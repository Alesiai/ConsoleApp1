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


        public GetHmac(string h, string k) { HMACK = h; HMACKey = k; }

        public static ObservableCollection<GetHmac> ListOfGetHmac = new ObservableCollection<GetHmac>();
       
        
        public static byte[] key;
        public static byte[] hash;
        public static int moveIdx;



        public static int HMACHASH()
        {
            byte[] array = new byte[16];
            Span<byte> span = new Span<byte>(array);
            RandomNumberGenerator.Fill(array);
            key = array;

            var hmac = new HMACSHA256(key);

            moveIdx = RandomNumberGenerator.GetInt32(1, Rules.words.Length);

            string str = Rules.words[moveIdx];

            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(str.ToCharArray()));

            Console.WriteLine("\n\nHMAC: " + FormatBArrayToString(hash));

            return moveIdx;
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

        public static string FormatBArrayToString(byte[] array)
        {
            return BitConverter.ToString(array)
                    .Replace("-", string.Empty)
                    .ToLower();
        }
    }
}
