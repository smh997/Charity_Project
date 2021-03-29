namespace WindowsFormsApp6
{
    partial class healHelpReqForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(healHelpReqForm));
            this.idTextbox = new System.Windows.Forms.RichTextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.healDocLabel = new System.Windows.Forms.Label();
            this.healDocButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reqLabel = new System.Windows.Forms.Label();
            this.reqAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.reqDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // idTextbox
            // 
            this.idTextbox.Enabled = false;
            this.idTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextbox.Location = new System.Drawing.Point(49, 28);
            this.idTextbox.Multiline = false;
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.ReadOnly = true;
            this.idTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextbox.Size = new System.Drawing.Size(174, 44);
            this.idTextbox.TabIndex = 286;
            this.idTextbox.Text = "";
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Firebrick;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delButton.FlatAppearance.BorderSize = 2;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.delButton.Location = new System.Drawing.Point(18, 459);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(174, 51);
            this.delButton.TabIndex = 285;
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
            this.setButton.Location = new System.Drawing.Point(201, 459);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(174, 51);
            this.setButton.TabIndex = 284;
            this.setButton.Text = "ثبت";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // healDocLabel
            // 
            this.healDocLabel.BackColor = System.Drawing.Color.Red;
            this.healDocLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healDocLabel.Location = new System.Drawing.Point(25, 151);
            this.healDocLabel.Name = "healDocLabel";
            this.healDocLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.healDocLabel.Size = new System.Drawing.Size(33, 32);
            this.healDocLabel.TabIndex = 283;
            this.healDocLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // healDocButton
            // 
            this.healDocButton.BackColor = System.Drawing.Color.YellowGreen;
            this.healDocButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.healDocButton.FlatAppearance.BorderSize = 2;
            this.healDocButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healDocButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.healDocButton.Location = new System.Drawing.Point(64, 191);
            this.healDocButton.Name = "healDocButton";
            this.healDocButton.Size = new System.Drawing.Size(100, 47);
            this.healDocButton.TabIndex = 282;
            this.healDocButton.Text = "انتخاب";
            this.healDocButton.UseVisualStyleBackColor = false;
            this.healDocButton.Click += new System.EventHandler(this.healDocButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(64, 147);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(131, 38);
            this.label2.TabIndex = 281;
            this.label2.Text = "مدارک درمان:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reqLabel
            // 
            this.reqLabel.BackColor = System.Drawing.Color.Red;
            this.reqLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqLabel.Location = new System.Drawing.Point(205, 151);
            this.reqLabel.Name = "reqLabel";
            this.reqLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqLabel.Size = new System.Drawing.Size(33, 32);
            this.reqLabel.TabIndex = 280;
            this.reqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reqAddFileButton
            // 
            this.reqAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.reqAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.reqAddFileButton.FlatAppearance.BorderSize = 2;
            this.reqAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reqAddFileButton.Location = new System.Drawing.Point(244, 190);
            this.reqAddFileButton.Name = "reqAddFileButton";
            this.reqAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.reqAddFileButton.TabIndex = 279;
            this.reqAddFileButton.Text = "انتخاب";
            this.reqAddFileButton.UseVisualStyleBackColor = false;
            this.reqAddFileButton.Click += new System.EventHandler(this.reqAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(244, 147);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(138, 38);
            this.label22.TabIndex = 278;
            this.label22.Text = "فرم درخواست:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.reqDateTimePickerX.Location = new System.Drawing.Point(49, 82);
            this.reqDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.reqDateTimePickerX.Name = "reqDateTimePickerX";
            this.reqDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reqDateTimePickerX.RightToLeftLayout = true;
            this.reqDateTimePickerX.ShowClearButton = false;
            this.reqDateTimePickerX.Size = new System.Drawing.Size(174, 50);
            this.reqDateTimePickerX.TabIndex = 277;
            this.reqDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reqDateTimePickerX.TextWhenClearButtonClicked = "";
            this.reqDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.reqDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(229, 84);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(153, 38);
            this.label9.TabIndex = 276;
            this.label9.Text = "تاریخ درخواست:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(150, 252);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(101, 38);
            this.label17.TabIndex = 275;
            this.label17.Text = "توضیحات:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // explainTextBox
            // 
            this.explainTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.explainTextBox.Location = new System.Drawing.Point(18, 293);
            this.explainTextBox.Multiline = true;
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.explainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.explainTextBox.Size = new System.Drawing.Size(357, 147);
            this.explainTextBox.TabIndex = 274;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(229, 30);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(109, 38);
            this.label5.TabIndex = 273;
            this.label5.Text = "شماره ملی:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // healHelpReqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gold;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(400, 539);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.healDocLabel);
            this.Controls.Add(this.healDocButton);
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
            this.Name = "healHelpReqForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت درخواست کمک درمان";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.healHelpReqForm_FormClosing);
            this.Load += new System.EventHandler(this.healHelpReqForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox idTextbox;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Label healDocLabel;
        private System.Windows.Forms.Button healDocButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label reqLabel;
        private System.Windows.Forms.Button reqAddFileButton;
        private System.Windows.Forms.Label label22;
        private BehComponents.DateTimePickerX reqDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
    }
}