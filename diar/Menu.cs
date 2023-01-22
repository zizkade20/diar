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
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)\n\n   DATUM A ČAS   DEN       NÁZEV     POZNÁMKA");
            Datas.CreateJson();
            Datas.PrintJson("c");
            
            bool bulin = true;
            while (bulin)
            {

                Console.WriteLine("\n(P) přidat událost \n(Z) Zobrazit události \n(H) hledat událost \n(U) upravit událost \n(S) smazat událost \n(E) exit");
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
                        DateOnly dejt;

                        while (true)
                        {
                            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                            string dateInput = Console.ReadLine();

                            if (DateOnly.TryParse(dateInput, out DateOnly date))
                            {
                                dejt = date;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Špatný formát vstupu!");
                            }
                        }
                        string poznamka;
                        while (true)
                        {
                            Console.WriteLine("Zadej poznámku (popis, čas, atd...):");
                            string noteInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(noteInput))
                            {
                                poznamka = noteInput;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný!");
                            }

                        }
                        Datas.AppendJson(eventicek, dejt, poznamka);
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
                        Datas.PrintJson("c");


                        int index;
                        while (true)
                        {
                            Console.WriteLine("\nNapiš index záznamu, který chceš upravit:");
                            int result;
                            if (int.TryParse(Console.ReadLine(), out result))
                            {
                                index = result;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Pouze číslo pls!");
                            }


                        }

                        Datas.DeleteFromJson(index);

                        string eventtt;
                        while (true)
                        {
                            Console.WriteLine("Zadej název události:");
                            string uEventInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(uEventInput))
                            {
                                eventtt = uEventInput;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný!");
                            }

                        }
                        DateOnly datum;

                        while (true)
                        {
                            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                            string uDateInput = Console.ReadLine();

                            if (DateOnly.TryParse(uDateInput, out DateOnly uDate))
                            {
                                datum = uDate;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Špatný formát vstupu!");
                            }
                        }
                        string uPoznamka;
                        while (true)
                        {
                            Console.WriteLine("Zadej poznámku (popis, čas, atd...):");
                            string uNoteInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(uNoteInput))
                            {
                                uPoznamka = uNoteInput;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný!");
                            }

                        }
                        Datas.AppendJson(eventtt, datum, uPoznamka);
                        Datas.PrintJson("c");

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
