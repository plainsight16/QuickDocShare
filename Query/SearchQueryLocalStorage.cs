using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query
{
    public class SearchQueryLocalStorage
    {
        private string path;

        public SearchQueryLocalStorage(string path)
        {
            this.path = path;
        }
        
        /// <summary>
        /// Serializes an object to a JSON file.
        /// </summary>
        /// <param name="myObject">The object to be serialized.</param>
        public void SaveObjectToFile(SearchQuery myObject)
        {
            // Serialize the object to JSON
            string json = JsonConvert.SerializeObject(myObject);

            // Write the JSON to the file
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Deserializes an object from a JSON file.
        /// </summary>
        /// <returns>The deserialized object.</returns>
        public SearchQuery LoadObjectFromFile()
        {
            // Read the JSON from the file
            string json = File.ReadAllText(path);

            // Deserialize the JSON to an object
            return JsonConvert.DeserializeObject<SearchQuery>(json);
        }

        public void AddQuery(string query)
        {
            SearchQuery searchQuery = LoadObjectFromFile();
            if(searchQuery!=null && searchQuery.previousSearchQueries != null)
            {
                searchQuery.previousSearchQueries.Add(query);
            }
            else
            {
                searchQuery = new SearchQuery();
                searchQuery.previousSearchQueries = new List<string> { query };
            }
            SaveObjectToFile(searchQuery);
        }
    }
}
