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
    public partial class otherHelpGlobalPresentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, ctype, pp, cashtype;
        int packs;
        bool res = false, newlistButtonLock = false;
        decimal fee, metric, packFee, packpoint;
        List<KeyValuePair<decimal, string>> li;
        Dictionary<string, Tuple<string, decimal, string>> di, di1;
        KeyValuePair<decimal, string>[] arr;
        List<KeyValuePair<string, string>> bankA;
        public otherHelpGlobalPresentForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<decimal, string>>();
            bankA = new List<KeyValuePair<string, string>>();
            di = new Dictionary<string, Tuple<string, decimal, string>>();
            di1 = new Dictionary<string, Tuple<string, decimal, string>>();
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void otherHelpGlobalPresentForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetcash = new SqlCommand("select cashtype from otherHelpsGlobal where id = @id;", con);
            cmdgetcash.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdgetcash.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.cashtype = reader.GetString(0);
                }
            }
            if(cashtype == "غیرنقدی")
            {
                bankAccountNameComboBox.Enabled = false;
            }
            SqlCommand cmdget2 = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdget2.ExecuteReader())
            {
                while (reader.Read())
                {
                    bankA.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    bankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            if (this.Text == "تایید کمک متفرقه گروهی" || this.Text == "ویرایش تایید کمک متفرقه گروهی")
            {
                enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
                enactmentTextbox2.SelectionAlignment = HorizontalAlignment.Center;
                bankAccountNameComboBox.Enabled =  delButton.Visible = newListButton.Visible = false;
                feeNumericUpDown.Visible = label23.Visible = label8.Visible = label4.Visible = searchButton.Visible = enactmentTextbox.Visible = enactmentTextbox2.Visible = true;
                label1.Text = "فایل‌‌های ارائه";
                addButton.Text = "مشاهده";
                addButton.BackColor = Color.Aquamarine;
                addButton.FlatAppearance.BorderColor = Color.LightSeaGreen;
                setButton.Text = "تایید";
                SqlCommand cmdget = new SqlCommand("select enactmentId, fee, ctype, bankAccountName, bankAccountId from OtherHelpsGlobal where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(0));
                        feeNumericUpDown.Value = this.fee = reader.GetDecimal(1);
                        this.ctype = reader.GetString(2);
                        bankAccountNameComboBox.Text = reader.GetString(3);
                        bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(4));
                    }
                }
                if (this.Text == "ویرایش تایید کمک متفرقه گروهی")
                {
                    cmdget = new SqlCommand("select fenactmentId from OtherHelpsGlobal where id = @id;", con);
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
            else if (this.Text == "ویرایش ارائه کمک متفرقه گروهی")
            {
                addButton.Visible = delButton.Visible = newListButton.Visible = setButton.Enabled = false;
                bankAccountNameComboBox.Enabled = editButton.Visible = true; setButton.Visible = false;
                res = true;
            }
            else if (this.Text == "ارائه کمک متفرقه گروهی")
            {
                addButton.Enabled = delButton.Enabled = false;
                setButton.Enabled = memberDataGridView.RowCount == 0;
                newListButton.Enabled = !setButton.Enabled && !newlistButtonLock;
                SqlCommand cmdgetGhelp = new SqlCommand("select fee, packets, metric, ctype from OtherHelpsGlobal where id = @id", con);
                cmdgetGhelp.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdgetGhelp.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.packs = reader.GetInt32(1);
                        this.fee = reader.GetDecimal(0);
                        this.metric = reader.GetDecimal(2);
                        this.ctype = reader.GetString(3);
                    }
                }
                this.packFee = this.fee / this.packs;
                this.packpoint = this.packFee / this.metric;
            }
            SqlCommand cmd;
            SqlDataAdapter da; DataTable dt;
            if (this.Text == "تایید کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@dtype", "OGhelp");
            }
            else
            {
                if (this.ctype == "همه خانوارها")
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                else
                {
                    cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                cmd.Parameters.AddWithValue("@hId", this.id);
            }
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            if (this.Text == "تایید کمک متفرقه گروهی")
            {
                memberDataGridView.Columns[0].Visible = memberDataGridView.Columns[3].Visible = false;
            }
            else
            {
                memberDataGridView.Columns[7].Visible = false;
            }
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            recDataGridView.DataSource = dt;
            recDataGridView.Columns[8].Visible = false;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            notexistdataGridView.DataSource = dt;
            notexistdataGridView.Columns[7].Visible = false;
            if(memberDataGridView.RowCount == 0)
            {
                newListButton.Enabled = false;
                newlistButtonLock = true;
            }
            con.Close();
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
                for (int i = 0; i < recDataGridView.SelectedCells.Count; i++)
                {
                    if (recDataGridView.Rows[recDataGridView.SelectedCells[i].RowIndex].Cells[3].Value.ToString() == "نهایی")
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
            if (this.Text == "تایید کمک متفرقه گروهی")
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

        private void editButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش فایل‌های ارائه کمک متفرقه گروهی", this.id, "OGhelp");
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

        private void otherHelpGlobalPresentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "ویرایش ارائه کمک متفرقه گروهی" && !this.res)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایلی بارگزاری نشده است، پیش از خروج باید فایلی بارگزاری نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
            else if (this.Text == "ارائه کمک متفرقه گروهی")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                if (recDataGridView.RowCount > 0 || notexistdataGridView.RowCount > 0)
                {
                    SqlCommand cmd = new SqlCommand("update OtherHelpsGlobal Set status = @stat where id = @id and status = N'تعریف شده';", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@stat", "در حال ارائه");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update OtherHelpsGlobal Set status = @stat where id = @id and status = N'در حال ارائه';", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                    cmd.ExecuteNonQuery();
                }
                con.Close();
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

        private void bankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(bankA[bankAccountNameComboBox.SelectedIndex].Key);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox2.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void enactmentTextbox2_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک متفرقه گروهی")
                setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void otherHelpGlobalPresentForm_Activated(object sender, EventArgs e)
        {
            if (memberDataGridView.RowCount != 0 && memberDataGridView.SelectedCells.Count != 0)
                memberDataGridView.SelectedCells[0].Selected = false;
            if (notexistdataGridView.RowCount != 0 && notexistdataGridView.SelectedCells.Count != 0)
                notexistdataGridView.SelectedCells[0].Selected = false;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک متفرقه گروهی")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();

                decimal budget = 0, consume = 0, stock = 0;
                if (cashtype == "نقدی")
                {
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select stock from bankAccount where id = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "othersBudget");
                    cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                    cmdget3.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fenactmentId = @feId, status = @stat, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update bankAccount Set stock = @amount3 where id = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@stat", "نهایی");
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmd.Parameters.AddWithValue("@tname3", "stock");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت تایید و نهایی شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "othersBudget");
                    cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fenactmentId = @feId, status = @stat, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@stat", "نهایی");
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmd.Parameters.AddWithValue("@tname3", "stock");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت تایید و نهایی شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه گروهی")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();

                decimal budget = 0, consume = 0, stock = 0;
                if (cashtype == "نقدی")
                {
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select stock from bankAccount where id = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "othersBudget");
                    cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                    cmdget3.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fenactmentId = @feId, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update bankAccount Set stock = @amount3 where id = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmd.Parameters.AddWithValue("@tname3", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("تایید کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "othersBudget");
                    cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fenactmentId = @feId, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox2.Text));
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmd.Parameters.AddWithValue("@tname3", "stock");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("تایید کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
                
            }
            else
            {
                if(cashtype == "نقدی" && bankAccountNameComboBox.SelectedIndex == -1)
                {
                    FMessegeBox.FarsiMessegeBox.Show("حساب بانکی انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("ثبت کمک باعث پایان فرآیند ارائه کمک می‌شود و این حرکت قابل بازگردانی نمی‌باشد. نسبت به این کار اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (dr != DialogResult.Yes)
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
                        cmd.Parameters.AddWithValue("@dtype", "OGhelp");
                        cmd.ExecuteNonQuery();
                    }
                    int remain = 0;
                    SqlCommand cmdget = new SqlCommand("select packets from OtherHelpsGlobalFinList where hId = @hId;", con);
                    cmdget.Parameters.AddWithValue("@hId", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            remain += reader.GetInt32(0);
                        }
                    }
                    int defpacks = 0;
                    decimal deffee = 0;
                    cmdget = new SqlCommand("select packets, fee from OtherHelpsGlobal where id = @hId;", con);
                    cmdget.Parameters.AddWithValue("@hId", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            defpacks = reader.GetInt32(0);
                            deffee = reader.GetDecimal(1);
                        }
                    }
                    decimal budget = 0, consume = 0, stock = 0;
                    if(cashtype == "نقدی")
                    {
                        SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                        SqlCommand cmdget3 = new SqlCommand("select stock from bankAccount where id = @id", con);
                        cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                        cmdget3.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
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
                        if(stock < fee - (remain * packFee))
                        {
                            FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            return;
                        }
                        SqlCommand cmdup = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set status = @stat, enddate = @edate, packets = @packs, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update bankAccount Set stock = @amount3 where id = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmdup.Parameters.AddWithValue("@id", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "پایان‌یافته");
                        cmdup.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                        cmdup.Parameters.AddWithValue("@packs", defpacks - remain);
                        cmdup.Parameters.AddWithValue("@fee", deffee - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount2", consume - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount3", stock - (fee - (remain * packFee)));
                        cmdup.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmdup.Parameters.AddWithValue("@tname3", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                        cmdup.ExecuteNonQuery();
                        cmdup = new SqlCommand("update OtherHelpsGlobalRecList Set status = @stat where hId = @hId;", con);
                        cmdup.Parameters.AddWithValue("@hId", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "نهایی");
                        cmdup.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                        SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                        cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                        cmdget3.Parameters.AddWithValue("@id", "stock");
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
                        SqlCommand cmdup = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set status = @stat, enddate = @edate, packets = @packs, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmdup.Parameters.AddWithValue("@id", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "پایان‌یافته");
                        cmdup.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                        cmdup.Parameters.AddWithValue("@packs", defpacks - remain);
                        cmdup.Parameters.AddWithValue("@fee", deffee - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount2", consume - remain * packFee);
                        cmdup.Parameters.AddWithValue("@amount3", stock + remain * packFee);
                        cmdup.Parameters.AddWithValue("@tname2", "othersConsume");
                        cmdup.Parameters.AddWithValue("@tname3", "stock");
                        cmdup.ExecuteNonQuery();
                        cmdup = new SqlCommand("update OtherHelpsGlobalRecList Set status = @stat where hId = @hId;", con);
                        cmdup.Parameters.AddWithValue("@hId", this.id);
                        cmdup.Parameters.AddWithValue("@stat", "نهایی");
                        cmdup.ExecuteNonQuery();
                    }
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

        private void newListButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("این حرکت بازگشت پذیر نمی باشد. آیا مطمئن هستید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            di.Clear(); di1.Clear(); li.Clear();
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            int remain = 0;
            SqlCommand cmdget = new SqlCommand("select count(*) from OtherHelpsGlobalFinList where hId = @hId;", con);
            cmdget.Parameters.AddWithValue("@hId", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    remain += reader.GetInt32(0);
                }
            }
            this.packs = remain;
            SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalNotComeList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalFinList where hId = @hId; delete from OtherHelpsGlobalFinList where hId = @hId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmdtransfer.Parameters.AddWithValue("@hId", this.id);
            cmdtransfer.ExecuteNonQuery();
            SqlCommand cmdup = new SqlCommand("update OtherHelpsGlobalRecList Set status = @stat where hId = @hId and status = N'قابل بازگردانی';", con);
            cmdup.Parameters.AddWithValue("@stat", "نهایی");
            cmdup.Parameters.AddWithValue("@hId", this.id);
            cmdup.ExecuteNonQuery();
            
            SqlCommand cmdgettmp = new SqlCommand("insert into OtherHelpsGlobalFinList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalTmpList where hId = @hId and mId not in (select mId from OtherHelpsGlobalNotComeList where hId = @hId);", con);
            cmdgettmp.Parameters.AddWithValue("@hId", this.id);
            int ans = cmdgettmp.ExecuteNonQuery();
            cmdgettmp = new SqlCommand("insert into OtherHelpsGlobalFinList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalDelList where hId = @hId and mId not in (select mId from OtherHelpsGlobalNotComeList where hId = @hId);", con);
            cmdgettmp.Parameters.AddWithValue("@hId", this.id);
            ans += cmdgettmp.ExecuteNonQuery();
            if (ans == 0)
            {
                newListButton.Enabled = false;
                newlistButtonLock = true;
                SqlCommand cmda;
                if (this.ctype == "همه خانوارها")
                {
                    cmda = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                else
                {
                    cmda = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                cmda.Parameters.AddWithValue("@hId", this.id);
                SqlDataAdapter daa; DataTable dta;
                daa = new SqlDataAdapter(cmda);
                dta = new DataTable();
                daa.Fill(dta);
                memberDataGridView.DataSource = dta;
                memberDataGridView.Columns[7].Visible = false;
                if (this.ctype == "همه خانوارها")
                {
                    cmda = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
                }
                else
                {
                    cmda = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
                }
                cmda.Parameters.AddWithValue("@hId", this.id);
                daa = new SqlDataAdapter(cmda);
                dta = new DataTable();
                daa.Fill(dta);
                recDataGridView.DataSource = dta;
                recDataGridView.Columns[8].Visible = false;
                if (this.ctype == "همه خانوارها")
                {
                    cmda = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
                }
                else
                {
                    cmda = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
                }
                cmda.Parameters.AddWithValue("@hId", this.id);
                daa = new SqlDataAdapter(cmda);
                dta = new DataTable();
                daa.Fill(dta);
                notexistdataGridView.DataSource = dta;
                notexistdataGridView.Columns[7].Visible = false;
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("مددجویی برای افزودن به لیست نمانده است. لطفا کمک را به اتمام رسانید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            cmdgettmp = new SqlCommand("select supporter_id, folder_id, rate, mId from OtherHelpsGlobalFinList where hId = @hId;", con);
            cmdgettmp.Parameters.AddWithValue("@hId", this.id);
            using (SqlDataReader reader = cmdgettmp.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (this.ctype == "همه خانوارها")
                    {
                        di[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(2), reader.GetString(3));
                    }
                    else
                    {
                        di[reader.GetString(3)] = new Tuple<string, decimal, string>(reader.GetString(1), reader.GetDecimal(2), reader.GetString(0));
                    }
                }
            }
            cmdget = new SqlCommand("select folder_id, mId from OtherHelpsGlobalRecList where hId = @hId;", con);
            cmdget.Parameters.AddWithValue("@hId", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (this.ctype == "همه خانوارها")
                    {
                        if (!di.ContainsKey(reader.GetString(0)))
                            continue;
                        di[reader.GetString(0)] = new Tuple<string, decimal, string>(di[reader.GetString(0)].Item1, Math.Max(di[reader.GetString(0)].Item2 - this.packpoint, Convert.ToDecimal(0)), reader.GetString(1));
                    }
                    else
                    {
                        if (!di.ContainsKey(reader.GetString(1)))
                            continue;
                        di[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(2), di[reader.GetString(1)].Item3);
                    }
                    
                }
            }
            foreach(var dd in di)
            {
                li.Add(new KeyValuePair<decimal, string>(dd.Value.Item2, dd.Key));   
            }
            SqlCommand cmddel;
            int rem = 0;
            arr = li.ToArray();
            arr.OrderBy((x => x.Key)).ToArray();
            Array.Reverse(arr);
            foreach (var dd in arr)
            {
                FMessegeBox.FarsiMessegeBox.Show("for " + rem.ToString() + " " + this.packs.ToString() + " " + arr.Length);
                if (rem >= this.packs)
                {
                    cmddel = new SqlCommand("delete from OtherHelpsGlobalFinList where hId = @hId and folder_id = @fId and mId = @mId;", con);
                    cmddel.Parameters.AddWithValue("@hId", this.id);
                    if (this.ctype == "همه خانوارها")
                    {
                        cmddel.Parameters.AddWithValue("@fId", dd.Value);
                        cmddel.Parameters.AddWithValue("@mId", di[dd.Value].Item3);
                    }
                    else
                    {
                        cmddel.Parameters.AddWithValue("@fId", di[dd.Value].Item1);
                        cmddel.Parameters.AddWithValue("@mId", dd.Value);
                    }
                    cmddel.ExecuteNonQuery();
                    di.Remove(dd.Value);
                    FMessegeBox.FarsiMessegeBox.Show("del "+dd.Key+" "+dd.Value);
                }
                rem++;
            }
            foreach (var dd in di)
            {
                di1[dd.Key] = new Tuple<string, decimal, string>(dd.Value.Item1, dd.Value.Item2, dd.Value.Item3);
            }
            foreach (var dd in di1)
            {
                cmdup = new SqlCommand("update OtherHelpsGlobalFinList Set packets = @packs where hId = @hId and folder_id = @fId and mId = @mId;", con);
                cmdup.Parameters.AddWithValue("@packs", 1);
                cmdup.Parameters.AddWithValue("@hId", this.id);
                if (this.ctype == "همه خانوارها")
                {
                    cmdup.Parameters.AddWithValue("@fId", dd.Key);
                    cmdup.Parameters.AddWithValue("@mId", dd.Value.Item3);
                }
                else
                {
                    cmdup.Parameters.AddWithValue("@fId", dd.Value.Item1);
                    cmdup.Parameters.AddWithValue("@mId", dd.Key);
                }
                cmdup.ExecuteNonQuery();
            }
            SqlCommand cmd;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            SqlDataAdapter da; DataTable dt;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[7].Visible = false;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            recDataGridView.DataSource = dt;
            recDataGridView.Columns[8].Visible = false;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalNotComeList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            notexistdataGridView.DataSource = dt;
            notexistdataGridView.Columns[7].Visible = false;
            con.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک متفرقه گروهی")
            {
                string dpath = memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
                System.Diagnostics.Process.Start(dpath);
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                int i = Convert.ToInt32(memberDataGridView.Rows[memberDataGridView.SelectedCells[0].RowIndex].Cells[memberDataGridView.ColumnCount-1].Value);
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalRecList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalFinList where i = @i; delete from OtherHelpsGlobalFinList where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@i", i);
                cmdtransfer.ExecuteNonQuery();
                cmdtransfer = new SqlCommand("update OtherHelpsGlobalRecList Set status = @stat where hId = @hId and status is Null;", con);
                cmdtransfer.Parameters.AddWithValue("@stat", "قابل بازگردانی");
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.ExecuteNonQuery();
                SqlCommand cmd;
                if (this.ctype == "همه خانوارها")
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                else
                {
                    cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
                }
                SqlDataAdapter da; DataTable dt;
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                memberDataGridView.Columns[7].Visible = false;
                if (this.ctype == "همه خانوارها")
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
                }
                else
                {
                    cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
                }
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                recDataGridView.DataSource = dt;
                recDataGridView.Columns[8].Visible = false;
                con.Close();
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            int i = Convert.ToInt32(recDataGridView.Rows[recDataGridView.SelectedCells[0].RowIndex].Cells[recDataGridView.ColumnCount-1].Value);
            SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalFinList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalRecList where i = @i; delete from OtherHelpsGlobalRecList where i = @i; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmdtransfer.Parameters.AddWithValue("@i", i);
            cmdtransfer.ExecuteNonQuery();
            SqlCommand cmd;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', i from OtherHelpsGlobalFinList where hId = @hId;", con);
            }
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[7].Visible = false;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', packets as 'تعداد بسته', status as 'وضعیت', i from OtherHelpsGlobalRecList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            recDataGridView.DataSource = dt;
            recDataGridView.Columns[8].Visible = false;
            con.Close();
        }

    }
}
