﻿namespace WindowsFormsApp6
{
    partial class healHelpCheckReqForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(healHelpCheckReqForm));
            this.label2 = new System.Windows.Forms.Label();
            this.explainTextBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.denyButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.visitDocsButton = new System.Windows.Forms.Button();
            this.visitFormButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.rIdTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mIdTextbox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(443, 245);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(101, 38);
            this.label2.TabIndex = 311;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox2
            // 
            this.explainTextBox2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox2.Location = new System.Drawing.Point(203, 220);
            this.explainTextBox2.Multiline = true;
            this.explainTextBox2.Name = "explainTextBox2";
            this.explainTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox2.Size = new System.Drawing.Size(234, 128);
            this.explainTextBox2.TabIndex = 310;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(9, 173);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(188, 38);
            this.label17.TabIndex = 309;
            this.label17.Text = "توضیحات درخواست:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(9, 220);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.ReadOnly = true;
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(188, 128);
            this.explainTextBox.TabIndex = 308;
            // 
            // denyButton
            // 
            this.denyButton.BackColor = System.Drawing.Color.Firebrick;
            this.denyButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkMagenta;
            this.denyButton.FlatAppearance.BorderSize = 2;
            this.denyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.denyButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.denyButton.Location = new System.Drawing.Point(192, 411);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(174, 51);
            this.denyButton.TabIndex = 307;
            this.denyButton.Text = "رد درخواست";
            this.denyButton.UseVisualStyleBackColor = false;
            this.denyButton.Click += new System.EventHandler(this.denyButton_Click);
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(192, 411);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 306;
            this.delButton.Text = "حذف";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(12, 411);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 305;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // visitDocsButton
            // 
            this.visitDocsButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitDocsButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitDocsButton.FlatAppearance.BorderSize = 2;
            this.visitDocsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitDocsButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitDocsButton.Location = new System.Drawing.Point(12, 354);
            this.visitDocsButton.Name = "visitDocsButton";
            this.visitDocsButton.Size = new System.Drawing.Size(174, 51);
            this.visitDocsButton.TabIndex = 304;
            this.visitDocsButton.Text = "مشاهده مدارک";
            this.visitDocsButton.UseVisualStyleBackColor = false;
            this.visitDocsButton.Click += new System.EventHandler(this.visitDocsButton_Click);
            // 
            // visitFormButton
            // 
            this.visitFormButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitFormButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitFormButton.FlatAppearance.BorderSize = 2;
            this.visitFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitFormButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitFormButton.Location = new System.Drawing.Point(192, 354);
            this.visitFormButton.Name = "visitFormButton";
            this.visitFormButton.Size = new System.Drawing.Size(174, 51);
            this.visitFormButton.TabIndex = 303;
            this.visitFormButton.Text = "مشاهده فرم";
            this.visitFormButton.UseVisualStyleBackColor = false;
            this.visitFormButton.Click += new System.EventHandler(this.visitFormButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(23, 115);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 51);
            this.searchButton.TabIndex = 302;
            this.searchButton.Text = "جستجو مصوبه";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(205, 119);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 44);
            this.enactmentTextbox.TabIndex = 301;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(385, 121);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 300;
            this.label8.Text = "شماره مصوبه:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feeNumericUpDown
            // 
            this.feeNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.feeNumericUpDown.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.feeNumericUpDown.Location = new System.Drawing.Point(205, 170);
            this.feeNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.feeNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.feeNumericUpDown.Name = "feeNumericUpDown";
            this.feeNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.feeNumericUpDown.Size = new System.Drawing.Size(174, 44);
            this.feeNumericUpDown.TabIndex = 299;
            this.feeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.feeNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label23.Location = new System.Drawing.Point(385, 171);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(115, 38);
            this.label23.TabIndex = 298;
            this.label23.Text = "ارزش ریالی:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rIdTextBox
            // 
            this.rIdTextBox.Enabled = false;
            this.rIdTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rIdTextBox.Location = new System.Drawing.Point(205, 18);
            this.rIdTextBox.Multiline = false;
            this.rIdTextBox.Name = "rIdTextBox";
            this.rIdTextBox.ReadOnly = true;
            this.rIdTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rIdTextBox.Size = new System.Drawing.Size(174, 44);
            this.rIdTextBox.TabIndex = 297;
            this.rIdTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(385, 20);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(159, 38);
            this.label1.TabIndex = 296;
            this.label1.Text = "شماره درخواست:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mIdTextbox
            // 
            this.mIdTextbox.Enabled = false;
            this.mIdTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mIdTextbox.Location = new System.Drawing.Point(205, 69);
            this.mIdTextbox.Multiline = false;
            this.mIdTextbox.Name = "mIdTextbox";
            this.mIdTextbox.ReadOnly = true;
            this.mIdTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.mIdTextbox.Size = new System.Drawing.Size(174, 44);
            this.mIdTextbox.TabIndex = 295;
            this.mIdTextbox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(385, 71);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(109, 38);
            this.label5.TabIndex = 294;
            this.label5.Text = "شماره ملی:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // healHelpCheckReqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gold;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(546, 476);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.explainTextBox2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.visitDocsButton);
            this.Controls.Add(this.visitFormButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.feeNumericUpDown);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.rIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mIdTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.denyButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "healHelpCheckReqForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بررسی درخواست کمک درمان";
            this.Load += new System.EventHandler(this.healHelpCheckReqForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox explainTextBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Button denyButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button visitDocsButton;
        private System.Windows.Forms.Button visitFormButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RichTextBox rIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox mIdTextbox;
        private System.Windows.Forms.Label label5;
    }
}