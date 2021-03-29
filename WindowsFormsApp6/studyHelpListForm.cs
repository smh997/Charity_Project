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
    public partial class studyHelpListForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, type, pp;
        int packs;
        bool res = false;
        public studyHelpListForm(string id, string type, string p = "")
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
            this.pp = p;
        }

        private void studyHelpListForm_Load(object sender, EventArgs e)
        {
            addButton.Enabled = delButton.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select number from StudyHelps where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.packs = reader.GetInt32(0);
                }
            }
            SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyTmpList where hId = @hId;", con);
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyDelList where hId = @hId;", con);
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            con.Close();
        }
        private void globalHelpListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.res)
                this.Text = "fail";
        }
        private void memberDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            delButton.Enabled = (memberDataGridView.SelectedCells.Count != 0);
        }

        private void memberDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            memberDataGridView.ClearSelection();
        }

        private void globalHelpListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.pp == "ویرایش" && !this.res)
            {
                FMessegeBox.FarsiMessegeBox.Show("باید لیست مورد نظر را تایید و ویرایش را کامل کنید.", "هشدار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
        }

        private void memberDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                memberDataGridView.ClearSelection();
            }
        }
        private void delDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                delDataGridView.ClearSelection();
            }
        }

        private void delDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            addButton.Enabled = (delDataGridView.SelectedCells.Count != 0);
        }

        private void delDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            delDataGridView.ClearSelection();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdtransfer;
            string folde;
            for (int j = 0; j < memberDataGridView.SelectedCells.Count; j++)
            {
                folde = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                cmdtransfer = new SqlCommand("begin tran t1; insert into StudyDelList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyTmpList where stuId = @id and hId = @hId; delete from StudyTmpList where stuId = @id and hId = @hId; commit tran t2;", con);
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.Parameters.AddWithValue("@id", folde);
                cmdtransfer.ExecuteNonQuery();
            }
            
            SqlDataAdapter da; DataTable dt;
            SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyTmpList where hId = @hId;", con);
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyDelList where hId = @hId;", con);
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            con.Close();
        }

        private void listButton_Click(object sender, EventArgs e)
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
            worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            for (int i = 1; i < memberDataGridView.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < memberDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < memberDataGridView.Columns.Count - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = memberDataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(this.type == "لوازم التحریر")
            {
                if(memberDataGridView.RowCount + delDataGridView.SelectedCells.Count > this.packs)
                {
                    FMessegeBox.FarsiMessegeBox.Show("مجموع تعداد افراد انتخاب شده از تعداد بسته‌های تعریف شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdtransfer;
            string folde;
            for (int j = 0; j < delDataGridView.SelectedCells.Count; j++)
            {
                folde = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                cmdtransfer = new SqlCommand("begin tran t1; insert into StudyTmpList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyDelList where stuId = @id and hId = @hId; delete from StudyDelList where stuId = @id and hId = @hId; commit tran t2;", con);
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.Parameters.AddWithValue("@id", folde);
                cmdtransfer.ExecuteNonQuery();
            }
            SqlDataAdapter da; DataTable dt;
            SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyTmpList where hId = @hId;", con);
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyDelList where hId = @hId;", con);
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            con.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (memberDataGridView.Rows.Count == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("لیست نمی‌تواند خالی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (this.type == "لوازم التحریر" && memberDataGridView.Rows.Count > this.packs)
            {
                FMessegeBox.FarsiMessegeBox.Show("تعداد افراد انتخابی از تعداد بسته‌های تعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd;
            if (this.pp == "ویرایش")
            {
                cmd = new SqlCommand("begin tran t1; delete from StudyfinList where hId = @hId; insert into StudyfinList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyTmpList where hId = @hId; update StudyHelps Set number = @num where id = @hId; commit tran t1;", con);
            }
            else
            {
                cmd = new SqlCommand("begin tran t1; insert into StudyfinList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyTmpList where hId = @hId; update StudyHelps Set number = @num where id = @hId; commit tran t1;", con);
            }
            cmd.Parameters.AddWithValue("@num", memberDataGridView.RowCount);
            cmd.Parameters.AddWithValue("@hId", this.id);
            cmd.ExecuteNonQuery();
            con.Close();
            this.res = true;
            if(this.pp == "ویرایش")
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            this.Close();
        }
    }
}
