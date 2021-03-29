namespace WindowsFormsApp6
{
    partial class otherHelpIndivPresentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(otherHelpIndivPresentForm));
            this.feeTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.explainTextBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.visitPreReceiptButton = new System.Windows.Forms.Button();
            this.receiptLabel = new System.Windows.Forms.Label();
            this.receiptAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mIdTextbox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // feeTextBox
            // 
            this.feeTextBox.Enabled = false;
            this.feeTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.feeTextBox.Location = new System.Drawing.Point(278, 123);
            this.feeTextBox.Multiline = false;
            this.feeTextBox.Name = "feeTextBox";
            this.feeTextBox.ReadOnly = true;
            this.feeTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.feeTextBox.Size = new System.Drawing.Size(174, 44);
            this.feeTextBox.TabIndex = 355;
            this.feeTextBox.Text = "";
            this.feeTextBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(458, 125);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(115, 38);
            this.label3.TabIndex = 354;
            this.label3.Text = "ارزش ریالی:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(12, 462);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 352;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(12, 405);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 353;
            this.delButton.Text = "حذف";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(458, 418);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(101, 38);
            this.label2.TabIndex = 351;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox2
            // 
            this.explainTextBox2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox2.Location = new System.Drawing.Point(206, 405);
            this.explainTextBox2.Multiline = true;
            this.explainTextBox2.Name = "explainTextBox2";
            this.explainTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox2.Size = new System.Drawing.Size(246, 108);
            this.explainTextBox2.TabIndex = 350;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(60, 14);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(145, 38);
            this.label17.TabIndex = 349;
            this.label17.Text = "توضیحات قبلی:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(13, 58);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.ReadOnly = true;
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(240, 203);
            this.explainTextBox.TabIndex = 348;
            // 
            // visitPreReceiptButton
            // 
            this.visitPreReceiptButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitPreReceiptButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitPreReceiptButton.FlatAppearance.BorderSize = 2;
            this.visitPreReceiptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitPreReceiptButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitPreReceiptButton.Location = new System.Drawing.Point(426, 227);
            this.visitPreReceiptButton.Name = "visitPreReceiptButton";
            this.visitPreReceiptButton.Size = new System.Drawing.Size(141, 47);
            this.visitPreReceiptButton.TabIndex = 347;
            this.visitPreReceiptButton.Text = "مشاهده قبلی";
            this.visitPreReceiptButton.UseVisualStyleBackColor = false;
            this.visitPreReceiptButton.Visible = false;
            this.visitPreReceiptButton.Click += new System.EventHandler(this.visitPreReceiptButton_Click);
            // 
            // receiptLabel
            // 
            this.receiptLabel.BackColor = System.Drawing.Color.Red;
            this.receiptLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.receiptLabel.Location = new System.Drawing.Point(404, 200);
            this.receiptLabel.Name = "receiptLabel";
            this.receiptLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.receiptLabel.Size = new System.Drawing.Size(33, 32);
            this.receiptLabel.TabIndex = 346;
            this.receiptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // receiptAddFileButton
            // 
            this.receiptAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.receiptAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.receiptAddFileButton.FlatAppearance.BorderSize = 2;
            this.receiptAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.receiptAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.receiptAddFileButton.Location = new System.Drawing.Point(298, 192);
            this.receiptAddFileButton.Name = "receiptAddFileButton";
            this.receiptAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.receiptAddFileButton.TabIndex = 345;
            this.receiptAddFileButton.Text = "انتخاب";
            this.receiptAddFileButton.UseVisualStyleBackColor = false;
            this.receiptAddFileButton.Click += new System.EventHandler(this.receiptAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(460, 196);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(107, 38);
            this.label22.TabIndex = 344;
            this.label22.Text = "فایل رسید:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextBox.Location = new System.Drawing.Point(278, 12);
            this.idTextBox.Multiline = false;
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextBox.Size = new System.Drawing.Size(174, 44);
            this.idTextBox.TabIndex = 343;
            this.idTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(458, 14);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(121, 38);
            this.label1.TabIndex = 342;
            this.label1.Text = "شماره کمک:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mIdTextbox
            // 
            this.mIdTextbox.Enabled = false;
            this.mIdTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mIdTextbox.Location = new System.Drawing.Point(278, 69);
            this.mIdTextbox.Multiline = false;
            this.mIdTextbox.Name = "mIdTextbox";
            this.mIdTextbox.ReadOnly = true;
            this.mIdTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.mIdTextbox.Size = new System.Drawing.Size(174, 44);
            this.mIdTextbox.TabIndex = 341;
            this.mIdTextbox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(458, 71);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(109, 38);
            this.label5.TabIndex = 340;
            this.label5.Text = "شماره ملی:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // bankAccountNumberTextBox
            // 
            this.bankAccountNumberTextBox.Enabled = false;
            this.bankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNumberTextBox.Location = new System.Drawing.Point(118, 333);
            this.bankAccountNumberTextBox.Multiline = false;
            this.bankAccountNumberTextBox.Name = "bankAccountNumberTextBox";
            this.bankAccountNumberTextBox.ReadOnly = true;
            this.bankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountNumberTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountNumberTextBox.TabIndex = 359;
            this.bankAccountNumberTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(460, 335);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(132, 38);
            this.label4.TabIndex = 358;
            this.label4.Text = "شماره حساب:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankAccountNameComboBox
            // 
            this.bankAccountNameComboBox.Enabled = false;
            this.bankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNameComboBox.FormattingEnabled = true;
            this.bankAccountNameComboBox.Location = new System.Drawing.Point(118, 280);
            this.bankAccountNameComboBox.Name = "bankAccountNameComboBox";
            this.bankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bankAccountNameComboBox.Size = new System.Drawing.Size(313, 42);
            this.bankAccountNameComboBox.TabIndex = 357;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(458, 277);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(104, 38);
            this.label6.TabIndex = 356;
            this.label6.Text = "نام حساب:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // otherHelpIndivPresentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(593, 525);
            this.Controls.Add(this.bankAccountNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bankAccountNameComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.feeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.explainTextBox2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.visitPreReceiptButton);
            this.Controls.Add(this.receiptLabel);
            this.Controls.Add(this.receiptAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mIdTextbox);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "otherHelpIndivPresentForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارائه کمک متفرقه فردی";
            this.Load += new System.EventHandler(this.otherHelpIndivPresentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox feeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox explainTextBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Button visitPreReceiptButton;
        private System.Windows.Forms.Label receiptLabel;
        private System.Windows.Forms.Button receiptAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RichTextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox mIdTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.RichTextBox bankAccountNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox bankAccountNameComboBox;
        private System.Windows.Forms.Label label6;
    }
}