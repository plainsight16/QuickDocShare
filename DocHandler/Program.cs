using System.IO;
namespace DocHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
          List<string> doc_texts = new Documents(@".\Files").doc_texts;
        }
    }
}