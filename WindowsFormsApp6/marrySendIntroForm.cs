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
    public partial class marrySendIntroForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, rId, eId, ePath, introFile = "", explain;
        public marrySendIntroForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void marrySendIntroForm_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.Text = ExtensionFunction.EnglishToPersian(this.id);
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmdget;
            con.Open();
            if (this.Text == "ارسال معرفی‌نامه جهیزیه")
            {
                cmdget = new SqlCommand("select reqId, MarryHelps.description, MarryHelps.enactmentId, MarryHelpReq.description from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.rId = reader.GetString(0);
                        explainTextBox.Text = reader.GetString(3) + " " + reader.GetString(1);
                        this.eId = reader.GetString(2);
                    }
                }
            }
            else
            {
                this.BackColor = Color.Yellow; delButton.Visible = visitPreIntroButton.Visible = true;
                introLabel.BackColor = Color.YellowGreen;
                label22.Location = new Point(label22.Location.X, label22.Location.Y - 12);
                introLabel.Location = new Point(introLabel.Location.X, introLabel.Location.Y - 12);
                introAddFileButton.Location = new Point(introAddFileButton.Location.X, introAddFileButton.Location.Y - 12);
                cmdget = new SqlCommand("select reqId, MarryHelps.description, MarryHelps.enactmentId, MarryHelpReq.description, introdescription from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.rId = reader.GetString(0);
                        explainTextBox.Text = reader.GetString(3) + " " + reader.GetString(1) + " " + reader.GetString(4); this.explain = reader.GetString(4);
                        this.eId = reader.GetString(2);
                    }
                }
            }
            
            cmdget = new SqlCommand("select docpath from enactment where id = @eId;", con);
            cmdget.Parameters.AddWithValue("@eId", this.eId);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.ePath = reader.GetString(0);
                }
            }
            con.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (introLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("معرفی‌نامه بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (this.Text == "ارسال معرفی‌نامه جهیزیه")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                string fileName = System.IO.Path.GetFileName(introFile);
                string targetPath = this.helpPath + "\\" + this.id + "\\intro\\";
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set introdescription = @des, senddate = @sdate, status = @stat where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @sdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@des", "(توضیحات معرفی‌نامه: " + explainTextBox2.Text + ")");
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@stat", "دریافت نتیجه");
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "Mhelp:intro");
                cmd.ExecuteNonQuery();
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("معرفی‌نامه با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                if(introLabel.BackColor == Color.GreenYellow)
                {
                    string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\intro")[0];
                    System.IO.File.Delete(dpath);
                    string fileName = System.IO.Path.GetFileName(introFile);
                    string targetPath = this.helpPath + "\\" + this.id + "\\intro\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set introdescription = @des where id = @id; update doc Set docname = @dname, docpath = @dpath, subdate = @sdate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش معرفی‌نامه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "Mhelp:intro");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update MarryHelps Set introdescription = @des where id = @id;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش معرفی‌نامه: " + explainTextBox2.Text + ")");
                    cmd.ExecuteNonQuery();
                }
                
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("ارسال معرفی‌نامه با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\intro")[0];
            System.IO.File.Delete(dpath);
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set introdescription = Null, senddate = Null, status = @stat where id = @id; delete from doc where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@stat", "ارسال معرفی‌نامه");
            cmd.Parameters.AddWithValue("@dtype", "Mhelp:intro");
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("معرفی‌نامه با موفقیت حذف شد. مجددا می‌توانید از طریق ثیت ارسال معرفی‌نامه اقدام کنید!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void visitPreIntroButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\intro")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void introAddFileButton_Click(object sender, EventArgs e)
        {
            if(this.Text == "ارسال معرفی‌نامه جهیزیه")
            {
                addOpenFileDialog.Title = "انتخاب فایل معرفی‌نامه";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    introFile = addOpenFileDialog.FileName;
                    introLabel.BackColor = Color.YellowGreen;
                }
                else
                {
                    introFile = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    introLabel.BackColor = Color.Red;
                }
            }
            else
            {
                addOpenFileDialog.Title = "انتخاب فایل معرفی‌نامه";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    introFile = addOpenFileDialog.FileName;
                    introLabel.BackColor = Color.GreenYellow;
                }
                else
                {
                    introFile = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    introLabel.BackColor = Color.YellowGreen;
                }
            }
        }

        private void visitDocsButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("مشاهده مدارک ازدواج", this.rId, "MRhelp:marryDoc");
            newform.ShowDialog(this);
        }

        private void visitEnactmentButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.ePath);
        }

        private void visitFormButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.rId + "\\req")[0];
            System.Diagnostics.Process.Start(dpath);
        }
    }
}
