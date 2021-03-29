namespace WindowsFormsApp6
{
    partial class editIndependencyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.membersView = new System.Windows.Forms.DataGridView();
            this.editIndependencySupportButton = new System.Windows.Forms.Button();
            this.editIndependencyDeleteSupportButton = new System.Windows.Forms.Button();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.editIndependencyTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editIndependencyDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.newExplain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            this.SuspendLayout();
            // 
            // membersView
            // 
            this.membersView.AllowUserToAddRows = false;
            this.membersView.AllowUserToDeleteRows = false;
            this.membersView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.membersView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.membersView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.membersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.membersView.DefaultCellStyle = dataGridViewCellStyle2;
            this.membersView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.membersView.Location = new System.Drawing.Point(347, 109);
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.Size = new System.Drawing.Size(792, 487);
            this.membersView.TabIndex = 8;
            this.membersView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellDoubleClick);
            // 
            // editIndependencySupportButton
            // 
            this.editIndependencySupportButton.BackColor = System.Drawing.Color.Lime;
            this.editIndependencySupportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.editIndependencySupportButton.FlatAppearance.BorderSize = 2;
            this.editIndependencySupportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editIndependencySupportButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editIndependencySupportButton.Location = new System.Drawing.Point(493, 47);
            this.editIndependencySupportButton.Name = "editIndependencySupportButton";
            this.editIndependencySupportButton.Size = new System.Drawing.Size(140, 51);
            this.editIndependencySupportButton.TabIndex = 19;
            this.editIndependencySupportButton.Text = "پوشش";
            this.editIndependencySupportButton.UseVisualStyleBackColor = false;
            this.editIndependencySupportButton.Click += new System.EventHandler(this.editIndependencySupportButton_Click);
            // 
            // editIndependencyDeleteSupportButton
            // 
            this.editIndependencyDeleteSupportButton.BackColor = System.Drawing.Color.Coral;
            this.editIndependencyDeleteSupportButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.editIndependencyDeleteSupportButton.FlatAppearance.BorderSize = 2;
            this.editIndependencyDeleteSupportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editIndependencyDeleteSupportButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editIndependencyDeleteSupportButton.Location = new System.Drawing.Point(347, 47);
            this.editIndependencyDeleteSupportButton.Name = "editIndependencyDeleteSupportButton";
            this.editIndependencyDeleteSupportButton.Size = new System.Drawing.Size(140, 51);
            this.editIndependencyDeleteSupportButton.TabIndex = 18;
            this.editIndependencyDeleteSupportButton.Text = "حذف پوشش";
            this.editIndependencyDeleteSupportButton.UseVisualStyleBackColor = false;
            this.editIndependencyDeleteSupportButton.Click += new System.EventHandler(this.editIndependencyDeleteSupportButton_Click);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(867, 56);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(278, 32);
            this.editMemberLabel.TabIndex = 17;
            this.editMemberLabel.Text = "شماره ملی عضو مورد نظر را وارد کنید.";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editIndependencyTextbox
            // 
            this.editIndependencyTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editIndependencyTextbox.Location = new System.Drawing.Point(657, 54);
            this.editIndependencyTextbox.Name = "editIndependencyTextbox";
            this.editIndependencyTextbox.Size = new System.Drawing.Size(204, 30);
            this.editIndependencyTextbox.TabIndex = 16;
            this.editIndependencyTextbox.TextChanged += new System.EventHandler(this.editindependencyTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(135, 74);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "توضیحات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editIndependencyDescriptionTextBox
            // 
            this.editIndependencyDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editIndependencyDescriptionTextBox.Location = new System.Drawing.Point(17, 109);
            this.editIndependencyDescriptionTextBox.Multiline = true;
            this.editIndependencyDescriptionTextBox.Name = "editIndependencyDescriptionTextBox";
            this.editIndependencyDescriptionTextBox.ReadOnly = true;
            this.editIndependencyDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editIndependencyDescriptionTextBox.Size = new System.Drawing.Size(324, 200);
            this.editIndependencyDescriptionTextBox.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox2.Location = new System.Drawing.Point(126, 315);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 57);
            this.textBox2.TabIndex = 83;
            this.textBox2.Text = "توضیحات جدید:";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newExplain
            // 
            this.newExplain.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.newExplain.Location = new System.Drawing.Point(17, 392);
            this.newExplain.Multiline = true;
            this.newExplain.Name = "newExplain";
            this.newExplain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newExplain.Size = new System.Drawing.Size(324, 204);
            this.newExplain.TabIndex = 82;
            // 
            // editIndependencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(1220, 683);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.newExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editIndependencyDescriptionTextBox);
            this.Controls.Add(this.editIndependencySupportButton);
            this.Controls.Add(this.editIndependencyDeleteSupportButton);
            this.Controls.Add(this.editMemberLabel);
            this.Controls.Add(this.editIndependencyTextbox);
            this.Controls.Add(this.membersView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editIndependencyForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ویرایش استقلال";
            this.Load += new System.EventHandler(this.editIndependencyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.Button editIndependencySupportButton;
        private System.Windows.Forms.Button editIndependencyDeleteSupportButton;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.TextBox editIndependencyTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editIndependencyDescriptionTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox newExplain;
    }
}