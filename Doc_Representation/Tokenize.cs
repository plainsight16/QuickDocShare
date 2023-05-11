namespace doc_representation
{
    public class Token
    {
        public int doc_id;
        public string token;

        public Token (int doc_id, string token)
        {
            this.doc_id = doc_id;
            this.token = token;
        }
    }

    public class Tokenize
    {
        private List<string> doc_texts;
        private List<Token> tokens;
        public List<Token> normalized_tokens;

        public Tokenize(List<string> doc_texts)
        {
            this.doc_texts = doc_texts;
            tokens = new List<Token>();
            normalized_tokens = new List<Token>();
            tokenizer();
            normalizer();
        }

        private void tokenizer()
        {

            // TODO: write a new tokenizer
            foreach (string doc_text in doc_texts)
            {

                string[] words = doc_text.Split(' ');
                foreach (string word in words)
                {
                    int doc_id = doc_texts.IndexOf(doc_text);
                    tokens.Add(new Token(doc_id, word));
                }
            }
        }

        private void normalizer()
        {
            foreach (Token token in tokens)
            {
                normalized_tokens.Add(new Token(token.doc_id, token.token.ToLower()));
            }
        }

        public List<Token> getTokens()
        {
            return tokens;
        }

        public List<Token> getNormalized_tokens()
        {
            return normalized_tokens;
        }
    } 
}