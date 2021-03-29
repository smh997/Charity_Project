namespace WindowsFormsApp6
{
    partial class otherHelpIndivForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(otherHelpIndivForm));
            this.checkReqButton = new System.Windows.Forms.Button();
            this.reqButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkReqButton
            // 
            this.checkReqButton.BackColor = System.Drawing.Color.SandyBrown;
            this.checkReqButton.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.checkReqButton.FlatAppearance.BorderSize = 2;
            this.checkReqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkReqButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkReqButton.Location = new System.Drawing.Point(147, 83);
            this.checkReqButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkReqButton.Name = "checkReqButton";
            this.checkReqButton.Size = new System.Drawing.Size(113, 93);
            this.checkReqButton.TabIndex = 200;
            this.checkReqButton.Text = "بررسی درخواست";
            this.checkReqButton.UseVisualStyleBackColor = false;
            this.checkReqButton.Click += new System.EventHandler(this.checkReqButton_Click);
            // 
            // reqButton
            // 
            this.reqButton.BackColor = System.Drawing.Color.Aquamarine;
            this.reqButton.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.reqButton.FlatAppearance.BorderSize = 2;
            this.reqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqButton.Location = new System.Drawing.Point(28, 83);
            this.reqButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reqButton.Name = "reqButton";
            this.reqButton.Size = new System.Drawing.Size(113, 93);
            this.reqButton.TabIndex = 199;
            this.reqButton.Text = "ثبت درخواست";
            this.reqButton.UseVisualStyleBackColor = false;
            this.reqButton.Click += new System.EventHandler(this.reqButton_Click);
            // 
            // otherHelpIndivForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(288, 259);
            this.Controls.Add(this.checkReqButton);
            this.Controls.Add(this.reqButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "otherHelpIndivForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "کمک متفرقه فردی";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkReqButton;
        private System.Windows.Forms.Button reqButton;
    }
}