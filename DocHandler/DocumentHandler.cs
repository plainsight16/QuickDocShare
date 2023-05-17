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
            slideshowParser.SetNext(spreadsheetParser);
            spreadsheetParser.SetNext(textDocumentParser);
            textDocumentParser.SetNext(HtmlParser);
            HtmlParser.SetNext(XmlParser);
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

        public List<string> GetDocTexts()
        {
            List<string> doc_texts = new List<string>();
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
                        doc_texts.Add(text);
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