﻿using System;
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
    public partial class observerecLetterForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public observerecLetterForm()
        {
            InitializeComponent();
        }

        private void observerecLetterForm_Load(object sender, EventArgs e)
        {
            exportButton2.Enabled = chooseButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select id as 'شماره یکتا', id_i as 'شماره نامه', title as 'عنوان', sender as 'فرستنده', signer as 'امضاکننده', attachment as 'پیوست', dbo.MiladiTOShamsi(recdate) as 'تاریخ دریافت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت' from receivedLetters;", con1);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[2].DefaultCellStyle.WrapMode = membersView.Columns[3].DefaultCellStyle.WrapMode = membersView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            con1.Close();
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
        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            cmd = new SqlCommand("select id as 'شماره یکتا', id_i as 'شماره نامه', title as 'عنوان', sender as 'فرستنده', signer as 'امضاکننده', attachment as 'پیوست', dbo.MiladiTOShamsi(recdate) as 'تاریخ دریافت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت' from receivedLetters where recdate >= '" + startDateTimePickerX.SelectedDateInStringEnglish + "' and recdate <= '" + endDateTimePickerX.SelectedDateInStringEnglish + "';", con1);
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
            var newform = new observerecLetterForm2(ExtensionFunction.PersianToEnglish(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString()));
            newform.ShowDialog(this);
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
    }
}
