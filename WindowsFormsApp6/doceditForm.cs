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
    public partial class doceditForm : Form
    {
        string id, type, fold, deltype;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string applicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\applicant";
        string otherApplicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\otherApplicant";
        string sendingLettersPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\sendingLetters";
        string receivedLettersPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\receivedLetters";
        DateTime ddate;
        List<string> li;
        string[] arr;
        public doceditForm(string p, string id, string type, string name="", string family="", string fold="", string ddate="", string deltype="")
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
            this.type = type;
            this.fold = fold;
            idTextbox.Text = id;
            nameTextbox.Text = name;
            familyTextbox.Text = family;
            if(name == "")
            {
                if(this.Text == "ویرایش معرفی‌نامه")
                {
                    label5.Text = "شماره تقاضا";
                }
                else if(this.Text == "ویرایش پیوست‌ها")
                {
                    label5.Text = "شماره نامه";
                }
                else
                {
                    label5.Text = "شماره کمک";
                }
                label1.Visible = label2.Visible = nameTextbox.Visible = familyTextbox.Visible = false;
                if(type == "MRhelp:marryDoc" || type == "HRhelp:healDoc" || type == "OIRhelp:otherDoc")
                {
                    deleteButton.Visible = addButton.Visible = false;
                }
            }
            if (ddate != "")
                this.ddate = Convert.ToDateTime(ddate).Date;
            if (deltype != "")
                this.deltype = deltype;
            li = new List<string>();
        }

        private void docdataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 2)
            {
                docdataGridViewX.ClearSelection();
            }
        }

        private void docdataGridViewX_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            docdataGridViewX.ClearSelection();
        }

        private void visitButton_Click(object sender, EventArgs e)
        {
            string dpath = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex+2].Value.ToString();
            System.Diagnostics.Process.Start(dpath);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if ((this.Text == "ویرایش فرم تقاضا" || this.Text == "ویرایش فرم ورود") && docdataGridViewX.Rows.Count > 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("فرم موجود می باشد! در صورت تمایل به ویرایش آن ابتدا باید فرم قبلی را حذف نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            switch (this.type)
            {
                case "auth":
                    addOpenFileDialog.Title = "انتخاب مدارک شناسایی";
                    break;
                case "other":
                    addOpenFileDialog.Title = "انتخاب مدارک متفرقه";
                    break;
                case "orphan":
                    addOpenFileDialog.Title = "انتخاب مدارک یتیمی";
                    break;
                case "student":
                    addOpenFileDialog.Title = "انتخاب مدارک دانش‌آموزی";
                    break;
                case "house":
                    addOpenFileDialog.Title = "انتخاب مدارک استیجار";
                    break;
                case "health":
                    addOpenFileDialog.Title = "انتخاب مدارک بیماری";
                    break;
                case "marry":
                    addOpenFileDialog.Title = "انتخاب مدارک " + this.Text.Substring(13);
                    break;
                case "deletion":
                    addOpenFileDialog.Title = "انتخاب مدارک حذف";
                    break;
                case "CB":
                    addOpenFileDialog.Title = "انتخاب مدارک رجعت";
                    break;
                case "req":
                    addOpenFileDialog.Title = "انتخاب فرم تقاضا";
                    break;
                case "facilities:intro":
                    addOpenFileDialog.Title = "انتخاب معرفی‌نامه";
                    break;
                case "Ghelp":
                    addOpenFileDialog.Title = "انتخاب فایل ارائه کمک جمعی";
                    break;
                case "Shelp":
                    addOpenFileDialog.Title = "انتخاب فایل ارائه کمک تحصیلی";
                    break;
                case "OGhelp":
                    addOpenFileDialog.Title = "انتخاب فایل ارائه کمک متفرقه گروهی";
                    break;
                case "»LetterAttachment":
                    addOpenFileDialog.Title = "انتخاب فایل پیوست";
                    break;
            }
            
            addOpenFileDialog.FileName = "*.pdf";
            if(this.Text == "ویرایش فرم تقاضا" || this.Text == "ویرایش فرم ورود")
            {
                addOpenFileDialog.Multiselect = false;
            }
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                if (this.Text == "ویرایش فرم تقاضا")
                {
                    string fileName = System.IO.Path.GetFileName(addOpenFileDialog.FileName);
                    string targetPath = this.applicantPath + "\\" + idTextbox.Text + "\\" + this.type + "\\enter";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);    
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    docdataGridViewX.DataSource = dt;
                    docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
                }
                else if (this.Text == "ویرایش فرم ورود")
                {
                    string fileName = System.IO.Path.GetFileName(addOpenFileDialog.FileName);
                    string targetPath = this.defaultPath + "\\" + idTextbox.Text + "\\" + this.type;
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    docdataGridViewX.DataSource = dt;
                    docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
                }
                else if (this.Text == "ویرایش معرفی‌نامه")
                {
                    foreach (var d in addOpenFileDialog.FileNames)
                    {
                        string fileName = System.IO.Path.GetFileName(d);
                        string targetPath, destFile;
                        if (this.fold != "")
                        {
                            foreach (var ch in arr)
                            {
                                targetPath = this.defaultPath + "\\" + this.fold + "\\" + ch + "\\req\\facilities\\" + idTextbox.Text + "\\intro";
                                destFile = System.IO.Path.Combine(targetPath, fileName);
                                string dd = DateTime.Now.Date.ToPersian();
                                if (System.IO.File.Exists(destFile))
                                {
                                    destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2) + ".pdf");
                                }
                                System.IO.File.Copy(d, destFile, false);
                                cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con);
                                cmd.Parameters.AddWithValue("@id", ch);
                                cmd.Parameters.AddWithValue("@dname", fileName);
                                cmd.Parameters.AddWithValue("@dpath", destFile);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@dtype", this.type);
                                cmd.Parameters.AddWithValue("@resId", this.id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            targetPath = this.otherApplicantPath + "\\" + arr[0] + "\\req\\facilities\\" + idTextbox.Text + "\\intro\\";
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            string dd = DateTime.Now.Date.ToPersian();
                            if (System.IO.File.Exists(destFile))
                            {
                                destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2) + ".pdf");
                            }
                            System.IO.File.Copy(d, destFile, false);
                            cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con);
                            cmd.Parameters.AddWithValue("@id", arr[0]);
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@dtype", this.type);
                            cmd.Parameters.AddWithValue("@resId", this.id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where researchId = @id and doctype = @dtype and id = @sup;", con);
                    cmd.Parameters.AddWithValue("@sup", arr[0]);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    docdataGridViewX.DataSource = dt;
                    docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
                }
                else
                {
                    foreach (var d in addOpenFileDialog.FileNames)
                    {
                        string fileName = System.IO.Path.GetFileName(d);
                        string targetPath;
                        if (this.Text == "ویرایش فایل‌های ارائه کمک جمعی" || this.Text == "ویرایش فایل‌های ارائه کمک تحصیلی" || this.Text == "ویرایش فایل‌های ارائه کمک متفرقه گروهی")
                        {
                            targetPath = this.helpPath + "\\" + this.id + "\\";
                        }
                        else if(this.Text == "ویرایش پیوست‌ها")
                        {
                            string iddir;
                            if(this.id[0] == 'R')
                            {
                                iddir = this.sendingLettersPath + "\\" + this.id;
                            }
                            else
                            {
                                iddir = this.receivedLettersPath + "\\" + this.id;
                            }
                            targetPath = iddir + "\\" + "attachments";
                            if (!System.IO.Directory.Exists(targetPath))
                            {
                                System.IO.Directory.CreateDirectory(targetPath);
                            }
                        }
                        else
                        {
                            targetPath = this.defaultPath + "\\" + this.fold + "\\" + idTextbox.Text + "\\" + this.type + "\\";
                        }
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        string dd = DateTime.Now.Date.ToPersian();
                        if (System.IO.File.Exists(destFile))
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2) + ".pdf");
                        }

                        System.IO.File.Copy(d, destFile, false);
                        cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                        cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@dpath", destFile);
                        if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                        {
                            cmd.Parameters.AddWithValue("@subdate", this.ddate);
                        }
                        else
                            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@dtype", this.type);
                        cmd.ExecuteNonQuery();
                        if (deltype == "ویرایش حذف پوشش خانوار")
                        {
                            foreach (var ch in arr)
                            {
                                targetPath = this.defaultPath + "\\" + this.fold + "\\" + ch + "\\" + this.type;
                                destFile = System.IO.Path.Combine(targetPath, fileName);
                                dd = DateTime.Now.Date.ToPersian();
                                if (System.IO.File.Exists(destFile))
                                {
                                    destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2) + ".pdf");
                                }
                                System.IO.File.Copy(d, destFile, false);

                                cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                                cmd.Parameters.AddWithValue("@id", ch);
                                cmd.Parameters.AddWithValue("@dname", fileName);
                                cmd.Parameters.AddWithValue("@dpath", destFile);
                                cmd.Parameters.AddWithValue("@subdate", this.ddate);
                                cmd.Parameters.AddWithValue("@dtype", this.type);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                    {
                        cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype and subdate = @ddate;", con);
                        cmd.Parameters.AddWithValue("@ddate", this.ddate);
                    }
                    else
                        cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    docdataGridViewX.DataSource = dt;
                    docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
                    if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                        docdataGridViewX.Columns[2].Visible = false;
                }
                con.Close();
            }
            else
            {
                addOpenFileDialog.FileName = "*.pdf";
            }
            if (this.Text == "ویرایش فرم تقاضا" || this.Text == "ویرایش فرم ورود")
            {
                addOpenFileDialog.Multiselect = true;
            }
        }

        private void doceditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Text = docdataGridViewX.Rows.Count.ToString();
        }

        private void docdataGridViewX_SelectionChanged(object sender, EventArgs e)
        {
            visitButton.Enabled = deleteButton.Enabled = (docdataGridViewX.SelectedCells.Count!=0);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به حذف فایل مطمئن هستید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
                return;
            SqlDataAdapter da; DataTable dt;
            string i = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex - 1].Value.ToString();
            string dpath = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex + 2].Value.ToString();
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmd;
            con.Open();
            if(this.Text == "ویرایش معرفی‌نامه")
            {
                if(this.fold != "")
                {
                    foreach (var ch in arr)
                    {
                        string fileName = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex].Value.ToString();
                        string targetPath = this.defaultPath + "\\" + this.fold + "\\" + ch + "\\req\\facilities\\" + idTextbox.Text + "\\intro";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Delete(destFile);

                        cmd = new SqlCommand("delete from doc where docname = @dname and doctype = @dtype and docpath = @dpath and id = @id", con);
                        cmd.Parameters.AddWithValue("@id", ch);
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@dpath", docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@dtype", this.type);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string fileName = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex].Value.ToString();
                    string targetPath = this.otherApplicantPath + "\\" + arr[0] + "\\req\\facilities\\" + idTextbox.Text + "\\intro";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Delete(destFile);
                    cmd = new SqlCommand("delete from doc where docname = @dname and doctype = @dtype and docpath = @dpath and id = @id", con);
                    cmd.Parameters.AddWithValue("@id", arr[0]);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@dtype", this.type);
                    cmd.ExecuteNonQuery();
                }

                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where researchId = @id and doctype = @dtype and id = @sup;", con);
                cmd.Parameters.AddWithValue("@sup", arr[0]);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@dtype", this.type);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                docdataGridViewX.DataSource = dt;
                docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
            }
            else
            {
                cmd = new SqlCommand("delete from doc where i = @i", con);
                cmd.Parameters.AddWithValue("@i", i);
                cmd.ExecuteNonQuery();

                System.IO.File.Delete(dpath);

                if (deltype == "ویرایش حذف پوشش خانوار")
                {
                    foreach (var ch in arr)
                    {
                        string fileName = docdataGridViewX.Rows[docdataGridViewX.SelectedCells[0].RowIndex].Cells[docdataGridViewX.SelectedCells[0].ColumnIndex].Value.ToString();
                        string targetPath = this.defaultPath + "\\" + this.fold + "\\" + ch + "\\" + this.type;
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Delete(destFile);

                        cmd = new SqlCommand("delete from doc where docname = @dname and subdate = @ddate and doctype = @dtype and id = @id", con);
                        cmd.Parameters.AddWithValue("@id", ch);
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@ddate", this.ddate);
                        cmd.Parameters.AddWithValue("@dtype", this.type);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                {
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype and subdate = @ddate;", con);
                    cmd.Parameters.AddWithValue("@ddate", this.ddate);
                }
                else
                    cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@dtype", this.type);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                docdataGridViewX.DataSource = dt;
                docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
                if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                    docdataGridViewX.Columns[2].Visible = false;
            }
            
            con.Close();
        }

        private void doceditForm_Load(object sender, EventArgs e)
        {
            visitButton.Enabled = deleteButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            if (deltype == "ویرایش حذف پوشش خانوار" || this.Text == "ویرایش معرفی‌نامه")
            {
                SqlCommand cmdgetid;
                if (this.Text == "ویرایش معرفی‌نامه")
                {
                    cmdgetid = new SqlCommand("select applicantId from request where id = @sup", con1);
                }
                else
                {
                    cmdgetid = new SqlCommand("select id from abandoned where supporter_id = @sup and id != @sup and abandoneddate = @ddate", con1);
                    cmdgetid.Parameters.AddWithValue("@ddate", this.ddate);
                }
                cmdgetid.Parameters.AddWithValue("@sup", this.id);

                using (SqlDataReader reader = cmdgetid.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        li.Add(reader.GetString(0));
                    }
                    arr = li.ToArray();
                }
            }
            if (this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype and subdate = @ddate;", con1);
                cmd.Parameters.AddWithValue("@ddate", this.ddate);
            }
            else if(this.Text == "ویرایش معرفی‌نامه")
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where researchId = @id and doctype = @dtype and id = @sup;", con1);
                cmd.Parameters.AddWithValue("@sup", arr[0]);
            }
            else
            {
                cmd = new SqlCommand("select i, docname as 'نام مدرک', dbo.MiladiTOShamsi(subdate) as 'تاریخ افزودن مدرک', docpath from doc where id = @id and doctype = @dtype;", con1);
            }
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@dtype", this.type);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            docdataGridViewX.DataSource = dt;
            docdataGridViewX.Columns[0].Visible = docdataGridViewX.Columns[3].Visible = false;
            if(this.Text == "ویرایش مدارک حذف" || this.Text == "ویرایش مدارک رجعت")
                docdataGridViewX.Columns[2].Visible = false;

            con1.Close();
        }

    }
}
