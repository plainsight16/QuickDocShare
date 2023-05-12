namespace DocRepresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I'm just testing the normalizer, both should normalize to the same word - send
            Tokenize.Normalize("Sending");
            Tokenize.Normalize("SENDS");
        }
    }
}