namespace WindowsFormsApp6
{
    partial class bankAccountCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bankAccountCreateForm));
            this.bankAccountNameTextBox = new System.Windows.Forms.RichTextBox();
            this.bankNameTextBox = new System.Windows.Forms.RichTextBox();
            this.bankAccountNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.bankAccountOwnerNameTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.createDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bankAccountNameTextBox
            // 
            this.bankAccountNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNameTextBox.Location = new System.Drawing.Point(206, 47);
            this.bankAccountNameTextBox.Multiline = false;
            this.bankAccountNameTextBox.Name = "bankAccountNameTextBox";
            this.bankAccountNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountNameTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountNameTextBox.TabIndex = 291;
            this.bankAccountNameTextBox.Text = "";
            this.bankAccountNameTextBox.TextChanged += new System.EventHandler(this.bankAccountNameTextBox_TextChanged);
            this.bankAccountNameTextBox.Enter += new System.EventHandler(this.bankAccountNameTextBox_Enter);
            // 
            // bankNameTextBox
            // 
            this.bankNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankNameTextBox.Location = new System.Drawing.Point(206, 217);
            this.bankNameTextBox.Multiline = false;
            this.bankNameTextBox.Name = "bankNameTextBox";
            this.bankNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankNameTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankNameTextBox.TabIndex = 294;
            this.bankNameTextBox.Text = "";
            this.bankNameTextBox.TextChanged += new System.EventHandler(this.bankNameTextBox_TextChanged);
            this.bankNameTextBox.Enter += new System.EventHandler(this.bankNameTextBox_Enter);
            // 
            // bankAccountNumberTextBox
            // 
            this.bankAccountNumberTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountNumberTextBox.Location = new System.Drawing.Point(206, 129);
            this.bankAccountNumberTextBox.Multiline = false;
            this.bankAccountNumberTextBox.Name = "bankAccountNumberTextBox";
            this.bankAccountNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountNumberTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountNumberTextBox.TabIndex = 293;
            this.bankAccountNumberTextBox.Text = "";
            this.bankAccountNumberTextBox.TextChanged += new System.EventHandler(this.bankAccountNumberTextBox_TextChanged);
            this.bankAccountNumberTextBox.Enter += new System.EventHandler(this.bankAccountNumberTextBox_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label20.Location = new System.Drawing.Point(415, 6);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(104, 38);
            this.label20.TabIndex = 290;
            this.label20.Text = "نام حساب:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(387, 94);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(132, 38);
            this.label2.TabIndex = 289;
            this.label2.Text = "شماره حساب:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(431, 176);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(88, 38);
            this.label19.TabIndex = 288;
            this.label19.Text = "نام بانک:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankAccountOwnerNameTextBox
            // 
            this.bankAccountOwnerNameTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bankAccountOwnerNameTextBox.Location = new System.Drawing.Point(206, 305);
            this.bankAccountOwnerNameTextBox.Multiline = false;
            this.bankAccountOwnerNameTextBox.Name = "bankAccountOwnerNameTextBox";
            this.bankAccountOwnerNameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.bankAccountOwnerNameTextBox.Size = new System.Drawing.Size(313, 44);
            this.bankAccountOwnerNameTextBox.TabIndex = 295;
            this.bankAccountOwnerNameTextBox.Text = "";
            this.bankAccountOwnerNameTextBox.TextChanged += new System.EventHandler(this.bankAccountOwnerNameTextBox_TextChanged);
            this.bankAccountOwnerNameTextBox.Enter += new System.EventHandler(this.bankAccountOwnerNameTextBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(310, 264);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(209, 38);
            this.label1.TabIndex = 294;
            this.label1.Text = "نام کامل صاحب حساب:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(283, 429);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 296;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(16, 47);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 50);
            this.enactmentTextbox.TabIndex = 298;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(43, 6);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 297;
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
            this.searchButton.Location = new System.Drawing.Point(16, 112);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 51);
            this.searchButton.TabIndex = 299;
            this.searchButton.Text = "جستجو مصوبه";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(70, 176);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 301;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(12, 217);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(188, 262);
            this.explainTextBox.TabIndex = 300;
            this.explainTextBox.TextChanged += new System.EventHandler(this.explainTextBox_TextChanged);
            this.explainTextBox.Enter += new System.EventHandler(this.explainTextBox_Enter);
            // 
            // createDateTimePickerX
            // 
            this.createDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.createDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.createDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.createDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.createDateTimePickerX.CalendarDayRectTickness = 2F;
            this.createDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.createDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.createDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.createDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.createDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.createDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.createDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.createDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.createDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.createDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.createDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.createDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.createDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.createDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.createDateTimePickerX.CalendarShowToday = true;
            this.createDateTimePickerX.CalendarShowTodayRect = true;
            this.createDateTimePickerX.CalendarShowToolTips = false;
            this.createDateTimePickerX.CalendarShowTrailing = true;
            this.createDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.createDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.createDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.createDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.createDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.createDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.createDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.createDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.createDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.createDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.createDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.createDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.createDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.createDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.createDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.createDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.createDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.createDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.createDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.createDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.createDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.createDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.createDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.createDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("createDateTimePickerX.ClearButtonImage")));
            this.createDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.createDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.createDateTimePickerX.ClearButtonText = "";
            this.createDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createDateTimePickerX.ClearButtonToolTip = "";
            this.createDateTimePickerX.ClearButtonWidth = 17;
            this.createDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.createDateTimePickerX.CustomFormat = "";
            this.createDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.createDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.createDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.createDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.createDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.createDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.createDateTimePickerX.Location = new System.Drawing.Point(218, 369);
            this.createDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.createDateTimePickerX.Name = "createDateTimePickerX";
            this.createDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.createDateTimePickerX.RightToLeftLayout = true;
            this.createDateTimePickerX.ShowClearButton = false;
            this.createDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.createDateTimePickerX.TabIndex = 303;
            this.createDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createDateTimePickerX.TextWhenClearButtonClicked = "";
            this.createDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.createDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(401, 369);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(113, 38);
            this.label9.TabIndex = 302;
            this.label9.Text = "تاریخ ایجاد:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bankAccountCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(531, 491);
            this.Controls.Add(this.createDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bankAccountOwnerNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bankAccountNameTextBox);
            this.Controls.Add(this.bankNameTextBox);
            this.Controls.Add(this.bankAccountNumberTextBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.searchButton);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bankAccountCreateForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ایجاد حساب بانکی";
            this.Load += new System.EventHandler(this.bankAccountCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox bankAccountNameTextBox;
        private System.Windows.Forms.RichTextBox bankNameTextBox;
        private System.Windows.Forms.RichTextBox bankAccountNumberTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox bankAccountOwnerNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private BehComponents.DateTimePickerX createDateTimePickerX;
        private System.Windows.Forms.Label label9;
    }
}