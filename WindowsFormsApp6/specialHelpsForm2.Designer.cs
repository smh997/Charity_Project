﻿namespace WindowsFormsApp6
{
    partial class specialHelpsForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(specialHelpsForm2));
            this.editButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.editButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Yellow;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.editButton.FlatAppearance.BorderSize = 2;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editButton.Location = new System.Drawing.Point(85, 129);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(174, 51);
            this.editButton.TabIndex = 17;
            this.editButton.Text = "ویرایش";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Chartreuse;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(85, 58);
            this.setButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 16;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // editButton2
            // 
            this.editButton2.BackColor = System.Drawing.Color.Yellow;
            this.editButton2.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.editButton2.FlatAppearance.BorderSize = 2;
            this.editButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editButton2.Location = new System.Drawing.Point(85, 161);
            this.editButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editButton2.Name = "editButton2";
            this.editButton2.Size = new System.Drawing.Size(174, 51);
            this.editButton2.TabIndex = 18;
            this.editButton2.Text = "ویرایش رد";
            this.editButton2.UseVisualStyleBackColor = false;
            this.editButton2.Visible = false;
            this.editButton2.Click += new System.EventHandler(this.editButton2_Click);
            // 
            // specialHelpsForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(347, 225);
            this.Controls.Add(this.editButton2);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.setButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "specialHelpsForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعریف کمک ویژه";
            this.Load += new System.EventHandler(this.specialHelpsForm2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button editButton2;
    }
}