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
    public class Token
    {
        public int doc_id;
        public string token;

        public Token(int doc_id, string token)
        {
            this.doc_id = doc_id;
            this.token = token;
        }
    }

    public class Tokenize
    {
        private List<string> doc_texts;
        private List<Token> tokens;
        public List<Token> normalized_tokens;

        public Tokenize(List<string> doc_texts)
        {
            this.doc_texts = doc_texts;
            tokens = new List<Token>();
            normalized_tokens = new List<Token>();
            tokenizer();
            Normalize();
        }

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

        private void Normalize()
        {
            foreach (Token token in tokens)
            {
                normalized_tokens.Add(new Token(token.doc_id, Normalize(token.token)));
            }
        }

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
            //var stemmer = new EnglishStemmer();
            //stemmer.SetCurrent(input);
            //bool stem = stemmer.Stem();

            //Console.WriteLine(stem);
            //Console.WriteLine(input);
            //Console.WriteLine(stemmer.Current);

            return input;
        }

        public List<Token> GetTokens()
        {
            return tokens;
        }

        public List<Token> GetNormalized_tokens()
        {
            return normalized_tokens;
        }
    }
}
