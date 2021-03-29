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
    public partial class healHelpReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, mId, reqdoc;
        List<string> healDocs;
        bool res = false;
        public healHelpReqForm(string mId, string p = "", string id = "")
        {
            InitializeComponent();
            this.mId = mId;
            healDocs = new List<string>();
            if (id != "")
            {
                this.id = id;
            }
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void healHelpReqForm_Load(object sender, EventArgs e)
        {
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
            if (this.Text == "ثبت درخواست کمک درمان")
            {
                idTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
            }
            else
            {
                this.BackColor = Color.Yellow; delButton.Visible = true;
                healDocLabel.BackColor = reqLabel.BackColor = Color.YellowGreen;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdget = new SqlCommand("select mId, reqdate, description from HealHelpReq where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idTextbox.Text = reader.GetString(0);
                        reqDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["reqdate"])).Date;
                        explainTextBox.Text = reader.GetString(2);
                    }
                }
                con.Close();
            }
        }
        private void reqDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (reqDateTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                reqDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void reqAddFileButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ثبت درخواست کمک درمان")
            {
                addOpenFileDialog.Title = "انتخاب فرم درخواست";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    reqdoc = addOpenFileDialog.FileName;
                    reqLabel.BackColor = Color.YellowGreen;
                }
                else
                {
                    reqdoc = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    reqLabel.BackColor = Color.Red;
                }
            }
            else
            {
                addOpenFileDialog.Title = "انتخاب فرم درخواست";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    reqdoc = addOpenFileDialog.FileName;
                    reqLabel.BackColor = Color.GreenYellow;
                }
                else
                {
                    reqdoc = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    reqLabel.BackColor = Color.YellowGreen;
                }
            }
        }

        private void healDocButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ثبت درخواست کمک درمان")
            {
                addOpenFileDialog.Multiselect = true;
                addOpenFileDialog.Title = "انتخاب مدارک درمان";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    healDocs.Clear();
                    foreach (var doc in addOpenFileDialog.FileNames)
                    {
                        healDocs.Add(doc);
                    }
                    healDocLabel.BackColor = Color.YellowGreen;
                }
                else
                {
                    healDocs.Clear();
                    addOpenFileDialog.FileName = "*.pdf";
                    healDocLabel.BackColor = Color.Red;
                }
                addOpenFileDialog.Multiselect = false;
            }
            else
            {
                addOpenFileDialog.Multiselect = true;
                addOpenFileDialog.Title = "انتخاب مدارک درمان";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    healDocs.Clear();
                    foreach (var doc in addOpenFileDialog.FileNames)
                    {
                        healDocs.Add(doc);
                    }
                    healDocLabel.BackColor = Color.GreenYellow;
                }
                else
                {
                    healDocs.Clear();
                    addOpenFileDialog.FileName = "*.pdf";
                    healDocLabel.BackColor = Color.YellowGreen;
                }
                addOpenFileDialog.Multiselect = false;
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            res = true;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            System.IO.Directory.Delete(this.helpPath + "\\" + this.id, true);
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from doc where id = @id; delete from HealHelpReq where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (reqLabel.BackColor == Color.Red || healDocLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("مدارک لازم بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            res = true;
            if (this.Text == "ثبت درخواست کمک درمان")
            {
                string d = DateTime.Now.Date.ToPersian(); d = "HR" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                SqlCommand cmdget = new SqlCommand("select id from HealHelpReq where id like '" + d + "%';", con);
                int index = 1, mx = 1;
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string s = String.Format("{0}", reader["id"]);
                        if (s == "") index = 1;
                        else index = Convert.ToInt32(s.Substring(10)) + 1;
                        mx = Math.Max(mx, index);
                    }
                }
                d = d + mx.ToString();
                this.id = d;
                System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id);
                System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id + "\\req\\");
                string fileName = System.IO.Path.GetFileName(reqdoc);
                string targetPath = this.helpPath + "\\" + this.id + "\\req\\";
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into HealHelpReq (id, mId, subdate, reqdate, description, status) Values (@id, @mId, @subdate, @rdate, @des, @stat); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@mId", this.mId);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@rdate", reqDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@des", "(توضیحات درخواست: " + explainTextBox.Text + ")");
                cmd.Parameters.AddWithValue("@stat", "ثبت شده");
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "HRhelp:reqForm");
                cmd.ExecuteNonQuery();
                SqlCommand cmddoc;
                System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id + "\\healDoc\\");
                foreach (var doc in healDocs)
                {
                    fileName = System.IO.Path.GetFileName(doc);
                    targetPath = this.helpPath + "\\" + this.id + "\\healDoc\\";
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmddoc.Parameters.AddWithValue("@id", this.id);
                    cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmddoc.Parameters.AddWithValue("@dname", fileName);
                    cmddoc.Parameters.AddWithValue("@dpath", destFile);
                    cmddoc.Parameters.AddWithValue("@dtype", "HRhelp:healDoc");
                    cmddoc.ExecuteNonQuery();
                }
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("درخواست به شماره " + this.id + " با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
            else
            {
                if (reqLabel.BackColor == Color.GreenYellow)
                {
                    System.IO.Directory.Delete(this.helpPath + "\\" + this.id + "\\req\\", true);
                    System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id + "\\req\\");
                    string fileName = System.IO.Path.GetFileName(reqdoc);
                    string targetPath = this.helpPath + "\\" + this.id + "\\req\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "HRhelp:reqForm");
                    cmd.ExecuteNonQuery();
                }
                if (healDocLabel.BackColor == Color.GreenYellow)
                {
                    SqlCommand cmddoc;
                    System.IO.Directory.Delete(this.helpPath + "\\" + this.id + "\\healDoc\\", true);
                    System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id + "\\healDoc\\");
                    foreach (var doc in healDocs)
                    {
                        string fileName = System.IO.Path.GetFileName(doc);
                        string targetPath = this.helpPath + "\\" + this.id + "\\healDoc\\";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                        cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                        cmddoc.Parameters.AddWithValue("@id", this.id);
                        cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmddoc.Parameters.AddWithValue("@dname", fileName);
                        cmddoc.Parameters.AddWithValue("@dpath", destFile);
                        cmddoc.Parameters.AddWithValue("@dtype", "HRhelp:healDoc");
                        cmddoc.ExecuteNonQuery();
                    }
                }
                SqlCommand cmdup = new SqlCommand("update HealHelpReq Set reqdate = @rdate, description = @des where id = @id;", con);
                cmdup.Parameters.AddWithValue("@id", this.id);
                cmdup.Parameters.AddWithValue("@rdate", reqDateTimePickerX.SelectedDateInDateTime.Date);
                cmdup.Parameters.AddWithValue("@des", explainTextBox.Text);
                cmdup.ExecuteNonQuery();
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("درخواست به شماره " + this.id + " با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }

        private void healHelpReqForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!res)
            {
                DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("با ترک این صفحه اطلاعات تغییر یافته، ذخیره نمی‌شوند. آیا نسبت به ترک صفحه اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
