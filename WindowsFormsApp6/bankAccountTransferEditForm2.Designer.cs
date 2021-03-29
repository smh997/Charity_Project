namespace WindowsFormsApp6
{
    partial class bankAccountTransferEditForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bankAccountTransferEditForm2));
            this.taxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dstBankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dstBankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.srcBankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.srcBankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.transporterNameTextBox = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.transferDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // taxNumericUpDown
            // 
            this.taxNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.taxNumericUpDown.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.taxNumericUpDown.Location = new System.Drawing.Point(44, 245);
            this.taxNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.taxNumericUpDown.Name = "taxNumericUpDown";
            this.taxNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.taxNumericUpDown.Size = new System.Drawing.Size(174, 44);
            this.taxNumericUpDown.TabIndex = 338;
            this.taxNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.taxNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(77, 204);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(148, 38);
            this.label5.TabIndex = 337;
            this.label5.Text = "کارمزد(به ریال):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(380, 159);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(183, 38);
            this.label3.TabIndex = 336;
            this.label3.Text = "شماره حساب مقصد:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dstBankAccountNumberTextBox
            // 
            this.dstBankAccountNumberTextBox.Enabled = false;
            this.dstBankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dstBankAccountNumberTextBox.Location = new System.Drawing.Point(28, 157);
            this.dstBankAccountNumberTextBox.Multiline = false;
            this.dstBankAccountNumberTextBox.Name = "dstBankAccountNumberTextBox";
            this.dstBankAccountNumberTextBox.ReadOnly = true;
            this.dstBankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.dstBankAccountNumberTextBox.Size = new System.Drawing.Size(347, 44);
            this.dstBankAccountNumberTextBox.TabIndex = 335;
            this.dstBankAccountNumberTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(408, 109);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(155, 38);
            this.label4.TabIndex = 334;
            this.label4.Text = "نام حساب مقصد:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dstBankAccountNameComboBox
            // 
            this.dstBankAccountNameComboBox.Enabled = false;
            this.dstBankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dstBankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dstBankAccountNameComboBox.FormattingEnabled = true;
            this.dstBankAccountNameComboBox.Location = new System.Drawing.Point(28, 109);
            this.dstBankAccountNameComboBox.Name = "dstBankAccountNameComboBox";
            this.dstBankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dstBankAccountNameComboBox.Size = new System.Drawing.Size(347, 42);
            this.dstBankAccountNameComboBox.TabIndex = 333;
            this.dstBankAccountNameComboBox.SelectedIndexChanged += new System.EventHandler(this.dstBankAccountNameComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(392, 60);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(171, 38);
            this.label1.TabIndex = 332;
            this.label1.Text = "شماره حساب مبدا:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // srcBankAccountNumberTextBox
            // 
            this.srcBankAccountNumberTextBox.Enabled = false;
            this.srcBankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.srcBankAccountNumberTextBox.Location = new System.Drawing.Point(28, 58);
            this.srcBankAccountNumberTextBox.Multiline = false;
            this.srcBankAccountNumberTextBox.Name = "srcBankAccountNumberTextBox";
            this.srcBankAccountNumberTextBox.ReadOnly = true;
            this.srcBankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.srcBankAccountNumberTextBox.Size = new System.Drawing.Size(347, 44);
            this.srcBankAccountNumberTextBox.TabIndex = 331;
            this.srcBankAccountNumberTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(420, 10);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(143, 38);
            this.label2.TabIndex = 330;
            this.label2.Text = "نام حساب مبدا:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // srcBankAccountNameComboBox
            // 
            this.srcBankAccountNameComboBox.Enabled = false;
            this.srcBankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srcBankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.srcBankAccountNameComboBox.FormattingEnabled = true;
            this.srcBankAccountNameComboBox.Location = new System.Drawing.Point(28, 10);
            this.srcBankAccountNameComboBox.Name = "srcBankAccountNameComboBox";
            this.srcBankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.srcBankAccountNameComboBox.Size = new System.Drawing.Size(347, 42);
            this.srcBankAccountNameComboBox.TabIndex = 329;
            this.srcBankAccountNameComboBox.SelectedIndexChanged += new System.EventHandler(this.srcBankAccountNameComboBox_SelectedIndexChanged);
            // 
            // transporterNameTextBox
            // 
            this.transporterNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.transporterNameTextBox.Location = new System.Drawing.Point(28, 335);
            this.transporterNameTextBox.Multiline = false;
            this.transporterNameTextBox.Name = "transporterNameTextBox";
            this.transporterNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.transporterNameTextBox.Size = new System.Drawing.Size(224, 44);
            this.transporterNameTextBox.TabIndex = 328;
            this.transporterNameTextBox.Text = "";
            this.transporterNameTextBox.TextChanged += new System.EventHandler(this.transporterNameTextBox_TextChanged);
            this.transporterNameTextBox.Enter += new System.EventHandler(this.transporterNameTextBox_Enter);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.Enabled = false;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(114, 569);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 327;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(391, 340);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 326;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(275, 332);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.docAddFileButton.TabIndex = 325;
            this.docAddFileButton.Text = "انتخاب";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(430, 336);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(107, 38);
            this.label22.TabIndex = 324;
            this.label22.Text = "فایل رسید:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(44, 292);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(191, 38);
            this.label19.TabIndex = 323;
            this.label19.Text = "نام کامل انتقال‌دهنده:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(260, 387);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 322;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(28, 385);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(224, 178);
            this.explainTextBox.TabIndex = 321;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            this.explainTextBox.Enter += new System.EventHandler(this.explainTextBox_Enter);
            // 
            // transferDateTimePickerX
            // 
            this.transferDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.transferDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.transferDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.transferDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.transferDateTimePickerX.CalendarDayRectTickness = 2F;
            this.transferDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.transferDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.transferDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.transferDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.transferDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.transferDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.transferDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.transferDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.transferDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.transferDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.transferDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.transferDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.transferDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.transferDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.transferDateTimePickerX.CalendarShowToday = true;
            this.transferDateTimePickerX.CalendarShowTodayRect = true;
            this.transferDateTimePickerX.CalendarShowToolTips = false;
            this.transferDateTimePickerX.CalendarShowTrailing = true;
            this.transferDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.transferDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.transferDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.transferDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.transferDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.transferDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.transferDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.transferDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.transferDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.transferDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.transferDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.transferDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.transferDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.transferDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.transferDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.transferDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.transferDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.transferDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.transferDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.transferDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.transferDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.transferDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.transferDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.transferDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("transferDateTimePickerX.ClearButtonImage")));
            this.transferDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.transferDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.transferDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.transferDateTimePickerX.ClearButtonText = "";
            this.transferDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.transferDateTimePickerX.ClearButtonToolTip = "";
            this.transferDateTimePickerX.ClearButtonWidth = 17;
            this.transferDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.transferDateTimePickerX.CustomFormat = "";
            this.transferDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.transferDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.transferDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.transferDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.transferDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.transferDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.transferDateTimePickerX.Location = new System.Drawing.Point(250, 274);
            this.transferDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.transferDateTimePickerX.Name = "transferDateTimePickerX";
            this.transferDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.transferDateTimePickerX.RightToLeftLayout = true;
            this.transferDateTimePickerX.ShowClearButton = false;
            this.transferDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.transferDateTimePickerX.TabIndex = 320;
            this.transferDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transferDateTimePickerX.TextWhenClearButtonClicked = "";
            this.transferDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.transferDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(430, 282);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(118, 38);
            this.label9.TabIndex = 319;
            this.label9.Text = "تاریخ انتقال:";
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
            this.feeNumericUpDown.Location = new System.Drawing.Point(250, 220);
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
            this.feeNumericUpDown.TabIndex = 318;
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
            this.label23.Location = new System.Drawing.Point(430, 220);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(131, 38);
            this.label23.TabIndex = 317;
            this.label23.Text = "مبلغ(به ریال):";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Aquamarine;
            this.showButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.showButton.FlatAppearance.BorderSize = 2;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showButton.Location = new System.Drawing.Point(310, 569);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(200, 51);
            this.showButton.TabIndex = 339;
            this.showButton.Text = "نمایش فایل رسید";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(260, 444);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 50);
            this.enactmentTextbox.TabIndex = 341;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(435, 444);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 340;
            this.label8.Text = "شماره مصوبه:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Orange;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(260, 500);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 51);
            this.searchButton.TabIndex = 342;
            this.searchButton.Text = "جستجو مصوبه";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // bankAccountTransferEditForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(570, 632);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.taxNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dstBankAccountNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dstBankAccountNameComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.srcBankAccountNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.srcBankAccountNameComboBox);
            this.Controls.Add(this.transporterNameTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.transferDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.feeNumericUpDown);
            this.Controls.Add(this.label23);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bankAccountTransferEditForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش انتقال وجه";
            this.Load += new System.EventHandler(this.bankAccountTransferEditForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown taxNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox dstBankAccountNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dstBankAccountNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox srcBankAccountNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox srcBankAccountNameComboBox;
        private System.Windows.Forms.RichTextBox transporterNameTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private BehComponents.DateTimePickerX transferDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button searchButton;
    }
}