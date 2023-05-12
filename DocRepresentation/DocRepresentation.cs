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
            index = new InvertIndex(tokens.getNormalized_tokens());
        }
    }
}
