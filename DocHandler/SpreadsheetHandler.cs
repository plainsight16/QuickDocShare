using OfficeOpenXml;
using System.Text;
namespace DocHandler
{
    public class SpreadsheetHandler: DocumentHandler
    {
        public SpreadsheetHandler(DocumentHandler next) : base(next)
        {}

        public override string parseDocument(string fileExtension, string fileName)
        {
            if(fileExtension == ".xlsx")
            {
                return parseDocument(fileName);
            }
            return base.parseDocument(fileExtension, fileName);
        }

        public string parseDocument(string filename)
        {
            StringBuilder sb = new StringBuilder();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filename)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                // Loop through each row in the worksheet
                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    // Loop through each column in the row
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        // Append the cell value to the string builder
                        sb.Append(worksheet.Cells[row, col].Value?.ToString() ?? string.Empty);
                        sb.Append("\t"); // Add a tab separator between columns
                    }
                    sb.AppendLine(); // Add a line break after each row
                }
            }
            return sb.ToString();
        }
    }
}