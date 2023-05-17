namespace DocHandler
{
    public class SpreadsheetHandler: DocumentHandler
    {
        public SpreadsheetHandler(DocumentHandler next) : base(next)
        {}

        public override string parseDocument(string fileExtension, string fileName)
        {
            if(fileExtension == "xlsx")
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