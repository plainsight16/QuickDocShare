using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace DocHandler
{
    public class PdfParser : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            return fileExtension.Equals(".pdf");
        }

        public override string parseDocument(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, pageNumber, strategy);

                    sb.Append(pageText);
                }
            }

            return sb.ToString();
        }
    }    
}