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
    public partial class editBuyHelpsForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string buyHelpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\buyHelps";
        string id, prebId, preFile, pretype, doc;
        decimal preFee;
        List<KeyValuePair<string, string>> li;
        public editBuyHelpsForm2(string id)
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<string, string>>();
        }

        private void editBuyHelpsForm2_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            buyerNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
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
            cmdget = new SqlCommand("select type, fee, packet, buyerName, buydate, bankAccountId ,bankAccountName, description from buyHelps where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    pretype = typeComboBox.Text = reader.GetString(0);
                    this.preFee = feeNumericUpDown.Value = reader.GetDecimal(1);
                    packetNumericUpDown.Value = reader.GetInt32(2);
                    buyerNameTextBox.Text = reader.GetString(3);
                    buyDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["buydate"])).Date;
                    bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(5));
                    this.prebId = reader.GetString(5);
                    bankAccountNameComboBox.Text = reader.GetString(6);
                    explainTextBox.Text = reader.GetString(7);
                }
            }
            cmdget = new SqlCommand("select docpath from doc where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    preFile = reader.GetString(0);
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
            decimal stock = 0, amount = 0, prestock = 0, preamount = 0;
            SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @id;", con);
            cmdgetst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            using (SqlDataReader reader = cmdgetst.ExecuteReader())
            {
                if (reader.Read())
                {
                    stock = reader.GetDecimal(0);
                }
            }
            if(this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
            {
                cmdgetst = new SqlCommand("select stock from bankAccount where id = @id;", con);
                cmdgetst.Parameters.AddWithValue("@id", this.prebId);
                using (SqlDataReader reader = cmdgetst.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        prestock = reader.GetDecimal(0);
                    }
                }
                if (stock < feeNumericUpDown.Value)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی حساب جدید کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
            }
            else if (feeNumericUpDown.Value > preFee && stock < feeNumericUpDown.Value - preFee)
            {
                FMessegeBox.FarsiMessegeBox.Show("موجودی حساب کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (pretype == "اداری فرهنگی" && typeComboBox.Text == "اداری فرهنگی")
            {
                decimal budget = 0, consume = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "cultureBudget");
                cmdget2.Parameters.AddWithValue("@id", "cultureConsume");
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
                if (feeNumericUpDown.Value > preFee && consume + feeNumericUpDown.Value - preFee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }

                SqlCommand cmdupam, cmdupst;
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@prev", this.prebId);
                    cmdupst.Parameters.AddWithValue("@st", prestock + preFee);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                else if (preFee != feeNumericUpDown.Value)
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock + preFee - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                if (docLabel.BackColor == Color.YellowGreen)
                {
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = this.buyHelpPath + "\\" + this.id + "\\";
                    System.IO.Directory.Delete(targetPath, true);
                    System.IO.Directory.CreateDirectory(targetPath);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                    cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                    cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                    cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                    cmdupdatefile.Parameters.AddWithValue("@dtype", "buyHelp");
                    cmdupdatefile.ExecuteNonQuery();
                }
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update buyHelps set type = @typ, fee = @fee, packet = @pack, buydate = @bdate, subdate = @sdate, buyerName = @buname, bankAccountId = @bId, bankAccountName = @bName, description = @des where id = @id; insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description, enactmentId) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
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
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmd.ExecuteNonQuery();
            }
            else if (pretype == "اداری فرهنگی" && typeComboBox.Text != "اداری فرهنگی")
            {
                SqlCommand cmdgetam = new SqlCommand("select amount from budgetsCurrencies where typename = @id;", con);
                switch (typeComboBox.Text)
                {
                    case "گوشت":
                        cmdgetam.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdgetam.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdgetam.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "متفرقه":
                        cmdgetam.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdgetam.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        amount = reader.GetDecimal(0);
                    }
                }
                cmdgetam = new SqlCommand("select amount from budgetsCurrencies where typename = @id;", con);
                cmdgetam.Parameters.AddWithValue("@id", "cultureConsume");
                using (SqlDataReader reader = cmdgetam.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        preamount = reader.GetDecimal(0);
                    }
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }

                SqlCommand cmdupam, cmdupst;
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@prev", this.prebId);
                    cmdupst.Parameters.AddWithValue("@st", prestock + preFee);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                else if (preFee != feeNumericUpDown.Value)
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock + preFee - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }

                cmdupam = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @am where typename = @prev; update budgetsCurrencies set amount = @newam where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdupam.Parameters.AddWithValue("@prev", "cultureConsume");
                if (typeComboBox.Text == "گوشت")
                {
                    cmdupam.Parameters.AddWithValue("@id", "meat");
                }
                else if (typeComboBox.Text == "مرغ")
                {
                    cmdupam.Parameters.AddWithValue("@id", "chicken");
                }
                else if (typeComboBox.Text == "خواربار")
                {
                    cmdupam.Parameters.AddWithValue("@id", "grocery");
                }
                else if (typeComboBox.Text == "متفرقه")
                {
                    cmdupam.Parameters.AddWithValue("@id", "stock");
                }
                cmdupam.Parameters.AddWithValue("@am", preamount - preFee);
                cmdupam.Parameters.AddWithValue("@newam", amount + feeNumericUpDown.Value);
                cmdupam.ExecuteNonQuery();
                if (docLabel.BackColor == Color.YellowGreen)
                {
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = this.buyHelpPath + "\\" + this.id + "\\";
                    System.IO.Directory.Delete(targetPath, true);
                    System.IO.Directory.CreateDirectory(targetPath);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                    cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                    cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                    cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                    cmdupdatefile.Parameters.AddWithValue("@dtype", "buyHelp");
                    cmdupdatefile.ExecuteNonQuery();
                }
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update buyHelps set type = @typ, fee = @fee, packet = @pack, buydate = @bdate, subdate = @sdate, buyerName = @buname, bankAccountId = @bId, bankAccountName = @bName, description = @des where id = @id; insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description, enactmentId) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
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
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmd.ExecuteNonQuery();
            }
            else if (pretype != "اداری فرهنگی" && typeComboBox.Text == "اداری فرهنگی")
            {
                decimal budget = 0, consume = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "cultureBudget");
                cmdget2.Parameters.AddWithValue("@id", "cultureConsume");
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
                if (feeNumericUpDown.Value > preFee && consume + feeNumericUpDown.Value - preFee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                SqlCommand cmdgetam = new SqlCommand("select amount from budgetsCurrencies where typename = @id;", con);
                switch (this.pretype)
                {
                    case "گوشت":
                        cmdgetam.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdgetam.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdgetam.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "متفرقه":
                        cmdgetam.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdgetam.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        preamount = reader.GetDecimal(0);
                    }
                }
                if (preamount < preFee)
                {
                    FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی {0} برای عودت ارزش ریالی کافی نیست!", this.pretype), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }

                SqlCommand cmdupam, cmdupst;
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@prev", this.prebId);
                    cmdupst.Parameters.AddWithValue("@st", prestock + preFee);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                else if (preFee != feeNumericUpDown.Value)
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock + preFee - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                cmdupam = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @am where typename = @prev; update budgetsCurrencies set amount = @newam where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                switch (this.pretype)
                {
                    case "گوشت":
                        cmdupam.Parameters.AddWithValue("@prev", "meat");
                        break;
                    case "خواربار":
                        cmdupam.Parameters.AddWithValue("@prev", "grocery");
                        break;
                    case "مرغ":
                        cmdupam.Parameters.AddWithValue("@prev", "chicken");
                        break;
                    case "متفرقه":
                        cmdupam.Parameters.AddWithValue("@prev", "stock");
                        break;
                }
                cmdupam.Parameters.AddWithValue("@id", "cultureConsume");
                cmdupam.Parameters.AddWithValue("@am", preamount - preFee);
                cmdupam.Parameters.AddWithValue("@newam", amount + feeNumericUpDown.Value);
                cmdupam.ExecuteNonQuery();
                if (docLabel.BackColor == Color.YellowGreen)
                {
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = this.buyHelpPath + "\\" + this.id + "\\";
                    System.IO.Directory.Delete(targetPath, true);
                    System.IO.Directory.CreateDirectory(targetPath);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                    cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                    cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                    cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                    cmdupdatefile.Parameters.AddWithValue("@dtype", "buyHelp");
                    cmdupdatefile.ExecuteNonQuery();
                }
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update buyHelps set type = @typ, fee = @fee, packet = @pack, buydate = @bdate, subdate = @sdate, buyerName = @buname, bankAccountId = @bId, bankAccountName = @bName, description = @des where id = @id; insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description, enactmentId) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
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
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdgetam = new SqlCommand("select amount from budgetsCurrencies where typename = @id;", con);
                switch (typeComboBox.Text)
                {
                    case "گوشت":
                        cmdgetam.Parameters.AddWithValue("@id", "meat");
                        break;
                    case "خواربار":
                        cmdgetam.Parameters.AddWithValue("@id", "grocery");
                        break;
                    case "مرغ":
                        cmdgetam.Parameters.AddWithValue("@id", "chicken");
                        break;
                    case "متفرقه":
                        cmdgetam.Parameters.AddWithValue("@id", "stock");
                        break;
                }
                using (SqlDataReader reader = cmdgetam.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        amount = reader.GetDecimal(0);
                    }
                }
                if (this.pretype != typeComboBox.Text)
                {
                    cmdgetam = new SqlCommand("select amount from budgetsCurrencies where typename = @id;", con);
                    switch (this.pretype)
                    {
                        case "گوشت":
                            cmdgetam.Parameters.AddWithValue("@id", "meat");
                            break;
                        case "خواربار":
                            cmdgetam.Parameters.AddWithValue("@id", "grocery");
                            break;
                        case "مرغ":
                            cmdgetam.Parameters.AddWithValue("@id", "chicken");
                            break;
                        case "متفرقه":
                            cmdgetam.Parameters.AddWithValue("@id", "stock");
                            break;
                    }
                    using (SqlDataReader reader = cmdgetam.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            preamount = reader.GetDecimal(0);
                        }
                    }
                    if (preamount < preFee)
                    {
                        FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی {0} برای عودت ارزش ریالی کافی نیست!", this.pretype), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                }
                else if (preFee > feeNumericUpDown.Value && amount < preFee - feeNumericUpDown.Value)
                {
                    FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی {0} برای اصلاح کافی نیست!", typeComboBox.Text), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش خرید این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }

                SqlCommand cmdupam, cmdupst;
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@prev", this.prebId);
                    cmdupst.Parameters.AddWithValue("@st", prestock + preFee);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                else if (preFee != feeNumericUpDown.Value)
                {
                    cmdupst = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupst.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmdupst.Parameters.AddWithValue("@newst", stock + preFee - feeNumericUpDown.Value);
                    cmdupst.ExecuteNonQuery();
                }
                if (this.pretype != typeComboBox.Text)
                {
                    cmdupam = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @am where typename = @prev; update budgetsCurrencies set amount = @newam where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    switch (this.pretype)
                    {
                        case "گوشت":
                            cmdupam.Parameters.AddWithValue("@prev", "meat");
                            break;
                        case "خواربار":
                            cmdupam.Parameters.AddWithValue("@prev", "grocery");
                            break;
                        case "مرغ":
                            cmdupam.Parameters.AddWithValue("@prev", "chicken");
                            break;
                        case "متفرقه":
                            cmdupam.Parameters.AddWithValue("@prev", "stock");
                            break;
                    }
                    if (typeComboBox.Text == "گوشت")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "meat");
                    }
                    else if (typeComboBox.Text == "مرغ")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "chicken");
                    }
                    else if (typeComboBox.Text == "خواربار")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "grocery");
                    }
                    else if (typeComboBox.Text == "متفرقه")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "stock");
                    }
                    cmdupam.Parameters.AddWithValue("@am", preamount - preFee);
                    cmdupam.Parameters.AddWithValue("@newam", amount + feeNumericUpDown.Value);
                    cmdupam.ExecuteNonQuery();
                }
                else if (preFee != feeNumericUpDown.Value)
                {
                    cmdupam = new SqlCommand("BEGIN TRY begin tran t1; update budgetsCurrencies set amount = @newam where typename = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    if (typeComboBox.Text == "گوشت")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "meat");
                    }
                    else if (typeComboBox.Text == "مرغ")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "chicken");
                    }
                    else if (typeComboBox.Text == "خواربار")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "grocery");
                    }
                    else if (typeComboBox.Text == "متفرقه")
                    {
                        cmdupam.Parameters.AddWithValue("@id", "stock");
                    }
                    cmdupam.Parameters.AddWithValue("@newam", amount + feeNumericUpDown.Value - preFee);
                    cmdupam.ExecuteNonQuery();
                }
                if (docLabel.BackColor == Color.YellowGreen)
                {
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = this.buyHelpPath + "\\" + this.id + "\\";
                    System.IO.Directory.Delete(targetPath, true);
                    System.IO.Directory.CreateDirectory(targetPath);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                    cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                    cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                    cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                    cmdupdatefile.Parameters.AddWithValue("@dtype", "buyHelp");
                    cmdupdatefile.ExecuteNonQuery();
                }
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update buyHelps set type = @typ, fee = @fee, packet = @pack, buydate = @bdate, subdate = @sdate, buyerName = @buname, bankAccountId = @bId, bankAccountName = @bName, description = @des where id = @id; insert into buyHelpsHistory (id, type, fee, packet, buydate, subdate, buyerName, bankAccountId, bankAccountName, description, enactmentId) Values(@id, @typ, @fee, @pack, @bdate, @sdate, @buName, @bId, @bName, @des, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
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
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmd.ExecuteNonQuery();
            }
            FMessegeBox.FarsiMessegeBox.Show("خرید کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
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

        private void showButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.preFile);
        }

        
    }
}
