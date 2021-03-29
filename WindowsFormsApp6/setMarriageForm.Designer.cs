namespace WindowsFormsApp6
{
    partial class setMarriageForm
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
            this.setMarriageButton = new System.Windows.Forms.Button();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.marriedDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.marriedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // setMarriageButton
            // 
            this.setMarriageButton.BackColor = System.Drawing.Color.Lime;
            this.setMarriageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.setMarriageButton.FlatAppearance.BorderSize = 2;
            this.setMarriageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMarriageButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setMarriageButton.Location = new System.Drawing.Point(159, 516);
            this.setMarriageButton.Name = "setMarriageButton";
            this.setMarriageButton.Size = new System.Drawing.Size(140, 51);
            this.setMarriageButton.TabIndex = 19;
            this.setMarriageButton.Text = "ثبت ازدواج";
            this.setMarriageButton.UseVisualStyleBackColor = false;
            this.setMarriageButton.Click += new System.EventHandler(this.setMarriageButton_Click);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(364, 38);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(131, 32);
            this.editMemberLabel.TabIndex = 17;
            this.editMemberLabel.Text = "شماره ملی عضو :";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextbox
            // 
            this.idTextbox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextbox.Location = new System.Drawing.Point(159, 36);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(199, 37);
            this.idTextbox.TabIndex = 16;
            this.idTextbox.TextChanged += new System.EventHandler(this.idTextbox_TextChanged);
            this.idTextbox.DoubleClick += new System.EventHandler(this.independencyTextbox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(364, 84);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "تاریخ ازدواج عضو :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(364, 127);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(85, 32);
            this.label2.TabIndex = 23;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // marriedDescriptionTextBox
            // 
            this.marriedDescriptionTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marriedDescriptionTextBox.Location = new System.Drawing.Point(53, 125);
            this.marriedDescriptionTextBox.Multiline = true;
            this.marriedDescriptionTextBox.Name = "marriedDescriptionTextBox";
            this.marriedDescriptionTextBox.Size = new System.Drawing.Size(305, 384);
            this.marriedDescriptionTextBox.TabIndex = 22;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(53, 32);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 43);
            this.searchButton.TabIndex = 24;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // marriedTimePicker
            // 
            this.marriedTimePicker.CustomFormat = "";
            this.marriedTimePicker.Location = new System.Drawing.Point(53, 87);
            this.marriedTimePicker.Name = "marriedTimePicker";
            this.marriedTimePicker.Size = new System.Drawing.Size(305, 22);
            this.marriedTimePicker.TabIndex = 25;
            // 
            // setMarriageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(516, 579);
            this.Controls.Add(this.marriedTimePicker);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.marriedDescriptionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setMarriageButton);
            this.Controls.Add(this.editMemberLabel);
            this.Controls.Add(this.idTextbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setMarriageForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت ازدواج";
            this.Load += new System.EventHandler(this.setMarriageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setMarriageButton;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox marriedDescriptionTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DateTimePicker marriedTimePicker;
    }
}