using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    /// <summary>
    /// Represents the document representation that includes the merged inverted index and document path and ID mapping.
    /// </summary>
    public class DocumentRepresentation
    {
        Tokenize tokens;
        InvertIndex index;

        /// <summary>
        /// Gets or sets the merged inverted index of the documents.
        /// </summary>
        public Dictionary<string, List<int>> mergedIndex { get; set; }

        /// <summary>
        /// Gets or sets the mapping between document IDs and their corresponding file paths.
        /// </summary>
        public Dictionary<int, string> documentPathAndID { get; set; }

        /// <summary>
        /// Initializes a new instance of the DocumentRepresentation class with the provided document texts.
        /// </summary>
        /// <param name="doc_texts">A dictionary containing document texts with their corresponding file paths.</param>
        public DocumentRepresentation(Dictionary<string, string> doc_texts)
        {

            // Create a Tokenize object and pass the document texts to tokenize them
            tokens = new Tokenize(doc_texts);

            // Create an InvertIndex object and pass the normalized tokens to build the inverted index
            index = new InvertIndex(tokens.GetNormalized_tokens());
            // Get the merged index from the InvertIndex object
            mergedIndex = index.GetMergedIndex();

            // Get the document paths and IDs from the Tokenize object
            documentPathAndID = tokens.GetDocumentPathAndID();

            // Save the DocumentRepresentation object to a file using JSON serialization
            LocalStorage.SaveObjectToFile(this);

            //foreach (var kvp in index.GetMergedIndex())
            //{
            //    Console.WriteLine("Term: {0}, Postings lists: {1}", kvp.Key, String.Join(", ", kvp.Value));
            //}
        }

        /// <summary>
        /// Initializes a new instance of the DocumentRepresentation class. (Used for deserialization)
        /// </summary>
        [JsonConstructor]
        public DocumentRepresentation()
        {
            // Empty parameterless constructor
        }
    }
}
