namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for text files.
    /// </summary>
    public class TextDocumentParser : DocumentParser
    {
        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="fileName">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public override bool CanParse(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            return fileExtension.Equals(".txt");
        }

        /// <summary>
        /// Parses the text document specified by the file path.
        /// </summary>
        /// <param name="filename">The path to the text document file.</param>
        /// <returns>The parsed text content of the text document.</returns>
        public override string parseDocument(string filename)
        {
            string result = string.Empty;
            string text = File.ReadAllText(filename);
            return text;
        }
    }
}