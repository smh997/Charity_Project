﻿namespace WindowsFormsApp6
{
    partial class observeBudgetsetsForm2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observeBudgetsetsForm2));
            this.membersView = new System.Windows.Forms.DataGridView();
            this.membersView2 = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chooseButton = new System.Windows.Forms.Button();
            this.exportButton4 = new System.Windows.Forms.Button();
            this.exportButton3 = new System.Windows.Forms.Button();
            this.exportButton2 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersView2)).BeginInit();
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
            this.membersView.Location = new System.Drawing.Point(41, 28);
            this.membersView.MultiSelect = false;
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView.Size = new System.Drawing.Size(399, 225);
            this.membersView.TabIndex = 11;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView_ColumnHeaderMouseClick);
            this.membersView.SelectionChanged += new System.EventHandler(this.membersView_SelectionChanged);
            // 
            // membersView2
            // 
            this.membersView2.AllowUserToAddRows = false;
            this.membersView2.AllowUserToDeleteRows = false;
            this.membersView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.membersView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.membersView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.membersView2.BackgroundColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.membersView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.membersView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.budget,
            this.consume});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.membersView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.membersView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.membersView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.membersView2.Location = new System.Drawing.Point(41, 274);
            this.membersView2.MultiSelect = false;
            this.membersView2.Name = "membersView2";
            this.membersView2.ReadOnly = true;
            this.membersView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.membersView2.RowTemplate.Height = 24;
            this.membersView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView2.Size = new System.Drawing.Size(399, 225);
            this.membersView2.TabIndex = 12;
            this.membersView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView2_CellClick);
            this.membersView2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView2_ColumnHeaderMouseClick);
            this.membersView2.SelectionChanged += new System.EventHandler(this.membersView2_SelectionChanged);
            // 
            // type
            // 
            this.type.HeaderText = "اقلام";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 68;
            // 
            // budget
            // 
            this.budget.HeaderText = "بودجه";
            this.budget.Name = "budget";
            this.budget.ReadOnly = true;
            this.budget.Width = 76;
            // 
            // consume
            // 
            this.consume.HeaderText = "بودجه مصرفی";
            this.consume.Name = "consume";
            this.consume.ReadOnly = true;
            this.consume.Width = 122;
            // 
            // chooseButton
            // 
            this.chooseButton.BackColor = System.Drawing.Color.Gold;
            this.chooseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chooseButton.FlatAppearance.BorderSize = 2;
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chooseButton.Location = new System.Drawing.Point(454, 85);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(154, 70);
            this.chooseButton.TabIndex = 342;
            this.chooseButton.Text = "مشاهده مصوبه";
            this.chooseButton.UseVisualStyleBackColor = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // exportButton4
            // 
            this.exportButton4.BackColor = System.Drawing.Color.YellowGreen;
            this.exportButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton4.BackgroundImage")));
            this.exportButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton4.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton4.FlatAppearance.BorderSize = 0;
            this.exportButton4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton4.Location = new System.Drawing.Point(454, 342);
            this.exportButton4.Name = "exportButton4";
            this.exportButton4.Size = new System.Drawing.Size(74, 82);
            this.exportButton4.TabIndex = 341;
            this.exportButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton4.UseVisualStyleBackColor = false;
            this.exportButton4.Click += new System.EventHandler(this.exportButton4_Click);
            // 
            // exportButton3
            // 
            this.exportButton3.BackColor = System.Drawing.Color.GreenYellow;
            this.exportButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton3.BackgroundImage")));
            this.exportButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton3.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton3.FlatAppearance.BorderSize = 0;
            this.exportButton3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton3.Location = new System.Drawing.Point(534, 342);
            this.exportButton3.Name = "exportButton3";
            this.exportButton3.Size = new System.Drawing.Size(74, 82);
            this.exportButton3.TabIndex = 340;
            this.exportButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton3.UseVisualStyleBackColor = false;
            this.exportButton3.Click += new System.EventHandler(this.exportButton3_Click);
            // 
            // exportButton2
            // 
            this.exportButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.exportButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton2.BackgroundImage")));
            this.exportButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton2.FlatAppearance.BorderSize = 0;
            this.exportButton2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton2.Location = new System.Drawing.Point(454, 161);
            this.exportButton2.Name = "exportButton2";
            this.exportButton2.Size = new System.Drawing.Size(74, 82);
            this.exportButton2.TabIndex = 339;
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
            this.exportButton.Location = new System.Drawing.Point(534, 161);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(74, 82);
            this.exportButton.TabIndex = 338;
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // observeBudgetsetsForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(649, 511);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.exportButton4);
            this.Controls.Add(this.exportButton3);
            this.Controls.Add(this.exportButton2);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.membersView2);
            this.Controls.Add(this.membersView);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observeBudgetsetsForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده بودجه تصویبی";
            this.Load += new System.EventHandler(this.observeBudgetsetsForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.DataGridView membersView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn consume;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Button exportButton4;
        private System.Windows.Forms.Button exportButton3;
        private System.Windows.Forms.Button exportButton2;
        private System.Windows.Forms.Button exportButton;
    }
}