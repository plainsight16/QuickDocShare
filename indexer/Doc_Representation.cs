namespace indexer
{
    public class Doc_Representation
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
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.normalized_tokens());
        }

       
    }

    private class Token
    {
        public int doc_id;
        public string token;

        public Token (int doc_id, string token)
        {
            this.doc_id = doc_id;
            this.token = token;
        }
    }

    private class TokenizeDocs
    {
        private List<string> doc_texts;
        private List<Token> tokens;
        public List<Token> normalized_tokens;

        public TokenizeDocs(List<string> doc_texts)
        {
            this.doc_texts = doc_texts;
            tokens = new List<Token>();
            normalized_tokens = new List<Token>();
            tokenize();
            normalize();
        }

        private void tokenize()
        {

            // inital implementation
            foreach (string doc_text in doc_texts)
            {
                string[] words = doc_text.Split(' ');
                foreach (string word in words)
                {
                    tokens.Add(new Token(doc_text.Index(), word));
                }
            }
        }

        private void normalize()
        {
            foreach (Token token in tokens)
            {
                normalized_tokens.Add(new Token(token.Value().ToLower()));
            }
        }

        public List<Token> tokens()
        {
            return tokens;
        }

        public List<Token> normalized_tokens()
        {
            return normalized_tokens;
        }
    } 



    private class InvertIndex
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