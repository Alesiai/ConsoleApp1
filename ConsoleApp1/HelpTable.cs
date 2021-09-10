using System;
using ConsoleTables;

namespace ConsoleApp1
{
    class HelpTable
    {
        public static void GetHelp()
        {
            var table = new ConsoleTable("User/PC");
            
            table.AddColumn(Rules.words);

            for (int i = 1; i <= Rules.words.Length; i++)
            {
                table.AddRow(Rules.Play(i, true));
            }
            table.Write(Format.Alternative);
        }
    }
}
