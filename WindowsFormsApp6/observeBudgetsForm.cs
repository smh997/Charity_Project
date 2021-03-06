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
    public partial class observeBudgetsForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        Dictionary<string, Tuple<int, string, string>> di;
        public observeBudgetsForm()
        {
            InitializeComponent();
            di = new Dictionary<string, Tuple<int, string, string>>();
        }

        private void observeBudgetsForm_Load(object sender, EventArgs e)
        {
            exportButton2.Enabled = false;
            di["culture"] = new Tuple<int, string, string>(0, "", ""); membersView.Rows.Add("فرهنگی/اداری");
            di["marry"] = new Tuple<int, string, string>(1, "", ""); membersView.Rows.Add("ازدواج");
            di["edu"] = new Tuple<int, string, string>(2, "", ""); membersView.Rows.Add("آموزشی");
            di["heal"] = new Tuple<int, string, string>(3, "", ""); membersView.Rows.Add("درمانی");
            di["healFamily"] = new Tuple<int, string, string>(4, "", ""); membersView.Rows.Add("درمانی خانوار");
            di["bread"] = new Tuple<int, string, string>(5, "", ""); membersView.Rows.Add("نان");
            di["breadFamily"] = new Tuple<int, string, string>(6, "", ""); membersView.Rows.Add("نان خانوار(ماهانه)");
            di["grocery"] = new Tuple<int, string, string>(7, "", ""); membersView.Rows.Add("مرغ/گوشت/خواربار");
            di["others"] = new Tuple<int, string, string>(8, "", ""); membersView.Rows.Add("متفرقه");
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2;
            cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrencies where typename != 'bankScore' and typename like '%Budget';", con1);
            string tmp;
            using(SqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    tmp = reader.GetString(0).Substring(0, reader.GetString(0).Length - 6);
                    di[tmp] = new Tuple<int, string, string>(di[tmp].Item1, reader.GetDecimal(1).ToString(),di[tmp].Item3);
                }
            }
            cmd2 = new SqlCommand("select typename as نام, amount as 'مبلغ ریالی' from budgetsCurrencies where typename != 'bankScore' and typename like '%Consume';", con1);
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
                membersView.Rows[tu.Item1].Cells[1].Value = tu.Item2;
                membersView.Rows[tu.Item1].Cells[2].Value = tu.Item3;
            }
            membersView.Columns[membersView.ColumnCount-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            con1.Close();
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
            for (int i = 1; i < membersView.Columns.Count+1; i++)
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
            exportButton2.Enabled = (membersView.SelectedCells.Count != 0);
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
        }
    }
}
