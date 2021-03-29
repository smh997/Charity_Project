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
    public partial class observeDocForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string form, type, id;
        DateTime sdate;
        public observeDocForm(string form, string type, string id, string sdate = "")
        {
            InitializeComponent();
            this.form = form;
            if(this.form == "پیوست‌ها")
            {
                this.Text += " " + form;
            }
            else
            {
                this.Text += " مدارک " + form;
            }
            this.id = id;
            this.type = type;
            if(sdate != "")
            {
                this.sdate = Convert.ToDateTime(sdate).Date;
            }
        }
        
        private void docdataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 2)
            {
                docdataGridViewX.ClearSelection();
            }
        }
        private void docdataGridViewX_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            docdataGridViewX.ClearSelection();
        }

        private void visitButton_Click(object sender, EventArgs e)
        {
            string dpath = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex + 2].Value.ToString();
            System.Diagnostics.Process.Start(dpath);
        }
        private void docdataGridViewX_SelectionChanged(object sender, EventArgs e)
        {
            visitButton.Enabled = (docdataGridViewX.SelectedCells.Count != 0);
        }
        private void observeDocForm_Load(object sender, EventArgs e)
        {
            visitButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            /*if (deltype == "ویرایش حذف پوشش خانوار" || this.Text == "ویرایش معرفی‌نامه")
            {
                SqlCommand cmdgetid;
                if (this.Text == "ویرایش معرفی‌نامه")
                {
                    cmdgetid = new SqlCommand("select applicantId from request where id = @sup", con1);
                }
                else
                {
                    cmdgetid = new SqlCommand("select id from abandoned where supporter_id = @sup and id != @sup and abandoneddate = @ddate", con1);
                    cmdgetid.Parameters.AddWithValue("@ddate", this.ddate);
                }
                cmdgetid.Parameters.AddWithValue("@sup", this.id);

                using (SqlDataReader reader = cmdgetid.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        li.Add(reader.GetString(0));
                    }
                    arr = li.ToArray();
                }
            }*/
            /*if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype and subdate = @ddate;", con1);
                cmd.Parameters.AddWithValue("@ddate", this.ddate);
            }
            else if (this.Text == "ویرایش معرفی‌نامه")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where researchId = @id and doctype = @dtype and id = @sup;", con1);
                cmd.Parameters.AddWithValue("@sup", arr[0]);
            }
            else
            {*/
            //    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con1);
            //}

            if (type == "deletion")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype and subdate = @sdate;", con1);
                cmd.Parameters.AddWithValue("@sdate", this.sdate);
            }
            else
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con1);
            }
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@dtype", this.type);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            docdataGridViewX.DataSource = dt;
            docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
            //if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
            //    docdataGridViewX.Columns[2].Visible = false;

            con1.Close();
        }
    }
}
