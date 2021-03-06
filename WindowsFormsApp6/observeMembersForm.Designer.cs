namespace WindowsFormsApp6
{
    partial class observeMembersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observeMembersForm));
            this.membersView = new System.Windows.Forms.DataGridView();
            this.chooseButton = new System.Windows.Forms.Button();
            this.searchByFolderbutton = new System.Windows.Forms.Button();
            this.foldertextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.familyTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.exportButton2 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
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
            this.membersView.Location = new System.Drawing.Point(28, 243);
            this.membersView.MultiSelect = false;
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView.Size = new System.Drawing.Size(676, 458);
            this.membersView.TabIndex = 9;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView_ColumnHeaderMouseClick);
            this.membersView.SelectionChanged += new System.EventHandler(this.membersView_SelectionChanged);
            // 
            // chooseButton
            // 
            this.chooseButton.BackColor = System.Drawing.Color.Gold;
            this.chooseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chooseButton.FlatAppearance.BorderSize = 2;
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chooseButton.Location = new System.Drawing.Point(494, 95);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(170, 47);
            this.chooseButton.TabIndex = 38;
            this.chooseButton.Text = "انتخاب";
            this.chooseButton.UseVisualStyleBackColor = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // searchByFolderbutton
            // 
            this.searchByFolderbutton.BackColor = System.Drawing.Color.GreenYellow;
            this.searchByFolderbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchByFolderbutton.FlatAppearance.BorderSize = 2;
            this.searchByFolderbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchByFolderbutton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchByFolderbutton.Location = new System.Drawing.Point(12, 95);
            this.searchByFolderbutton.Name = "searchByFolderbutton";
            this.searchByFolderbutton.Size = new System.Drawing.Size(138, 47);
            this.searchByFolderbutton.TabIndex = 37;
            this.searchByFolderbutton.Text = "جستجو";
            this.searchByFolderbutton.UseVisualStyleBackColor = false;
            this.searchByFolderbutton.Click += new System.EventHandler(this.searchByFolderbutton_Click);
            // 
            // foldertextBox
            // 
            this.foldertextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.foldertextBox.Location = new System.Drawing.Point(170, 97);
            this.foldertextBox.Name = "foldertextBox";
            this.foldertextBox.Size = new System.Drawing.Size(174, 44);
            this.foldertextBox.TabIndex = 36;
            this.foldertextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foldertextBox.TextChanged += new System.EventHandler(this.foldertextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(350, 99);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(129, 38);
            this.label3.TabIndex = 35;
            this.label3.Text = "شماره پرونده:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.GreenYellow;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(12, 36);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(138, 47);
            this.searchButton.TabIndex = 34;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(350, 39);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(125, 38);
            this.label1.TabIndex = 33;
            this.label1.Text = "نام خانوادگی:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // familyTextbox
            // 
            this.familyTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.familyTextbox.Location = new System.Drawing.Point(170, 38);
            this.familyTextbox.Name = "familyTextbox";
            this.familyTextbox.Size = new System.Drawing.Size(174, 44);
            this.familyTextbox.TabIndex = 32;
            this.familyTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.familyTextbox.TextChanged += new System.EventHandler(this.familyTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(674, 41);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(44, 38);
            this.label2.TabIndex = 31;
            this.label2.Text = "نام:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.nameTextbox.Location = new System.Drawing.Point(494, 39);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(174, 44);
            this.nameTextbox.TabIndex = 30;
            this.nameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameTextbox.TextChanged += new System.EventHandler(this.nameTextbox_TextChanged);
            // 
            // exportButton2
            // 
            this.exportButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.exportButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton2.BackgroundImage")));
            this.exportButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton2.FlatAppearance.BorderSize = 0;
            this.exportButton2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton2.Location = new System.Drawing.Point(156, 155);
            this.exportButton2.Name = "exportButton2";
            this.exportButton2.Size = new System.Drawing.Size(74, 82);
            this.exportButton2.TabIndex = 331;
            this.exportButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton2.UseVisualStyleBackColor = false;
            this.exportButton2.Click += new System.EventHandler(this.exportButton2_Click);
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.GreenYellow;
            this.exportButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton.BackgroundImage")));
            this.exportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton.Location = new System.Drawing.Point(76, 155);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(74, 82);
            this.exportButton.TabIndex = 330;
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // observeMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(726, 726);
            this.Controls.Add(this.exportButton2);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.searchByFolderbutton);
            this.Controls.Add(this.foldertextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.familyTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.membersView);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observeMembersForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده مددجویان";
            this.Load += new System.EventHandler(this.observeMembersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Button searchByFolderbutton;
        private System.Windows.Forms.TextBox foldertextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox familyTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Button exportButton2;
        private System.Windows.Forms.Button exportButton;
    }
}