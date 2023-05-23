using DocRepresentation;
using System.Diagnostics;

namespace SearchEngineGUI
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(List<Token> rankedDocuments)
        {
            InitializeComponent();
            DisplayResults(rankedDocuments);
        }

        private void DisplayResults(List<Token> rankedDocuments)
        {
            int currentHeight = 0;
            foreach (Token item in rankedDocuments)
            {
                string filePath = item.filePath;
              
                Button btn = new Button();
                btn.Text = Path.GetFileName(filePath);
                btn.Height = 50;
                btn.Width = 100;
                btn.Location =  new Point(0, currentHeight);
                btn.Click += (object sender, EventArgs e) =>
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                };
                Controls.Add(btn);
                currentHeight = currentHeight + 50;
            }
        }
    }
}
