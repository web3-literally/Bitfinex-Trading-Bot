using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDSBot
{
    class NetHelper
    {
        private static readonly HttpClient client = new HttpClient();
                
        private static async Task<string> DoHttpRequestAsync(
                    string subUri, string publicKey, string secretKey, Action<string> callback, dynamic body = null)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
            long nonce = (long)Math.Floor(diff.TotalMilliseconds);
            var rawBody = JsonConvert.SerializeObject(body == null ? new { } : body);

            string signature = $"/api/{subUri}{nonce}{rawBody}";
            var hmac = new HMACSHA384(Encoding.UTF8.GetBytes(secretKey));
            byte[] k = hmac.ComputeHash(Encoding.UTF8.GetBytes(signature));
            string signatureString = string.Concat(k.Select(b => b.ToString("X2")).ToArray()).ToLower();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("bfx-nonce", nonce.ToString());
            client.DefaultRequestHeaders.TryAddWithoutValidation("bfx-apikey", publicKey);
            client.DefaultRequestHeaders.TryAddWithoutValidation("bfx-signature", signatureString);
            var response = await client.PostAsync($"https://api.bitfinex.com/{subUri}", 
                                    new StringContent(rawBody, Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();

            if (callback != null)
            {
                callback(responseString);
            }

            return responseString;
        }

        public static async Task GetBalance(string publicKey, string secretKey, Action<string> callback)
        {
            try
            {
                await DoHttpRequestAsync("v2/auth/r/wallets", publicKey, secretKey, callback);
            } catch (WebException e)
            {
                Helper.Log(string.Format("Exception in GetBalance {0}", e.Message));
                callback(null);
            }
        }

        public static async void GetTickersInfo(Action<string> callback)
        {
            var url = "https://api-pub.bitfinex.com/v2/tickers?symbols=ALL";
            var webClient = new WebClient();
            var responseString = await webClient.DownloadStringTaskAsync(new Uri(url, UriKind.Absolute));
            if (callback != null)
            {
                callback(responseString);
            }
        }

        public static async Task<string> GetSymbolDetails()
        {
            var url = "https://api.bitfinex.com/v1/symbols_details";
            var webClient = new WebClient();
            var responseString = await webClient.DownloadStringTaskAsync(new Uri(url, UriKind.Absolute));
            return responseString;
        }

        public static async Task<string> GetTickerInfo(string ticker)
        {
            try
            {
                var url = "https://api-pub.bitfinex.com/v2/ticker/" + ticker;
                var webClient = new WebClient();
                var responseString = await webClient.DownloadStringTaskAsync(new Uri(url, UriKind.Absolute));
                return responseString;
            } catch (Exception e)
            {
                Helper.Log(string.Format("Exception in GetTickerInfo {0}", e.Message));
                return null;
            }
        }

        public static async Task GetActiveOrders(string publicKey, string secretKey, Action<string> callback)
        {
            try
            {
                await DoHttpRequestAsync("v2/auth/r/orders", publicKey, secretKey, callback);
            }
            catch (WebException e)
            {
                Helper.Log(string.Format("Exception in GetActiveOrders {0}", e.Message));
                callback(null);
            }
        }

        public static async Task GetActivePositions(string publicKey, string secretKey, Action<string> callback)
        {
            try
            {
                await DoHttpRequestAsync("v2/auth/r/positions", publicKey, secretKey, callback);
            }
            catch (WebException e)
            {
                Helper.Log(string.Format("Exception in GetPositions {0}", e.Message));
                callback(null);
            }
        }

        public static async Task<string> CancelAllOrder(string publicKey, string secretKey)
        {
            try
            {
                dynamic payload = new System.Dynamic.ExpandoObject();
                payload.all = 1;
                string response = await DoHttpRequestAsync("v2/auth/w/order/cancel/multi", publicKey, secretKey, null, payload);
                return response;
            } catch (WebException e)
            {
                Helper.Log(string.Format("Exception in CancelOrder {0}", e.Message));
                return null;
            }
        }

        public static async Task<string> SendMultiOrders(string publicKey, string secretKey, 
            bool isSell, List<TrailingOrder> ordersForSend)
        {
            try
            {
                dynamic payload = new System.Dynamic.ExpandoObject();
                payload.ops = new List<dynamic>();
                foreach (var orderForSend in ordersForSend)
                {
                    payload.ops.Add(orderForSend.OrderDataForApi(isSell));
                }
                
                string response = await DoHttpRequestAsync("v2/auth/w/order/multi",
                                                publicKey, secretKey, null, payload);
                return response;
            }
            catch (WebException e)
            {
                Helper.Log(string.Format("Exception in SendMultiOrders {0}", e.Message));
                return null;
            }
        }
    }
}
