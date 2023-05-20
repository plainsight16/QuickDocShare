using Microsoft.Office.Interop.Word;
using System.Text;
namespace DocHandler
{
    public class DocParser : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return fileExtension.Equals(".doc");
        }

        public override string parseDocument(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            Application wordApp = new Application();
            Document wordDoc = wordApp.Documents.Open(filePath);

            foreach (Microsoft.Office.Interop.Word.Range range in wordDoc.StoryRanges)
            {
                sb.Append(range.Text);
            }

            wordDoc.Close();
            wordApp.Quit();

            return sb.ToString();
        }
    }
}