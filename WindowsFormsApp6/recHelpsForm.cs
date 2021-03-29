using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Data.SqlClient;

namespace WindowsFormsApp6
{
    public partial class recHelpsForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string recHelpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\receivedHelps";
        string doc;
        List<KeyValuePair<string, string>> li;
        public recHelpsForm()
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
        }

        private void recHelpsForm_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            helperIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            helperNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cashRadioButton.Checked = true;
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
            con.Close();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "نقدی")
            {
                cashRadioButton.Checked = true;
                typeGroupBox.Enabled = false;
            }
            else
            {
                typeGroupBox.Enabled = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.Text.Length == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("نوع کمک انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            /*if (String.IsNullOrWhiteSpace(helperIdTextbox.Text))
            {
                helperIdTextbox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شناسه ملی اهداکننده وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }*/
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
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایل رسید انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(explainTextBox.Text))
            {
                explainTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("ذکر توضیحات الزامی است. توضیحی وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if(typeComboBox.Text == "نقدی" && bankAccountNumberTextBox.TextLength == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مورد نظر انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت دریافت این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string d = DateTime.Now.Date.ToPersian(); d = "Rec" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
            SqlCommand cmdgetid = new SqlCommand("select id from recHelps where id like '" + d + "%';", con);
            int index = 1, mx = 1;
            using (SqlDataReader reader = cmdgetid.ExecuteReader())
            {
                while (reader.Read())
                {
                    string s = String.Format("{0}", reader["id"]);
                    if (s == "") index = 1;
                    else index = Convert.ToInt32(s.Substring(11)) + 1;
                    mx = Math.Max(mx, index);
                }
            }
            d = d + mx.ToString();
            decimal stock = 0;
            if(cashRadioButton.Checked)
            {
                SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @id", con);
                cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using(SqlDataReader reader = cmdget.ExecuteReader())
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
                switch (typeComboBox.Text)
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

            string fileName = System.IO.Path.GetFileName(doc);
            string targetPath = this.recHelpPath + "\\" + d + "\\";
            System.IO.Directory.CreateDirectory(targetPath);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(doc, destFile, false);
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into recHelps(id, type, fee, packet, recdate, subdate, helperId, helperName, bankAccountId, bankAccountName, description, cashtype) Values(@id, @typ, @fee, @pack, @rdate, @sdate, @hId, @hName, @bId, @bName, @des, @cashtype); insert into recHelpsHistory (id, type, fee, packet, recdate, subdate, helperId, helperName, bankAccountId, bankAccountName, description, cashtype) Values(@id, @typ, @fee, @pack, @rdate, @sdate, @hId, @hName, @bId, @bName, @des, @cashtype); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", d);
            cmd.Parameters.AddWithValue("@typ", typeComboBox.Text);
            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@pack", packetNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@rdate", recDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@hId", ExtensionFunction.PersianToEnglish(helperIdTextbox.Text));
            cmd.Parameters.AddWithValue("@hName", helperNameTextBox.Text);
            cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
            if (cashRadioButton.Checked)
            {
                cmd.Parameters.AddWithValue("@cashtype", "نقدی");
            }
            else
            {
                cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
            }
            cmd.Parameters.AddWithValue("@dname", fileName);
            cmd.Parameters.AddWithValue("@dpath", destFile);
            cmd.Parameters.AddWithValue("@dtype", "recHelp");
            cmd.ExecuteNonQuery();
            SqlCommand cmd2;
            if(cashRadioButton.Checked)
            {
                cmd2 = new SqlCommand("update bankAccount set stock = @st where id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                cmd2.Parameters.AddWithValue("@st", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "گوشت")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "meat");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "مرغ")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "chicken");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "خواربار")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "grocery");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "ازدواج")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "marry");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "ایتام")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "orphan");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            else if (typeComboBox.Text == "متفرقه")
            {
                cmd2 = new SqlCommand("update budgetsCurrencies set amount = @amount where typename = @typ;", con);
                cmd2.Parameters.AddWithValue("@typ", "stock");
                cmd2.Parameters.AddWithValue("@amount", stock + feeNumericUpDown.Value);
                cmd2.ExecuteNonQuery();
            }
            FMessegeBox.FarsiMessegeBox.Show("دریافت کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
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
            using(SqlDataReader reader = cmd.ExecuteReader())
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

        private void explainTextBox_Enter(object sender, EventArgs e)
        {
            explainTextBox.BackColor = SystemColors.Window;
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
    }
}
