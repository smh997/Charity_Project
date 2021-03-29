namespace WindowsFormsApp6
{
    partial class marryHelpForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(marryHelpForm2));
            this.editSendIntroduceButton = new System.Windows.Forms.Button();
            this.setResultButton = new System.Windows.Forms.Button();
            this.editResultButton = new System.Windows.Forms.Button();
            this.sendIntroduceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editSendIntroduceButton
            // 
            this.editSendIntroduceButton.BackColor = System.Drawing.Color.Yellow;
            this.editSendIntroduceButton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.editSendIntroduceButton.FlatAppearance.BorderSize = 2;
            this.editSendIntroduceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSendIntroduceButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editSendIntroduceButton.Location = new System.Drawing.Point(154, 133);
            this.editSendIntroduceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editSendIntroduceButton.Name = "editSendIntroduceButton";
            this.editSendIntroduceButton.Size = new System.Drawing.Size(122, 93);
            this.editSendIntroduceButton.TabIndex = 201;
            this.editSendIntroduceButton.Text = "ویرایش ارسال";
            this.editSendIntroduceButton.UseVisualStyleBackColor = false;
            this.editSendIntroduceButton.Click += new System.EventHandler(this.editSendIntroduceButton_Click);
            // 
            // setResultButton
            // 
            this.setResultButton.BackColor = System.Drawing.Color.Lime;
            this.setResultButton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.setResultButton.FlatAppearance.BorderSize = 2;
            this.setResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setResultButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setResultButton.Location = new System.Drawing.Point(12, 32);
            this.setResultButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setResultButton.Name = "setResultButton";
            this.setResultButton.Size = new System.Drawing.Size(124, 93);
            this.setResultButton.TabIndex = 200;
            this.setResultButton.Text = "ثبت نتیجه";
            this.setResultButton.UseVisualStyleBackColor = false;
            this.setResultButton.Click += new System.EventHandler(this.setResultButton_Click);
            // 
            // editResultButton
            // 
            this.editResultButton.BackColor = System.Drawing.Color.Yellow;
            this.editResultButton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.editResultButton.FlatAppearance.BorderSize = 2;
            this.editResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editResultButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editResultButton.Location = new System.Drawing.Point(12, 133);
            this.editResultButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editResultButton.Name = "editResultButton";
            this.editResultButton.Size = new System.Drawing.Size(124, 93);
            this.editResultButton.TabIndex = 199;
            this.editResultButton.Text = "ویرایش نتیجه";
            this.editResultButton.UseVisualStyleBackColor = false;
            this.editResultButton.Click += new System.EventHandler(this.editResultButton_Click);
            // 
            // sendIntroduceButton
            // 
            this.sendIntroduceButton.BackColor = System.Drawing.Color.Lime;
            this.sendIntroduceButton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.sendIntroduceButton.FlatAppearance.BorderSize = 2;
            this.sendIntroduceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendIntroduceButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sendIntroduceButton.Location = new System.Drawing.Point(154, 32);
            this.sendIntroduceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendIntroduceButton.Name = "sendIntroduceButton";
            this.sendIntroduceButton.Size = new System.Drawing.Size(122, 93);
            this.sendIntroduceButton.TabIndex = 202;
            this.sendIntroduceButton.Text = "ارسال معرفی‌نامه";
            this.sendIntroduceButton.UseVisualStyleBackColor = false;
            this.sendIntroduceButton.Click += new System.EventHandler(this.sendIntroduceButton_Click);
            // 
            // marryHelpForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(288, 259);
            this.Controls.Add(this.sendIntroduceButton);
            this.Controls.Add(this.editSendIntroduceButton);
            this.Controls.Add(this.setResultButton);
            this.Controls.Add(this.editResultButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "marryHelpForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پیگیری جهیزیه";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editSendIntroduceButton;
        private System.Windows.Forms.Button setResultButton;
        private System.Windows.Forms.Button editResultButton;
        private System.Windows.Forms.Button sendIntroduceButton;
    }
}