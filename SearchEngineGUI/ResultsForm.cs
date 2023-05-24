using DocRepresentation;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;

namespace SearchEngineGUI
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(List<Token> rankedDocuments, string query)
        {
            InitializeComponent();
            CustomizeListView(query);
            DisplayResults(rankedDocuments);
        }

        private void CustomizeListView(string query)
        {
            // update result label
            ResultLabel.Text += string.Format(" for {0}", query);

            ResultsListView.Dock = DockStyle.None;
            ResultsListView.View = View.Details;
            ResultsListView.GridLines = true;
            ResultsListView.BackColor = System.Drawing.Color.White;
            ResultsListView.ForeColor = System.Drawing.Color.Black;
            ResultsListView.HeaderStyle = ColumnHeaderStyle.None;

            // Set the padding for ListViewItems
            int padding = 10;
            ResultsListView.DrawItem += (sender, e) =>
            {
                e.DrawBackground();
                e.DrawText(TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                Rectangle itemBounds = e.Bounds;
                itemBounds.Inflate(-padding, -padding);
                ResultsListView.Invalidate(itemBounds);
            };

            // Create column headers
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Width = ResultsListView.Width; // Auto-size column to fill ListView width
            columnHeader.Text = "";
            ResultsListView.Columns.Add(columnHeader);

        }

        private void DisplayResults(List<Token> rankedDocuments)
        {

            foreach (Token item in rankedDocuments)
            {
                string filePath = item.filePath;
                string fileName = Path.GetFileName(filePath);

                ListViewItem listViewItem = new ListViewItem(fileName);
                listViewItem.Tag = filePath; // Store the string value in the Tag property
                //listViewItem.Font = listItemFont;
                ResultsListView.Items.Add(listViewItem);
            }

            ResultsListView.ItemActivate += ResultsListView_ItemActivate;

        }

        private void ResultsListView_ItemActivate(object sender, EventArgs e)
        {
            // Get the selected item
            if (ResultsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = ResultsListView.SelectedItems[0];

                // Get the stored string value from the Tag property
                string filePath = selectedItem.Tag.ToString();

                // Perform your action here with the selected value
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }
    }
}
