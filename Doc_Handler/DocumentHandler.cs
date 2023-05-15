using System;
using System.IO;
using NPOI.HSLF.Extractor;
using NPOI.SS.UserModel;


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
        public virtual void handleRequest(String fileExtension)
        {
            if(next != null)
            {
                next.handleRequest(fileExtension);
            }
            else if(next == null)
            {
                Console.WriteLine("File extension not supported");
            }
        }

        public abstract string parseDocument(string filename);

        
    }

    // The concrete handlers
   

    public class TextDocumentHandler : DocumentHandler
    {
        public TextDocumentHandler(DocumentHandler next) : base(next)
        {}

        public override void handleRequest(String fileExtension)
        {
            if(fileExtension == "txt")
            {
                Console.WriteLine("Parsing txt file...");
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

    public class SpreadsheetHandler: DocumentHandler
    {
        public SpreadsheetHandler(DocumentHandler next) : base(next)
        {}

        public override void handleRequest(String fileExtension)
        {
            if(fileExtension == "xlsx")
            {
                Console.WriteLine("Parsing xlsx file...");
            }
            else
            {
                base.handleRequest(fileExtension);
            }
        }

    }
}