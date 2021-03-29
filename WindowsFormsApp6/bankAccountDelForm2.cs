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
    public partial class bankAccountDelForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id;
        public bankAccountDelForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void bankAccountDelForm2_Load(object sender, EventArgs e)
        {
            bankAccountNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountOwnerNameTextBox.SelectionAlignment = HorizontalAlignment.Center;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select name, bankName, ownerName from bankAccount where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
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

        private void endDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (endDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                endDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(explainTextBox.Text))
            {
                explainTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("توضیحات وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into backAccountInfoHistory (id, name, bankName, ownerName, subdate, enactmentId, description) Values (@id, @name, @bname, @oname, @sdate, @eId, @des); delete from bankAccount where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
            cmd.Parameters.AddWithValue("@name", bankAccountNameTextBox.Text);
            cmd.Parameters.AddWithValue("@bname", bankNameTextBox.Text);
            cmd.Parameters.AddWithValue("@oname", bankAccountOwnerNameTextBox.Text);
            cmd.Parameters.AddWithValue("@sdate", endDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.Parameters.AddWithValue("@des", "(حذف حساب) " + explainTextBox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("حساب با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }
    }
}
