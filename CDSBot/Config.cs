using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSBot
{
    class Config
    {
        private static void AddConf(Configuration conf, string key, string value)
        {
            if (conf.AppSettings.Settings[key] != null)
            {
                conf.AppSettings.Settings[key].Value = value;
            } else
            {
                conf.AppSettings.Settings.Add(key, value);
            }
        }
        
        public static bool LoadConfig()
        {
            Helper.Log("Loading key from config file...");
            try
            {
                Global.API_PUBLIC_KEY = Helper.Decrypt(ConfigurationManager.AppSettings.Get("API_PUBLIC_KEY"));
                Global.API_SECRET_KEY = Helper.Decrypt(ConfigurationManager.AppSettings.Get("API_SECRET_KEY"));
            } catch (Exception e)
            {
                Helper.Log(string.Format("Loading api key failed... {0}", e.Message));
            }

            Global._shortOrderParam = new ShortOrderParam()
            {
                TickerChoice = new Ticker()
                                {
                                    Pair = ConfigurationManager.AppSettings.Get("TICKER")
                },
                DistributionType = Enum.GetValues(typeof(DISTRIBUTION_TYPE))
                                        .Cast<DISTRIBUTION_TYPE>()
                                        .FirstOrDefault(v => v.ToString() == ConfigurationManager.AppSettings.Get("API_PUBLIC_KEY")),
                LowerPrice = Convert.ToDouble(ConfigurationManager.AppSettings.Get("LOWER_PRICE")),
                UpperPrice = Convert.ToDouble(ConfigurationManager.AppSettings.Get("UPPER_PRICE")),
                Coefficient = Convert.ToDouble(ConfigurationManager.AppSettings.Get("COEFFICIENT")),
                MinSize = Convert.ToDouble(ConfigurationManager.AppSettings.Get("MIN_SIZE")),
                Amount = Convert.ToDouble(ConfigurationManager.AppSettings.Get("AMOUNT")),
                OrderCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ORDER_COUNT"))
            };

            Global._conditionalOrderParam = new ConditionalOrderParam()
            {
                ProfitTarget = Convert.ToDouble(ConfigurationManager.AppSettings.Get("PROFIT_TARGET")),
                ProfitPercent = Convert.ToDouble(ConfigurationManager.AppSettings.Get("PROFIT_PERCENT")),
                Distance = Convert.ToDouble(ConfigurationManager.AppSettings.Get("DISTANCE")),
                Fee = Convert.ToDouble(ConfigurationManager.AppSettings.Get("FEE")),
                TargetOrPercent = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("TARGET_OR_PERCENT"))
            };
            
            Helper.Log("Loaded key from config file...");
            return true;
        }

        public static bool SaveKeys(string publicKey, string secretKey)
        {
            Helper.Log("Saving key to config file...");
            Global.API_PUBLIC_KEY = publicKey;
            Global.API_SECRET_KEY = secretKey;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AddConf(conf, "API_PUBLIC_KEY", Helper.Encrypt(publicKey));
            AddConf(conf, "API_SECRET_KEY", Helper.Encrypt(secretKey));
            conf.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
            Helper.Log("Saved key to config file...");
            return true;
        }

        public static bool SaveShortOrderParams(ShortOrderParam shortOrderParam)
        {
            Helper.Log("Saving short order parameters to config file...");
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AddConf(conf, "TICKER", shortOrderParam.TickerChoice.Pair);
            AddConf(conf, "DISTRIBUTION_TYPE", Convert.ToString(shortOrderParam.DistributionType));
            AddConf(conf, "LOWER_PRICE", Convert.ToString(shortOrderParam.LowerPrice));
            AddConf(conf, "UPPER_PRICE", Convert.ToString(shortOrderParam.UpperPrice));
            AddConf(conf, "COEFFICIENT", Convert.ToString(shortOrderParam.Coefficient));
            AddConf(conf, "MIN_SIZE", Convert.ToString(shortOrderParam.MinSize));
            AddConf(conf, "AMOUNT", Convert.ToString(shortOrderParam.Amount));
            AddConf(conf, "ORDER_COUNT", Convert.ToString(shortOrderParam.OrderCount));
            conf.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
            Helper.Log("Saved key to config file...");
            return true;
        }

        public static bool SaveConditionalOrderParam(ConditionalOrderParam conditionalOrderParam)
        {
            Helper.Log("Saving conditional order param to config file...");
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AddConf(conf, "PROFIT_TARGET", Convert.ToString(conditionalOrderParam.ProfitTarget));
            AddConf(conf, "PROFIT_PERCENT", Convert.ToString(conditionalOrderParam.ProfitPercent));
            AddConf(conf, "DISTANCE", Convert.ToString(conditionalOrderParam.Distance));
            AddConf(conf, "FEE", Convert.ToString(conditionalOrderParam.Fee));
            AddConf(conf, "TARGET_OR_PERCENT", Convert.ToString(conditionalOrderParam.TargetOrPercent));
            conf.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
            Helper.Log("Saved conditional order param to config file...");
            return true;
        }
    }
}
