using NUnit.Framework;
using System.Text;

namespace DocHandler.Tests
{
    [TestFixture]
    public class DocParserTests
    {
        private DocParser parser;
        static string path = @"C:\Users\Julius Alibrown\Desktop\class\Project\new\search-engine\Files\Documents\";
        string filePath = path + "Doc_test_file.doc";

        [SetUp]
        public void Setup()
        {
            parser = new DocParser();
        }

        [Test]
        public void CanParse_ValidFile_ReturnsTrue()
        {
            // Act
            bool result = parser.CanParse(filePath);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanParse_InvalidFile_ReturnsFalse()
        {
            // Arrange
            string invalidFilePath = "C:\\path\\to\\invalid.doc";

            // Act
            bool result = parser.CanParse(invalidFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ParseDocument_ValidFile_ReturnsContent()
        {
            // Arrange
            string expectedContent = "This is the content of the document.";

            // Act'
            byte[] bomBytes = Encoding.UTF8.GetBytes("\uFEFF");
            char[] bomChars = Encoding.UTF8.GetString(bomBytes).ToCharArray();
            string result = parser.parseDocument(filePath).Trim().TrimStart(bomChars);

            // Assert
            Assert.That(result, Is.EqualTo(expected: expectedContent));
        }
    }
}
