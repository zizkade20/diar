
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace Diar
{
    class Data
    {
        public string Event { get; set; }
        public DateTime Datee { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("VÍTEJ V PLÁNOVAČI UDÁLOSTÍ AKA DIÁŘI :)");
            CreateJson();
            DeserializeJson();  
            bool bulin = true;
            while (bulin)
            {

                Console.WriteLine("\n(P) přidat událost\n(Z) Zobrazit události\n(U) upravit událost\n(S) smazat událost\n(E) exit");
                string add = Console.ReadLine().ToLower();
                switch (add)
                {
                    case "p":
                        Console.WriteLine("Zadej událost:");
                        string eventos = Console.ReadLine();
                        
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
                        }
                        AppendJson(eventos, dejt);
                        DeserializeJson();
                            
                        
                        
                        break;
                    case "z":
                        DeserializeJson();
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

        internal static void CreateJson()
        {
            var path = @"../../../diar.json";

            string stri = "";

            File.AppendAllText(path, stri);
        }

        internal static bool AppendJson(string eventt, DateTime datum)
        {

            var path = @"../../../diar.json";

            var data = File.ReadAllText(path);



            var nData = JsonConvert.DeserializeObject<List<Data>>(data) ?? new List<Data>();

            nData.Add(new Data { Event = eventt, Datee = datum });

            data = JsonConvert.SerializeObject(nData);

            // File.AppendAllText(path, data);

            File.WriteAllText(path, data);


            return true;
        }

        internal static void DeserializeJson()
        {
            var path = @"../../../diar.json";


            string json = File.ReadAllText(path);

            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);


            Console.WriteLine("");

            if (dataList != null)
            {
                foreach (var data in dataList)
                {

                    Console.WriteLine(data.Event + "  " + data.Datee);
                }
            }

        }



    }
}
