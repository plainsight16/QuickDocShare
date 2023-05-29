using DocHandler;
using DocRepresentation;
using DocRanker;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentRepresentation docRep = new DocRepLocalStorage( @"..\..\..\..\Files\Databases\db.json").LoadObjectFromFile();
            Dictionary<string, List<Token>> mergedIndex = docRep.mergedIndex;

            Ranker ranker = new Ranker(mergedIndex);
            string query = "Project Execution";
            List<Token> rankedDocuments = ranker.RankQuery(query);

            foreach (var item in rankedDocuments)
            {
                Console.WriteLine("Document Id: {0}, Path: {1}", item.doc_id, item.filePath);
            }
        }
    }
}