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
    public partial class responseReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string otherApplicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\otherApplicant";
        string id, typ, fold = "", AM;
        List<string> doc;
        List<string> children;
        string[] arr;
        public responseReqForm(string id, string typ)
        {
            InitializeComponent();
            this.id = id;
            this.typ = typ;
            doc = new List<string>();
            children = new List<string>();
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

        private void responseReqForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (typ == "edit" && docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("معرفی‌نامه‌ای افزوده نشده است و بدون افزودن نمی‌توانید ویرایش را رها نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("معرفی‌نامه بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmddoc, cmd;
                if (this.typ == "response")
                {
                    cmd = new SqlCommand("update request Set deliveryDate = @ddate, description3 = @des where id = @id;", con);
                    cmd.Parameters.AddWithValue("@ddate", DateTime.Now.Date);
                }
                else
                {
                    cmd = new SqlCommand("update request Set result = @res, acceptedFee = @aFee, description3 = @des where id = @id;", con);
                }
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@des", introTextBox.Text);
                cmd.ExecuteNonQuery();
                if (this.typ == "response")
                {
                    foreach (var child in arr)
                    {
                        string targetPath = "";
                        if (this.AM == "member")
                        {
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\intro");
                            targetPath = defaultPath + "\\" + this.fold + "\\" + child + "\\req\\facilities\\" + this.id + "\\intro\\";
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id+ "\\intro");
                            targetPath = otherApplicantPath + "\\" + child + "\\req\\facilities\\" + this.id + "\\intro\\";
                        }
                        foreach(var fm in doc)
                        {
                            string fileName = System.IO.Path.GetFileName(fm);
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(fm, destFile, false);
                            cmddoc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype, researchId) Values(@id, @dname, @dpath, @subdate, @dtype, @resId);", con);
                            cmddoc.Parameters.AddWithValue("@id", child);
                            cmddoc.Parameters.AddWithValue("@dname", fileName);
                            cmddoc.Parameters.AddWithValue("@dpath", destFile);
                            cmddoc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmddoc.Parameters.AddWithValue("@dtype", "facilities:intro");
                            cmddoc.Parameters.AddWithValue("@resId", this.id);
                            cmddoc.ExecuteNonQuery();
                        }
                    }
                }
                
                if (this.typ == "response")
                    FMessegeBox.FarsiMessegeBox.Show("ارائه معرفی‌نامه با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                else
                    FMessegeBox.FarsiMessegeBox.Show("ارائه معرفی‌نامه با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }

        }

        private void docAddFileButton_Click(object sender, EventArgs e)
        {
            if(this.typ == "edit")
            {
                var newform = new doceditForm("ویرایش معرفی‌نامه", this.id, "facilities:intro", "", "", this.fold);
                newform.ShowDialog(this);
                if (int.Parse(newform.Text) == 0)
                    docLabel.BackColor = Color.Red;
                else
                    docLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                addOpenFileDialog.Title = "معرفی‌نامه";
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
        }

        private void responseReqForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from request where id = @id and applicantId = sup;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    fullnameTextbox.Text = String.Format("{0}", reader["fullname"]);
                    reqFeeTextBox.Text = Convert.ToInt64(Convert.ToDecimal(String.Format("{0}", reader["reqFee"]))).ToString();
                    reqTypeTextBox.Text = String.Format("{0}", reader["reqType"]);
                    explainTextBox.Text = String.Format("{0}", reader["description"]);
                    acceptedFeeTextBox.Text = Convert.ToInt64(Convert.ToDecimal(String.Format("{0}", reader["acceptedFee"]))).ToString();
                    checkDescTextBox.Text = String.Format("{0}", reader["description2"]);
                    this.AM = String.Format("{0}", reader["AM"]);
                    if (this.typ == "edit")
                    {
                        introTextBox.Text = String.Format("{0}", reader["description3"]);
                        this.BackColor = Color.Yellow;
                        docLabel.BackColor = Color.YellowGreen;
                    }
                }
            }
            SqlCommand cmdgetchild = new SqlCommand("select applicantId from request where id = @id", con);
            cmdgetchild.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetchild.ExecuteReader())
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
                using (SqlDataReader reader = cmd.ExecuteReader())
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
