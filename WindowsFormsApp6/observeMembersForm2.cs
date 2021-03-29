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
    public partial class observeMembersForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string profile = "", id;

        public observeMembersForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void observeMemberForm2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate)as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where id = @id", con);
            cmd2.Parameters.AddWithValue("@id", this.id);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            SqlCommand cmdgetprofile = new SqlCommand("select docpath from doc where id = @id and doctype = 'profile';", con);
            cmdgetprofile.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetprofile.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.profile = String.Format("{0}", reader["docpath"]);
                }
            }
            if (this.profile == "")
                profilePictureBox.Image = WindowsFormsApp6.Properties.Resources.profile;
            else
                profilePictureBox.ImageLocation = this.profile;
            con.Close();
        }
        private void membersView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView.ClearSelection();
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            
            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < membersView.Columns.Count+1; i++)
            {
                worksheet.Cells[1, i] = membersView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < membersView.Rows.Count; i++)
            {
                for (int j = 0; j < membersView.Columns.Count; j++)
                {
                    if (membersView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(membersView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = membersView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }
        private void authButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("شناسایی", "auth", this.id);
            newform.ShowDialog(this);
        }
        private void marryButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("ازدواج", "marry", this.id);
            newform.ShowDialog(this);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("مسکن", "house", this.id);
            newform.ShowDialog(this);
        }

        private void otherButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("متفرقه", "other", this.id);
            newform.ShowDialog(this);
        }

        private void orphanButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("تیمی", "orphan", this.id);
            newform.ShowDialog(this);
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("دانش‌آموزی", "study", this.id);
            newform.ShowDialog(this);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select enactmentId from member where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            SqlCommand cmd = new SqlCommand("select docpath from enactment where id = @id;", con);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if(reader.Read())
                    cmd.Parameters.AddWithValue("@id", reader.GetString(0));
            }
            string dpath = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                    dpath = reader.GetString(0);
            }
            con.Close();
            System.Diagnostics.Process.Start(System.IO.Directory.GetFiles(dpath)[0]);
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
        }

        private void healthButton_Click(object sender, EventArgs e)
        {
            var newform = new observeDocForm("سلامت", "health", this.id);
            newform.ShowDialog(this);
        }
    }
}
