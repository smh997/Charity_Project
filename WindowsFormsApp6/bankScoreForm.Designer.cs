namespace WindowsFormsApp6
{
    partial class bankScoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bankScoreForm));
            this.label23 = new System.Windows.Forms.Label();
            this.bankScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.setButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bankScoreNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label23.Location = new System.Drawing.Point(207, 70);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(189, 38);
            this.label23.TabIndex = 1;
            this.label23.Text = "امتیاز بانکی(به ریال):";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankScoreNumericUpDown
            // 
            this.bankScoreNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankScoreNumericUpDown.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.bankScoreNumericUpDown.Location = new System.Drawing.Point(36, 72);
            this.bankScoreNumericUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.bankScoreNumericUpDown.Name = "bankScoreNumericUpDown";
            this.bankScoreNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bankScoreNumericUpDown.Size = new System.Drawing.Size(165, 39);
            this.bankScoreNumericUpDown.TabIndex = 18;
            this.bankScoreNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bankScoreNumericUpDown.ThousandsSeparator = true;
            this.bankScoreNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(106, 127);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 206;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // bankScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Orange;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(427, 213);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.bankScoreNumericUpDown);
            this.Controls.Add(this.label23);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bankScoreForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "امتیاز بانکی";
            ((System.ComponentModel.ISupportInitialize)(this.bankScoreNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown bankScoreNumericUpDown;
        private System.Windows.Forms.Button setButton;
    }
}