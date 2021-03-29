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
    public partial class parameterVisitFamiliesForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        Dictionary<string, decimal> di;
        public parameterVisitFamiliesForm()
        {
            InitializeComponent();
            di = new Dictionary<string, decimal>();
        }

        private void parameterVisitFamiliesForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select rate as امتیاز, id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', address as آدرس, explain as توضیحات from member where id = supporter_id order by rate desc;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[memberDataGridView.ColumnCount-2].DefaultCellStyle.WrapMode = memberDataGridView.Columns[memberDataGridView.ColumnCount-1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            memberDataGridView.Columns[0].DefaultCellStyle.Format = "#,##;#,##-";

            SqlCommand cmdgetfamilies = new SqlCommand("select folder_id, rate from member where id = supporter_id;", con);
            using (SqlDataReader reader = cmdgetfamilies.ExecuteReader())
            {
                while (reader.Read())
                {
                    di[reader.GetString(0)] = reader.GetInt32(1);
                }
            }
            if (di.Count == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("خانواری وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
            SqlCommand cmdget = new SqlCommand("select distinct gId, folder_id, GlobalHelps.packets, receivedTableHelp.packets, fee from GlobalHelps,receivedTableHelp where (GlobalHelps.status = N'تایید شده' or GlobalHelps.status = N'نهایی') and id = gId and DATEADD(day,@days, enddate) >= @now;", con);
            SqlCommand cmdgetparam = new SqlCommand("select point from parameters where name = 'day';", con);
            using (SqlDataReader reader = cmdgetparam.ExecuteReader())
            {
                if (reader.Read())
                {
                    cmdget.Parameters.AddWithValue("@days", reader.GetInt32(0));
                }
            }
            cmdgetparam = new SqlCommand("select point from parameters where name = 'help';", con);
            decimal metric = 0;
            using (SqlDataReader reader = cmdgetparam.ExecuteReader())
            {
                if (reader.Read())
                {
                    metric = reader.GetInt32(0);
                }
            }
            cmdget.Parameters.AddWithValue("@now", DateTime.Now.Date);
            int p = 0; decimal f = 0;
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (di.ContainsKey(reader.GetString(1)))
                    {
                        decimal a = di[reader.GetString(1)] - (reader.GetDecimal(4) * reader.GetInt32(3) / reader.GetInt32(2)) / metric;
                        di[reader.GetString(1)] = Math.Max(a, 0);
                    }
                }
            }
            foreach(var dd in di)
            {
                cmd = new SqlCommand("insert into ShowFamiliesList(fId, rate) Values (@fId, @rate);", con);
                cmd.Parameters.AddWithValue("@fId", dd.Key);
                cmd.Parameters.AddWithValue("@rate", dd.Value);
                cmd.ExecuteNonQuery();
            }
            cmd = new SqlCommand("select ShowFamiliesList.rate as امتیاز, id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', address as آدرس, explain as توضیحات from member, ShowFamiliesList where id = supporter_id and member.folder_id = ShowFamiliesList.fId order by ShowFamiliesList.rate desc;", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView2.DataSource = dt;
            memberDataGridView2.Columns[memberDataGridView2.ColumnCount-2].DefaultCellStyle.WrapMode = memberDataGridView2.Columns[memberDataGridView2.ColumnCount-1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            memberDataGridView2.Columns[0].DefaultCellStyle.Format = "#,##;#,##-";
            con.Close();
        }

        private void parameterVisitFamiliesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from ShowFamiliesList;", con);
            cmd.ExecuteNonQuery();
            con.Close();
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
            for (int i = 1; i < memberDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < memberDataGridView.Columns.Count; j++)
            {
                if (memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
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
            for (int i = 1; i < memberDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < memberDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < memberDataGridView.Columns.Count; j++)
                {
                    if (memberDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(memberDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = memberDataGridView.Rows[i].Cells[j].Value.ToString();
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

        private void byhelpexportButton2_Click(object sender, EventArgs e)
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
            for (int i = 1; i < memberDataGridView2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView2.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < memberDataGridView2.Columns.Count; j++)
            {
                if (memberDataGridView2.Rows[memberDataGridView2.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(memberDataGridView2.Rows[memberDataGridView2.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = memberDataGridView2.Rows[memberDataGridView2.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void byhelpexportButton_Click(object sender, EventArgs e)
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
            for (int i = 1; i < memberDataGridView2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView2.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < memberDataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < memberDataGridView2.Columns.Count; j++)
                {
                    if (memberDataGridView2.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(memberDataGridView2.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = memberDataGridView2.Rows[i].Cells[j].Value.ToString();
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
    }
}
