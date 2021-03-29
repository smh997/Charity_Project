namespace WindowsFormsApp6
{
    partial class recHelpsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recHelpsForm));
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.recDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.packetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.helperIdTextbox = new System.Windows.Forms.RichTextBox();
            this.helperNameTextBox = new System.Windows.Forms.RichTextBox();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.cashRadioButton = new System.Windows.Forms.RadioButton();
            this.nonCashRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(129, 255);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 272;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(30, 296);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(201, 283);
            this.explainTextBox.TabIndex = 271;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            this.explainTextBox.Enter += new System.EventHandler(this.explainTextBox_Enter);
            // 
            // recDateTimePickerX
            // 
            this.recDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.recDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.recDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.recDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.recDateTimePickerX.CalendarDayRectTickness = 2F;
            this.recDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.recDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.recDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.recDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.recDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.recDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.recDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.recDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.recDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.recDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.recDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.recDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.recDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.recDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.recDateTimePickerX.CalendarShowToday = true;
            this.recDateTimePickerX.CalendarShowTodayRect = true;
            this.recDateTimePickerX.CalendarShowToolTips = false;
            this.recDateTimePickerX.CalendarShowTrailing = true;
            this.recDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.recDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.recDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.recDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.recDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.recDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.recDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.recDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.recDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.recDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.recDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.recDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.recDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.recDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.recDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.recDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.recDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.recDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.recDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.recDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.recDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.recDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.recDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.recDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("recDateTimePickerX.ClearButtonImage")));
            this.recDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.recDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.recDateTimePickerX.ClearButtonText = "";
            this.recDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recDateTimePickerX.ClearButtonToolTip = "";
            this.recDateTimePickerX.ClearButtonWidth = 17;
            this.recDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.recDateTimePickerX.CustomFormat = "";
            this.recDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.recDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.recDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.recDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.recDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.recDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.recDateTimePickerX.Location = new System.Drawing.Point(270, 223);
            this.recDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.recDateTimePickerX.Name = "recDateTimePickerX";
            this.recDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.recDateTimePickerX.RightToLeftLayout = true;
            this.recDateTimePickerX.ShowClearButton = false;
            this.recDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.recDateTimePickerX.TabIndex = 265;
            this.recDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recDateTimePickerX.TextWhenClearButtonClicked = "";
            this.recDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.recDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(453, 231);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(130, 38);
            this.label9.TabIndex = 264;
            this.label9.Text = "تاریخ دریافت:";
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
            this.feeNumericUpDown.Location = new System.Drawing.Point(270, 169);
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
            this.feeNumericUpDown.TabIndex = 263;
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
            this.label23.Location = new System.Drawing.Point(450, 169);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(115, 38);
            this.label23.TabIndex = 262;
            this.label23.Text = "ارزش ریالی:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "گوشت",
            "مرغ",
            "خواربار",
            "نقدی",
            "ازدواج",
            "ایتام",
            "متفرقه"});
            this.typeComboBox.Location = new System.Drawing.Point(270, 19);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeComboBox.Size = new System.Drawing.Size(174, 42);
            this.typeComboBox.TabIndex = 261;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(450, 23);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(100, 38);
            this.label13.TabIndex = 260;
            this.label13.Text = "نوع کمک:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(56, 105);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(174, 38);
            this.label19.TabIndex = 274;
            this.label19.Text = "نام کامل اهداکننده:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(31, 19);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(199, 38);
            this.label2.TabIndex = 276;
            this.label2.Text = "شناسه ملی اهداکننده:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.Red;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(411, 296);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 281;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(295, 288);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.docAddFileButton.TabIndex = 280;
            this.docAddFileButton.Text = "انتخاب";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(450, 292);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(107, 38);
            this.label22.TabIndex = 279;
            this.label22.Text = "فایل رسید:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // packetNumericUpDown
            // 
            this.packetNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.packetNumericUpDown.Location = new System.Drawing.Point(270, 359);
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
            this.packetNumericUpDown.TabIndex = 283;
            this.packetNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.packetNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(450, 360);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(111, 38);
            this.label3.TabIndex = 282;
            this.label3.Text = "تعداد بسته:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(202, 594);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 284;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // helperIdTextbox
            // 
            this.helperIdTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helperIdTextbox.Location = new System.Drawing.Point(31, 58);
            this.helperIdTextbox.Multiline = false;
            this.helperIdTextbox.Name = "helperIdTextbox";
            this.helperIdTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.helperIdTextbox.Size = new System.Drawing.Size(191, 44);
            this.helperIdTextbox.TabIndex = 285;
            this.helperIdTextbox.Text = "";
            this.helperIdTextbox.TextChanged += new System.EventHandler(this.helperIdTextbox_TextChanged);
            this.helperIdTextbox.Enter += new System.EventHandler(this.helperIdTextbox_Enter);
            // 
            // helperNameTextBox
            // 
            this.helperNameTextBox.Enabled = false;
            this.helperNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.helperNameTextBox.Location = new System.Drawing.Point(31, 146);
            this.helperNameTextBox.Multiline = false;
            this.helperNameTextBox.Name = "helperNameTextBox";
            this.helperNameTextBox.ReadOnly = true;
            this.helperNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.helperNameTextBox.Size = new System.Drawing.Size(191, 44);
            this.helperNameTextBox.TabIndex = 286;
            this.helperNameTextBox.Text = "";
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // bankAccountNumberTextBox
            // 
            this.bankAccountNumberTextBox.Enabled = false;
            this.bankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNumberTextBox.Location = new System.Drawing.Point(237, 535);
            this.bankAccountNumberTextBox.Multiline = false;
            this.bankAccountNumberTextBox.Name = "bankAccountNumberTextBox";
            this.bankAccountNumberTextBox.ReadOnly = true;
            this.bankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountNumberTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountNumberTextBox.TabIndex = 317;
            this.bankAccountNumberTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(450, 498);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(132, 38);
            this.label1.TabIndex = 316;
            this.label1.Text = "شماره حساب:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankAccountNameComboBox
            // 
            this.bankAccountNameComboBox.Enabled = false;
            this.bankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNameComboBox.FormattingEnabled = true;
            this.bankAccountNameComboBox.Location = new System.Drawing.Point(237, 453);
            this.bankAccountNameComboBox.Name = "bankAccountNameComboBox";
            this.bankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bankAccountNameComboBox.Size = new System.Drawing.Size(313, 42);
            this.bankAccountNameComboBox.TabIndex = 315;
            this.bankAccountNameComboBox.SelectedIndexChanged += new System.EventHandler(this.bankAccountNameComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(450, 412);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(104, 38);
            this.label4.TabIndex = 314;
            this.label4.Text = "نام حساب:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Transparent;
            this.updateButton.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.updateicon;
            this.updateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.updateButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.updateButton.FlatAppearance.BorderSize = 0;
            this.updateButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.updateButton.Location = new System.Drawing.Point(31, 196);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(48, 47);
            this.updateButton.TabIndex = 318;
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(85, 196);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(137, 47);
            this.searchButton.TabIndex = 319;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.typeGroupBox.Controls.Add(this.cashRadioButton);
            this.typeGroupBox.Controls.Add(this.nonCashRadioButton);
            this.typeGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typeGroupBox.Location = new System.Drawing.Point(270, 64);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeGroupBox.Size = new System.Drawing.Size(271, 100);
            this.typeGroupBox.TabIndex = 320;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "نقدی/غیرنقدی";
            // 
            // cashRadioButton
            // 
            this.cashRadioButton.AutoSize = true;
            this.cashRadioButton.Location = new System.Drawing.Point(178, 43);
            this.cashRadioButton.Name = "cashRadioButton";
            this.cashRadioButton.Size = new System.Drawing.Size(80, 42);
            this.cashRadioButton.TabIndex = 1;
            this.cashRadioButton.TabStop = true;
            this.cashRadioButton.Text = "نقدی";
            this.cashRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cashRadioButton.UseVisualStyleBackColor = true;
            this.cashRadioButton.CheckedChanged += new System.EventHandler(this.cashRadioButton_CheckedChanged);
            // 
            // nonCashRadioButton
            // 
            this.nonCashRadioButton.AutoSize = true;
            this.nonCashRadioButton.Location = new System.Drawing.Point(25, 43);
            this.nonCashRadioButton.Name = "nonCashRadioButton";
            this.nonCashRadioButton.Size = new System.Drawing.Size(115, 42);
            this.nonCashRadioButton.TabIndex = 2;
            this.nonCashRadioButton.TabStop = true;
            this.nonCashRadioButton.Text = "غیر نقدی";
            this.nonCashRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nonCashRadioButton.UseVisualStyleBackColor = true;
            this.nonCashRadioButton.CheckedChanged += new System.EventHandler(this.nonCashRadioButton_CheckedChanged);
            // 
            // recHelpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(591, 654);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.bankAccountNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bankAccountNameComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.helperNameTextBox);
            this.Controls.Add(this.helperIdTextbox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.packetNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.recDateTimePickerX);
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
            this.Name = "recHelpsForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت کمک دریافتی";
            this.Load += new System.EventHandler(this.recHelpsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private BehComponents.DateTimePickerX recDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown packetNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.RichTextBox helperIdTextbox;
        private System.Windows.Forms.RichTextBox helperNameTextBox;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.RichTextBox bankAccountNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bankAccountNameComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton cashRadioButton;
        private System.Windows.Forms.RadioButton nonCashRadioButton;
    }
}