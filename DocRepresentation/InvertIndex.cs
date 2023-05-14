using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    public class InvertIndex
    {
        private Dictionary<string, List<int>> merged_index;

        public InvertIndex(List<Token> tokens)
        {
            merged_index = new Dictionary<string, List<int>>();

            List<Token> sorted_index = sortedIndex(tokens);
            mergeIndex(sorted_index);
        }

        private List<Token> sortedIndex(List<Token> tokens)
        {
            List<Token> sortedTokens = tokens.OrderBy(token => token.token).ThenBy(token => token.doc_id).ToList();
            return sortedTokens;
        }

        private void mergeIndex(List<Token> tokens)
        {
            foreach (Token token in tokens)
            {
                if (merged_index.ContainsKey(token.token))
                {
                    if (!merged_index[token.token].Contains(token.doc_id))
                    {
                        merged_index[token.token].Add(token.doc_id);
                    }
                }
                else
                {
                    List<int> pairingList = new List<int>
                    {
                        token.doc_id
                    };
                    merged_index.Add(token.token, pairingList);
                }
            }
        }

        public Dictionary<string, List<int>> GetMergedIndex()
        {
            return merged_index;
        }
    }
}
