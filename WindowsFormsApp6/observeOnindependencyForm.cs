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
    public partial class observeOnindependencyForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public observeOnindependencyForm()
        {
            InitializeComponent();
        }

        private void observeOnindependencyForm_Load(object sender, EventArgs e)
        {
            chooseButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select member.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate)as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member, onindependency where onindependency.id = member.id;", con1);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            con1.Close();
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

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            exportButton2.Enabled = chooseButton.Enabled = (membersView.SelectedCells.Count != 0);
        }
        private void chooseButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMembersForm2(ExtensionFunction.PersianToEnglish(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString()));
            newform.ShowDialog(this);
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
    }
}
