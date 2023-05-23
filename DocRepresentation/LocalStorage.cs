﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    /// <summary>
    /// Provides functionality for serializing and deserializing objects to/from a JSON file.
    /// </summary>
    public class LocalStorage
    {
        private static string path = @"..\..\..\..\Files\db.json";

        /// <summary>
        /// Serializes an object to a JSON file.
        /// </summary>
        /// <param name="myObject">The object to be serialized.</param>
        public static void SaveObjectToFile(DocumentRepresentation myObject)
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
        public static DocumentRepresentation LoadObjectFromFile()
        {
            // Read the JSON from the file
            string json = File.ReadAllText(path);

            // Deserialize the JSON to an object
            return JsonConvert.DeserializeObject<DocumentRepresentation>(json);
        }
    }
}