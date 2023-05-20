namespace DocHandler
{
    /// <summary>
    /// Represents an abstract base class for document parsers.
    /// </summary>
    public abstract class DocumentParser
    {
        
        public DocumentParser next;

        /// <summary>
        /// Sets the next document parser in the chain of responsibility.
        /// </summary>
        /// <param name="next">The next document parser to be set.</param>
        public void SetNext(DocumentParser next)
        {
            this.next = next;
        }

        /// <summary>
        /// Parses the document specified by the file path.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>The parsed text of the document.</returns>
        public abstract string parseDocument(string filePath);

        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public abstract bool CanParse(string filePath);
    }
}