using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocHandler.Tests
{
    [TestFixture]
    public class PdfParserTests
    {
        private PdfParser parser;
        static string path = @"C:\Users\Julius Alibrown\Desktop\class\Project\new\search-engine\Files\Documents\";
        string filePath = path + "pdf_test_file.pdf";

        [SetUp]
        public void Setup()
        {
            parser = new PdfParser();
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
            string invalidFilePath = "C:\\path\\to\\invalid.pdf";

            // Act
            bool result = parser.CanParse(invalidFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ParseDocument_ValidFile_ReturnsContent()
        {
            // Arrange
            string expectedContent = "This is a PDF file.";

            // Act
            string result = parser.parseDocument(filePath).Trim();

            // Assert
            Assert.That(result, Is.EqualTo(expected: expectedContent));
        }
    }
}
