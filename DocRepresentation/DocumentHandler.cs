namespace DocRepresentation
{
    public abstract class DocumentHandler
    {
        private DocumentHandler next;
        public DocumentHandler(DocumentHandler next)
        {
            this.next = next;
        }

    }


    public class SlideshowHandler : DocumentHandler
    {
        public SlideshowHandler(DocumentHandler next) : base(next)
        {
        }
    }
}