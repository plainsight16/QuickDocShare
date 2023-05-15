namespace DocHandler
{
    public class SlideShowHandler : DocumentHandler
    {
        public SlideShowHandler(DocumentHandler next) : base(next)
        {}

        public override void handleRequest(String fileExtension)
        {
            if(fileExtension == "pptx")
            {
                Console.WriteLine("Parsing pptx file...");
            }
            else if (next != null)
            {
                base.handleRequest(fileExtension);
            }
        }

        public override string parseDocument(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                HSLFSlideShow slideShow = new HSLFSlideShow(fileStream);
                PowerPointTextExtractor extractor = new PowerPointTextExtractor(slideShow);

                string text = extractor.Text;
                return text;
            }
        }
    }
}