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
    public partial class setMarriageForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public setMarriageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newform = new searchForm(this.Name);
            newform.ShowDialog(this);
        }

        private void independencyTextbox_DoubleClick(object sender, EventArgs e)
        {
            idTextbox.Text = Clipboard.GetText();
        }

        private void setMarriageForm_Load(object sender, EventArgs e)
        {
            setMarriageButton.Enabled = false;
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setMarriageButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }
        private void setMarriageButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(idTextbox.Text, out res) && !idTextbox.Text.Any(char.IsWhiteSpace))
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from member where id = @sup and sex = N'زن'", con);
                cmdcheck.Parameters.AddWithValue("@sup", idTextbox.Text);
                int sup = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sup = int.Parse(String.Format("{0}", reader["sup"]));
                    }
                }
                if (sup == 0)
                {
                    MessageBox.Show("شماره ملی عضو خانم در لیست موجود نیست!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    SqlCommand cmdchecksup = new SqlCommand("select count(*) as sup from member where supporter_id = @sup and id != @sup", con);
                    cmdcheck.Parameters.AddWithValue("@sup", idTextbox.Text);
                    int su = 0;
                    using (SqlDataReader reader = cmdchecksup.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            su = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (su != 0)
                    {
                        var newform = new changeSupporterForm(this.Text, idTextbox.Text);
                        newform.ShowDialog(this);
                    }
                    su = 0;
                    using (SqlDataReader reader = cmdchecksup.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            su = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup != 0)
                    {
                        MessageBox.Show("این عضو سرپرست خانوار است و ابتدا باید وضعیت سرپرستی آنها را مشخص کنید!", "اخطار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, rate, folder_id from member where id = @tmp", con);
                        cmdget.Parameters.AddWithValue("@tmp", idTextbox.Text);
                        SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id, abandoneddate)" +
                                    " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @abandoneddate); " +
                                    "insert into married (id, marrieddate, description, setupdate, folder_id) Values(@id, @marrieddate, @description, @abandoneddate, @folder_id); " +
                                    "delete from member where id = @id; commit tran t1;", con);

                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                                cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                                cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                                cmd.Parameters.AddWithValue("@id", String.Format("{0}", reader["id"]));
                                cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                                cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                                cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                                cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                                cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                                cmd.Parameters.AddWithValue("@lifehood", String.Format("{0}", reader["lifehood"]));
                                cmd.Parameters.AddWithValue("@marriage", "متأهل");
                                cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                                cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                                cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                                cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"])+ marriedDescriptionTextBox.Text + "(خروج از پوشش به علت ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                                cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                                cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                                cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                                cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                                cmd.Parameters.AddWithValue("@marrieddate", marriedTimePicker.Value.Date);
                                cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@description", marriedDescriptionTextBox.Text + "(خروج از پوشش به علت ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("ازدواج عضو با موفقیت ثبت شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    con.Close();

                    setMarriageButton.Enabled = false;
                    idTextbox.Text = "";
                    marriedDescriptionTextBox.Text = "";
                    marriedTimePicker.Value = DateTime.Now;
                }
            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }
    }
}
