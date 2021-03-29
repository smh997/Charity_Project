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
    public partial class observeOtherHelpsGlobalForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public observeOtherHelpsGlobalForm()
        {
            InitializeComponent();
        }

        private void observeOtherHelpsGlobalForm_Load(object sender, EventArgs e)
        {
            chooseButton.Enabled = exportButton2.Enabled = false;
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList; 
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            SqlCommand cmdget = new SqlCommand("select name from bankAccount;", con);
            bankAccountNameComboBox.Items.Add("همه"); bankAccountNameComboBox.SelectedIndex = 0;
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    bankAccountNameComboBox.Items.Add(reader.GetString(0));
                }
            }
            cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(enddate) as 'تاریخ پایان', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', metric as 'مبلغ معیار امتیاز', status as 'وضعیت', bankAccountName as 'نام حساب', bankAccountId as 'شماره حساب', enactmentId as 'شماره مصوبه تعریف', fenactmentId as 'شماره مصوبه تایید', description as 'توضیحات' from OtherHelpsGlobal;", con);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            con.Close();
        }
        private void startDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (startDateTimePickerX.SelectedDateInDateTime.Date > endDateTimePickerX.SelectedDateInDateTime.Date)
            {
                startDateTimePickerX.SelectedDateInDateTime = endDateTimePickerX.SelectedDateInDateTime.Date;
            }
        }

        private void endDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (startDateTimePickerX.SelectedDateInDateTime.Date > endDateTimePickerX.SelectedDateInDateTime.Date)
            {
                endDateTimePickerX.SelectedDateInDateTime = startDateTimePickerX.SelectedDateInDateTime.Date;
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            string ss = "", ss2 = "", ss3 = "", sss = "";
            foreach (CheckBox ch in typeGroupBox.Controls)
            {
                if (ch.Checked)
                {
                    if (ss != "")
                    {
                        ss += " or ";
                    }
                    else
                    {
                        ss += "(";
                    }
                    ss += "ctype = " + "N'" + ch.Text + "'";
                }
            }
            if (ss != "")
            {
                ss += ")";
            }
            foreach (CheckBox ch in cashGroupBox.Controls)
            {
                if (ch.Checked)
                {
                    if (ss2 != "")
                    {
                        ss2 += " or ";
                    }
                    else
                    {
                        ss2 += "(";
                    }
                    ss2 += "cashtype = " + "N'" + ch.Text + "'";
                }
            }
            if (ss2 != "")
            {
                ss2 += ")";
            }
            foreach (CheckBox ch in statusGroupBox.Controls)
            {
                if (ch.Checked)
                {
                    if (ss3 != "")
                    {
                        ss3 += " or ";
                    }
                    else
                    {
                        ss3 += "(";
                    }
                    ss3 += "status = " + "N'" + ch.Text + "'";
                }
            }
            if (ss3 != "")
            {
                ss3 += ")";
            }
            sss += ss;
            if (sss != "")
            {
                sss += " and ";
            }
            sss += ss2;
            if (sss != "")
            {
                sss += " and ";
            }
            sss += ss3;
            if (sss != "")
            {
                sss += " and ";
            }
            sss += "startdate <= '" + endDateTimePickerX.SelectedDateInStringEnglish + "'";
            sss += " and ";
            sss += "startdate >= '" + startDateTimePickerX.SelectedDateInStringEnglish + "'";
            if(bankAccountNameComboBox.SelectedIndex != 0)
            {
                sss += " and ";
                sss += "bankAccountName = N'" + bankAccountNameComboBox.Text + "'";
            }
            cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(enddate) as 'تاریخ پایان', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', metric as 'مبلغ معیار امتیاز', status as 'وضعیت', bankAccountName as 'نام حساب', bankAccountId as 'شماره حساب', enactmentId as 'شماره مصوبه تعریف', fenactmentId as 'شماره مصوبه تایید', description as 'توضیحات' from OtherHelpsGlobal where " + sss + ";", con1);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
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
            var newform = new observeOtherHelpsGlobalForm2(ExtensionFunction.PersianToEnglish(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString()));
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
        private void cashTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bankAccountNameComboBox.Enabled = cashTypeCheckBox.Checked;
            if (!bankAccountNameComboBox.Enabled)
            {
                bankAccountNameComboBox.SelectedIndex = 0;
            }
            searchButton.Enabled = false;
            foreach (CheckBox ch in cashGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
            searchButton.Enabled = false;
            foreach (CheckBox ch in statusGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
            searchButton.Enabled = false;
            foreach (CheckBox ch in typeGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
        }
        private void orphanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = false;
            foreach (CheckBox ch in typeGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
            searchButton.Enabled = false;
            foreach (CheckBox ch in statusGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
            searchButton.Enabled = false;
            foreach (CheckBox ch in cashGroupBox.Controls)
            {
                searchButton.Enabled |= ch.Checked;
            }
        }
    }
}
