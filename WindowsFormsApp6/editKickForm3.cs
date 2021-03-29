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
    public partial class editKickForm3 : Form
    {
        string id, fold, name, family, ddate, profile;
        DateTime tmp;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string reason = "";
        public editKickForm3(string p, string id)
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
            this.profile = "";
        }

        private void editKickForm3_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2, cmdgetdesc; SqlDataAdapter da; DataTable dt;
            deleteFamilygroupBox.Hide();
            deletePersongroupBox.Hide();
            marrydateTimePickerX.Hide(); label3.Hide();
            if (this.Text == "ویرایش حذف پوشش خانوار")
            {
                deleteFamilygroupBox.Show();
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', lifehood as 'وضعیت معیشت', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(abandoneddate) as 'تاریخ حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned where supporter_id = @sup;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                cmdgetdesc = new SqlCommand("select financial, familyRegion, description from outmember where id = @sup", con1);
                cmdgetdesc.Parameters.AddWithValue("@sup", this.id);
                using(SqlDataReader reader = cmdgetdesc.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DescriptionTextBox.Text = String.Format("{0}", reader["description"]);
                        if(String.Format("{0}", reader["financial"]) == "بله")
                        {
                            financialcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["familyRegion"]) == "بله")
                        {
                            familyRegioncheckBox.Checked = true;
                        }
                    }
                }
            }
            else
            {
                deletePersongroupBox.Show();
                marrydateTimePickerX.Show(); label3.Show(); marrydateTimePickerX.Enabled = false;
                cmd2 = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', lifehood as 'وضعیت معیشت', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and status = N'خروج فردی' and outmember.id = @sup;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                cmd2.ExecuteNonQuery();
                da.Fill(dt);
                membersView.DataSource = dt;
                cmdgetdesc = new SqlCommand("select personRegion, dead, marry, service, jobing, description from outmember where id = @sup", con1);
                cmdgetdesc.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdgetdesc.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DescriptionTextBox.Text = String.Format("{0}", reader["description"]);
                        if (String.Format("{0}", reader["dead"]) == "بله")
                        {
                            deadcheckBox.Checked = true ;
                        }
                        if (String.Format("{0}", reader["personRegion"]) == "بله")
                        {
                            personRegioncheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["jobing"]) == "بله")
                        {
                            jobingcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["service"]) == "بله")
                        {
                            servicecheckBox.Checked = true ;
                        }
                        if (String.Format("{0}", reader["marry"]) == "بله")
                        {
                            marrycheckBox.Checked = true;
                        }
                    }
                }
            }
            cmd2 = new SqlCommand("select abandoneddate from abandoned where id = @sup;", con1);
            cmd2.Parameters.AddWithValue("@sup", this.id);
            using(SqlDataReader reader = cmd2.ExecuteReader())
            {
                if(reader.Read())
                    tmp = Convert.ToDateTime(String.Format("{0}", reader["abandoneddate"])).Date;
            }
            this.fold = membersView.Rows[0].Cells["شماره پرونده"].Value.ToString();
            this.name = membersView.Rows[0].Cells["نام"].Value.ToString();
            this.family = membersView.Rows[0].Cells["نام خانوادگی"].Value.ToString();
            this.ddate = tmp.ToString();
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

        private void editKickForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ مدرکی برای حذف انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            if (this.Text == "ویرایش حذف پوشش خانوار")
            {
                SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, enactmentId, abandoneddate from abandoned where id = @tmp;", con1);
                cmdget.Parameters.AddWithValue("@tmp", this.id);
                SqlCommand cmd = new SqlCommand("begin tran t1; insert into member(id, name, family, fatherName, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, homephone, cellphone, address, explain, folder_id, orphan, student, identifierName, identifierPhone, enactmentId)" +
                    " Values(@prev_id, @name, @family, @fatherName , @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @car, , @seyed, @marriage, @insurance, @homephone, @cellphone, @address, @explain, @folder_id, @orphan, @student, @iName, @iPhone, @eId); delete from abandoned where id = @prev_id; update Inmember Set kickdate= Null where id = @prev_id and kickdate = @abandoneddate; delete from outmember where id = @prev_id; commit tran t1;", con1);
                cmd.Parameters.AddWithValue("@prev_id", this.id);
                string sick = ""; DateTime birth = DateTime.Now;
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                        cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                        cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                        cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                        cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                        sick = String.Format("{0}", reader["health"]);
                        cmd.Parameters.AddWithValue("@health", sick);
                        cmd.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                        cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                        cmd.Parameters.AddWithValue("@insurance", String.Format("{0}", reader["insurance"]));
                        cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                        cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                        cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                        cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                        cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                        cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش خانوار: بازگشت به پوشش خانوار در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                        birth = Convert.ToDateTime(String.Format("{0}", reader["birthdate"]));
                        cmd.Parameters.AddWithValue("@birthdate", birth.Date);
                        cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                        cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        cmd.Parameters.AddWithValue("@abandoneddate", Convert.ToDateTime(String.Format("{0}", reader["abandoneddate"])).Date);
                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                        cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                        cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                    }
                }
                cmd.ExecuteNonQuery();
                DateTime now = DateTime.Now;
                if (/*sex == "مرد"*/ sick != "بیماری خاص" && now.Year - birth.Year < 18 || (now.Year - birth.Year == 18 && now.DayOfYear < birth.DayOfYear))
                {
                    SqlCommand cmdcheckexistance = new SqlCommand("select count(*) as exist from onindependency where id = @id", con1);
                    cmdcheckexistance.Parameters.AddWithValue("@id", this.id);
                    int exist = 0;
                    using (SqlDataReader reader = cmdcheckexistance.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exist = int.Parse(String.Format("{0}", reader["exist"]));
                        }
                    }
                    if (exist == 0)
                    {
                        SqlCommand addit = new SqlCommand("insert into onindependency(id) Values (@id);", con1);
                        addit.Parameters.AddWithValue("@id", this.id);
                        addit.ExecuteNonQuery();
                    }
                }
                List<string> li = new List<string>();
                string[] arr;
                SqlCommand cmdchild = new SqlCommand("select id from abandoned where supporter_id = @sup and id != @sup", con1);
                cmdchild.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdchild.ExecuteReader())
                {

                    while (reader.Read())
                        li.Add(reader.GetString(0));
                    arr = li.ToArray();
                }
                foreach (var i in arr)
                {
                    SqlCommand cmdgetc = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance,orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, enactmentId, abandoneddate from abandoned where id = @tmp;", con1);
                    cmdgetc.Parameters.AddWithValue("@tmp", i);
                    SqlCommand cmdc = new SqlCommand("begin tran t1; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, enactmentId)" +
                        " Values(@name, @family, @fatherName, @prev_id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @car, @seyed, @marriage, @insurance, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @eId); delete from abandoned where id = @prev_id; update Inmember Set kickdate= Null where id = @prev_id and kickdate = @abandoneddate; delete from outmember where id = @prev_id; commit tran t1;", con1);
                    cmdc.Parameters.AddWithValue("@prev_id", i);
                    using (SqlDataReader reader = cmdgetc.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdc.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                            cmdc.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                            cmdc.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                            cmdc.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                            cmdc.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                            cmdc.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                            cmdc.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                            sick = String.Format("{0}", reader["health"]);
                            cmdc.Parameters.AddWithValue("@health", sick);
                            cmdc.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                            cmdc.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                            cmdc.Parameters.AddWithValue("@insurance", String.Format("{0}", reader["insurance"]));
                            cmdc.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                            cmdc.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                            cmdc.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmdc.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmdc.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmdc.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش خانوار: بازگشت به پوشش خانوار در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmdc.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            birth = Convert.ToDateTime(String.Format("{0}", reader["birthdate"]));
                            cmdc.Parameters.AddWithValue("@birthdate", birth.Date);
                            cmdc.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmdc.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            cmd.Parameters.AddWithValue("@abandoneddate", Convert.ToDateTime(String.Format("{0}", reader["abandoneddate"])).Date);
                            cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                            cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                            cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                            cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                            cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                            cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                        }
                    }
                    cmdc.ExecuteNonQuery();
                    DateTime nowc = DateTime.Now;
                    if (/*sex == "مرد"*/ sick != "بیماری خاص" && nowc.Year - birth.Year < 18 || (nowc.Year - birth.Year == 18 && nowc.DayOfYear < birth.DayOfYear))
                    {
                        SqlCommand cmdcheckexistance = new SqlCommand("select count(*) as exist from onindependency where id = @id", con1);
                        cmdcheckexistance.Parameters.AddWithValue("@id", i);
                        int exist = 0;
                        using (SqlDataReader reader = cmdcheckexistance.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                exist = int.Parse(String.Format("{0}", reader["exist"]));
                            }
                        }
                        if (exist == 0)
                        {
                            SqlCommand addit = new SqlCommand("insert into onindependency(id) Values (@id);", con1);
                            addit.Parameters.AddWithValue("@id", i);
                            addit.ExecuteNonQuery();
                        }
                    }
                }
            }
            else
            {
                SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, enactmentId, abandoneddate from abandoned where id = @tmp;", con1);
                cmdget.Parameters.AddWithValue("@tmp", this.id);
                SqlCommand cmd = new SqlCommand("begin tran t1; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, enactmentId)" +
                    " Values(@name, @family, @fatherName, @prev_id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @car, @seyed, @marriage, @insurance, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @eId); delete from abandoned where id = @prev_id; update Inmember Set kickdate= Null where id = @prev_id and kickdate = @abandoneddate;  delete from outmember where id = @prev_id; commit tran t1;", con1);
                cmd.Parameters.AddWithValue("@prev_id", this.id);
                SqlCommand cmdcomeback = new SqlCommand("update member Set supporter_id = @sup where folder_id = @fold", con1); bool suppo = false; string sick = ""; DateTime birth = DateTime.Now;
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                        cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                        cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                        cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                        cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                        sick = String.Format("{0}", reader["health"]);
                        cmd.Parameters.AddWithValue("@health", sick);
                        cmd.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                        cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                        cmd.Parameters.AddWithValue("@insurance", String.Format("{0}", reader["insurance"]));
                        cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                        cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                        cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                        cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                        cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                        cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش فرد: بازگشت به پوشش فرد در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                        birth = Convert.ToDateTime(String.Format("{0}", reader["birthdate"]));
                        cmd.Parameters.AddWithValue("@birthdate", birth.Date);
                        cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                        cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        cmd.Parameters.AddWithValue("@abandoneddate", Convert.ToDateTime(String.Format("{0}", reader["abandoneddate"])).Date);
                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                        cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                        cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                        if (String.Format("{0}", reader["supporter_id"]) == this.id)
                        {
                            suppo = true;
                            cmdcomeback.Parameters.AddWithValue("@sup", this.id);
                            cmdcomeback.Parameters.AddWithValue("@fold", String.Format("{0}", reader["folder_id"]));
                        }
                    }
                }
                cmd.ExecuteNonQuery();
                if (suppo)
                {
                    
                    DialogResult res = FMessegeBox.FarsiMessegeBox.Show("این عضو قبل از حذف، سرپرست بوده است آیا مجددا سرپرست گردد؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (res == DialogResult.Yes)
                    {
                        cmdcomeback.ExecuteNonQuery();
                    }
                }
                DateTime nowc = DateTime.Now;
                if (/*sex == "مرد"*/ sick != "بیماری خاص" && nowc.Year - birth.Year < 18 || (nowc.Year - birth.Year == 18 && nowc.DayOfYear < birth.DayOfYear))
                {
                    SqlCommand cmdcheckexistance = new SqlCommand("select count(*) as exist from onindependency where id = @id", con1);
                    cmdcheckexistance.Parameters.AddWithValue("@id", this.id);
                    int exist = 0;
                    using (SqlDataReader reader = cmdcheckexistance.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exist = int.Parse(String.Format("{0}", reader["exist"]));
                        }
                    }
                    if (exist == 0)
                    {
                        SqlCommand addit = new SqlCommand("insert into onindependency(id) Values (@id);", con1);
                        addit.Parameters.AddWithValue("@id", this.id);
                        addit.ExecuteNonQuery();
                    }
                }
            }
            FMessegeBox.FarsiMessegeBox.Show("لغو حذف با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con1.Close();
            this.Close();
                
        }

        private void updateDesc_Click(object sender, EventArgs e)
        {
            bool isempty = true;
            if (this.Text == "ویرایش حذف پوشش خانوار")
            {
                foreach (CheckBox cb in deleteFamilygroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        reason += cb.Text + " و ";
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
                            reason += cb.Text + "در تاریخ " + marrydateTimePickerX.SelectedDateInDateTime.Date.ToPersian() + " و ";
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
            SqlCommand cmd2, cmdgetexp;
            if (this.Text == "ویرایش حذف پوشش خانوار")
            {
                List<string> li = new List<string>();
                string[] arr;
                SqlCommand cmdchild = new SqlCommand("select id from abandoned where supporter_id = @sup and id != @sup", con1);
                cmdchild.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdchild.ExecuteReader())
                {

                    while (reader.Read())
                        li.Add(reader.GetString(0));
                    arr = li.ToArray();
                }
                foreach(var i in arr)
                {
                    cmdgetexp = new SqlCommand("select explain from abandoned where id = @sup", con1);
                    cmdgetexp.Parameters.AddWithValue("@sup", i);
                    cmd2 = new SqlCommand("begin tran t1; update outmember Set description = @description, financial = @fin, familyRegion = @famReg where id = @sup; update abandoned Set reason = @description, explain = @explain where id = @sup; commit tran t1;", con1);
                    cmd2.Parameters.AddWithValue("@sup", i);
                    using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmd2.Parameters.AddWithValue("@description", newExplain.Text + "(ویرایش حذف پوشش خانوار: تغییر علت و یا ویرایش توضیحات: علل: "+ reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            cmd2.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش خانوار: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        }
                    }
                    if (familyRegioncheckBox.Checked)
                        cmd2.Parameters.AddWithValue("@famReg", "بله");
                    else
                        cmd2.Parameters.AddWithValue("@famReg", "خیر");
                    if (financialcheckBox.Checked)
                        cmd2.Parameters.AddWithValue("@fin", "بله");
                    else
                        cmd2.Parameters.AddWithValue("@fin", "خیر");
                    cmd2.ExecuteNonQuery();
                }
                cmdgetexp = new SqlCommand("select explain from abandoned where id = @sup", con1);
                cmdgetexp.Parameters.AddWithValue("@sup", this.id);
                cmd2 = new SqlCommand("begin tran t1; update outmember Set description = @description, financial = @fin, familyRegion = @famReg where id = @sup; update abandoned Set reason = @description, explain = @explain where id = @sup; commit tran t1;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                cmd2.Parameters.AddWithValue("@description", newExplain.Text + "(ویرایش حذف پوشش خانوار: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                if (familyRegioncheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@famReg", "بله");
                else
                    cmd2.Parameters.AddWithValue("@famReg", "خیر");
                if (financialcheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@fin", "بله");
                else
                    cmd2.Parameters.AddWithValue("@fin", "خیر");
                using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd2.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش خانوار: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    }
                }
                cmd2.ExecuteNonQuery();
            }
            else
            {
                cmdgetexp = new SqlCommand("select explain from abandoned where id = @sup", con1);
                cmdgetexp.Parameters.AddWithValue("@sup", this.id);
                cmd2 = new SqlCommand("begin tran t1; update outmember Set description = @description, dead = @dead, personRegion = @perReg, marry = @mar, jobing = @jb, service = @serv where id = @sup and comebackdate is Null; update abandoned Set explain = @explain, reason = @description where id = @sup; commit tran t1;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                cmd2.Parameters.AddWithValue("@description", newExplain.Text + "(ویرایش حذف پوشش فرد: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                if (personRegioncheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@perReg", "بله");
                else
                    cmd2.Parameters.AddWithValue("@perReg", "خیر");
                if (deadcheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@dead", "بله");
                else
                    cmd2.Parameters.AddWithValue("@dead", "خیر");
                if (servicecheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@serv", "بله");
                else
                    cmd2.Parameters.AddWithValue("@serv", "خیر");
                if (jobingcheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@jb", "بله");
                else
                    cmd2.Parameters.AddWithValue("@jb", "خیر");
                if (marrycheckBox.Checked)
                    cmd2.Parameters.AddWithValue("@mar", "بله");
                else
                    cmd2.Parameters.AddWithValue("@mar", "خیر");
                using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd2.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش حذف پوشش فرد: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    }
                }
                cmd2.ExecuteNonQuery();
            }
            FMessegeBox.FarsiMessegeBox.Show("تغییر علت و یا ویرایش توضیحات با موفقیت انجام شد.", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con1.Close();
            this.Close();
        }

        private void marrycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            marrydateTimePickerX.Enabled = marrycheckBox.Checked;
        }

        private void editFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک حذف", this.id, "deletion", this.name, this.family, this.fold, this.ddate, this.Text);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                docLabel.BackColor = Color.Red;
            else
                docLabel.BackColor = Color.YellowGreen;
        }
    }
}
