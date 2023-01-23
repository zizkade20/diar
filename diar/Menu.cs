using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace diar
{
    internal class Menu
    {
        // loop aplikace
        internal static void Loop()
        {
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)\nDnes je: " + DateOnly.FromDateTime(DateTime.Now) + "\n\n   DATUM A ČAS     DEN       NÁZEV     POZNÁMKA");
            // Vytvoření JSON souboru
            Data.CreateJson();
            // Zobrazení záznamů
            Data.PrintJson("c");
            
            bool bulin = true;
            while (bulin)
            {
                Console.WriteLine("\n(P) přidat událost \n(Z) Zobrazit události \n(H) hledat událost \n(U) upravit událost \n(S) smazat událost \n(E) exit");
                string add = Console.ReadLine().ToLower();
                // menu
                switch (add)
                {
                    case "p":
                        Data.AppendJson();
                        Data.PrintJson("c");
                        break;
                    case "z":
                        Console.WriteLine("Chcete zobrazit:\n(A) Dnešní události\n(B) Zítřejší události\n(C) Všechny události");
                        string inpput = Console.ReadLine().ToLower();

                        switch (inpput)
                        {
                            case "a":
                                Data.PrintJson(inpput);
                                break;
                            case "b":
                                Data.PrintJson(inpput);
                                break;
                            case "c":
                                Data.PrintJson(inpput);

                                break;
                            default:
                                Console.WriteLine("Vyber z nabídky!");
                                break;
                        }
                        break;
                    case "h":
                        Console.WriteLine("Zadejte jméno události, kterou chcete najít:");
                        string search = Console.ReadLine().ToLower();
                        Data.SearchInJson(search);
                        break;
                    case "u":
                        Data.PrintJson("c");
                        Data.DeleteFromJson();
                        Data.AppendJson();
                        Data.PrintJson("c");
                        break;
                    case "s":
                        Data.PrintJson("c");
                        Data.DeleteFromJson();
                        Data.PrintJson("c");
                        break;
                    case "e":
                        bulin = false;
                        break;
                    default:
                        Console.WriteLine("vyber z nabídky!");
                        break;
                }
            }
        }
    }
}
