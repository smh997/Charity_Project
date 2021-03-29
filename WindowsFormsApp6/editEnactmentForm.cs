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
    public partial class editEnactmentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string enactmentPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\enactment";
        string doc = "";
        string id = "";
        public editEnactmentForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string dpath = enactmentPath + "\\" + this.id;
            System.Diagnostics.Process.Start(System.IO.Directory.GetFiles(dpath)[0]);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string dd = enactmentTimePickerX.SelectedDateInDateTime.Date.ToPersian();
            dd = dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2);
            if(id == dd)
            {
                if(docLabel.BackColor == Color.Red)
                {
                    FMessegeBox.FarsiMessegeBox.Show("تغییری ایجاد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else
                {
                    System.IO.Directory.Delete(enactmentPath + "\\" + id);
                    System.IO.Directory.CreateDirectory(enactmentPath + "\\" + dd);
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = enactmentPath + "\\" + dd + "\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update enactment Set docname = @dname and docpath = @dpath;", con);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("ویرایش با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
                }
            }
            else
            {
                int c = 0;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as c from enactment where id = @id", con);
                cmdcheck.Parameters.AddWithValue("@id", dd);
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    FMessegeBox.FarsiMessegeBox.Show("مصوبه‌ای قبلا در این تاریخ تصویب شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                }
                else if (docLabel.BackColor == Color.Red)
                {
                    // to do: change all used pos
                    SqlCommand cmd = new SqlCommand("update enactment Set id=@id, setdate=@sdate;", con);
                    cmd.Parameters.AddWithValue("@id", dd);
                    cmd.Parameters.AddWithValue("@sdate", enactmentTimePickerX.SelectedDateInDateTime.Date);
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("ویرایش با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
                }
                else
                {
                    System.IO.Directory.Delete(enactmentPath + "\\" + id);
                    System.IO.Directory.CreateDirectory(enactmentPath + "\\" + dd);
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = enactmentPath + "\\" + dd + "\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmd, cmddel;
                    // to do: change all used pos
                    cmddel = new SqlCommand("delete from enactment where id = @id;", con);
                    cmddel.Parameters.AddWithValue("@id", id);
                    cmddel.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into enactment (id, setdate, docname, docpath) Values (@id, @sdate, @dname, @dpath);", con);
                    cmd.Parameters.AddWithValue("@id", dd);
                    cmd.Parameters.AddWithValue("@sdate", enactmentTimePickerX.SelectedDateInDateTime.Date);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("ویرایش با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
                }
                
            }

        }

        private void docAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب فایل مصوبه";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc = addOpenFileDialog.FileName;
                docLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                doc = "";
                addOpenFileDialog.FileName = "*.pdf";
                docLabel.BackColor = Color.Red;
            }
        }

        private void editEnactmentForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select setdate from enactment where id = @id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmd.ExecuteReader()){
                if (reader.Read())
                {
                    enactmentTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["setdate"]));
                }
            }
            con.Close();
        }

        private void enactmentTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (enactmentTimePickerX.SelectedDateInDateTime.Date > DateTime.Now.Date)
            {
                enactmentTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }
    }
}
