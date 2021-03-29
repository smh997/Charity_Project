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
    public partial class editReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public editReqForm(string p="")
        {
            InitializeComponent();
            idTextbox.EnableContextMenu();
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(this.Text == "بررسی تقاضا" || this.Text == "ویرایش تقاضا")
            {
                var newform = new searchForm("ویرایش تقاضا");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
                }
            }
            else if (this.Text == "ثبت ارائه معرفی‌نامه" || this.Text == "ویرایش بررسی")
            {
                searchForm newform;
                if(this.Text == "ویرایش بررسی")
                    newform = new searchForm("ویرایش بررسی");
                else
                    newform = new searchForm("ثبت ارائه معرفی‌نامه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
                }
            }
            else if(this.Text == "ویرایش مصوبه")
            {
                var newform = new searchForm("ویرایش مصوبه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
                }
            }
            else
            {
                var newform = new searchForm("ویرایش ارائه معرفی‌نامه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6)); ;
                }
            }
            
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdcheck;
            if (this.Text == "بررسی تقاضا" || this.Text == "ویرایش تقاضا")
            {
                cmdcheck = new SqlCommand("select count(*) from request where applicantId = sup and id = @id and result is Null;", con);
                cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                int c = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    if (this.Text == "بررسی تقاضا")
                    {
                        var newform = new checkReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "check");
                        newform.ShowDialog(this);
                    }
                    else
                    {
                        var newform = new newReqForm2(ExtensionFunction.PersianToEnglish(idTextbox.Text), "edit");
                        newform.ShowDialog(this);
                    }
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("شماره تقاضا موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
            else if(this.Text == "ثبت ارائه معرفی‌نامه" || this.Text == "ویرایش بررسی")
            {
                if(this.Text == "ویرایش بررسی")
                    cmdcheck = new SqlCommand("select count(*) from request where applicantId = sup and id = @id and result is not Null and deliveryDate is Null;", con);
                else
                    cmdcheck = new SqlCommand("select count(*) from request where applicantId = sup and id = @id and result = N'تایید' and deliveryDate is Null;", con);
                cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                int c = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    if (this.Text == "ثبت ارائه معرفی‌نامه")
                    {
                        var newform = new responseReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "response");
                        newform.ShowDialog(this);
                    }
                    else
                    {
                        var newform = new checkReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "edit");
                        newform.ShowDialog(this);
                    }
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("شماره تقاضا موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                
            }
            else if(this.Text == "ویرایش مصوبه")
            {
                cmdcheck = new SqlCommand("select count(*) from enactment where id = @id;", con);
                cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                int c = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    var newform = new editEnactmentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("شماره مصوبه موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
            else
            {
                cmdcheck = new SqlCommand("select count(*) from request where applicantId = sup and id = @id and deliveryDate is not Null;", con);
                cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                int c = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = reader.GetInt32(0);
                    }
                }
                if (c != 0)
                {
                    var newform = new responseReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "edit");
                    newform.ShowDialog(this);
                }
                else
                {
                    FMessegeBox.FarsiMessegeBox.Show("شماره تقاضا موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
            }
            con.Close();
               
        }

        private void editReqForm_Load(object sender, EventArgs e)
        {
            if(this.Text == "بررسی تقاضا")
            {
                this.BackColor = Color.SkyBlue;
            }
            else if(this.Text == "ثبت ارائه معرفی‌نامه")
            {
                this.BackColor = Color.SkyBlue;
            }
        }
    }
}
