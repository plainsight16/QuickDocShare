namespace DocHandler
{
    public abstract class DocumentParser
    {
        public DocumentParser next;
        public void SetNext(DocumentParser next)
        {
            this.next = next;
        }

        // The method that handles the request
        public abstract string parseDocument(string filePath);
        public abstract bool CanParse(string filePath);
    }
}