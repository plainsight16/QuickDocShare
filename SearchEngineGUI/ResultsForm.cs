﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

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
              
                Button btn = new Button();
                btn.Text = Path.GetFileName(item.);
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