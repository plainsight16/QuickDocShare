namespace DocHandler
{
    public class TextDocumentHandler : DocumentHandler
    {
        public TextDocumentHandler(DocumentHandler next) : base(next)
        {}

        public override string parseDocument(string fileExtension, string filePath)
        {
            if(fileExtension.Equals(".txt"))
            {
                return parseDocument(filePath);
            }
            return base.parseDocument(fileExtension, filePath);
        }
        public string parseDocument(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return text;
        }
    }
}