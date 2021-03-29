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
    public partial class kickForm3 : Form
    {
        string id;
        string reason = "";
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string fold, profile;
        List<string> doc;
        public kickForm3(string p, string id)
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
            doc = new List<string>();
            this.profile = "";
        }

        private void kickForm3_Load(object sender, EventArgs e)
        {            
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            deleteFamilygroupBox.Hide();
            deletePersongroupBox.Hide();
            marrydateTimePickerX.Hide(); label3.Hide();
            if (this.Text == "حذف پوشش خانوار")
            {
                deleteFamilygroupBox.Show();
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where supporter_id = @sup", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else
            {
                deletePersongroupBox.Show();
                marrydateTimePickerX.Show(); label3.Show(); marrydateTimePickerX.Enabled = false;
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where id = @sup", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                
            }
            this.fold = membersView.Rows[0].Cells["شماره پرونده"].Value.ToString();
            SqlCommand cmdgetprofile = new SqlCommand("select docpath from doc where id = @id and doctype = 'profile';", con1);
            cmdgetprofile.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetprofile.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.profile = String.Format("{0}", reader["docpath"]);
                }
            }
            if (this.profile == "")
                profilePictureBox.Image = WindowsFormsApp6.Properties.Resources.profile;
            else
                profilePictureBox.ImageLocation = this.profile;
            con1.Close();
        }

        private void membersView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(membersView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            bool isempty = true;
            reason = "";
            if (this.Text == "حذف پوشش خانوار")
            {
                foreach (CheckBox cb in deleteFamilygroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        reason += cb.Text + "و ";
                        isempty = false;
                    }
                }
            }
            else
            {
                foreach (CheckBox cb in deletePersongroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        if (cb.Text == "ازدواج")
                            reason += cb.Text + " در تاریخ " + marrydateTimePickerX.SelectedDateInDateTime.Date.ToPersian() + " و ";
                        else
                            reason += cb.Text + " و ";
                        isempty = false;
                    }
                }
            }
            
            if (isempty)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ علتی برای حذف انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }

            if(docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ مدرکی برای حذف انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            
            if (this.Text == "حذف پوشش خانوار")
            {       
                List<string> li = new List<string>();
                string[] arr;
                SqlCommand cmdchild = new SqlCommand("select id from member where supporter_id = @sup and id != @sup", con1);
                cmdchild.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdchild.ExecuteReader())
                {
                    
                    while (reader.Read())
                        li.Add(reader.GetString(0));
                    arr = li.ToArray();
                }
                SqlCommand cmdgetc, cmdc;
                foreach (var i in arr)
                {
                    cmdgetc = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, homephone, cellphone, address, explain, rate, marriage, insurance, orphan, student, folder_id, identifierName, identifierPhone, enactmentId from member where id = @tmp", con1);
                    cmdgetc.Parameters.AddWithValue("@tmp", i);
                    cmdc = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, abandoneddate, reason, enactmentId)" +
                                                                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @abandoneddate, @reason, @eId); " +
                                                                                "insert into outmember (id, setupdate, description, status, folder_id, familyRegion, financial) Values(@id, @setupdate, @reason, @status, @folder_id, @famReg, @fin);" +
                                                                                "delete from onindependency where id = @id;" +
                                                                    "delete from member where id = @id; update Inmember Set kickdate= @abandoneddate where id = @id and kickdate is Null; commit tran t1;", con1);
                    using (SqlDataReader reader = cmdgetc.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdc.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                            cmdc.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                            cmdc.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                            cmdc.Parameters.AddWithValue("@id", String.Format("{0}", reader["id"]));
                            cmdc.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                            cmdc.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                            cmdc.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                            cmdc.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                            cmdc.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                            cmdc.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                            cmdc.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                            cmdc.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                            cmdc.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                            cmdc.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                            cmdc.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                            cmdc.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                            cmdc.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmdc.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmdc.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmdc.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmdc.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmdc.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + DescriptionTextBox.Text + "(خروج از پوشش خانواری به علت "+ reason +"در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmdc.Parameters.AddWithValue("@reason", DescriptionTextBox.Text + "(خروج از پوشش خانواری به علت " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmdc.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmdc.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmdc.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmdc.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                            cmdc.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                            cmdc.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmdc.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                            cmdc.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                            cmdc.Parameters.AddWithValue("@status", "خروج خانواری");
                            if (familyRegioncheckBox.Checked)
                                cmdc.Parameters.AddWithValue("@famReg", "بله");
                            else
                                cmdc.Parameters.AddWithValue("@famReg", "خیر");
                            if (financialcheckBox.Checked)
                                cmdc.Parameters.AddWithValue("@fin", "بله");
                            else
                                cmdc.Parameters.AddWithValue("@fin", "خیر");
                        }
                    }
                    cmdc.ExecuteNonQuery();
                    System.Globalization.PersianCalendar _persian = new System.Globalization.PersianCalendar();
                    foreach (var fm in doc)
                    {
                        string fileName = System.IO.Path.GetFileName(fm);
                        string targetPath = defaultPath + "\\" + this.fold + "\\" + i + "\\deletion";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        if (System.IO.File.Exists(destFile))
                        {
                            
                            destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + _persian.GetYear(DateTime.Now.Date).ToString()+ _persian.GetMonth(DateTime.Now.Date).ToString()+ _persian.GetDayOfMonth(DateTime.Now.Date).ToString() + ".pdf");
                        }
                        System.IO.File.Copy(fm, destFile, false);
                        cmdc = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                        cmdc.Parameters.AddWithValue("@id", i);
                        cmdc.Parameters.AddWithValue("@dname", fileName);
                        cmdc.Parameters.AddWithValue("@dpath", destFile);
                        cmdc.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmdc.Parameters.AddWithValue("@dtype", "deletion");
                        cmdc.ExecuteNonQuery();
                    }
                }
                SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, homephone, cellphone, address, explain, rate, marriage, insurance, orphan, student, folder_id, identifierName, identifierPhone, enactmentId from member where id = @tmp", con1);
                cmdget.Parameters.AddWithValue("@tmp", this.id);
                SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, abandoneddate, reason, enactmentId)" +
                                                                            " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @abandoneddate, @description, @eId); " +
                                                                "insert into outmember (id, setupdate, description, status, folder_id, familyRegion, financial) Values(@id, @setupdate, @description, @status, @folder_id, @famReg, @fin); " +
                                                                "delete from onindependency where id = @id;" +
                                                                "delete from member where id = @id; update Inmember Set kickdate= @abandoneddate where id = @id and kickdate is Null; commit tran t1;", con1);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                        cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                        cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                        cmd.Parameters.AddWithValue("@id", String.Format("{0}", reader["id"]));
                        cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                        cmd.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                        cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                        cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                        cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                        cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                        cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                        cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                        cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                        cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                        cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                        cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                        cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                        cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + DescriptionTextBox.Text + "(خروج از پوشش خانواری به علت " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                        cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                        cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                        cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        cmd.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text + "(خروج از پوشش خانواری به علت " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@status", "خروج خانواری");
                        if(familyRegioncheckBox.Checked)
                            cmd.Parameters.AddWithValue("@famReg", "بله");
                        else
                            cmd.Parameters.AddWithValue("@famReg", "خیر");
                        if (financialcheckBox.Checked)
                            cmd.Parameters.AddWithValue("@fin", "بله");
                        else
                            cmd.Parameters.AddWithValue("@fin", "خیر");
                    }
                }
                cmd.ExecuteNonQuery();
                foreach (var fm in doc)
                {
                    string fileName = System.IO.Path.GetFileName(fm);
                    string targetPath = defaultPath + "\\" + this.fold + "\\" + this.id + "\\deletion";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    if (System.IO.File.Exists(destFile))
                    {
                        destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + DateTime.Now.Date.ToPersian() + ".pdf");
                    }
                    System.IO.File.Copy(fm, destFile, false);
                    cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dtype", "deletion");
                    cmd.ExecuteNonQuery();
                }
                cmd = new SqlCommand("update research Set confirmed = @conf where id = (select max(research.id) from research, member where memberId = member.id and member.supporter_id = @sup and confirmed = N'خیر');", con1);
                cmd.Parameters.AddWithValue("@sup", this.id);
                cmd.Parameters.AddWithValue("@conf", "بله");
                cmd.ExecuteNonQuery();

                FMessegeBox.FarsiMessegeBox.Show("خانوار با موفقیت از پوشش خارج شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con1.Close();
                this.Close();
            }
            else
            {
                SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from member where supporter_id = @sup and id != @sup", con1);
                cmdcheck.Parameters.AddWithValue("@sup", this.id);
                int sup= 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sup = int.Parse(String.Format("{0}", reader["sup"]));
                    }
                }
                if (sup != 0)
                {
                    var newform = new changeSupporterForm(this.Text, this.id);
                    newform.ShowDialog(this);
                }
                sup = 0;
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sup = int.Parse(String.Format("{0}", reader["sup"]));
                    }
                }
                if (sup != 0)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این عضو سرپرست خانوار است و ابتدا باید وضعیت سرپرستی آنها را مشخص کنید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con1.Close();
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, homephone, cellphone, address, explain, rate, marriage, insurance, orphan, student, folder_id, identifierName, identifierPhone from member where id = @tmp", con1);
                    cmdget.Parameters.AddWithValue("@tmp", this.id);
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, abandoneddate, reason)" +
                                                                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @abandoneddate, @description); " +
                                                                    "insert into outmember (id, setupdate, description, status, folder_id, personRegion, dead, jobing, marry, service) Values(@id, @setupdate, @description, @status, @folder_id, @perReg, @dead, @jb, @mar, @serv); " +
                                                                    "delete from onindependency where id = @id;" +
                                                                    "delete from member where id = @id; update Inmember Set kickdate= @abandoneddate where id = @id and kickdate is Null; commit tran t1;", con1);
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
                            cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                            cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                            cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                            cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                            if (marrycheckBox.Checked)
                                cmd.Parameters.AddWithValue("@marriage", "متأهل");
                            else
                                cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                            cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                            cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]).ToString() + DescriptionTextBox.Text + "(خروج از پوشش فردی به علت " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                            cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                            cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmd.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text + "(خروج از پوشش فردی به علت " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmd.Parameters.AddWithValue("@status", "خروج فردی");
                            if (personRegioncheckBox.Checked)
                                cmd.Parameters.AddWithValue("@perReg", "بله");
                            else
                                cmd.Parameters.AddWithValue("@perReg", "خیر");
                            if (deadcheckBox.Checked)
                                cmd.Parameters.AddWithValue("@dead", "بله");
                            else
                                cmd.Parameters.AddWithValue("@dead", "خیر");
                            if (servicecheckBox.Checked)
                                cmd.Parameters.AddWithValue("@serv", "بله");
                            else
                                cmd.Parameters.AddWithValue("@serv", "خیر");
                            if (jobingcheckBox.Checked)
                                cmd.Parameters.AddWithValue("@jb", "بله");
                            else
                                cmd.Parameters.AddWithValue("@jb", "خیر");
                            if (marrycheckBox.Checked)
                                cmd.Parameters.AddWithValue("@mar", "بله");
                            else
                                cmd.Parameters.AddWithValue("@mar", "خیر");
                        }
                    }
                    cmd.ExecuteNonQuery();
                    foreach (var fm in doc)
                    {
                        string fileName = System.IO.Path.GetFileName(fm);
                        string targetPath = defaultPath + "\\" + this.fold + "\\" + this.id + "\\deletion";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        if (System.IO.File.Exists(destFile))
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + DateTime.Now.Date.ToPersian() + ".pdf");
                        }
                        System.IO.File.Copy(fm, destFile, false);
                        cmd = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@dpath", destFile);
                        cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@dtype", "deletion");
                        cmd.ExecuteNonQuery();
                    }
                    FMessegeBox.FarsiMessegeBox.Show("عضو با موفقیت از پوشش خارج شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con1.Close();
                    this.Close();
                }
                
            }
            
        }

        private void marrycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            marrydateTimePickerX.Enabled = marrycheckBox.Checked;
        }


        private void addFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب مدارک حذف";
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
}
