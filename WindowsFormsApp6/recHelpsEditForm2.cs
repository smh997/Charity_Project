using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class recHelpsEditForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string recHelpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\receivedHelps";
        string id, prebId, preFile, doc, precashtype;
        decimal preFee;
        List<KeyValuePair<string, string>> li;
        public recHelpsEditForm2(string id)
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<string, string>>();
        }

        private void recHelpsEditForm2_Load(object sender, EventArgs e)
        {
            typeTextBox.SelectionAlignment = HorizontalAlignment.Center;
            helperIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            helperNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    bankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            cmdget = new SqlCommand("select type, fee, packet, helperId, helperName, recdate, bankAccountId ,bankAccountName, description, cashtype from recHelps where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    typeTextBox.Text = reader.GetString(0);
                    this.preFee = feeNumericUpDown.Value = reader.GetDecimal(1);
                    packetNumericUpDown.Value = reader.GetInt32(2);
                    helperIdTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(3));
                    helperNameTextBox.Text = reader.GetString(4);
                    recDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["recdate"])).Date;
                    bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(6));
                    this.prebId = reader.GetString(6);
                    bankAccountNameComboBox.Text = reader.GetString(7);
                    explainTextBox.Text = reader.GetString(8);
                    if(reader.GetString(9) == "نقدی")
                    {
                        cashRadioButton.Checked = true;
                        this.precashtype = "نقدی";
                    }
                    else
                    {
                        nonCashRadioButton.Checked = true;
                        this.precashtype = "غیرنقدی";
                        bankAccountNameComboBox.SelectedIndex = -1;
                        bankAccountNumberTextBox.Text = "";
                    }
                }
            }
            cmdget = new SqlCommand("select docpath from doc where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    preFile = reader.GetString(0);
                }
            }
            SqlCommand cmdcheck = new SqlCommand("select count(*) from bankAccount where id = @id;", con);
            cmdcheck.Parameters.AddWithValue("@id", this.prebId);
            int c = 0;
            using(SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    c = reader.GetInt32(0);
                }
            }
            if(c == 0)
            {
                bankAccountNameComboBox.Enabled = false;
                bankAccountNameComboBox.Text += "(حذف شده)";
                feeNumericUpDown.Enabled = false;
                typeGroupBox.Enabled = cashRadioButton.Enabled = nonCashRadioButton.Enabled = false;
            }
            con.Close();
        }

        private void helperIdTextbox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (helperIdTextbox.Text.Length != 0 && myreg.IsMatch(helperIdTextbox.Text.Substring(helperIdTextbox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                helperIdTextbox.Text = helperIdTextbox.Text.Substring(0, helperIdTextbox.Text.Length - 1);
            }
        }

        private void helperIdTextbox_Enter(object sender, EventArgs e)
        {
            helperIdTextbox.BackColor = SystemColors.Window;
        }

        private void docAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب فایل رسید";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc = addOpenFileDialog.FileName;
                docLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                addOpenFileDialog.FileName = "*.pdf";
            }
        }

        private void bankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[bankAccountNameComboBox.SelectedIndex].Key);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name, family from helper where id = @id;", con);
            cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(helperIdTextbox.Text));
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    helperNameTextBox.Text = reader.GetString(0) + " " + reader.GetString(1);
                    flag = true;
                }
            }
            con.Close();
            if (!flag)
            {
                helperNameTextBox.Text = "";
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.preFile);
        }

        private void explainTextBox_Enter(object sender, EventArgs e)
        {
            explainTextBox.BackColor = SystemColors.Window;
        }

        private void seachEnactmentbutton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!helperIdTextbox.Text.All(char.IsDigit) || helperIdTextbox.TextLength != 10)
            {
                helperIdTextbox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شناسه ملی اهداکننده باید فقط شامل ارقام و 10 رقم باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!String.IsNullOrWhiteSpace(helperIdTextbox.Text) && String.IsNullOrWhiteSpace(helperNameTextBox.Text))
            {
                helperIdTextbox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره ملی وارد شده ولی نام اهداکننده بررسی نشده یا وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(explainTextBox.Text))
            {
                explainTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("ذکر توضیحات الزامی است. توضیحی وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            decimal stock = 0, prestock = 0;
            if (cashRadioButton.Checked && this.precashtype == "نقدی")
            {
                SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @id", con);
                cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                if(this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    SqlCommand cmdget2 = new SqlCommand("select stock from bankAccount where id = @id", con);
                    cmdget2.Parameters.AddWithValue("@id", this.prebId);
                    using (SqlDataReader reader = cmdget2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prestock = reader.GetDecimal(0);
                        }
                    }
                }
            }
            else if (cashRadioButton.Checked && this.precashtype != "نقدی")
            {
                SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @id", con);
                cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                switch (typeTextBox.Text)
                {
                    case "گوشت":
                        cmdget2.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdget2.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdget2.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "ازدواج":
                        cmdget2.Parameters.AddWithValue("@id", "marry");
                        break;
                    case "ایتام":
                        cmdget2.Parameters.AddWithValue("@id", "orphan");
                        break;
                    case "متفرقه":
                        cmdget2.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        prestock = reader.GetDecimal(0);
                    }
                }
            }
            else if (!cashRadioButton.Checked && this.precashtype == "نقدی")
            {
                SqlCommand cmdget2 = new SqlCommand("select stock from bankAccount where id = @id", con);
                cmdget2.Parameters.AddWithValue("@id", this.prebId);
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        prestock = reader.GetDecimal(0);
                    }
                }
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                switch (typeTextBox.Text)
                {
                    case "گوشت":
                        cmdget.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdget.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdget.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "ازدواج":
                        cmdget.Parameters.AddWithValue("@id", "marry");
                        break;
                    case "ایتام":
                        cmdget.Parameters.AddWithValue("@id", "orphan");
                        break;
                    case "متفرقه":
                        cmdget.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
            }
            else
            {
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                switch (typeTextBox.Text)
                {
                    case "گوشت":
                        cmdget.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdget.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdget.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "ازدواج":
                        cmdget.Parameters.AddWithValue("@id", "marry");
                        break;
                    case "ایتام":
                        cmdget.Parameters.AddWithValue("@id", "orphan");
                        break;
                    case "متفرقه":
                        cmdget.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
            }
            if ((this.precashtype == "نقدی" && (nonCashRadioButton.Checked || this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))) || (this.precashtype == "غیرنقدی" && cashRadioButton.Checked))
            {
                if (prestock < preFee)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی حساب قبلی از ارزش ریالی ثبت شده قبلی کمتر می‌باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
            }
            if ((this.precashtype == "نقدی" && cashRadioButton.Checked) || (this.precashtype == "غیرنقدی" && nonCashRadioButton.Checked))
            {
                if (feeNumericUpDown.Value < preFee && stock < preFee - feeNumericUpDown.Value)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی برای ویرایش کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
            }
            
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت دریافت این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            if (docLabel.BackColor == Color.YellowGreen)
            {
                string fileName = System.IO.Path.GetFileName(doc);
                string targetPath = this.recHelpPath + "\\" + this.id + "\\";
                System.IO.Directory.Delete(targetPath, true);
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);
                SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmdupdatefile.Parameters.AddWithValue("@dtype", "recHelp");
                cmdupdatefile.ExecuteNonQuery();
            }
            
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update recHelps set fee = @fee, packet = @pack, recdate = @rdate, subdate = @sdate, helperId = @hId, helperName = @hName, bankAccountId = @bId, bankAccountName = @bName, description = @des, cashtype = @cashtype where id = @id; insert into recHelpsHistory (id, type, fee, packet, recdate, subdate, helperId, helperName, bankAccountId, bankAccountName, description, enactmentId, cashtype) Values(@id, @typ, @fee, @pack, @rdate, @sdate, @hId, @hName, @bId, @bName, @des, @eId, @cashtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@typ", typeTextBox.Text);
            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@pack", packetNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@rdate", recDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@hId", ExtensionFunction.PersianToEnglish(helperIdTextbox.Text));
            cmd.Parameters.AddWithValue("@hName", helperNameTextBox.Text);
            cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            if (cashRadioButton.Checked)
            {
                cmd.Parameters.AddWithValue("@cashtype", "نقدی");
            }
            else
            {
                cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
            }
            cmd.ExecuteNonQuery();
            SqlCommand cmd2;
            if (this.precashtype == "نقدی" && cashRadioButton.Checked)
            {
                if(this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update bankAccount set stock = @st where id = @id;", con);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@st", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "گوشت")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "meet");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "meet");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "meat");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "مرغ")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "chicken");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "chicken");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "chicken");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "خواربار")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "grocery");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "grocery");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "grocery");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "ازدواج")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "marry");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "marry");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "marry");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "ایتام")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "orphan");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "orphan");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "orphan");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            else if (typeTextBox.Text == "متفرقه")
            {
                if (this.precashtype == "نقدی" && nonCashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update budgetsCurrencies set amount = @newst where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", this.prebId);
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", "stock");
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else if (this.precashtype == "غیرنقدی" && cashRadioButton.Checked)
                {
                    cmd2 = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @st where typename = @prev; update bankAccount set stock = @st where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd2.Parameters.AddWithValue("@prev", "stock");
                    cmd2.Parameters.AddWithValue("@st", prestock - preFee);
                    cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd2.Parameters.AddWithValue("@newst", stock + feeNumericUpDown.Value);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                    cmd2.Parameters.AddWithValue("@typ", "stock");
                    cmd2.Parameters.AddWithValue("@amount", stock - (preFee - feeNumericUpDown.Value));
                    cmd2.ExecuteNonQuery();
                }
            }
            FMessegeBox.FarsiMessegeBox.Show("دریافت کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }

        private void cashRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bankAccountNameComboBox.Enabled = cashRadioButton.Checked;
            packetNumericUpDown.Enabled = nonCashRadioButton.Checked;
            if (!packetNumericUpDown.Enabled)
            {
                packetNumericUpDown.Value = 1;
            }
            if (!bankAccountNameComboBox.Enabled)
            {
                bankAccountNameComboBox.SelectedIndex = -1;
            }
        }

        private void nonCashRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bankAccountNameComboBox.Enabled = cashRadioButton.Checked;
            packetNumericUpDown.Enabled = nonCashRadioButton.Checked;
            if (!packetNumericUpDown.Enabled)
            {
                packetNumericUpDown.Value = 1;
            }
            if (!bankAccountNameComboBox.Enabled)
            {
                bankAccountNameComboBox.SelectedIndex = -1;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("ویرایش اطلاعات مددکار");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                helperIdTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                updateButton.PerformClick();
            }

        }

        private void recDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (recDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                recDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void explainTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (explainTextBox.Text.Length != 0 && myreg.IsMatch(explainTextBox.Text.Substring(explainTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                explainTextBox.Text = explainTextBox.Text.Substring(0, explainTextBox.Text.Length - 1);
            }
        }
    }
}
