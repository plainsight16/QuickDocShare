namespace DocHandler
{
    public class TextDocumentParser : DocumentParser
    {
        public override bool CanParse(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            return fileExtension.Equals(".txt");
        }

        public override string parseDocument(string filename)
        {
            string result = string.Empty;
            string text = File.ReadAllText(filename);
            return text;
        }
    }
}