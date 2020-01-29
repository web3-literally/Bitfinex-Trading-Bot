using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDSBot
{
    class OrderAgent
    {
        private System.Timers.Timer _mainTimer;
        private byte _timerCount;
        private bool _shouldTimerRun;

        public OrderAgent()
        {
            _mainTimer = new System.Timers.Timer(1000);
            _mainTimer.Elapsed += this.TimerElapsed;
            _mainTimer.Enabled = false;
            _shouldTimerRun = false;
        }

        public List<string> PreviewOrders(ShortOrderParam shortOrderParam)
        {
            Helper.Log(string.Format("Making orders preview with input {0}...", shortOrderParam.ToString()));
            var previews = new List<string>();
            var ticker = shortOrderParam.TickerChoice;
            if (ticker == null)
            {
                return previews;
            }

            Config.SaveShortOrderParams(shortOrderParam);
            var market_price = TickerAgent.TickerPrice(ticker.Pair);
            var limited_order_size = TickerAgent.LimitedOrderSize(ticker.Pair);
            double amount = shortOrderParam.Amount;
            double low = shortOrderParam.LowerPrice;
            double high = shortOrderParam.UpperPrice;
            int count = shortOrderParam.OrderCount;
            double pstep = (high - low) / (count - 1);
            var scale_type = shortOrderParam.DistributionType;
            double min_size = Math.Max(limited_order_size, shortOrderParam.MinSize);
            double exp = shortOrderParam.Coefficient;

            if (min_size * count > amount)
            {
                count = (int)Math.Floor(amount / min_size) - 1;
                Helper.Log(string.Format("min_size {0} amount {1} count was reset to {2}", min_size, amount, count));
                if (count < 0)
                {
                    return previews;
                }
                previews.Add(count.ToString());
            }
            else
            {
                previews.Add("match");
            }
            if (count <= 0)
            {
                return previews;
            }

            double size_max = ((amount - min_size * count) * 2) / count + min_size;
            double sum = 0;
            double first_value = 1;
            for (double i = 0; i < count; i++)
            {
                sum = sum + Math.Pow(exp, i);
            }
            first_value = (amount - min_size * count) / sum;
            if (first_value < 0)
            {
                first_value = 0;
            }

            double[] sizes = new double[count];
            for (int i = 0; i < count; i++)
            {
                switch (scale_type)
                {
                    case DISTRIBUTION_TYPE.FLAT:
                        sizes[i] = amount / count;
                        break;
                    case DISTRIBUTION_TYPE.LINEAR_UP:
                        sizes[i] = min_size + (size_max - min_size) / (count - 1) * i;
                        break;
                    case DISTRIBUTION_TYPE.LINEAR_DN:
                        sizes[i] = min_size + (size_max - min_size) / (count - 1) * (count - i - 1);
                        break;
                    case DISTRIBUTION_TYPE.EXPONENTIAL_UP:
                        sizes[i] = min_size + first_value * Math.Pow(exp, i);
                        break;
                    case DISTRIBUTION_TYPE.EXPONENTIAL_DN:
                        sizes[i] = min_size + first_value * Math.Pow(exp, count - i - 1);
                        break;
                    default:
                        sizes[i] = amount / count;
                        break;
                }
            }

            var previewContent = "";
            previewContent = string.Format("Current price: {0}", market_price);
            previewContent += Environment.NewLine;

            lock (Global._previewOrders)
            {
                Global._previewOrders.Clear();
                for (int i = 0; i < count; i++)
                {
                    double p = low + i * pstep;
                    string ex_price = p.ToString("F5");
                    var txt = "at " + ex_price;

                    var order = new TrailingOrder();
                    order.Symbol = ticker.Pair;
                    order.Price = Convert.ToDouble(ex_price);
                    order.Exchange = "bitfinex";

                    // buy order
                    order.BuyAmount = sizes[i];
                    var type = "TRAILING STOP";
                    order.BuyType = type;
                    txt += string.Format(" buy {0} size: {1}", type, sizes[i].ToString());

                    // sell order
                    order.SellAmount = sizes[count - i - 1];
                    type = p > market_price ? "LIMIT" : "TRAILING STOP";
                    order.SellType = type;
                    txt += string.Format(" sell {0} size: {1}", type, sizes[count - i - 1].ToString());
                    txt += Environment.NewLine;

                    previewContent += txt;
                    Global._previewOrders.Add(order);
                }

                previews.Add(previewContent);
                Helper.Log(string.Format("order data was made {0} (preview {1})",
                    string.Join<TrailingOrder>(" ", Global._previewOrders), previewContent));
            }

            return previews;
        }

        public async Task PlaceOrders(ConditionalOrderParam conditionalOrderParam)
        {
            Config.SaveConditionalOrderParam(conditionalOrderParam);

            foreach (TrailingOrder order in Global._previewOrders)
            {
                order.TargetOrPercent = conditionalOrderParam.TargetOrPercent;
                order.ProfitParam = order.TargetOrPercent
                    ? conditionalOrderParam.ProfitTarget : conditionalOrderParam.ProfitPercent;
                order.TrailingStopBuyDistance = conditionalOrderParam.Distance;
                order.Fee = conditionalOrderParam.Fee;
            }

            var notPlacedOrders = new List<TrailingOrder>();
                       
            string response = await NetHelper.SendMultiOrders(
                            Global.API_PUBLIC_KEY, Global.API_SECRET_KEY, true, Global._previewOrders);
            if (string.IsNullOrEmpty(response))
            {
                notPlacedOrders.AddRange(Global._previewOrders);
            }
            else
            {
                Helper.Log(string.Format("create multi sell orders {0}", response));
                dynamic data = JsonConvert.DeserializeObject(response);
                dynamic orders_response = data[4];
                var index = 0;
                foreach (dynamic order_reponse in orders_response)
                {
                    if (order_reponse[6] != "SUCCESS")
                    {
                        Helper.Log($"Not success in creating order {order_reponse[7]}");
                        notPlacedOrders.Add(Global._previewOrders.ElementAt(index));
                    }
                    else
                    {
                        var pendingOrder = Global._previewOrders.ElementAt(index);
                        pendingOrder.LinkedSellOrderId = Convert.ToString(order_reponse[4][0][0]);
                        lock (Global._pendingOrders)
                        {
                            Global._pendingOrders.Add(pendingOrder);
                        }
                    }
                    index++;
                }
            }

            Global._previewOrders.Clear();
            if (notPlacedOrders.Count > 0)
            {
                Global._previewOrders.AddRange(notPlacedOrders);
            }

            Helper.Log(string.Format("Place orders {0}",
                    string.Join<TrailingOrder>(Environment.NewLine, Global._previewOrders)));
        }

        public void SellOrderFilled(Position position)
        {
            dynamic meta = JsonConvert.DeserializeObject(position.Meta);
            if (meta.trade_amount > 0)
            {   // This is not sell order
                return;
            }
            lock (Global._pendingOrders)
            {
                foreach (TrailingOrder order in Global._pendingOrders)
                {
                    if (order.LinkedSellOrderId == Convert.ToString(meta.order_id))
                    {
                        Helper.Log($"Sell order {position.Meta} just filled...");
                        order.SellFilledPrice = Convert.ToDouble(meta.trade_price);
                        order.SellFilledAmount = Convert.ToDouble(meta.trade_amount);

                        lock (Global._waitingOrders)
                        {
                            Global._waitingOrders.Add(order);
                        }
                        Global._pendingOrders.Remove(order);
                        break;
                    }
                }
            }
        }

        public async Task DeleteAllOrders()
        {
            string response = await NetHelper.CancelAllOrder(Global.API_PUBLIC_KEY, Global.API_SECRET_KEY);
            Helper.Log(string.Format("Delete all orders {0}", response));
        }

        public void EnableAlgorithm(bool flag)
        {
            _shouldTimerRun = flag;
            _mainTimer.Enabled = flag;
        }

        private async void TimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!_shouldTimerRun)
            {
                _mainTimer.Enabled = false;
            }

            var buy_orders_to_send = new List<TrailingOrder>();

            lock (Global._waitingOrders)
            {
                foreach (var waiting_order in Global._waitingOrders)
                {
                    var pair = waiting_order.Symbol;
                    var market_price = 0.0;
                    lock (Global._tickerPricePairs)
                    {
                        market_price = Global._tickerPricePairs.ContainsKey(pair) ? Global._tickerPricePairs[pair] : 0.0;
                    }
                    var sell_price = waiting_order.SellFilledPrice;
                    var sell_amount = waiting_order.SellFilledAmount;
                    var buy_amount = waiting_order.BuyAmount;
                    var stop_buy_distance = waiting_order.TrailingStopBuyDistance;
                    var fee = waiting_order.Fee;
                    var profit_target_price = market_price + stop_buy_distance;

                    var profit_target = (sell_price - market_price) * sell_amount 
                        - profit_target_price * buy_amount * fee
                        - sell_price * sell_amount * fee;

                    var profit_percent = 1 - profit_target_price / sell_price;

                    bool buy_order_meet_condition = false;
                    if (waiting_order.TargetOrPercent)
                    {   // Profit target should meet condition
                        buy_order_meet_condition = profit_target > waiting_order.ProfitParam;
                    } else
                    {   // Profit percent should meet condition
                        buy_order_meet_condition = profit_percent > waiting_order.ProfitParam;
                    }

                    if (buy_order_meet_condition)
                    {   // This trailing stop buy order meet condition
                        waiting_order.Price = profit_target_price;
                        buy_orders_to_send.Add(waiting_order);
                        Global._waitingOrders.Remove(waiting_order);
                    }
                }
            }

            if (buy_orders_to_send.Count > 0)
            {
                string response = await NetHelper.SendMultiOrders(
                            Global.API_PUBLIC_KEY, Global.API_SECRET_KEY, false, buy_orders_to_send);
                if (string.IsNullOrEmpty(response))
                {
                    lock (Global._waitingOrders)
                    {
                        Global._waitingOrders.AddRange(buy_orders_to_send);
                    }
                    return;
                }
                else
                {
                    dynamic data = JsonConvert.DeserializeObject(response);
                    dynamic orders_response = data[4];
                    var index = 0;
                    foreach (dynamic order_reponse in orders_response)
                    {
                        var waiting_order = buy_orders_to_send.ElementAt(index);

                        if (order_reponse[6] != "SUCCESS")
                        {
                            Helper.Log($"creating buy order failed : {order_reponse[7]}");
                            lock (Global._waitingOrders)
                            {
                                Global._waitingOrders.Add(waiting_order);
                            }
                        }
                        else
                        {
                            Helper.Log($"New buy order created {order_reponse}");
                        }
                        index++;
                    }
                }
            }
        }
    }
}
