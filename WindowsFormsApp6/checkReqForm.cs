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

namespace WindowsFormsApp6
{
    public partial class checkReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string otherApplicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\otherApplicant";
        string id, typ, fold="", AM;
        List<string> doc;
        List<string> children;
        string[] arr;
        public checkReqForm(string id, string typ)
        {
            InitializeComponent();
            this.id = id;
            this.typ = typ;
            doc = new List<string>();
            children = new List<string>();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if(docLabel.BackColor == Color.Red && this.typ == "check")
            {
                FMessegeBox.FarsiMessegeBox.Show("مصوبه بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                if (this.typ == "edit" && docLabel.BackColor == Color.YellowGreen)
                {
                    DialogResult res = FMessegeBox.FarsiMessegeBox.Show("فایل مصوبه جدیدی انتخاب شده است! آیا میخواهید این فایل جایگزین شود؟", "پرسش!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (res != DialogResult.Yes)
                    {
                        return;
                    }
                }
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmddoc, cmd;
                if (this.typ == "check")
                {
                    cmd = new SqlCommand("update request Set result = @res, acceptedFee = @aFee, checkdate = @cdate, description2 = @des where id = @id;", con);
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now.Date);
                }
                else
                {
                    cmd = new SqlCommand("update request Set result = @res, acceptedFee = @aFee, description2 = @des where id = @id;", con);
                }
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@res", "تایید");
                cmd.Parameters.AddWithValue("@aFee", feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@des", checkDescTextBox.Text);
                cmd.ExecuteNonQuery();
                foreach(var child in arr)
                {
                    string targetPath = "";
                    if(this.AM == "member")
                    {
                        if(this.typ == "check")
                        {
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id);
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc");
                        }
                        else if(docLabel.BackColor == Color.YellowGreen)
                        {
                            SqlCommand cmddeldoc = new SqlCommand("delete from doc where researchId = @id;", con);
                            cmddeldoc.Parameters.AddWithValue("@id", this.id);
                            cmddeldoc.ExecuteNonQuery();
                            string[] filePaths = System.IO.Directory.GetFiles(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc");
                            foreach (string filePath in filePaths)
                                System.IO.File.Delete(filePath);
                        }
                        targetPath = defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc\\";
                    }
                    else
                    {
                        if (this.typ == "check")
                        {
                            System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id);
                            System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc");
                        }
                        else if (docLabel.BackColor == Color.YellowGreen)
                        {
                            SqlCommand cmddeldoc = new SqlCommand("delete from doc where researchId = @id;", con);
                            cmddeldoc.Parameters.AddWithValue("@id", this.id);
                            cmddeldoc.ExecuteNonQuery();
                            string[] filePaths = System.IO.Directory.GetFiles(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc");
                            foreach (string filePath in filePaths)
                                System.IO.File.Delete(filePath);
                        }
                        targetPath = otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id + "\\doc\\";
                    }
                    if (docLabel.BackColor == Color.YellowGreen)
                    {
                        string fileName = System.IO.Path.GetFileName(doc[0]);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(doc[0], destFile, false);
                        cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con);
                        cmddoc.Parameters.AddWithValue("@id", child);
                        cmddoc.Parameters.AddWithValue("@dname", fileName);
                        cmddoc.Parameters.AddWithValue("@dpath", destFile);
                        cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmddoc.Parameters.AddWithValue("@dtype", "facilities:doc");
                        cmddoc.Parameters.AddWithValue("@resId", this.id);
                        cmddoc.ExecuteNonQuery();
                    }
                }
                if(this.typ == "check")
                    FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت تایید شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                else
                    FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت ویرایش و تایید شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
        }

        private void docLabel_Click(object sender, EventArgs e)
        {
            if(this.typ == "edit")
            {
                doc.Clear();
                addOpenFileDialog.FileName = "*.pdf";
                docLabel.BackColor = Color.Red;
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string dpath;
            if (this.AM == "applicant")
            {
                dpath = otherApplicantPath + "\\" + arr[0] + "\\req\\facilities\\" + this.id + "\\doc";
            }
            else
            {
                dpath = defaultPath + "\\" + this.fold + "\\" + arr[0] + "\\req\\facilities\\" + this.id + "\\doc";
            }
            System.Diagnostics.Process.Start(System.IO.Directory.GetFiles(dpath)[0]);
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            if (docLabel.BackColor == Color.Red && this.typ == "check")
            {
                FMessegeBox.FarsiMessegeBox.Show("مصوبه بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                if(this.typ == "edit" && docLabel.BackColor == Color.YellowGreen)
                {
                    DialogResult res =  FMessegeBox.FarsiMessegeBox.Show("فایل مصوبه جدیدی انتخاب شده است! آیا میخواهید این فایل جایگزین شود؟", "پرسش!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if(res != DialogResult.Yes)
                    {
                        return;
                    }
                }
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmddoc, cmd;
                if (this.typ == "check")
                {
                    cmd = new SqlCommand("update request Set result = @res, acceptedFee = @aFee, checkdate = @cdate, description2 = @des where id = @id;", con);
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now.Date);
                }
                else
                {
                    cmd = new SqlCommand("update request Set result = @res, acceptedFee = @aFee, description2 = @des where id = @id;", con);
                }
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@res", "رد");
                cmd.Parameters.AddWithValue("@aFee", 0);
                cmd.Parameters.AddWithValue("@des", checkDescTextBox.Text);
                cmd.ExecuteNonQuery();
                foreach (var child in arr)
                {
                    string targetPath = "";
                    if (this.AM == "member")
                    {
                        if (this.typ == "check")
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id);
                        else if (docLabel.BackColor == Color.YellowGreen)
                        {
                            SqlCommand cmddeldoc = new SqlCommand("delete from doc where researchId = @id;", con);
                            cmddeldoc.Parameters.AddWithValue("@id", this.id);
                            cmddeldoc.ExecuteNonQuery();
                            string[] filePaths = System.IO.Directory.GetFiles(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id);
                            foreach (string filePath in filePaths)
                                System.IO.File.Delete(filePath);
                        }
                        targetPath = defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\";
                    }
                    else
                    {
                        if (this.typ == "check")
                            System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id);
                        else if (docLabel.BackColor == Color.YellowGreen)
                        {
                            SqlCommand cmddeldoc = new SqlCommand("delete from doc where researchId = @id;", con);
                            cmddeldoc.Parameters.AddWithValue("@id", this.id);
                            cmddeldoc.ExecuteNonQuery();
                            string[] filePaths = System.IO.Directory.GetFiles(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id);
                            foreach (string filePath in filePaths)
                                System.IO.File.Delete(filePath);
                        }
                        targetPath = otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id + "\\";
                    }
                    if (docLabel.BackColor == Color.YellowGreen)
                    {
                        string fileName = System.IO.Path.GetFileName(doc[0]);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(doc[0], destFile, false);
                        cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con);
                        cmddoc.Parameters.AddWithValue("@id", child);
                        cmddoc.Parameters.AddWithValue("@dname", fileName);
                        cmddoc.Parameters.AddWithValue("@dpath", destFile);
                        cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmddoc.Parameters.AddWithValue("@dtype", "facilities:doc");
                        cmddoc.Parameters.AddWithValue("@resId", this.id);
                        cmddoc.ExecuteNonQuery();
                    }
                }
                if (this.typ == "check")
                    FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت رد شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                else
                    FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت ویرایش و رد شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                
                con.Close();
                this.Close();
            }
        }

        private void docAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "مصوبه تقاضا";
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

        private void checkReqForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from request where id = @id and applicantId = sup;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    fullnameTextbox.Text = String.Format("{0}", reader["fullname"]);
                    reqFeeTextBox.Text = Convert.ToInt64(feeNumericUpDown.Maximum = Convert.ToDecimal(String.Format("{0}", reader["reqFee"]))).ToString();
                    reqTypeTextBox.Text = String.Format("{0}", reader["reqType"]);
                    explainTextBox.Text = String.Format("{0}", reader["description"]);
                    this.AM = String.Format("{0}", reader["AM"]);
                    if (this.typ == "edit")
                    {
                        this.BackColor = Color.Yellow;
                        feeNumericUpDown.Value = Convert.ToDecimal(String.Format("{0}", reader["acceptedFee"]));
                        checkDescTextBox.Text = String.Format("{0}", reader["description2"]);
                        showButton.Visible = true;
                    }
                }
            }
            SqlCommand cmdgetchild = new SqlCommand("select distinct(applicantId) from request where id = @id", con);
            cmdgetchild.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdgetchild.ExecuteReader())
            {
                while (reader.Read())
                {
                    children.Add(reader.GetString(0));
                }
            }
            arr = children.ToArray();
            if (AM == "member")
            {
                cmd = new SqlCommand("select folder_id from member where id = @id", con);
                cmd.Parameters.AddWithValue("@id", arr[0]);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.fold = String.Format("{0}", reader["folder_id"]);
                    }
                }
            }
            con.Close();
        }
    }
}
