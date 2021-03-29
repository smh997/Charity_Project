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
    
    public partial class EditMemberForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public EditMemberForm()
        {
            InitializeComponent();
            editMemberTextbox.EnableContextMenu();
            editMemberTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void editMemeberButton_Click(object sender, EventArgs e)
        {
            string id;
            if (!editMemberTextbox.Text.Any(char.IsWhiteSpace) && editMemberTextbox.Text.All(char.IsDigit))
            {
                id = ExtensionFunction.PersianToEnglish(editMemberTextbox.Text);
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as existance from member where id = @id", con);
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
                    var newform = new editMemberForm2(id);
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("عضوی با این شماره ملی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                    
                    
            }
            else
            {
                FMessegeBox.FarsiMessegeBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }

        }

        private void EditMemberForm_Load(object sender, EventArgs e)
        {
            editMemeberButton.Enabled = false;
            editMemberTextbox.Text = "";
        }

        private void editMemberTextbox_TextChanged(object sender, EventArgs e)
        {
            editMemeberButton.Enabled = !string.IsNullOrEmpty(editMemberTextbox.Text) && !string.IsNullOrWhiteSpace(editMemberTextbox.Text);
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm(this.Text);
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                editMemberTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
            }
        }

        private void editMemberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && editMemeberButton.Enabled)
            {
                editMemeberButton.PerformClick();
            }
        }
    }
}
