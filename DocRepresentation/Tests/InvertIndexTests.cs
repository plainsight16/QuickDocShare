using NUnit.Framework;
using System.Collections.Generic;

namespace DocRepresentation.Tests
{
    [TestFixture]
    public class InvertIndexTests
    {
        [Test]
        public void GetMergedIndex_ReturnsEmptyDictionary_WhenNoTokensProvided()
        {
            // Arrange
            List<Token> tokens = new List<Token>();
            InvertIndex invertIndex = new InvertIndex(tokens);

            // Act
            Dictionary<string, List<Token>> mergedIndex = invertIndex.GetMergedIndex();

            // Assert
            Assert.IsEmpty(mergedIndex);
        }

        [Test]
        public void GetMergedIndex_ConstructsInvertedIndex_WithCorrectTermsAndDocumentIDs()
        {
            // Arrange
            List<Token> tokens = new List<Token>
            {
                new Token(1, "apple", "file1.txt"),
                new Token(2, "banana", "file2.txt"),
                new Token(3, "orange", "file3.txt"),
                new Token(2, "banana", "file2.txt"),
                new Token(3, "apple", "file3.txt"),
                new Token(3, "banana", "file3.txt")
            };

            InvertIndex invertIndex = new InvertIndex(tokens);

            // Act
            Dictionary<string, List<Token>> mergedIndex = invertIndex.GetMergedIndex();

            // Assert
            Assert.AreEqual(3, mergedIndex.Count);

            Assert.IsTrue(mergedIndex.ContainsKey("apple"));
            CollectionAssert.AreEquivalent(new List<Token>
            {
                new Token(1, "apple", "file1.txt"),
                new Token(3, "apple", "file3.txt"),
                new Token(3, "apple", "file3.txt")
            }, mergedIndex["apple"]);

            Assert.IsTrue(mergedIndex.ContainsKey("banana"));
            CollectionAssert.AreEquivalent(new List<Token>
            {
                new Token(2, "banana", "file2.txt"),
                new Token(3, "banana", "file2.txt")
            }, mergedIndex["banana"]);

            Assert.IsTrue(mergedIndex.ContainsKey("orange"));
            CollectionAssert.AreEquivalent(new List<Token>
            {
                new Token(3, "orange", "file3.txt")
            }, mergedIndex["orange"]);
        }
    }
}
  
