using DocHandler;
using DocRepresentation;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> doc_texts = new DocumentHandler(@"..\..\..\..\Files").GetDocTexts();
            new DocumentRepresentation(doc_texts);
        }
    }
}