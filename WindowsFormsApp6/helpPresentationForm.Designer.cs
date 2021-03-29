namespace WindowsFormsApp6
{
    partial class helpPresentationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpPresentationForm));
            this.indivButton = new System.Windows.Forms.Button();
            this.globalButton = new System.Windows.Forms.Button();
            this.otherHelpButton = new System.Windows.Forms.Button();
            this.otherHelpIndivButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // indivButton
            // 
            this.indivButton.BackColor = System.Drawing.Color.Chartreuse;
            this.indivButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.indivButton.FlatAppearance.BorderSize = 2;
            this.indivButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indivButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.indivButton.Location = new System.Drawing.Point(179, 26);
            this.indivButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.indivButton.Name = "indivButton";
            this.indivButton.Size = new System.Drawing.Size(158, 76);
            this.indivButton.TabIndex = 13;
            this.indivButton.Text = "ویژه";
            this.indivButton.UseVisualStyleBackColor = false;
            this.indivButton.Click += new System.EventHandler(this.indivButton_Click);
            // 
            // globalButton
            // 
            this.globalButton.BackColor = System.Drawing.Color.YellowGreen;
            this.globalButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.globalButton.FlatAppearance.BorderSize = 2;
            this.globalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.globalButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.globalButton.Location = new System.Drawing.Point(12, 26);
            this.globalButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.globalButton.Name = "globalButton";
            this.globalButton.Size = new System.Drawing.Size(161, 76);
            this.globalButton.TabIndex = 14;
            this.globalButton.Text = "جمعی";
            this.globalButton.UseVisualStyleBackColor = false;
            this.globalButton.Click += new System.EventHandler(this.globalButton_Click);
            // 
            // otherHelpButton
            // 
            this.otherHelpButton.BackColor = System.Drawing.Color.Khaki;
            this.otherHelpButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.otherHelpButton.FlatAppearance.BorderSize = 2;
            this.otherHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otherHelpButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.otherHelpButton.Location = new System.Drawing.Point(12, 119);
            this.otherHelpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.otherHelpButton.Name = "otherHelpButton";
            this.otherHelpButton.Size = new System.Drawing.Size(161, 76);
            this.otherHelpButton.TabIndex = 20;
            this.otherHelpButton.Text = "متفرقه گروهی";
            this.otherHelpButton.UseVisualStyleBackColor = false;
            this.otherHelpButton.Click += new System.EventHandler(this.otherHelpButton_Click);
            // 
            // otherHelpIndivButton
            // 
            this.otherHelpIndivButton.BackColor = System.Drawing.Color.DarkOrange;
            this.otherHelpIndivButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.otherHelpIndivButton.FlatAppearance.BorderSize = 2;
            this.otherHelpIndivButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otherHelpIndivButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.otherHelpIndivButton.Location = new System.Drawing.Point(179, 119);
            this.otherHelpIndivButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.otherHelpIndivButton.Name = "otherHelpIndivButton";
            this.otherHelpIndivButton.Size = new System.Drawing.Size(161, 76);
            this.otherHelpIndivButton.TabIndex = 21;
            this.otherHelpIndivButton.Text = "متفرقه فردی";
            this.otherHelpIndivButton.UseVisualStyleBackColor = false;
            this.otherHelpIndivButton.Click += new System.EventHandler(this.otherHelpIndivButton_Click);
            // 
            // helpPresentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(349, 225);
            this.Controls.Add(this.otherHelpIndivButton);
            this.Controls.Add(this.otherHelpButton);
            this.Controls.Add(this.globalButton);
            this.Controls.Add(this.indivButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "helpPresentationForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارائه کمک";
            this.Load += new System.EventHandler(this.helpPresentationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button indivButton;
        private System.Windows.Forms.Button globalButton;
        private System.Windows.Forms.Button otherHelpButton;
        private System.Windows.Forms.Button otherHelpIndivButton;
    }
}