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
    public partial class bankAccountCreateForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public bankAccountCreateForm()
        {
            InitializeComponent();
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
            /*if (!bankAccountOwnerNameTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                bankAccountOwnerNameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام صاحب حساب باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }*/

            if (String.IsNullOrWhiteSpace(explainTextBox.Text))
            {
                explainTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("توضیحات وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select id, name from bankAccount;", con);
            List<KeyValuePair<string, string>> li = new List<KeyValuePair<string, string>>();
            using(SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(0)));
                }
            }
            bool flag = true;
            foreach(var ac in li)
            {
                if(ac.Key == bankAccountNumberTextBox.Text || ac.Value == bankAccountNameTextBox.Text)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب دیگری با این نام یا شماره حساب موجود است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into bankAccount (id, name, bankName, stock, ownerName) Values(@id, @name, @bname, @st, @oname); insert into backAccountInfoHistory (id, name, bankName, ownerName, subdate, enactmentId, description) Values (@id, @name, @bname, @oname, @sdate, @eId, @des); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            cmd.Parameters.AddWithValue("@name", bankAccountNameTextBox.Text);
            cmd.Parameters.AddWithValue("@bname", bankNameTextBox.Text);
            cmd.Parameters.AddWithValue("@st", 0);
            cmd.Parameters.AddWithValue("@oname", bankAccountOwnerNameTextBox.Text);
            cmd.Parameters.AddWithValue("@sdate", createDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.Parameters.AddWithValue("@des", "(ایجاد حساب)" + explainTextBox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("حساب با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void bankAccountCreateForm_Load(object sender, EventArgs e)
        {
            bankAccountNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountOwnerNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void bankAccountNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountNameTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountNameTextBox.Text.Substring(bankAccountNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountNameTextBox.Text = bankAccountNameTextBox.Text.Substring(0, bankAccountNameTextBox.Text.Length - 1);
            }
        }

        private void bankAccountNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountNumberTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountNumberTextBox.Text.Substring(bankAccountNumberTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountNumberTextBox.Text = bankAccountNumberTextBox.Text.Substring(0, bankAccountNumberTextBox.Text.Length - 1);
            }
        }

        private void bankNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankNameTextBox.Text.Length != 0 && myreg.IsMatch(bankNameTextBox.Text.Substring(bankNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankNameTextBox.Text = bankNameTextBox.Text.Substring(0, bankNameTextBox.Text.Length - 1);
            }
        }

        private void bankAccountOwnerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (bankAccountOwnerNameTextBox.Text.Length != 0 && myreg.IsMatch(bankAccountOwnerNameTextBox.Text.Substring(bankAccountOwnerNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                bankAccountOwnerNameTextBox.Text = bankAccountOwnerNameTextBox.Text.Substring(0, bankAccountOwnerNameTextBox.Text.Length - 1);
            }
        }

        private void bankAccountNameTextBox_Enter(object sender, EventArgs e)
        {
            bankAccountNameTextBox.BackColor = SystemColors.Window;
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

        private void searchButton_Click(object sender, EventArgs e)
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

        private void createDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (createDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                createDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }
    }
}
