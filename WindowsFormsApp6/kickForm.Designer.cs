namespace WindowsFormsApp6
{
    partial class kickForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kickForm));
            this.deletememberButton = new System.Windows.Forms.Button();
            this.deletefamilyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deletememberButton
            // 
            this.deletememberButton.BackColor = System.Drawing.Color.Orange;
            this.deletememberButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.deletememberButton.FlatAppearance.BorderSize = 2;
            this.deletememberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletememberButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deletememberButton.Location = new System.Drawing.Point(39, 52);
            this.deletememberButton.Name = "deletememberButton";
            this.deletememberButton.Size = new System.Drawing.Size(113, 91);
            this.deletememberButton.TabIndex = 28;
            this.deletememberButton.Text = "فردی";
            this.deletememberButton.UseVisualStyleBackColor = false;
            this.deletememberButton.Click += new System.EventHandler(this.deletememberButton_Click);
            // 
            // deletefamilyButton
            // 
            this.deletefamilyButton.BackColor = System.Drawing.Color.Gold;
            this.deletefamilyButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.deletefamilyButton.FlatAppearance.BorderSize = 2;
            this.deletefamilyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletefamilyButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deletefamilyButton.Location = new System.Drawing.Point(209, 52);
            this.deletefamilyButton.Name = "deletefamilyButton";
            this.deletefamilyButton.Size = new System.Drawing.Size(113, 91);
            this.deletefamilyButton.TabIndex = 29;
            this.deletefamilyButton.Text = "خانواری";
            this.deletefamilyButton.UseVisualStyleBackColor = false;
            this.deletefamilyButton.Click += new System.EventHandler(this.deletefamilyButton_Click);
            // 
            // kickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Tomato;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(378, 191);
            this.Controls.Add(this.deletefamilyButton);
            this.Controls.Add(this.deletememberButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kickForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "حذف پوشش";
            this.Load += new System.EventHandler(this.kickForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deletememberButton;
        private System.Windows.Forms.Button deletefamilyButton;
    }
}