using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSBot
{
    class TickerAgent
    {
        private List<WebSocketSharp.WebSocket> _wsList;

        public async Task Init(bool flag)
        {
            if (flag)
            {
                var symbolsData = await NetHelper.GetSymbolDetails();
                if (!string.IsNullOrEmpty(symbolsData))
                {
                    dynamic symbols = JsonConvert.DeserializeObject(symbolsData);
                    foreach (dynamic symbol in symbols)
                    {
                        var pair = $"t{Convert.ToString(symbol.pair).ToUpper()}";
                        if (!Global._tickerMinSizePairs.ContainsKey(pair))
                        {
                            continue;
                        }
                        Global._tickerMinSizePairs[pair] = Convert.ToDouble(symbol.minimum_order_size);
                    }
                }

                _wsList = new List<WebSocketSharp.WebSocket>();
                string[] pairs = Global._tickerPricePairs.Keys.ToArray();
                foreach (var pair in pairs)
                {
                    dynamic payload = new System.Dynamic.ExpandoObject();
                    ((IDictionary<string, object>)payload)["event"] = "subscribe";
                    ((IDictionary<string, object>)payload)["channel"] = "ticker";
                    ((IDictionary<string, object>)payload)["symbol"] = pair;

                    var _subscribeWS = new WebSocketSharp.WebSocket("wss://api-pub.bitfinex.com/ws/2");
                    _subscribeWS.OnMessage += (sender, e) => this.SubscribeFunc(pair, e.Data);
                    _subscribeWS.Connect();
                    _wsList.Add(_subscribeWS);
                    _subscribeWS.Send(JsonConvert.SerializeObject(payload));
                }
            } else
            {
                foreach (var subscribeWS in _wsList)
                {
                    subscribeWS.Close();
                }
                _wsList.Clear();
            }
        }

        private void SubscribeFunc(string pair, string data)
        {
            try
            {
                dynamic tickerData = JsonConvert.DeserializeObject(data);
                var last_price = Convert.ToDouble(tickerData[1][6]);
                lock (Global._tickerPricePairs)
                {
                    Global._tickerPricePairs[pair] = last_price;
                }
            } catch (Exception e)
            {
                return;
            }
        }

        public static double TickerPrice(string pair)
        {
            var price = 0.0;
            lock (Global._tickerPricePairs)
            {
                price = Global._tickerPricePairs.ContainsKey(pair) ? Global._tickerPricePairs[pair] : 0.0;
            }
            return price;
        }

        public static double LimitedOrderSize(string pair)
        {
            var order_size = 0.0;
            order_size = Global._tickerMinSizePairs.ContainsKey(pair) ? Global._tickerMinSizePairs[pair] : 0.0;
            
            return order_size;
        }
    }
}
