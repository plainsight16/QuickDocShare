using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    public class LocalStorage
    {
        private static string path = @"..\..\..\..\Files\db.json";

        // Serialize object to JSON file
        public static void SaveObjectToFile(DocumentRepresentation myObject)
        {
            string json = JsonConvert.SerializeObject(myObject);
            File.WriteAllText(path, json);
        }

        // Deserialize object from JSON file
        public static DocumentRepresentation LoadObjectFromFile()
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<DocumentRepresentation>(json);
        }
    }
}
