using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocRepresentation.Tests
{
    [TestFixture]
    public class TokenizeTests
    {
        [Test]
        public void Tokenize_Constructor_InputDocTexts_PopulatesTokensAndNormalizedTokens()
        {
            // Arrange
            Dictionary<string, string> docTexts = new Dictionary<string, string>
            {
                { "file1.txt", "This is the content of file 1." },
                { "file2.txt", "Here is some text from file 2." }
            };

            // Act
            Tokenize tokenizer = new Tokenize(docTexts);
            List<Token> tokens = tokenizer.GetTokens();
            List<Token> normalizedTokens = tokenizer.GetNormalized_tokens();

            // Assert
            // Test that the tokens and normalized tokens lists are not empty
            Assert.That(tokens.Count > 0);
            Assert.That(normalizedTokens.Count > 0);

            // Test the token properties
            foreach (Token token in tokens)
            {
                Assert.That(token.doc_id > 0);
                Assert.That(!string.IsNullOrWhiteSpace(token.token));
                Assert.That(!string.IsNullOrWhiteSpace(token.filePath));
            }

            // Test the normalized token properties
            foreach (Token normalizedToken in normalizedTokens)
            {
                Assert.That(normalizedToken.doc_id > 0);
                Assert.That(!string.IsNullOrWhiteSpace(normalizedToken.token));
                Assert.That(!string.IsNullOrWhiteSpace(normalizedToken.filePath));
            }
        }
    }
}
