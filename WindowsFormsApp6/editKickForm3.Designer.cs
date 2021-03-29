namespace WindowsFormsApp6
{
    partial class editKickForm3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editKickForm3));
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.membersView = new System.Windows.Forms.DataGridView();
            this.updateDesc = new System.Windows.Forms.Button();
            this.newExplain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deletePersongroupBox = new System.Windows.Forms.GroupBox();
            this.marrycheckBox = new System.Windows.Forms.CheckBox();
            this.deadcheckBox = new System.Windows.Forms.CheckBox();
            this.jobingcheckBox = new System.Windows.Forms.CheckBox();
            this.servicecheckBox = new System.Windows.Forms.CheckBox();
            this.personRegioncheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.familyRegioncheckBox = new System.Windows.Forms.CheckBox();
            this.financialcheckBox = new System.Windows.Forms.CheckBox();
            this.deleteFamilygroupBox = new System.Windows.Forms.GroupBox();
            this.editFileButton = new System.Windows.Forms.Button();
            this.marrydateTimePickerX = new BehComponents.DateTimePickerX();
            this.docLabel = new System.Windows.Forms.Label();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).BeginInit();
            this.deletePersongroupBox.SuspendLayout();
            this.deleteFamilygroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(768, 325);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(101, 38);
            this.label2.TabIndex = 39;
            this.label2.Text = "توضیحات:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(450, 328);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(312, 201);
            this.DescriptionTextBox.TabIndex = 38;
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(768, 377);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(152, 92);
            this.setButton.TabIndex = 37;
            this.setButton.Text = "لغو حذف پوشش";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // membersView
            // 
            this.membersView.AllowUserToAddRows = false;
            this.membersView.AllowUserToDeleteRows = false;
            this.membersView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.membersView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
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
            this.membersView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.membersView.Location = new System.Drawing.Point(111, 35);
            this.membersView.Name = "membersView";
            this.membersView.ReadOnly = true;
            this.membersView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.membersView.RowTemplate.Height = 24;
            this.membersView.Size = new System.Drawing.Size(651, 287);
            this.membersView.TabIndex = 36;
            // 
            // updateDesc
            // 
            this.updateDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.updateDesc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.updateDesc.FlatAppearance.BorderSize = 2;
            this.updateDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateDesc.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.updateDesc.Location = new System.Drawing.Point(768, 472);
            this.updateDesc.Name = "updateDesc";
            this.updateDesc.Size = new System.Drawing.Size(152, 92);
            this.updateDesc.TabIndex = 40;
            this.updateDesc.Text = "تغییر علت و اصلاح توضیحات";
            this.updateDesc.UseVisualStyleBackColor = false;
            this.updateDesc.Click += new System.EventHandler(this.updateDesc_Click);
            // 
            // newExplain
            // 
            this.newExplain.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.newExplain.Location = new System.Drawing.Point(450, 535);
            this.newExplain.Multiline = true;
            this.newExplain.Name = "newExplain";
            this.newExplain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newExplain.Size = new System.Drawing.Size(312, 201);
            this.newExplain.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(272, 499);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(172, 38);
            this.label3.TabIndex = 45;
            this.label3.Text = "تاریخ ازدواج عضو :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deletePersongroupBox
            // 
            this.deletePersongroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletePersongroupBox.Controls.Add(this.marrycheckBox);
            this.deletePersongroupBox.Controls.Add(this.deadcheckBox);
            this.deletePersongroupBox.Controls.Add(this.jobingcheckBox);
            this.deletePersongroupBox.Controls.Add(this.servicecheckBox);
            this.deletePersongroupBox.Controls.Add(this.personRegioncheckBox);
            this.deletePersongroupBox.ForeColor = System.Drawing.Color.Black;
            this.deletePersongroupBox.Location = new System.Drawing.Point(103, 338);
            this.deletePersongroupBox.Name = "deletePersongroupBox";
            this.deletePersongroupBox.Size = new System.Drawing.Size(277, 151);
            this.deletePersongroupBox.TabIndex = 43;
            this.deletePersongroupBox.TabStop = false;
            // 
            // marrycheckBox
            // 
            this.marrycheckBox.AutoSize = true;
            this.marrycheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marrycheckBox.Location = new System.Drawing.Point(30, 61);
            this.marrycheckBox.Name = "marrycheckBox";
            this.marrycheckBox.Size = new System.Drawing.Size(82, 39);
            this.marrycheckBox.TabIndex = 30;
            this.marrycheckBox.Text = "ازدواج";
            this.marrycheckBox.UseVisualStyleBackColor = true;
            this.marrycheckBox.CheckedChanged += new System.EventHandler(this.marrycheckBox_CheckedChanged);
            // 
            // deadcheckBox
            // 
            this.deadcheckBox.AutoSize = true;
            this.deadcheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deadcheckBox.Location = new System.Drawing.Point(30, 100);
            this.deadcheckBox.Name = "deadcheckBox";
            this.deadcheckBox.Size = new System.Drawing.Size(68, 39);
            this.deadcheckBox.TabIndex = 29;
            this.deadcheckBox.Text = "فوت";
            this.deadcheckBox.UseVisualStyleBackColor = true;
            // 
            // jobingcheckBox
            // 
            this.jobingcheckBox.AutoSize = true;
            this.jobingcheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jobingcheckBox.Location = new System.Drawing.Point(178, 100);
            this.jobingcheckBox.Name = "jobingcheckBox";
            this.jobingcheckBox.Size = new System.Drawing.Size(87, 39);
            this.jobingcheckBox.TabIndex = 28;
            this.jobingcheckBox.Text = "اشتغال";
            this.jobingcheckBox.UseVisualStyleBackColor = true;
            // 
            // servicecheckBox
            // 
            this.servicecheckBox.AutoSize = true;
            this.servicecheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.servicecheckBox.Location = new System.Drawing.Point(124, 61);
            this.servicecheckBox.Name = "servicecheckBox";
            this.servicecheckBox.Size = new System.Drawing.Size(147, 39);
            this.servicecheckBox.TabIndex = 27;
            this.servicecheckBox.Text = "مشمول خدمت";
            this.servicecheckBox.UseVisualStyleBackColor = true;
            // 
            // personRegioncheckBox
            // 
            this.personRegioncheckBox.AutoSize = true;
            this.personRegioncheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personRegioncheckBox.Location = new System.Drawing.Point(118, 22);
            this.personRegioncheckBox.Name = "personRegioncheckBox";
            this.personRegioncheckBox.Size = new System.Drawing.Size(159, 39);
            this.personRegioncheckBox.TabIndex = 26;
            this.personRegioncheckBox.Text = "خروج از محدوده";
            this.personRegioncheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(386, 403);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(51, 32);
            this.label1.TabIndex = 44;
            this.label1.Text = "علت:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // familyRegioncheckBox
            // 
            this.familyRegioncheckBox.AutoSize = true;
            this.familyRegioncheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.familyRegioncheckBox.Location = new System.Drawing.Point(11, 32);
            this.familyRegioncheckBox.Name = "familyRegioncheckBox";
            this.familyRegioncheckBox.Size = new System.Drawing.Size(159, 39);
            this.familyRegioncheckBox.TabIndex = 31;
            this.familyRegioncheckBox.Text = "خروج از محدوده";
            this.familyRegioncheckBox.UseVisualStyleBackColor = true;
            // 
            // financialcheckBox
            // 
            this.financialcheckBox.AutoSize = true;
            this.financialcheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.financialcheckBox.Location = new System.Drawing.Point(45, 80);
            this.financialcheckBox.Name = "financialcheckBox";
            this.financialcheckBox.Size = new System.Drawing.Size(117, 39);
            this.financialcheckBox.TabIndex = 31;
            this.financialcheckBox.Text = "تمکن مالی";
            this.financialcheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteFamilygroupBox
            // 
            this.deleteFamilygroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deleteFamilygroupBox.Controls.Add(this.familyRegioncheckBox);
            this.deleteFamilygroupBox.Controls.Add(this.financialcheckBox);
            this.deleteFamilygroupBox.ForeColor = System.Drawing.Color.Black;
            this.deleteFamilygroupBox.Location = new System.Drawing.Point(204, 360);
            this.deleteFamilygroupBox.Name = "deleteFamilygroupBox";
            this.deleteFamilygroupBox.Size = new System.Drawing.Size(176, 129);
            this.deleteFamilygroupBox.TabIndex = 46;
            this.deleteFamilygroupBox.TabStop = false;
            // 
            // editFileButton
            // 
            this.editFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.editFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.editFileButton.FlatAppearance.BorderSize = 2;
            this.editFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editFileButton.Location = new System.Drawing.Point(768, 570);
            this.editFileButton.Name = "editFileButton";
            this.editFileButton.Size = new System.Drawing.Size(152, 77);
            this.editFileButton.TabIndex = 169;
            this.editFileButton.Text = "ویرایش مدارک";
            this.editFileButton.UseVisualStyleBackColor = false;
            this.editFileButton.Click += new System.EventHandler(this.editFileButton_Click);
            // 
            // marrydateTimePickerX
            // 
            this.marrydateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.marrydateTimePickerX.BackColor = System.Drawing.Color.White;
            this.marrydateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.marrydateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.marrydateTimePickerX.CalendarDayRectTickness = 2F;
            this.marrydateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.marrydateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marrydateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.marrydateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.marrydateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.marrydateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.marrydateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.marrydateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.marrydateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.marrydateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.marrydateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.marrydateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.marrydateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.marrydateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.marrydateTimePickerX.CalendarShowToday = true;
            this.marrydateTimePickerX.CalendarShowTodayRect = true;
            this.marrydateTimePickerX.CalendarShowToolTips = false;
            this.marrydateTimePickerX.CalendarShowTrailing = true;
            this.marrydateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.marrydateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.marrydateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.marrydateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.marrydateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.marrydateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.marrydateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.marrydateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.marrydateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.marrydateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.marrydateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.marrydateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.marrydateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.marrydateTimePickerX.CalendarTodayRectTickness = 2F;
            this.marrydateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.marrydateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.marrydateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.marrydateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.marrydateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.marrydateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.marrydateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.marrydateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.marrydateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.marrydateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("marrydateTimePickerX.ClearButtonImage")));
            this.marrydateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.marrydateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.marrydateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.marrydateTimePickerX.ClearButtonText = "";
            this.marrydateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.marrydateTimePickerX.ClearButtonToolTip = "";
            this.marrydateTimePickerX.ClearButtonWidth = 17;
            this.marrydateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.marrydateTimePickerX.CustomFormat = "";
            this.marrydateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.marrydateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.marrydateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.marrydateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marrydateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.marrydateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.marrydateTimePickerX.Location = new System.Drawing.Point(102, 497);
            this.marrydateTimePickerX.Margin = new System.Windows.Forms.Padding(5);
            this.marrydateTimePickerX.Name = "marrydateTimePickerX";
            this.marrydateTimePickerX.RightToLeftLayout = true;
            this.marrydateTimePickerX.ShowClearButton = false;
            this.marrydateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.marrydateTimePickerX.TabIndex = 170;
            this.marrydateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.marrydateTimePickerX.TextWhenClearButtonClicked = "";
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.YellowGreen;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(936, 593);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 177;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.profilePictureBox.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePictureBox.ErrorImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.InitialImage = global::WindowsFormsApp6.Properties.Resources.profile;
            this.profilePictureBox.Location = new System.Drawing.Point(768, 35);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(210, 280);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePictureBox.TabIndex = 191;
            this.profilePictureBox.TabStop = false;
            this.profilePictureBox.WaitOnLoad = true;
            // 
            // editKickForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(1025, 749);
            this.Controls.Add(this.profilePictureBox);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.marrydateTimePickerX);
            this.Controls.Add(this.editFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newExplain);
            this.Controls.Add(this.updateDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.membersView);
            this.Controls.Add(this.deleteFamilygroupBox);
            this.Controls.Add(this.deletePersongroupBox);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editKickForm3";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.editKickForm3_FormClosing);
            this.Load += new System.EventHandler(this.editKickForm3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membersView)).EndInit();
            this.deletePersongroupBox.ResumeLayout(false);
            this.deletePersongroupBox.PerformLayout();
            this.deleteFamilygroupBox.ResumeLayout(false);
            this.deleteFamilygroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.DataGridView membersView;
        private System.Windows.Forms.Button updateDesc;
        private System.Windows.Forms.TextBox newExplain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox deletePersongroupBox;
        private System.Windows.Forms.CheckBox marrycheckBox;
        private System.Windows.Forms.CheckBox deadcheckBox;
        private System.Windows.Forms.CheckBox jobingcheckBox;
        private System.Windows.Forms.CheckBox servicecheckBox;
        private System.Windows.Forms.CheckBox personRegioncheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox familyRegioncheckBox;
        private System.Windows.Forms.CheckBox financialcheckBox;
        private System.Windows.Forms.GroupBox deleteFamilygroupBox;
        private System.Windows.Forms.Button editFileButton;
        private BehComponents.DateTimePickerX marrydateTimePickerX;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.PictureBox profilePictureBox;
    }
}