namespace WindowsFormsApp6
{
    partial class comebackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comebackForm));
            this.searchButton = new System.Windows.Forms.Button();
            this.comebackButton = new System.Windows.Forms.Button();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.comebackTextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(193, 103);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(173, 51);
            this.searchButton.TabIndex = 36;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click_1);
            // 
            // comebackButton
            // 
            this.comebackButton.BackColor = System.Drawing.Color.Lime;
            this.comebackButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.comebackButton.FlatAppearance.BorderSize = 2;
            this.comebackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comebackButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comebackButton.Location = new System.Drawing.Point(14, 103);
            this.comebackButton.Name = "comebackButton";
            this.comebackButton.Size = new System.Drawing.Size(173, 51);
            this.comebackButton.TabIndex = 35;
            this.comebackButton.Text = "ثبت";
            this.comebackButton.UseVisualStyleBackColor = false;
            this.comebackButton.Click += new System.EventHandler(this.comebackButton_Click);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(214, 46);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(152, 38);
            this.editMemberLabel.TabIndex = 34;
            this.editMemberLabel.Text = "شماره ملی عضو:";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comebackTextbox
            // 
            this.comebackTextbox.Enabled = false;
            this.comebackTextbox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comebackTextbox.Location = new System.Drawing.Point(12, 46);
            this.comebackTextbox.Multiline = false;
            this.comebackTextbox.Name = "comebackTextbox";
            this.comebackTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.comebackTextbox.Size = new System.Drawing.Size(199, 38);
            this.comebackTextbox.TabIndex = 37;
            this.comebackTextbox.Text = "";
            this.comebackTextbox.Click += new System.EventHandler(this.comebackButton_Click);
            this.comebackTextbox.TextChanged += new System.EventHandler(this.comebackTextbox_TextChanged);
            this.comebackTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comebackTextbox_KeyPress);
            // 
            // comebackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(378, 191);
            this.Controls.Add(this.comebackTextbox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.comebackButton);
            this.Controls.Add(this.editMemberLabel);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "comebackForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "رجعت عضو";
            this.Load += new System.EventHandler(this.comebackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button comebackButton;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.RichTextBox comebackTextbox;
    }
}