
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diar
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)");

            DisplayLeaderboard();
            Console.WriteLine("\nChcete přidat záznam? (Y/N)");
            string add = Console.ReadLine().ToLower();
            switch (add)
            {
                case "y":
                    Console.WriteLine("Zadej událost:");
                    string eventos = Console.ReadLine();
                    Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                    string datum = Console.ReadLine();

                    WriteToLeaderboard(eventos, datum);
                    DisplayLeaderboard();

                    break;
                case "n":
                    DisplayLeaderboard();
                    break;

                default:
                    Console.WriteLine("vyber z nabídky");
                    break;
            }
            
            

            Console.WriteLine("\npro opuštění aplikace stiskni jakoukoliv klávesu");
            Console.ReadLine();

        }
        internal static bool WriteToLeaderboard(string eventt, string datee)
        {
            string FileName = "../../../leaderboard.csv";
            string personDetail = eventt + " " + datee + Environment.NewLine;

            if (!File.Exists(FileName))
            {
                string clientHeader = Environment.NewLine;

                File.WriteAllText(FileName, clientHeader);
            }

            File.AppendAllText(FileName, personDetail);

            return true;
        }

        // Funkce na zobrazení dat z csv souboru
        internal static void DisplayLeaderboard()
        {
            string[] leaderboard = System.IO.File.ReadAllLines(@"../../../leaderboard.csv");
            foreach (string line in leaderboard)
            {
                Console.WriteLine(line);
            }
        }



    }
}