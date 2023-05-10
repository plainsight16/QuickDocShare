namespace doc_representation
{
    public class Doc_Representation
    {
        //tokenization
        //normalized_tokenization

        Token tokens;
        InvertIndex index;

        public Doc_Representation(List<string> doc_texts)
        {
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.normalized_tokens());
        }

       
    }
}