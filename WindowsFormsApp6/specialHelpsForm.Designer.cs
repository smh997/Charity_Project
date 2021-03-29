namespace WindowsFormsApp6
{
    partial class specialHelpsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(specialHelpsForm));
            this.studyButton = new System.Windows.Forms.Button();
            this.marryButton = new System.Windows.Forms.Button();
            this.healButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studyButton
            // 
            this.studyButton.BackColor = System.Drawing.Color.Aquamarine;
            this.studyButton.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.studyButton.FlatAppearance.BorderSize = 2;
            this.studyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.studyButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.studyButton.Location = new System.Drawing.Point(94, 37);
            this.studyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.studyButton.Name = "studyButton";
            this.studyButton.Size = new System.Drawing.Size(117, 70);
            this.studyButton.TabIndex = 13;
            this.studyButton.Text = "تحصیلی";
            this.studyButton.UseVisualStyleBackColor = false;
            this.studyButton.Click += new System.EventHandler(this.studyButton_Click);
            // 
            // marryButton
            // 
            this.marryButton.BackColor = System.Drawing.Color.Violet;
            this.marryButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.marryButton.FlatAppearance.BorderSize = 2;
            this.marryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.marryButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marryButton.Location = new System.Drawing.Point(94, 134);
            this.marryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.marryButton.Name = "marryButton";
            this.marryButton.Size = new System.Drawing.Size(117, 70);
            this.marryButton.TabIndex = 14;
            this.marryButton.Text = "ازدواج";
            this.marryButton.UseVisualStyleBackColor = false;
            this.marryButton.Click += new System.EventHandler(this.marryButton_Click);
            // 
            // healButton
            // 
            this.healButton.BackColor = System.Drawing.Color.Gold;
            this.healButton.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.healButton.FlatAppearance.BorderSize = 2;
            this.healButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healButton.Location = new System.Drawing.Point(94, 229);
            this.healButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.healButton.Name = "healButton";
            this.healButton.Size = new System.Drawing.Size(117, 70);
            this.healButton.TabIndex = 15;
            this.healButton.Text = "درمان";
            this.healButton.UseVisualStyleBackColor = false;
            this.healButton.Click += new System.EventHandler(this.healButton_Click);
            // 
            // specialHelpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(305, 330);
            this.Controls.Add(this.healButton);
            this.Controls.Add(this.marryButton);
            this.Controls.Add(this.studyButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "specialHelpsForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "کمک‌های ویژه";
            this.Load += new System.EventHandler(this.specialHelpsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button studyButton;
        private System.Windows.Forms.Button marryButton;
        private System.Windows.Forms.Button healButton;
    }
}