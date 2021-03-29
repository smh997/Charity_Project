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
    public partial class helpPresentationForm3 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, type, pp, deftype;
        int packs;
        bool res = false, newlistButtonLock = false;
        decimal fee, metric, packFee, packpoint;
        List<KeyValuePair<decimal, string>> li;
        Dictionary<string, Tuple<string, int, decimal>> di, di1;
        KeyValuePair<decimal, string>[] arr;
        public helpPresentationForm3(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<decimal, string>>();
            di = new Dictionary<string, Tuple<string, int, decimal>>();
            di1 = new Dictionary<string, Tuple<string, int, decimal>>();
            if (p != "")
            {
                this.Text = p;
            }
        }
        private void recDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0 || recDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() == "نهایی")
            {
                recDataGridView.ClearSelection();
            }
        }

        private void memberDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            memberDataGridView.ClearSelection();
        }

        private void recDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            recDataGridView.ClearSelection();
        }

        private void memberDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            addButton.Enabled = (memberDataGridView.SelectedCells.Count != 0);
        }

        private void recDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (recDataGridView.SelectedCells.Count != 0)
            {
                for(int i = 0; i< recDataGridView.SelectedCells.Count; i++)
                {
                    if(recDataGridView.Rows[recDataGridView.SelectedCells[i].RowIndex].Cells[3].Value.ToString() == "نهایی")
                    {
                        recDataGridView.SelectedCells[i].Selected = false;
                    }
                }
            }
            delButton.Enabled = (recDataGridView.SelectedCells.Count != 0);
        }

        private void memberDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            newListButton.Enabled = (memberDataGridView.RowCount != 0 && !newlistButtonLock);
        }

        private void memberDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text.Contains("جمعی"))
            {
                if (this.Text == "تایید کمک جمعی")
                {
                    if (e.RowIndex == -1 || e.ColumnIndex == 2)
                    {
                        memberDataGridView.ClearSelection();
                    }
                }
                else
                {
                    if (e.RowIndex == -1 || e.ColumnIndex != 0)
                    {
                        memberDataGridView.ClearSelection();
                    }
                }
            }
            else if (this.Text.Contains("تحصیلی"))
            {
                if (this.Text == "تایید کمک تحصیلی")
                {
                    if (e.RowIndex == -1 || e.ColumnIndex == 2)
                    {
                        memberDataGridView.ClearSelection();
                    }
                }
                else
                {
                    if (e.RowIndex == -1 || e.ColumnIndex != 0)
                    {
                        memberDataGridView.ClearSelection();
                    }
                }
            }
            
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            doceditForm newform;
            if (this.Text.Contains("جمعی"))
            {
                newform = new doceditForm("ویرایش فایل‌های ارائه کمک جمعی", this.id, "Ghelp");
            }
            else
            {
                newform = new doceditForm("ویرایش فایل‌های ارائه کمک تحصیلی", this.id, "Shelp");
            }
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
            {
                this.res = false;
            }
            else
            {
                this.res = true;
            }
        }

        private void helpPresentationForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Contains("جمعی"))
            {
                if (this.Text == "ویرایش ارائه کمک جمعی" && !this.res)
                {
                    FMessegeBox.FarsiMessegeBox.Show("فایلی بارگزاری نشده است، پیش از خروج باید فایلی بارگزاری نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    e.Cancel = true;
                }
                else if (this.Text == "ارائه کمک جمعی")
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    if (recDataGridView.RowCount > 0 || notexistdataGridView.RowCount > 0)
                    {
                        SqlCommand cmd = new SqlCommand("update GlobalHelps Set status = @stat where id = @id and status = N'تعریف شده';", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@stat", "در حال ارائه");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update GlobalHelps Set status = @stat where id = @id and status = N'در حال ارائه';", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            else if(this.Text.Contains("تحصیلی"))
            {
                if (this.Text == "ویرایش ارائه کمک تحصیلی" && !this.res)
                {
                    FMessegeBox.FarsiMessegeBox.Show("فایلی بارگزاری نشده است، پیش از خروج باید فایلی بارگزاری نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    e.Cancel = true;
                }
                else if (this.Text == "ارائه کمک تحصیلی")
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    if (recDataGridView.RowCount > 0 || notexistdataGridView.RowCount > 0)
                    {
                        SqlCommand cmd = new SqlCommand("update StudyHelps Set status = @stat where id = @id and status = N'تعریف شده';", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@stat", "در حال ارائه");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update StudyHelps Set status = @stat where id = @id and status = N'در حال ارائه';", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
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
                for (int j = 0; j < memberDataGridView.Columns.Count-1; j++)
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

        private void recDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox2.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                if(this.deftype == "پیشامده")
                    enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void enactmentTextbox2_TextChanged(object sender, EventArgs e)
        {
            if(this.Text == "تایید کمک جمعی" || this.Text == "تایید کمک تحصیلی")
                setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void helpPresentationForm3_Activated(object sender, EventArgs e)
        {
            if(memberDataGridView.RowCount != 0 && memberDataGridView.SelectedCells.Count != 0)
                memberDataGridView.SelectedCells[0].Selected = false;
            if (notexistdataGridView.RowCount != 0 && notexistdataGridView.SelectedCells.Count !=0)
                notexistdataGridView.SelectedCells[0].Selected = false;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text.Contains("جمعی"))
            {
                if (this.Text == "تایید کمک جمعی")
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();

                    decimal budget = 0, consume = 0, stock = 0;
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    switch (this.type)
                    {
                        case "گوشت":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "meat");
                            break;
                        case "خواربار":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "grocery");
                            break;
                        case "مرغ":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "chicken");
                            break;
                        case "نان":
                            cmdget.Parameters.AddWithValue("@id", "breadBudget");
                            cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                            cmdget3.Parameters.AddWithValue("@id", "bread");
                            break;
                    }
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update GlobalHelps Set fenactmentId = @feId, status = @stat, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@stat", "نهایی");
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        switch (this.type)
                        {
                            case "گوشت":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "meat");
                                break;
                            case "خواربار":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "grocery");
                                break;
                            case "مرغ":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "chicken");
                                break;
                            case "نان":
                                cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                                cmd.Parameters.AddWithValue("@tname3", "bread");
                                break;
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت تایید و نهایی شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                    
                }
                else if (this.Text == "ویرایش تایید کمک جمعی")
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();

                    decimal budget = 0, consume = 0, stock = 0;
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    switch (this.type)
                    {
                        case "گوشت":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "meat");
                            break;
                        case "خواربار":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "grocery");
                            break;
                        case "مرغ":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "chicken");
                            break;
                        case "نان":
                            cmdget.Parameters.AddWithValue("@id", "breadBudget");
                            cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                            cmdget3.Parameters.AddWithValue("@id", "bread");
                            break;
                    }
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update GlobalHelps Set fenactmentId = @feId, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        switch (this.type)
                        {
                            case "گوشت":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "meat");
                                break;
                            case "خواربار":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "grocery");
                                break;
                            case "مرغ":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "chicken");
                                break;
                            case "نان":
                                cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                                cmd.Parameters.AddWithValue("@tname3", "bread");
                                break;
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("تایید کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
                else
                {
                    DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("ثبت کمک باعث پایان فرآیند ارائه کمک می‌شود و این حرکت قابل بازگردانی نمی‌باشد. نسبت به این کار اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if(dr != DialogResult.Yes)
                    {
                        return;
                    }
                    addOpenFileDialog.Title = "انتخاب فایل‌های کمک";
                    addOpenFileDialog.FileName = "*.pdf";
                    if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SqlConnection con = new SqlConnection(this.connection);
                        con.Open();
                        string fileName, targetPath, destFile;
                        SqlCommand cmd;
                        System.IO.Directory.CreateDirectory(helpPath + "\\" + this.id);
                        foreach (var d in addOpenFileDialog.FileNames)
                        {
                            fileName = System.IO.Path.GetFileName(d);
                            targetPath = helpPath + "\\" + this.id + "\\";
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(d, destFile, false);
                            cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@dtype", "Ghelp");
                            cmd.ExecuteNonQuery();
                        }
                        int remain = 0;
                        SqlCommand cmdget = new SqlCommand("select packets from finalizedTableHelp where gId = @gId;", con);
                        cmdget.Parameters.AddWithValue("@gId", this.id);
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                remain += reader.GetInt32(0);
                            }
                        }
                        int defpacks = 0;
                        decimal deffee = 0;
                        cmdget = new SqlCommand("select packets, fee from GlobalHelps where id = @gId;", con);
                        cmdget.Parameters.AddWithValue("@gId", this.id);
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                defpacks = reader.GetInt32(0);
                                deffee = reader.GetDecimal(1);
                            }
                        }
                        decimal budget = 0, consume = 0, stock = 0;
                        SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                        SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                        switch (this.type)
                        {
                            case "گوشت":
                                cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                cmdget3.Parameters.AddWithValue("@id", "meat");
                                break;
                            case "خواربار":
                                cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                cmdget3.Parameters.AddWithValue("@id", "grocery");
                                break;
                            case "مرغ":
                                cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                cmdget3.Parameters.AddWithValue("@id", "chicken");
                                break;
                            case "نان":
                                cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                cmdget3.Parameters.AddWithValue("@id", "bread");
                                break;
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
                        SqlCommand cmdup = new SqlCommand("BEGIN TRY begin tran t1; update GlobalHelps Set status = @stat, enddate = @edate, packets = @packs, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmdup.Parameters.AddWithValue("@id", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "پایان‌یافته");
                        cmdup.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                        cmdup.Parameters.AddWithValue("@packs", defpacks-remain);
                        cmdup.Parameters.AddWithValue("@fee", deffee - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount2", consume - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount3", stock + remain * packFee);
                        switch (this.type)
                        {
                            case "گوشت":
                                cmdup.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmdup.Parameters.AddWithValue("@tname3", "meat");
                                break;
                            case "خواربار":
                                cmdup.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmdup.Parameters.AddWithValue("@tname3", "grocery");
                                break;
                            case "مرغ":
                                cmdup.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmdup.Parameters.AddWithValue("@tname3", "chicken");
                                break;
                            case "نان":
                                cmdup.Parameters.AddWithValue("@tname2", "breadConsume");
                                cmdup.Parameters.AddWithValue("@tname3", "bread");
                                break;
                        }
                        cmdup.ExecuteNonQuery();
                        cmdup = new SqlCommand("update receivedTableHelp Set status = @stat where gId = @gId;", con);
                        cmdup.Parameters.AddWithValue("@gId", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "نهایی");
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت پایان یافت!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                    else
                    {
                        addOpenFileDialog.FileName = "*.pdf";
                    }
                }
            }
            else if(this.Text.Contains("تحصیلی"))
            {
                if (this.Text == "تایید کمک تحصیلی")
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
                else if (this.Text == "ویرایش تایید کمک تحصیلی")
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
                else
                {
                    DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("ثبت کمک باعث پایان فرآیند ارائه کمک می‌شود و این حرکت قابل بازگردانی نمی‌باشد. نسبت به این کار اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if(dr != DialogResult.Yes)
                    {
                        return;
                    }
                    addOpenFileDialog.Title = "انتخاب فایل‌های کمک";
                    addOpenFileDialog.FileName = "*.pdf";
                    if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SqlConnection con = new SqlConnection(this.connection);
                        con.Open();
                        string fileName, targetPath, destFile;
                        SqlCommand cmd;
                        System.IO.Directory.CreateDirectory(helpPath + "\\" + this.id);
                        foreach (var d in addOpenFileDialog.FileNames)
                        {
                            fileName = System.IO.Path.GetFileName(d);
                            targetPath = helpPath + "\\" + this.id + "\\";
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(d, destFile, false);
                            cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@dtype", "Shelp");
                            cmd.ExecuteNonQuery();
                        }
                        SqlCommand cmdup = new SqlCommand("update StudyHelps Set status = @stat, enddate = @edate where id = @id;", con);
                        cmdup.Parameters.AddWithValue("@id", this.id);
                        cmdup.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                        cmdup.Parameters.AddWithValue("@stat", "پایان‌یافته");
                        cmdup.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت پایان یافت!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                    else
                    {
                        addOpenFileDialog.FileName = "*.pdf";
                    }
                }
            }
            
        }

        

        private void newListButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("این حرکت بازگشت پذیر نمی باشد. آیا مطمئن هستید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }
            if (this.Text.Contains("جمعی"))
            {
                di.Clear(); di1.Clear(); li.Clear();
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                int remain = 0;
                SqlCommand cmdget = new SqlCommand("select packets from finalizedTableHelp where gId = @gId;", con);
                cmdget.Parameters.AddWithValue("@gId", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        remain += reader.GetInt32(0);
                    }
                }
                this.packs = remain;
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into notexistTableHelp (gId, supporter_id, folder_id, packets, rate) select gId, supporter_id, folder_id, packets, rate from finalizedTableHelp where gId = @gId; delete from finalizedTableHelp where gId = @gId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@gId", this.id);
                cmdtransfer.ExecuteNonQuery();
                SqlCommand cmdup = new SqlCommand("update receivedTableHelp Set status = @stat where gId = @gId and status = N'قابل بازگردانی';", con);
                cmdup.Parameters.AddWithValue("@stat", "نهایی");
                cmdup.Parameters.AddWithValue("@gId", this.id);
                int ans = cmdup.ExecuteNonQuery();
                if (ans == 0)
                {
                    newListButton.Enabled = false;
                    newlistButtonLock = true;
                }
                SqlCommand cmdgettmp = new SqlCommand("insert into finalizedTableHelp (gId, supporter_id, folder_id, packets, rate) select gId, supporter_id, folder_id, packets, rate from tmpDefinedTableHelp where gId = @gId and folder_id not in (select folder_id from notexistTableHelp where gId = @gId);", con);
                cmdgettmp.Parameters.AddWithValue("@gId", this.id);
                cmdgettmp.ExecuteNonQuery();
                cmdgettmp = new SqlCommand("select supporter_id, folder_id, packets, rate from finalizedTableHelp where gId = @gId;", con);
                cmdgettmp.Parameters.AddWithValue("@gId", this.id);
                using (SqlDataReader reader = cmdgettmp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                    }
                }
                cmdget = new SqlCommand("select folder_id, packets from receivedTableHelp where gId = @gId;", con);
                cmdget.Parameters.AddWithValue("@gId", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        di[reader.GetString(0)] = new Tuple<string, int, decimal>(di[reader.GetString(0)].Item1, 0, Math.Max(di[reader.GetString(0)].Item3 - reader.GetInt32(1) * this.packpoint, Convert.ToDecimal(0)));
                    }
                }
                decimal sum = 0; int consumep = 0;
                foreach (var dd in di)
                {
                    sum += dd.Value.Item3;
                }
                foreach (var dd in di)
                {
                    int p = Convert.ToInt32(dd.Value.Item3 * this.packs / sum); consumep += p;
                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                    li.Add(new KeyValuePair<decimal, string>(Math.Max(dd.Value.Item3 - p * this.packpoint, 0), dd.Key));
                }
                arr = li.ToArray();
                arr.OrderBy((x => x.Key)).ToArray();
                Array.Reverse(arr);
                int i = 0;
                while (consumep != this.packs)
                {
                    di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                    i++;
                    consumep++;
                }
                foreach (var dd in di1)
                {
                    cmdup = new SqlCommand("update finalizedTableHelp Set packets = @packs where gId = @gId and folder_id = @fId;", con);
                    cmdup.Parameters.AddWithValue("@packs", dd.Value.Item2);
                    cmdup.Parameters.AddWithValue("@gId", this.id);
                    cmdup.Parameters.AddWithValue("@fId", dd.Key);
                    cmdup.ExecuteNonQuery();
                }
                SqlCommand cmddel;
                foreach (var dd in di1)
                {
                    if (dd.Value.Item2 == 0)
                    {
                        cmddel = new SqlCommand("delete from finalizedTableHelp where gId = @gId and folder_id = @fId;", con);
                        cmddel.Parameters.AddWithValue("@packs", dd.Value.Item2);
                        cmddel.Parameters.AddWithValue("@gId", this.id);
                        cmddel.Parameters.AddWithValue("@fId", dd.Key);
                        cmddel.ExecuteNonQuery();
                    }
                }
                SqlCommand cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from finalizedTableHelp where gId = @gId;", con);
                SqlDataAdapter da; DataTable dt;
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[3].Visible = false;
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from receivedTableHelp where gId = @gId;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[4].Visible = false;
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from notexistTableHelp where gId = @gId;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                notexistdataGridView.DataSource = dt;
                notexistdataGridView.Columns[3].Visible = false;
                con.Close();
            }
            else if (this.Text.Contains("تحصیلی"))
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                int remain = 0;
                SqlCommand cmdget = new SqlCommand("select count(*) from StudyFinList where hId = @hId;", con);
                cmdget.Parameters.AddWithValue("@hId", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        remain = reader.GetInt32(0);
                    }
                }
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into StudyNotComeList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyFinList where hId = @hId; delete from StudyFinList where hId = @hId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.ExecuteNonQuery();
                SqlCommand cmdgettmp = new SqlCommand("insert into StudyFinList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyDelList where hId = @hId and stuId in (select top(@num) stuId from StudyDelList, member where stuId = id and hId = @hId order by rate); delete from StudyDelList where stuId in (select top(@num) stuId from StudyDelList, member where stuId = id and hId = @hId order by rate);", con);
                cmdgettmp.Parameters.AddWithValue("@hId", this.id);
                cmdgettmp.Parameters.AddWithValue("@num", remain);
                cmdgettmp.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyFinList where hId = @hId;", con);
                SqlDataAdapter da; DataTable dt;
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[5].Visible = false;
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyRecList where hId = @hId;", con);
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[5].Visible = false;
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyNotComeList where hId = @hId;", con);
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                notexistdataGridView.DataSource = dt;
                notexistdataGridView.Columns[5].Visible = false;
                con.Close();
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.Text.Contains("جمعی"))
            {
                if (this.Text == "تایید کمک جمعی")
                {
                    string dpath = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
                    System.Diagnostics.Process.Start(dpath);
                }
                else
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    
                    int i = Convert.ToInt32(memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.ColumnCount-1].Value);
                    SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into receivedTableHelp (gId, supporter_id, folder_id, name, family, fatherName, packets, rate) select gId, supporter_id, folder_id, name, family, fatherName, packets, rate from finalizedTableHelp where i = @i; delete from finalizedTableHelp where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdtransfer.Parameters.AddWithValue("@i", i);
                    cmdtransfer.ExecuteNonQuery();
                    cmdtransfer = new SqlCommand("update receivedTableHelp Set status = @stat where gId = @gId and status is Null;", con);
                    cmdtransfer.Parameters.AddWithValue("@stat", "قابل بازگردانی");
                    cmdtransfer.Parameters.AddWithValue("@gId", this.id);
                    cmdtransfer.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', i from finalizedTableHelp where gId = @gId;", con);
                    SqlDataAdapter da; DataTable dt;
                    cmd.Parameters.AddWithValue("@gId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    memberDataGridView.DataSource = dt;
                    memberDataGridView.Columns[6].Visible = false;
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', status as 'وضعیت', i from receivedTableHelp where gId = @gId;", con);
                    cmd.Parameters.AddWithValue("@gId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    recDataGridView.DataSource = dt;
                    recDataGridView.Columns[7].Visible = false;
                    con.Close();
                }
            }
            else if (this.Text.Contains("تحصیلی"))
            {
                if (this.Text == "تایید کمک تحصیلی")
                {
                    string dpath = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
                    System.Diagnostics.Process.Start(dpath);
                }
                else
                {
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    int i = Convert.ToInt32(memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[5].Value);
                    SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into StudyRecList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyFinList where i = @i; delete from StudyFinList where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdtransfer.Parameters.AddWithValue("@i", i);
                    cmdtransfer.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyFinList where hId = @hId;", con);
                    SqlDataAdapter da; DataTable dt;
                    cmd.Parameters.AddWithValue("@hId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    memberDataGridView.DataSource = dt;
                    memberDataGridView.Columns[5].Visible = false;
                    cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyRecList where hId = @hId;", con);
                    cmd.Parameters.AddWithValue("@hId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    recDataGridView.DataSource = dt;
                    recDataGridView.Columns[5].Visible = false;
                    con.Close();
                }
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text.Contains("جمعی"))
            {
                int i = Convert.ToInt32(recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[recDataGridView.ColumnCount-1].Value);
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into finalizedTableHelp (gId, supporter_id, folder_id, packets, rate) select gId, supporter_id, folder_id, packets, rate from receivedTableHelp where i = @i; delete from receivedTableHelp where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@i", i);
                cmdtransfer.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', i from finalizedTableHelp where gId = @gId;", con);
                SqlDataAdapter da; DataTable dt;
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[6].Visible = false;
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', status as 'وضعیت', i from receivedTableHelp where gId = @gId;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[7].Visible = false;
            }
            else if (this.Text.Contains("تحصیلی"))
            {
                int i = Convert.ToInt32(recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[5].Value);
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into StudyFinList (hId, supporter_id, folder_id, name, family, stuId) select hId, supporter_id, folder_id, name, family, stuId from StudyRecList where i = @i; delete from StudyRecList where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@i", i);
                cmdtransfer.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyFinList where hId = @hId;", con);
                SqlDataAdapter da; DataTable dt;
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[5].Visible = false;
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyRecList where hId = @hId;", con);
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[5].Visible = false;
            }
            con.Close();
        }

        private void helpPresentationForm3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text.Contains("جمعی"))
            {
                if (this.Text == "تایید کمک جمعی" || this.Text == "ویرایش تایید کمک جمعی")
                {
                    enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
                    enactmentTextbox2.SelectionAlignment = HorizontalAlignment.Center;
                    addButton.Enabled = delButton.Visible = newListButton.Visible = false;
                    feeNumericUpDown.Visible = label23.Visible = label8.Visible = label4.Visible = searchButton.Visible = enactmentTextbox.Visible = enactmentTextbox2.Visible = true;
                    label1.Text = "فایل‌‌های ارائه";
                    addButton.Text = "مشاهده";
                    addButton.BackColor = Color.Aquamarine;
                    addButton.FlatAppearance.BorderColor = Color.LightSeaGreen;
                    setButton.Text = "تایید";
                    SqlCommand cmdget = new SqlCommand("select enactmentId, defType, fee, type from GlobalHelps where id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(0));
                            this.deftype = deftype = reader.GetString(1);
                            feeNumericUpDown.Value = this.fee = reader.GetDecimal(2);
                            this.type = reader.GetString(3);
                        }
                    }
                    if (this.Text == "ویرایش تایید کمک جمعی")
                    {
                        cmdget = new SqlCommand("select fenactmentId from GlobalHelps where id = @id;", con);
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
                else if (this.Text == "ویرایش ارائه کمک جمعی")
                {
                    addButton.Enabled = delButton.Enabled = memberDataGridView.Enabled = recDataGridView.Enabled = newListButton.Enabled = setButton.Enabled = false;
                    editButton.Visible = true; setButton.Visible = false;
                    res = true;
                }
                else if (this.Text == "ارائه کمک جمعی")
                {
                    addButton.Enabled = delButton.Enabled = false;
                    setButton.Enabled = memberDataGridView.RowCount == 0;
                    newListButton.Enabled = !setButton.Enabled && !newlistButtonLock;
                    SqlCommand cmdgetGhelp = new SqlCommand("select fee, packets, metric, type from GlobalHelps where id = @id", con);
                    cmdgetGhelp.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdgetGhelp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.packs = reader.GetInt32(1);
                            this.fee = reader.GetDecimal(0);
                            this.metric = reader.GetDecimal(2);
                            this.type = reader.GetString(3);
                        }
                    }
                    this.packFee = this.fee / this.packs;
                    this.packpoint = this.packFee / this.metric;
                }
                if (this.type == "نان")
                {
                    this.newlistButtonLock = true;
                }
                SqlCommand cmd;
                SqlDataAdapter da; DataTable dt;
                if (this.Text == "تایید کمک جمعی")
                {
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", "Ghelp");
                }
                else
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', i from finalizedTableHelp where gId = @gId;", con);
                    cmd.Parameters.AddWithValue("@gId", this.id);
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                if (this.Text == "تایید کمک جمعی")
                {
                    memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
                }
                else
                {
                    memberDataGridView.Columns[6].Visible = false;
                }
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', status as 'وضعیت', i from receivedTableHelp where gId = @gId;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[7].Visible = false;
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', i from notexistTableHelp where gId = @gId;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                notexistdataGridView.DataSource = dt;
                notexistdataGridView.Columns[6].Visible = false;
            }
            else if (this.Text.Contains("تحصیلی"))
            {
                if(this.Text == "ارائه کمک تحصیلی")
                {
                    addButton.Enabled = delButton.Enabled = false;
                    setButton.Enabled = memberDataGridView.RowCount == 0;
                    newListButton.Enabled = !setButton.Enabled && !newlistButtonLock;
                    SqlCommand cmdgetGhelp = new SqlCommand("select number from StudyHelps where id = @id", con);
                    cmdgetGhelp.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdgetGhelp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.packs = reader.GetInt32(0);
                        }
                    }
                }
                else if (this.Text == "ویرایش ارائه کمک تحصیلی")
                {
                    addButton.Enabled = delButton.Enabled = memberDataGridView.Enabled = recDataGridView.Enabled = newListButton.Enabled = setButton.Enabled = false;
                    addButton.Visible = delButton.Visible = false;
                    editButton.Visible = true; setButton.Visible = false;
                    res = true;
                }
                else if (this.Text == "تایید کمک تحصیلی" || this.Text == "ویرایش تایید کمک تحصیلی")
                {
                    enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
                    enactmentTextbox2.SelectionAlignment = HorizontalAlignment.Center;
                    delButton.Visible = newListButton.Visible = false;
                    feeNumericUpDown.Visible = label23.Visible = label8.Visible = label4.Visible = searchButton.Visible = enactmentTextbox.Visible = enactmentTextbox2.Visible = true;
                    label1.Text = "فایل‌‌های ارائه";
                    addButton.Text = "مشاهده";
                    addButton.BackColor = Color.Aquamarine;
                    addButton.FlatAppearance.BorderColor = Color.LightSeaGreen;
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
                    if (this.Text == "ویرایش مصوبه تایید کمک تحصیلی")
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
                if (this.Text == "تایید کمک تحصیلی")
                {
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", "Shelp");
                }
                else
                {
                    cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyFinList where hId = @hId;", con);
                    cmd.Parameters.AddWithValue("@hId", this.id);
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                if (this.Text == "تایید کمک تحصیلی")
                {
                    memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
                }
                else
                {
                    memberDataGridView.Columns[5].Visible = false;
                }
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyRecList where hId = @hId;", con);
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[5].Visible = false;
                cmd = new SqlCommand("select stuId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', supporter_id as 'شماره ملی سرپرست', folder_id as 'شماره پرونده', i from StudyNotComeList where hId = @hId;", con);
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                notexistdataGridView.DataSource = dt;
                notexistdataGridView.Columns[5].Visible = false;
            }
            con.Close();
        }
    }
}
