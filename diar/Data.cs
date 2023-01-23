using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace diar
{
    // klása obsahující datum, název záznamu a poznámku
    public class Data
    {
        public DateOnly Datee { get; set; }
        public string Event { get; set; }
        public string Note { get; set; }

    /*}
    public class Datas
    {*/
        // metoda na vytvoření json souboru
        public void CreateJson()
        {
            var path = @"../../../diar.json";

            string stri = "";

            File.AppendAllText(path, stri);
        }
        // metoda na přidání souboru
        public bool AppendJson()
        {
            DateOnly dejt;
            // while dokud nezadá správný input
            while (true)
            {
                Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                string dateInput = Console.ReadLine();
                // kontrola datumu
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
            // while dokud nezadá správný input
            string eventicek;
            while (true)
            {
                Console.WriteLine("Zadej název události:");
                string eventInput = Console.ReadLine().ToLower();
                // kontrola, aby nebyl string prázdný
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
            
            Console.WriteLine("Zadej poznámku (popis, čas, atd...):");
            string poznamka = Console.ReadLine().ToLower();
                
            var path = @"../../../diar.json";
            // získání dat z jsonu
            var data = File.ReadAllText(path);
            // deserializace dat z jsonu do listu, pokud je prázdný, vytvoří se nový listlist
            var nData = JsonConvert.DeserializeObject<List<Data>>(data) ?? new List<Data>();
            // Přiřazení inputů do listu
            nData.Add(new Data {Event = eventicek, Datee = dejt, Note = poznamka });
            // serializace dat
            data = JsonConvert.SerializeObject(nData);

            // zapsání do jsonu
            File.WriteAllText(path, data);
            
            return true;
        }
        // metoda na vypsání záznamů
        public void PrintJson(string when)
        {
            var path = @"../../../diar.json";

            // získání dat z jsonu
            string json = File.ReadAllText(path);
            // deserializace dat z jsonu do listu
            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);

            int index = 1;
            // pokud není json prázdný
            if (dataList != null)
            {
                // seřazení podle datumu
                var dtList = dataList.OrderBy(x => x.Datee).ToList();
                Console.WriteLine("");


                foreach (var data in dtList)
                {
                    // pokud má volání metody parametr a
                    if (when == "a")
                    {
                        // pokud se datum události rovná dnešnímu
                        if (data.Datee == DateOnly.FromDateTime(DateTime.Now))
                        {
                            Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek + ")   " + data.Event + "    " + data.Note);
                        }
                    }
                    // pokud má volání metody parametr b
                    if (when == "b")
                    {
                        // pokud se datum události rovná zítřejšímu
                        if (data.Datee == DateOnly.FromDateTime(DateTime.Now).AddDays(1))
                        {
                            Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek + ")   " + data.Event + "    " + data.Note);
                        }
                    }
                    // pokud má volání metody parametr c
                    if (when == "c")
                    {
                        Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek + ")   " + data.Event + "    " + data.Note);
                    }
                    index++;
                }
                index = 0;
            }
        }
        // metoda na smazání záznamu
        public void DeleteFromJson()
        {
            int input;
            // while dokud nezadá správný input

            while (true)
            {
                Console.WriteLine("\nNapiš index záznamu");
                int result;
                // pokud je input číslo
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    input = result;
                    break;
                }
                else
                {
                    Console.WriteLine("Pouze číslo pls!");
                }
            }

            var path = @"../../../diar.json";

            //získání dat z jsonu
            string json = File.ReadAllText(path);
            //deserializace dat z jsonu do listu
            List<Data> records = JsonConvert.DeserializeObject<List<Data>>(json);
            var dtList = records.OrderBy(x => x.Datee).ToList();

            // pokud je input větší  než počet záznamů
            if (input <= dtList.Count) 
            {
                dtList.RemoveAt(input - 1);
            } else
            {
                Console.WriteLine("Vyber z nabídky!");
            }
            // serializace listu do jsonu
            string data = JsonConvert.SerializeObject(dtList);
            // zapsání do jsonu
            File.WriteAllText(path, data);

        }
        // metoda na hledání v záznamech
        public void SearchInJson(string searchInput)
        {

            var path = @"../../../diar.json";
            // získání dat z jsonu
            string json = File.ReadAllText(path);
            // deserializace dat z jsonu do listu
            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);
            // pokud není prázdný
            if (dataList != null)
            {
                // seřazení listu podle datumu
                var dtList = dataList.OrderBy(x => x.Datee).ToList();
                
                Console.WriteLine("");
                int index = 1;
                
                foreach (var data in dtList)
                {
                    // pokud název události obsahuje input
                    if (data.Event.Contains(searchInput))
                    {
                        Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek + ")  " + data.Event);

                        index++;
                    } 
                }
            }
        }
    }
}
