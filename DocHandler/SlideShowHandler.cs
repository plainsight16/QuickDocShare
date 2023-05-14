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
        public override string parseDocument(string filename)
        {
            return "";
        }
    }
}