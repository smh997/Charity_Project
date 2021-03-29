namespace WindowsFormsApp6
{
    partial class reportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportForm));
            this.reqButton = new System.Windows.Forms.Button();
            this.helpFamilyButton = new System.Windows.Forms.Button();
            this.helpMemberButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reqButton
            // 
            this.reqButton.BackColor = System.Drawing.Color.Aquamarine;
            this.reqButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.reqButton.FlatAppearance.BorderSize = 2;
            this.reqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqButton.Location = new System.Drawing.Point(130, 12);
            this.reqButton.Name = "reqButton";
            this.reqButton.Size = new System.Drawing.Size(194, 90);
            this.reqButton.TabIndex = 285;
            this.reqButton.Text = "تقاضا‌های متقاضی";
            this.reqButton.UseVisualStyleBackColor = false;
            this.reqButton.Click += new System.EventHandler(this.reqButton_Click);
            // 
            // helpFamilyButton
            // 
            this.helpFamilyButton.BackColor = System.Drawing.Color.Aquamarine;
            this.helpFamilyButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.helpFamilyButton.FlatAppearance.BorderSize = 2;
            this.helpFamilyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpFamilyButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helpFamilyButton.Location = new System.Drawing.Point(232, 108);
            this.helpFamilyButton.Name = "helpFamilyButton";
            this.helpFamilyButton.Size = new System.Drawing.Size(194, 90);
            this.helpFamilyButton.TabIndex = 286;
            this.helpFamilyButton.Text = "کمک‌های داده شده (خانوار)";
            this.helpFamilyButton.UseVisualStyleBackColor = false;
            this.helpFamilyButton.Click += new System.EventHandler(this.helpFamilyButton_Click);
            // 
            // helpMemberButton
            // 
            this.helpMemberButton.BackColor = System.Drawing.Color.Aquamarine;
            this.helpMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.helpMemberButton.FlatAppearance.BorderSize = 2;
            this.helpMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpMemberButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helpMemberButton.Location = new System.Drawing.Point(32, 108);
            this.helpMemberButton.Name = "helpMemberButton";
            this.helpMemberButton.Size = new System.Drawing.Size(194, 90);
            this.helpMemberButton.TabIndex = 287;
            this.helpMemberButton.Text = "کمک‌های داده شده (مددجو)";
            this.helpMemberButton.UseVisualStyleBackColor = false;
            this.helpMemberButton.Click += new System.EventHandler(this.helpMemberButton_Click);
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(458, 207);
            this.Controls.Add(this.helpMemberButton);
            this.Controls.Add(this.helpFamilyButton);
            this.Controls.Add(this.reqButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reportForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گزارشات";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reqButton;
        private System.Windows.Forms.Button helpFamilyButton;
        private System.Windows.Forms.Button helpMemberButton;
    }
}