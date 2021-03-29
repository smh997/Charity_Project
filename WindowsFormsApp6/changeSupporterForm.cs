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
    public partial class changeSupporterForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id;
        public changeSupporterForm(string p, string id)
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void changeSupporterForm_Load(object sender, EventArgs e)
        {
            setButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            
            cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate)as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where supporter_id = @sup and id != @sup", con1);
            cmd2.Parameters.AddWithValue("@sup", this.id);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
            
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(idTextbox.Text, out res) && !idTextbox.Text.Any(char.IsWhiteSpace))
            {

                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from member where id = @tmp and supporter_id = @sup and id != @sup", con);
                cmdcheck.Parameters.AddWithValue("@tmp", idTextbox.Text);
                cmdcheck.Parameters.AddWithValue("@sup", this.id);
                int sup = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        sup = int.Parse(String.Format("{0}", reader["sup"]));
                    }
                }
                if (sup == 0)
                {
                    MessageBox.Show("شماره ملی عضو در لیست اعضای این خانوار موجود نیست یا فرد سرپرست فعلی است!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    List<string> li = new List<string>();
                    string[] arr;
                    SqlCommand cmdchild = new SqlCommand("select id from member where supporter_id = @sup and id != @sup", con);
                    cmdchild.Parameters.AddWithValue("@sup", this.id);
                    using (SqlDataReader reader = cmdchild.ExecuteReader())
                    {
                        while (reader.Read())
                            li.Add(reader.GetString(0));
                        arr = li.ToArray();
                    }
                    SqlCommand cmdgetc, cmd;
                    foreach (var i in arr)
                    {
                        cmdgetc = new SqlCommand("select explain from member where id = @tmp", con);
                        cmdgetc.Parameters.AddWithValue("@tmp", i);
                        string explain = "";
                        using (SqlDataReader reader = cmdgetc.ExecuteReader())
                        {
                            explain = String.Format("{0}", reader["explain"]);
                        }
                        cmd = new SqlCommand("update member Set supporter_id = @tmp, explain = @explain where id = @i", con);
                        cmd.Parameters.AddWithValue("@tmp", idTextbox.Text);
                        cmd.Parameters.AddWithValue("@i", i);
                        cmd.Parameters.AddWithValue("@explain", explain + "(تغییر سرپرست در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + "به " + idTextbox.Text + ")");
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("سرپرست با موفقیت تغییر یافت!", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    con.Close();
                    this.Close();
                    
                }
            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void idTextbox_DoubleClick(object sender, EventArgs e)
        {
            idTextbox.Text = Clipboard.GetText();
        }
    }
}
