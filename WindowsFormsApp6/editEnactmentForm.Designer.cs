namespace WindowsFormsApp6
{
    partial class editEnactmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editEnactmentForm));
            this.addButton = new System.Windows.Forms.Button();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.enactmentTimePickerX = new BehComponents.DateTimePickerX();
            this.label8 = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(100, 149);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 212;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.Red;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(161, 104);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 211;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(43, 96);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.docAddFileButton.TabIndex = 210;
            this.docAddFileButton.Text = "انتخاب";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(214, 100);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(114, 38);
            this.label22.TabIndex = 209;
            this.label22.Text = "فایل مصوبه:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enactmentTimePickerX
            // 
            this.enactmentTimePickerX.AnchorSize = new System.Drawing.Size(182, 56);
            this.enactmentTimePickerX.BackColor = System.Drawing.Color.White;
            this.enactmentTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.enactmentTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.enactmentTimePickerX.CalendarDayRectTickness = 2F;
            this.enactmentTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.enactmentTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.enactmentTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.enactmentTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.enactmentTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.enactmentTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.enactmentTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.enactmentTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.enactmentTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.enactmentTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.enactmentTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.enactmentTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.enactmentTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.enactmentTimePickerX.CalendarShowToday = true;
            this.enactmentTimePickerX.CalendarShowTodayRect = true;
            this.enactmentTimePickerX.CalendarShowToolTips = false;
            this.enactmentTimePickerX.CalendarShowTrailing = true;
            this.enactmentTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.enactmentTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.enactmentTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.enactmentTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.enactmentTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.enactmentTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.enactmentTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.enactmentTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.enactmentTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.enactmentTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.enactmentTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.enactmentTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.enactmentTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.enactmentTimePickerX.CalendarTodayRectTickness = 2F;
            this.enactmentTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.enactmentTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.enactmentTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.enactmentTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.enactmentTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.enactmentTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.enactmentTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.enactmentTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.enactmentTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.enactmentTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("enactmentTimePickerX.ClearButtonImage")));
            this.enactmentTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enactmentTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.enactmentTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.enactmentTimePickerX.ClearButtonText = "";
            this.enactmentTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enactmentTimePickerX.ClearButtonToolTip = "";
            this.enactmentTimePickerX.ClearButtonWidth = 17;
            this.enactmentTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.enactmentTimePickerX.CustomFormat = "";
            this.enactmentTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.enactmentTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.enactmentTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.enactmentTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.enactmentTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.enactmentTimePickerX.Location = new System.Drawing.Point(25, 29);
            this.enactmentTimePickerX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enactmentTimePickerX.Name = "enactmentTimePickerX";
            this.enactmentTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.enactmentTimePickerX.RightToLeftLayout = true;
            this.enactmentTimePickerX.ShowClearButton = false;
            this.enactmentTimePickerX.Size = new System.Drawing.Size(182, 56);
            this.enactmentTimePickerX.TabIndex = 208;
            this.enactmentTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.enactmentTimePickerX.TextWhenClearButtonClicked = "";
            this.enactmentTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.enactmentTimePickerX_SelectedDateChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(214, 38);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(135, 38);
            this.label8.TabIndex = 207;
            this.label8.Text = "تاریخ تصویب :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Aquamarine;
            this.showButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.showButton.FlatAppearance.BorderSize = 2;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showButton.Location = new System.Drawing.Point(76, 206);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(223, 51);
            this.showButton.TabIndex = 256;
            this.showButton.Text = "نمایش فایل قبلی";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // editEnactmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(374, 268);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.enactmentTimePickerX);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editEnactmentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش مصوبه";
            this.Load += new System.EventHandler(this.editEnactmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label label22;
        private BehComponents.DateTimePickerX enactmentTimePickerX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
    }
}