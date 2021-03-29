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
    public partial class addhelperForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public addhelperForm()
        {
            InitializeComponent();
        }

        private void addhelperForm_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            nameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            familyTextBox.SelectionAlignment = HorizontalAlignment.Center;
            phoneTextBox.SelectionAlignment = HorizontalAlignment.Center;
            addressTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (idTextBox.Text.Length != 0 && myreg.IsMatch(idTextBox.Text.Substring(idTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                idTextBox.Text = idTextBox.Text.Substring(0, idTextBox.Text.Length - 1);
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (nameTextBox.Text.Length != 0 && myreg.IsMatch(nameTextBox.Text.Substring(nameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                nameTextBox.Text = nameTextBox.Text.Substring(0, nameTextBox.Text.Length - 1);
            }
        }

        private void familyTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (familyTextBox.Text.Length != 0 && myreg.IsMatch(familyTextBox.Text.Substring(familyTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                familyTextBox.Text = familyTextBox.Text.Substring(0, familyTextBox.Text.Length - 1);
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (phoneTextBox.Text.Length != 0 && myreg.IsMatch(phoneTextBox.Text.Substring(phoneTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                phoneTextBox.Text = phoneTextBox.Text.Substring(0, phoneTextBox.Text.Length - 1);
            }
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (addressTextBox.Text.Length != 0 && myreg.IsMatch(addressTextBox.Text.Substring(addressTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                addressTextBox.Text = addressTextBox.Text.Substring(0, addressTextBox.Text.Length - 1);
            }
        }

        private void idTextBox_Enter(object sender, EventArgs e)
        {
            idTextBox.BackColor = SystemColors.Window;
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            nameTextBox.BackColor = SystemColors.Window;
        }

        private void familyTextBox_Enter(object sender, EventArgs e)
        {
            familyTextBox.BackColor = SystemColors.Window;
        }

        private void phoneTextBox_Enter(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = SystemColors.Window;
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            addressTextBox.BackColor = SystemColors.Window;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idTextBox.Text))
            {
                idTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره ملی مددکار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!idTextBox.Text.All(char.IsDigit) || idTextBox.TextLength != 10)
            {
                idTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره ملی مددکار باید فقط شامل ارقام و 10 رقم باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                nameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام مددکار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!nameTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                nameTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام مددکار باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(familyTextBox.Text))
            {
                familyTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام خانوادگی مددکار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!familyTextBox.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                familyTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("نام خانوادگی مددکار باید فقط شامل حروف و فاصله باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                phoneTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره تلفن مددکار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (!phoneTextBox.Text.All(char.IsDigit))
            {
                phoneTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره تلفن مددکار باید فقط شامل ارقام و 10 رقم باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                addressTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("آدرس مددکار وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به افزودن این مددکار اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into helper(id, name, family, phone, address, subdate) Values(@id, @name, @family, @phone, @address, @sdate); insert into helperInfoHistory (id, name, family, phone, address, subdate) Values(@id, @name, @family, @phone, @address, @sdate); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextBox.Text));
            cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
            cmd.Parameters.AddWithValue("@family", familyTextBox.Text);
            cmd.Parameters.AddWithValue("@phone", ExtensionFunction.PersianToEnglish(phoneTextBox.Text));
            cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.ExecuteNonQuery();
            FMessegeBox.FarsiMessegeBox.Show("مددکار با موفقیت افزوده شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }

    }
}
