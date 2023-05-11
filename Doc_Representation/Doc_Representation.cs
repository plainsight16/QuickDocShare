namespace doc_representation
{
    public class Doc_Representation
    {
        //tokenization
        //normalized_tokenization

        Tokenize tokens;
        InvertIndex index;

        public Doc_Representation(List<string> doc_texts)
        {
            tokens = new Tokenize(doc_texts);
            index = new InvertIndex(tokens.getNormalized_tokens());
        }
       
    }
}