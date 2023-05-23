using DocHandler;
using Query;
using System.Reflection.Metadata;

namespace DocRepresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> doc_texts = new DocumentHandler(@"..\..\..\..\Files").GetDocTexts();
            DocumentRepresentation docRep = new DocumentRepresentation(doc_texts);
        }
    }
}