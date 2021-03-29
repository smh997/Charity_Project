namespace WindowsFormsApp6
{
    partial class deleteMemberForm
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
            this.deleteMemeberButton = new System.Windows.Forms.Button();
            this.deleteMemberLabel = new System.Windows.Forms.Label();
            this.deleteMemberTextbox = new System.Windows.Forms.TextBox();
            this.membersView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteMemeberButton
            // 
            this.deleteMemeberButton.BackColor = System.Drawing.Color.Lime;
            this.deleteMemeberButton.Font = new System.Drawing.Font("B Titr", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deleteMemeberButton.Location = new System.Drawing.Point(500, 41);
            this.deleteMemeberButton.Name = "deleteMemeberButton";
            this.deleteMemeberButton.Size = new System.Drawing.Size(110, 37);
            this.deleteMemeberButton.TabIndex = 9;
            this.deleteMemeberButton.Text = "ثبت";
            this.deleteMemeberButton.UseVisualStyleBackColor = false;
            this.deleteMemeberButton.Click += new System.EventHandler(this.deleteMemeberButton_Click);
            // 
            // deleteMemberLabel
            // 
            this.deleteMemberLabel.AutoSize = true;
            this.deleteMemberLabel.Font = new System.Drawing.Font("B Titr", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deleteMemberLabel.Location = new System.Drawing.Point(843, 48);
            this.deleteMemberLabel.Name = "deleteMemberLabel";
            this.deleteMemberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteMemberLabel.Size = new System.Drawing.Size(243, 30);
            this.deleteMemberLabel.TabIndex = 8;
            this.deleteMemberLabel.Text = "شماره ملی عضو مورد نظر را وارد کنید.";
            this.deleteMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteMemberTextbox
            // 
            this.deleteMemberTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteMemberTextbox.Location = new System.Drawing.Point(633, 46);
            this.deleteMemberTextbox.Name = "deleteMemberTextbox";
            this.deleteMemberTextbox.Size = new System.Drawing.Size(204, 30);
            this.deleteMemberTextbox.TabIndex = 7;
            this.deleteMemberTextbox.TextChanged += new System.EventHandler(this.deleteMemberTextbox_TextChanged);
            // 
            // membersView
            // 
            this.membersView.AllowUserToAddRows = false;
            this.membersView.AllowUserToDeleteRows = false;
            this.membersView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.membersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersView.Location = new System.Drawing.Point(172, 92);
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.Size = new System.Drawing.Size(989, 446);
            this.membersView.TabIndex = 6;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellDoubleClick);
            // 
            // deleteMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1332, 559);
            this.Controls.Add(this.deleteMemeberButton);
            this.Controls.Add(this.deleteMemberLabel);
            this.Controls.Add(this.deleteMemberTextbox);
            this.Controls.Add(this.membersView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "deleteMemberForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حذف عضو";
            this.Load += new System.EventHandler(this.deleteMemberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteMemeberButton;
        private System.Windows.Forms.Label deleteMemberLabel;
        private System.Windows.Forms.TextBox deleteMemberTextbox;
        private System.Windows.Forms.DataGridView membersView;
    }
}