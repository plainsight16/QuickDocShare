using HtmlAgilityPack;
namespace DocHandler
{
    public class HtmlParser : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return fileExtension.Equals(".html");
        }

        public override string parseDocument(string filePath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);

            string htmlString = htmlDoc.DocumentNode.OuterHtml;
            return htmlString;
        }
    }
}