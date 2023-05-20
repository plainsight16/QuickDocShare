using Microsoft.Office.Interop.Word;
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
            // Get the file extension
            string fileExtension = Path.GetExtension(filePath);

            // Check if the file extension is .doc
            return fileExtension.Equals(".doc");
        }

        /// <summary>
        /// Parses the document and returns its content as a string.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>The content of the document as a string.</returns>
        public override string parseDocument(string filePath)
        {
            // Create a StringBuilder to store the document content
            StringBuilder sb = new StringBuilder();

            // Create a new instance of the Word application
            Application wordApp = new Application();

            // Open the document file
            Document wordDoc = wordApp.Documents.Open(filePath);

            // Iterate through the story ranges in the document
            foreach (Microsoft.Office.Interop.Word.Range range in wordDoc.StoryRanges)
            {
                // Append the text of each range to the StringBuilder
                sb.Append(range.Text);
            }

            // Close the document and quit the Word application
            wordDoc.Close();
            wordApp.Quit();

            // Return the document content as a string
            return sb.ToString();
        }
    }
}
