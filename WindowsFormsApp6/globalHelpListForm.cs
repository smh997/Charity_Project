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
    public partial class globalHelpListForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, type, pp;
        int packs;
        bool res = false;
        decimal fee, metric, packFee, packpoint, breadconsume;
        List<KeyValuePair<decimal, string>> li;
        Dictionary<string, Tuple<string, int, decimal>> di, di1, di2;
        KeyValuePair<decimal, string>[] arr;
        public globalHelpListForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<decimal, string>>();
            di = new Dictionary<string, Tuple<string, int, decimal>>();
            di1 = new Dictionary<string, Tuple<string, int, decimal>>();
            di2 = new Dictionary<string, Tuple<string, int, decimal>>();
            if (p != "")
            {
                this.pp = p;
            }
        }
        public void calc_breadconsume()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select fee from receivedTableHelp, GlobalHelps where gId != @id and folder_id = @fId and enddate is not Null and DATEDIFF(day, enddate, GETDATE()) <= 30;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@fId", memberDataGridView.Rows[0].Cells[0].Value.ToString());
            this.breadconsume = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.breadconsume += reader.GetDecimal(0);
                }
            }
            con.Close();
        }
        private void updaterate()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select distinct gId, folder_id, GlobalHelps.packets, receivedTableHelp.packets, fee from GlobalHelps,receivedTableHelp where (GlobalHelps.status = N'تایید شده' or GlobalHelps.status = N'نهایی') and id = gId and DATEADD(day,@days, enddate) >= @now;", con);
            SqlCommand cmdgetparam = new SqlCommand("select point from parameters where name = 'day';", con);
            using(SqlDataReader reader = cmdgetparam.ExecuteReader())
            {
                if (reader.Read())
                {
                    cmdget.Parameters.AddWithValue("@days", reader.GetInt32(0));
                }
            }
            cmdget.Parameters.AddWithValue("@now", DateTime.Now.Date);
            int p=0; decimal f = 0;
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (di.ContainsKey(reader.GetString(1)))
                    {
                        decimal a =  di[reader.GetString(1)].Item3 - (reader.GetDecimal(4) * reader.GetInt32(3) / reader.GetInt32(2)) / this.metric;
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(di[reader.GetString(1)].Item1, di[reader.GetString(1)].Item2, Math.Max(a, 0));
                    }
                }
            }
            con.Close();
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
            if(this.pp == "ویرایش کمک جمعی" && !this.res)
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
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < memberDataGridView.Columns.Count+1; i++)
            {
                worksheet.Cells[1, i] = memberDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < memberDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < memberDataGridView.Columns.Count; j++)
                {
                    if (memberDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(memberDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = memberDataGridView.Rows[i].Cells[j].Value.ToString();
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

        private void setButton_Click(object sender, EventArgs e)
        {
            if (memberDataGridView.Rows.Count==0)
            {
                FMessegeBox.FarsiMessegeBox.Show("لیست نمی‌تواند خالی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            calc_breadconsume();
            decimal familybreadBudget = 0;
            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            cmdget.Parameters.AddWithValue("@id", "breadFamilyBudget");
            using(SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    familybreadBudget = reader.GetDecimal(0);
                }
            }
            if (this.type == "نان" && this.breadconsume + this.fee > familybreadBudget)
            {
                FMessegeBox.FarsiMessegeBox.Show("ارزش ریالی کمک خارج از محدوده بودجه نان مصرفی این خانوار تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlCommand cmd;
            if (this.pp == "ویرایش کمک جمعی")
            {
                cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from finalizedTableHelp where gId = @gId; insert into finalizedTableHelp (gId, supporter_id, name, family, fatherName, folder_id, packets, rate) select gId, supporter_id, name, family, fatherName, folder_id, packets, rate from tmpDefinedTableHelp where gId = @gId and packets != 0; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            }
            else
            {
                cmd = new SqlCommand("insert into finalizedTableHelp (gId, supporter_id, name, family, fatherName, folder_id, packets, rate) select gId, supporter_id, name, family, fatherName, folder_id, packets, rate from tmpDefinedTableHelp where gId = @gId and packets != 0;", con);
            }
            cmd.Parameters.AddWithValue("@gId", this.id);
            cmd.ExecuteNonQuery();
            con.Close();
            this.res = true;
            if (this.pp == "ویرایش کمک جمعی")
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            this.Close();
        }

        private void globalHelpListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.res)
                this.Text = "fail";
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            // Display form modelessly
            var waitform = new waitForm();
            waitform.StartPosition = FormStartPosition.Manual;
            waitform.Show(this);

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string folde;
            for(int j = 0; j < memberDataGridView.SelectedCells.Count; j++)
            {
                folde = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                di2[folde] = di1[folde];
                di1.Remove(folde);
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into delDefinedTableHelp (gId, supporter_id, name, family, fatherName, folder_id, packets, rate) select gId, supporter_id, name, family, fatherName, folder_id, packets, rate from tmpDefinedTableHelp where folder_id = @fId and gId = @gId; delete from tmpDefinedTableHelp where folder_id = @fId and gId = @gId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@gId", this.id);
                cmdtransfer.Parameters.AddWithValue("@fId", folde);
                cmdtransfer.ExecuteNonQuery();
            }
            SqlCommand cmdupdate, cmd;
            SqlDataAdapter da; DataTable dt;
            if (di1.Count == 0)
            {
                foreach (var dd in di1)
                {
                    cmdupdate = new SqlCommand("update tmpDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                    cmdupdate.Parameters.AddWithValue("@gId", this.id);
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                    cmdupdate.ExecuteNonQuery();
                }
                foreach (var dd in di2)
                {
                    cmdupdate = new SqlCommand("update delDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                    cmdupdate.Parameters.AddWithValue("@gId", this.id);
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@packs", 0);
                    cmdupdate.ExecuteNonQuery();
                }
                
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from tmpDefinedTableHelp where gId = @gId order by rate desc;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from delDefinedTableHelp where gId = @gId order by rate desc;", con);
                cmd.Parameters.AddWithValue("@gId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                delDataGridView.DataSource = dt;
                con.Close();
                waitform.Close();
                return;
            }    
            decimal sum = 0; int consumep = 0;
            li.Clear();
            foreach (var dd in di1)
            {
                if(dd.Value.Item3 > 0)
                    sum += dd.Value.Item3;
            }
            //FMessegeBox.FarsiMessegeBox.Show("sum , pack " + sum.ToString() + "\n" + this.packs.ToString());
            foreach (var dd in di)
            {
                if (di1.ContainsKey(dd.Key))
                {
                    int p = Convert.ToInt32(Math.Floor(((dd.Value.Item3>0)? dd.Value.Item3 : 0) * this.packs / sum)); consumep += p;
                    //FMessegeBox.FarsiMessegeBox.Show(dd.Value.Item3.ToString() + "\n" + p.ToString() + "\n" + consumep.ToString());
                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                    if (dd.Value.Item3 > 0)
                        li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                }
            }
            arr = li.ToArray();
            arr.OrderBy((x => x.Key)).ToArray();
            int i = 0;
            //FMessegeBox.FarsiMessegeBox.Show("res: " + consumep.ToString() + "\n" + this.packs.ToString());
            while (consumep != this.packs)
            {
                //FMessegeBox.FarsiMessegeBox.Show("arr: " + arr[i].Value);
                di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                i++;
                consumep++;
            }
            foreach (var dd in di1)
            {
                cmdupdate = new SqlCommand("update tmpDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                cmdupdate.Parameters.AddWithValue("@gId", this.id);
                cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                cmdupdate.ExecuteNonQuery();
            }
            foreach (var dd in di2)
            {
                cmdupdate = new SqlCommand("update delDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                cmdupdate.Parameters.AddWithValue("@gId", this.id);
                cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                cmdupdate.Parameters.AddWithValue("@packs", 0);
                cmdupdate.ExecuteNonQuery();
            }
            
            cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from tmpDefinedTableHelp where gId = @gId order by rate desc;", con);
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from delDefinedTableHelp where gId = @gId order by rate desc;", con);
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            con.Close();
            waitform.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(this.type == "نان" && memberDataGridView.RowCount + delDataGridView.SelectedCells.Count > 1)
            {
                FMessegeBox.FarsiMessegeBox.Show("برای کمک نان تنها یک مددجو قابل انتخاب است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            // Display form modelessly
            var waitform = new waitForm();
            waitform.StartPosition = FormStartPosition.Manual;
            waitform.Show(this);

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string folde;
            for (int j = 0; j < delDataGridView.SelectedCells.Count; j++)
            {
                folde = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                di1[folde] = di2[folde];
                di2.Remove(folde);
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into tmpDefinedTableHelp (gId, supporter_id, name, family, fatherName, folder_id, packets, rate) select gId, supporter_id, name, family, fatherName, folder_id, packets, rate from delDefinedTableHelp where folder_id = @fId and gId = @gId; delete from delDefinedTableHelp where folder_id = @fId and gId = @gId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@gId", this.id);
                cmdtransfer.Parameters.AddWithValue("@fId", folde);
                cmdtransfer.ExecuteNonQuery();
            }
            decimal sum = 0; int consumep = 0;
            li.Clear();
            foreach (var dd in di1)
            {
                if(dd.Value.Item3 > 0)
                    sum += dd.Value.Item3;
            }
            foreach (var dd in di)
            {
                if (di1.ContainsKey(dd.Key))
                {
                    int p = Convert.ToInt32(Math.Floor(((dd.Value.Item3 > 0) ? dd.Value.Item3 : 0) * this.packs / sum)); consumep += p;
                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                    if(dd.Value.Item3 > 0)
                        li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                }
            }
            arr = li.ToArray();
            arr.OrderBy((x => x.Key)).ToArray();
            int i = 0;
            while (consumep != this.packs)
            {
                di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                i++;
                consumep++;
            }
            SqlCommand cmdupdate;
            foreach (var dd in di1)
            {
                cmdupdate = new SqlCommand("update tmpDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                cmdupdate.Parameters.AddWithValue("@gId", this.id);
                cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                cmdupdate.ExecuteNonQuery();
            }
            SqlCommand cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from tmpDefinedTableHelp where gId = @gId order by rate desc;", con);
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from delDefinedTableHelp where gId = @gId order by rate desc;", con);
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            con.Close();
            waitform.Close();
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

        private void globalHelpListForm_Load(object sender, EventArgs e)
        {
            addButton.Enabled = delButton.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetGhelp = new SqlCommand("select fee, packets, metric, type from GlobalHelps where id = @id", con);
            cmdgetGhelp.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdgetGhelp.ExecuteReader())
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
            if(this.pp == "ویرایش کمک جمعی")
            {
                SqlCommand cmdget = new SqlCommand("select supporter_id, folder_id, packets, rate from tmpDefinedTableHelp where gId = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using(SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                        di1[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                    }
                }
                cmdget = new SqlCommand("select supporter_id, folder_id, packets, rate from delDefinedTableHelp where gId = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), Convert.ToDecimal(reader.GetInt32(3)));
                        di2[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), Convert.ToDecimal(reader.GetInt32(3)));
                    }
                }
            }
            else
            {
                SqlCommand cmdgetfamilies = new SqlCommand("select id, folder_id, rate from member where id = supporter_id;", con);
                using (SqlDataReader reader = cmdgetfamilies.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), 0, Convert.ToDecimal(reader.GetInt32(2)));
                    }
                }
                if (di.Count == 0)
                {
                    FMessegeBox.FarsiMessegeBox.Show("خانواری وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                updaterate();
                decimal sum = 0; int consumep = 0;
                foreach (var dd in di)
                {
                    if(dd.Value.Item3 > 0)
                    {
                        sum += dd.Value.Item3;
                    }
                }
                foreach (var dd in di)
                {
                    //FMessegeBox.FarsiMessegeBox.Show(dd.Key + "\n" + dd.Value.Item1.ToString() + "\n" + dd.Value.Item2.ToString() + "\n" + dd.Value.Item3.ToString());
                    int p = Convert.ToInt32(Math.Floor(((dd.Value.Item3 > 0) ? dd.Value.Item3 : 0) * this.packs / sum)); consumep += p;
                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                    if (dd.Value.Item3 > 0)
                        li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                }
                arr = li.ToArray();
                arr.OrderBy((x => x.Key)).ToArray();
                
                int i = 0;
                /*foreach(var a in arr)
                {
                    FMessegeBox.FarsiMessegeBox.Show(a.Key + "\n" + a.Value);
                }*/
                while (consumep != this.packs)
                {
                    di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                    i++;
                    consumep++;
                }
                SqlCommand cmdgettmp;
                foreach (var dd in di1)
                {
                    cmdgettmp = new SqlCommand("insert into tmpDefinedTableHelp(gId, name, family, fatherName, supporter_id, folder_id, packets, rate) Values(@gId, @name, @family, @father, @sId, @fId, @packs, @rate);", con);
                    SqlCommand cmdgetdata = new SqlCommand("select name, family, fatherName from member where id = @id", con);
                    cmdgetdata.Parameters.AddWithValue("@id", dd.Value.Item1);
                    using(SqlDataReader reader = cmdgetdata.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdgettmp.Parameters.AddWithValue("@name", reader.GetString(0));
                            cmdgettmp.Parameters.AddWithValue("@family", reader.GetString(1));
                            cmdgettmp.Parameters.AddWithValue("@father", reader.GetString(2));
                        }
                    }
                    cmdgettmp.Parameters.AddWithValue("@gId", this.id);
                    cmdgettmp.Parameters.AddWithValue("@sId", dd.Value.Item1);
                    cmdgettmp.Parameters.AddWithValue("@fId", dd.Key);
                    cmdgettmp.Parameters.AddWithValue("@packs", dd.Value.Item2);
                    cmdgettmp.Parameters.AddWithValue("@rate", dd.Value.Item3);
                    cmdgettmp.ExecuteNonQuery();
                }
            }
            
            SqlCommand cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from tmpDefinedTableHelp where gId = @gId order by rate desc;", con);
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[memberDataGridView.ColumnCount-1].DefaultCellStyle.Format = "#,##;#,##-";
            cmd = new SqlCommand("select folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', packets as 'تعداد بسته', cast(rate as decimal(10,3)) as 'امتیاز' from delDefinedTableHelp where gId = @gId order by rate desc;", con);
            cmd.Parameters.AddWithValue("@gId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            delDataGridView.Columns[delDataGridView.ColumnCount - 1].DefaultCellStyle.Format = "#,##;#,##-";
            con.Close();
            if (this.pp == "ویرایش کمک جمعی")
            {
                memberDataGridView.SelectedCells[0].Selected = false;
                delButton.Enabled = true;
                delButton.PerformClick();
                delButton.Enabled = false;
            }
            else if(this.type == "نان")
            {
                for(int j = 0; j<memberDataGridView.RowCount; j++)
                {
                    memberDataGridView.Rows[j].Cells[0].Selected = true;
                }
                delButton.PerformClick();
            }
            
        }
    }
}
