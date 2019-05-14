using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataBase
{
    public class ReadSaveJson
    {
        public List<Item> Products;

        public ReadSaveJson()
        {
            Products = new List<Item>();
        }

        public void SaveToJason(string name)
        {
            string jsonData = JsonConvert.SerializeObject(Products, Formatting.None);
            File.WriteAllText($@"C:\Users\patro\Desktop\doc\{name}.json", jsonData);
        }

        public void LoadFromJason()
        {
            string data = File.ReadAllText(@"C:\Users\patro\Desktop\doc\tryToSaveToJason.json");
            Products = JsonConvert.DeserializeObject<List<Item>>(data);
        }
    }
}
