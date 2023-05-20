using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    public class DocumentRepresentation
    {
        Tokenize tokens;
        InvertIndex index;
        public Dictionary<string, List<int>> mergedIndex { get; set; }
        public Dictionary<int, string> documentPathAndID { get; set; }
        public DocumentRepresentation(Dictionary<string, string> doc_texts)
        {
           
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.GetNormalized_tokens());
            mergedIndex = index.GetMergedIndex();
            documentPathAndID = tokens.GetDocumentPathAndID();
            LocalStorage.SaveObjectToFile(this);

            //foreach (var kvp in index.GetMergedIndex())
            //{
            //    Console.WriteLine("Term: {0}, Postings lists: {1}", kvp.Key, String.Join(", ", kvp.Value));
            //}
        }

        // Parameterless constructor for deserialization
        [JsonConstructor]
        public DocumentRepresentation()
        {
            // Empty parameterless constructor
        }
    }
}
