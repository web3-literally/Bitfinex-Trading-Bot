using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSBot
{
    public enum DISTRIBUTION_TYPE: byte
    {
        FLAT = 0,
        LINEAR_UP,
        LINEAR_DN,
        EXPONENTIAL_UP,
        EXPONENTIAL_DN,
    }

    class Model
    {
    }

    class Wallet
    {
        public Wallet(dynamic walletData)
        {
            Type = walletData[0];
            Currency = walletData[1];
            Amount = walletData[2];
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _type;

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        private string _currency;

        public float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private float _amount;

        public float Available
        {
            get { return _available; }
            set { _available = value; }
        }
        private float _available;

        public object[] ToDisplayDatas()
        {
            return new object[] { Currency, Amount };
        }
    }

    class TickerDetail
    {
        [JsonProperty("mid")]
        public double MId
        {
            get { return _mid; }
            set { _mid = value; }
        }
        private double _mid;

        [JsonProperty("bid")]
        public double BId
        {
            get { return _bid; }
            set { _bid = value; }
        }
        private double _bid;

        [JsonProperty("ask")]
        public double Ask
        {
            get { return _ask; }
            set { _ask = value; }
        }
        private double _ask;

        [JsonProperty("last_price")]
        public double LastPrice
        {
            get { return _last_price; }
            set { _last_price = value; }
        }
        private double _last_price;

        [JsonProperty("low")]
        public double Low
        {
            get { return _low; }
            set { _low = value; }
        }
        private double _low;

        [JsonProperty("high")]
        public double High
        {
            get { return _high; }
            set { _high = value; }
        }
        private double _high;

        [JsonProperty("volume")]
        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
        private double _volume;

        [JsonProperty("timestamp")]
        public double TimeStamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
        private double _timestamp;
    }

    class Ticker
    {
        public string Pair
        {
            get { return _pair; }
            set { _pair = value; }
        }
        private string _pair;

        public int LastPrice
        {
            get { return _last_price; }
            set { _last_price = value; }
        }
        private int _last_price;
        
        public float MinimumOrderSize
        {
            get { return _minimum_order_size; }
            set { _minimum_order_size = value; }
        }
        private float _minimum_order_size;

        override
        public string ToString()
        {
            return Pair;
        }
    }

    class Order
    {
        public Order(dynamic orderData)
        {
            Id = Convert.ToString(orderData[0]);
            Symbol = Convert.ToString(orderData[3]);
            Type = Convert.ToString(orderData[8]);
            Status = Convert.ToString(orderData[13]);
            //Price = Type == "TRAILING STOP" ? Convert.ToDouble(orderData[18]) : Convert.ToDouble(orderData[16]);
            Price = Convert.ToDouble(orderData[16]);
            AvgPrice = Convert.ToDouble(orderData[17]);
            Amount = Convert.ToDouble(orderData[6]);
            OriginalAmount = Convert.ToDouble(orderData[7]);
            CreatedAt = Convert.ToInt64(orderData[4]);
            UpdatedAt = Convert.ToInt64(orderData[5]);
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _id;

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        private string _symbol;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _type;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _status;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private double _price;

        public double AvgPrice
        {
            get { return _avg_price; }
            set { _avg_price = value; }
        }
        private double _avg_price;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private double _amount;

        public double OriginalAmount
        {
            get { return _orig_amount; }
            set { _orig_amount = value; }
        }
        private double _orig_amount;

        public long CreatedAt
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        private long _created_at;

        public long UpdatedAt
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }
        private long _updated_at;

        public object[] ToDisplayDatas()
        {
            return new object[] { Id, Symbol, Type, Status, Price, AvgPrice, Amount, OriginalAmount,
                Helper.Timestamp2DateString(CreatedAt), Helper.Timestamp2DateString(UpdatedAt) };
        }
    }

    class Position
    {
        public Position(dynamic positionData)
        {
            Id = Convert.ToString(positionData[11]);
            Symbol = Convert.ToString(positionData[0]);
            Status = Convert.ToString(positionData[1]);
            BasePrice = Convert.ToDouble(positionData[3]);
            Amount = Convert.ToDouble(positionData[2]);
            //CreatedAt = Convert.ToInt64(positionData[12]),
            //UpdatedAt = Convert.ToInt64(positionData[13]),
            //PL = Convert.ToDouble(positionData[6]),
            Meta = Convert.ToString(positionData[19]);
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _id;
        
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        private string _symbol;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _status;
        
        public double BasePrice
        {
            get { return _base_price; }
            set { _base_price = value; }
        }
        private double _base_price;
        
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private double _amount;

        public long CreatedAt
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        private long _created_at;

        public long UpdatedAt
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }
        private long _updated_at;

        public double PL
        {
            get { return _pl; }
            set { _pl = value; }
        }
        private double _pl;

        public string Meta
        {
            get { return _meta; }
            set { _meta = value; }
        }
        private string _meta;

        public object[] ToDisplayDatas()
        {
            return new object[] { Id, Symbol, Status, BasePrice, Amount, Meta};
        }
    }

    class ShortOrderParam
    {
        public Ticker TickerChoice
        {
            get { return _tickerChoice; }
            set { _tickerChoice = value; }
        }
        private Ticker _tickerChoice;

        public DISTRIBUTION_TYPE DistributionType
        {
            get { return _distributionType; }
            set { _distributionType = value; }
        }
        private DISTRIBUTION_TYPE _distributionType;

        public double LowerPrice
        {
            get { return _lowerPrice; }
            set { _lowerPrice = value; }
        }
        private double _lowerPrice;

        public double UpperPrice
        {
            get { return _upperPrice; }
            set { _upperPrice = value; }
        }
        private double _upperPrice;

        public double Coefficient
        {
            get { return _coefficient; }
            set { _coefficient = value; }
        }
        private double _coefficient;
        
        public double MinSize
        {
            get { return _minSize; }
            set { _minSize = value; }
        }
        private double _minSize;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private double _amount;

        public int OrderCount
        {
            get { return _orderCount; }
            set { _orderCount = value; }
        }
        private int _orderCount;
    }

    class ConditionalOrderParam
    {
        public double ProfitTarget
        {
            get { return _profitTarget; }
            set { _profitTarget = value; }
        }
        private double _profitTarget;

        public double ProfitPercent
        {
            get { return _profitPercent; }
            set { _profitPercent = value; }
        }
        private double _profitPercent;

        public bool TargetOrPercent
        {
            get { return _target_or_percent; }
            set { _target_or_percent = value; }
        }
        private bool _target_or_percent;

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        private double _distance;

        public double Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }
        private double _fee;
    }

    class TrailingOrder
    {
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        private string _symbol;

        public double SellAmount
        {
            get { return _sell_amount; }
            set { _sell_amount = value; }
        }
        private double _sell_amount;

        public double BuyAmount
        {
            get { return _buy_amount; }
            set { _buy_amount = value; }
        }
        private double _buy_amount;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private double _price;

        public string Exchange
        {
            get { return _exchange; }
            set { _exchange = value; }
        }
        private string _exchange;

        public string SellType
        {
            get { return _sell_type; }
            set { _sell_type = value; }
        }
        private string _sell_type;

        public string BuyType
        {
            get { return _buy_type; }
            set { _buy_type = value; }
        }
        private string _buy_type;

        public string LinkedSellOrderId
        {
            get { return _linked_sell_order_id; }
            set { _linked_sell_order_id = value; }
        }
        private string _linked_sell_order_id;

        public double SellFilledPrice
        {
            get { return _sell_filled_price; }
            set { _sell_filled_price = value; }
        }
        private double _sell_filled_price;

        public double SellFilledAmount
        {
            get { return _sell_filled_amount; }
            set { _sell_filled_amount = value; }
        }
        private double _sell_filled_amount;

        public bool TargetOrPercent
        {
            get { return _target_or_percent; }
            set { _target_or_percent = value; }
        }
        private bool _target_or_percent;

        public double ProfitParam
        {
            get { return _profit_param; }
            set { _profit_param = value; }
        }
        private double _profit_param;

        public double TrailingStopBuyDistance
        {
            get { return _trailing_stop_buy_distance; }
            set { _trailing_stop_buy_distance = value; }
        }
        private double _trailing_stop_buy_distance;

        public double Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }
        private double _fee;
        
        public dynamic OrderDataForApi(bool isSell)
        {
            var market_price = TickerAgent.TickerPrice(Symbol);

            dynamic orderData = new List<dynamic>();
            orderData.Add("on");
            dynamic orderBody = new System.Dynamic.ExpandoObject();
            orderBody.type = (isSell ? SellType : BuyType);
            orderBody.symbol = Symbol;
            if (orderBody.type == "TRAILING STOP")
            {
                orderBody.price = Convert.ToString(Math.Abs(Price - market_price));
            } else
            {
                orderBody.price = Convert.ToString(Price);
            }
            
            orderBody.amount = Convert.ToString(isSell ? -SellAmount : BuyAmount);
            orderBody.flags = 0;
            orderData.Add(orderBody);

            return orderData;
        }
    }
}
