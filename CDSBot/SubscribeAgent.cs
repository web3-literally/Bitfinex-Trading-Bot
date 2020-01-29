using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebSocketSharp;

namespace CDSBot
{
    class SubscribeAgent
    {
        public Action<dynamic> ActionWalletSnapshot
        {
            get { return _action_wallet_snapshot; }
            set { _action_wallet_snapshot = value; }
        }
        private Action<dynamic> _action_wallet_snapshot;

        public Action<dynamic> ActionWalletUpdate
        {
            get { return _action_wallet_update; }
            set { _action_wallet_update = value; }
        }
        private Action<dynamic> _action_wallet_update;

        public Action<dynamic> ActionOrderSnapshot
        {
            get { return _action_order_snapshot; }
            set { _action_order_snapshot = value; }
        }
        private Action<dynamic> _action_order_snapshot;

        public Action<string, dynamic> ActionOrderUpdate
        {
            get { return _action_order_update; }
            set { _action_order_update = value; }
        }
        private Action<string, dynamic> _action_order_update;

        public Action<dynamic> ActionPositionSnapshot
        {
            get { return _action_position_snapshot; }
            set { _action_position_snapshot = value; }
        }
        private Action<dynamic> _action_position_snapshot;

        public Action<string, dynamic> ActionPositionUpdate
        {
            get { return _action_position_update; }
            set { _action_position_update = value; }
        }
        private Action<string, dynamic> _action_position_update;

        private WebSocketSharp.WebSocket _subscribeWS;

        private void SubscribeFunc(string data)
        {
            try
            {
                dynamic eventData = JsonConvert.DeserializeObject(data);
                var type = eventData[1];
                if (type == "os")
                {
                    Helper.Log($"Order snapshot from bitfinex {eventData}");
                    this.ActionOrderSnapshot(eventData[2]);
                }
                else if (type == "on")
                {
                    Helper.Log($"Order new from bitfinex {eventData}");
                    this.ActionOrderUpdate("on", eventData[2]);
                }
                else if (type == "ou")
                {
                    Helper.Log($"Order update from bitfinex {eventData}");
                    this.ActionOrderUpdate("ou", eventData[2]);
                }
                else if (type == "oc")
                {
                    Helper.Log($"Order cancel from bitfinex {eventData}");
                    this.ActionOrderUpdate("oc", eventData[2]);
                }
                else if (type == "ps")
                {
                    Helper.Log($"Position snapshot from bitfinex {eventData}");
                    this.ActionPositionSnapshot(eventData[2]);
                }
                else if (type == "pn")
                {
                    Helper.Log($"Position new from bitfinex {eventData}");
                    this.ActionPositionUpdate("pn", eventData[2]);
                }
                else if (type == "pu")
                {
                    //Helper.Log($"Position update from bitfinex {eventData}");
                    this.ActionPositionUpdate("pu", eventData[2]);
                }
                else if (type == "pc")
                {
                    Helper.Log($"Position cancel from bitfinex {eventData}");
                    this.ActionPositionUpdate("pc", eventData[2]);
                }
                else if (type == "ws")
                {
                    Helper.Log($"Wallet snapshot from bitfinex {eventData}");
                    this.ActionWalletSnapshot(eventData[2]);
                }
                else if (type == "wu")
                {
                    //Helper.Log($"Wallet update from bitfinex {eventData}");
                    this.ActionWalletUpdate(eventData[2]);
                }
            }
            catch (Exception e)
            {
                Helper.Log($"Subscribe function execption {e.Message}");
            }
        }

        public void EnableSubscribe(bool flag)
        {
            if (flag)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                long nonce = (long)Math.Floor(diff.TotalMilliseconds);

                var authPayload = $"AUTH{nonce}";
                var hmac = new HMACSHA384(Encoding.UTF8.GetBytes(Global.API_SECRET_KEY));
                byte[] k = hmac.ComputeHash(Encoding.UTF8.GetBytes(authPayload));
                string signatureString = string.Concat(k.Select(b => b.ToString("X2")).ToArray()).ToLower();

                dynamic payload = new System.Dynamic.ExpandoObject();
                payload.apiKey = Global.API_PUBLIC_KEY;
                payload.authSig = signatureString;
                payload.authNonce = nonce;
                payload.authPayload = authPayload;
                ((IDictionary<string, object>)payload)["event"] = "auth";
                payload.filter = new List<dynamic>();
                payload.filter.Add("trading");
                payload.filter.Add("wallet");
                payload.filter.Add("balance");

                _subscribeWS = new WebSocketSharp.WebSocket("wss://api.bitfinex.com/ws/2");
                _subscribeWS.OnMessage += (sender, e) => this.SubscribeFunc(e.Data);
                _subscribeWS.Connect();
                _subscribeWS.Send(JsonConvert.SerializeObject(payload));
            } else
            {
                _subscribeWS.Close();
                _subscribeWS = null;

                this.ActionWalletSnapshot(new List<dynamic>());
                this.ActionOrderSnapshot(new List<dynamic>());
                this.ActionPositionSnapshot(new List<dynamic>());
            }
        }
    }
}
