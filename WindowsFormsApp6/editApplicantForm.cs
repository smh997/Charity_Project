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

namespace WindowsFormsApp6
{
    public partial class editApplicantForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public editApplicantForm(string p="")
        {
            InitializeComponent();
            idTextbox.EnableContextMenu();
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
            if (p == "افزودن مددجو")
                this.Text = "افزودن مددجو";
            if (p == "ویرایش متقاضی")
                this.Text = "ویرایش متقاضی";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchForm newform;
            if(this.Text == "ویرایش متقاضی")
                newform = new searchForm("متقاضی سایر");
            else
                newform = new searchForm("متقاضی");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            string id;

            if (!idTextbox.Text.Any(char.IsWhiteSpace) && idTextbox.Text.All(char.IsDigit))
            {
                id = ExtensionFunction.PersianToEnglish(idTextbox.Text);
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck;
                if (this.Text == "ویرایش متقاضی")
                    cmdcheck = new SqlCommand("select count(*) as existance from otherApplicant where id = @id", con);
                else
                    cmdcheck = new SqlCommand("select count(*) as existance from applicant where id = @id", con);
                cmdcheck.Parameters.AddWithValue("@id", id);
                int exist = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        exist = int.Parse(String.Format("{0}", reader["existance"]));
                    }
                }
                con.Close();
                if (exist == 1)
                {
                    if(this.Text == "افزودن مددجو")
                    {
                        var newform = new addMemberForm(id);
                        newform.ShowDialog(this);
                    }
                    else if(this.Text == "ویرایش متقاضی")
                    {
                        var newform = new editOtherApplicantForm(id);
                        newform.ShowDialog(this);
                    }
                    else
                    {
                        var newform = new editApplicantForm2(id);
                        newform.ShowDialog(this);
                    }
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("متقاضی با این شماره ملی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }


            }
            else
            {
                FMessegeBox.FarsiMessegeBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
        }

        private void editApplicantForm_Load(object sender, EventArgs e)
        {
            if(this.Text == "افزودن مددجو")
            {
                this.BackColor = Color.LimeGreen;
            }
            setButton.Enabled = false;
            idTextbox.Text = "";
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }
    }
}
