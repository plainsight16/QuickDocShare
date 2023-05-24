namespace SearchEngineGUI
{
    partial class HomeForm
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
            ButtonUpload = new Button();
            ButtonSearch = new Button();
            TextBoxQuery = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(291, 30);
            label1.Name = "label1";
            label1.Size = new Size(235, 37);
            label1.TabIndex = 0;
            label1.Text = "SEARCH ENGINE";
            // 
            // ButtonUpload
            // 
            ButtonUpload.Location = new Point(284, 342);
            ButtonUpload.Name = "ButtonUpload";
            ButtonUpload.Size = new Size(242, 41);
            ButtonUpload.TabIndex = 1;
            ButtonUpload.Text = "Upload Document";
            ButtonUpload.UseVisualStyleBackColor = true;
            ButtonUpload.Click += ButtonUpload_Click;
            // 
            // ButtonSearch
            // 
            ButtonSearch.BackColor = Color.Black;
            ButtonSearch.FlatAppearance.BorderSize = 0;
            ButtonSearch.FlatStyle = FlatStyle.Flat;
            ButtonSearch.ForeColor = Color.White;
            ButtonSearch.Location = new Point(284, 201);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(242, 41);
            ButtonSearch.TabIndex = 2;
            ButtonSearch.Text = "Search";
            ButtonSearch.UseVisualStyleBackColor = false;
            ButtonSearch.Click += ButtonSearch_Click;
            // 
            // TextBoxQuery
            // 
            TextBoxQuery.BorderStyle = BorderStyle.FixedSingle;
            TextBoxQuery.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxQuery.Location = new Point(284, 149);
            TextBoxQuery.Name = "TextBoxQuery";
            TextBoxQuery.Size = new Size(242, 36);
            TextBoxQuery.TabIndex = 3;
            TextBoxQuery.Text = "Enter Search Query";
            TextBoxQuery.TextAlign = HorizontalAlignment.Center;
            TextBoxQuery.TextChanged += TextBoxQuery_TextChanged;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(TextBoxQuery);
            Controls.Add(ButtonSearch);
            Controls.Add(ButtonUpload);
            Controls.Add(label1);
            MinimumSize = new Size(0, 150);
            Name = "HomeForm";
            Text = "Search Engine";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ButtonUpload;
        private Button ButtonSearch;
        private TextBox TextBoxQuery;
    }
}