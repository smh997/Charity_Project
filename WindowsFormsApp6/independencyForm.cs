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
    
    public partial class independencyForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public independencyForm()
        {
            InitializeComponent();
        }

        private void independencyForm_Load(object sender, EventArgs e)
        {
            independencyDeleteSupportButton.Enabled = false;
            independencySupportButton.Enabled = false;
            
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2 = new SqlCommand("select member.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', orphan as یتیم, student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) )", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
            con1.Close();
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void independencyDeleteSupportButton_Click(object sender, EventArgs e)
        {
            int res;
            if(int.TryParse(independencyTextbox.Text, out res) && !independencyTextbox.Text.Any(char.IsWhiteSpace))
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from onindependency where id = @sup", con);
                cmdcheck.Parameters.AddWithValue("@sup", independencyTextbox.Text);
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
                    MessageBox.Show("شماره ملی عضو در لیست موجود نیست!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, homephone, cellphone, address, explain, rate, marriage, folder_id, orphan, student from member where id = @tmp", con);
                    cmdget.Parameters.AddWithValue("@tmp", independencyTextbox.Text);
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student homephone, cellphone, address, explain, folder_id, abandoneddate)" +
                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @abandoneddate); " +
                                "insert into independencyChecked (id, checkdate, description, status, name, family, fatherName, supporter_id, sex, job, house, birthdate, health, lifehood, marriage, orphan, student homephone, cellphone, address, explain, rate, folder_id) Values(@id, @independencycheckdate, @description, @status, @name, @family, @fatherName, @supporter_id, @sex, @job, @house, @birthdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @rate, @folder_id); " +
                                "delete from onindependency where id = @id; delete from member where id = @id; commit tran t1;", con);

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
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"])+ independencyDescriptionTextBox.Text + "(خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@rate", float.Parse(String.Format("{0}", reader["rate"])));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmd.Parameters.AddWithValue("@independencycheckdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@description", independencyDescriptionTextBox.Text + "(خروج از پوشش به علت استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@status", "خارج از پوشش");
                        }
                    }
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("عضو با موفقیت از پوشش خارج شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    independencyDeleteSupportButton.Enabled = false;
                    independencySupportButton.Enabled = false;

                    
                    SqlCommand cmd2 = new SqlCommand("select member.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی',  orphan as یتیم, student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) )", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    membersView.DataSource = dt;
                    membersView.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
                    con.Close();
                    independencyDescriptionTextBox.Text = "";
                    independencyTextbox.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            
        }

        private void independencyTextbox_TextChanged(object sender, EventArgs e)
        {
            independencyDeleteSupportButton.Enabled = !string.IsNullOrEmpty(independencyTextbox.Text) && !string.IsNullOrWhiteSpace(independencyTextbox.Text);
            independencySupportButton.Enabled = !string.IsNullOrEmpty(independencyTextbox.Text) && !string.IsNullOrWhiteSpace(independencyTextbox.Text);
        }

        private void independencySupportButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(independencyTextbox.Text, out res) && !independencyTextbox.Text.Any(char.IsWhiteSpace))
            {

                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from onindependency where id = @sup", con);
                cmdcheck.Parameters.AddWithValue("@sup", independencyTextbox.Text);
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
                    MessageBox.Show("شماره ملی عضو در لیست موجود نیست!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, rate, folder_id from member where id = @tmp", con);
                    cmdget.Parameters.AddWithValue("@tmp", independencyTextbox.Text);
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into independencyChecked (id, checkdate, description, status, name, family, fatherName, supporter_id, sex, job, house, birthdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, rate, folder_id) Values(@id, @independencycheckdate, @description, @status, @name, @family, @fatherName, @supporter_id, @sex, @job, @house, @birthdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @rate, @folder_id);  delete from onindependency where id = @id; commit tran t1;", con);
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
                            cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"])+ independencyDescriptionTextBox.Text + "(تحت پوشش ماندن با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@rate", float.Parse(String.Format("{0}", reader["rate"])));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@independencycheckdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@description", independencyDescriptionTextBox.Text + "(تحت پوشش ماندن با وجود رسیدن به سن استقلال در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@status", "تحت پوشش");
                        }
                    }
                    
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("عضو با موفقیت در پوشش باقی ماند", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    independencyDeleteSupportButton.Enabled = false;
                    independencySupportButton.Enabled = false;

                    SqlCommand cmd2 = new SqlCommand("select member.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) )", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    membersView.DataSource = dt;
                    membersView.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
                    con.Close();
                    independencyDescriptionTextBox.Text = "";
                    independencyTextbox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("اخطار شماره ملی باید شامل اعداد و بدون هیچ فاضله‌ای باشد", "اخظار!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
             
                  
        }
            



        
    }
}
