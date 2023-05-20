using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for PDF files.
    /// </summary>
    public class PdfParser : DocumentParser
    {
        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public override bool CanParse(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            return fileExtension.Equals(".pdf");
        }

        /// <summary>
        /// Parses the PDF document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the PDF document file.</param>
        /// <returns>The parsed text content of the PDF document.</returns>
        public override string parseDocument(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                // Iterate over each page of the PDF document
                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
                {
                    // Use a text extraction strategy to extract text from the page
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, pageNumber, strategy);

                    sb.Append(pageText);
                }
            }

            //Console.WriteLine(sb.ToString());

            return sb.ToString();
        }
    }    
}