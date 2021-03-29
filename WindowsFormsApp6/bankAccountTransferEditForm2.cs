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
    public partial class bankAccountTransferEditForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string moneyTransferPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\moneyTransfer";
        List<KeyValuePair<string, string>> li;
        string id, preSrcid, preDstid, preFile, doc;
        decimal preFee, preTax;
        public bankAccountTransferEditForm2(string id)
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
            this.id = id;
        }

        private void bankAccountTransferEditForm2_Load(object sender, EventArgs e)
        {
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetaccounts = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdgetaccounts.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    srcBankAccountNameComboBox.Items.Add(reader.GetString(1));
                    dstBankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            SqlCommand cmdget = new SqlCommand("select srcid, dstid, fee, tax, transporterName, subdate, transferdate, description from moneyTransfer where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    preSrcid = reader.GetString(0);
                    srcBankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(preSrcid);
                    preDstid = reader.GetString(1);
                    dstBankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(preDstid);
                    feeNumericUpDown.Value = preFee = reader.GetDecimal(2);
                    taxNumericUpDown.Value = preTax = reader.GetDecimal(3);
                    transporterNameTextBox.Text = reader.GetString(4);
                    transferDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["transferdate"])).Date;
                    explainTextBox.Text = reader.GetString(7);
                }
            }
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].Key == preSrcid)
                {
                    srcBankAccountNameComboBox.SelectedIndex = i;
                }
                if (li[i].Key == preDstid)
                {
                    dstBankAccountNameComboBox.SelectedIndex = i;
                }
            }
            if (srcBankAccountNameComboBox.SelectedIndex == -1)
            {
                srcBankAccountNameComboBox.Text = "حساب حذف شده";
            }
            if (dstBankAccountNameComboBox.SelectedIndex == -1)
            {
                dstBankAccountNameComboBox.Text = "حساب حذف شده";
            }
            SqlCommand cmdgetfile = new SqlCommand("select docpath from doc where id = @id;", con);
            cmdgetfile.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetfile.ExecuteReader())
            {
                if (reader.Read())
                {
                    preFile = reader.GetString(0);
                }
            }
            con.Close();
            srcBankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dstBankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            srcBankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            dstBankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            transporterNameTextBox.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.preFile);
        }

        private void srcBankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            srcBankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[srcBankAccountNameComboBox.SelectedIndex].Key);
        }

        private void dstBankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dstBankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[dstBankAccountNameComboBox.SelectedIndex].Key);
        }

        private void transferDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (transferDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                transferDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
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

        private void transporterNameTextBox_Enter(object sender, EventArgs e)
        {
            transporterNameTextBox.BackColor = SystemColors.Window;
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
                doc = "";
                addOpenFileDialog.FileName = "*.pdf";
                docLabel.BackColor = Color.LimeGreen;
            }
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (srcBankAccountNameComboBox.Enabled && srcBankAccountNameComboBox.SelectedIndex == -1)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مبدا انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (dstBankAccountNameComboBox.Enabled && dstBankAccountNameComboBox.SelectedIndex == -1)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب مقصد انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (srcBankAccountNameComboBox.Enabled && dstBankAccountNameComboBox.Enabled && srcBankAccountNameComboBox.SelectedIndex == dstBankAccountNameComboBox.SelectedIndex)
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
            if (docLabel.BackColor == Color.Red)
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
            decimal srcstock = 0;
            cmdgetstock.Parameters.AddWithValue("@id", li[srcBankAccountNameComboBox.SelectedIndex].Key);
            using (SqlDataReader reader = cmdgetstock.ExecuteReader())
            {
                if (reader.Read())
                {
                    srcstock = reader.GetDecimal(0);
                }
            }
            decimal dststock = 0;
            SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @id", con);
            cmdget.Parameters.AddWithValue("@id", li[dstBankAccountNameComboBox.SelectedIndex].Key);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    dststock = reader.GetDecimal(0);
                }
            }

            if (preFee + preTax < (feeNumericUpDown.Value + taxNumericUpDown.Value) && srcstock < (feeNumericUpDown.Value + taxNumericUpDown.Value) - (preFee + preTax))
            {
                FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی حساب مبدا {0} ریال و ما به تفاوت {0} ریال است و موجودی کافی نیست!", srcstock, (feeNumericUpDown.Value + taxNumericUpDown.Value) - (preFee + preTax)), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            else if (preFee + preTax > (feeNumericUpDown.Value + taxNumericUpDown.Value) && dststock < (preFee + preTax) - (feeNumericUpDown.Value + taxNumericUpDown.Value))
            {
                FMessegeBox.FarsiMessegeBox.Show(String.Format("موجودی حساب مقصد {0} ریال و ما به تفاوت {0} ریال است و موجودی کافی نیست!", srcstock, (feeNumericUpDown.Value + taxNumericUpDown.Value) - (preFee + preTax)), "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }

            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش انتقال اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }

            if(docLabel.BackColor == Color.YellowGreen)
            {
                string fileName = System.IO.Path.GetFileName(doc);
                string targetPath = this.moneyTransferPath + "\\" + this.id + "\\";
                System.IO.Directory.Delete(targetPath, true);
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);
                SqlCommand cmdupdatefile = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdupdatefile.Parameters.AddWithValue("@id", this.id);
                cmdupdatefile.Parameters.AddWithValue("@dname", fileName);
                cmdupdatefile.Parameters.AddWithValue("@dpath", destFile);
                cmdupdatefile.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmdupdatefile.Parameters.AddWithValue("@dtype", "moneyTransfer");
                cmdupdatefile.ExecuteNonQuery();
            }

            if(srcBankAccountNameComboBox.Text != "حساب حذف شده" && srcBankAccountNameComboBox.Text != "حساب حذف شده" && (preFee + preTax != (feeNumericUpDown.Value + taxNumericUpDown.Value)))
            {
                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @srcst where id = @srcid; update bankAccount set stock = @dstst where id = @dstid; update moneyTransfer set fee = @fee, tax = @tax, transporterName = @tname, subdate = @sdate, transferdate = @tdate, description = @des where id = @id; insert into moneyTransferHistory (id, srcid, dstid, fee, tax, transporterName, subdate, transferdate, enactmentId, description) Values (@id, @srcid, @dstid, @fee, @tax, @tname, @sdate, @tdate, @eId, @des); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdupdate.Parameters.AddWithValue("@srcst", srcstock - ((feeNumericUpDown.Value + taxNumericUpDown.Value) - (preFee + preTax)));
                cmdupdate.Parameters.AddWithValue("@dstst", dststock - ((preFee + preTax) - (feeNumericUpDown.Value + taxNumericUpDown.Value)));
                cmdupdate.Parameters.AddWithValue("@srcid", li[srcBankAccountNameComboBox.SelectedIndex].Key);
                cmdupdate.Parameters.AddWithValue("@dstid", li[dstBankAccountNameComboBox.SelectedIndex].Key);
                cmdupdate.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                cmdupdate.Parameters.AddWithValue("@tax", taxNumericUpDown.Value);
                cmdupdate.Parameters.AddWithValue("@tname", transporterNameTextBox.Text);
                cmdupdate.Parameters.AddWithValue("@id", this.id);
                cmdupdate.Parameters.AddWithValue("@tdate", transferDateTimePickerX.SelectedDateInDateTime.Date);
                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmdupdate.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update moneyTransfer set transporterName = @tname, subdate = @sdate, transferdate = @tdate, description = @des where id = @id; insert into moneyTransferHistory (id, srcid, dstid, fee, tax, transporterName, subdate, transferdate, enactmentId, description) Values (@id, @srcid, @dstid, @fee, @tax, @tname, @sdate, @tdate, @eId, @des); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdupdate.Parameters.AddWithValue("@srcid", li[srcBankAccountNameComboBox.SelectedIndex].Key);
                cmdupdate.Parameters.AddWithValue("@dstid", li[dstBankAccountNameComboBox.SelectedIndex].Key);
                cmdupdate.Parameters.AddWithValue("@id", this.id);
                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                cmdupdate.Parameters.AddWithValue("@tax", taxNumericUpDown.Value);
                cmdupdate.Parameters.AddWithValue("@tname", transporterNameTextBox.Text);
                cmdupdate.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmdupdate.Parameters.AddWithValue("@tdate", transferDateTimePickerX.SelectedDateInDateTime.Date);
                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                cmdupdate.ExecuteNonQuery();
            }
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("انتقال با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        
    }
}
