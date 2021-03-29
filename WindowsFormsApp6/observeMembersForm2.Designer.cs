namespace WindowsFormsApp6
{
    partial class observeMembersForm2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observeMembersForm2));
            this.membersView = new System.Windows.Forms.DataGridView();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.docGroupBox = new System.Windows.Forms.GroupBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.studentButton = new System.Windows.Forms.Button();
            this.orphanButton = new System.Windows.Forms.Button();
            this.otherButton = new System.Windows.Forms.Button();
            this.authButton = new System.Windows.Forms.Button();
            this.healthButton = new System.Windows.Forms.Button();
            this.marryButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.docGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // membersView
            // 
            this.membersView.AllowUserToAddRows = false;
            this.membersView.AllowUserToDeleteRows = false;
            this.membersView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.membersView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.membersView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.membersView.BackgroundColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.membersView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.membersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.membersView.DefaultCellStyle = dataGridViewCellStyle2;
            this.membersView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.membersView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.membersView.Location = new System.Drawing.Point(26, 12);
            this.membersView.MultiSelect = false;
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView.Size = new System.Drawing.Size(471, 225);
            this.membersView.TabIndex = 10;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView_ColumnHeaderMouseClick);
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.profilePictureBox.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePictureBox.ErrorImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.InitialImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.Location = new System.Drawing.Point(503, 12);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(210, 280);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePictureBox.TabIndex = 186;
            this.profilePictureBox.TabStop = false;
            this.profilePictureBox.WaitOnLoad = true;
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.Aquamarine;
            this.homeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.homeButton.FlatAppearance.BorderSize = 2;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.homeButton.Location = new System.Drawing.Point(6, 43);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(152, 51);
            this.homeButton.TabIndex = 285;
            this.homeButton.Text = "مسکن";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // docGroupBox
            // 
            this.docGroupBox.BackColor = System.Drawing.Color.SkyBlue;
            this.docGroupBox.Controls.Add(this.enterButton);
            this.docGroupBox.Controls.Add(this.studentButton);
            this.docGroupBox.Controls.Add(this.orphanButton);
            this.docGroupBox.Controls.Add(this.otherButton);
            this.docGroupBox.Controls.Add(this.authButton);
            this.docGroupBox.Controls.Add(this.healthButton);
            this.docGroupBox.Controls.Add(this.marryButton);
            this.docGroupBox.Controls.Add(this.homeButton);
            this.docGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docGroupBox.Location = new System.Drawing.Point(48, 324);
            this.docGroupBox.Name = "docGroupBox";
            this.docGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docGroupBox.Size = new System.Drawing.Size(640, 179);
            this.docGroupBox.TabIndex = 286;
            this.docGroupBox.TabStop = false;
            this.docGroupBox.Text = "مدارک";
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.Aquamarine;
            this.enterButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.enterButton.FlatAppearance.BorderSize = 2;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enterButton.Location = new System.Drawing.Point(6, 100);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(152, 51);
            this.enterButton.TabIndex = 291;
            this.enterButton.Text = "ورود";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // studentButton
            // 
            this.studentButton.BackColor = System.Drawing.Color.Aquamarine;
            this.studentButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.studentButton.FlatAppearance.BorderSize = 2;
            this.studentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.studentButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.studentButton.Location = new System.Drawing.Point(162, 100);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(152, 51);
            this.studentButton.TabIndex = 290;
            this.studentButton.Text = "دانش‌آموز";
            this.studentButton.UseVisualStyleBackColor = false;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // orphanButton
            // 
            this.orphanButton.BackColor = System.Drawing.Color.Aquamarine;
            this.orphanButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.orphanButton.FlatAppearance.BorderSize = 2;
            this.orphanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orphanButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.orphanButton.Location = new System.Drawing.Point(320, 100);
            this.orphanButton.Name = "orphanButton";
            this.orphanButton.Size = new System.Drawing.Size(152, 51);
            this.orphanButton.TabIndex = 289;
            this.orphanButton.Text = "یتیم";
            this.orphanButton.UseVisualStyleBackColor = false;
            this.orphanButton.Click += new System.EventHandler(this.orphanButton_Click);
            // 
            // otherButton
            // 
            this.otherButton.BackColor = System.Drawing.Color.Aquamarine;
            this.otherButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.otherButton.FlatAppearance.BorderSize = 2;
            this.otherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otherButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.otherButton.Location = new System.Drawing.Point(478, 100);
            this.otherButton.Name = "otherButton";
            this.otherButton.Size = new System.Drawing.Size(152, 51);
            this.otherButton.TabIndex = 289;
            this.otherButton.Text = "متفرقه";
            this.otherButton.UseVisualStyleBackColor = false;
            this.otherButton.Click += new System.EventHandler(this.otherButton_Click);
            // 
            // authButton
            // 
            this.authButton.BackColor = System.Drawing.Color.Aquamarine;
            this.authButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.authButton.FlatAppearance.BorderSize = 2;
            this.authButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.authButton.Location = new System.Drawing.Point(478, 43);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(152, 51);
            this.authButton.TabIndex = 288;
            this.authButton.Text = "شناسایی";
            this.authButton.UseVisualStyleBackColor = false;
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            // 
            // healthButton
            // 
            this.healthButton.BackColor = System.Drawing.Color.Aquamarine;
            this.healthButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.healthButton.FlatAppearance.BorderSize = 2;
            this.healthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healthButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healthButton.Location = new System.Drawing.Point(162, 43);
            this.healthButton.Name = "healthButton";
            this.healthButton.Size = new System.Drawing.Size(152, 51);
            this.healthButton.TabIndex = 287;
            this.healthButton.Text = "سلامت";
            this.healthButton.UseVisualStyleBackColor = false;
            this.healthButton.Click += new System.EventHandler(this.healthButton_Click);
            // 
            // marryButton
            // 
            this.marryButton.BackColor = System.Drawing.Color.Aquamarine;
            this.marryButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.marryButton.FlatAppearance.BorderSize = 2;
            this.marryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.marryButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marryButton.Location = new System.Drawing.Point(320, 43);
            this.marryButton.Name = "marryButton";
            this.marryButton.Size = new System.Drawing.Size(152, 51);
            this.marryButton.TabIndex = 286;
            this.marryButton.Text = "تأهل";
            this.marryButton.UseVisualStyleBackColor = false;
            this.marryButton.Click += new System.EventHandler(this.marryButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.GreenYellow;
            this.exportButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton.BackgroundImage")));
            this.exportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton.Location = new System.Drawing.Point(26, 243);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(74, 82);
            this.exportButton.TabIndex = 287;
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // observeMembersForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(721, 511);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.docGroupBox);
            this.Controls.Add(this.profilePictureBox);
            this.Controls.Add(this.membersView);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observeMembersForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده مددجو";
            this.Load += new System.EventHandler(this.observeMemberForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            this.docGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.PictureBox profilePictureBox;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.GroupBox docGroupBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button authButton;
        private System.Windows.Forms.Button healthButton;
        private System.Windows.Forms.Button marryButton;
        private System.Windows.Forms.Button otherButton;
        private System.Windows.Forms.Button orphanButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button studentButton;
    }
}