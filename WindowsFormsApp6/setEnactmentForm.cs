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
    public partial class setEnactmentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string enactmentPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\enactment";
        string doc="";
        public setEnactmentForm()
        {
            InitializeComponent();
        }

        private void enactmentTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (enactmentTimePickerX.SelectedDateInDateTime > DateTime.Now.Date)
            {
                enactmentTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایل مصوبه افزوده نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);

            }
            else
            {
                string d = enactmentTimePickerX.SelectedDateInDateTime.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                int c = 0;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as c from enactment where id = @id", con);
                cmdcheck.Parameters.AddWithValue("@id", d);
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
                }
                else
                {
                    System.IO.Directory.CreateDirectory(enactmentPath + "\\" + d);
                    string fileName = System.IO.Path.GetFileName(doc);
                    string targetPath = enactmentPath + "\\" + d + "\\";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmd = new SqlCommand("insert into enactment (id, setdate, docname, docpath) Values (@id, @sdate, @dname, @dpath);", con);
                    cmd.Parameters.AddWithValue("@id", d);
                    cmd.Parameters.AddWithValue("@sdate", enactmentTimePickerX.SelectedDateInDateTime.Date);
                    cmd.Parameters.AddWithValue("dname", fileName);
                    cmd.Parameters.AddWithValue("dpath", destFile);
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("مصوبه با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
                }
                con.Close();
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
    }
}
