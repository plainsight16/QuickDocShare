using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

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