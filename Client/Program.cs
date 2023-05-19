using DocHandler;
using DocRepresentation;
using DocRanker;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> doc_texts = new DocumentHandler(@"..\..\..\..\Files").GetDocTexts();
            DocumentRepresentation docRep = new DocumentRepresentation(doc_texts);
            Dictionary<int, string> documentPathAndID = docRep.GetDocumentPathAndId();
            Dictionary<string, List<int>> mergedIndex = docRep.GetMergedIndex();

            Ranker ranker = new Ranker(mergedIndex);
            string query = "project";
            List<int> rankedDocuments = ranker.RankQuery(query);

            foreach (var item in rankedDocuments)
            {
                string path = documentPathAndID[item];
                Console.WriteLine("Document Id: {0}, Path: {1}", item, path);
            }
        }
    }
}