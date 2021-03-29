namespace WindowsFormsApp6
{
    partial class checkReqForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(checkReqForm));
            this.label1 = new System.Windows.Forms.Label();
            this.fullnameTextbox = new System.Windows.Forms.TextBox();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reqFeeTextBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.reqTypeTextBox = new System.Windows.Forms.TextBox();
            this.checkDescTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.showButton = new System.Windows.Forms.Button();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.docLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(508, 41);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(166, 38);
            this.label1.TabIndex = 204;
            this.label1.Text = "نام و نام خانوادگی:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fullnameTextbox
            // 
            this.fullnameTextbox.Enabled = false;
            this.fullnameTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.fullnameTextbox.Location = new System.Drawing.Point(303, 41);
            this.fullnameTextbox.Name = "fullnameTextbox";
            this.fullnameTextbox.ReadOnly = true;
            this.fullnameTextbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fullnameTextbox.Size = new System.Drawing.Size(198, 42);
            this.fullnameTextbox.TabIndex = 203;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Enabled = false;
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(34, 71);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.ReadOnly = true;
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(223, 190);
            this.explainTextBox.TabIndex = 210;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(74, 30);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(150, 38);
            this.label3.TabIndex = 209;
            this.label3.Text = "توضیحات تقاضا:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(508, 91);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(180, 38);
            this.label2.TabIndex = 211;
            this.label2.Text = "مبلغ تقاضا(به ریال):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // reqFeeTextBox
            // 
            this.reqFeeTextBox.Enabled = false;
            this.reqFeeTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqFeeTextBox.Location = new System.Drawing.Point(304, 91);
            this.reqFeeTextBox.Name = "reqFeeTextBox";
            this.reqFeeTextBox.ReadOnly = true;
            this.reqFeeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqFeeTextBox.Size = new System.Drawing.Size(198, 42);
            this.reqFeeTextBox.TabIndex = 212;
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(34, 381);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(223, 51);
            this.setButton.TabIndex = 213;
            this.setButton.Text = "تایید";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.BackColor = System.Drawing.Color.Salmon;
            this.rejectButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.rejectButton.FlatAppearance.BorderSize = 2;
            this.rejectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rejectButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rejectButton.Location = new System.Drawing.Point(34, 438);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(223, 51);
            this.rejectButton.TabIndex = 214;
            this.rejectButton.Text = "رد";
            this.rejectButton.UseVisualStyleBackColor = false;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(508, 140);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(100, 38);
            this.label4.TabIndex = 215;
            this.label4.Text = "نوع تقاضا:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reqTypeTextBox
            // 
            this.reqTypeTextBox.Enabled = false;
            this.reqTypeTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqTypeTextBox.Location = new System.Drawing.Point(304, 140);
            this.reqTypeTextBox.Multiline = true;
            this.reqTypeTextBox.Name = "reqTypeTextBox";
            this.reqTypeTextBox.ReadOnly = true;
            this.reqTypeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqTypeTextBox.Size = new System.Drawing.Size(198, 71);
            this.reqTypeTextBox.TabIndex = 216;
            // 
            // checkDescTextBox
            // 
            this.checkDescTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkDescTextBox.Location = new System.Drawing.Point(303, 273);
            this.checkDescTextBox.Multiline = true;
            this.checkDescTextBox.Name = "checkDescTextBox";
            this.checkDescTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkDescTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.checkDescTextBox.Size = new System.Drawing.Size(204, 216);
            this.checkDescTextBox.TabIndex = 218;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(513, 340);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(161, 38);
            this.label5.TabIndex = 217;
            this.label5.Text = "توضیحات بررسی:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feeNumericUpDown
            // 
            this.feeNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.feeNumericUpDown.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.feeNumericUpDown.Location = new System.Drawing.Point(303, 217);
            this.feeNumericUpDown.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.feeNumericUpDown.Name = "feeNumericUpDown";
            this.feeNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.feeNumericUpDown.Size = new System.Drawing.Size(204, 44);
            this.feeNumericUpDown.TabIndex = 220;
            this.feeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.feeNumericUpDown.ThousandsSeparator = true;
            this.feeNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(508, 218);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(219, 38);
            this.label6.TabIndex = 219;
            this.label6.Text = "مبلغ مورد تایید(به ریال):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Aquamarine;
            this.showButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.showButton.FlatAppearance.BorderSize = 2;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showButton.Location = new System.Drawing.Point(34, 267);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(223, 51);
            this.showButton.TabIndex = 254;
            this.showButton.Text = "نمایش فایل مصوبه قبلی";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Visible = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(34, 324);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(223, 51);
            this.docAddFileButton.TabIndex = 238;
            this.docAddFileButton.Text = "مصوبه";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.Red;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(264, 334);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 239;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.docLabel.Click += new System.EventHandler(this.docLabel_Click);
            // 
            // checkReqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(745, 500);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.feeNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkDescTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reqTypeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.reqFeeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullnameTextbox);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "checkReqForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بررسی تقاضا";
            this.Load += new System.EventHandler(this.checkReqForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fullnameTextbox;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox reqFeeTextBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reqTypeTextBox;
        private System.Windows.Forms.TextBox checkDescTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label docLabel;
    }
}