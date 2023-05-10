namespace doc_representation
{
    public class InvertIndex
    {
        private Dictionary<string, int> index;
        private Dictionary<string, int> sorted_index;
        private Dictionary<string, List<int>> merged_index;

        public InvertIndex(TokenizeDocs tokens)
        {
            index = indexer(tokens)
            sorted_index = sortIndex(index);
            merged_index = mergeIndex(sorted_index);
        }

        public indexer(TokenizeDocs tokens)
        {
            Dictionary<string, int> index = new Dictionary<string, int>();
            foreach (Token token in tokens)
            {
               index.Add(token.token, token.doc_id)
            }
            return index;
        }

        public sorted_index(Dictionary<string, int> index)
        {
            return index.OrderBy(key => key.Value());
        }

        private void mergeIndex()
        {
            foreach (string index in sorted_index)
            {
                if (merged_index.ContainsKey(index))
                {
                    merged_index[index].Add(index.Value());
                }
                else
                {
                    merged_index.Add(index, new List<int>().Add(index.Value()));
                }
            }
        }
    }
}