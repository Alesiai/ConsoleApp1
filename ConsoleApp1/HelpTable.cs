using System;

namespace ConsoleApp1
{
    class HelpTable
    {
        public static void GetHelp()
        {
            bool isHelp = true;

            for (int i = 0; i <= Rules.words.Length; i++)
            {

                for (int j = 0; j < Rules.words.Length; j++)
                {
                    if (i == 0)
                    {
                        Console.Write(string.Format("{0,10}", Rules.words[j] + "|"));
                    }
                }
                Console.WriteLine("\n______________________________________________________________");
                Console.Write(string.Format("{0,10}", "\n" + Rules.words[i] + "|"));

                for (int j = 0; j < Rules.words.Length; j++)
                {
                    int result = Rules.Play(i + 1, j + 1, isHelp);

                    if (result == 0)
                    {
                        Console.Write(string.Format("{0,10}", "Lose|"));
                    }
                    else if (result == 1)
                    {
                        Console.Write(string.Format("{0,10}", "Win|"));
                    }
                    else
                    {
                        Console.Write(string.Format("{0,10}", "Draw|"));
                    }
                }
            }
        }
    }
}
