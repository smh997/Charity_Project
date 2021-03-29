namespace WindowsFormsApp6
{
    partial class editMarriageForm2
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
            this.marriedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.marriedDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.familyTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteMarriageButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.newExplain = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // setMarriageButton
            // 
            this.setMarriageButton.BackColor = System.Drawing.Color.Lime;
            this.setMarriageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.setMarriageButton.FlatAppearance.BorderSize = 2;
            this.setMarriageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMarriageButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setMarriageButton.Location = new System.Drawing.Point(656, 397);
            this.setMarriageButton.Name = "setMarriageButton";
            this.setMarriageButton.Size = new System.Drawing.Size(150, 43);
            this.setMarriageButton.TabIndex = 28;
            this.setMarriageButton.Text = "ثبت";
            this.setMarriageButton.UseVisualStyleBackColor = false;
            this.setMarriageButton.Click += new System.EventHandler(this.setMarriageButton_Click);
            // 
            // marriedTimePicker
            // 
            this.marriedTimePicker.CustomFormat = "";
            this.marriedTimePicker.Location = new System.Drawing.Point(476, 228);
            this.marriedTimePicker.Name = "marriedTimePicker";
            this.marriedTimePicker.Size = new System.Drawing.Size(199, 22);
            this.marriedTimePicker.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(370, 77);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(85, 32);
            this.label2.TabIndex = 33;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // marriedDescriptionTextBox
            // 
            this.marriedDescriptionTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marriedDescriptionTextBox.Location = new System.Drawing.Point(59, 75);
            this.marriedDescriptionTextBox.Multiline = true;
            this.marriedDescriptionTextBox.Name = "marriedDescriptionTextBox";
            this.marriedDescriptionTextBox.ReadOnly = true;
            this.marriedDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.marriedDescriptionTextBox.Size = new System.Drawing.Size(305, 175);
            this.marriedDescriptionTextBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(681, 225);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 31;
            this.label1.Text = "تاریخ ازدواج عضو :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(681, 77);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(131, 32);
            this.editMemberLabel.TabIndex = 30;
            this.editMemberLabel.Text = "شماره ملی عضو :";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextbox
            // 
            this.idTextbox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextbox.Location = new System.Drawing.Point(476, 75);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(199, 37);
            this.idTextbox.TabIndex = 29;
            this.idTextbox.TextChanged += new System.EventHandler(this.idTextbox_TextChanged);
            this.idTextbox.DoubleClick += new System.EventHandler(this.idTextbox_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(681, 124);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 35;
            this.label3.Text = "نام عضو :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(681, 172);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(146, 32);
            this.label4.TabIndex = 36;
            this.label4.Text = "نام خانوادگی عضو :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(476, 334);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(150, 43);
            this.searchButton.TabIndex = 37;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // familyTextBox
            // 
            this.familyTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.familyTextBox.Location = new System.Drawing.Point(476, 171);
            this.familyTextBox.Name = "familyTextBox";
            this.familyTextBox.Size = new System.Drawing.Size(199, 37);
            this.familyTextBox.TabIndex = 42;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.nameTextBox.Location = new System.Drawing.Point(476, 123);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(199, 37);
            this.nameTextBox.TabIndex = 39;
            // 
            // DeleteMarriageButton
            // 
            this.DeleteMarriageButton.BackColor = System.Drawing.Color.OrangeRed;
            this.DeleteMarriageButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.DeleteMarriageButton.FlatAppearance.BorderSize = 2;
            this.DeleteMarriageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMarriageButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DeleteMarriageButton.Location = new System.Drawing.Point(476, 397);
            this.DeleteMarriageButton.Name = "DeleteMarriageButton";
            this.DeleteMarriageButton.Size = new System.Drawing.Size(150, 43);
            this.DeleteMarriageButton.TabIndex = 40;
            this.DeleteMarriageButton.Text = "حذف";
            this.DeleteMarriageButton.UseVisualStyleBackColor = false;
            this.DeleteMarriageButton.Click += new System.EventHandler(this.DeleteMarriageButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.Color.YellowGreen;
            this.checkButton.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.checkButton.FlatAppearance.BorderSize = 2;
            this.checkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkButton.Location = new System.Drawing.Point(656, 334);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(150, 43);
            this.checkButton.TabIndex = 41;
            this.checkButton.Text = "بررسی";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox2.Location = new System.Drawing.Point(374, 262);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 57);
            this.textBox2.TabIndex = 85;
            this.textBox2.Text = "توضیحات جدید:";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newExplain
            // 
            this.newExplain.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.newExplain.Location = new System.Drawing.Point(59, 261);
            this.newExplain.Multiline = true;
            this.newExplain.Name = "newExplain";
            this.newExplain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newExplain.Size = new System.Drawing.Size(305, 204);
            this.newExplain.TabIndex = 84;
            // 
            // editMarriageForm2
            // 
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(862, 477);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.newExplain);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.DeleteMarriageButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.familyTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.marriedTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.marriedDescriptionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editMemberLabel);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.setMarriageButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editMarriageForm2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "ویرایش ازدواج";
            this.Load += new System.EventHandler(this.editMarriageForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button setMarriageButton;
        private System.Windows.Forms.DateTimePicker marriedTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox marriedDescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox familyTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button DeleteMarriageButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox newExplain;

        #endregion
        /*
        private System.Windows.Forms.DateTimePicker marriedTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox marriedDescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox familyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setMarriageButton;
        private System.Windows.Forms.Button DeleteMarriageButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button button1;
        */
    }
}