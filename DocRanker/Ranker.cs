using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRanker
{
    public class Ranker
    {
        private Dictionary<string, List<int>> wordIndex;
        private Dictionary<int, int> documentFrequencies;
        private int totalDocuments;

        public Ranker(Dictionary<string, List<int>> index)
        {
            wordIndex = index;
            documentFrequencies = CalculateDocumentFrequencies(index);
            totalDocuments = documentFrequencies.Count;
        }

        public List<int> RankQuery(string query)
        {
            string[] queryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> queryTermFrequencies = CalculateTermFrequencies(queryWords);

            Dictionary<int, double> documentScores = new Dictionary<int, double>();

            foreach (string word in queryTermFrequencies.Keys)
            {
                if (wordIndex.ContainsKey(word))
                {
                    List<int> documents = wordIndex[word];

                    foreach (int document in documents)
                    {
                        int termFrequency = queryTermFrequencies[word];
                        int documentFrequency = documentFrequencies[document];
                        double tfIdfScore = (termFrequency / (double)queryWords.Length) * Math.Log(totalDocuments / (double)documentFrequency);

                        if (documentScores.ContainsKey(document))
                            documentScores[document] += tfIdfScore;
                        else
                            documentScores[document] = tfIdfScore;
                    }
                }
            }

            List<int> rankedDocuments = documentScores.OrderByDescending(d => d.Value).Select(d => d.Key).ToList();

            return rankedDocuments;
        }

        private Dictionary<string, int> CalculateTermFrequencies(string[] words)
        {
            Dictionary<string, int> termFrequencies = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (termFrequencies.ContainsKey(word))
                    termFrequencies[word]++;
                else
                    termFrequencies[word] = 1;
            }

            return termFrequencies;
        }

        private Dictionary<int, int> CalculateDocumentFrequencies(Dictionary<string, List<int>> wordIndex)
        {
            Dictionary<int, int> documentFrequencies = new Dictionary<int, int>();

            foreach (List<int> documentIds in wordIndex.Values)
            {
                foreach (int documentId in documentIds)
                {
                    if (documentFrequencies.ContainsKey(documentId))
                        documentFrequencies[documentId]++;
                    else
                        documentFrequencies[documentId] = 1;
                }
            }

            return documentFrequencies;
        }
    }
}
