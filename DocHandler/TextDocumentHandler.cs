namespace DocHandler
{
    public class TextDocumentHandler : DocumentHandler
    {
        public TextDocumentHandler(DocumentHandler next) : base(next)
        {}

        public override string parseDocument(string fileExtension, string fileName)
        {
            if(fileExtension == ".txt")
            {
                return parseDocument(fileName);
            }
            return base.parseDocument(fileExtension, fileName);
        }
        public string parseDocument(string filename)
        {
            return "";
        }
    }
}