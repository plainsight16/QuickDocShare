using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocRepresentation;

namespace DocRanker.Tests
{
    [TestFixture]
    internal class DocRankerTests
    {
        private Ranker ranker;
        private Dictionary<string, List<Token>> wordIndex;



        [SetUp]
        public void SetUp()
        {
            wordIndex = new Dictionary<string, List<Token>>()
            {
                {"apple", new List<Token>(){new Token(1, "apple", "file1"), new Token(2, "apple", "file2")}},
                {"banana", new List<Token>(){new Token(3, "banana", "file3"), new Token(2, "banana", "file2")}},
                {"cherry", new List<Token>(){new Token(1, "cherry", "file1"), new Token(2, "cherry", "file2")}}
            };

            //Initialize ranker with wordIndex
            ranker = new Ranker(wordIndex);
        }
        [Test]
        public void RankQuery_WithValidQuery_ReturnsRankedDocuments()
        {
            // Arrange
            string query = "apple banana";

            // Act
            List<Token> rankedDocuments = ranker.RankQuery(query);

            // Assert
            Assert.AreEqual(3, rankedDocuments.Count);
            Assert.AreEqual(2, rankedDocuments[0].doc_id);
            Assert.AreEqual(1, rankedDocuments[1].doc_id);
            Assert.AreEqual(3, rankedDocuments[2].doc_id);
        }

        [Test]
        public void RankQuery_WithEmptyQuery_ReturnsEmptyList()
        {
            // Arrange
            string query = string.Empty;

            // Act
            List<Token> rankedDocuments = ranker.RankQuery(query);

            // Assert
            Assert.IsEmpty(rankedDocuments);
        }

        [Test]
        public void RankQuery_WithNon_ExistentQuery_ReturnsEmptyList()
        {
            // Arrange
            string query = "pineapple";

            // Act
            List<Token> rankedDocuments = ranker.RankQuery(query);

            // Assert
            Assert.IsEmpty(rankedDocuments);
        }
        
    }
}
   
   
