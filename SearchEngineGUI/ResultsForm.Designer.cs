namespace SearchEngineGUI
{
    partial class ResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ResultLabel = new Label();
            ResultsListView = new ListView();
            SuspendLayout();
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ResultLabel.Location = new Point(21, 22);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(80, 25);
            ResultLabel.TabIndex = 1;
            ResultLabel.Text = "Results";
            ResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResultsListView
            // 
            ResultsListView.Alignment = ListViewAlignment.Left;
            ResultsListView.BorderStyle = BorderStyle.None;
            ResultsListView.LabelWrap = false;
            ResultsListView.Location = new Point(27, 78);
            ResultsListView.Name = "ResultsListView";
            ResultsListView.Size = new Size(742, 348);
            ResultsListView.TabIndex = 2;
            ResultsListView.UseCompatibleStateImageBehavior = false;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(ResultsListView);
            Controls.Add(ResultLabel);
            Name = "ResultsForm";
            Text = "Results";
            Load += ResultsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ResultLabel;
        private ListView ResultsListView;
    }
}