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
    public partial class editComebackForm2 : Form
    {
        string id;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string reason = "";
        bool man = false;
        string name, family, fold, ddate;
        DateTime tmp;
        public editComebackForm2(string p, string id)
        {
            InitializeComponent();
            this.Text = p;
            this.id = id;
        }

        private void editComebackForm2_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2, cmdgetdesc; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select sex from member where id = @id", con1);
            cmd2.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.Read())
                {
                    if(String.Format("{0}", reader["sex"]) == "مرد")
                    {
                        this.man = true;
                    }
                }
            }
            comebackmangroupBox.Hide();
            comebackwomangroupBox.Hide();
            if (this.man)
            {
                comebackmangroupBox.Show();
                cmd2 = new SqlCommand("select Inmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', lifehood as 'وضعیت معیشت', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', Inmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ رجعت', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member, Inmember where member.id = Inmember.id and Inmember.id = @sup and Inmember.kickdate is Null;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;

                cmdgetdesc = new SqlCommand("select familyFinancial, sick, description from Inmember where id = @sup", con1);
                cmdgetdesc.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdgetdesc.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DescriptionTextBox.Text = String.Format("{0}", reader["description"]);
                        if (String.Format("{0}", reader["familyFinancial"]) == "yes")
                        {
                            financialcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["sick"]) == "yes")
                        {
                            manhealthcheckBox.Checked = true;
                        }
                    }
                }
            }
            else
            {
                comebackwomangroupBox.Show();
                cmd2 = new SqlCommand("select Inmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', lifehood as 'وضعیت معیشت', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', Inmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ رجعت', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, Inmember where member.id = Inmember.id and Inmember.id = @sup and Inmember.kickdate is Null;", con1);
                cmd2.Parameters.AddWithValue("@sup", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;

                cmdgetdesc = new SqlCommand("select familyFinancial, sick, nonjob, single, cut, description from Inmember where id = @sup and Inmember.kickdate is Null", con1);
                cmdgetdesc.Parameters.AddWithValue("@sup", this.id);
                using (SqlDataReader reader = cmdgetdesc.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DescriptionTextBox.Text = String.Format("{0}", reader["description"]);
                        if (String.Format("{0}", reader["familyFinancial"]) == "yes")
                        {
                            womanfinancialcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["sick"]) == "yes")
                        {
                            womanhealthcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["cut"]) == "yes")
                        {
                            cutcheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["single"]) == "yes")
                        {
                            singlecheckBox.Checked = true;
                        }
                        if (String.Format("{0}", reader["nonjob"]) == "yes")
                        {
                            nonjobcheckBox.Checked = true;
                        }
                    }
                }
            }
            cmd2 = new SqlCommand("select abandoneddate from abandoned where id = @sup;", con1);
            cmd2.Parameters.AddWithValue("@sup", this.id);
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.Read())
                    tmp = Convert.ToDateTime(String.Format("{0}", reader["abandoneddate"])).Date;
            }
            this.fold = membersView.Rows[0].Cells["شماره پرونده"].Value.ToString();
            this.name = membersView.Rows[0].Cells["نام"].Value.ToString();
            this.family = membersView.Rows[0].Cells["نام خانوادگی"].Value.ToString();
            this.ddate = tmp.ToString();
            con1.Close();
        }

        private void editComebackForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ مدرکی برای رجعت انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from member where supporter_id = @sup and id != @sup", con1);
            cmdcheck.Parameters.AddWithValue("@sup", this.id);
            int sup = 0;
            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            if (sup != 0)
            {
                MessageBox.Show("این عضو سرپرست خانوار است و ابتدا باید رجعت اعضای تحت پوشش این فرد را ویرایش کنید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                con1.Close();
                return;
            }
            SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, comebackdate, legalYearAbandoned, outmember.description as desc from member, outmember, Inmember where member.id = outmember.id and Inmember.id = member.id and outmember.comebackdate = Inmember.setupdate and id = @tmp;", con1);
            cmdget.Parameters.AddWithValue("@tmp", this.id);
            SqlCommand cmd = new SqlCommand("begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, abandoneddate, reason, legalYearAbandoned)" +
                " Values(@name, @family, @fatherName, @prev_id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @abandoneddate, @reason, @legalYearAbandoned); delete from onindependency where id = @prev_id; delete from member where id = @prev_id; update outmember Set comebackdate = Null where comebackdate = @abandoneddate; " +
                " delete from Inmember where id = @prev_id; commit tran t1;", con1);
            cmd.Parameters.AddWithValue("@prev_id", this.id);
            SqlCommand cmdcomeback = new SqlCommand("update member Set supporter_id = @sup where folder_id = @fold", con1); bool suppo = false;
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
                    cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                    cmd.Parameters.AddWithValue("@lifehood", String.Format("{0}", reader["lifehood"]));
                    cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                    cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                    cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                    cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                    cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                    cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                    cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                    cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش رجعت عضو: لغو رجعت در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                    cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                    cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                    cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                    cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                    cmd.Parameters.AddWithValue("@abandoneddate", Convert.ToDateTime(String.Format("{0}", reader["comebackdate"])).Date);
                    cmd.Parameters.AddWithValue("@reason", Convert.ToDateTime(String.Format("{0}", reader["desc"])).Date);
                    cmd.Parameters.AddWithValue("@legalYearAbandoned", Convert.ToDateTime(String.Format("{0}", reader["legalYearAbandoned"])).Date);
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
                DialogResult res = MessageBox.Show("این عضو قبل از حذف، سرپرست بوده است آیا مجددا سرپرست گردد؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (res == DialogResult.Yes)
                {
                    cmdcomeback.ExecuteNonQuery();
                }
            }
            MessageBox.Show("لغو رجعت با موفقیت انجام شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            con1.Close();
            this.Close();
        }

        private void updateDesc_Click(object sender, EventArgs e)
        {
            bool isempty = true;
            if (this.man)
            {
                foreach (CheckBox cb in comebackmangroupBox.Controls)
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
                foreach (CheckBox cb in comebackwomangroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        reason += cb.Text + " و ";
                        isempty = false;
                    }
                }
            }

            if (isempty)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ علتی برای رجعت انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }

            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ مدرکی برای رجعت انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }

            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2, cmdgetexp;
            cmdgetexp = new SqlCommand("select explain from member where id = @sup", con1);
            cmdgetexp.Parameters.AddWithValue("@sup", this.id);
            cmd2 = new SqlCommand("begin tran t1; update Inmember Set description = @description, nonjob = @nonjob, sick = @sick, familyFinancial = @famfin, single = @single, cut = @cut where id = @sup and kickdate is Null; update member Set explain = @explain where id = @sup; commit tran t1;", con1);
            cmd2.Parameters.AddWithValue("@sup", this.id);
            cmd2.Parameters.AddWithValue("@description", newExplain.Text + "(ویرایش رجعت عضو: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
            if (manhealthcheckBox.Checked || womanhealthcheckBox.Checked)
                cmd2.Parameters.AddWithValue("@sick", "yes");
            else
                cmd2.Parameters.AddWithValue("@sick", "no");
            if (nonjobcheckBox.Checked)
                cmd2.Parameters.AddWithValue("@nonjob", "yes");
            else
                cmd2.Parameters.AddWithValue("@nonjob", "no");
            if (financialcheckBox.Checked || womanfinancialcheckBox.Checked)
                cmd2.Parameters.AddWithValue("@famfin", "yes");
            else
                cmd2.Parameters.AddWithValue("@famfin", "no");
            if (singlecheckBox.Checked)
                cmd2.Parameters.AddWithValue("@single", "yes");
            else
                cmd2.Parameters.AddWithValue("@single", "no");
            if (cutcheckBox.Checked)
                cmd2.Parameters.AddWithValue("@cut", "yes");
            else
                cmd2.Parameters.AddWithValue("@cut", "no");
            using (SqlDataReader reader = cmdgetexp.ExecuteReader())
            {
                if (reader.Read())
                {
                    cmd2.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش رجعت عضو: تغییر علت و یا ویرایش توضیحات: علل: " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                }
            }
            cmd2.ExecuteNonQuery();
        
        MessageBox.Show("تغییر علت و یا ویرایش توضیحات  با موفقیت انجام شد.", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            con1.Close();
            this.Close();
        }

        private void editFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک رجعت", this.id, "deletion", this.name, this.family, this.fold, this.ddate, this.Text);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                docLabel.BackColor = Color.Red;
            else
                docLabel.BackColor = Color.YellowGreen;
        }
    }
}
