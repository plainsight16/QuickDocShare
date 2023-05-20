using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

namespace DocHandler
{
    public class SlideShowParser : DocumentParser
    {
        public override bool CanParse(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return fileExtension.Equals(".pptx");
        }
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
                    return text;
                }
            }
            return null;
        }

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