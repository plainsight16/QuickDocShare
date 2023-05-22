namespace SearchEngineGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            ButtonSearch = new Button();
            TextBoxQuery = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(363, 39);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "SEARCH ENGINE";
            // 
            // button1
            // 
            button1.Location = new Point(291, 365);
            button1.Name = "button1";
            button1.Size = new Size(242, 41);
            button1.TabIndex = 1;
            button1.Text = "Upload Document";
            button1.UseVisualStyleBackColor = true;
            // 
            // ButtonSearch
            // 
            ButtonSearch.Location = new Point(291, 173);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(242, 41);
            ButtonSearch.TabIndex = 2;
            ButtonSearch.Text = "Search";
            ButtonSearch.UseVisualStyleBackColor = true;
            ButtonSearch.Click += ButtonSearch_Click;
            // 
            // TextBoxQuery
            // 
            TextBoxQuery.Location = new Point(291, 122);
            TextBoxQuery.Name = "TextBoxQuery";
            TextBoxQuery.Size = new Size(242, 23);
            TextBoxQuery.TabIndex = 3;
            TextBoxQuery.Text = "Enter Search Query";
            TextBoxQuery.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextBoxQuery);
            Controls.Add(ButtonSearch);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button ButtonSearch;
        private TextBox TextBoxQuery;
    }
}