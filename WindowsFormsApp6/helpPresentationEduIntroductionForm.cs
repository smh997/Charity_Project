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
    public partial class helpPresentationEduIntroductionForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id;
        decimal fee;
        bool res = false;
        public helpPresentationEduIntroductionForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
            if (this.Text == "ویرایش تایید معرفی‌نامه تحصیلی")
            {
                setButton.Enabled = true;
            }
        }

        private void memberDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 2)
            {
                memberDataGridView.ClearSelection();
            }
        }

        private void memberDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(this.Text == "ارائه معرفی‌نامه تحصیلی" || this.Text == "ویرایش فایل‌های معرفی‌نامه تحصیلی")
                setButton.Enabled = memberDataGridView.RowCount != 0;
        }
        private void memberDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            memberDataGridView.ClearSelection();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به حذف فایل مطمئن هستید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (dr != DialogResult.Yes)
                return;
            SqlDataAdapter da; DataTable dt;
            string i = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex - 1].Value.ToString();
            string dpath = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("delete from doc where i = @i", con);
            cmd.Parameters.AddWithValue("@i", i);
            cmd.ExecuteNonQuery();

            System.IO.File.Delete(dpath);
            cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@dtype", "Shelp");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            addOpenFileDialog.Title = "انتخاب فایل ارائه معرفی‌نامه";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                if(!System.IO.Directory.Exists(this.helpPath + "\\" + this.id))
                {
                    System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id);
                }
                foreach (var d in addOpenFileDialog.FileNames)
                {
                    string fileName = System.IO.Path.GetFileName(d);
                    string targetPath;
                    targetPath = this.helpPath + "\\" + this.id + "\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    string dd = DateTime.Now.Date.ToPersian();
                    if (System.IO.File.Exists(destFile))
                    {
                        destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2) + ".pdf");
                    }
                    System.IO.File.Copy(d, destFile, false);
                    cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dtype", "Shelp");
                    cmd.ExecuteNonQuery();
                }    
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@dtype", "Shelp");
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
                con.Close();
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید معرفی‌نامه تحصیلی")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();

                decimal budget = 0, consume = 0, stock = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "eduBudget");
                cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                cmdget3.Parameters.AddWithValue("@id", "stock");
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consume = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else
                {
                    res = true;
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1;update StudyHelps Set fenactmentId = @feId, status = @stat, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                    cmd.Parameters.AddWithValue("@stat", "نهایی");
                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                    cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                    cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@tname2", "eduConsume");
                    cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت تایید و نهایی شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }

            }
            else if (this.Text == "ویرایش تایید معرفی‌نامه تحصیلی")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();

                decimal budget = 0, consume = 0, stock = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "eduBudget");
                cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                cmdget3.Parameters.AddWithValue("@id", "stock");
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consume = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else
                {
                    res = true;
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1;update StudyHelps Set fenactmentId = @feId, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                    cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                    cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@tname2", "eduConsume");
                    cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("تایید کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
            }
            else if(this.Text == "ارائه معرفی‌نامه تحصیلی")
            {
                res = true;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdup = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set status = @stat, enddate = @edate where id = @id; insert into StudyRecList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyFinList where hId = @id; delete from StudyFinList where hId = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdup.Parameters.AddWithValue("@id", this.id);
                cmdup.Parameters.AddWithValue("@stat", "پایان‌یافته");
                cmdup.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                cmdup.ExecuteNonQuery();
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت پایان یافت!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
            else
            {
                res = true;
                FMessegeBox.FarsiMessegeBox.Show("ارائه کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }

        private void memberDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            delButton.Enabled = visitButton.Enabled = (memberDataGridView.SelectedCells.Count != 0);
        }

        private void helpPresentationEduIntroductionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.Text == "ویرایش فایل‌های معرفی‌نامه تحصیلی" && !res)
            {
                FMessegeBox.FarsiMessegeBox.Show("باید از طریق ثبت تغییرات این فرم را ترک کنید.", "هشدار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
            else if (this.Text == "ارائه معرفی‌نامه تحصیلی" && !res)
            {
                DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("با ترک این فرم فایل‌های افزوده شده پاک می‌شوند. آیا نسبت به ترک فرم اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if(dr == DialogResult.Yes)
                {
                    if(System.IO.Directory.Exists(this.helpPath + "\\" + this.id))
                    {
                        SqlConnection con = new SqlConnection(this.connection);
                        con.Open();
                        System.IO.Directory.Delete(this.helpPath + "\\" + this.id, true);
                        SqlCommand cmd = new SqlCommand("delete from doc where id = @id and doctype = @dtype;", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@dtype", "Shelp");
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if(!res)
            {
                DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("با ترک این فرم تغییرات اعمال شده، ذخیره نمی‌شوند. آیا نسبت به ترک فرم اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if(dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void enactmentTextbox2_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "تایید معرفی‌نامه تحصیلی")
                setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void helpPresentationEduIntroductionForm_Activated(object sender, EventArgs e)
        {
            if(memberDataGridView.SelectedCells.Count != 0)
            {
                memberDataGridView.SelectedCells[0].Selected = false;
            }
        }

        private void helpPresentationEduIntroductionForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text == "ارائه معرفی‌نامه تحصیلی")
            {
                visitButton.Enabled = delButton.Enabled = false;
                setButton.Enabled = memberDataGridView.RowCount != 0;
            }
            else if (this.Text == "ویرایش فایل‌های معرفی‌نامه تحصیلی")
            {
                setButton.Enabled = false;
                returnButton.Visible = true;
            }
            else if (this.Text == "تایید معرفی‌نامه تحصیلی" || this.Text == "ویرایش تایید معرفی‌نامه تحصیلی")
            {
                setButton.Enabled = visitButton.Enabled = false;
                enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
                enactmentTextbox2.SelectionAlignment = HorizontalAlignment.Center;
                delButton.Visible = addButton.Visible = false;
                feeNumericUpDown.Visible = label23.Visible = label8.Visible = label4.Visible = searchButton.Visible = enactmentTextbox.Visible = enactmentTextbox2.Visible = true;
                setButton.Text = "تایید";
                SqlCommand cmdget = new SqlCommand("select enactmentId, fee from StudyHelps where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(0));
                        feeNumericUpDown.Value = this.fee = reader.GetDecimal(1);
                    }
                }
                if (this.Text == "ویرایش تایید معرفی‌نامه تحصیلی")
                {
                    cmdget = new SqlCommand("select fenactmentId from StudyHelps where id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enactmentTextbox2.Text = ExtensionFunction.EnglishToPersian(reader.GetString(0));
                        }
                    }
                }
            }
            SqlCommand cmd;
            SqlDataAdapter da; DataTable dt;
            
            cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@dtype", "Shelp");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
            if(this.Text == "ارائه معرفی‌نامه تحصیلی")
            {
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyFinList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده' from StudyRecList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            recDataGridView.DataSource = dt;
            con.Close();
        }
        private void visitButton_Click(object sender, EventArgs e)
        {
            string dpath = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
            System.Diagnostics.Process.Start(dpath);
        }

        private void feeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(this.Text == "ویرایش تایید معرفی‌نامه تحصیلی")
            {
                setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            res = true;
            DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به بازگشت به حالت ارائه معرفی‌نامه اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (dr == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdup = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set status = @stat, enddate = Null where id = @id; insert into StudyFinList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyRecList where hId = @id; delete from StudyRecList where hId = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdup.Parameters.AddWithValue("@id", this.id);
                cmdup.Parameters.AddWithValue("@stat", "تعریف شده");
                cmdup.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
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
            for (int i = 1; i < recDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = recDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < recDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < recDataGridView.Columns.Count; j++)
                {
                    if (recDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(recDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = recDataGridView.Rows[i].Cells[j].Value.ToString();
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
            for (int i = 1; i < recDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = recDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < recDataGridView.Columns.Count; j++)
            {
                if (recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
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
