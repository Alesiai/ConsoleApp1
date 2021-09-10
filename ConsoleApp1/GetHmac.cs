using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{

    class GetHmac
    {
        private string hMACKey;
        private string hMAC;

        #region
        public string HMACKey
        {
            get { return hMACKey; }
            set { hMACKey = value; }
        }

        public string HMACK
        {
            get { return hMAC; }
            set { hMAC = value; }
        }
        #endregion

        public static string key;

        public GetHmac(string h, string k) { HMACK = h; HMACKey = k; }

        public static ObservableCollection<GetHmac> ListOfGetHmac = new ObservableCollection<GetHmac>();

        public static void HMACHASH()
        {
            var rnd = new Random();

            byte[] bKey = Encoding.Default.GetBytes(Convert.ToString(rnd.Next(0, 10)));
            using (var hMac = new HMACSHA256(bKey))
            {
                byte[] bString = Encoding.Default.GetBytes(Convert.ToString(rnd.Next(0, 10)));
                var bHash = hMac.ComputeHash(bString);

                var bKeyToHash = hMac.ComputeHash(bKey);
                var getHmac = new GetHmac(FormatBArrayToString(bHash), FormatBArrayToString(bKeyToHash));
                ListOfGetHmac.Add(getHmac);
                key = FormatBArrayToString(bKeyToHash);
                Console.WriteLine("\n\nHMAC: " + FormatBArrayToString(bHash));

            }
        }

        public static string HMACKEY(string hash)
        {
            foreach (GetHmac getHmac in ListOfGetHmac)
            {
                if (getHmac.HMACK == hash)
                {
                    return getHmac.HMACKey;
                }
            }
            return "Not found HMACK HASH.";
        }

        private static string FormatBArrayToString(byte[] array)
        {
            return BitConverter.ToString(array)
                    .Replace("-", string.Empty)
                    .ToLower();
        }
    }
}
