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
    public partial class editMarriageForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public editMarriageForm()
        {
            InitializeComponent();
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void editMarriageTextbox_TextChanged(object sender, EventArgs e)
        {
            editMarriageButton.Enabled = !string.IsNullOrEmpty(editMarriageTextbox.Text) && !string.IsNullOrWhiteSpace(editMarriageTextbox.Text);
        }

        private void editMarriageForm_Load(object sender, EventArgs e)
        {
            editMarriageButton.Enabled = false;
            editMarriageTextbox.Text = "";
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2 = new SqlCommand("select married.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', marrieddate as 'تاریخ ازدواج', married.description as 'توضیحات ازدواج', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from married, abandoned where married.id = abandoned.id;", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
            membersView.Columns[7].DefaultCellStyle.Format = "yyyy/MM/dd";
            con1.Close();
        }

        private void editMarriageTextbox_DoubleClick(object sender, EventArgs e)
        {
            editMarriageTextbox.Text = Clipboard.GetText();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm(this.Name);
            newform.ShowDialog(this);
        }


        private void editMarriageButton_Click_1(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(editMarriageTextbox.Text, out res) && !editMarriageTextbox.Text.Any(char.IsWhiteSpace))
            {
                string id;
                bool correct = true;
                foreach (char c in editMarriageTextbox.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("باید یک عدد وارد کنید", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        correct = false;
                        break;
                    }
                }
                if (correct)
                {
                    id = editMarriageTextbox.Text;
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    SqlCommand cmdcheck = new SqlCommand("select count(*) as existance from married where id = @id", con);
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
                        var newform = new editMarriageForm2(id);
                        newform.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("عضوی با این شماره ملی وجود ندارد", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }
            else
            {
                MessageBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

        }
    }
}
