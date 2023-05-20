namespace DocHandler
{
    /// <summary>
    /// Represents a document handler that processes files in a specified folder.
    /// </summary>
    public class DocumentHandler
    {
        private string FolderPath;
        private DocumentParser parser;

        /// <summary>
        /// Initializes a new instance of the DocumentHandler class with the specified folder path.
        /// </summary>
        /// <param name="folderPath">The path to the folder containing the documents.</param>
        public DocumentHandler(string folderPath)
        {
            FolderPath = folderPath;
            BuildHandler();
        }

        /// <summary>
        /// Builds the document handler by setting up the chain of document parsers.
        /// </summary>
        private void BuildHandler()
        {
            // Create instances of different document parsers
            DocumentParser slideshowParser = new SlideShowParser();
            DocumentParser textDocumentParser = new TextDocumentParser();
            DocumentParser spreadsheetParser = new SpreadsheetParser();
            DocumentParser HtmlParser = new HtmlParser();
            DocumentParser XmlParser = new XmlParser();
            DocumentParser PdfParser = new PdfParser();
            DocumentParser DocXParser = new DocXParser();
            DocumentParser DocParser = new DocParser();

            // Set up the chain of responsibility by linking the parsers together
            slideshowParser.SetNext(spreadsheetParser);
            spreadsheetParser.SetNext(textDocumentParser);
            textDocumentParser.SetNext(HtmlParser);
            HtmlParser.SetNext(XmlParser);
            XmlParser.SetNext(PdfParser);
            PdfParser.SetNext(DocXParser);
            DocXParser.SetNext(DocParser);

            // Set the starting parser
            parser = slideshowParser;
        }

        /// <summary>
        /// Gets the list of files in the specified folder.
        /// </summary>
        /// <returns>An array of file paths.</returns>
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

        /// <summary>
        /// Retrieves the texts of the documents in the folder using the appropriate parsers.
        /// </summary>
        /// <returns>A dictionary containing the file paths and their corresponding texts.</returns>
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