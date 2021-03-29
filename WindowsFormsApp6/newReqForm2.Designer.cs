namespace WindowsFormsApp6
{
    partial class newReqForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newReqForm2));
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.transferRadioButton = new System.Windows.Forms.RadioButton();
            this.helpeeRadioButton = new System.Windows.Forms.RadioButton();
            this.helpingRadioButton = new System.Windows.Forms.RadioButton();
            this.newWorkRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.fullnameTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.typeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.typeGroupBox.Controls.Add(this.transferRadioButton);
            this.typeGroupBox.Controls.Add(this.helpeeRadioButton);
            this.typeGroupBox.Controls.Add(this.helpingRadioButton);
            this.typeGroupBox.Controls.Add(this.newWorkRadioButton);
            this.typeGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typeGroupBox.Location = new System.Drawing.Point(287, 120);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeGroupBox.Size = new System.Drawing.Size(357, 239);
            this.typeGroupBox.TabIndex = 191;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "نوع تقاضا";
            // 
            // transferRadioButton
            // 
            this.transferRadioButton.AutoSize = true;
            this.transferRadioButton.Location = new System.Drawing.Point(186, 43);
            this.transferRadioButton.Name = "transferRadioButton";
            this.transferRadioButton.Size = new System.Drawing.Size(154, 42);
            this.transferRadioButton.TabIndex = 1;
            this.transferRadioButton.TabStop = true;
            this.transferRadioButton.Text = "واگذاری امتیاز";
            this.transferRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.transferRadioButton.UseVisualStyleBackColor = true;
            this.transferRadioButton.CheckedChanged += new System.EventHandler(this.transferRadioButton_CheckedChanged);
            // 
            // helpeeRadioButton
            // 
            this.helpeeRadioButton.AutoSize = true;
            this.helpeeRadioButton.Location = new System.Drawing.Point(30, 187);
            this.helpeeRadioButton.Name = "helpeeRadioButton";
            this.helpeeRadioButton.Size = new System.Drawing.Size(310, 42);
            this.helpeeRadioButton.TabIndex = 4;
            this.helpeeRadioButton.TabStop = true;
            this.helpeeRadioButton.Text = "دریافت امتیاز تسهیلات مددجویی";
            this.helpeeRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpeeRadioButton.UseVisualStyleBackColor = true;
            this.helpeeRadioButton.CheckedChanged += new System.EventHandler(this.newWorkRadioButton_CheckedChanged);
            // 
            // helpingRadioButton
            // 
            this.helpingRadioButton.AutoSize = true;
            this.helpingRadioButton.Location = new System.Drawing.Point(31, 139);
            this.helpingRadioButton.Name = "helpingRadioButton";
            this.helpingRadioButton.Size = new System.Drawing.Size(309, 42);
            this.helpingRadioButton.TabIndex = 3;
            this.helpingRadioButton.TabStop = true;
            this.helpingRadioButton.Text = "دریافت امتیاز تسهیلات مدد کاری";
            this.helpingRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpingRadioButton.UseVisualStyleBackColor = true;
            this.helpingRadioButton.CheckedChanged += new System.EventHandler(this.newWorkRadioButton_CheckedChanged);
            // 
            // newWorkRadioButton
            // 
            this.newWorkRadioButton.AutoSize = true;
            this.newWorkRadioButton.Location = new System.Drawing.Point(26, 91);
            this.newWorkRadioButton.Name = "newWorkRadioButton";
            this.newWorkRadioButton.Size = new System.Drawing.Size(314, 42);
            this.newWorkRadioButton.TabIndex = 2;
            this.newWorkRadioButton.TabStop = true;
            this.newWorkRadioButton.Text = "دریافت امتیاز تسهیلات کارآفرینی";
            this.newWorkRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newWorkRadioButton.UseVisualStyleBackColor = true;
            this.newWorkRadioButton.CheckedChanged += new System.EventHandler(this.newWorkRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(492, 57);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(166, 38);
            this.label1.TabIndex = 202;
            this.label1.Text = "نام و نام خانوادگی:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fullnameTextbox
            // 
            this.fullnameTextbox.Enabled = false;
            this.fullnameTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.fullnameTextbox.Location = new System.Drawing.Point(287, 57);
            this.fullnameTextbox.Name = "fullnameTextbox";
            this.fullnameTextbox.ReadOnly = true;
            this.fullnameTextbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fullnameTextbox.Size = new System.Drawing.Size(198, 42);
            this.fullnameTextbox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(478, 374);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(180, 38);
            this.label2.TabIndex = 204;
            this.label2.Text = "مبلغ تقاضا(به ریال):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(250, 449);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 205;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // feeNumericUpDown
            // 
            this.feeNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.feeNumericUpDown.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.feeNumericUpDown.Location = new System.Drawing.Point(273, 374);
            this.feeNumericUpDown.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.feeNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.feeNumericUpDown.Name = "feeNumericUpDown";
            this.feeNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.feeNumericUpDown.Size = new System.Drawing.Size(198, 39);
            this.feeNumericUpDown.TabIndex = 206;
            this.feeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.feeNumericUpDown.ThousandsSeparator = true;
            this.feeNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.feeNumericUpDown.VisibleChanged += new System.EventHandler(this.feeNumericUpDown_VisibleChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(87, 57);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(101, 38);
            this.label3.TabIndex = 207;
            this.label3.Text = "توضیحات:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(37, 120);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(204, 292);
            this.explainTextBox.TabIndex = 208;
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.DarkRed;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(454, 449);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(173, 51);
            this.delButton.TabIndex = 209;
            this.delButton.Text = "حذف";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // newReqForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(670, 512);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.feeNumericUpDown);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullnameTextbox);
            this.Controls.Add(this.typeGroupBox);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newReqForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تقاضا جدید";
            this.Load += new System.EventHandler(this.newReqForm2_Load);
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton transferRadioButton;
        private System.Windows.Forms.RadioButton helpeeRadioButton;
        private System.Windows.Forms.RadioButton helpingRadioButton;
        private System.Windows.Forms.RadioButton newWorkRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fullnameTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Button delButton;
    }
}