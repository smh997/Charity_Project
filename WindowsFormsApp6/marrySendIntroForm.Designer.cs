namespace WindowsFormsApp6
{
    partial class marrySendIntroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(marrySendIntroForm));
            this.idTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.visitDocsButton = new System.Windows.Forms.Button();
            this.visitFormButton = new System.Windows.Forms.Button();
            this.visitEnactmentButton = new System.Windows.Forms.Button();
            this.introLabel = new System.Windows.Forms.Label();
            this.introAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.explainTextBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.visitPreIntroButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextBox.Location = new System.Drawing.Point(276, 20);
            this.idTextBox.Multiline = false;
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextBox.Size = new System.Drawing.Size(174, 44);
            this.idTextBox.TabIndex = 278;
            this.idTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(456, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(121, 38);
            this.label1.TabIndex = 277;
            this.label1.Text = "شماره کمک:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // visitDocsButton
            // 
            this.visitDocsButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitDocsButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitDocsButton.FlatAppearance.BorderSize = 2;
            this.visitDocsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitDocsButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitDocsButton.Location = new System.Drawing.Point(211, 180);
            this.visitDocsButton.Name = "visitDocsButton";
            this.visitDocsButton.Size = new System.Drawing.Size(174, 94);
            this.visitDocsButton.TabIndex = 286;
            this.visitDocsButton.Text = "مشاهده مدارک ازدواج";
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
            this.visitFormButton.Location = new System.Drawing.Point(396, 180);
            this.visitFormButton.Name = "visitFormButton";
            this.visitFormButton.Size = new System.Drawing.Size(174, 94);
            this.visitFormButton.TabIndex = 285;
            this.visitFormButton.Text = "مشاهده فرم درخواست";
            this.visitFormButton.UseVisualStyleBackColor = false;
            this.visitFormButton.Click += new System.EventHandler(this.visitFormButton_Click);
            // 
            // visitEnactmentButton
            // 
            this.visitEnactmentButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitEnactmentButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitEnactmentButton.FlatAppearance.BorderSize = 2;
            this.visitEnactmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitEnactmentButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitEnactmentButton.Location = new System.Drawing.Point(22, 180);
            this.visitEnactmentButton.Name = "visitEnactmentButton";
            this.visitEnactmentButton.Size = new System.Drawing.Size(174, 94);
            this.visitEnactmentButton.TabIndex = 287;
            this.visitEnactmentButton.Text = "مشاهده مصوبه";
            this.visitEnactmentButton.UseVisualStyleBackColor = false;
            this.visitEnactmentButton.Click += new System.EventHandler(this.visitEnactmentButton_Click);
            // 
            // introLabel
            // 
            this.introLabel.BackColor = System.Drawing.Color.Red;
            this.introLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.introLabel.Location = new System.Drawing.Point(400, 102);
            this.introLabel.Name = "introLabel";
            this.introLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.introLabel.Size = new System.Drawing.Size(33, 32);
            this.introLabel.TabIndex = 290;
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // introAddFileButton
            // 
            this.introAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.introAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.introAddFileButton.FlatAppearance.BorderSize = 2;
            this.introAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.introAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.introAddFileButton.Location = new System.Drawing.Point(294, 94);
            this.introAddFileButton.Name = "introAddFileButton";
            this.introAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.introAddFileButton.TabIndex = 289;
            this.introAddFileButton.Text = "انتخاب";
            this.introAddFileButton.UseVisualStyleBackColor = false;
            this.introAddFileButton.Click += new System.EventHandler(this.introAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(438, 98);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(139, 38);
            this.label22.TabIndex = 288;
            this.label22.Text = "فرم معرفی‌نامه:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(476, 299);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(101, 38);
            this.label2.TabIndex = 295;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox2
            // 
            this.explainTextBox2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox2.Location = new System.Drawing.Point(211, 286);
            this.explainTextBox2.Multiline = true;
            this.explainTextBox2.Name = "explainTextBox2";
            this.explainTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox2.Size = new System.Drawing.Size(259, 108);
            this.explainTextBox2.TabIndex = 294;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(69, 22);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(145, 38);
            this.label17.TabIndex = 293;
            this.label17.Text = "توضیحات قبلی:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(22, 66);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.ReadOnly = true;
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(240, 103);
            this.explainTextBox.TabIndex = 292;
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(22, 286);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 297;
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
            this.setButton.Location = new System.Drawing.Point(22, 343);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 296;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // visitPreIntroButton
            // 
            this.visitPreIntroButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitPreIntroButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.visitPreIntroButton.FlatAppearance.BorderSize = 2;
            this.visitPreIntroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitPreIntroButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitPreIntroButton.Location = new System.Drawing.Point(429, 127);
            this.visitPreIntroButton.Name = "visitPreIntroButton";
            this.visitPreIntroButton.Size = new System.Drawing.Size(141, 47);
            this.visitPreIntroButton.TabIndex = 298;
            this.visitPreIntroButton.Text = "مشاهده قبلی";
            this.visitPreIntroButton.UseVisualStyleBackColor = false;
            this.visitPreIntroButton.Visible = false;
            this.visitPreIntroButton.Click += new System.EventHandler(this.visitPreIntroButton_Click);
            // 
            // marrySendIntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(593, 413);
            this.Controls.Add(this.visitPreIntroButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.explainTextBox2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.introAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.visitEnactmentButton);
            this.Controls.Add(this.visitDocsButton);
            this.Controls.Add(this.visitFormButton);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "marrySendIntroForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارسال معرفی‌نامه جهیزیه";
            this.Load += new System.EventHandler(this.marrySendIntroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button visitDocsButton;
        private System.Windows.Forms.Button visitFormButton;
        private System.Windows.Forms.Button visitEnactmentButton;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.Button introAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox explainTextBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button visitPreIntroButton;
    }
}