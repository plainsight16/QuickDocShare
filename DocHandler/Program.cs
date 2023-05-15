namespace DocHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentHandler doc_handler = new SlideShowHandler(null);
            doc_handler.parseDocument(@"C:\Users\Julius Alibrown\Desktop\class\Project\search-engine\DocHandler\powerpoint_file.pptx");
        }
    }
}