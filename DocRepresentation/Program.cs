using DocHandler;
using System.Reflection.Metadata;

namespace DocRepresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I'm just testing the normalizer, both should normalize to the same word - send
            //Tokenize.Normalize("Sending");
            //Tokenize.Normalize("SENDS");

            DocumentHandler doc_handler = new SlideShowHandler(null);
            string doc_1_texts = doc_handler.parseDocument("pptx", @"C:\Users\Julius Alibrown\Desktop\class\Project\search-engine\DocHandler\powerpoint_file.pptx");

            DocumentHandler doc_handler2 = new SlideShowHandler(null);
            string doc_2_texts = doc_handler2.parseDocument("pptx", @"C:\Users\Julius Alibrown\Desktop\class\Project\search-engine\DocHandler\powerpoint_file_2.pptx");

            List<string> doc_texts = new List<string>
            {
                // DOC 1
                doc_1_texts,

                // DOC 2
                doc_2_texts
            };


            new DocRepresentation(doc_texts);
        }
    }
}