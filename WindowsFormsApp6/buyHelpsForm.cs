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
    public partial class buyHelpsForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string buyHelpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\buyHelps";
        string doc;
        List<KeyValuePair<string, string>> li;
        public buyHelpsForm()
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
        }

        private void buyHelpForm_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            buyerNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void buyDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (buyDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                buyDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
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

        private void buyerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (buyerNameTextBox.Text.Length != 0 && myreg.IsMatch(buyerNameTextBox.Text.Substring(buyerNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                buyerNameTextBox.Text = buyerNameTextBox.Text.Substring(0, buyerNameTextBox.Text.Length - 1);
            }
        }

        private void buyerNameTextBox_Enter(object sender, EventArgs e)
        {
            buyerNameTextBox.BackColor = SystemColors.Window;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.Text.Length == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("نوع کمک انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(buyerNameTextBox.Text))
            {
                buyerNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام خریدار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
            if (bankAccountNameComboBox.SelectedIndex == -1)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مورد نظر انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            decimal budget = 0, consume = 0, stock = 0, amount = 0;
            if (typeComboBox.Text == "اداری فرهنگی")
            {
                SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @id;", con);
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "cultureBudget");
                cmdget2.Parameters.AddWithValue("@id", "cultureConsume");
                cmdgetst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consume = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdgetst.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                if (consume + feeNumericUpDown.Value > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                if (stock < feeNumericUpDown.Value)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی حساب کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                string d = DateTime.Now.Date.ToPersian(); d = "Buy" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
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
                string fileName = System.IO.Path.GetFileName(doc);
                string targetPath = this.buyHelpPath + "\\" + d + "\\";
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);

                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into buyHelps(id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des); insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); update budgetsCurrencies set amount = @amount where typename = @dtyp; update bankAccount set stock = @newst where id = @bId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", d);
                cmd.Parameters.AddWithValue("@typ", typeComboBox.Text);
                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@pack", packetNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@bdate", buyDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@buName", buyerNameTextBox.Text);
                cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
                cmd.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "buyHelp");
                cmd.Parameters.AddWithValue("@dtyp", "cultureConsume");
                cmd.Parameters.AddWithValue("@amount", consume + feeNumericUpDown.Value);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @id;", con);
                cmdgetst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using (SqlDataReader reader = cmdgetst.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                if (stock < feeNumericUpDown.Value)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی حساب کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                string d = DateTime.Now.Date.ToPersian(); d = "Buy" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
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
                    case "متفرقه":
                        cmdget.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        amount = reader.GetDecimal(0);
                    }
                }
                string fileName = System.IO.Path.GetFileName(doc);
                string targetPath = this.buyHelpPath + "\\" + d + "\\";
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);

                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into buyHelps(id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des); insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); update budgetsCurrencies set amount = @amount where typename = @dtyp; update bankAccount set stock = @newst where id = @bId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", d);
                cmd.Parameters.AddWithValue("@typ", typeComboBox.Text);
                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@pack", packetNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@bdate", buyDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@buName", buyerNameTextBox.Text);
                cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
                cmd.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "buyHelp");

                if (typeComboBox.Text == "گوشت")
                {
                    cmd.Parameters.AddWithValue("@dtyp", "meat");
                    cmd.Parameters.AddWithValue("@amount", amount + feeNumericUpDown.Value);
                }
                else if (typeComboBox.Text == "مرغ")
                {
                    cmd.Parameters.AddWithValue("@dtyp", "chicken");
                    cmd.Parameters.AddWithValue("@amount", amount + feeNumericUpDown.Value);
                }
                else if (typeComboBox.Text == "خواربار")
                {
                    cmd.Parameters.AddWithValue("@dtyp", "grocery");
                    cmd.Parameters.AddWithValue("@amount", amount + feeNumericUpDown.Value);
                }
                else if (typeComboBox.Text == "متفرقه")
                {
                    cmd.Parameters.AddWithValue("@dtyp", "stock");
                    cmd.Parameters.AddWithValue("@amount", amount + feeNumericUpDown.Value);
                }
                cmd.ExecuteNonQuery();
            }
            
            
            FMessegeBox.FarsiMessegeBox.Show("خرید کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }
    }
}
