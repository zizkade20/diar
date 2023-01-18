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
    internal class Data
    {
        public DateTime Datee { get; set; }
        public string Event { get; set; }

    }
    public class Datas
    {
        public static void CreateJson()
        {
            var path = @"../../../diar.json";

            string stri = "";

            File.AppendAllText(path, stri);

        }
        public static bool AppendJson(string eventt, DateTime datum)
        {

            var path = @"../../../diar.json";

            var data = File.ReadAllText(path);

            var nData = JsonConvert.DeserializeObject<List<Data>>(data) ?? new List<Data>();

            nData.Add(new Data {Event = eventt, Datee = datum });

            data = JsonConvert.SerializeObject(nData);


            File.WriteAllText(path, data);
            
            return true;
        }
        public static void PrintJson(/*string when*/)
        {
            var path = @"../../../diar.json";


            string json = File.ReadAllText(path);

            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);

            int index = 1;

            if (dataList != null)
            {
                var dtList = dataList.OrderBy(x => x.Datee).ToList();
                Console.WriteLine("");

                if (dataList != null)
                {
                    foreach (var data in dtList)
                    {
                        
                        Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek  + ")  " + data.Event);

                        index++;
                    }
                    index = 0;
                }
            }
        }
        public static void DeleteFromJson(int input)
        {

            var path = @"../../../diar.json";

            string json = File.ReadAllText(path);

            List<Data> records = JsonConvert.DeserializeObject<List<Data>>(json);
            var dtList = records.OrderBy(x => x.Datee).ToList();

            dtList.RemoveAt(input-1);
            File.WriteAllText(path, JsonConvert.SerializeObject(dtList));

            

        }
        public static void SearchInJson(string searchInput)
        {

            var path = @"../../../diar.json";

            string json = File.ReadAllText(path);

            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);

            if (dataList != null)
            {
                var dtList = dataList.OrderBy(x => x.Datee).ToList();
                
                Console.WriteLine("");
                int index = 1;
                if (dataList != null)
                {
                    foreach (var data in dtList)
                    {
                        if (data.Event == searchInput)
                        {
                            Console.WriteLine(index + ") " + data.Datee + "  (" + data.Datee.DayOfWeek + ")  " + data.Event);

                            index++;
                        } 
                       
                    }
                }
            }



        }

    }
}
