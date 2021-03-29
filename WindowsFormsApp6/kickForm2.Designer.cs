namespace WindowsFormsApp6
{
    partial class kickForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kickForm2));
            this.setButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.RichTextBox();
            this.searchApplicantButton = new System.Windows.Forms.Button();
            this.searchAbandonedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Gold;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(12, 93);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(173, 51);
            this.setButton.TabIndex = 32;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(208, 93);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(173, 51);
            this.searchButton.TabIndex = 31;
            this.searchButton.Text = "جستجو مددجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(235, 42);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(157, 38);
            this.editMemberLabel.TabIndex = 30;
            this.editMemberLabel.Text = "شماره ملی عضو :";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextbox
            // 
            this.idTextbox.Enabled = false;
            this.idTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextbox.Location = new System.Drawing.Point(30, 40);
            this.idTextbox.Multiline = false;
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextbox.Size = new System.Drawing.Size(199, 38);
            this.idTextbox.TabIndex = 33;
            this.idTextbox.Text = "";
            this.idTextbox.TextChanged += new System.EventHandler(this.idTextbox_TextChanged);
            this.idTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTextbox_KeyPress);
            // 
            // searchApplicantButton
            // 
            this.searchApplicantButton.BackColor = System.Drawing.Color.Orange;
            this.searchApplicantButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchApplicantButton.FlatAppearance.BorderSize = 2;
            this.searchApplicantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchApplicantButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchApplicantButton.Location = new System.Drawing.Point(208, 152);
            this.searchApplicantButton.Name = "searchApplicantButton";
            this.searchApplicantButton.Size = new System.Drawing.Size(173, 51);
            this.searchApplicantButton.TabIndex = 34;
            this.searchApplicantButton.Text = "جستجو متقاضی";
            this.searchApplicantButton.UseVisualStyleBackColor = false;
            this.searchApplicantButton.Visible = false;
            this.searchApplicantButton.Click += new System.EventHandler(this.searchApplicantButton_Click);
            // 
            // searchAbandonedButton
            // 
            this.searchAbandonedButton.BackColor = System.Drawing.Color.Orange;
            this.searchAbandonedButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchAbandonedButton.FlatAppearance.BorderSize = 2;
            this.searchAbandonedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchAbandonedButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchAbandonedButton.Location = new System.Drawing.Point(12, 150);
            this.searchAbandonedButton.Name = "searchAbandonedButton";
            this.searchAbandonedButton.Size = new System.Drawing.Size(173, 51);
            this.searchAbandonedButton.TabIndex = 35;
            this.searchAbandonedButton.Text = "جستجو معلق";
            this.searchAbandonedButton.UseVisualStyleBackColor = false;
            this.searchAbandonedButton.Visible = false;
            this.searchAbandonedButton.Click += new System.EventHandler(this.searchAbandonedButton_Click);
            // 
            // kickForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Tomato;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(395, 225);
            this.Controls.Add(this.searchAbandonedButton);
            this.Controls.Add(this.searchApplicantButton);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.editMemberLabel);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kickForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "حذف پوشش";
            this.Load += new System.EventHandler(this.kickForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.RichTextBox idTextbox;
        private System.Windows.Forms.Button searchApplicantButton;
        private System.Windows.Forms.Button searchAbandonedButton;
    }
}