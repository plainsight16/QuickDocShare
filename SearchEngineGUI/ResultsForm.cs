using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchEngineGUI
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(List<int> rankedDocuments, Dictionary<int, string> documentPathAndID)
        {
            InitializeComponent();
            DisplayResults(rankedDocuments, documentPathAndID);
        }

        private void DisplayResults(List<int> rankedDocuments, Dictionary<int, string> documentPathAndID)
        {
            int currentHeight = 0;
            foreach (var item in rankedDocuments)
            {
                string path = documentPathAndID[item];
                string message = string.Format("Document Id: {0}, Path: {1}", item, path);
               
                Button btn = new Button();
                btn.Text = Path.GetFileName(path);
                btn.Height = 50;
                btn.Width = 100;
                btn.Location =  new Point(0, currentHeight);
                btn.Click += (object sender, EventArgs e) =>
                {
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                };
                Controls.Add(btn);
                currentHeight = currentHeight + 50;
            }
        }
    }
}
