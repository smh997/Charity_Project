namespace WindowsFormsApp6
{
    partial class observeDocForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observeDocForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.docdataGridViewX = new BehComponents.DataGridViewX(this.components);
            this.visitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.docdataGridViewX)).BeginInit();
            this.SuspendLayout();
            // 
            // docdataGridViewX
            // 
            this.docdataGridViewX.AllowUserToAddRows = false;
            this.docdataGridViewX.AllowUserToDeleteRows = false;
            this.docdataGridViewX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.docdataGridViewX.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.docdataGridViewX.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.docdataGridViewX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.docdataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docdataGridViewX.Columns_EnglishDate = ((System.Collections.Generic.List<string>)(resources.GetObject("docdataGridViewX.Columns_EnglishDate")));
            this.docdataGridViewX.Columns_PersianDate = ((System.Collections.Generic.List<string>)(resources.GetObject("docdataGridViewX.Columns_PersianDate")));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.docdataGridViewX.DefaultCellStyle = dataGridViewCellStyle2;
            this.docdataGridViewX.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.docdataGridViewX.Location = new System.Drawing.Point(32, 25);
            this.docdataGridViewX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.docdataGridViewX.MultiSelect = false;
            this.docdataGridViewX.Name = "docdataGridViewX";
            this.docdataGridViewX.ReadOnly = true;
            this.docdataGridViewX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.docdataGridViewX.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docdataGridViewX.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.docdataGridViewX.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.docdataGridViewX.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docdataGridViewX.RowTemplate.Height = 24;
            this.docdataGridViewX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.docdataGridViewX.Size = new System.Drawing.Size(447, 364);
            this.docdataGridViewX.TabIndex = 138;
            this.docdataGridViewX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.docdataGridViewX_CellClick);
            this.docdataGridViewX.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.docdataGridViewX_ColumnHeaderMouseClick);
            this.docdataGridViewX.SelectionChanged += new System.EventHandler(this.docdataGridViewX_SelectionChanged);
            // 
            // visitButton
            // 
            this.visitButton.BackColor = System.Drawing.Color.Aquamarine;
            this.visitButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.visitButton.FlatAppearance.BorderSize = 2;
            this.visitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitButton.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.visitButton.Location = new System.Drawing.Point(500, 54);
            this.visitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.visitButton.Name = "visitButton";
            this.visitButton.Size = new System.Drawing.Size(112, 77);
            this.visitButton.TabIndex = 181;
            this.visitButton.Text = "مشاهده";
            this.visitButton.UseVisualStyleBackColor = false;
            this.visitButton.Click += new System.EventHandler(this.visitButton_Click);
            // 
            // observeDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(641, 427);
            this.Controls.Add(this.visitButton);
            this.Controls.Add(this.docdataGridViewX);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observeDocForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده";
            this.Load += new System.EventHandler(this.observeDocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docdataGridViewX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BehComponents.DataGridViewX docdataGridViewX;
        private System.Windows.Forms.Button visitButton;
    }
}