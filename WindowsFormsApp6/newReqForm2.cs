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
    public partial class newReqForm2 : Form
    {
        string id, typ;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public newReqForm2(string id, string type)
        {
            InitializeComponent();
            this.id = id;
            this.typ = type;
        }

        private void newWorkRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            feeNumericUpDown.Visible = label2.Visible = (newWorkRadioButton.Checked || helpingRadioButton.Checked || helpeeRadioButton.Checked);
        }

        private void transferRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            feeNumericUpDown.Visible = label2.Visible = ! transferRadioButton.Checked;
        }

        private void feeNumericUpDown_VisibleChanged(object sender, EventArgs e)
        {
            if (!feeNumericUpDown.Visible)
            {
                feeNumericUpDown.Value = 1000000;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string[] arr;List<string> li = new List<string>();

            SqlCommand cmdgetchild, cmd;
            if(this.typ == "applicant" || this.typ == "member")
            {
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نیست به ثبت تقاضا اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if(res != DialogResult.Yes)
                {
                    return;
                }
                if (this.typ == "applicant")
                {
                    cmdgetchild = new SqlCommand("select id from otherApplicant where id = @id;", con);
                    cmdgetchild.Parameters.AddWithValue("@id", this.id);
                }
                else
                {
                    cmdgetchild = new SqlCommand("select id from member where supporter_id = @id;", con);
                    cmdgetchild.Parameters.AddWithValue("@id", this.id);
                }
                using (SqlDataReader reader = cmdgetchild.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        li.Add(reader.GetString(0));
                    }
                    arr = li.ToArray();
                }
                string rtype = "";
                foreach (RadioButton cont in typeGroupBox.Controls)
                {
                    if (cont.Checked)
                    {
                        rtype = cont.Text;
                    }
                }
                string d = DateTime.Now.Date.ToPersian(); d = "req" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                SqlCommand cmdgetreqid = new SqlCommand("select id from request where id like '" + d + "%';", con);
                int index = 1, mx = 1;
                using (SqlDataReader reader = cmdgetreqid.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string s = String.Format("{0}", reader["id"]);
                        if (s == "") index = 1;
                        else index = Convert.ToInt32(s.Substring(11)) + 1;
                        mx = Math.Max(mx, index);
                    }
                }
                d = d + mx.ToString();
                string reqId = d ;
                foreach (var child in arr)
                {
                    cmd = new SqlCommand("insert into request (id, fullname, applicantId, subdate, reqType, reqFee, description, AM, sup) Values (@rid, @fname, @id, @subdate, @rType, @rFee, @des, @AM, @sup);", con);
                    cmd.Parameters.AddWithValue("@id", child);
                    cmd.Parameters.AddWithValue("@fname", fullnameTextbox.Text);
                    cmd.Parameters.AddWithValue("@rid", reqId);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@rType", rtype);
                    cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                    cmd.Parameters.AddWithValue("@AM", this.typ);
                    cmd.Parameters.AddWithValue("@sup", this.id);
                    if (transferRadioButton.Checked)
                    {
                        cmd.Parameters.AddWithValue("@rFee", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rFee", feeNumericUpDown.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
            else
            {
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نیست به ویرایش تقاضا اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                cmd = new SqlCommand("update request Set reqFee = @rFee, description = @des, reqType = @rtype where id = @id", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@rFee", feeNumericUpDown.Value);
                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                foreach(RadioButton rb in typeGroupBox.Controls)
                {
                    if (rb.Checked)
                    {
                        cmd.Parameters.AddWithValue("@rtype", rb.Text);
                        break;
                    }
                }
                cmd.ExecuteNonQuery();
                FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from request where id = @id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.ExecuteNonQuery();
            FMessegeBox.FarsiMessegeBox.Show("تقاضا با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }

        private void newReqForm2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetname;
            if(this.typ == "applicant")
            {
                helpeeRadioButton.Enabled = false;
                cmdgetname = new SqlCommand("select name, family from otherApplicant where id = @id;", con);
                cmdgetname.Parameters.AddWithValue("@id", this.id);
                string name="", family="";
                using(SqlDataReader reader = cmdgetname.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = String.Format("{0}", reader["name"]);
                        family = String.Format("{0}", reader["family"]);
                    }
                }
                fullnameTextbox.Text = name + " " + family;
            }
            else if(this.typ == "member")
            {
                cmdgetname = new SqlCommand("select name, family from member where id = @id;", con);
                cmdgetname.Parameters.AddWithValue("@id", this.id);
                string name = "", family = "";
                using (SqlDataReader reader = cmdgetname.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = String.Format("{0}", reader["name"]);
                        family = String.Format("{0}", reader["family"]);
                    }
                }
                fullnameTextbox.Text = name + " " + family;
            }
            else
            {
                delButton.Visible = true;
                this.BackColor = Color.Yellow;
                SqlCommand cmdgetAM = new SqlCommand("select fullname, reqType, reqFee, description, AM from request where id = @id", con);
                cmdgetAM.Parameters.AddWithValue("@id", this.id);
                string AM="", reqType="";
                using(SqlDataReader reader = cmdgetAM.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        fullnameTextbox.Text = String.Format("{0}", reader["fullname"]);
                        explainTextBox.Text = String.Format("{0}", reader["description"]);
                        feeNumericUpDown.Value = Convert.ToDecimal(String.Format("{0}", reader["reqFee"]));
                        AM = String.Format("{0}", reader["AM"]);
                        reqType = String.Format("{0}", reader["reqType"]);
                    }
                }
                if(AM == "applicant")
                {
                    helpeeRadioButton.Enabled = false;
                }
                foreach(RadioButton rb in typeGroupBox.Controls)
                {
                    if(rb.Text == reqType)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
            con.Close();
        }
    }
}
