namespace RDX.MH3U.Forms
{
    partial class EquipmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentForm));
            label1 = new Label();
            txtUpgrade = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cbValue = new ComboBox();
            cbSlot1 = new ComboBox();
            cbSlot2 = new ComboBox();
            cbSlot3 = new ComboBox();
            cbClass = new ComboBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "Value";
            // 
            // txtUpgrade
            // 
            txtUpgrade.Location = new Point(85, 79);
            txtUpgrade.Name = "txtUpgrade";
            txtUpgrade.Size = new Size(351, 27);
            txtUpgrade.TabIndex = 2;
            txtUpgrade.TextChanged += txtUpgrade_TextChanged;
            txtUpgrade.KeyPress += txtUpgrade_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Upgrade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 136);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 4;
            label3.Text = "Slot 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 169);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 5;
            label4.Text = "Slot 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 202);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 9;
            label5.Text = "Slot 3";
            // 
            // cbValue
            // 
            cbValue.FormattingEnabled = true;
            cbValue.Location = new Point(85, 46);
            cbValue.Name = "cbValue";
            cbValue.Size = new Size(351, 28);
            cbValue.TabIndex = 10;
            cbValue.SelectedIndexChanged += cbValue_SelectedIndexChanged;
            // 
            // cbSlot1
            // 
            cbSlot1.FormattingEnabled = true;
            cbSlot1.Location = new Point(85, 136);
            cbSlot1.Name = "cbSlot1";
            cbSlot1.Size = new Size(351, 28);
            cbSlot1.TabIndex = 11;
            cbSlot1.SelectedIndexChanged += cbSlot1_SelectedIndexChanged;
            // 
            // cbSlot2
            // 
            cbSlot2.FormattingEnabled = true;
            cbSlot2.Location = new Point(85, 170);
            cbSlot2.Name = "cbSlot2";
            cbSlot2.Size = new Size(351, 28);
            cbSlot2.TabIndex = 12;
            cbSlot2.SelectedIndexChanged += cbSlot2_SelectedIndexChanged;
            // 
            // cbSlot3
            // 
            cbSlot3.FormattingEnabled = true;
            cbSlot3.Location = new Point(85, 204);
            cbSlot3.Name = "cbSlot3";
            cbSlot3.Size = new Size(351, 28);
            cbSlot3.TabIndex = 13;
            cbSlot3.SelectedIndexChanged += cbSlot3_SelectedIndexChanged;
            // 
            // cbClass
            // 
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(85, 12);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(351, 28);
            cbClass.TabIndex = 14;
            cbClass.SelectedIndexChanged += cbClass_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 15);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 15;
            label6.Text = "Class";
            // 
            // EquipmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 450);
            Controls.Add(label6);
            Controls.Add(cbClass);
            Controls.Add(cbSlot3);
            Controls.Add(cbSlot2);
            Controls.Add(cbSlot1);
            Controls.Add(cbValue);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUpgrade);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EquipmentForm";
            Text = "MH3U Save Editor @ 2026 DanielDaix";
            FormClosing += EquipmentForm_FormClosing;
            Load += EquipmentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox txtUpgrade;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label5;
        private ComboBox cbValue;
        private ComboBox cbSlot1;
        private ComboBox cbSlot2;
        private ComboBox cbSlot3;
        private ComboBox cbClass;
        private Label label6;
    }
}