namespace WindowsFormsApp6
{
    partial class otherHelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(otherHelpForm));
            this.globalButton = new System.Windows.Forms.Button();
            this.indivButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // globalButton
            // 
            this.globalButton.BackColor = System.Drawing.Color.DarkSalmon;
            this.globalButton.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.globalButton.FlatAppearance.BorderSize = 2;
            this.globalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.globalButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.globalButton.Location = new System.Drawing.Point(23, 67);
            this.globalButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.globalButton.Name = "globalButton";
            this.globalButton.Size = new System.Drawing.Size(109, 70);
            this.globalButton.TabIndex = 16;
            this.globalButton.Text = "گروهی";
            this.globalButton.UseVisualStyleBackColor = false;
            this.globalButton.Click += new System.EventHandler(this.globalButton_Click);
            // 
            // indivButton
            // 
            this.indivButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.indivButton.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.indivButton.FlatAppearance.BorderSize = 2;
            this.indivButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indivButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.indivButton.Location = new System.Drawing.Point(155, 67);
            this.indivButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.indivButton.Name = "indivButton";
            this.indivButton.Size = new System.Drawing.Size(111, 70);
            this.indivButton.TabIndex = 15;
            this.indivButton.Text = "فردی";
            this.indivButton.UseVisualStyleBackColor = false;
            this.indivButton.Click += new System.EventHandler(this.indivButton_Click);
            // 
            // otherHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(288, 190);
            this.Controls.Add(this.globalButton);
            this.Controls.Add(this.indivButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "otherHelpForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "کمک متفرقه";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button globalButton;
        private System.Windows.Forms.Button indivButton;
    }
}