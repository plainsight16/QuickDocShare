using DocHandler;
using DocRepresentation;
using DocRanker;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentRepresentation docRep = LocalStorage.LoadObjectFromFile();
            Dictionary<int, string> documentPathAndID = docRep.documentPathAndID;
            Dictionary<string, List<int>> mergedIndex = docRep.mergedIndex;

            Ranker ranker = new Ranker(mergedIndex);
            string query = "Project Execution";
            List<int> rankedDocuments = ranker.RankQuery(query);

            foreach (var item in rankedDocuments)
            {
                string path = documentPathAndID[item];
                Console.WriteLine("Document Id: {0}, Path: {1}", item, path);
            }
        }
    }
}