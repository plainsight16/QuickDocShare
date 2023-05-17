using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Text;


namespace DocHandler
{
    public class DocXParser   : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            return fileExtension.Equals(".docx");
        }

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