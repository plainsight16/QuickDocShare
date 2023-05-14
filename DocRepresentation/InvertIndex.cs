using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation
{
    /// <summary>
    /// Represents a class that constructs an inverted index from a list of tokens.
    /// </summary>
    public class InvertIndex
    {

        // Stores the inverted index as a dictionary where the key is a term and the value is a list of document IDs that contain that term.
        private Dictionary<string, List<int>> merged_index;



        /// <summary>
        /// Initializes a new instance of the <see cref="InvertIndex"/> class with the provided tokens.
        /// </summary>
        /// <param name="tokens">The list of tokens used to construct the inverted index.</param>
        public InvertIndex(List<Token> tokens)
        {
            // Constructor for InvertIndex class.
            // Initializes the merged_index dictionary and constructs the inverted index.

            // Initialize the merged_index dictionary.
            merged_index = new Dictionary<string, List<int>>();

            // Sort the tokens to ensure a consistent order for merging.
            List<Token> sorted_index = sortedIndex(tokens);
            mergeIndex(sorted_index);
        }

        /// <summary>
        /// Sorts the tokens by token and document ID.
        /// </summary>
        /// <param name="tokens">The list of tokens to be sorted.</param>
        /// <returns>The sorted list of tokens.</returns>
        private List<Token> sortedIndex(List<Token> tokens)
        {
            // Sorts the tokens by token and document ID.
            // Returns the sorted list of tokens.
            List<Token> sortedTokens = tokens.OrderBy(token => token.token).ThenBy(token => token.doc_id).ToList();
            return sortedTokens;
        }

        /// <summary>
        /// Merges the sorted tokens to construct the inverted index.
        /// </summary>
        /// <param name="tokens">The sorted list of tokens.</param>
        private void mergeIndex(List<Token> tokens)
        {
            // Merges the sorted tokens to construct the inverted index.
            foreach (Token token in tokens)
            {
                if (merged_index.ContainsKey(token.token))
                {
                    // If the token already exists in the merged_index,
                    // add the document ID to the list if it's not already present.
                    if (!merged_index[token.token].Contains(token.doc_id))
                    {
                        merged_index[token.token].Add(token.doc_id);
                    }
                }
                else
                {
                    // If the token does not exist in the merged_index,
                    // create a new list with the document ID and add it to the dictionary.
                    List<int> pairingList = new List<int>
                    {
                        token.doc_id
                    };
                    merged_index.Add(token.token, pairingList);
                }
            }
        }

        /// <summary>
        /// Gets the constructed merged_index, which represents the inverted index.
        /// </summary>
        /// <returns>The inverted index as a dictionary.</returns>
        public Dictionary<string, List<int>> GetMergedIndex()
        {
            // Returns the constructed merged_index, which represents the inverted index.
            return merged_index;
        }
    }
}
