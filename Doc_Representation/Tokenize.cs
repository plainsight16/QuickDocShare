namespace doc_representation
{
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

    public class TokenizeDocs
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
}