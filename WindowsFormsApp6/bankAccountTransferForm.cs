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
    public partial class bankAccountTransferForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string moneyTransferPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\moneyTransfer";
        List<KeyValuePair<string, string>> li;
        string doc;
        public bankAccountTransferForm()
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
        }

        private void bankAccountTransferForm_Load(object sender, EventArgs e)
        {
            FMessegeBox.FarsiMessegeBox.Show("در انتخاب حساب‌ها دقت کنید، پس از ثبت انتقال امکان تغییر شماره حساب‌ها وجود ندارد!", "هشدار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    srcBankAccountNameComboBox.Items.Add(reader.GetString(1));
                    dstBankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            con.Close();
            srcBankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dstBankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            srcBankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            dstBankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            transporterNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void srcBankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            srcBankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[srcBankAccountNameComboBox.SelectedIndex].Key);
        }

        private void dstBankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dstBankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[dstBankAccountNameComboBox.SelectedIndex].Key);
        }

        private void transporterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (transporterNameTextBox.Text.Length != 0 && myreg.IsMatch(transporterNameTextBox.Text.Substring(transporterNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                transporterNameTextBox.Text = transporterNameTextBox.Text.Substring(0, transporterNameTextBox.Text.Length - 1);
            }
            transporterNameTextBox.SelectionStart = transporterNameTextBox.Text.Length;
            transporterNameTextBox.SelectionLength = 0;
        }

        private void transferDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (transferDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                transferDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(srcBankAccountNameComboBox.SelectedIndex == -1)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مبدا انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (dstBankAccountNameComboBox.SelectedIndex == -1)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مقصد انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (srcBankAccountNameComboBox.SelectedIndex == dstBankAccountNameComboBox.SelectedIndex)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مبدا و مقصد نمی‌تواند یکسان باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(transporterNameTextBox.Text))
            {
                transporterNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام انتقال‌دهنده وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!transporterNameTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                transporterNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام انتقال‌دهنده باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if(docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایل رسید انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(explainTextBox.Text))
            {
                explainTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("توضیحات وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetstock = new SqlCommand("select stock from bankAccount where id = @id;", con);
            decimal stock = 0;
            cmdgetstock.Parameters.AddWithValue("@id", li[srcBankAccountNameComboBox.SelectedIndex].Key);
            using(SqlDataReader reader = cmdgetstock.ExecuteReader())
            {
                if (reader.Read())
                {
                    stock = reader.GetDecimal(0);
                }
            }
            if(stock < feeNumericUpDown.Value + taxNumericUpDown.Value)
            {
                FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی حساب مبدا {0} ریال است و کافی نیست!", stock), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت انتثال اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            string d = DateTime.Now.Date.ToPersian(); d = "MT" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
            SqlCommand cmdget = new SqlCommand("select id from moneyTransfer where id like '" + d + "%';", con);
            int index = 1, mx = 1;
            using (SqlDataReader reader = cmdget.ExecuteReader())
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
            decimal dststock = 0;
            cmdget = new SqlCommand("select stock from bankAccount where id = @id", con);
            cmdget.Parameters.AddWithValue("@id", li[dstBankAccountNameComboBox.SelectedIndex].Key);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    dststock = reader.GetDecimal(0);
                }
            }
            
            string fileName = System.IO.Path.GetFileName(doc);
            string targetPath = this.moneyTransferPath + "\\" + d + "\\";
            System.IO.Directory.CreateDirectory(targetPath);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(doc, destFile, false);
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @srcst where id = @srcid; update bankAccount set stock = @dstst where id = @dstid; insert into moneyTransfer (id, srcid, dstid, fee, tax, transporterName, subdate, transferdate, description) Values (@id, @srcid, @dstid, @fee, @tax, @tname, @sdate, @tdate, @des); insert into moneyTransferHistory (id, srcid, dstid, fee, tax, transporterName, subdate, transferdate, description) Values (@id, @srcid, @dstid, @fee, @tax, @tname, @sdate, @tdate, @des); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@srcst", stock - feeNumericUpDown.Value - taxNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@dstst", dststock + feeNumericUpDown.Value + taxNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@srcid", li[srcBankAccountNameComboBox.SelectedIndex].Key);
            cmd.Parameters.AddWithValue("@dstid", li[dstBankAccountNameComboBox.SelectedIndex].Key);
            cmd.Parameters.AddWithValue("@id", d);
            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@tax", taxNumericUpDown.Value);
            cmd.Parameters.AddWithValue("@tname", transporterNameTextBox.Text);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@tdate", transferDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
            cmd.Parameters.AddWithValue("@dname", fileName);
            cmd.Parameters.AddWithValue("@dpath", destFile);
            cmd.Parameters.AddWithValue("@dtype", "moneyTransfer");
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("انتقال با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void transporterNameTextBox_Enter(object sender, EventArgs e)
        {
            transporterNameTextBox.BackColor = SystemColors.Window;
        }

        private void explainTextBox_Enter(object sender, EventArgs e)
        {
            explainTextBox.BackColor = SystemColors.Window;
        }

        private void explainTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (explainTextBox.Text.Length != 0 && myreg.IsMatch(explainTextBox.Text.Substring(explainTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                explainTextBox.Text = explainTextBox.Text.Substring(0, explainTextBox.Text.Length - 1);
            }
            explainTextBox.SelectionStart = explainTextBox.Text.Length;
            explainTextBox.SelectionLength = 0;
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
                doc = "";
                addOpenFileDialog.FileName = "*.pdf";
            }
        }
    }
}
