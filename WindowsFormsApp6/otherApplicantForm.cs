using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class otherApplicantForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string otherApplicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\otherApplicant";
        public otherApplicantForm()
        {
            InitializeComponent();
        }

        private void idTextbox_Click(object sender, EventArgs e)
        {
            idTextbox.BackColor = SystemColors.Window;
        }

        private void nameTextbox_Click(object sender, EventArgs e)
        {
            nameTextBox.BackColor = SystemColors.Window;
        }
        private void familyTextbox_Click(object sender, EventArgs e)
        {
            nameTextBox.BackColor = SystemColors.Window;
        }

        private void phoneTextBox_Click(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = SystemColors.Window;
        }

        private void addressTextBox_Click(object sender, EventArgs e)
        {
            addressTextBox.BackColor = SystemColors.Window;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();

            if (nameTextBox.TextLength == 0 || familyTextBox.TextLength == 0 ||  idTextbox.TextLength == 0 || phoneTextBox.TextLength == 0 || addressTextBox.TextLength == 0)
            {
                if (nameTextBox.TextLength == 0)
                    nameTextBox.BackColor = Color.Tomato;
                if (familyTextBox.TextLength == 0)
                    familyTextBox.BackColor = Color.Tomato;
                if (idTextbox.TextLength == 0)
                    idTextbox.BackColor = Color.Tomato;
                if (phoneTextBox.TextLength == 0)
                    phoneTextBox.BackColor = Color.Tomato;
                if (addressTextBox.TextLength == 0)
                    addressTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("مشخصات وارد شده ناقص است", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                int check = 0;
                SqlCommand cmdcheck = new SqlCommand("select count(*) as checked from otherApplicant where id = @id", con1);
                cmdcheck.Parameters.AddWithValue("@id", idTextbox.Text);
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        check = int.Parse(String.Format("{0}", reader["checked"]));
                    }
                }
                if (check == 1)
                {
                    idTextbox.BackColor = Color.Tomato;
                    FMessegeBox.FarsiMessegeBox.Show("متقاضی با این شماره ملی وجود دارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else
                {
                    var myregex = new Regex(@"^[ آاأإؤيبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیة]+$");

                    if (nameTextBox.Text.Any(char.IsDigit) || !myregex.IsMatch(nameTextBox.Text))
                    {
                        nameTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (familyTextBox.Text.Any(char.IsDigit) || !myregex.IsMatch(familyTextBox.Text))
                    {
                        familyTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام خانوادگی باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!idTextbox.Text.All(char.IsDigit) || idTextbox.Text.Any(char.IsWhiteSpace))
                    {
                        idTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!phoneTextBox.Text.All(char.IsDigit) || phoneTextBox.Text.Any(char.IsWhiteSpace) || phoneTextBox.Text.Length != 11)
                    {
                        phoneTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره تلفن باید شامل 11 رقم عدد(همراه با پیش شماره) و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    
                    DialogResult resu = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت این متقاضی مطمئن هستید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (resu != DialogResult.Yes)
                    {
                        con1.Close();
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("insert into otherApplicant(name, family, id, phone, address, explain, subdate)" +
                    " Values(@name, @family, @id, @phone, @address, @explain, @subdate)", con1);
                    cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@family", familyTextBox.Text);
                    cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                    cmd.Parameters.AddWithValue("@explain", explainTextBox.Text + "(اضافه شدن متقاضی در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.ExecuteNonQuery();
                    System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + idTextbox.Text);
                    System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + idTextbox.Text + "\\req");
                    System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + idTextbox.Text + "\\req\\facilities");
                    FMessegeBox.FarsiMessegeBox.Show("متقاضی با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);

                    nameTextBox.Text = "";
                    familyTextBox.Text = "";
                    idTextbox.Text = "";
                    phoneTextBox.Text = "";
                    addressTextBox.Text = "";
                    explainTextBox.Text = "";
                }
            }
            con1.Close();
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

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (addressTextBox.Text.Length != 0 && myreg.IsMatch(addressTextBox.Text.Substring(addressTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                addressTextBox.Text = addressTextBox.Text.Substring(0, addressTextBox.Text.Length - 1);
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

        private void otherApplicantForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = nameTextBox;
        }

        
    }
}
