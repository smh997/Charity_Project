using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using Microsoft.Office.Interop;

namespace WindowsFormsApp6
{
    public partial class deleteMemberForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        public deleteMemberForm()
        {
            InitializeComponent();
        }

        private void deleteMemeberButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True");
            con1.Open();
            SqlCommand cmdgetinfo = new SqlCommand("select folder_id as fol from member where id = @id", con1);
            cmdgetinfo.Parameters.AddWithValue("@id", deleteMemberTextbox.Text);
            string fol = "";
            using (SqlDataReader reader = cmdgetinfo.ExecuteReader())
            {
                if (reader.Read())
                {
                    fol = String.Format("{0}", reader["fol"]);
                }
            }
            SqlCommand cmd = new SqlCommand("delete from member where id = @id", con1);
            cmd.Parameters.AddWithValue("@id", deleteMemberTextbox.Text);
            cmd.ExecuteNonQuery();
            string tpath = this.defaultPath + "\\" + fol + "\\" + deleteMemberTextbox.Text;
            System.IO.Directory.Delete(tpath);
            MessageBox.Show("عضو با موفقیت حذف شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            SqlCommand cmd2 = new SqlCommand("select * from member", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            con1.Close();
        }


        private void deleteMemberForm_Load(object sender, EventArgs e)
        {
            deleteMemeberButton.Enabled = false;
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True");
            con1.Open();
            SqlCommand cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', folderdate as 'تاریخ تشکیل پرونده', checkdate as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
            membersView.Columns[6].DefaultCellStyle.Format = "yyyy/MM/dd";
            membersView.Columns[7].DefaultCellStyle.Format = "yyyy/MM/dd";
            //ExportDataFromSQLServer((System.Data.DataTable)membersView.DataSource);
            /*
            bool[] arr= new bool[dt.Columns.Count];
            for(int i=0; i < dt.Columns.Count; i++)
            {
                if (i == 5 || i == 6 || i == 7)
                    arr[i] = true;
                else
                    arr[i] = false;
            }
            ExportDataFromSQLServer(dt, arr);
            */
            con1.Close();
        }

        protected void ExportDataFromSQLServer(System.Data.DataTable dt, bool[] arr)
        {
            DataTable dataTable = dt;
            int leng = arr.Length;
            using (SqlConnection con = new SqlConnection(this.connection))
            {
                con.Open();

                var excelApplication = new Microsoft.Office.Interop.Excel.Application();

                var excelWorkBook = excelApplication.Application.Workbooks.Add(Type.Missing);

                DataColumnCollection dataColumnCollection = dataTable.Columns;
                
                for (int i = 1; i <= dataTable.Rows.Count + 1; i++)
                {
                    for (int j = 1; j <= dataTable.Columns.Count; j++)
                    {
                        if (i == 1)
                            excelApplication.Cells[i, j] = dataColumnCollection[j - 1].ToString();
                        else
                        {
                            if (arr[j - 1])
                            {
                                string s = dataTable.Rows[i - 2][j - 1].ToString();
                                excelApplication.Cells[i, j] = s.Substring(6, 4)+"/"+s.Substring(3,2)+"/"+ s.Substring(0, 2);
                                //MessageBox.Show(s.Substring(6, 4) + "/" + s.Substring(3, 2) + "/" + s.Substring(0, 2));
                            }
                            else
                                excelApplication.Cells[i, j] = dataTable.Rows[i - 2][j - 1].ToString();
                            
                        }
                            
                    }
                }
                //MessageBox.Show(dataTable.Rows[0][5].ToString());
                Microsoft.Office.Interop.Excel._Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApplication.ActiveSheet;
                workSheet.DisplayRightToLeft = true;
                
                // Save the excel file at specified location
                excelApplication.ActiveWorkbook.SaveCopyAs(@"C:\Users\hashemi\Desktop\test2.xlsx");

                excelApplication.ActiveWorkbook.Saved = true;

                // Close the Excel Application
                excelApplication.Quit();

                con.Close();

                //Release or clear the COM object
                releaseObject(excelWorkBook);
                releaseObject(excelApplication);

                MessageBox.Show("Your data is exported Successfully into Excel File.");
            }
            //return dataTable;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void deleteMemberTextbox_TextChanged(object sender, EventArgs e)
        {
            deleteMemeberButton.Enabled = !string.IsNullOrEmpty(deleteMemberTextbox.Text);
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            MessageBox.Show(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }
    }
}
