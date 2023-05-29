using DocRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRanker
{
    /// <summary>
    /// Represents a ranker that ranks documents based on a given query.
    /// </summary>
    public class Ranker
    {
        private Dictionary<string, List<Token>> wordIndex;
        private Dictionary<Token, int> documentFrequencies;
        private int totalDocuments;

        /// <summary>
        /// Initializes a new instance of the Ranker class with the given word index.
        /// </summary>
        /// <param name="index">The word index.</param>
        public Ranker(Dictionary<string, List<Token>> index)
        {
            wordIndex = index;
            documentFrequencies = CalculateDocumentFrequencies(index);
            totalDocuments = documentFrequencies.Count;
        }

        /// <summary>
        /// Ranks the documents based on the given query.
        /// </summary>
        /// <param name="query">The query to rank the documents.</param>
        /// <returns>A list of ranked document IDs.</returns>
        public List<Token> RankQuery(string query)
        {
            string[] rawQueryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] queryWords = new string[] {};
            List<string> normalizedWords = new List<string>();

            foreach (string item in rawQueryWords)
            {
                string normalizedWord = Tokenize.Normalize(item);
                //Console.WriteLine(normalizedWord);
                normalizedWords.Add(normalizedWord);
            }

            queryWords = normalizedWords.ToArray();

            Dictionary<string, int> queryTermFrequencies = CalculateTermFrequencies(queryWords);

            Dictionary<Token, double> documentScores = new Dictionary<Token, double>();

            foreach (string word in queryTermFrequencies.Keys)
            {
                if (wordIndex.ContainsKey(word))
                {
                    List<Token> documents = wordIndex[word];

                    foreach (Token document in documents)
                    {
                        int termFrequency = queryTermFrequencies[word];
                        Token tk = documentFrequencies.Keys.FirstOrDefault(tk => tk.doc_id == document.doc_id);
                        int documentFrequency = documentFrequencies[tk];
                        double tfIdfScore = (termFrequency / (double)queryWords.Length) * Math.Log(totalDocuments / (double)documentFrequency);

                        if (documentScores.ContainsKey(tk))
                            documentScores[tk] += tfIdfScore;
                        else
                            documentScores[tk] = tfIdfScore;
                    }
                }
            }

            List<Token> rankedDocuments = documentScores.OrderByDescending(d => d.Value).Select(d => d.Key).ToList();

            //foreach (var item in documentScores)
            //{
            //    Console.WriteLine("Doc Id: {0}, Score: {1}", item.Key, item.Value);
            //}

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

        private Dictionary<Token, int> CalculateDocumentFrequencies(Dictionary<string, List<Token>> wordIndex)
        {
            Dictionary<Token, int> documentFrequencies = new Dictionary<Token, int>();

            foreach (List<Token> tokens in wordIndex.Values)
            {
                foreach (Token token in tokens)
                {
                    int documentId = token.doc_id;
                    if (documentFrequencies.Keys.Any(tk => tk.doc_id == documentId))
                    {
                        Token tk = documentFrequencies.Keys.FirstOrDefault(tk => tk.doc_id == documentId);
                        documentFrequencies[tk]++;
                    }
                    else
                    {
                        documentFrequencies[token] = 1;

                    }
                }
            }

            return documentFrequencies;
        }
    }
}
