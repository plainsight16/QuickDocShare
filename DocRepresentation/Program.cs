using DocHandler;
using System.Reflection.Metadata;

namespace DocRepresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> doc_texts = new DocumentHandler(@"..\..\..\..\Files").GetDocTexts();
            new DocRepresentation(doc_texts);
        }
    }
}