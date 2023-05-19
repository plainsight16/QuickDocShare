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
        Dictionary<string, List<int>> mergedIndex;
        Dictionary<int, string> documentPathAndID;
        public DocumentRepresentation(Dictionary<string, string> doc_texts)
        {
           
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.GetNormalized_tokens());
            mergedIndex = index.GetMergedIndex();
            documentPathAndID = tokens.GetDocumentPathAndID();

            //foreach (var kvp in index.GetMergedIndex())
            //{
            //    Console.WriteLine("Term: {0}, Postings lists: {1}", kvp.Key, String.Join(", ", kvp.Value));
            //}
        }

        public Dictionary<string, List<int>> GetMergedIndex()
        {
            return mergedIndex;
        }

        public Dictionary<int, string> GetDocumentPathAndId()
        {
            return documentPathAndID;
        }
    }
}
