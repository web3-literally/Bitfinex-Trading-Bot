using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CDSBot
{
    class Helper
    {
        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Global.APP_KEY));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Global.APP_KEY));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        public static void Log(string msg)
        {
            DateTime now = DateTime.UtcNow;
            string line = string.Format("{0} ==> {1}", now.ToString("yyyy-MM-dd HH:mm:ss fff"), msg);

            FileStream ostrm;
            StreamWriter fout;
            TextWriter cout = Console.Out;

            if (Global.IS_DEBUG)
            {
                Console.WriteLine(line);
            }

            if (Global.LOG_TO_FILE)
            {
                try
                {
                    string appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string logFilePath = string.Format("{0}/log_{1}.txt", appDir, now.ToString("yyyyMMdd"));
                    ostrm = new FileStream(logFilePath, FileMode.Append, FileAccess.Write);
                    fout = new StreamWriter(ostrm);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot open log file for appending");
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.SetOut(fout);
                Console.WriteLine(line);
                Console.SetOut(cout);
                fout.Close();
                ostrm.Close();
            }
        }

        public static string Timestamp2DateString(double timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(timeStamp).ToLocalTime();
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss fff");
        }

        public static bool IsPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }
    }
}
