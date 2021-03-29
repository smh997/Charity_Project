namespace WindowsFormsApp6
{
    partial class EditMemberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMemberForm));
            this.editMemeberButton = new System.Windows.Forms.Button();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.editMemberTextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // editMemeberButton
            // 
            this.editMemeberButton.BackColor = System.Drawing.Color.Lime;
            this.editMemeberButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.editMemeberButton.FlatAppearance.BorderSize = 2;
            this.editMemeberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editMemeberButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemeberButton.Location = new System.Drawing.Point(37, 107);
            this.editMemeberButton.Name = "editMemeberButton";
            this.editMemeberButton.Size = new System.Drawing.Size(152, 51);
            this.editMemeberButton.TabIndex = 13;
            this.editMemeberButton.Text = "ثبت";
            this.editMemeberButton.UseVisualStyleBackColor = false;
            this.editMemeberButton.Click += new System.EventHandler(this.editMemeberButton_Click);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(239, 53);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(152, 38);
            this.editMemberLabel.TabIndex = 12;
            this.editMemberLabel.Text = "شماره ملی عضو:";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(207, 107);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(152, 51);
            this.searchButton.TabIndex = 32;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // editMemberTextbox
            // 
            this.editMemberTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberTextbox.Location = new System.Drawing.Point(37, 51);
            this.editMemberTextbox.Multiline = false;
            this.editMemberTextbox.Name = "editMemberTextbox";
            this.editMemberTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.editMemberTextbox.Size = new System.Drawing.Size(199, 40);
            this.editMemberTextbox.TabIndex = 33;
            this.editMemberTextbox.Text = "";
            this.editMemberTextbox.Click += new System.EventHandler(this.editMemeberButton_Click);
            this.editMemberTextbox.TextChanged += new System.EventHandler(this.editMemberTextbox_TextChanged);
            this.editMemberTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editMemberTextbox_KeyPress);
            // 
            // EditMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(394, 206);
            this.Controls.Add(this.editMemberTextbox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.editMemeberButton);
            this.Controls.Add(this.editMemberLabel);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMemberForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش عضو";
            this.Activated += new System.EventHandler(this.EditMemberForm_Load);
            this.Load += new System.EventHandler(this.EditMemberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editMemeberButton;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RichTextBox editMemberTextbox;
    }
}