using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    public class DocRepresentation
    {
        Tokenize tokens;
        InvertIndex index;

        public DocRepresentation(List<string> doc_texts)
        {
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.GetNormalized_tokens());

            foreach (var kvp in index.GetMergedIndex())
            {
                Console.WriteLine("Term: {0}, Postings lists: {1}", kvp.Key, String.Join(", ", kvp.Value));
            }
        }
    }
}
