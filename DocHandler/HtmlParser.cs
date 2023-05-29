using HtmlAgilityPack;

namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for HTML files.
    /// </summary>
    public class HtmlParser : DocumentParser
    {
        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public override bool CanParse(string filePath)
        {
            if (Path.Exists(filePath))
            {
                string fileExtension = Path.GetExtension(filePath);
                return fileExtension.Equals(".html");
            }
            return false;
        }

        /// <summary>
        /// Parses the HTML document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the HTML document file.</param>
        /// <returns>The parsed HTML string.</returns>
        public override string parseDocument(string filePath)
        {
            // Load the HTML document using HtmlAgilityPack
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);

            // Extract the HTML content as a string
            string htmlString = htmlDoc.DocumentNode.InnerText;
            return htmlString;
        }
    }
}