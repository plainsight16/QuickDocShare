using System.Xml;
namespace DocHandler
{
    public class XmlParser : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return fileExtension.Equals(".xml");
        }

        public override string parseDocument(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            string xmlString = xmlDoc.OuterXml;
            return xmlString;
        }
    }
}