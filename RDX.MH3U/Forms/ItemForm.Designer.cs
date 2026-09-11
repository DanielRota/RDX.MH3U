namespace RDX.MH3U.Forms
{
    partial class ItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemForm));
            label1 = new Label();
            label2 = new Label();
            txtCount = new TextBox();
            cbValue = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Count";
            // 
            // txtCount
            // 
            txtCount.Location = new Point(68, 42);
            txtCount.MaxLength = 2;
            txtCount.Name = "txtCount";
            txtCount.Size = new Size(347, 27);
            txtCount.TabIndex = 3;
            txtCount.TextChanged += txtCount_TextChanged;
            // 
            // cbValue
            // 
            cbValue.FormattingEnabled = true;
            cbValue.Location = new Point(68, 9);
            cbValue.Name = "cbValue";
            cbValue.Size = new Size(347, 28);
            cbValue.TabIndex = 4;
            cbValue.SelectedIndexChanged += cbValue_SelectedIndexChanged;
            // 
            // ItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 229);
            Controls.Add(cbValue);
            Controls.Add(txtCount);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ItemForm";
            Text = "MH3U Save Editor @ 2026 DanielDaix";
            FormClosing += ItemForm_FormClosing;
            Load += ItemForm_Load;
            KeyDown += ItemForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox txtCount;
        private ComboBox cbValue;
    }
}