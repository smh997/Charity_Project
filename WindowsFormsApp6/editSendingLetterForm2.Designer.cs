namespace WindowsFormsApp6
{
    partial class editSendingLetterForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editSendingLetterForm2));
            this.addButton = new System.Windows.Forms.Button();
            this.docLabel = new System.Windows.Forms.Label();
            this.docAddFileButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.attachmentLabel = new System.Windows.Forms.Label();
            this.attachmetAddFileButton = new System.Windows.Forms.Button();
            this.sendDateTimePickerX = new BehComponents.DateTimePickerX();
            this.label9 = new System.Windows.Forms.Label();
            this.attachmentCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.signerTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.receiverTextBox = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.RichTextBox();
            this.showButton = new System.Windows.Forms.Button();
            this.enactmentTextbox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.seachEnactmentbutton = new System.Windows.Forms.Button();
            this.addOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lime;
            this.addButton.Enabled = false;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(257, 387);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(174, 51);
            this.addButton.TabIndex = 371;
            this.addButton.Text = "ثبت";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // docLabel
            // 
            this.docLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.docLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.docLabel.Location = new System.Drawing.Point(353, 225);
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
            this.docAddFileButton.Location = new System.Drawing.Point(247, 217);
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
            this.label22.Location = new System.Drawing.Point(392, 221);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(94, 38);
            this.label22.TabIndex = 368;
            this.label22.Text = "فایل نامه:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attachmentLabel
            // 
            this.attachmentLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.attachmentLabel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.attachmentLabel.Location = new System.Drawing.Point(343, 285);
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
            this.attachmetAddFileButton.Location = new System.Drawing.Point(237, 277);
            this.attachmetAddFileButton.Name = "attachmetAddFileButton";
            this.attachmetAddFileButton.Size = new System.Drawing.Size(100, 47);
            this.attachmetAddFileButton.TabIndex = 366;
            this.attachmetAddFileButton.Text = "ویرایش";
            this.attachmetAddFileButton.UseVisualStyleBackColor = false;
            this.attachmetAddFileButton.Visible = false;
            this.attachmetAddFileButton.Click += new System.EventHandler(this.attachmetAddFileButton_Click);
            // 
            // sendDateTimePickerX
            // 
            this.sendDateTimePickerX.AnchorSize = new System.Drawing.Size(186, 50);
            this.sendDateTimePickerX.BackColor = System.Drawing.Color.White;
            this.sendDateTimePickerX.CalendarBoldedDayForeColor = System.Drawing.Color.Blue;
            this.sendDateTimePickerX.CalendarBorderColor = System.Drawing.Color.CadetBlue;
            this.sendDateTimePickerX.CalendarDayRectTickness = 2F;
            this.sendDateTimePickerX.CalendarDaysBackColor = System.Drawing.Color.LightGray;
            this.sendDateTimePickerX.CalendarDaysFont = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sendDateTimePickerX.CalendarDaysForeColor = System.Drawing.Color.DodgerBlue;
            this.sendDateTimePickerX.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.sendDateTimePickerX.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.sendDateTimePickerX.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.sendDateTimePickerX.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.sendDateTimePickerX.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.sendDateTimePickerX.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.sendDateTimePickerX.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.sendDateTimePickerX.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.sendDateTimePickerX.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.sendDateTimePickerX.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.sendDateTimePickerX.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.sendDateTimePickerX.CalendarShowToday = true;
            this.sendDateTimePickerX.CalendarShowTodayRect = true;
            this.sendDateTimePickerX.CalendarShowToolTips = false;
            this.sendDateTimePickerX.CalendarShowTrailing = true;
            this.sendDateTimePickerX.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.sendDateTimePickerX.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.sendDateTimePickerX.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.sendDateTimePickerX.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.sendDateTimePickerX.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.sendDateTimePickerX.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.sendDateTimePickerX.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.sendDateTimePickerX.CalendarTitleFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.sendDateTimePickerX.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.sendDateTimePickerX.CalendarTodayBackColor = System.Drawing.Color.Wheat;
            this.sendDateTimePickerX.CalendarTodayFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.sendDateTimePickerX.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.sendDateTimePickerX.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.sendDateTimePickerX.CalendarTodayRectTickness = 2F;
            this.sendDateTimePickerX.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.sendDateTimePickerX.CalendarType = BehComponents.CalendarTypes.Persian;
            this.sendDateTimePickerX.CalendarWeekDaysBackColor = System.Drawing.Color.Wheat;
            this.sendDateTimePickerX.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 7.8F);
            this.sendDateTimePickerX.CalendarWeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.sendDateTimePickerX.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.sendDateTimePickerX.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.sendDateTimePickerX.ClearButtonBackColor = System.Drawing.Color.White;
            this.sendDateTimePickerX.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.sendDateTimePickerX.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("sendDateTimePickerX.ClearButtonImage")));
            this.sendDateTimePickerX.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sendDateTimePickerX.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.sendDateTimePickerX.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.sendDateTimePickerX.ClearButtonText = "";
            this.sendDateTimePickerX.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sendDateTimePickerX.ClearButtonToolTip = "";
            this.sendDateTimePickerX.ClearButtonWidth = 17;
            this.sendDateTimePickerX.ClearDateTimeWhenDownDeleteKey = true;
            this.sendDateTimePickerX.CustomFormat = "";
            this.sendDateTimePickerX.DockSide = BehComponents.DropDownEmpty.Alignments.Left;
            this.sendDateTimePickerX.DropDownClosedWhenClickOnDays = false;
            this.sendDateTimePickerX.DropDownClosedWhenSelectedDateChanged = false;
            this.sendDateTimePickerX.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sendDateTimePickerX.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.sendDateTimePickerX.Format4Binding = "yyyy/MM/dd";
            this.sendDateTimePickerX.Location = new System.Drawing.Point(29, 272);
            this.sendDateTimePickerX.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.sendDateTimePickerX.Name = "sendDateTimePickerX";
            this.sendDateTimePickerX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sendDateTimePickerX.RightToLeftLayout = true;
            this.sendDateTimePickerX.ShowClearButton = false;
            this.sendDateTimePickerX.Size = new System.Drawing.Size(186, 50);
            this.sendDateTimePickerX.TabIndex = 365;
            this.sendDateTimePickerX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sendDateTimePickerX.TextWhenClearButtonClicked = "";
            this.sendDateTimePickerX.SelectedDateChanged += new BehComponents.DateTimePickerX.OnSelectedDateChanged(this.sendDateTimePickerX_SelectedDateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(117, 221);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(120, 38);
            this.label9.TabIndex = 364;
            this.label9.Text = "تاریخ ارسال:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attachmentCheckBox
            // 
            this.attachmentCheckBox.AutoSize = true;
            this.attachmentCheckBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.attachmentCheckBox.Location = new System.Drawing.Point(379, 280);
            this.attachmentCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.attachmentCheckBox.Name = "attachmentCheckBox";
            this.attachmentCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.attachmentCheckBox.Size = new System.Drawing.Size(98, 42);
            this.attachmentCheckBox.TabIndex = 363;
            this.attachmentCheckBox.Text = "پیوست";
            this.attachmentCheckBox.UseVisualStyleBackColor = true;
            this.attachmentCheckBox.CheckedChanged += new System.EventHandler(this.attachmentCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(414, 117);
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
            this.titleTextBox.Location = new System.Drawing.Point(269, 163);
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
            this.label2.Location = new System.Drawing.Point(132, 117);
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
            this.signerTextBox.Location = new System.Drawing.Point(20, 165);
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
            this.label1.Location = new System.Drawing.Point(161, 14);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(76, 38);
            this.label1.TabIndex = 357;
            this.label1.Text = "گیرنده:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // receiverTextBox
            // 
            this.receiverTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.receiverTextBox.Location = new System.Drawing.Point(20, 65);
            this.receiverTextBox.Multiline = false;
            this.receiverTextBox.Name = "receiverTextBox";
            this.receiverTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.receiverTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.receiverTextBox.Size = new System.Drawing.Size(210, 44);
            this.receiverTextBox.TabIndex = 360;
            this.receiverTextBox.Text = "";
            this.receiverTextBox.TextChanged += new System.EventHandler(this.receiverTextBox_TextChanged);
            this.receiverTextBox.Enter += new System.EventHandler(this.receiverTextBox_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(414, 14);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(72, 38);
            this.label19.TabIndex = 356;
            this.label19.Text = "شماره:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idTextBox.Location = new System.Drawing.Point(269, 65);
            this.idTextBox.Multiline = false;
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.idTextBox.Size = new System.Drawing.Size(210, 44);
            this.idTextBox.TabIndex = 355;
            this.idTextBox.Text = "";
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Aquamarine;
            this.showButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.showButton.FlatAppearance.BorderSize = 2;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showButton.Location = new System.Drawing.Point(12, 386);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(200, 51);
            this.showButton.TabIndex = 375;
            this.showButton.Text = "نمایش فایل نامه";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // enactmentTextbox
            // 
            this.enactmentTextbox.Enabled = false;
            this.enactmentTextbox.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.enactmentTextbox.Location = new System.Drawing.Point(192, 331);
            this.enactmentTextbox.Multiline = false;
            this.enactmentTextbox.Name = "enactmentTextbox";
            this.enactmentTextbox.ReadOnly = true;
            this.enactmentTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.enactmentTextbox.Size = new System.Drawing.Size(174, 50);
            this.enactmentTextbox.TabIndex = 373;
            this.enactmentTextbox.Text = "";
            this.enactmentTextbox.TextChanged += new System.EventHandler(this.enactmentTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(372, 337);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 372;
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
            this.seachEnactmentbutton.Location = new System.Drawing.Point(12, 330);
            this.seachEnactmentbutton.Name = "seachEnactmentbutton";
            this.seachEnactmentbutton.Size = new System.Drawing.Size(174, 51);
            this.seachEnactmentbutton.TabIndex = 374;
            this.seachEnactmentbutton.Text = "جستجو مصوبه";
            this.seachEnactmentbutton.UseVisualStyleBackColor = false;
            this.seachEnactmentbutton.Click += new System.EventHandler(this.seachEnactmentbutton_Click);
            // 
            // addOpenFileDialog
            // 
            this.addOpenFileDialog.DefaultExt = "pdf";
            this.addOpenFileDialog.FileName = "addOpenFileDialog";
            this.addOpenFileDialog.Filter = "\"Pdf Files (*.pdf)|*.pdf\"";
            // 
            // editSendingLetterForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::WindowsFormsApp6.Properties.Resources.Blank_New_Logoooo_1;
            this.ClientSize = new System.Drawing.Size(500, 460);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.enactmentTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.seachEnactmentbutton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.docLabel);
            this.Controls.Add(this.docAddFileButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.attachmentLabel);
            this.Controls.Add(this.attachmetAddFileButton);
            this.Controls.Add(this.sendDateTimePickerX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.attachmentCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.signerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receiverTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.idTextBox);
            this.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editSendingLetterForm2";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش نامه ارسالی";
            this.Load += new System.EventHandler(this.editSendingLetterForm2_Load);
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
        private BehComponents.DateTimePickerX sendDateTimePickerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox attachmentCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox signerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox receiverTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox idTextBox;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.RichTextBox enactmentTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button seachEnactmentbutton;
        private System.Windows.Forms.OpenFileDialog addOpenFileDialog;
    }
}