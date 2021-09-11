using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rules.GetArray(args);

            int compIndex, personIndex;
            string option;

            while (true)
            {
                compIndex = GetHmac.HMACHASH();

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
                        personIndex = Convert.ToInt32(option);
                        
                        Console.WriteLine("Computer move: " + GetHmac.moveIdx);

                        Rules.Play(personIndex, compIndex);
                    }
                }
                catch { };
            }
        }
    }
}
