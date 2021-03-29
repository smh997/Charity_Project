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
    public partial class editIndependencyForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public editIndependencyForm()
        {
            InitializeComponent();
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void editindependencyTextbox_TextChanged(object sender, EventArgs e)
        {
            editIndependencyDeleteSupportButton.Enabled = !string.IsNullOrEmpty(editIndependencyTextbox.Text) && !string.IsNullOrWhiteSpace(editIndependencyTextbox.Text);
            editIndependencySupportButton.Enabled = !string.IsNullOrEmpty(editIndependencyTextbox.Text) && !string.IsNullOrWhiteSpace(editIndependencyTextbox.Text);
        }

        private void editIndependencyForm_Load(object sender, EventArgs e)
        {
            editIndependencyDeleteSupportButton.Enabled = false;
            editIndependencySupportButton.Enabled = false;

            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', orphan as 'یتیم', student as 'دانش‌آموز', checkdate as 'تاریخ تعیین استقلال', status as 'وضعیت', description as 'توضیحات استقلال', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as 'امتیاز' from independencyChecked;", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[6].DefaultCellStyle.Format = "yyyy/MM/dd";
            membersView.Columns[10].DefaultCellStyle.Format = "yyyy/MM/dd";
            con1.Close();
        }

        private void editIndependencySupportButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(editIndependencyTextbox.Text, out res) && !editIndependencyTextbox.Text.Any(char.IsWhiteSpace))
            {

                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select id as sup, status as stat, rate from independencyChecked where id = @sup", con);
                cmdcheck.Parameters.AddWithValue("@sup", editIndependencyTextbox.Text);
                int sup = 0; string st = ""; string rate = "";
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string s = String.Format("{0}", reader["sup"]);
                        if (s == "") sup = 0;
                        else sup = int.Parse(s);
                        st = String.Format("{0}", reader["stat"]);
                        rate = String.Format("{0}", reader["rate"]);
                    }
                }
                if (sup == 0)
                {
                    MessageBox.Show("شماره ملی عضو در لیست موجود نیست!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if(st == "تحت پوشش")
                {
                    SqlCommand cmdupdate = new SqlCommand("begin tran t1; update independencyChecked set description = @description where id = @id; update member set explain = @explain where id = @id; commit tran t1;", con);
                    cmdupdate.Parameters.AddWithValue("@id", editIndependencyTextbox.Text);
                    cmdupdate.Parameters.AddWithValue("@description", editIndependencyDescriptionTextBox.Text + newExplain.Text +"(ویرایش توضیحات تحت پوشش ماندن با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                    SqlCommand cmdgetexp = new SqlCommand("select explain from member where id = @id;", con);
                    cmdgetexp.Parameters.AddWithValue("@id", editIndependencyTextbox.Text);
                    using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdupdate.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش توضیحات تحت پوشش ماندن با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                        }
                    }
                    cmdupdate.ExecuteNonQuery();

                    MessageBox.Show("توضیحات تحت پوشش باقی ماندن عضو با موفقیت به روز شد!", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, marriage, orphan, student, lifehood, homephone, cellphone, address, explain, folder_id, orphan, student from abandoned where id = @tmp;", con);
                    cmdget.Parameters.AddWithValue("@tmp", editIndependencyTextbox.Text);
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, rate, folder_id) " +
                        "Values (@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @rate, @folder_id); delete from abandoned where id = @id; " +
                        "update independencyChecked Set status = @status, checkdate = @independencycheckdate, description = @description where id = @id commit tran t1;", con);
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
                            cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                            cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش استقلال: از خروج از پوشش به تحت پوشش با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@rate", float.Parse(rate));
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmd.Parameters.AddWithValue("@independencycheckdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@description", editIndependencyDescriptionTextBox.Text + newExplain.Text +"(ویرایش استقلال: از خروج از پوشش به تحت پوشش با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@status", "تحت پوشش");
                        }
                    }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("عضو با موفقیت مجددا تحت پوشش قرار گرفت!", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    editIndependencyDeleteSupportButton.Enabled = false;
                    editIndependencySupportButton.Enabled = false;

                    SqlCommand cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', orphan as 'یتیم', student as 'دانش‌آموز', checkdate as 'تاریخ تعیین استقلال', status as 'وضعیت', description as 'توضیحات استقلال', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as 'امتیاز' from independencyChecked;", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    membersView.DataSource = dt;
                    membersView.Columns[6].DefaultCellStyle.Format = "yyyy/MM/dd";
                    membersView.Columns[10].DefaultCellStyle.Format = "yyyy/MM/dd";
                    
                    editIndependencyDescriptionTextBox.Text = "";
                    newExplain.Text = "";
                    editIndependencyTextbox.Text = "";
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void editIndependencyDeleteSupportButton_Click(object sender, EventArgs e)
        {
            //todo
            int res;
            if (int.TryParse(editIndependencyTextbox.Text, out res) && !editIndependencyTextbox.Text.Any(char.IsWhiteSpace))
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select id as sup, status as stat, rate from independencyChecked where id = @sup", con);
                cmdcheck.Parameters.AddWithValue("@sup", editIndependencyTextbox.Text);
                int sup = 0; string st = ""; string rate = "";
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string s = String.Format("{0}", reader["sup"]);
                        if (s == "") sup = 0;
                        else sup = int.Parse(s);
                        st = String.Format("{0}", reader["stat"]);
                        rate = String.Format("{0}", reader["rate"]);
                    }
                }
                if (sup == 0)
                {
                    MessageBox.Show("شماره ملی عضو در لیست موجود نیست!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (st == "خارج از پوشش")
                {
                    
                    SqlCommand cmdupdate = new SqlCommand("begin tran t1; update independencyChecked set description = @description where id = @id; update member set explain = @explain where id = @id; commit tran t1;", con);
                    cmdupdate.Parameters.AddWithValue("@id", editIndependencyTextbox.Text);
                    cmdupdate.Parameters.AddWithValue("@description", editIndependencyDescriptionTextBox.Text + newExplain.Text +"(ویرایش  توضیحات خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                    SqlCommand cmdgetexp = new SqlCommand("select explain from member where id = @id;", con);
                    cmdgetexp.Parameters.AddWithValue("@id", editIndependencyTextbox.Text);
                    using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdupdate.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش  توضیحات خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                        }
                    }
                    cmdupdate.ExecuteNonQuery();

                    MessageBox.Show("توضیحات خروج عضو از پوشش با موفقیت به روز شد!", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, rate, folder_id from member where id = @tmp", con);
                    cmdget.Parameters.AddWithValue("@tmp", editIndependencyTextbox.Text);
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id, abandoneddate)" +
                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @abandoneddate); " +
                                "update independencyChecked Set status = @status, checkdate = @independencycheckdate, description = @description where id = @id " +
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
                            cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                            cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش استقلال: از تحت پوشش با وجود رسیدن به سن استقلال به خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@rate", float.Parse(String.Format("{0}", reader["rate"])));
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmd.Parameters.AddWithValue("@independencycheckdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@description", editIndependencyDescriptionTextBox.Text + newExplain.Text + "(ویرایش استقلال: از تحت پوشش با وجود رسیدن به سن استقلال به خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@status", "خارج از پوشش");
                        }
                    }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("عضو با موفقیت از پوشش خارج شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    editIndependencyDeleteSupportButton.Enabled = false;
                    editIndependencySupportButton.Enabled = false;

                    SqlCommand cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', orphan as 'یتیم', student as 'دانش‌آموز', checkdate as 'تاریخ تعیین استقلال', status as 'وضعیت', description as 'توضیحات استقلال', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as 'امتیاز' from independencyChecked;", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    membersView.DataSource = dt;
                    membersView.Columns[6].DefaultCellStyle.Format = "yyyy/MM/dd";
                    membersView.Columns[10].DefaultCellStyle.Format = "yyyy/MM/dd";

                    editIndependencyDescriptionTextBox.Text = "";
                    newExplain.Text = "";
                    editIndependencyTextbox.Text = "";
                }

            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

        }
    }
}
