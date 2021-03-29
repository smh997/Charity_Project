namespace WindowsFormsApp6
{
    partial class marryHelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(marryHelpForm));
            this.drowryButton = new System.Windows.Forms.Button();
            this.checkReqButton = new System.Windows.Forms.Button();
            this.reqButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drowryButton
            // 
            this.drowryButton.BackColor = System.Drawing.Color.Gold;
            this.drowryButton.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.drowryButton.FlatAppearance.BorderSize = 2;
            this.drowryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drowryButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.drowryButton.Location = new System.Drawing.Point(89, 132);
            this.drowryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drowryButton.Name = "drowryButton";
            this.drowryButton.Size = new System.Drawing.Size(113, 93);
            this.drowryButton.TabIndex = 198;
            this.drowryButton.Text = "پیگیری جهیزیه";
            this.drowryButton.UseVisualStyleBackColor = false;
            this.drowryButton.Click += new System.EventHandler(this.drowryButton_Click);
            // 
            // checkReqButton
            // 
            this.checkReqButton.BackColor = System.Drawing.Color.Coral;
            this.checkReqButton.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.checkReqButton.FlatAppearance.BorderSize = 2;
            this.checkReqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkReqButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkReqButton.Location = new System.Drawing.Point(149, 31);
            this.checkReqButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkReqButton.Name = "checkReqButton";
            this.checkReqButton.Size = new System.Drawing.Size(113, 93);
            this.checkReqButton.TabIndex = 196;
            this.checkReqButton.Text = "بررسی درخواست";
            this.checkReqButton.UseVisualStyleBackColor = false;
            this.checkReqButton.Click += new System.EventHandler(this.checkReqButton_Click);
            // 
            // reqButton
            // 
            this.reqButton.BackColor = System.Drawing.Color.Aquamarine;
            this.reqButton.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.reqButton.FlatAppearance.BorderSize = 2;
            this.reqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqButton.Location = new System.Drawing.Point(30, 31);
            this.reqButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reqButton.Name = "reqButton";
            this.reqButton.Size = new System.Drawing.Size(113, 93);
            this.reqButton.TabIndex = 195;
            this.reqButton.Text = "ثبت درخواست";
            this.reqButton.UseVisualStyleBackColor = false;
            this.reqButton.Click += new System.EventHandler(this.reqButton_Click);
            // 
            // marryHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(288, 259);
            this.Controls.Add(this.drowryButton);
            this.Controls.Add(this.checkReqButton);
            this.Controls.Add(this.reqButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "marryHelpForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "کمک هزینه و جهیزیه ازدواج";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.marryHelpForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.marryHelpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button drowryButton;
        private System.Windows.Forms.Button checkReqButton;
        private System.Windows.Forms.Button reqButton;
    }
}