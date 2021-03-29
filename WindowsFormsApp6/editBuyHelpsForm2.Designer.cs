namespace WindowsFormsApp6
{
    partial class editBuyHelpsForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editBuyHelpsForm2));
            this.bankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buyerNameTextBox = new System.Windows.Forms.RichTextBox();
            this.packetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.buyDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.feeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.seachEnactmentbutton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bankAccountNumberTextBox
            // 
            this.bankAccountNumberTextBox.Enabled = false;
            this.bankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNumberTextBox.Location = new System.Drawing.Point(230, 369);
            this.bankAccountNumberTextBox.Multiline = false;
            this.bankAccountNumberTextBox.Name = "bankAccountNumberTextBox";
            this.bankAccountNumberTextBox.ReadOnly = true;
            this.bankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountNumberTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountNumberTextBox.TabIndex = 361;
            this.bankAccountNumberTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(438, 332);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(132, 38);
            this.label1.TabIndex = 360;
            this.label1.Text = "شماره حساب:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankAccountNameComboBox
            // 
            this.bankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNameComboBox.FormattingEnabled = true;
            this.bankAccountNameComboBox.Location = new System.Drawing.Point(230, 287);
            this.bankAccountNameComboBox.Name = "bankAccountNameComboBox";
            this.bankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bankAccountNameComboBox.Size = new System.Drawing.Size(313, 42);
            this.bankAccountNameComboBox.TabIndex = 359;
            this.bankAccountNameComboBox.SelectedIndexChanged += new System.EventHandler(this.bankAccountNameComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(443, 246);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(104, 38);
            this.label4.TabIndex = 358;
            this.label4.Text = "نام حساب:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buyerNameTextBox
            // 
            this.buyerNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buyerNameTextBox.Location = new System.Drawing.Point(22, 62);
            this.buyerNameTextBox.Multiline = false;
            this.buyerNameTextBox.Name = "buyerNameTextBox";
            this.buyerNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.buyerNameTextBox.Size = new System.Drawing.Size(191, 44);
            this.buyerNameTextBox.TabIndex = 357;
            this.buyerNameTextBox.Text = "";
            this.buyerNameTextBox.TextChanged += new System.EventHandler(this.buyerNameTextBox_TextChanged);
            this.buyerNameTextBox.Enter += new System.EventHandler(this.buyerNameTextBox_Enter);
            // 
            // packetNumericUpDown
            // 
            this.packetNumericUpDown.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.packetNumericUpDown.Location = new System.Drawing.Point(22, 150);
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
            this.packetNumericUpDown.Size = new System.Drawing.Size(191, 44);
            this.packetNumericUpDown.TabIndex = 355;
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
            this.label3.Location = new System.Drawing.Point(103, 109);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(111, 38);
            this.label3.TabIndex = 354;
            this.label3.Text = "تعداد بسته:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(396, 209);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 353;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(280, 201);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.docAddFileButton.TabIndex = 352;
            this.docAddFileButton.Text = "انتخاب";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(435, 205);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(107, 38);
            this.label22.TabIndex = 351;
            this.label22.Text = "فایل رسید:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(63, 21);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(151, 38);
            this.label19.TabIndex = 350;
            this.label19.Text = "نام کامل خریدار:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(113, 203);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 349;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(15, 244);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(201, 180);
            this.explainTextBox.TabIndex = 348;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            this.explainTextBox.Enter += new System.EventHandler(this.explainTextBox_Enter);
            // 
            // buyDateTimePickerX
            // 
            this.buyDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.buyDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.buyDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.buyDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.buyDateTimePickerX.CalendarDayRectTickness = 2F;
            this.buyDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.buyDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buyDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.buyDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.buyDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.buyDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.buyDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.buyDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.buyDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.buyDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.buyDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.buyDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.buyDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.buyDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.buyDateTimePickerX.CalendarShowToday = true;
            this.buyDateTimePickerX.CalendarShowTodayRect = true;
            this.buyDateTimePickerX.CalendarShowToolTips = false;
            this.buyDateTimePickerX.CalendarShowTrailing = true;
            this.buyDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.buyDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.buyDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.buyDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.buyDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.buyDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.buyDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.buyDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.buyDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.buyDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.buyDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.buyDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.buyDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.buyDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.buyDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.buyDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.buyDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.buyDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.buyDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.buyDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.buyDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.buyDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.buyDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.buyDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("buyDateTimePickerX.ClearButtonImage")));
            this.buyDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buyDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.buyDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.buyDateTimePickerX.ClearButtonText = "";
            this.buyDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buyDateTimePickerX.ClearButtonToolTip = "";
            this.buyDateTimePickerX.ClearButtonWidth = 17;
            this.buyDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.buyDateTimePickerX.CustomFormat = "";
            this.buyDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.buyDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.buyDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.buyDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buyDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.buyDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.buyDateTimePickerX.Location = new System.Drawing.Point(255, 136);
            this.buyDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.buyDateTimePickerX.Name = "buyDateTimePickerX";
            this.buyDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buyDateTimePickerX.RightToLeftLayout = true;
            this.buyDateTimePickerX.ShowClearButton = false;
            this.buyDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.buyDateTimePickerX.TabIndex = 347;
            this.buyDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buyDateTimePickerX.TextWhenClearButtonClicked = "";
            this.buyDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.buyDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(438, 144);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(114, 38);
            this.label9.TabIndex = 346;
            this.label9.Text = "تاریخ خرید:";
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
            this.feeNumericUpDown.Location = new System.Drawing.Point(255, 74);
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
            this.feeNumericUpDown.TabIndex = 345;
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
            this.label23.Location = new System.Drawing.Point(435, 74);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(115, 38);
            this.label23.TabIndex = 344;
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
            "اداری فرهنگی",
            "متفرقه"});
            this.typeComboBox.Location = new System.Drawing.Point(255, 17);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeComboBox.Size = new System.Drawing.Size(174, 42);
            this.typeComboBox.TabIndex = 343;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(435, 21);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(100, 38);
            this.label13.TabIndex = 342;
            this.label13.Text = "نوع کمک:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Aquamarine;
            this.showButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.showButton.FlatAppearance.BorderSize = 2;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showButton.Location = new System.Drawing.Point(22, 495);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(200, 51);
            this.showButton.TabIndex = 366;
            this.showButton.Text = "نمایش فایل رسید";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(255, 427);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 50);
            this.enactmentTextbox.TabIndex = 364;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(438, 429);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 363;
            this.label8.Text = "شماره مصوبه:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seachEnactmentbutton
            // 
            this.seachEnactmentbutton.BackColor = System.Drawing.Color.Orange;
            this.seachEnactmentbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.seachEnactmentbutton.FlatAppearance.BorderSize = 2;
            this.seachEnactmentbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seachEnactmentbutton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.seachEnactmentbutton.Location = new System.Drawing.Point(255, 498);
            this.seachEnactmentbutton.Name = "seachEnactmentbutton";
            this.seachEnactmentbutton.Size = new System.Drawing.Size(174, 51);
            this.seachEnactmentbutton.TabIndex = 365;
            this.seachEnactmentbutton.Text = "جستجو مصوبه";
            this.seachEnactmentbutton.UseVisualStyleBackColor = false;
            this.seachEnactmentbutton.Click += new System.EventHandler(this.seachEnactmentbutton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.Enabled = false;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(33, 430);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 362;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // editBuyHelpsForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(591, 558);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.seachEnactmentbutton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bankAccountNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bankAccountNameComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buyerNameTextBox);
            this.Controls.Add(this.packetNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.buyDateTimePickerX);
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
            this.Name = "editBuyHelpsForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش کمک خریده‌شده";
            this.Load += new System.EventHandler(this.editBuyHelpsForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox bankAccountNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bankAccountNameComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox buyerNameTextBox;
        private System.Windows.Forms.NumericUpDown packetNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private BehComponents.DateTimePickerX buyDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown feeNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button seachEnactmentbutton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
    }
}