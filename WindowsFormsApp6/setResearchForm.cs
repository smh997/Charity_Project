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
    public partial class setResearchForm : Form
    {
        string id;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string applicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\applicant";
        string fold="", resId, profile, type;
        List<string> doc;
        public setResearchForm(string p, string id, string type)
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
            this.type = type;
            doc = new List<string>();
            profile = "";
        }

        private void setResearchForm_Load(object sender, EventArgs e)
        {
            if(this.type == "enter")
            {
                enterRadioButton.Checked = true;
                typeGroupBox.Enabled = false;
            }
            else if (this.type == "CB")
            {
                comebackRadioButton.Checked = true;
                typeGroupBox.Enabled = false;
            }
            else
            {
                comebackRadioButton.Enabled = enterRadioButton.Enabled = false;
            }
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            
            if (this.Text == "ثبت تحقیق خانواری")
            {
                if(this.type == "enter")
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from applicant where supporter_id = @sup", con1);
                else if(this.type == "CB")
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned where supporter_id = @sup", con1);
                else
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member where supporter_id = @sup", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else
            {
                if (this.type == "enter")
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from applicant where id = @sup", con1);
                else if (this.type == "CB")
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned where id = @sup", con1);
                else
                    cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member where id = @sup", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            if (this.type != "enter")
            {
                this.fold = membersView.Rows[0].Cells["شماره پرونده"].Value.ToString();
                SqlCommand cmdgetprofile = new SqlCommand("select docpath from doc where id = @id and doctype = 'profile';", con1);
                cmdgetprofile.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdgetprofile.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.profile = String.Format("{0}", reader["docpath"]);
                    }
                }
                if (this.profile == "")
                    profilePictureBox.Image = WindowsFormsApp6.Properties.Resources.profile;
                else
                    profilePictureBox.ImageLocation = this.profile;
            }
            con1.Close();
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب مدارک تحقیق";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var d in addOpenFileDialog.FileNames)
                {
                    doc.Add(@d);
                }
                docLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                doc.Clear();
                addOpenFileDialog.FileName = "*.pdf";
                docLabel.BackColor = Color.Red;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            string typ = "", desc = "";
            foreach(RadioButton t in typeGroupBox.Controls)
            {
                if (t.Checked)
                {
                    typ = t.Text;
                    break;
                }
            }
            if(typ == "")
            {
                FMessegeBox.FarsiMessegeBox.Show("نوعی برای تحقیق انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ مدرکی برای تحقیق انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            foreach (CheckBox t in groupBox1.Controls)
            {
                if (t.Checked)
                {
                    if (desc != "")
                    {
                        desc += " و " + t.Text;
                    }
                    else
                    {
                        desc += t.Text;
                    }
                }
            }

            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();

            string d = researchdateTimePickerX.SelectedDateInDateTime.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
            SqlCommand cmdgetfolder = new SqlCommand("select id from research where id like '" + d + "%';", con1);
            string index = "1";
            using (SqlDataReader reader = cmdgetfolder.ExecuteReader())
            {
                if (reader.Read())
                {
                    string s = String.Format("{0}", reader["id"]);
                    if (s == "") index = "1";
                    else index = (s[s.Length - 1] - '0' + 1).ToString();
                }
            }
            this.resId = d + index;
            SqlCommand cmd;
            if (this.Text == "ثبت تحقیق خانواری")
            {
                List<string> li = new List<string>();
                string[] arr;
                SqlCommand cmdchild;
                if (this.type == "enter")
                    cmdchild = new SqlCommand("select id from applicant where supporter_id = @sup", con1);
                else if(this.type == "CB")
                    cmdchild = new SqlCommand("select id from abandoned where supporter_id = @sup", con1);
                else
                    cmdchild = new SqlCommand("select id from member where supporter_id = @sup", con1);
                cmdchild.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdchild.ExecuteReader())
                {

                    while (reader.Read())
                        li.Add(reader.GetString(0));
                    arr = li.ToArray();
                }
                SqlCommand cmddoc, cmdupexp, cmdgetexp;
                foreach (var i in arr)
                {
                    cmd = new SqlCommand("insert into research(id, memberId, subdate, rdate, rtype, status, description) Values (@id, @memId, @subdate, @rdate, @rtype, @status, @desc);", con1);
                    cmd.Parameters.AddWithValue("@id", this.resId);
                    cmd.Parameters.AddWithValue("@memId", i);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@rdate", researchdateTimePickerX.SelectedDateInDateTime.Date);
                    cmd.Parameters.AddWithValue("@rtype", typ);
                    cmd.Parameters.AddWithValue("@status", "خانواری");
                    if(this.type == "enter")
                        cmd.Parameters.AddWithValue("@desc", DescriptionTextBox.Text + "(ثحقیق " + typ + " با سرپرستی به شماره ملی: " + this.id + " شامل موارد " + desc + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    else
                        cmd.Parameters.AddWithValue("@desc", DescriptionTextBox.Text + "(ثحقیق " + typ + " خانوار به شماره پرونده " + this.fold + " با سرپرستی به شماره ملی: " + this.id + " شامل موارد " + desc + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    cmd.ExecuteNonQuery();
                    if(this.type == "enter")
                    {
                        cmdgetexp = new SqlCommand("select explain from applicant where id = @i", con1);
                        cmdupexp = new SqlCommand("update applicant Set explain = @exp", con1);
                    }
                    else if(this.type == "CB")
                    {
                        cmdgetexp = new SqlCommand("select explain from abandoned where id = @i", con1);
                        cmdupexp = new SqlCommand("update abandoned Set explain = @exp", con1);
                    }
                    else
                    {
                        cmdgetexp = new SqlCommand("select explain from member where id = @i", con1);
                        cmdupexp = new SqlCommand("update member Set explain = @exp", con1);
                    }
                    cmdgetexp.Parameters.AddWithValue("@i", i);
                    using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                    {
                        cmdupexp.Parameters.AddWithValue("@exp", String.Format("{0}", reader["explain"]) + "(ثحقیق " + typ + " به شماره " + this.resId + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    }
                    cmdupexp.ExecuteNonQuery();
                    if(this.type == "enter")
                        System.IO.Directory.CreateDirectory(applicantPath + "\\" + this.id + "\\research\\" + resId);
                    else
                        System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + i + "\\research\\" + this.resId);
                    foreach (var fm in doc)
                    {
                        string fileName = System.IO.Path.GetFileName(fm);
                        string targetPath = "";
                        if (this.type == "enter")
                            targetPath = applicantPath + "\\" + this.id + "\\research\\" + resId + "\\";
                        else
                            targetPath = defaultPath + "\\" + this.fold + "\\" + i + "\\research\\"+this.resId+"\\";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(fm, destFile, false);
                        cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con1);
                        cmddoc.Parameters.AddWithValue("@id", i);
                        cmddoc.Parameters.AddWithValue("@dname", fileName);
                        cmddoc.Parameters.AddWithValue("@dpath", destFile);
                        cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmddoc.Parameters.AddWithValue("@dtype", "research");
                        cmddoc.Parameters.AddWithValue("@resId", this.resId);
                        cmddoc.ExecuteNonQuery();
                    }
                }
                FMessegeBox.FarsiMessegeBox.Show("تحقیق درمورد خانوار با موفقیت ثبت شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con1.Close();
                this.Close();
            }
            else
            {
                cmd = new SqlCommand("insert into research(id, memberId, subdate, rdate, rtype, status, description) Values (@id, @memId, @subdate, @rdate, @rtype, @status, @desc);", con1);
                cmd.Parameters.AddWithValue("@id", this.resId);
                cmd.Parameters.AddWithValue("@memId", this.id);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@rdate", researchdateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@rtype", typ);
                cmd.Parameters.AddWithValue("@status", "فردی");
                if(this.type == "enter")
                    cmd.Parameters.AddWithValue("@desc", DescriptionTextBox.Text + "(ثحقیق " + typ + " فردی " + " با شماره ملی: " + this.id + " شامل موارد " + desc + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                else
                    cmd.Parameters.AddWithValue("@desc", DescriptionTextBox.Text + "(ثحقیق " + typ + " فردی به شماره پرونده " + this.fold + " با شماره ملی: " + this.id + " شامل موارد " + desc + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                cmd.ExecuteNonQuery();
                SqlCommand cmddoc, cmdupexp, cmdgetexp;
                if (this.type == "enter")
                {
                    cmdgetexp = new SqlCommand("select explain from applicant where id = @i", con1);
                    cmdupexp = new SqlCommand("update applicant Set explain = @exp", con1);
                }
                else if (this.type == "CB")
                {
                    cmdgetexp = new SqlCommand("select explain from abandoned where id = @i", con1);
                    cmdupexp = new SqlCommand("update abandoned Set explain = @exp", con1);
                }
                else
                {
                    cmdgetexp = new SqlCommand("select explain from member where id = @i", con1);
                    cmdupexp = new SqlCommand("update member Set explain = @exp", con1);
                }
                cmdgetexp.Parameters.AddWithValue("@i", this.id);
                using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                {
                    if(reader.Read())
                        cmdupexp.Parameters.AddWithValue("@exp", String.Format("{0}", reader["explain"]) + "(ثحقیق " + typ + " به شماره "+ this.resId + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                }
                cmdupexp.ExecuteNonQuery();
                if (this.type == "enter")
                    System.IO.Directory.CreateDirectory(applicantPath + "\\" + this.id + "\\research\\" + resId);
                else
                    System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + this.id + "\\research\\" + this.resId);
                foreach (var fm in doc)
                {
                    string fileName = System.IO.Path.GetFileName(fm);
                    string targetPath = "";
                    if (this.type == "enter")
                        targetPath = applicantPath + "\\" + this.id + "\\research\\" + resId + "\\";
                    else
                        targetPath = defaultPath + "\\" + this.fold + "\\" + this.id + "\\research\\" + this.resId + "\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(fm, destFile, false);
                    cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con1);
                    cmddoc.Parameters.AddWithValue("@id", this.id);
                    cmddoc.Parameters.AddWithValue("@dname", fileName);
                    cmddoc.Parameters.AddWithValue("@dpath", destFile);
                    cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmddoc.Parameters.AddWithValue("@dtype", "research");
                    cmddoc.Parameters.AddWithValue("@resId", this.resId);
                    cmddoc.ExecuteNonQuery();
                }
                
                FMessegeBox.FarsiMessegeBox.Show("تحقیق در مورد فرد با موفقیت ثبت شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con1.Close();
                this.Close();
            }
        }
    }
}
