using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocHandler.Tests
{
    [TestFixture]
    public class DocParserTests
    {
        private DocParser parser;

        [SetUp]
        public void Setup()
        {
            parser = new DocParser();
        }

        [Test]
        public void CanParse_ValidDocFile_ReturnsTrue()
        {
            // Arrange
            string filePath = "C:\\path\\to\\valid.doc";

            // Act
            bool result = parser.CanParse(filePath);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanParse_InvalidDocFile_ReturnsFalse()
        {
            // Arrange
            string filePath = "C:\\path\\to\\invalid.txt";

            // Act
            bool result = parser.CanParse(filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ParseDocument_ValidDocFile_ReturnsDocumentContent()
        {
            // Arrange
            string filePath = "C:\\path\\to\\document.doc";
            string expectedContent = "This is the content of the document.";

            // Act
            string result = parser.parseDocument(filePath);

            // Assert
            Assert.That(result, Is.EqualTo(expected: expectedContent));
        }
    }
}
