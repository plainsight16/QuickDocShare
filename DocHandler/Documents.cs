namespace DocHandler
{
    public class Documents
    {
        private string FolderPath;

        public Documents(string folderPath)
        {
            this.FolderPath = folderPath;
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
                DocumentHandler docHandler = new SpreadsheetHandler(new SlideShowHandler(new TextDocumentHandler(null)));
                string text = docHandler.parseDocument(Path.GetExtension(filepath), filepath);
                doc_texts.Add(text);
            }
            return doc_texts;
        }
    }
}