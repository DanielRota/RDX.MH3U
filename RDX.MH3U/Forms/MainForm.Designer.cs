namespace RDX.MH3U
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnLoad = new Button();
            txtName = new TextBox();
            txtZenny = new TextBox();
            txtPoints = new TextBox();
            lblName = new Label();
            lblZenny = new Label();
            lblPoints = new Label();
            btnOpenEquipBox = new Button();
            btnOpenItemsChest = new Button();
            btnOpenItemsPouch = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            rdbFemale = new RadioButton();
            rdbMale = new RadioButton();
            groupBox2 = new GroupBox();
            label2 = new Label();
            lblPath = new Label();
            cbBackup = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 234);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(203, 53);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Select File";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(98, 33);
            txtName.MaxLength = 10;
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtZenny
            // 
            txtZenny.Location = new Point(98, 66);
            txtZenny.MaxLength = 8;
            txtZenny.Name = "txtZenny";
            txtZenny.Size = new Size(125, 27);
            txtZenny.TabIndex = 2;
            txtZenny.TextChanged += txtZenny_TextChanged;
            // 
            // txtPoints
            // 
            txtPoints.Location = new Point(98, 99);
            txtPoints.MaxLength = 8;
            txtPoints.Name = "txtPoints";
            txtPoints.Size = new Size(125, 27);
            txtPoints.TabIndex = 3;
            txtPoints.TextChanged += txtPoints_TextChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblZenny
            // 
            lblZenny.AutoSize = true;
            lblZenny.Location = new Point(20, 69);
            lblZenny.Name = "lblZenny";
            lblZenny.Size = new Size(49, 20);
            lblZenny.TabIndex = 5;
            lblZenny.Text = "Zenny";
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Location = new Point(20, 102);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(48, 20);
            lblPoints.TabIndex = 6;
            lblPoints.Text = "Points";
            // 
            // btnOpenEquipBox
            // 
            btnOpenEquipBox.Location = new Point(44, 65);
            btnOpenEquipBox.Name = "btnOpenEquipBox";
            btnOpenEquipBox.Size = new Size(139, 93);
            btnOpenEquipBox.TabIndex = 7;
            btnOpenEquipBox.Text = "Equipment Box";
            btnOpenEquipBox.UseVisualStyleBackColor = true;
            btnOpenEquipBox.Click += btnOpenEquipBox_Click;
            // 
            // btnOpenItemsChest
            // 
            btnOpenItemsChest.Location = new Point(189, 65);
            btnOpenItemsChest.Name = "btnOpenItemsChest";
            btnOpenItemsChest.Size = new Size(139, 93);
            btnOpenItemsChest.TabIndex = 8;
            btnOpenItemsChest.Text = "Items Chest";
            btnOpenItemsChest.UseVisualStyleBackColor = true;
            btnOpenItemsChest.Click += btnOpenItemsChest_Click;
            // 
            // btnOpenItemsPouch
            // 
            btnOpenItemsPouch.Enabled = false;
            btnOpenItemsPouch.Location = new Point(334, 65);
            btnOpenItemsPouch.Name = "btnOpenItemsPouch";
            btnOpenItemsPouch.Size = new Size(139, 93);
            btnOpenItemsPouch.TabIndex = 9;
            btnOpenItemsPouch.Text = "Items Pouch";
            btnOpenItemsPouch.UseVisualStyleBackColor = true;
            btnOpenItemsPouch.Click += btnOpenItemsPouch_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(585, 234);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(203, 53);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(rdbFemale);
            groupBox1.Controls.Add(rdbMale);
            groupBox1.Controls.Add(txtPoints);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtZenny);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(lblZenny);
            groupBox1.Controls.Add(lblPoints);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(254, 216);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Character";
            groupBox1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 156);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 9;
            label1.Text = "Gender";
            // 
            // rdbFemale
            // 
            rdbFemale.AutoSize = true;
            rdbFemale.Location = new Point(98, 169);
            rdbFemale.Name = "rdbFemale";
            rdbFemale.Size = new Size(78, 24);
            rdbFemale.TabIndex = 8;
            rdbFemale.TabStop = true;
            rdbFemale.Text = "Female";
            rdbFemale.UseVisualStyleBackColor = true;
            rdbFemale.CheckedChanged += rdbFemale_CheckedChanged;
            // 
            // rdbMale
            // 
            rdbMale.AutoSize = true;
            rdbMale.Location = new Point(98, 139);
            rdbMale.Name = "rdbMale";
            rdbMale.Size = new Size(63, 24);
            rdbMale.TabIndex = 7;
            rdbMale.TabStop = true;
            rdbMale.Text = "Male";
            rdbMale.UseVisualStyleBackColor = true;
            rdbMale.CheckedChanged += rdbMale_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnOpenEquipBox);
            groupBox2.Controls.Add(btnOpenItemsChest);
            groupBox2.Controls.Add(btnOpenItemsPouch);
            groupBox2.Location = new Point(272, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(516, 215);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Boxes";
            groupBox2.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 300);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 14;
            label2.Text = "Path:";
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(58, 300);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(15, 20);
            lblPath.TabIndex = 15;
            lblPath.Text = "-";
            // 
            // cbBackup
            // 
            cbBackup.AutoSize = true;
            cbBackup.Location = new Point(709, 300);
            cbBackup.Name = "cbBackup";
            cbBackup.Size = new Size(79, 24);
            cbBackup.TabIndex = 16;
            cbBackup.Text = "Backup";
            cbBackup.UseVisualStyleBackColor = true;
            cbBackup.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 338);
            Controls.Add(cbBackup);
            Controls.Add(lblPath);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MH3U Save Editor @ 2026 DanielDaix | Ver. 0.0";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private TextBox txtName;
        private TextBox txtZenny;
        private TextBox txtPoints;
        private Label lblName;
        private Label lblZenny;
        private Label lblPoints;
        private Button btnOpenEquipBox;
        private Button btnOpenItemsChest;
        private Button btnOpenItemsPouch;
        private Button btnSave;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private RadioButton rdbFemale;
        private RadioButton rdbMale;
        private Label label2;
        private Label lblPath;
        private CheckBox cbBackup;
    }
}
