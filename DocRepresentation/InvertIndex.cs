using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    public class InvertIndex
    {
        private Dictionary<string, int> index;
        private Dictionary<string, int> sorted_index;
        private Dictionary<string, List<int>> merged_index;

        public InvertIndex(List<Token> tokens)
        {
            index = new Dictionary<string, int>();
            sorted_index = new Dictionary<string, int>();
            merged_index = new Dictionary<string, List<int>>();
            indexer(tokens);
            sortedIndex();
            mergeIndex();
        }

        private void indexer(List<Token> tokens)
        {
            Dictionary<string, int> index = new Dictionary<string, int>();
            foreach (Token token in tokens)
            {
                index.Add(token.token, token.doc_id);
            }
        }

        private void sortedIndex()
        {
            List<KeyValuePair<string, int>> temp = index.ToList();
            temp.Sort((left, right) => left.Value.CompareTo(right.Value));
            sorted_index = temp.ToDictionary(item => item.Key, item => item.Value);
        }

        private void mergeIndex()
        {
            foreach (KeyValuePair<string, int> index in sorted_index)
            {
                if (merged_index.ContainsKey(index.Key))
                {
                    merged_index[index.Key].Add(index.Value);
                }
                else
                {
                    List<int> pairingList = new List<int>();
                    pairingList.Add(index.Value);
                    merged_index.Add(index.Key, pairingList);
                }
            }
        }
    }
}
