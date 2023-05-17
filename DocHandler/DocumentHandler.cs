namespace DocHandler
{
    public abstract class DocumentHandler
    {
        // The next handler in the chain
        protected DocumentHandler next;
        // The constructor accepts the next handler in the chain
        public DocumentHandler(DocumentHandler next)
        {
            this.next = next;
        }

        // The method that handles the request
        public virtual string parseDocument(string fileExtension, string fileName)
        {
            if(next != null)
            {
                next.parseDocument(fileExtension, fileName);
            }
            return "File extension not supported";
        }
    }
}