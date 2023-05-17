namespace DocHandler
{
    public class Documents
    {
        private string FolderPath = @".\Files";
        DocumentHandler docHandler;
        public List<string> doc_texts;
        private List<string> filePaths;

        public Documents(string folderPath)
        {
            docHandler = new SlideShowHandler(new TextDocumentHandler(new SpreadsheetHandler(null)));
            filePaths = new List<string>();
            doc_texts = new List<string>();
            GetFilesInFolder(folderPath);
            GetDocTexts();

        }

        public string[] GetFilesInFolder(string folderPath)
        {
            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException("Folder not found: " + folderPath);
            }

            // Get the list of files in the folder
            string[] files = Directory.GetFiles(folderPath);

            return files;
        }

        public void GetDocTexts()
        {
            foreach (string filepath in filePaths)
            {
                string text = docHandler.parseDocument(Path.GetExtension(filepath), filepath);
                doc_texts.Add(text);
            }
        }
    }
}