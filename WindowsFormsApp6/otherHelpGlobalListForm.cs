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
    public partial class otherHelpGlobalListForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, ctype, pp;
        int packs;
        bool res = false;
        decimal fee, metric, packFee, packpoint;
        List<KeyValuePair<decimal, string>> li;
        Dictionary<string, Tuple<string, decimal, string>> di, di1, di2;
        KeyValuePair<decimal, string>[] arr;
        public otherHelpGlobalListForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            li = new List<KeyValuePair<decimal, string>>();
            di = new Dictionary<string, Tuple<string, decimal, string>>();
            di1 = new Dictionary<string, Tuple<string, decimal, string>>();
            di2 = new Dictionary<string, Tuple<string, decimal, string>>();
            if (p != "")
            {
                this.pp = p;
            }
        }

        private void otherHelpGlobalListForm_Load(object sender, EventArgs e)
        {
            addButton.Enabled = delButton.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetOhelp = new SqlCommand("select fee, packets, metric, ctype from OtherHelpsGlobal where id = @id", con);
            cmdgetOhelp.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetOhelp.ExecuteReader())
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
            if (this.pp == "ویرایش کمک متفرقه گروهی")
            {
                SqlCommand cmdget = new SqlCommand("select supporter_id, folder_id, rate, mId from OtherHelpsGlobalTmpList where hId = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (this.ctype == "همه خانوارها")
                        {
                            di[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(2), reader.GetString(3));
                            di1[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(2), reader.GetString(3));
                        }
                        else
                        {
                            di[reader.GetString(3)] = new Tuple<string, decimal, string>(reader.GetString(1), reader.GetDecimal(2), reader.GetString(0));
                            di1[reader.GetString(3)] = new Tuple<string, decimal, string>(reader.GetString(1), reader.GetDecimal(2), reader.GetString(0));
                        }
                    }
                }
                cmdget = new SqlCommand("select supporter_id, folder_id, packets, rate, mId from OtherHelpsGlobalDelList where hId = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (this.ctype == "همه خانوارها")
                        {
                            di[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(3), reader.GetString(4));
                            di2[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), reader.GetDecimal(3), reader.GetString(4));
                        }
                        else
                        {
                            di[reader.GetString(4)] = new Tuple<string, decimal, string>(reader.GetString(1), reader.GetDecimal(3), reader.GetString(0));
                            di2[reader.GetString(4)] = new Tuple<string, decimal, string>(reader.GetString(1), reader.GetDecimal(3), reader.GetString(0));
                        }
                    }
                }
            }
            else
            {
                SqlCommand cmdget = new SqlCommand("select id, folder_id, rate, supporter_id from member where id = supporter_id;", con);
                switch (this.ctype)
                {
                    case "ایتام":
                        cmdget = new SqlCommand("select id, folder_id, rate, supporter_id from member where orphan = N'بله';", con);
                        break;
                    case "دانش آموزان":
                        cmdget = new SqlCommand("select id, folder_id, rate, supporter_id from member where student = N'بله';", con);
                        break;
                    case "بیماران خاص":
                        cmdget = new SqlCommand("select id, folder_id, rate, supporter_id from member where health = N'بیمار خاص';", con);
                        break;
                    case "همه افراد":
                        cmdget = new SqlCommand("select id, folder_id, rate, supporter_id from member;", con);
                        break;
                    case "همه خانوارها":
                        break;
                }
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(this.ctype == "همه خانوارها")
                        {
                            di[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), Convert.ToDecimal(reader.GetInt32(2)), reader.GetString(3));
                            di1[reader.GetString(1)] = new Tuple<string, decimal, string>(reader.GetString(0), Convert.ToDecimal(reader.GetInt32(2)), reader.GetString(3));
                        }
                        else
                        {
                            di[reader.GetString(0)] = new Tuple<string, decimal, string>(reader.GetString(1), Convert.ToDecimal(reader.GetInt32(2)), reader.GetString(3));
                            di1[reader.GetString(0)] = new Tuple<string, decimal, string>(reader.GetString(1), Convert.ToDecimal(reader.GetInt32(2)), reader.GetString(3));
                        }
                    }
                }
                if (di.Count == 0)
                {
                    switch (this.ctype)
                    {
                        case "ایتام":
                            FMessegeBox.FarsiMessegeBox.Show("یتیمی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "دانش آموزان":
                            FMessegeBox.FarsiMessegeBox.Show("دانش آموزی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "بیماران خاص":
                            FMessegeBox.FarsiMessegeBox.Show("بیمار خاصی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "همه افراد":
                            FMessegeBox.FarsiMessegeBox.Show("مددجویی وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "همه خانوارها":
                            FMessegeBox.FarsiMessegeBox.Show("خانواری وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                    }
                    return;
                }
                
                SqlCommand cmdgettmp;
                foreach (var dd in di1)
                {
                    //FMessegeBox.FarsiMessegeBox.Show(dd.Key + " " + dd.Value.Item1 + " " + dd.Value.Item2.ToString() + " " + dd.Value.Item3);
                    cmdgettmp = new SqlCommand("insert into OtherHelpsGlobalTmpList(hId, name, family, fatherName, mId, supporter_id, folder_id, packets, rate) Values(@hId, @name, @family, @father, @mId, @sId, @fId, @packs, @rate);", con);
                    SqlCommand cmdgetdata = new SqlCommand("select name, family, fatherName from member where id = @id", con);
                    if (this.ctype == "همه خانوارها")
                    {
                        cmdgetdata.Parameters.AddWithValue("@id", dd.Value.Item3);
                    }
                    else
                    {
                        cmdgetdata.Parameters.AddWithValue("@id", dd.Key);
                    }
                    using (SqlDataReader reader = cmdgetdata.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdgettmp.Parameters.AddWithValue("@name", reader.GetString(0));
                            cmdgettmp.Parameters.AddWithValue("@family", reader.GetString(1));
                            cmdgettmp.Parameters.AddWithValue("@father", reader.GetString(2));
                        }
                    }
                    if(this.ctype == "همه خانوارها")
                    {
                        cmdgettmp.Parameters.AddWithValue("@sId", dd.Value.Item1);
                        cmdgettmp.Parameters.AddWithValue("@fId", dd.Key);
                        cmdgettmp.Parameters.AddWithValue("@mId", dd.Value.Item3);
                    }
                    else
                    {
                        cmdgettmp.Parameters.AddWithValue("@sId", dd.Value.Item3);
                        cmdgettmp.Parameters.AddWithValue("@fId", dd.Value.Item1);
                        cmdgettmp.Parameters.AddWithValue("@mId", dd.Key);
                    }
                    cmdgettmp.Parameters.AddWithValue("@hId", this.id);
                    cmdgettmp.Parameters.AddWithValue("@packs", 1);
                    cmdgettmp.Parameters.AddWithValue("@rate", dd.Value.Item2);
                    cmdgettmp.ExecuteNonQuery();
                }
            }
            
            
            SqlCommand cmd;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            delDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";

            if (this.pp == "ویرایش کمک متفرقه گروهی")
            {
                /*memberDataGridView.SelectedCells[0].Selected = false;
                delButton.Enabled = true;
                delButton.PerformClick();
                delButton.Enabled = false;*/
            }
            else
            {
                for (int j = 0; j < memberDataGridView.RowCount; j++)
                {
                    memberDataGridView.Rows[j].Cells[0].Selected = true;
                }
                //delButton.Enabled = true;
                delButton.PerformClick();
                //delButton.Enabled = false;
                if (this.ctype == "همه خانوارها")
                {
                    string mId, folde;
                    for(int j = 0; j<this.packs; j++)
                    {
                        mId = delDataGridView.Rows[j].Cells[4].Value.ToString();
                        folde = delDataGridView.Rows[j].Cells[0].Value.ToString();
                        di1[folde] = di2[folde];
                        di2.Remove(folde);
                    }
                    SqlCommand cmdgettmp = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalTmpList(hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, 1, rate from OtherHelpsGlobalDelList where hId = @hId and folder_id in (select top(@num) folder_id from OtherHelpsGlobalDelList where hId = @hId order by rate desc); delete from OtherHelpsGlobalDelList where folder_id in (select top(@num) folder_id from OtherHelpsGlobalDelList where hId = @hId order by rate desc); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmdgettmp.Parameters.AddWithValue("@hId", this.id);
                    cmdgettmp.Parameters.AddWithValue("@num", this.packs);
                    cmdgettmp.ExecuteNonQuery();
                    if (this.ctype == "همه خانوارها")
                    {
                        cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
                    }
                    cmd.Parameters.AddWithValue("@hId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    memberDataGridView.DataSource = dt;
                    memberDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
                    if (this.ctype == "همه خانوارها")
                    {
                        cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
                    }
                    cmd.Parameters.AddWithValue("@hId", this.id);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    delDataGridView.DataSource = dt;
                    delDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
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

        private void otherHelpGlobalListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.pp == "ویرایش کمک متفرقه گروهی" && !this.res)
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

        private void setButton_Click(object sender, EventArgs e)
        {
            if (memberDataGridView.Rows.Count < this.packs)
            {
                FMessegeBox.FarsiMessegeBox.Show("لیست تکمیل نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (memberDataGridView.Rows.Count > this.packs)
            {
                FMessegeBox.FarsiMessegeBox.Show("تعداد مددجویان لیست از تعداد بسته‌ها بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd;
            if (this.pp == "ویرایش کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalFinList where hId = @hId; insert into OtherHelpsGlobalFinList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalTmpList where hId = @hId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            }
            else
            {
                cmd = new SqlCommand("insert into OtherHelpsGlobalFinList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate from OtherHelpsGlobalTmpList where hId = @hId;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            cmd.ExecuteNonQuery();
            con.Close();
            this.res = true;
            if (this.pp == "ویرایش کمک متفرقه گروهی")
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            this.Close();
        }

        private void otherHelpGlobalListForm_FormClosed(object sender, FormClosedEventArgs e)
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
            string folde, mId;
            for (int j = 0; j < memberDataGridView.SelectedCells.Count; j++)
            {
                if(this.ctype == "همه خانوارها")
                {
                    mId = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex+4].Value.ToString();
                    folde = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                    di2[folde] = di1[folde];
                    di1.Remove(folde);
                }
                else
                {
                    mId = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                    folde = memberDataGridView.Rows[memberDataGridView.SelectedCells[j].RowIndex].Cells[memberDataGridView.SelectedCells[j].ColumnIndex + 4].Value.ToString();
                    di2[mId] = di1[mId];
                    di1.Remove(mId);
                }
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalDelList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, 0, rate from OtherHelpsGlobalTmpList where mId = @mId and folder_id = @fId and hId = @hId; delete from OtherHelpsGlobalTmpList where mId = @mId and folder_id = @fId and hId = @hId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.Parameters.AddWithValue("@mId", mId);
                cmdtransfer.Parameters.AddWithValue("@fId", folde);
                cmdtransfer.ExecuteNonQuery();
            }
            SqlCommand cmdupdate, cmd;
            SqlDataAdapter da; DataTable dt;
            if (di1.Count == 0)
            {
                foreach (var dd in di1)
                {
                    cmdupdate = new SqlCommand("update OtherHelpsGlobalTmpList Set packets = @packs where folder_id = @fId and hId = @hId;", con);
                    cmdupdate.Parameters.AddWithValue("@hId", this.id);
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                    cmdupdate.ExecuteNonQuery();
                }
                foreach (var dd in di2)
                {
                    cmdupdate = new SqlCommand("update OtherHelpsGlobalDelList Set packets = @packs where folder_id = @fId and hId = @hId;", con);
                    cmdupdate.Parameters.AddWithValue("@hId", this.id);
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@packs", 0);
                    cmdupdate.ExecuteNonQuery();
                }

                if (this.ctype == "همه خانوارها")
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
                }
                else
                {
                    cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
                }
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                memberDataGridView.DataSource = dt;
                if (this.ctype == "همه خانوارها")
                {
                    cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
                }
                else
                {
                    cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
                }
                cmd.Parameters.AddWithValue("@hId", this.id);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                delDataGridView.DataSource = dt;
                con.Close();
                waitform.Close();
                return;
            }
            foreach (var dd in di1)
            {
                cmdupdate = new SqlCommand("update OtherHelpsGlobalTmpList Set packets = @packs where mId = @mId and folder_id = @fId and hId = @hId;", con);
                cmdupdate.Parameters.AddWithValue("@hId", this.id);
                if (this.ctype == "همه خانوارها")
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Value.Item3);
                }
                else
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Value.Item1);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Key);
                }
                cmdupdate.Parameters.AddWithValue("@packs", 1);
                cmdupdate.ExecuteNonQuery();
            }
            foreach (var dd in di2)
            {
                cmdupdate = new SqlCommand("update OtherHelpsGlobalDelList Set packets = @packs where mId = @mId and folder_id = @fId and hId = @hId;", con);
                cmdupdate.Parameters.AddWithValue("@hId", this.id);
                if (this.ctype == "همه خانوارها")
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Value.Item3);
                }
                else
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Value.Item1);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Key);
                }
                cmdupdate.Parameters.AddWithValue("@packs", 0);
                cmdupdate.ExecuteNonQuery();
            }
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            delDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
            con.Close();
            waitform.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(memberDataGridView.RowCount + delDataGridView.SelectedCells.Count > this.packs)
            {
                FMessegeBox.FarsiMessegeBox.Show("مجموع تعداد افراد انتخاب شده از تعداد بسته‌های تعریف شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
            string folde, mId;
            for (int j = 0; j < delDataGridView.SelectedCells.Count; j++)
            {
                if (this.ctype == "همه خانوارها")
                {
                    mId = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex + 4].Value.ToString();
                    folde = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                    di1[folde] = di2[folde];
                    di2.Remove(folde);
                }
                else
                {
                    //FMessegeBox.FarsiMessegeBox.Show(delDataGridView.ColumnCount.ToString() + " " + delDataGridView.SelectedCells[0].RowIndex + " " + delDataGridView.SelectedCells[0].ColumnIndex);
                    mId = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex].Value.ToString();
                    folde = delDataGridView.Rows[delDataGridView.SelectedCells[j].RowIndex].Cells[delDataGridView.SelectedCells[j].ColumnIndex + 4].Value.ToString();
                    di1[mId] = di2[mId];
                    di2.Remove(mId);
                }
                SqlCommand cmdtransfer = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobalTmpList (hId, supporter_id, folder_id, name, family, fatherName, mId, packets, rate) select hId, supporter_id, folder_id, name, family, fatherName, mId, 1, rate from OtherHelpsGlobalDelList where mId = @mId and folder_id = @fId and hId = @hId; delete from OtherHelpsGlobalDelList where mid = @mId and folder_id = @fId and hId = @hId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdtransfer.Parameters.AddWithValue("@hId", this.id);
                cmdtransfer.Parameters.AddWithValue("@fId", folde);
                cmdtransfer.Parameters.AddWithValue("@mId", mId);
                cmdtransfer.ExecuteNonQuery();
            }
            SqlCommand cmdupdate;
            foreach (var dd in di1)
            {
                cmdupdate = new SqlCommand("update OtherHelpsGlobalTmpList Set packets = @packs where mId = @mId and folder_id = @fId and hId = @hId;", con);
                cmdupdate.Parameters.AddWithValue("@hId", this.id);
                if (this.ctype == "همه خانوارها")
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Value.Item3);
                }
                else
                {
                    cmdupdate.Parameters.AddWithValue("@fId", dd.Value.Item1);
                    cmdupdate.Parameters.AddWithValue("@mId", dd.Key);
                }
                cmdupdate.Parameters.AddWithValue("@packs", 1);
                cmdupdate.ExecuteNonQuery();
            }
            SqlCommand cmd;
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalTmpList where hId = @hId order by rate desc;", con);
            }
            SqlDataAdapter da; DataTable dt;
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            memberDataGridView.DataSource = dt;
            memberDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
            if (this.ctype == "همه خانوارها")
            {
                cmd = new SqlCommand("select folder_id as 'شماره پرونده', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', mId as 'شماره ملی', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            else
            {
                cmd = new SqlCommand("select mId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', cast(rate as decimal(10,3)) as 'امتیاز' from OtherHelpsGlobalDelList where hId = @hId order by rate desc;", con);
            }
            cmd.Parameters.AddWithValue("@hId", this.id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            delDataGridView.DataSource = dt;
            delDataGridView.Columns[6].DefaultCellStyle.Format = "#,##;#,##-";
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
    }
}
