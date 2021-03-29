namespace WindowsFormsApp6
{
    partial class observereqForm3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observereqForm3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chooseButton = new System.Windows.Forms.Button();
            this.exportButton2 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.membersView = new System.Windows.Forms.DataGridView();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.transferCheckBox = new System.Windows.Forms.CheckBox();
            this.helpeeCheckBox = new System.Windows.Forms.CheckBox();
            this.newWorkCheckBox = new System.Windows.Forms.CheckBox();
            this.helpingCheckBox = new System.Windows.Forms.CheckBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseButton
            // 
            this.chooseButton.BackColor = System.Drawing.Color.Gold;
            this.chooseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chooseButton.FlatAppearance.BorderSize = 2;
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chooseButton.Location = new System.Drawing.Point(41, 431);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(170, 47);
            this.chooseButton.TabIndex = 369;
            this.chooseButton.Text = "انتخاب";
            this.chooseButton.UseVisualStyleBackColor = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // exportButton2
            // 
            this.exportButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.exportButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton2.BackgroundImage")));
            this.exportButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton2.FlatAppearance.BorderSize = 0;
            this.exportButton2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton2.Location = new System.Drawing.Point(137, 290);
            this.exportButton2.Name = "exportButton2";
            this.exportButton2.Size = new System.Drawing.Size(74, 82);
            this.exportButton2.TabIndex = 368;
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
            this.exportButton.Location = new System.Drawing.Point(57, 290);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(74, 82);
            this.exportButton.TabIndex = 367;
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
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
            this.membersView.Location = new System.Drawing.Point(35, 12);
            this.membersView.MultiSelect = false;
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView.Size = new System.Drawing.Size(548, 243);
            this.membersView.TabIndex = 366;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView_ColumnHeaderMouseClick);
            this.membersView.SelectionChanged += new System.EventHandler(this.membersView_SelectionChanged);
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.BackColor = System.Drawing.Color.SkyBlue;
            this.typeGroupBox.Controls.Add(this.transferCheckBox);
            this.typeGroupBox.Controls.Add(this.helpeeCheckBox);
            this.typeGroupBox.Controls.Add(this.newWorkCheckBox);
            this.typeGroupBox.Controls.Add(this.helpingCheckBox);
            this.typeGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typeGroupBox.Location = new System.Drawing.Point(228, 277);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeGroupBox.Size = new System.Drawing.Size(379, 201);
            this.typeGroupBox.TabIndex = 370;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "نوع";
            // 
            // transferCheckBox
            // 
            this.transferCheckBox.AutoSize = true;
            this.transferCheckBox.Checked = true;
            this.transferCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.transferCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.transferCheckBox.Location = new System.Drawing.Point(200, 34);
            this.transferCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transferCheckBox.Name = "transferCheckBox";
            this.transferCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.transferCheckBox.Size = new System.Drawing.Size(155, 42);
            this.transferCheckBox.TabIndex = 333;
            this.transferCheckBox.Text = "واگذاری امتیاز";
            this.transferCheckBox.UseVisualStyleBackColor = true;
            this.transferCheckBox.CheckedChanged += new System.EventHandler(this.transferCheckBox_CheckedChanged);
            // 
            // helpeeCheckBox
            // 
            this.helpeeCheckBox.AutoSize = true;
            this.helpeeCheckBox.Checked = true;
            this.helpeeCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.helpeeCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helpeeCheckBox.Location = new System.Drawing.Point(44, 148);
            this.helpeeCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.helpeeCheckBox.Name = "helpeeCheckBox";
            this.helpeeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.helpeeCheckBox.Size = new System.Drawing.Size(311, 42);
            this.helpeeCheckBox.TabIndex = 336;
            this.helpeeCheckBox.Text = "دریافت امتیاز تسهیلات مددجویی";
            this.helpeeCheckBox.UseVisualStyleBackColor = true;
            // 
            // newWorkCheckBox
            // 
            this.newWorkCheckBox.AutoSize = true;
            this.newWorkCheckBox.Checked = true;
            this.newWorkCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.newWorkCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.newWorkCheckBox.Location = new System.Drawing.Point(40, 109);
            this.newWorkCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newWorkCheckBox.Name = "newWorkCheckBox";
            this.newWorkCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.newWorkCheckBox.Size = new System.Drawing.Size(315, 42);
            this.newWorkCheckBox.TabIndex = 334;
            this.newWorkCheckBox.Text = "دریافت امتیاز تسهیلات کارآفرینی";
            this.newWorkCheckBox.UseVisualStyleBackColor = true;
            // 
            // helpingCheckBox
            // 
            this.helpingCheckBox.AutoSize = true;
            this.helpingCheckBox.Checked = true;
            this.helpingCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.helpingCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helpingCheckBox.Location = new System.Drawing.Point(45, 69);
            this.helpingCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.helpingCheckBox.Name = "helpingCheckBox";
            this.helpingCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.helpingCheckBox.Size = new System.Drawing.Size(310, 42);
            this.helpingCheckBox.TabIndex = 335;
            this.helpingCheckBox.Text = "دریافت امتیاز تسهیلات مدد کاری";
            this.helpingCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.GreenYellow;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(41, 378);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(170, 47);
            this.searchButton.TabIndex = 371;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // observereqForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(619, 483);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.exportButton2);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.membersView);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observereqForm3";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده معرفی نامه";
            this.Load += new System.EventHandler(this.observereqForm3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Button exportButton2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.CheckBox transferCheckBox;
        private System.Windows.Forms.CheckBox helpeeCheckBox;
        private System.Windows.Forms.CheckBox helpingCheckBox;
        private System.Windows.Forms.CheckBox newWorkCheckBox;
        private System.Windows.Forms.Button searchButton;
    }
}