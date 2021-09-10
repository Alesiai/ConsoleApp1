using System;
using System.Linq;

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

        public static void GetArray()
        {
            string str = Console.ReadLine();
            words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check = true;

            var grouped = words.GroupBy(i => i).Select(i => new { Count = i.Count() }).OrderByDescending(i => i.Count);

            foreach (var i in grouped)
            {
                if (i.Count > 1)
                {
                    check = false;
                }
            }

            if (words.Length % 2 != 1) { Console.WriteLine("Enter an uneven number of parameters."); Rules.GetArray(); }
            else if (words.Length == 1) { Console.WriteLine("Enter more than one parameter."); Rules.GetArray(); }
            else if (words.Length == 0) { Console.WriteLine("You didn't entered the parameters."); Rules.GetArray(); }
            else if (check == false) { Console.WriteLine("Parameters names should not repeate."); Rules.GetArray(); }
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

        public static int Play(int personInd, int computerInd, bool help)
        {
            if (computerInd == personInd)
            {
                return 2;
            }
            else
            {
                int controlIndex = personInd + (words.Length / 2);
                int controlIndex2 = controlIndex - words.Length;

                return (controlIndex >= computerInd && personInd < computerInd) ||
                    (controlIndex2 >= computerInd && personInd > computerInd) ? 1 : 0;
            }
        }

    }

}
