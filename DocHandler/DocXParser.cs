using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Text;


namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for DOCX files.
    /// </summary>
    public class DocXParser   : DocumentParser
    {
        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public override bool CanParse(string filePath)
        {

            string fileExtension = System.IO.Path.GetExtension(filePath);
            return fileExtension.Equals(".docx");
        }

        /// <summary>
        /// Parses the document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>The parsed text of the document.</returns>
        public override string parseDocument(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                var body = doc.MainDocumentPart.Document.Body;

                foreach (var text in body.Descendants<Text>())
                {
                    sb.Append(text.Text);
                }
            }

            return sb.ToString();
        }

    }
}