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
    public partial class observeBudgetsetsForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        Dictionary<string, Tuple<int, string, string>> di;
        string id;
        public observeBudgetsetsForm2(string id)
        {
            InitializeComponent();
            di = new Dictionary<string, Tuple<int, string, string>>();
            this.id = id;
        }

        private void observeBudgetsetsForm2_Load(object sender, EventArgs e)
        {
            chooseButton.Enabled = exportButton2.Enabled = exportButton4.Enabled = false;
            di["culture"] = new Tuple<int, string, string>(0, "", ""); membersView2.Rows.Add("فرهنگی/اداری");
            di["marry"] = new Tuple<int, string, string>(1, "", ""); membersView2.Rows.Add("ازدواج");
            di["edu"] = new Tuple<int, string, string>(2, "", ""); membersView2.Rows.Add("آموزشی");
            di["heal"] = new Tuple<int, string, string>(3, "", ""); membersView2.Rows.Add("درمانی");
            di["healFamily"] = new Tuple<int, string, string>(4, "", ""); membersView2.Rows.Add("درمانی خانوار");
            di["bread"] = new Tuple<int, string, string>(5, "", ""); membersView2.Rows.Add("نان");
            di["breadFamily"] = new Tuple<int, string, string>(6, "", ""); membersView2.Rows.Add("نان خانوار(ماهانه)");
            di["grocery"] = new Tuple<int, string, string>(7, "", ""); membersView2.Rows.Add("مرغ/گوشت/خواربار");
            di["others"] = new Tuple<int, string, string>(8, "", ""); membersView2.Rows.Add("متفرقه");
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmdgetbsid = new SqlCommand("select max(id) from budgetsets;", con1);
            string bsid = "1398";
            using (SqlDataReader reader = cmdgetbsid.ExecuteReader())
            {
                if (reader.Read())
                {
                    bsid = reader.GetString(0);
                }
            }
            SqlCommand cmd2;
            if (this.id == bsid)
            {
                cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrencies where typename != 'bankScore' and typename like '%Budget';", con1);
            }
            else
            {
                cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrenciesHistory where bsid = @id and typename != 'bankScore' and typename like '%Budget';", con1);
            }
            string tmp;
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    tmp = reader.GetString(0).Substring(0, reader.GetString(0).Length - 6);
                    di[tmp] = new Tuple<int, string, string>(di[tmp].Item1, reader.GetDecimal(1).ToString(), di[tmp].Item3);
                }
            }
            if (this.id == bsid)
            {
                cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrencies where typename != 'bankScore' and typename like '%Consume';", con1);
            }
            else
            {
                cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrenciesHistory where bsid = @id and typename != 'bankScore' and typename like '%Consume';", con1);
            }
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    tmp = reader.GetString(0).Substring(0, reader.GetString(0).Length - 7);
                    di[tmp] = new Tuple<int, string, string>(di[tmp].Item1, di[tmp].Item2, reader.GetDecimal(1).ToString());
                }
            }
            foreach (Tuple<int, string, string> tu in di.Values)
            {
                membersView2.Rows[tu.Item1].Cells[1].Value = tu.Item2;
                membersView2.Rows[tu.Item1].Cells[2].Value = tu.Item3;
            }
            membersView2.Columns[membersView2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select id as 'شناسه', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', enactmentId as 'شماره مصوبه', description as 'توضیحات' from budgetedits;", con1);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;

            con1.Close();
        }
        private void membersView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView.ClearSelection();
        }
        private void membersView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView2.ClearSelection();
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

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            chooseButton.Enabled = exportButton2.Enabled = (membersView.SelectedCells.Count != 0);
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
        }
        private void membersView2_SelectionChanged(object sender, EventArgs e)
        {
            exportButton4.Enabled = (membersView2.SelectedCells.Count != 0);
        }

        private void membersView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView2.ClearSelection();
            }
        }
        private void exportButton4_Click(object sender, EventArgs e)
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
            for (int i = 1; i < membersView2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = membersView2.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < membersView2.Columns.Count; j++)
            {
                if (membersView2.Rows[membersView2.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(membersView2.Rows[membersView2.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = membersView2.Rows[membersView2.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void exportButton3_Click(object sender, EventArgs e)
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
            for (int i = 1; i < membersView2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = membersView2.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < membersView2.Rows.Count; i++)
            {
                for (int j = 0; j < membersView2.Columns.Count; j++)
                {
                    if (membersView2.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(membersView2.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = membersView2.Rows[i].Cells[j].Value.ToString();
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

        private void chooseButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select docpath from enactment where id = @id;", con);
            cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex + 2].Value.ToString()));
            string p = "";
            using(SqlDataReader reader = cmd.ExecuteReader())
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
