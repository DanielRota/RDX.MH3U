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
            cbSkill2 = new ComboBox();
            cbSkill1 = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txtPoints1 = new TextBox();
            txtPoints2 = new TextBox();
            txtSlots = new TextBox();
            label9 = new Label();
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
            txtUpgrade.Location = new Point(101, 79);
            txtUpgrade.Name = "txtUpgrade";
            txtUpgrade.Size = new Size(335, 27);
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
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 4;
            label3.Text = "Slot 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 165);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 5;
            label4.Text = "Slot 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 199);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 9;
            label5.Text = "Slot 3";
            // 
            // cbValue
            // 
            cbValue.FormattingEnabled = true;
            cbValue.Location = new Point(101, 46);
            cbValue.Name = "cbValue";
            cbValue.Size = new Size(335, 28);
            cbValue.TabIndex = 10;
            cbValue.SelectedIndexChanged += cbValue_SelectedIndexChanged;
            // 
            // cbSlot1
            // 
            cbSlot1.FormattingEnabled = true;
            cbSlot1.Location = new Point(101, 128);
            cbSlot1.Name = "cbSlot1";
            cbSlot1.Size = new Size(335, 28);
            cbSlot1.TabIndex = 11;
            cbSlot1.SelectedIndexChanged += cbSlot1_SelectedIndexChanged;
            // 
            // cbSlot2
            // 
            cbSlot2.FormattingEnabled = true;
            cbSlot2.Location = new Point(101, 162);
            cbSlot2.Name = "cbSlot2";
            cbSlot2.Size = new Size(335, 28);
            cbSlot2.TabIndex = 12;
            cbSlot2.SelectedIndexChanged += cbSlot2_SelectedIndexChanged;
            // 
            // cbSlot3
            // 
            cbSlot3.FormattingEnabled = true;
            cbSlot3.Location = new Point(101, 196);
            cbSlot3.Name = "cbSlot3";
            cbSlot3.Size = new Size(335, 28);
            cbSlot3.TabIndex = 13;
            cbSlot3.SelectedIndexChanged += cbSlot3_SelectedIndexChanged;
            // 
            // cbClass
            // 
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(101, 12);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(335, 28);
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
            // cbSkill2
            // 
            cbSkill2.FormattingEnabled = true;
            cbSkill2.Location = new Point(101, 280);
            cbSkill2.Name = "cbSkill2";
            cbSkill2.Size = new Size(206, 28);
            cbSkill2.TabIndex = 19;
            cbSkill2.SelectedIndexChanged += cbSkill2_SelectedIndexChanged;
            // 
            // cbSkill1
            // 
            cbSkill1.FormattingEnabled = true;
            cbSkill1.Location = new Point(101, 246);
            cbSkill1.Name = "cbSkill1";
            cbSkill1.Size = new Size(206, 28);
            cbSkill1.TabIndex = 18;
            cbSkill1.SelectedIndexChanged += cbSkill1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 283);
            label7.Name = "label7";
            label7.Size = new Size(48, 20);
            label7.TabIndex = 17;
            label7.Text = "Skill 2";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 249);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 16;
            label8.Text = "Skill 1";
            // 
            // txtPoints1
            // 
            txtPoints1.Location = new Point(313, 246);
            txtPoints1.MaxLength = 2;
            txtPoints1.Name = "txtPoints1";
            txtPoints1.Size = new Size(123, 27);
            txtPoints1.TabIndex = 20;
            txtPoints1.TextChanged += txtPoints1_TextChanged;
            txtPoints1.KeyPress += txtPoints1_KeyPress;
            // 
            // txtPoints2
            // 
            txtPoints2.Location = new Point(313, 280);
            txtPoints2.MaxLength = 2;
            txtPoints2.Name = "txtPoints2";
            txtPoints2.Size = new Size(123, 27);
            txtPoints2.TabIndex = 21;
            txtPoints2.TextChanged += txtPoints2_TextChanged;
            txtPoints2.KeyPress += txtPoints2_KeyPress;
            // 
            // txtSlots
            // 
            txtSlots.Location = new Point(101, 314);
            txtSlots.MaxLength = 1;
            txtSlots.Name = "txtSlots";
            txtSlots.Size = new Size(335, 27);
            txtSlots.TabIndex = 22;
            txtSlots.TextChanged += txtSlots_TextChanged;
            txtSlots.KeyPress += txtSlots_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 317);
            label9.Name = "label9";
            label9.Size = new Size(68, 20);
            label9.TabIndex = 23;
            label9.Text = "No. Slots";
            // 
            // EquipmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 496);
            Controls.Add(label9);
            Controls.Add(txtSlots);
            Controls.Add(txtPoints2);
            Controls.Add(txtPoints1);
            Controls.Add(cbSkill2);
            Controls.Add(cbSkill1);
            Controls.Add(label7);
            Controls.Add(label8);
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
            KeyDown += EquipmentForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox cbValue;
        private ComboBox cbSlot1;
        private ComboBox cbSlot2;
        private ComboBox cbSlot3;
        private ComboBox cbClass;
        private TextBox txtUpgrade;
        private ComboBox cbSkill1;
        private ComboBox cbSkill2;
        private TextBox txtPoints1;
        private TextBox txtPoints2;
        private TextBox txtSlots;
        private Label label9;
    }
}
