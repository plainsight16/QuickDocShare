namespace DocHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DocumentHandler doc_handler = new SpreadsheetHandler(new SlideShowHandler(new TextDocumentHandler(null)));
            doc_handler.handleRequest("pptx");
            doc_handler.parseDocument("powerpoint_file.pptx")
            //doc_handler.handleRequest("xlsx");
            //doc_handler.handleRequest("pptx");
            //doc_handler.handleRequest("docx");


        }
    }
}