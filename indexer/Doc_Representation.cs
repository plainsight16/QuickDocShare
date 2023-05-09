namespace indexer
{
    class Doc_Representation
    {
        //tokenization
        //normalized_tokenization
        //invert_indexing(normalized_tokens)

        //sortAlphabetically
        //mergeMultipleOcuurences
        //postigLists


        //result is split into dict and posting list

        //posting list is a variable length array
        Token tokens;
        InvertIndex index;

        public Doc_Representation(List<string> doc_texts)
        {
            tokens = new Token(doc_texts);
            index = new InvertIndex(tokens.normalized_tokens());
        }

       
    }



    private class InvertIndex
    {
        private Dictionary<string, int> index;
        private Dictionary<string, int> sorted_index;
        private Dictionary<string, List<int>> merged_index;

        public InvertIndex(Token tokens)
        {
            index = new Dictionary<string, int>();
            sorted_index = sortIndex(index);
            merged_index = mergeIndex(sorted_index);
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