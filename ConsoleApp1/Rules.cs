using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Rules
    {
        private string rules;

        #region
        public string RULES
        {
            get { return rules; }
            set { rules = value; }
        }
        #endregion

        public Rules(string r) { RULES = r; }

        public static string[] words;
       

        public static bool GetArray(string[] str)
        {
            words = str;
            bool check = true;

            var grouped = words.GroupBy(i => i).Select(i => new { Count = i.Count() }).OrderByDescending(i => i.Count);

            foreach (var i in grouped)
            {
                if (i.Count > 1)
                {
                    check = false;
                }
            }

            if (words.Length % 2 != 1 || words.Length == 1 || words.Length == 0 || check == false) 
            { 
                Console.WriteLine("Enter correct parameters.");
                return false;
            }
            
            return true; 

        }

        public static void Play(int personInd, int computerInd)
        {
            if (computerInd == personInd) { WhoWin.PlayTable(personInd, computerInd, "Draw"); }
            else
            {
                int controlIndex = personInd + (words.Length / 2);
                int controlIndex2 = controlIndex - words.Length;

                if ((controlIndex >= computerInd && personInd < computerInd) ||
                    (controlIndex2 >= computerInd && personInd > computerInd))
                {
                    WhoWin.PlayTable(personInd, computerInd, "You Win");
                }
                else
                {
                    WhoWin.PlayTable(personInd, computerInd, "You Lose");
                }
            }
        }

        public static string[] Play(int personInd, bool help)
        {
            string str = Convert.ToString(personInd);
            for (int computerInd = 1; computerInd <= Rules.words.Length; computerInd++)
            {

                if (computerInd == personInd)
                {
                    str += " Draw";

                }
                else
                {
                    int controlIndex = personInd + (words.Length / 2);
                    int controlIndex2 = controlIndex - words.Length;

                    str += (controlIndex >= computerInd && personInd < computerInd) ||
                        (controlIndex2 >= computerInd && personInd > computerInd) ? " Win" : " Lose";
                }
            }

            string[] mystring = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return mystring;
        }

    }

}
