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
    public partial class editMarriageForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id;
        string name, family;
        public editMarriageForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void editMarriageForm2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from married, abandoned where married.id = @id and married.id = abandoned.id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    idTextbox.Text = this.id.ToString();
                    nameTextBox.Text = String.Format("{0}", reader["name"]); nameTextBox.Enabled = false;
                    this.name = nameTextBox.Text;
                    familyTextBox.Text = String.Format("{0}", reader["family"]); familyTextBox.Enabled = false;
                    this.family = familyTextBox.Text;
                    marriedDescriptionTextBox.Text = String.Format("{0}", reader["description"]);
                    marriedTimePicker.Value = Convert.ToDateTime(String.Format("{0}", reader["marrieddate"]));
                }
            }
            con.Close();
        }

        private void setMarriageButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(idTextbox.Text, out res) && !idTextbox.Text.Any(char.IsWhiteSpace))
            {
                SqlConnection con1 = new SqlConnection(this.connection);
                con1.Open();

                int check = 0, check2 = 0;
                SqlCommand cmdcheck = new SqlCommand("select count(*) as checked from married where id = @id", con1);
                cmdcheck.Parameters.AddWithValue("@id", idTextbox.Text);
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        check = int.Parse(String.Format("{0}", reader["checked"]));
                    }
                }
                SqlCommand cmdcheck2 = new SqlCommand("select count(*) as checked from member where id = @id and sex = N'زن' and marriage != N'متأهل';", con1);
                cmdcheck2.Parameters.AddWithValue("@id", idTextbox.Text);
                using (SqlDataReader reader = cmdcheck2.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        check2 = int.Parse(String.Format("{0}", reader["checked"]));
                    }
                }
                if (check2 == 0)
                {
                    MessageBox.Show("عضو خانم نامتأهلی با این شماره ملی وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (check == 1 && this.id != idTextbox.Text)
                    MessageBox.Show("عضوی با این شماره ملی ازدواجش ثبت گردیده است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                else
                {
                    if (this.id == idTextbox.Text)
                    {
                        SqlCommand cmdgetexp = new SqlCommand("select explain from abandoned where id = @id", con1);
                        cmdgetexp.Parameters.AddWithValue("@id", this.id);
                        SqlCommand cmd1 = new SqlCommand("begin tran t1; update married Set marrieddate = @date, description = @description where id = @id; update abandoned Set explain = @explain where id = @id; commit tran t1;", con1);
                        cmd1.Parameters.AddWithValue("@id", this.id);
                        cmd1.Parameters.AddWithValue("@description", marriedDescriptionTextBox.Text + newExplain.Text + "(ویرایش ازدواج: ویرایش توضیحات ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                        cmd1.Parameters.AddWithValue("@date", marriedTimePicker.Value.Date);
                        using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmd1.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش ازدواج: ویرایش توضیحات ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            }
                        }
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("توضیحات جدید ازدواج عضو با موفقیت افزوده شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id from abandoned where id = @tmp;", con1);
                        cmdget.Parameters.AddWithValue("@tmp", this.id);
                        SqlCommand cmdget2 = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan , student, homephone, cellphone, address, explain, folder_id from member where id = @tmp", con1);
                        cmdget2.Parameters.AddWithValue("@tmp", idTextbox.Text);
                        SqlCommand cmd = new SqlCommand("begin tran t1; delete from married where id = @prev_id; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id)" +
                        " Values(@name, @family, @fatherName, @prev_id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id); delete from abandoned where id = @prev_id; " +
                        "insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id, abandoneddate)" +
                                " Values(@nname, @nfamily, @nfatherName, @nid, @nsupporter_id, @nsex, @njob, @nhouse, @nbirthdate, @nfolderdate, @ncheckdate, @nhealth, @nlifehood, @nmarriage, @nhomephone, @ncellphone, @naddress, @nexplain, @nfolder_id, @nabandoneddate); " +
                                "insert into married (id, marrieddate, description, setupdate, folder_id) Values(@nid, @nmarrieddate, @ndescription, @nabandoneddate, @nfolder_id); " +
                                "delete from member where id = @nid;" +
                                "commit tran t1;", con1);
                        cmd.Parameters.AddWithValue("@prev_id", this.id);
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                                cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                                cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                                cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                                cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                                cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                                cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                                cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                                cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                                cmd.Parameters.AddWithValue("@lifehood", String.Format("{0}", reader["lifehood"]));
                                cmd.Parameters.AddWithValue("@marriage", "مجرد");
                                cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                                cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                                cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                                cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش ازدواج: حذف ثبت ازدواج اشتباه شده در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                                cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                                cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                                cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                                cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                            }
                        }
                        using (SqlDataReader reader = cmdget2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmd.Parameters.AddWithValue("@nname", String.Format("{0}", reader["name"]));
                                cmd.Parameters.AddWithValue("@nfamily", String.Format("{0}", reader["family"]));
                                cmd.Parameters.AddWithValue("@nfatherName", String.Format("{0}", reader["fatherName"]));
                                cmd.Parameters.AddWithValue("@nid", idTextbox.Text);
                                cmd.Parameters.AddWithValue("@nsupporter_id", String.Format("{0}", reader["supporter_id"]));
                                cmd.Parameters.AddWithValue("@nsex", String.Format("{0}", reader["sex"]));
                                cmd.Parameters.AddWithValue("@njob", String.Format("{0}", reader["job"]));
                                cmd.Parameters.AddWithValue("@nhouse", String.Format("{0}", reader["house"]));
                                cmd.Parameters.AddWithValue("@nhealth", String.Format("{0}", reader["health"]));
                                cmd.Parameters.AddWithValue("@nlifehood", String.Format("{0}", reader["lifehood"]));
                                cmd.Parameters.AddWithValue("@nmarriage", "متأهل");
                                cmd.Parameters.AddWithValue("@nhomephone", String.Format("{0}", reader["homephone"]));
                                cmd.Parameters.AddWithValue("@ncellphone", String.Format("{0}", reader["cellphone"]));
                                cmd.Parameters.AddWithValue("@naddress", String.Format("{0}", reader["address"]));
                                cmd.Parameters.AddWithValue("@nexplain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش ازدواج: اصلاح شماره ملی اشتباه و در واقع ثبت درست ازدواج و خروج از پوشش به علت ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                                cmd.Parameters.AddWithValue("@nfolder_id", String.Format("{0}", reader["folder_id"]));
                                cmd.Parameters.AddWithValue("@nbirthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                                cmd.Parameters.AddWithValue("@nfolderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                                cmd.Parameters.AddWithValue("@ncheckdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                                cmd.Parameters.AddWithValue("@nmarrieddate", marriedTimePicker.Value.Date);
                                cmd.Parameters.AddWithValue("@nabandoneddate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@ndescription", marriedDescriptionTextBox.Text + newExplain.Text + "(ویرایش ازدواج: اصلاح شماره ملی اشتباه و در واقع ثبت درست ازدواج و خروج از پوشش به علت ازدواج در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            }
                        }
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" ازدواج عضو با موفقیت اصلاح شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }

                    con1.Close();

                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void DeleteMarriageButton_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(idTextbox.Text, out res) && !idTextbox.Text.Any(char.IsWhiteSpace))
            { 
                if (this.id == idTextbox.Text)
                {
                    SqlConnection con1 = new SqlConnection(this.connection);
                    con1.Open();
                    SqlCommand cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id from abandoned where id = @tmp;", con1);
                    cmdget.Parameters.AddWithValue("@tmp", this.id);
                    SqlCommand cmd = new SqlCommand("begin tran t1; delete from married where id = @prev_id; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, lifehood, marriage, orphan, student, homephone, cellphone, address, explain, folder_id)" +
                        " Values(@name, @family, @fatherName, @prev_id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @lifehood, @marriage, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id); delete from abandoned where id = @prev_id; commit tran t1;", con1);
                    cmd.Parameters.AddWithValue("@prev_id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                            cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                            cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                            cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                            cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                            cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                            cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                            cmd.Parameters.AddWithValue("@lifehood", String.Format("{0}", reader["lifehood"]));
                            cmd.Parameters.AddWithValue("@marriage", "مجرد");
                            cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                            cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                            cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                            cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + newExplain.Text + "(ویرایش ازدواج: حذف ازدواج اشتباه ثبت شده برای عضو و بازگشت به پوشش در تاریخ" + DateTime.Now.Date.ToString().Substring(8, 2) + "/" + DateTime.Now.Date.ToString().Substring(3, 2) + "/" + DateTime.Now.Date.ToString().Substring(0, 2) + ")");
                            cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                            cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                            cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                            cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ازدواج اشتباه ثبت شده برای عضو با موفقیت حذف شد", "تبریک!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    con1.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("نمی توانید عضو دیگری را حذف کنید، شماره ملی اشتباه است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setMarriageButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
            DeleteMarriageButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
            checkButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("setMarriageForm");
            newform.ShowDialog(this);
        }

        private void idTextbox_DoubleClick(object sender, EventArgs e)
        {
            idTextbox.Text = Clipboard.GetText();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            int res;
            if(int.TryParse(idTextbox.Text, out res) && !idTextbox.Text.Any(char.IsWhiteSpace))
            { 
                if (this.id != idTextbox.Text)
                {
                    SqlConnection con1 = new SqlConnection(this.connection);
                    con1.Open();
                    int c = 0;
                    SqlCommand cmdget = new SqlCommand("select count(*) as c from member where id = @tmp;", con1);
                    cmdget.Parameters.AddWithValue("@tmp", idTextbox.Text);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            c = int.Parse(String.Format("{0}", reader["c"]));
                        }
                    }
                    if (c == 1)
                    {
                        SqlCommand cmd = new SqlCommand("select name, family from member where id = @id and sex = N'زن' and marriage != N'متأهل';", con1);
                        cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nameTextBox.Text = String.Format("{0}", reader["name"]); nameTextBox.Enabled = false;
                                familyTextBox.Text = String.Format("{0}", reader["family"]); familyTextBox.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("عضو خانم غیر متأهلی با این شماره ملی یافت نشد!", "هشدار!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    con1.Close();
                }
                else
                {
                    nameTextBox.Text = this.name;
                    familyTextBox.Text = this.family;
                }
            }
            else
            {
                MessageBox.Show("!شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }
    }
}
