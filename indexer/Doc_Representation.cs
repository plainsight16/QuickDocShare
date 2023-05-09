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

        private List<string> tokens;
        private List<string> normalized_tokens;
        private Dictionary<string, List<int>> inverted_index;

        public Doc_Representation(string doc_text)
        {
            tokens = new List<string>();
            normalized_tokens = new List<string>();
            inverted_index = new Dictionary<string, List<int>>();
            tokenize(doc_text);
            normalize_tokens();
            invert_index();
        }

        private void tokenize(string doc_text)
        {
            string[] 
        }
    }
}