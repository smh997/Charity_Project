namespace WindowsFormsApp6
{
    partial class independencyForm
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
            this.independencyTextbox = new System.Windows.Forms.TextBox();
            this.editMemberLabel = new System.Windows.Forms.Label();
            this.independencyDeleteSupportButton = new System.Windows.Forms.Button();
            this.independencySupportButton = new System.Windows.Forms.Button();
            this.independencyDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.membersView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
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
            this.membersView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.membersView.Location = new System.Drawing.Point(360, 96);
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.Size = new System.Drawing.Size(792, 487);
            this.membersView.TabIndex = 7;
            this.membersView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellDoubleClick);
            // 
            // independencyTextbox
            // 
            this.independencyTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.independencyTextbox.Location = new System.Drawing.Point(670, 37);
            this.independencyTextbox.Name = "independencyTextbox";
            this.independencyTextbox.Size = new System.Drawing.Size(204, 30);
            this.independencyTextbox.TabIndex = 12;
            this.independencyTextbox.TextChanged += new System.EventHandler(this.independencyTextbox_TextChanged);
            // 
            // editMemberLabel
            // 
            this.editMemberLabel.AutoSize = true;
            this.editMemberLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editMemberLabel.Location = new System.Drawing.Point(880, 39);
            this.editMemberLabel.Name = "editMemberLabel";
            this.editMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editMemberLabel.Size = new System.Drawing.Size(278, 32);
            this.editMemberLabel.TabIndex = 13;
            this.editMemberLabel.Text = "شماره ملی عضو مورد نظر را وارد کنید.";
            this.editMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // independencyDeleteSupportButton
            // 
            this.independencyDeleteSupportButton.BackColor = System.Drawing.Color.Coral;
            this.independencyDeleteSupportButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.independencyDeleteSupportButton.FlatAppearance.BorderSize = 2;
            this.independencyDeleteSupportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.independencyDeleteSupportButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.independencyDeleteSupportButton.Location = new System.Drawing.Point(360, 30);
            this.independencyDeleteSupportButton.Name = "independencyDeleteSupportButton";
            this.independencyDeleteSupportButton.Size = new System.Drawing.Size(140, 51);
            this.independencyDeleteSupportButton.TabIndex = 14;
            this.independencyDeleteSupportButton.Text = "حذف پوشش";
            this.independencyDeleteSupportButton.UseVisualStyleBackColor = false;
            this.independencyDeleteSupportButton.Click += new System.EventHandler(this.independencyDeleteSupportButton_Click);
            // 
            // independencySupportButton
            // 
            this.independencySupportButton.BackColor = System.Drawing.Color.Lime;
            this.independencySupportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.independencySupportButton.FlatAppearance.BorderSize = 2;
            this.independencySupportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.independencySupportButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.independencySupportButton.Location = new System.Drawing.Point(506, 30);
            this.independencySupportButton.Name = "independencySupportButton";
            this.independencySupportButton.Size = new System.Drawing.Size(140, 51);
            this.independencySupportButton.TabIndex = 15;
            this.independencySupportButton.Text = "پوشش";
            this.independencySupportButton.UseVisualStyleBackColor = false;
            this.independencySupportButton.Click += new System.EventHandler(this.independencySupportButton_Click);
            // 
            // independencyDescriptionTextBox
            // 
            this.independencyDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.independencyDescriptionTextBox.Location = new System.Drawing.Point(30, 110);
            this.independencyDescriptionTextBox.Multiline = true;
            this.independencyDescriptionTextBox.Name = "independencyDescriptionTextBox";
            this.independencyDescriptionTextBox.Size = new System.Drawing.Size(324, 384);
            this.independencyDescriptionTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(152, 75);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "توضیحات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // independencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1220, 683);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.independencyDescriptionTextBox);
            this.Controls.Add(this.independencySupportButton);
            this.Controls.Add(this.independencyDeleteSupportButton);
            this.Controls.Add(this.editMemberLabel);
            this.Controls.Add(this.independencyTextbox);
            this.Controls.Add(this.membersView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1238, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1238, 730);
            this.Name = "independencyForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بررسی استقلال";
            this.Load += new System.EventHandler(this.independencyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.TextBox independencyTextbox;
        private System.Windows.Forms.Label editMemberLabel;
        private System.Windows.Forms.Button independencyDeleteSupportButton;
        private System.Windows.Forms.Button independencySupportButton;
        private System.Windows.Forms.TextBox independencyDescriptionTextBox;
        private System.Windows.Forms.Label label1;
    }
}