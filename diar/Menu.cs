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

        internal static void Loop()
        {
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)\n\n    DATUM A ČAS         DEN        NÁZEV UDÁLOSTI");
            Datas.CreateJson();
            Datas.PrintJson("c");
            
            bool bulin = true;
            while (bulin)
            {

                Console.WriteLine("\n(P) přidat událost HOTOVO\n(Z) Zobrazit události\n(H) hledat událost HOTOVO\n(U) upravit událost\n(S) smazat událost HOTOVO\n(E) exit");
                string add = Console.ReadLine().ToLower();
                switch (add)
                {
                    case "p":
                        string eventicek;
                        while (true)
                        {
                            Console.WriteLine("Zadej název události:");
                            string eventInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(eventInput))
                            {
                                eventicek = eventInput;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný!");
                            }

                        }
                        DateTime dejt;

                        while (true)
                        {
                            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr hh:mm(:ss))");
                            string dateInput = Console.ReadLine();

                            if (DateTime.TryParse(dateInput, out DateTime date))
                            {
                                dejt = date;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Špatný formát vstupu!");
                            }
                        }
                        Datas.AppendJson(eventicek, dejt);
                        Datas.PrintJson("c");

                        break;
                    case "z":
                        Console.WriteLine("Chcete zobrazit:\n(A) Dnešní události\n(B) Zítřejší události\n(C) Všechny události");
                        string inpput = Console.ReadLine().ToLower();

                        switch (inpput)
                        {
                            case "a":
                                Datas.PrintJson(inpput);

                                break;
                            case "b":
                                Datas.PrintJson(inpput);

                                break;
                            case "c":
                                Datas.PrintJson(inpput);

                                break;
                            default:
                                Console.WriteLine("Vyber z nabídky!");
                                break;
                        }


                        break;
                    case "h":
                        Console.WriteLine("Zadejte jméno události, kterou chcete najít:");
                        string search = Console.ReadLine().ToLower();
                        Datas.SearchInJson(search);
                        break;
                    case "u":

                        break;
                    case "s":
                        Datas.PrintJson("c");


                        int bramboracek;
                        while (true)
                        {
                            Console.WriteLine("\nNapiš index záznamu, který chceš smazat:");
                            int vvv;
                            if (int.TryParse(Console.ReadLine(), out vvv))
                            {
                                bramboracek = vvv;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Pouze číslo pls!");
                            }

                         
                        }

                        Datas.DeleteFromJson(bramboracek);
                        Datas.PrintJson("c");
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
