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

namespace WindowsFormsApp6
{
    public partial class comebackForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        
        public comebackForm(string p)
        {
            InitializeComponent();
            this.Text = p;
            comebackTextbox.EnableContextMenu();
            comebackTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void comebackForm_Load(object sender, EventArgs e)
        {
            comebackButton.Enabled = false;
            comebackTextbox.Text = "";
            if (this.Text == "ویرایش رجعت عضو")
            {
                this.BackColor = Color.Yellow;
            }
        }

        private void comebackTextbox_TextChanged(object sender, EventArgs e)
        {
            comebackButton.Enabled = !string.IsNullOrEmpty(comebackTextbox.Text) && !string.IsNullOrWhiteSpace(comebackTextbox.Text);
        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            var newform = new searchForm(this.Text);
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                comebackTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void comebackButton_Click(object sender, EventArgs e)
        {
            string id;
            id = ExtensionFunction.PersianToEnglish(comebackTextbox.Text);
            SqlCommand cmdcheck;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text == "رجعت عضو")
            {
                cmdcheck = new SqlCommand("select count(*) as existance from abandoned where id = @id", con);
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
                    var newform = new comebackForm2(id);
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("!عضوی با این شماره ملی در لیست اعضای معلق وجود ندارد", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
            else
            {
                cmdcheck = new SqlCommand("select count(*) as existance from member, Inmember where member.id = Inmember.id and Inmember.kickdate is Null and member.id = @id", con);
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
                    var newform = new comebackForm2(id);
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("!عضوی با این شماره ملی در لیست اعضای رجعت یافته وجود ندارد", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
        }

        private void comebackTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && comebackButton.Enabled)
            {
                comebackButton.PerformClick();
            }
        }
    }
}
