using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for PowerPoint slide show files.
    /// </summary>
    public class SlideShowParser : DocumentParser
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
                return fileExtension.Equals(".pptx");
            }
            return false;
        }

        /// <summary>
        /// Parses the slide show document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the slide show document file.</param>
        /// <returns>The parsed text content of the slide show document.</returns>
        public override string parseDocument(string filePath)
        {
            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                PresentationPart presentationPart = presentationDocument.PresentationPart;
                if (presentationPart != null)
                {
                    Presentation presentation = presentationPart.Presentation;

                    string text = "";
                    foreach (SlideId slideId in presentation.SlideIdList)
                    {
                        SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                        if (slidePart != null)
                        {
                            Slide slide = slidePart.Slide;
                            text += GetSlideText(slide);
                        }
                    }
                    return text.Trim();
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves the text content from a slide.
        /// </summary>
        /// <param name="slide">The slide to extract text from.</param>
        /// <returns>The extracted text content of the slide.</returns>
        private string GetSlideText(Slide slide)
        {
            string text = "";
            foreach (var element in slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>())
            {
                text += element.Text;
            }
            return text;
        }
    }
}