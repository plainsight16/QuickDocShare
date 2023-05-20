namespace DocHandler
{
    public class DocumentHandler
    {
        private string FolderPath;
        private DocumentParser parser;

        public DocumentHandler(string folderPath)
        {
            FolderPath = folderPath;
            BuildHandler();
        }
        private void BuildHandler()
        {
            DocumentParser slideshowParser = new SlideShowParser();
            DocumentParser textDocumentParser = new TextDocumentParser();
            DocumentParser spreadsheetParser = new SpreadsheetParser();
            DocumentParser HtmlParser = new HtmlParser();
            DocumentParser XmlParser = new XmlParser();
            DocumentParser PdfParser = new PdfParser();
            DocumentParser DocXParser = new DocXParser();
            DocumentParser DocParser = new DocParser();
            slideshowParser.SetNext(spreadsheetParser);
            spreadsheetParser.SetNext(textDocumentParser);
            textDocumentParser.SetNext(HtmlParser);
            HtmlParser.SetNext(XmlParser);
            XmlParser.SetNext(PdfParser);
            PdfParser.SetNext(DocXParser);
            DocXParser.SetNext(DocParser);

            parser = slideshowParser;
        }
        public string[] GetFilesInFolder()
        {
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                throw new DirectoryNotFoundException("Folder not found: " + FolderPath);
            }
            // Get the list of files in the folder
            return Directory.GetFiles(FolderPath);
        }

        public Dictionary<string, string> GetDocTexts()
        {
            Dictionary<string, string> doc_texts = new Dictionary<string, string>();
            string[] filePaths = GetFilesInFolder();
            foreach (string filepath in filePaths)
            {
                DocumentParser currentParser = parser;
                bool parsed = false;
                while(currentParser != null && !parsed){
                    if(currentParser.CanParse(filepath))
                    {
                        string text = currentParser.parseDocument(filepath);
                        parsed = true;
                        doc_texts.Add(filepath, text);
                    }
                    else
                    {
                        currentParser = currentParser.next;
                    }
                }
            }
            return doc_texts;
        }
    }
}