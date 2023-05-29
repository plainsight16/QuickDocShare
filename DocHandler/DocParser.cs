using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;


namespace DocHandler
{
    /// <summary>
    /// Represents a parser for .doc files using the Microsoft Office Interop library.
    /// </summary>
    public class DocParser : DocumentParser
    {
        /// <summary>
        /// Determines if the parser can parse the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the parser can parse the file; otherwise, false.</returns>
        public override bool CanParse(string filePath)
        {
            if (Path.Exists(filePath))
            {
                // Get the file extension
                string fileExtension = Path.GetExtension(filePath);

                // Check if the file extension is .doc
                return fileExtension.Equals(".doc");
            }
            return false;
        }

        /// <summary>
        /// Parses the document and returns its content as a string.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>The content of the document as a string.</returns>
        public override string parseDocument(string filePath)
        {
            // Load .doc file
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(filePath);

            // Extract text from the document
            string text = document.GetText().Replace("Evaluation Warning: The document was created with Spire.Doc for .NET.", "");
            return text;
        }
    }
}
