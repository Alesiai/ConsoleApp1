using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rules.GetArray(args);

            var random = new Random();
            int compIndex, personIndex;
            string option;

            while (true)
            {
                GetHmac.HMACHASH();

                Console.WriteLine("\nChoose your option:\n");
                for (int i = 0; i < Rules.words.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + Rules.words[i]);
                }
                Console.WriteLine("___________________________________________\n\n" +
                    "0. Exit\n" +
                    "?. Help\n" +
                    "h. History\n" +
                    "___________________________________________");
                option = Console.ReadLine();
                try
                {
                    if (option == "0") { break; }
                    else if (option == "?") { HelpTable.GetHelp(); }
                    else if (option == "h") { WhoWin.ShowPlayTable(); }
                    else if (Convert.ToInt32(option) <= Rules.words.Length)
                    {
                        compIndex = random.Next(1, Rules.words.Length);
                        personIndex = Convert.ToInt32(option);
                        Rules.Play(personIndex, compIndex);
                    }
                }
                catch { };
            }
        }
    }
}
