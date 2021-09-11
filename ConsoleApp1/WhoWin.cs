using System;
using System.Collections.ObjectModel;


namespace ConsoleApp1
{

    class WhoWin
    {
        private string person;
        private string computer;
        private string result;
        private string HMACkey;

        #region
        public string PERSON
        {
            get { return person; }
            set { person = value; }
        }

        public string COMPUTER
        {
            get { return computer; }
            set { computer = value; }
        }

        public string RESULT
        {
            get { return result; }
            set { result = value; }
        }

        public string HMACKEY
        {
            get { return HMACkey; }
            set { HMACkey = value; }
        }

        public string P { get; }
        public string C { get; }
        public string R { get; }
        public string H { get; }
        #endregion

        public WhoWin(string p, string c, string r, string h) { PERSON = p; COMPUTER = c; RESULT = r; HMACKEY = h; }

        public static ObservableCollection<WhoWin> ListOfWins = new ObservableCollection<WhoWin>();

        public static void PlayTable(int personInd, int computerInd, string result)
        {
            string person = "", computer = "";

            for (int i = 0; i < Rules.words.Length; i++)
            {
                if (i + 1 == personInd) { person = Rules.words[i]; }
                if (i + 1 == computerInd) { computer = Rules.words[i]; }
            }

            Console.WriteLine("Your move: " + person + "\nComputer move: " + computer + "\n" + result + "\nHMAC key: "
                + GetHmac.FormatBArrayToString(GetHmac.key));

            var whoWin = new WhoWin(person, computer, result, GetHmac.FormatBArrayToString(GetHmac.key));
            ListOfWins.Add(whoWin);
        }

        public static void ShowPlayTable()
        {
            foreach (WhoWin whoWin1 in ListOfWins)
            {
                Console.WriteLine("Your move: " + whoWin1.PERSON + ". " + "Computer move: " + whoWin1.COMPUTER + ". " + "Result: "
                    + whoWin1.RESULT + ". " + "HMAC key: " + whoWin1.HMACKEY + ".");
            }
        }
    }
}
