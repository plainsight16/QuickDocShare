using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DocHandler
{
    /// <summary>
    /// Represents a document parser for spreadsheet files.
    /// </summary>
    public class SpreadsheetParser: DocumentParser
    {
        /// <summary>
        /// Determines if the document parser can handle the specified file.
        /// </summary>
        /// <param name="fileName">The path to the document file.</param>
        /// <returns>True if the parser can handle the file; otherwise, false.</returns>
        public override bool CanParse(string filePath)
        {
            if (Path.Exists(filePath))
            {
                string fileExtension = Path.GetExtension(filePath);
                return fileExtension.Equals(".xlsx");
            }
            return false;
        }

        /// <summary>
        /// Parses the spreadsheet document specified by the file path.
        /// </summary>
        /// <param name="filename">The path to the spreadsheet document file.</param>
        /// <returns>The parsed text content of the spreadsheet document.</returns>
        public override string parseDocument(string filename)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                if (workbookPart != null)
                {
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.FirstOrDefault();
                    if (worksheetPart != null)
                    {
                        List<OpenXmlElement> sheetData = worksheetPart.Worksheet.Descendants<Row>().Cast<OpenXmlElement>().ToList();

                        if (sheetData != null)
                        {
                            string text = "";
                            foreach (Row row in sheetData)
                            {
                                foreach (Cell cell in row.Elements<Cell>())
                                {
                                    if (cell.CellValue != null)
                                    {
                                        text += GetCellValue(cell, workbookPart) + " ";
                                    }
                                }
                                text += Environment.NewLine;
                            }

                            //Console.WriteLine(text);

                            return text;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the value of a cell in a spreadsheet.
        /// </summary>
        /// <param name="cell">The cell to retrieve the value from.</param>
        /// <param name="workbookPart">The workbook part containing the shared string table.</param>
        /// <returns>The value of the cell.</returns>
        private string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            string value = cell.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                int sharedStringId = int.Parse(value);
                SharedStringTablePart sharedStringTablePart = workbookPart.SharedStringTablePart;
                if (sharedStringTablePart != null)
                {
                    SharedStringItem sharedStringItem = sharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(sharedStringId);
                    if (sharedStringItem != null)
                    {
                        value = sharedStringItem.Text.Text;
                    }
                }
            }

            return value;
        }

    }
}