namespace DocRepresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I'm just testing the normalizer, both should normalize to the same word - send
            //Tokenize.Normalize("Sending");
            //Tokenize.Normalize("SENDS");

            List<string> doc_texts = new List<string>();
            // DOC 1
            doc_texts.Add("I did enact Julius Caesar: I was killed i' the Capitol; Brutus killed me.");

            // DOC 2
            doc_texts.Add("So let it be with Caesar. The noble Brutus hath told you Ceasar was ambitious:");


            new DocRepresentation(doc_texts);
        }
    }
}