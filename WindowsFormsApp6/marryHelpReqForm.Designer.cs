namespace WindowsFormsApp6
{
    partial class marryHelpReqForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(marryHelpReqForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.reqDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.reqLabel = new System.Windows.Forms.Label();
            this.reqAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.marryDocLabel = new System.Windows.Forms.Label();
            this.marryDocButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.idTextbox = new System.Windows.Forms.RichTextBox();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(232, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(109, 38);
            this.label5.TabIndex = 251;
            this.label5.Text = "شماره ملی:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(153, 253);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 261;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(21, 294);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(357, 147);
            this.explainTextBox.TabIndex = 260;
            // 
            // reqDateTimePickerX
            // 
            this.reqDateTimePickerX.AnchorSize = new System.Drawing.Size(174, 50);
            this.reqDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.reqDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.reqDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.reqDateTimePickerX.CalendarDayRectTickness = 2F;
            this.reqDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.reqDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.reqDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.reqDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.reqDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.reqDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.reqDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.reqDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.reqDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.reqDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.reqDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.reqDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.reqDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.reqDateTimePickerX.CalendarShowToday = true;
            this.reqDateTimePickerX.CalendarShowTodayRect = true;
            this.reqDateTimePickerX.CalendarShowToolTips = false;
            this.reqDateTimePickerX.CalendarShowTrailing = true;
            this.reqDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.reqDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.reqDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.reqDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.reqDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.reqDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.reqDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.reqDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.reqDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.reqDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.reqDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.reqDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.reqDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.reqDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.reqDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.reqDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.reqDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.reqDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.reqDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.reqDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.reqDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.reqDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.reqDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.reqDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("reqDateTimePickerX.ClearButtonImage")));
            this.reqDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reqDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.reqDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.reqDateTimePickerX.ClearButtonText = "";
            this.reqDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reqDateTimePickerX.ClearButtonToolTip = "";
            this.reqDateTimePickerX.ClearButtonWidth = 17;
            this.reqDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.reqDateTimePickerX.CustomFormat = "";
            this.reqDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.reqDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.reqDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.reqDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.reqDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.reqDateTimePickerX.Location = new System.Drawing.Point(52, 83);
            this.reqDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.reqDateTimePickerX.Name = "reqDateTimePickerX";
            this.reqDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqDateTimePickerX.RightToLeftLayout = true;
            this.reqDateTimePickerX.ShowClearButton = false;
            this.reqDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.reqDateTimePickerX.TabIndex = 263;
            this.reqDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reqDateTimePickerX.TextWhenClearButtonClicked = "";
            this.reqDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.reqDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(232, 85);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(153, 38);
            this.label9.TabIndex = 262;
            this.label9.Text = "تاریخ درخواست:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reqLabel
            // 
            this.reqLabel.BackColor = System.Drawing.Color.Red;
            this.reqLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqLabel.Location = new System.Drawing.Point(208, 152);
            this.reqLabel.Name = "reqLabel";
            this.reqLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqLabel.Size = new System.Drawing.Size(33, 32);
            this.reqLabel.TabIndex = 266;
            this.reqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reqAddFileButton
            // 
            this.reqAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.reqAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.reqAddFileButton.FlatAppearance.BorderSize = 2;
            this.reqAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqAddFileButton.Location = new System.Drawing.Point(247, 191);
            this.reqAddFileButton.Name = "reqAddFileButton";
            this.reqAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.reqAddFileButton.TabIndex = 265;
            this.reqAddFileButton.Text = "انتخاب";
            this.reqAddFileButton.UseVisualStyleBackColor = false;
            this.reqAddFileButton.Click += new System.EventHandler(this.reqAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(247, 148);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(138, 38);
            this.label22.TabIndex = 264;
            this.label22.Text = "فرم درخواست:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // marryDocLabel
            // 
            this.marryDocLabel.BackColor = System.Drawing.Color.Red;
            this.marryDocLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marryDocLabel.Location = new System.Drawing.Point(28, 152);
            this.marryDocLabel.Name = "marryDocLabel";
            this.marryDocLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.marryDocLabel.Size = new System.Drawing.Size(33, 32);
            this.marryDocLabel.TabIndex = 269;
            this.marryDocLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // marryDocButton
            // 
            this.marryDocButton.BackColor = System.Drawing.Color.YellowGreen;
            this.marryDocButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.marryDocButton.FlatAppearance.BorderSize = 2;
            this.marryDocButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.marryDocButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.marryDocButton.Location = new System.Drawing.Point(67, 192);
            this.marryDocButton.Name = "marryDocButton";
            this.marryDocButton.Size = new System.Drawing.Size(100, 47);
            this.marryDocButton.TabIndex = 268;
            this.marryDocButton.Text = "انتخاب";
            this.marryDocButton.UseVisualStyleBackColor = false;
            this.marryDocButton.Click += new System.EventHandler(this.marryDocButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(67, 148);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(135, 38);
            this.label2.TabIndex = 267;
            this.label2.Text = "مدارک ازدواج:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(21, 460);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 271;
            this.delButton.Text = "حذف";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.setButton.FlatAppearance.BorderSize = 2;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.setButton.Location = new System.Drawing.Point(204, 460);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 270;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // idTextbox
            // 
            this.idTextbox.Enabled = false;
            this.idTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextbox.Location = new System.Drawing.Point(52, 29);
            this.idTextbox.Multiline = false;
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.ReadOnly = true;
            this.idTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextbox.Size = new System.Drawing.Size(174, 44);
            this.idTextbox.TabIndex = 272;
            this.idTextbox.Text = "";
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // marryHelpReqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(400, 539);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.marryDocLabel);
            this.Controls.Add(this.marryDocButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reqLabel);
            this.Controls.Add(this.reqAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.reqDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.explainTextBox);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "marryHelpReqForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت درخواست کمک ازدواج";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.marryHelpReqForm_FormClosing);
            this.Load += new System.EventHandler(this.marryHelpReqForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private BehComponents.DateTimePickerX reqDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label reqLabel;
        private System.Windows.Forms.Button reqAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label marryDocLabel;
        private System.Windows.Forms.Button marryDocButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.RichTextBox idTextbox;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
    }
}