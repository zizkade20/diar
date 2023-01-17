﻿using System;
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
            Datas.PrintJson();
            bool bulin = true;
            while (bulin)
            {

                Console.WriteLine("\n(P) přidat událost\n(Z) Zobrazit události\n(U) upravit událost\n(S) smazat událost\n(E) exit");
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
                            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr hh/mm)");
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
                        Datas.PrintJson();

                        break;
                    case "z":
                        Console.WriteLine("Chcete zobrazit:\n(A) Dnešní události\n(B) Zítřejší události\n(C) Všechny události");
                        string inpput = Console.ReadLine().ToLower();

                        switch (inpput)
                        {
                            case "a":

                                break;
                            case "b":
                                break;
                            case "c":
                                break;
                        }

                        Datas.PrintJson();

                        break;
                    case "u":

                        break;
                    case "s":
                        Datas.PrintJson();

                        string volb;
                        while (true)
                        {
                            Console.WriteLine("\nNapiš jméno záznamu, který chceš smazat:");
                            string volba = Console.ReadLine();

                            if (!string.IsNullOrEmpty(volba))
                            {
                                volb = volba;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Input nesmí být prázdný!\n");
                            }

                        }

                        Datas.DeleteFromJson(volb);
                        Datas.PrintJson();
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
