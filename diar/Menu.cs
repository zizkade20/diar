using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace diar
{
    internal class Menu
    {

        internal static void Loop()
        {
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)\n\n   DATUM A ČAS      NÁZEV AKCE");
            Datas.CreateJson();
            Datas.DeserializeJson();
            bool bulin = true;
            while (bulin)
            {

                Console.WriteLine("\n(P) přidat událost\n(Z) Zobrazit události\n(U) upravit událost\n(S) smazat událost\n(E) exit");
                string add = Console.ReadLine().ToLower();
                switch (add)
                {
                    case "p":
                        DateTime dejt;
                        string eventicek;
                        while (true)
                        {
                            Console.WriteLine("Zadej událost:");
                            string eventInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(eventInput))
                            {
                                eventicek = eventInput;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný");
                            }

                        }

                        while (true)
                        {
                            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr hh/mm)");
                            string dateInput = Console.ReadLine();

                            if (DateTime.TryParse(dateInput, out DateTime date))
                            {
                                dejt = date;
                                break;
                            }
                        }
                        Datas.AppendJson(eventicek, dejt);
                        Datas.DeserializeJson();

                        break;
                    case "z":
                        Datas.DeserializeJson();

                        break;
                    case "u":

                        break;
                    case "s":

                        break;
                    case "e":
                        bulin = false;
                        break;

                    default:
                        Console.WriteLine("vyber z nabídky");
                        break;
                }

            }
        }

    }
}
