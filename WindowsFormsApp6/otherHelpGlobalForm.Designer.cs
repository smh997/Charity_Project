namespace WindowsFormsApp6
{
    partial class otherHelpGlobalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(otherHelpGlobalForm));
            this.delButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.packetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.startDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cashtypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(202, 420);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 260;
            this.delButton.Text = "حذف";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(382, 318);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 259;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(15, 289);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(361, 125);
            this.explainTextBox.TabIndex = 258;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(15, 420);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 257;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(201, 232);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 51);
            this.searchButton.TabIndex = 256;
            this.searchButton.Text = "جستجو مصوبه";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(201, 176);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 50);
            this.enactmentTextbox.TabIndex = 255;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(382, 178);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 254;
            this.label8.Text = "شماره مصوبه:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // packetNumericUpDown
            // 
            this.packetNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.packetNumericUpDown.Location = new System.Drawing.Point(201, 126);
            this.packetNumericUpDown.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.packetNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.packetNumericUpDown.Name = "packetNumericUpDown";
            this.packetNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.packetNumericUpDown.Size = new System.Drawing.Size(174, 44);
            this.packetNumericUpDown.TabIndex = 253;
            this.packetNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.packetNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(381, 126);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(111, 38);
            this.label1.TabIndex = 252;
            this.label1.Text = "تعداد بسته:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startDateTimePickerX
            // 
            this.startDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.startDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.startDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.startDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.startDateTimePickerX.CalendarDayRectTickness = 2F;
            this.startDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.startDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.startDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.startDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.startDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.startDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.startDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.startDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.startDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.startDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.startDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.startDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.startDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.startDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.startDateTimePickerX.CalendarShowToday = true;
            this.startDateTimePickerX.CalendarShowTodayRect = true;
            this.startDateTimePickerX.CalendarShowToolTips = false;
            this.startDateTimePickerX.CalendarShowTrailing = true;
            this.startDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.startDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.startDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.startDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.startDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.startDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.startDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.startDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.startDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.startDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.startDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.startDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.startDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.startDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.startDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.startDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.startDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.startDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.startDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.startDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.startDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.startDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.startDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.startDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("startDateTimePickerX.ClearButtonImage")));
            this.startDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.startDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.startDateTimePickerX.ClearButtonText = "";
            this.startDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startDateTimePickerX.ClearButtonToolTip = "";
            this.startDateTimePickerX.ClearButtonWidth = 17;
            this.startDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.startDateTimePickerX.CustomFormat = "";
            this.startDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.startDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.startDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.startDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.startDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.startDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.startDateTimePickerX.Location = new System.Drawing.Point(18, 225);
            this.startDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.startDateTimePickerX.Name = "startDateTimePickerX";
            this.startDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startDateTimePickerX.RightToLeftLayout = true;
            this.startDateTimePickerX.ShowClearButton = false;
            this.startDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.startDateTimePickerX.TabIndex = 251;
            this.startDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startDateTimePickerX.TextWhenClearButtonClicked = "";
            this.startDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.startDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(57, 176);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(119, 38);
            this.label9.TabIndex = 250;
            this.label9.Text = "تاریخ شروع:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feeNumericUpDown
            // 
            this.feeNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.feeNumericUpDown.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.feeNumericUpDown.Location = new System.Drawing.Point(201, 71);
            this.feeNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.feeNumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.feeNumericUpDown.Name = "feeNumericUpDown";
            this.feeNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.feeNumericUpDown.Size = new System.Drawing.Size(174, 44);
            this.feeNumericUpDown.TabIndex = 249;
            this.feeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.feeNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label23.Location = new System.Drawing.Point(381, 71);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(115, 38);
            this.label23.TabIndex = 248;
            this.label23.Text = "ارزش ریالی:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "ایتام",
            "دانش آموزان",
            "بیماران خاص",
            "همه افراد",
            "همه خانوارها"});
            this.typeComboBox.Location = new System.Drawing.Point(201, 15);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeComboBox.Size = new System.Drawing.Size(174, 42);
            this.typeComboBox.TabIndex = 247;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(381, 19);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(150, 38);
            this.label13.TabIndex = 246;
            this.label13.Text = "دریافت‌کنندگان:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(130, 71);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(51, 38);
            this.label2.TabIndex = 261;
            this.label2.Text = "نوع:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cashtypeComboBox
            // 
            this.cashtypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashtypeComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cashtypeComboBox.FormattingEnabled = true;
            this.cashtypeComboBox.Items.AddRange(new object[] {
            "نقدی",
            "غیرنقدی"});
            this.cashtypeComboBox.Location = new System.Drawing.Point(18, 125);
            this.cashtypeComboBox.Name = "cashtypeComboBox";
            this.cashtypeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cashtypeComboBox.Size = new System.Drawing.Size(174, 42);
            this.cashtypeComboBox.TabIndex = 262;
            // 
            // otherHelpGlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(529, 479);
            this.Controls.Add(this.cashtypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.packetNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.feeNumericUpDown);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "otherHelpGlobalForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعریف کمک متفرقه گروهی";
            this.Load += new System.EventHandler(this.otherHelpGlobalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown packetNumericUpDown;
        private System.Windows.Forms.Label label1;
        private BehComponents.DateTimePickerX startDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cashtypeComboBox;
    }
}