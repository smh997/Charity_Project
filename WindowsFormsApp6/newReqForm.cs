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
    public partial class newReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public newReqForm()
        {
            InitializeComponent();
            idTextbox.EnableContextMenu();
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("تقاضا جدید مددجو");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                // ExtensionFunction.PersianToEnglish(idTextbox.Text);
            }
        }

        private void searchApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("تقاضا جدید متقاضی");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                // ExtensionFunction.PersianToEnglish(idTextbox.Text);
            }
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdmember = new SqlCommand("select count(*) from member where id = @id and id = supporter_id;", con);
            cmdmember.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
            int c = 0;
            using(SqlDataReader reader = cmdmember.ExecuteReader())
            {
                if (reader.Read())
                {
                    c = reader.GetInt32(0);
                }
            }
            if (c != 0)
            {
                var newform = new newReqForm2(ExtensionFunction.PersianToEnglish(idTextbox.Text), "member");
                newform.ShowDialog(this);
            }
            else
            {
                SqlCommand cmdapplicant = new SqlCommand("select count(*) from otherApplicant where id = @id;", con);
                cmdapplicant.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                c = 0;
                using (SqlDataReader reader = cmdapplicant.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    var newform = new newReqForm2(ExtensionFunction.PersianToEnglish(idTextbox.Text), "applicant");
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("شماره ملی عضو موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
            con.Close();
        }

    }
}
