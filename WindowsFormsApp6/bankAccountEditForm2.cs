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
    public partial class bankAccountEditForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id;
        public bankAccountEditForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void bankAccountNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountNameTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountNameTextBox.Text.Substring(bankAccountNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountNameTextBox.Text = bankAccountNameTextBox.Text.Substring(0, bankAccountNameTextBox.Text.Length - 1);
            }
            bankAccountNameTextBox.SelectionStart = bankAccountNameTextBox.Text.Length;
            bankAccountNameTextBox.SelectionLength = 0;
        }

        private void bankAccountEditForm2_Load(object sender, EventArgs e)
        {
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountOwnerNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select name, bankName, ownerName from bankAccount where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(this.id);
                    bankAccountNameTextBox.Text = reader.GetString(0);
                    bankNameTextBox.Text = reader.GetString(1);
                    bankAccountOwnerNameTextBox.Text = reader.GetString(2);
                }
            }
            con.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bankAccountNameTextBox.Text))
            {
                bankAccountNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام حساب وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!bankAccountNumberTextBox.Text.All(char.IsDigit))
            {
                bankAccountNumberTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره حساب باید فقط شامل ارقام باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(bankNameTextBox.Text))
            {
                bankNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام بانک وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            /*if (!bankNameTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                bankNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام بانک باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }*/
            if (String.IsNullOrWhiteSpace(bankAccountOwnerNameTextBox.Text))
            {
                bankAccountOwnerNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام صاحب حساب وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!bankAccountOwnerNameTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                bankAccountOwnerNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام صاحب حساب باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
            if(this.id != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
            {
                int c = 0;
                SqlCommand cmdcheck = new SqlCommand("select count(*) from bankAccount where id = @id;", con);
                using(SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if(c != 0)
                {
                    bankAccountNumberTextBox.BackColor = Color.Tomato;
                    FMessegeBox.FarsiMessegeBox.Show("شماره حساب وارد شده متعلق به یک حساب دیگر موجود در سیستم می‌باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
            }
            SqlCommand cmd = new SqlCommand("update backAccountInfoHistory set id = @newId where id = @id; insert into backAccountInfoHistory (id, name, bankName, ownerName, subdate, enactmentId, description) Values (@newId, @name, @bname, @oname, @sdate, @eId, @des); update bankAccount set id = @newId, name = @name, bankName = @bname, ownerName = @oname where id = @id;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@newId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            cmd.Parameters.AddWithValue("@name", bankAccountNameTextBox.Text);
            cmd.Parameters.AddWithValue("@bname", bankNameTextBox.Text);
            cmd.Parameters.AddWithValue("@oname", bankAccountOwnerNameTextBox.Text);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("حساب با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
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

        private void bankAccountNumberTextBox_Enter(object sender, EventArgs e)
        {
            bankAccountNumberTextBox.BackColor = SystemColors.Window;
        }

        private void bankNameTextBox_Enter(object sender, EventArgs e)
        {
            bankNameTextBox.BackColor = SystemColors.Window;
        }

        private void bankAccountOwnerNameTextBox_Enter(object sender, EventArgs e)
        {
            bankAccountOwnerNameTextBox.BackColor = SystemColors.Window;
        }

        private void bankAccountNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountNumberTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountNumberTextBox.Text.Substring(bankAccountNumberTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountNumberTextBox.Text = bankAccountNumberTextBox.Text.Substring(0, bankAccountNumberTextBox.Text.Length - 1);
            }
            bankAccountNumberTextBox.SelectionStart = bankAccountNumberTextBox.Text.Length;
            bankAccountNumberTextBox.SelectionLength = 0;
        }

        private void bankNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankNameTextBox.Text.Length != 0 && myreg.IsMatch(bankNameTextBox.Text.Substring(bankNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankNameTextBox.Text = bankNameTextBox.Text.Substring(0, bankNameTextBox.Text.Length - 1);
            }
            bankNameTextBox.SelectionStart = bankNameTextBox.Text.Length;
            bankNameTextBox.SelectionLength = 0;
        }

        private void bankAccountOwnerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountOwnerNameTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountOwnerNameTextBox.Text.Substring(bankAccountOwnerNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountOwnerNameTextBox.Text = bankAccountOwnerNameTextBox.Text.Substring(0, bankAccountOwnerNameTextBox.Text.Length - 1);
            }
            bankAccountOwnerNameTextBox.SelectionStart = bankAccountOwnerNameTextBox.Text.Length;
            bankAccountOwnerNameTextBox.SelectionLength = 0;
        }
    }
}
