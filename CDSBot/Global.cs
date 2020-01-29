using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSBot
{
    public enum UI_EVENT : int
    {
        INITIALIZED = 0,
        CONNECT_CLICK,
        DISCONNECT_CLICK,
        PREVIEW_CLICK,
        PLACE_CLICK,
        DELETE_CLICK,
        EXIT_CLICK
    }

    public enum LOGIC_EVENT : int
    {
        INIT_STEP = 0,
        API_SERVER_CONNECTING,
        API_SERVER_CONNECTED,
        API_SERVER_CONNECT_FAILED,
        API_SERVER_DISCONNECTING,
        API_SERVER_DISCONNECTED,

        TICKERS_LOADED,
        TICKERS_LOAD_FAILED,
        WALLETS_SNAPSHOT,
        WALLET_UPDATE,
        BALANCES_LOAD_FAILED,
        ORDERS_SNAPSHOT,
        ORDER_NEW,
        ORDER_UPDATE,
        ORDER_CANCEL,
        ORDERS_LOAD_FAILED,
        POSITIONS_SNAPSHOT,
        POSITION_NEW,
        POSITION_UPDATE,
        POSITION_CANCEL,
        POSITIONS_LOAD_FAILED,
        PREVIEWS_MADE,
        PLACE_DONE,
        PLACE_DONE_FAILED,
        EXIT_APP
    }

    public delegate void UIEvent(UI_EVENT evt, Object args);
    public delegate void LogicEvent(LOGIC_EVENT evt, Object args);
    
    class Global
    {
        public static string API_PUBLIC_KEY = "";
        public static string API_SECRET_KEY = "";
        public static ShortOrderParam _shortOrderParam;
        public static ConditionalOrderParam _conditionalOrderParam;

        public static List<TrailingOrder> _previewOrders = new List<TrailingOrder>();
        public static List<TrailingOrder> _sellingOrders = new List<TrailingOrder>();
        public static List<TrailingOrder> _pendingOrders = new List<TrailingOrder>();
        public static List<TrailingOrder> _waitingOrders = new List<TrailingOrder>();

        public static bool _deleteAllOrders = false;

        public static readonly String APP_KEY = ")FWD(WXC*12&EWBVC^%DF3SW$#Q@!";
        public static bool LOG_TO_FILE = true;
        public static bool IS_DEBUG = true;

        public static Dictionary<string, double> _tickerPricePairs = new Dictionary<string, double>() {
            {"tBTCUSD",0.0},
            {"tBTCUSDT",0.0},
            {"tETHUSD",0.0},
            {"tETHUSDT",0.0},
            {"tBSVUSD",0.0},
            {"tETCUSD",0.0},
            {"tBCHUSD",0.0},
            {"tEOSUSD",0.0},
            {"tXRPUSD",0.0},
            {"tLTCUSD",0.0},
            {"tUSDTUSD",0.0},
            {"tDASHUSD",0.0},
            {"tIOTAUSD",0.0},
            {"tNEOUSD",0.0},
            {"tZECUSD",0.0},
            {"tBTGUSD",0.0},
            {"tLEOUSD",0.0},
            {"tLEOUSDT",0.0},
            {"tXMRUSD",0.0},
            {"tOMGUSD",0.0},
            {"tZRXUSD",0.0},
            {"tXLMUSD",0.0},
            {"tETPUSD",0.0},
            {"tXTZUSD",0.0},
            {"tSANUSD",0.0},
            {"tEDOUSD",0.0}
        };

        public static Dictionary<string, double> _tickerMinSizePairs = new Dictionary<string, double>() {
            {"tBTCUSD",0.0},
            {"tBTCUSDT",0.0},
            {"tETHUSD",0.0},
            {"tETHUSDT",0.0},
            {"tBSVUSD",0.0},
            {"tETCUSD",0.0},
            {"tBCHUSD",0.0},
            {"tEOSUSD",0.0},
            {"tXRPUSD",0.0},
            {"tLTCUSD",0.0},
            {"tUSDTUSD",0.0},
            {"tDASHUSD",0.0},
            {"tIOTAUSD",0.0},
            {"tNEOUSD",0.0},
            {"tZECUSD",0.0},
            {"tBTGUSD",0.0},
            {"tLEOUSD",0.0},
            {"tLEOUSDT",0.0},
            {"tXMRUSD",0.0},
            {"tOMGUSD",0.0},
            {"tZRXUSD",0.0},
            {"tXLMUSD",0.0},
            {"tETPUSD",0.0},
            {"tXTZUSD",0.0},
            {"tSANUSD",0.0},
            {"tEDOUSD",0.0}
        };
    }
}
