namespace WindowsFormsApp6
{
    partial class addReceivedLetterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addReceivedLetterForm));
            this.addButton = new System.Windows.Forms.Button();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.attachmentLabel = new System.Windows.Forms.Label();
            this.attachmetAddFileButton = new System.Windows.Forms.Button();
            this.recDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.attachmentCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.signerTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.senderTextBox = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.RichTextBox();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.identicalTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(39, 351);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 371;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.Red;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(349, 333);
            this.docLabel.Name = "docLabel";
            this.docLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docLabel.Size = new System.Drawing.Size(33, 32);
            this.docLabel.TabIndex = 370;
            this.docLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docAddFileButton
            // 
            this.docAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.docAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.docAddFileButton.FlatAppearance.BorderSize = 2;
            this.docAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docAddFileButton.Location = new System.Drawing.Point(243, 325);
            this.docAddFileButton.Name = "docAddFileButton";
            this.docAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.docAddFileButton.TabIndex = 369;
            this.docAddFileButton.Text = "انتخاب";
            this.docAddFileButton.UseVisualStyleBackColor = false;
            this.docAddFileButton.Click += new System.EventHandler(this.docAddFileButton_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(388, 329);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(94, 38);
            this.label22.TabIndex = 368;
            this.label22.Text = "فایل نامه:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attachmentLabel
            // 
            this.attachmentLabel.BackColor = System.Drawing.Color.Red;
            this.attachmentLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.attachmentLabel.Location = new System.Drawing.Point(339, 393);
            this.attachmentLabel.Name = "attachmentLabel";
            this.attachmentLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.attachmentLabel.Size = new System.Drawing.Size(33, 32);
            this.attachmentLabel.TabIndex = 367;
            this.attachmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.attachmentLabel.Visible = false;
            // 
            // attachmetAddFileButton
            // 
            this.attachmetAddFileButton.BackColor = System.Drawing.Color.YellowGreen;
            this.attachmetAddFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.attachmetAddFileButton.FlatAppearance.BorderSize = 2;
            this.attachmetAddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmetAddFileButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.attachmetAddFileButton.Location = new System.Drawing.Point(233, 385);
            this.attachmetAddFileButton.Name = "attachmetAddFileButton";
            this.attachmetAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.attachmetAddFileButton.TabIndex = 365;
            this.attachmetAddFileButton.Text = "انتخاب";
            this.attachmetAddFileButton.UseVisualStyleBackColor = false;
            this.attachmetAddFileButton.Visible = false;
            this.attachmetAddFileButton.Click += new System.EventHandler(this.attachmetAddFileButton_Click);
            // 
            // recDateTimePickerX
            // 
            this.recDateTimePickerX.AnchorSize = new System.Drawing.Size(186, 50);
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
            this.recDateTimePickerX.Location = new System.Drawing.Point(266, 265);
            this.recDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.recDateTimePickerX.Name = "recDateTimePickerX";
            this.recDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.recDateTimePickerX.RightToLeftLayout = true;
            this.recDateTimePickerX.ShowClearButton = false;
            this.recDateTimePickerX.Size = new System.Drawing.Size(186, 50);
            this.recDateTimePickerX.TabIndex = 364;
            this.recDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recDateTimePickerX.TextWhenClearButtonClicked = "";
            this.recDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.recDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(353, 220);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(130, 38);
            this.label9.TabIndex = 363;
            this.label9.Text = "تاریخ دریافت:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attachmentCheckBox
            // 
            this.attachmentCheckBox.AutoSize = true;
            this.attachmentCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.attachmentCheckBox.Location = new System.Drawing.Point(381, 388);
            this.attachmentCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.attachmentCheckBox.Name = "attachmentCheckBox";
            this.attachmentCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.attachmentCheckBox.Size = new System.Drawing.Size(98, 42);
            this.attachmentCheckBox.TabIndex = 366;
            this.attachmentCheckBox.Text = "پیوست";
            this.attachmentCheckBox.UseVisualStyleBackColor = true;
            this.attachmentCheckBox.CheckedChanged += new System.EventHandler(this.attachmentCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(411, 117);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(72, 38);
            this.label3.TabIndex = 361;
            this.label3.Text = "عنوان:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.titleTextBox.Location = new System.Drawing.Point(266, 163);
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.titleTextBox.Size = new System.Drawing.Size(210, 46);
            this.titleTextBox.TabIndex = 359;
            this.titleTextBox.Text = "";
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.Enter += new System.EventHandler(this.titleTextBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(138, 220);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(105, 38);
            this.label2.TabIndex = 358;
            this.label2.Text = "امضا‌کننده:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signerTextBox
            // 
            this.signerTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.signerTextBox.Location = new System.Drawing.Point(26, 268);
            this.signerTextBox.Multiline = false;
            this.signerTextBox.Name = "signerTextBox";
            this.signerTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.signerTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.signerTextBox.Size = new System.Drawing.Size(210, 44);
            this.signerTextBox.TabIndex = 362;
            this.signerTextBox.Text = "";
            this.signerTextBox.TextChanged += new System.EventHandler(this.signerTextBox_TextChanged);
            this.signerTextBox.Enter += new System.EventHandler(this.signerTextBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(151, 117);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(92, 38);
            this.label1.TabIndex = 357;
            this.label1.Text = "فرستنده:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // senderTextBox
            // 
            this.senderTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.senderTextBox.Location = new System.Drawing.Point(26, 168);
            this.senderTextBox.Multiline = false;
            this.senderTextBox.Name = "senderTextBox";
            this.senderTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.senderTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.senderTextBox.Size = new System.Drawing.Size(210, 44);
            this.senderTextBox.TabIndex = 360;
            this.senderTextBox.Text = "";
            this.senderTextBox.TextChanged += new System.EventHandler(this.senderTextBox_TextChanged);
            this.senderTextBox.Enter += new System.EventHandler(this.senderTextBox_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(171, 22);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(72, 38);
            this.label19.TabIndex = 356;
            this.label19.Text = "شماره:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextBox.Location = new System.Drawing.Point(26, 73);
            this.idTextBox.Multiline = false;
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextBox.Size = new System.Drawing.Size(210, 44);
            this.idTextBox.TabIndex = 355;
            this.idTextBox.Text = "";
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            this.idTextBox.Enter += new System.EventHandler(this.idTextBox_Enter);
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(371, 22);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(111, 38);
            this.label4.TabIndex = 373;
            this.label4.Text = "شماره یکتا:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identicalTextBox
            // 
            this.identicalTextBox.Enabled = false;
            this.identicalTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.identicalTextBox.Location = new System.Drawing.Point(269, 73);
            this.identicalTextBox.Multiline = false;
            this.identicalTextBox.Name = "identicalTextBox";
            this.identicalTextBox.ReadOnly = true;
            this.identicalTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.identicalTextBox.Size = new System.Drawing.Size(210, 44);
            this.identicalTextBox.TabIndex = 372;
            this.identicalTextBox.Text = "";
            // 
            // addReceivedLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(506, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.identicalTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.attachmentLabel);
            this.Controls.Add(this.attachmetAddFileButton);
            this.Controls.Add(this.recDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.attachmentCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.signerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.senderTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.idTextBox);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addReceivedLetterForm";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت نامه دریافتی";
            this.Load += new System.EventHandler(this.addReceivedLetterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label docLabel;
        private System.Windows.Forms.Button docAddFileButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label attachmentLabel;
        private System.Windows.Forms.Button attachmetAddFileButton;
        private BehComponents.DateTimePickerX recDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox attachmentCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox signerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox senderTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox idTextBox;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox identicalTextBox;
    }
}