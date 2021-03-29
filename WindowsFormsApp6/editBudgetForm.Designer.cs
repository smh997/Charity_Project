namespace WindowsFormsApp6
{
    partial class editBudgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editBudgetForm));
            this.searchButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.othersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.eduNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.healNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groceryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.breadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.marryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cultureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.healFamilyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.breadFamilyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.othersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eduNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groceryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breadNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cultureNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healFamilyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breadFamilyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(393, 269);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(158, 51);
            this.searchButton.TabIndex = 257;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.Enabled = false;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(342, 374);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(158, 51);
            this.setButton.TabIndex = 256;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(259, 227);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(163, 38);
            this.enactmentTextbox.TabIndex = 255;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(430, 227);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 254;
            this.label8.Text = "شماره مصوبه:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(159, 180);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(77, 38);
            this.label7.TabIndex = 253;
            this.label7.Text = "متفرقه:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // othersNumericUpDown
            // 
            this.othersNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.othersNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.othersNumericUpDown.Location = new System.Drawing.Point(20, 179);
            this.othersNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.othersNumericUpDown.Name = "othersNumericUpDown";
            this.othersNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.othersNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.othersNumericUpDown.TabIndex = 252;
            this.othersNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.othersNumericUpDown.ThousandsSeparator = true;
            // 
            // eduNumericUpDown
            // 
            this.eduNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.eduNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.eduNumericUpDown.Location = new System.Drawing.Point(259, 78);
            this.eduNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.eduNumericUpDown.Name = "eduNumericUpDown";
            this.eduNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eduNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.eduNumericUpDown.TabIndex = 251;
            this.eduNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.eduNumericUpDown.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(398, 79);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(89, 38);
            this.label6.TabIndex = 250;
            this.label6.Text = "آموزشی:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // healNumericUpDown
            // 
            this.healNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.healNumericUpDown.Location = new System.Drawing.Point(259, 128);
            this.healNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.healNumericUpDown.Name = "healNumericUpDown";
            this.healNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.healNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.healNumericUpDown.TabIndex = 247;
            this.healNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healNumericUpDown.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(398, 129);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(71, 38);
            this.label4.TabIndex = 246;
            this.label4.Text = "درمان:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groceryNumericUpDown
            // 
            this.groceryNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groceryNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.groceryNumericUpDown.Location = new System.Drawing.Point(20, 27);
            this.groceryNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.groceryNumericUpDown.Name = "groceryNumericUpDown";
            this.groceryNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groceryNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.groceryNumericUpDown.TabIndex = 245;
            this.groceryNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.groceryNumericUpDown.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(159, 28);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(80, 38);
            this.label3.TabIndex = 244;
            this.label3.Text = "خواربار:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // breadNumericUpDown
            // 
            this.breadNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.breadNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.breadNumericUpDown.Location = new System.Drawing.Point(20, 77);
            this.breadNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.breadNumericUpDown.Name = "breadNumericUpDown";
            this.breadNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.breadNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.breadNumericUpDown.TabIndex = 243;
            this.breadNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.breadNumericUpDown.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(159, 128);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(83, 38);
            this.label2.TabIndex = 242;
            this.label2.Text = "جهیزیه:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // marryNumericUpDown
            // 
            this.marryNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marryNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.marryNumericUpDown.Location = new System.Drawing.Point(20, 127);
            this.marryNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.marryNumericUpDown.Name = "marryNumericUpDown";
            this.marryNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.marryNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.marryNumericUpDown.TabIndex = 241;
            this.marryNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.marryNumericUpDown.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(159, 78);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(48, 38);
            this.label1.TabIndex = 240;
            this.label1.Text = "نان:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cultureNumericUpDown
            // 
            this.cultureNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cultureNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cultureNumericUpDown.Location = new System.Drawing.Point(259, 28);
            this.cultureNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.cultureNumericUpDown.Name = "cultureNumericUpDown";
            this.cultureNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cultureNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.cultureNumericUpDown.TabIndex = 239;
            this.cultureNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cultureNumericUpDown.ThousandsSeparator = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label23.Location = new System.Drawing.Point(398, 29);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(151, 38);
            this.label23.TabIndex = 238;
            this.label23.Text = "فرهنگی و اداری:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(260, 278);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(101, 38);
            this.label9.TabIndex = 258;
            this.label9.Text = "توضیحات:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(20, 276);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(234, 192);
            this.explainTextBox.TabIndex = 259;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            // 
            // healFamilyNumericUpDown
            // 
            this.healFamilyNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healFamilyNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.healFamilyNumericUpDown.Location = new System.Drawing.Point(259, 177);
            this.healFamilyNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.healFamilyNumericUpDown.Name = "healFamilyNumericUpDown";
            this.healFamilyNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.healFamilyNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.healFamilyNumericUpDown.TabIndex = 263;
            this.healFamilyNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healFamilyNumericUpDown.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(398, 179);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(125, 38);
            this.label5.TabIndex = 262;
            this.label5.Text = "درمان خانوار:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // breadFamilyNumericUpDown
            // 
            this.breadFamilyNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.breadFamilyNumericUpDown.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.breadFamilyNumericUpDown.Location = new System.Drawing.Point(20, 227);
            this.breadFamilyNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.breadFamilyNumericUpDown.Name = "breadFamilyNumericUpDown";
            this.breadFamilyNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.breadFamilyNumericUpDown.Size = new System.Drawing.Size(133, 44);
            this.breadFamilyNumericUpDown.TabIndex = 261;
            this.breadFamilyNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.breadFamilyNumericUpDown.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(159, 228);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(102, 38);
            this.label10.TabIndex = 260;
            this.label10.Text = "نان خانوار:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(558, 488);
            this.Controls.Add(this.healFamilyNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.breadFamilyNumericUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.othersNumericUpDown);
            this.Controls.Add(this.eduNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.healNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groceryNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.breadNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.marryNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cultureNumericUpDown);
            this.Controls.Add(this.label23);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editBudgetForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش بودجه";
            this.Load += new System.EventHandler(this.editBudgetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.othersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eduNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groceryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breadNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cultureNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healFamilyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breadFamilyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown othersNumericUpDown;
        private System.Windows.Forms.NumericUpDown eduNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown healNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown groceryNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown breadNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown marryNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cultureNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.NumericUpDown healFamilyNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown breadFamilyNumericUpDown;
        private System.Windows.Forms.Label label10;
    }
}