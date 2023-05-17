using OfficeOpenXml;
using System.Text;
namespace DocHandler
{
    public class SpreadsheetParser: DocumentParser
    {
        public override bool CanParse(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            return fileExtension.Equals(".xlsx");
        }

        public override string parseDocument(string filename)
        {
            string result = string.Empty;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filename)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                if (worksheet != null)
                {
                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            result += worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;
                            result += "\t";
                        }

                        result += "\n";
                    }
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
    }
}