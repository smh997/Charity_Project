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
    public partial class observereqForm3_2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id;
        public observereqForm3_2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void observereqForm3_2_Load(object sender, EventArgs e)
        {
            exportButton2.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', dbo.MiladiTOShamsi(deliveryDate) as 'تاریخ ارائه معرفی‌نامه', result as 'نتیجه بررسی', description as 'توضیحات تقاضا', description2 as 'توضیحات بررسی', description3 as 'توضیحات ارائه معرفی‌نامه' from request where applicantId = sup and deliveryDate is not Null and id = @id;", con);
            cmd2.Parameters.AddWithValue("@id", this.id);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            con.Close();
        }
        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
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
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < membersView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = membersView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < membersView.Rows.Count; i++)
            {
                for (int j = 0; j < membersView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = membersView.Rows[i].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }
        private void exportButton2_Click(object sender, EventArgs e)
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
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < membersView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = membersView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < membersView.Columns.Count; j++)
            {
                if (membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select docpath from doc where researchId = @id and doctype = 'facilities:doc';", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            string p = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    p = reader.GetString(0);
                }
            }
            con.Close();
            System.Diagnostics.Process.Start(p);
        }

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            exportButton2.Enabled = (membersView.SelectedCells.Count != 0);
        }

        private void introButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select docpath from doc where researchId = @id and doctype = 'facilities:intro';", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            string p = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    p = reader.GetString(0);
                }
            }
            con.Close();
            System.Diagnostics.Process.Start(p);
        }
    }
}
