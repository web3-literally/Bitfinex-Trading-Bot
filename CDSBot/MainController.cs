using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CDSBot
{
    class MainController
    {
        public static event LogicEvent LogicEventListener;

        private OrderAgent _orderAgent;
        private SubscribeAgent _subscribeAgent;
        private TickerAgent _tickerAgent;

        public MainController()
        {
            Config.LoadConfig();
            MainUI.UIEventListener += new UIEvent(this.OnUIEvent);

            _orderAgent = new OrderAgent();            
            _subscribeAgent = new SubscribeAgent();
            _subscribeAgent.ActionWalletSnapshot = this.WalletSnapshot;
            _subscribeAgent.ActionWalletUpdate = this.WalletUpdate;
            _subscribeAgent.ActionOrderSnapshot = this.OrderSnapshot;
            _subscribeAgent.ActionOrderUpdate = this.OrderUpdate;
            _subscribeAgent.ActionPositionSnapshot = this.PositionSnapshot;
            _subscribeAgent.ActionPositionUpdate = this.PositionUpdate;
            _tickerAgent = new TickerAgent();
        }

        private async void OnUIEvent(UI_EVENT evt, Object param)
        {
            LogicEvent handler = LogicEventListener;
            if (handler == null)
            {
                return;
            }
            switch (evt)
            {
                case UI_EVENT.INITIALIZED:
                    NetHelper.GetTickersInfo(this.GetTickerResult);
                    break;
                case UI_EVENT.CONNECT_CLICK:
                    Helper.Log("Connecting to api server...");
                    string[] keys = ((IEnumerable)param).Cast<object>()
                                 .Select(x => x.ToString()).ToArray();
                    string publicKey = keys[0];
                    string secretKey = keys[1];
                    Config.SaveKeys(publicKey, secretKey);
                    handler(LOGIC_EVENT.API_SERVER_CONNECTING, this);
                    _subscribeAgent.EnableSubscribe(true);
                    _orderAgent.EnableAlgorithm(true);
                    await _tickerAgent.Init(true);
                    handler(LOGIC_EVENT.API_SERVER_CONNECTED, this);
                    break;
                case UI_EVENT.DISCONNECT_CLICK:
                    Helper.Log("Disconnecting from api server...");
                    handler(LOGIC_EVENT.API_SERVER_DISCONNECTING, this);
                    _subscribeAgent.EnableSubscribe(false);
                    _orderAgent.EnableAlgorithm(false);
                    await _tickerAgent.Init(false);
                    handler(LOGIC_EVENT.API_SERVER_DISCONNECTED, this);
                    break;
                case UI_EVENT.PREVIEW_CLICK:
                    List<string> previews = _orderAgent.PreviewOrders((ShortOrderParam)param);
                    handler(LOGIC_EVENT.PREVIEWS_MADE, previews);
                    break;
                case UI_EVENT.PLACE_CLICK:
                    await _orderAgent.PlaceOrders((ConditionalOrderParam)param);
                    handler(LOGIC_EVENT.PLACE_DONE, this);
                    break;
                case UI_EVENT.DELETE_CLICK:
                    await _orderAgent.DeleteAllOrders();
                    break;
                case UI_EVENT.EXIT_CLICK:
                    Helper.Log("Exiting app...");
                    handler(LOGIC_EVENT.EXIT_APP, this);
                    break;
            }
        }

        private void OrderSnapshot(dynamic orders)
        {
            LogicEvent handler = LogicEventListener;
            var ordersCount = orders.Count;
            var structured_orders = new List<Order>();
            foreach (dynamic order in orders)
            {
                if (order.Count < 32)
                {
                    continue;
                }
                var structured_order = new Order(order);
                structured_orders.Add(structured_order);
            }
            handler(LOGIC_EVENT.ORDERS_SNAPSHOT, structured_orders);
        }

        private void OrderUpdate(string eventType, dynamic orderData)
        {
            LogicEvent handler = LogicEventListener;
            
            if (orderData.Count < 32)
            {
                return;
            }
            var order = new Order(orderData);
            if (eventType == "on")
            {
                handler(LOGIC_EVENT.ORDER_NEW, order);
            } else if (eventType == "ou")
            {
                handler(LOGIC_EVENT.ORDER_UPDATE, order);
            } else if (eventType == "oc")
            {
                handler(LOGIC_EVENT.ORDER_CANCEL, order);
            }
        }

        private void PositionSnapshot(dynamic positions)
        {
            LogicEvent handler = LogicEventListener;
            var structured_positions = new List<Position>();
            foreach (var position in positions)
            {
                if (position.Count < 20)
                {
                    continue;
                }
                var structured_position = new Position(position);
                structured_positions.Add(structured_position);
            }
            handler(LOGIC_EVENT.POSITIONS_SNAPSHOT, structured_positions);
        }

        private void PositionUpdate(string eventType, dynamic positionData)
        {
            LogicEvent handler = LogicEventListener;
            if (positionData.Count < 20)
            {
                return;
            }
            var position = new Position(positionData);
            if (eventType == "pn")
            {
                _orderAgent.SellOrderFilled(position);
                handler(LOGIC_EVENT.POSITION_NEW, position);
            } else if (eventType == "pu")
            {
                handler(LOGIC_EVENT.POSITION_UPDATE, position);
            } else if (eventType == "pc")
            {
                handler(LOGIC_EVENT.POSITION_CANCEL, position);
            }
        }

        private void GetTickerResult(string response)
        {
            LogicEvent handler = LogicEventListener;
            if (string.IsNullOrEmpty(response))
            {
                Helper.Log("Get ticker from api server failed...");
                handler(LOGIC_EVENT.TICKERS_LOAD_FAILED, this);
            } else
            {
                var tickers = JsonConvert.DeserializeObject<List<dynamic>>(response);
                var structured_tickers = new List<Ticker>();
                foreach (dynamic ticker in tickers)
                {
                    if (ticker.Count == 11)
                    {
                        var structured_ticker = new Ticker()
                        {
                            Pair = ticker[0],
                            LastPrice = ticker[7],
                        };
                        structured_tickers.Add(structured_ticker);
                    }
                }
                Helper.Log(string.Format("Get ticker from api server {0}", response));
                handler(LOGIC_EVENT.TICKERS_LOADED, structured_tickers);
            }
        }

        private void WalletSnapshot(dynamic wallets)
        {
            LogicEvent handler = LogicEventListener;
            
            var structured_wallets = new List<Wallet>();
            foreach (dynamic wallet in wallets)
            {
                if (wallet.Count != 7 || wallet[0] != "margin")
                {
                    continue;
                }
                var structured_balance = new Wallet(wallet);
                structured_wallets.Add(structured_balance);
            }
            handler(LOGIC_EVENT.WALLETS_SNAPSHOT, structured_wallets);
        }

        private void WalletUpdate(dynamic walletData)
        {
            LogicEvent handler = LogicEventListener;

            if (walletData.Count != 7 || walletData[0] != "margin")
            {
                return;
            }

            var wallet = new Wallet(walletData);
            handler(LOGIC_EVENT.WALLET_UPDATE, wallet);
        }
    }
}
