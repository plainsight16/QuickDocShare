using System.Xml;
namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for XML files.
    /// </summary>
    public class XmlParser : DocumentParser
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
                return fileExtension.Equals(".xml");
            }
            return false;
        }

        /// <summary>
        /// Parses the XML document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the XML document file.</param>
        /// <returns>The parsed XML content of the document.</returns>
        public override string parseDocument(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            string xmlString = xmlDoc.InnerText;
            return xmlString;
        }
    }
}