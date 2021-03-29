namespace WindowsFormsApp6
{
    partial class observeMarryHelpsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(observeMarryHelpsForm));
            this.bankAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.recCheckBox = new System.Windows.Forms.CheckBox();
            this.sendCheckBox = new System.Windows.Forms.CheckBox();
            this.endedradCheckBox = new System.Windows.Forms.CheckBox();
            this.presCheckBox = new System.Windows.Forms.CheckBox();
            this.endedCheckBox = new System.Windows.Forms.CheckBox();
            this.accCheckBox = new System.Windows.Forms.CheckBox();
            this.membersView = new System.Windows.Forms.DataGridView();
            this.exportButton2 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.endDateTimePickerX = new BehComponents.DateTimePickerX();
            this.startDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cashGroupBox = new System.Windows.Forms.GroupBox();
            this.otherCheckBox = new System.Windows.Forms.CheckBox();
            this.noncashTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.cashTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.statusGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            this.cashGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bankAccountNameComboBox
            // 
            this.bankAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bankAccountNameComboBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNameComboBox.FormattingEnabled = true;
            this.bankAccountNameComboBox.Location = new System.Drawing.Point(73, 218);
            this.bankAccountNameComboBox.Name = "bankAccountNameComboBox";
            this.bankAccountNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bankAccountNameComboBox.Size = new System.Drawing.Size(304, 42);
            this.bankAccountNameComboBox.TabIndex = 408;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(280, 167);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(104, 38);
            this.label4.TabIndex = 407;
            this.label4.Text = "نام حساب:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.BackColor = System.Drawing.Color.SkyBlue;
            this.statusGroupBox.Controls.Add(this.recCheckBox);
            this.statusGroupBox.Controls.Add(this.sendCheckBox);
            this.statusGroupBox.Controls.Add(this.endedradCheckBox);
            this.statusGroupBox.Controls.Add(this.presCheckBox);
            this.statusGroupBox.Controls.Add(this.endedCheckBox);
            this.statusGroupBox.Controls.Add(this.accCheckBox);
            this.statusGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.statusGroupBox.Location = new System.Drawing.Point(66, 23);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusGroupBox.Size = new System.Drawing.Size(492, 126);
            this.statusGroupBox.TabIndex = 401;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "وضعیت";
            // 
            // recCheckBox
            // 
            this.recCheckBox.AutoSize = true;
            this.recCheckBox.Checked = true;
            this.recCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.recCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.recCheckBox.Location = new System.Drawing.Point(27, 45);
            this.recCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recCheckBox.Name = "recCheckBox";
            this.recCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.recCheckBox.Size = new System.Drawing.Size(149, 42);
            this.recCheckBox.TabIndex = 357;
            this.recCheckBox.Text = "دریافت نتیجه";
            this.recCheckBox.UseVisualStyleBackColor = true;
            this.recCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
            // 
            // sendCheckBox
            // 
            this.sendCheckBox.AutoSize = true;
            this.sendCheckBox.Checked = true;
            this.sendCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.sendCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sendCheckBox.Location = new System.Drawing.Point(201, 45);
            this.sendCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendCheckBox.Name = "sendCheckBox";
            this.sendCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sendCheckBox.Size = new System.Drawing.Size(176, 42);
            this.sendCheckBox.TabIndex = 356;
            this.sendCheckBox.Text = "ارسال معرفی‌نامه";
            this.sendCheckBox.UseVisualStyleBackColor = true;
            this.sendCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
            // 
            // endedradCheckBox
            // 
            this.endedradCheckBox.AutoSize = true;
            this.endedradCheckBox.Checked = true;
            this.endedradCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.endedradCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.endedradCheckBox.Location = new System.Drawing.Point(27, 82);
            this.endedradCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endedradCheckBox.Name = "endedradCheckBox";
            this.endedradCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.endedradCheckBox.Size = new System.Drawing.Size(237, 42);
            this.endedradCheckBox.TabIndex = 355;
            this.endedradCheckBox.Text = "پایان‌یافته: رد معرفی‌نامه";
            this.endedradCheckBox.UseVisualStyleBackColor = true;
            this.endedradCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
            // 
            // presCheckBox
            // 
            this.presCheckBox.AutoSize = true;
            this.presCheckBox.Checked = true;
            this.presCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.presCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.presCheckBox.Location = new System.Drawing.Point(404, 45);
            this.presCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.presCheckBox.Name = "presCheckBox";
            this.presCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.presCheckBox.Size = new System.Drawing.Size(74, 42);
            this.presCheckBox.TabIndex = 354;
            this.presCheckBox.Text = "ارائه";
            this.presCheckBox.UseVisualStyleBackColor = true;
            this.presCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
            // 
            // endedCheckBox
            // 
            this.endedCheckBox.AutoSize = true;
            this.endedCheckBox.Checked = true;
            this.endedCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.endedCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.endedCheckBox.Location = new System.Drawing.Point(272, 82);
            this.endedCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endedCheckBox.Name = "endedCheckBox";
            this.endedCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.endedCheckBox.Size = new System.Drawing.Size(206, 42);
            this.endedCheckBox.TabIndex = 353;
            this.endedCheckBox.Text = "پایان‌یافته: ارائه شده";
            this.endedCheckBox.UseVisualStyleBackColor = true;
            this.endedCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
            // 
            // accCheckBox
            // 
            this.accCheckBox.AutoSize = true;
            this.accCheckBox.Checked = true;
            this.accCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.accCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.accCheckBox.Location = new System.Drawing.Point(272, 45);
            this.accCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accCheckBox.Name = "accCheckBox";
            this.accCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accCheckBox.Size = new System.Drawing.Size(84, 42);
            this.accCheckBox.TabIndex = 352;
            this.accCheckBox.Text = "نهایی";
            this.accCheckBox.UseVisualStyleBackColor = true;
            this.accCheckBox.CheckedChanged += new System.EventHandler(this.presCheckBox_CheckedChanged);
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
            this.membersView.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.membersView.Location = new System.Drawing.Point(36, 357);
            this.membersView.MultiSelect = false;
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.membersView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.membersView.Size = new System.Drawing.Size(775, 248);
            this.membersView.TabIndex = 406;
            this.membersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.membersView_CellClick);
            this.membersView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.membersView_ColumnHeaderMouseClick);
            this.membersView.SelectionChanged += new System.EventHandler(this.membersView_SelectionChanged);
            // 
            // exportButton2
            // 
            this.exportButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.exportButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportButton2.BackgroundImage")));
            this.exportButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.exportButton2.FlatAppearance.BorderSize = 0;
            this.exportButton2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exportButton2.Location = new System.Drawing.Point(155, 267);
            this.exportButton2.Name = "exportButton2";
            this.exportButton2.Size = new System.Drawing.Size(74, 82);
            this.exportButton2.TabIndex = 405;
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
            this.exportButton.Location = new System.Drawing.Point(75, 267);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(74, 82);
            this.exportButton.TabIndex = 404;
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.BackColor = System.Drawing.Color.Gold;
            this.chooseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chooseButton.FlatAppearance.BorderSize = 2;
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chooseButton.Location = new System.Drawing.Point(583, 304);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(170, 47);
            this.chooseButton.TabIndex = 403;
            this.chooseButton.Text = "انتخاب";
            this.chooseButton.UseVisualStyleBackColor = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.GreenYellow;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchButton.Location = new System.Drawing.Point(404, 304);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(170, 47);
            this.searchButton.TabIndex = 402;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // endDateTimePickerX
            // 
            this.endDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.endDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.endDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.endDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.endDateTimePickerX.CalendarDayRectTickness = 2F;
            this.endDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.endDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.endDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.endDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.endDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.endDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.endDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.endDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.endDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.endDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.endDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.endDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.endDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.endDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.endDateTimePickerX.CalendarShowToday = true;
            this.endDateTimePickerX.CalendarShowTodayRect = true;
            this.endDateTimePickerX.CalendarShowToolTips = false;
            this.endDateTimePickerX.CalendarShowTrailing = true;
            this.endDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.endDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.endDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.endDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.endDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.endDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.endDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.endDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.endDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.endDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.endDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.endDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.endDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.endDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.endDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.endDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.endDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.endDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.endDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.endDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.endDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.endDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.endDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.endDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("endDateTimePickerX.ClearButtonImage")));
            this.endDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.endDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.endDateTimePickerX.ClearButtonText = "";
            this.endDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endDateTimePickerX.ClearButtonToolTip = "";
            this.endDateTimePickerX.ClearButtonWidth = 17;
            this.endDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.endDateTimePickerX.CustomFormat = "";
            this.endDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.endDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.endDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.endDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.endDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.endDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.endDateTimePickerX.Location = new System.Drawing.Point(583, 99);
            this.endDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.endDateTimePickerX.Name = "endDateTimePickerX";
            this.endDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.endDateTimePickerX.RightToLeftLayout = true;
            this.endDateTimePickerX.ShowClearButton = false;
            this.endDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.endDateTimePickerX.TabIndex = 400;
            this.endDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.endDateTimePickerX.TextWhenClearButtonClicked = "";
            this.endDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.endDateTimePickerX_SelectedDateChanged);
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
            this.startDateTimePickerX.Location = new System.Drawing.Point(583, 43);
            this.startDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.startDateTimePickerX.Name = "startDateTimePickerX";
            this.startDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startDateTimePickerX.RightToLeftLayout = true;
            this.startDateTimePickerX.ShowClearButton = false;
            this.startDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.startDateTimePickerX.TabIndex = 399;
            this.startDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startDateTimePickerX.TextWhenClearButtonClicked = "";
            this.startDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.startDateTimePickerX_SelectedDateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(755, 105);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(63, 38);
            this.label1.TabIndex = 398;
            this.label1.Text = "پایان:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(755, 48);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(57, 38);
            this.label2.TabIndex = 397;
            this.label2.Text = "آغاز:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cashGroupBox
            // 
            this.cashGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cashGroupBox.Controls.Add(this.otherCheckBox);
            this.cashGroupBox.Controls.Add(this.noncashTypeCheckBox);
            this.cashGroupBox.Controls.Add(this.cashTypeCheckBox);
            this.cashGroupBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cashGroupBox.Location = new System.Drawing.Point(506, 155);
            this.cashGroupBox.Name = "cashGroupBox";
            this.cashGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cashGroupBox.Size = new System.Drawing.Size(247, 143);
            this.cashGroupBox.TabIndex = 409;
            this.cashGroupBox.TabStop = false;
            this.cashGroupBox.Text = "نقدی/غیرنقدی";
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.AutoSize = true;
            this.otherCheckBox.Checked = true;
            this.otherCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.otherCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.otherCheckBox.Location = new System.Drawing.Point(19, 93);
            this.otherCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.otherCheckBox.Size = new System.Drawing.Size(210, 42);
            this.otherCheckBox.TabIndex = 341;
            this.otherCheckBox.Text = "غیرنقدی خیریه دیگر";
            this.otherCheckBox.UseVisualStyleBackColor = true;
            this.otherCheckBox.CheckedChanged += new System.EventHandler(this.cashTypeCheckBox_CheckedChanged);
            // 
            // noncashTypeCheckBox
            // 
            this.noncashTypeCheckBox.AutoSize = true;
            this.noncashTypeCheckBox.Checked = true;
            this.noncashTypeCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.noncashTypeCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.noncashTypeCheckBox.Location = new System.Drawing.Point(29, 45);
            this.noncashTypeCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noncashTypeCheckBox.Name = "noncashTypeCheckBox";
            this.noncashTypeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.noncashTypeCheckBox.Size = new System.Drawing.Size(111, 42);
            this.noncashTypeCheckBox.TabIndex = 340;
            this.noncashTypeCheckBox.Text = "غیرنقدی";
            this.noncashTypeCheckBox.UseVisualStyleBackColor = true;
            this.noncashTypeCheckBox.CheckedChanged += new System.EventHandler(this.cashTypeCheckBox_CheckedChanged);
            // 
            // cashTypeCheckBox
            // 
            this.cashTypeCheckBox.AutoSize = true;
            this.cashTypeCheckBox.Checked = true;
            this.cashTypeCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cashTypeCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cashTypeCheckBox.Location = new System.Drawing.Point(148, 45);
            this.cashTypeCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cashTypeCheckBox.Name = "cashTypeCheckBox";
            this.cashTypeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cashTypeCheckBox.Size = new System.Drawing.Size(81, 42);
            this.cashTypeCheckBox.TabIndex = 339;
            this.cashTypeCheckBox.Text = "نقدی";
            this.cashTypeCheckBox.UseVisualStyleBackColor = true;
            this.cashTypeCheckBox.CheckedChanged += new System.EventHandler(this.cashTypeCheckBox_CheckedChanged);
            // 
            // observeMarryHelpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(848, 640);
            this.Controls.Add(this.cashGroupBox);
            this.Controls.Add(this.bankAccountNameComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.membersView);
            this.Controls.Add(this.exportButton2);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.endDateTimePickerX);
            this.Controls.Add(this.startDateTimePickerX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "observeMarryHelpsForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده کمک‌های ازدواج";
            this.Load += new System.EventHandler(this.observeMarryHelpsForm_Load);
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.cashGroupBox.ResumeLayout(false);
            this.cashGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox bankAccountNameComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.CheckBox recCheckBox;
        private System.Windows.Forms.CheckBox sendCheckBox;
        private System.Windows.Forms.CheckBox endedradCheckBox;
        private System.Windows.Forms.CheckBox presCheckBox;
        private System.Windows.Forms.CheckBox endedCheckBox;
        private System.Windows.Forms.CheckBox accCheckBox;
        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.Button exportButton2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Button searchButton;
        private BehComponents.DateTimePickerX endDateTimePickerX;
        private BehComponents.DateTimePickerX startDateTimePickerX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox cashGroupBox;
        private System.Windows.Forms.CheckBox noncashTypeCheckBox;
        private System.Windows.Forms.CheckBox cashTypeCheckBox;
        private System.Windows.Forms.CheckBox otherCheckBox;
    }
}