//using Lucene.Net.Tartarus.Snowball.Ext;
using Lucene.Net.Tartarus.Snowball.Ext;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DocRepresentation
{
    /// <summary>
    /// Represents a token, consisting of a document ID and a token string.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// The ID of the document that this token belongs to.
        /// </summary>
        public int doc_id;

        /// <summary>
        /// The token value.
        /// </summary>
        public string token;

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class with the specified document ID and token.
        /// </summary>
        /// <param name="doc_id">The document ID associated with the token.</param>
        /// <param name="token">The token string.</param
        public Token(int doc_id, string token)
        {
            this.doc_id = doc_id;
            this.token = token;
        }
    }

    /// <summary>
    /// Represents a class responsible for tokenizing and normalizing a list of document texts.
    /// </summary>
    public class Tokenize
    {
        private List<string> doc_texts;
        private List<Token> tokens;
        public List<Token> normalized_tokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tokenize"/> class with the specified list of document texts.
        /// </summary>
        /// <param name="doc_texts">The list of document texts to tokenize and normalize.</param>
        public Tokenize(List<string> doc_texts)
        {
            this.doc_texts = doc_texts;
            tokens = new List<Token>();
            normalized_tokens = new List<Token>();
            tokenizer();
            Normalize();
        }

        /// <summary>
        /// Tokenizes the document texts and creates tokens.
        /// </summary>
        private void tokenizer()
        {
            foreach (string doc_text in doc_texts)
            {

                string[] words = doc_text.Split(' ');
                foreach (string word in words)
                {
                    // index starts from 0 but ID starts from 1
                    int doc_id = doc_texts.IndexOf(doc_text) + 1;
                    tokens.Add(new Token(doc_id, word));
                }
            }
        }

        /// <summary>
        /// Normalizes the tokens by applying various normalization techniques.
        /// </summary>
        private void Normalize()
        {
            foreach (Token token in tokens)
            {
                normalized_tokens.Add(new Token(token.doc_id, Normalize(token.token)));
            }
        }

        /// <summary>
        /// Normalizes the input string by converting it to lowercase, removing punctuation marks and symbols,
        /// expanding contractions, and removing diacritics.
        /// </summary>
        /// <param name="input">The input string to normalize.</param>
        /// <returns>The normalized string.</returns>
        public string Normalize(string input)
        {
            // Convert all characters to lowercase
            input = input.ToLower(CultureInfo.InvariantCulture);

            // Remove all punctuation marks and symbols
            input = new string(input.Where(c => !char.IsPunctuation(c) && !char.IsSymbol(c)).ToArray());

            // Expand contractions (optional)
            input = Regex.Replace(input, @"\b(can't|won't|didn't|doesn't|isn't|aren't|haven't|hasn't)\b", match =>
                match.Value.Replace("'", "") + " not", RegexOptions.IgnoreCase);

            // Remove diacritics (optional)
            input = input.Normalize(NormalizationForm.FormD);
            input = new string(input.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) !=
                UnicodeCategory.NonSpacingMark).ToArray());
            input = input.Normalize(NormalizationForm.FormC);

            // Stem or lemmatize words (optional)
            var stemmer = new EnglishStemmer();
            stemmer.SetCurrent(input);
            bool stem = stemmer.Stem();

            //Console.WriteLine(stem);
            //Console.WriteLine(input);
            //Console.WriteLine(stemmer.Current);

            return stemmer.Current;
        }

        /// <summary>
        /// Gets the list of tokens.
        /// </summary>
        /// <returns>The list of tokens.</returns>
        public List<Token> GetTokens()
        {
            return tokens;
        }

        /// <summary>
        /// Gets the list of normalized tokens.
        /// </summary>
        /// <returns>The list of normalized tokens.</returns>
        public List<Token> GetNormalized_tokens()
        {
            return normalized_tokens;
        }
    }
}
