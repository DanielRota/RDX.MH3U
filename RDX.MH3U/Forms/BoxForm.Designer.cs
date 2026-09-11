namespace RDX.MH3U
{
    partial class BoxFormBase
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxFormBase));
            btnPreviousPage = new Button();
            btnNextPage = new Button();
            lblPage = new Label();
            table = new TableLayoutPanel();
            SuspendLayout();
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Enabled = false;
            btnPreviousPage.Location = new Point(363, 12);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(36, 29);
            btnPreviousPage.TabIndex = 1;
            btnPreviousPage.Text = "←";
            btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(405, 12);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(36, 29);
            btnNextPage.TabIndex = 2;
            btnNextPage.Text = "→";
            btnNextPage.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(12, 16);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(150, 20);
            lblPage.TabIndex = 3;
            lblPage.Text = "Page 1 / No. of Pages";
            // 
            // table
            // 
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.2577324F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.7422676F));
            table.Location = new Point(12, 47);
            table.Name = "table";
            table.RowCount = 2;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.Size = new Size(776, 600);
            table.TabIndex = 4;
            // 
            // BoxFormBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 659);
            Controls.Add(table);
            Controls.Add(lblPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnPreviousPage);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BoxFormBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MH3U Save Editor @ 2026 DanielDaix";
            KeyDown += BoxFormBase_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button btnPreviousPage;
        protected Button btnNextPage;
        protected Label lblPage;
        protected TableLayoutPanel table;
    }
}