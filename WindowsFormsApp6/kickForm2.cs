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
    public partial class kickForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string applicantPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\applicant";
        string id;
        public kickForm2(string p)
        {
            InitializeComponent();
            this.Text = p;
            idTextbox.EnableContextMenu();
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "حذف پوشش فرد" || this.Text == "حذف پوشش خانوار" || this.Text == "ثبت تحقیق فردی" || this.Text == "ثبت تحقیق خانواری")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck;
                int sup = 0;
                if (this.Text == "حذف پوشش خانوار" || this.Text == "ثبت تحقیق خانواری")
                {
                    cmdcheck = new SqlCommand("select count(*) as sup from member where supporter_id = @sup and id != @sup", con);
                    cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {

                        //applicant
                        cmdcheck = new SqlCommand("select count(*) as sup from applicant where supporter_id = @sup and id != @sup", con);
                        cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                        using (SqlDataReader reader = cmdcheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sup = int.Parse(String.Format("{0}", reader["sup"]));
                            }
                        }
                        if (sup == 0)
                        {
                            //abandoned
                            cmdcheck = new SqlCommand("select count(*) as sup from abandoned, outmember where outmember.id = abandoned.id and abandoneddate=setupdate and status = N'خانواری' and supporter_id = @sup and abandoned.id != @sup", con);
                            cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdcheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                                }
                            }
                            if (sup == 0)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در لیست موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                con.Close();
                                return;
                            }
                            else
                            {
                                // confirm last research
                                string fol = "", rId = "", conf = "", memId = "", stat = "";
                                cmdcheck = new SqlCommand("select confirmed, research.id as resId, memberId as memId, status from research where id = (select max(research.id) from research, abandoned where memberId = abandoned.id and abandoned.supporter_id = @sup);", con);
                                cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        conf = String.Format("{0}", reader["confirmed"]);
                                        rId = String.Format("{0}", reader["resId"]);
                                        memId = String.Format("{0}", reader["memId"]);
                                        stat = String.Format("{0}", reader["status"]);
                                    }
                                }
                                if (conf == "خیر")
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("ابتدا باید تحقیق قبلی را تایید نمایید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    confirmResForm newform;
                                    if (stat == "فردی")
                                        newform = new confirmResForm("تایید تحقیق فردی", rId, fol, memId);
                                    else
                                        newform = new confirmResForm("تایید تحقیق خانواری", rId, fol, memId);
                                    newform.ShowDialog(this);
                                    if (newform.Text == "confirmed")
                                    {
                                        conf = "بله";
                                    }
                                }
                                if (conf != "خیر")
                                {
                                    var newform = new setResearchForm(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text), "CB");
                                    newform.ShowDialog(this);
                                }
                            }
                        }
                        else
                        {
                            // confirm last research
                            string fol = "", rId = "", conf = "", memId = "", stat = "";
                            cmdcheck = new SqlCommand("select confirmed, research.id as resId, memberId as memId, status from research where id = (select max(research.id) from research, applicant where memberId = applicant.id and applicant.supporter_id = @sup);", con);
                            cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdcheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    conf = String.Format("{0}", reader["confirmed"]);
                                    rId = String.Format("{0}", reader["resId"]);
                                    memId = String.Format("{0}", reader["memId"]);
                                    stat = String.Format("{0}", reader["status"]);
                                }
                            }
                            if (conf == "خیر")
                            {
                                FMessegeBox.FarsiMessegeBox.Show("ابتدا باید تحقیق قبلی را تایید نمایید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                confirmResForm newform;
                                if (stat == "فردی")
                                    newform = new confirmResForm("تایید تحقیق فردی", rId, fol, memId);
                                else
                                    newform = new confirmResForm("تایید تحقیق خانواری", rId, fol, memId);
                                newform.ShowDialog(this);
                                if (newform.Text == "confirmed")
                                {
                                    conf = "بله";
                                }
                            }
                            if (conf != "خیر")
                            {
                                var newform = new setResearchForm(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text), "enter");
                                newform.ShowDialog(this);
                            }
                        }
                    }
                    else
                    {
                        if (this.Text == "حذف پوشش خانوار")
                        {
                            var newform2 = new kickForm3(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            newform2.ShowDialog(this);
                        }
                        else
                        {
                            // confirm last research
                            SqlCommand cmdgetfol = new SqlCommand("select folder_id as fol from member where id = @id;", con);
                            cmdgetfol.Parameters.AddWithValue("@id", id);
                            string fol = "", rId = "", conf = "", memId = "", stat = "";
                            using (SqlDataReader reader = cmdgetfol.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    fol = String.Format("{0}", reader["fol"]);
                                }
                            }
                            cmdcheck = new SqlCommand("select confirmed, research.id as resId, memberId as memId, status from research where id = (select max(research.id) from research, member where memberId = member.id and folder_id = @fol);", con);
                            cmdcheck.Parameters.AddWithValue("@fol", fol);

                            using (SqlDataReader reader = cmdcheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    conf = String.Format("{0}", reader["confirmed"]);
                                    rId = String.Format("{0}", reader["resId"]);
                                    memId = String.Format("{0}", reader["memId"]);
                                    stat = String.Format("{0}", reader["status"]);
                                }
                            }
                            if (conf == "خیر")
                            {
                                FMessegeBox.FarsiMessegeBox.Show("ابتدا باید تحقیق قبلی را تایید نمایید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                confirmResForm newform;
                                if (stat == "فردی")
                                    newform = new confirmResForm("تایید تحقیق فردی", rId, fol, memId);
                                else
                                    newform = new confirmResForm("تایید تحقیق خانواری", rId, fol, memId);
                                newform.ShowDialog(this);
                                if (newform.Text == "confirmed")
                                {
                                    conf = "بله";
                                }
                            }
                            if (conf != "خیر")
                            {
                                var newform = new setResearchForm(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text), "period");
                                newform.ShowDialog(this);
                            }
                        }

                    }
                }
                else
                {
                    cmdcheck = new SqlCommand("select count(*) as sup from member where id = @sup", con);
                    cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {
                        if (this.Text == "حذف پوشش فرد")
                        {
                            FMessegeBox.FarsiMessegeBox.Show("شماره ملی فرد در لیست موجود نیست یا این خانوار تک عضوی است و باید از طریق حذف خانواری اقدام شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            con.Close();
                            return;
                        }
                        else
                        {
                            //abandoned
                            cmdcheck = new SqlCommand("select count(*) as sup from abandoned where id = @sup", con);
                            cmdcheck.Parameters.AddWithValue("@sup", id);
                            using (SqlDataReader reader = cmdcheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                                }
                            }
                            if (sup == 0)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("شماره ملی فرد در لیست موجود نیست یا این خانوار تک عضوی است و باید از طریق تحقیق خانواری اقدام شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                con.Close();
                                return;
                            }
                            else
                            {
                                // confirm last research
                                string fol = "", rId = "", conf = "", memId = "", stat = "";
                                cmdcheck = new SqlCommand("select confirmed, research.id as resId, memberId as memId, status from research where id = (select max(research.id) from research, abandoned where memberId = abandoned.id and abandoned.id = @sup);", con);
                                cmdcheck.Parameters.AddWithValue("@sup", id);
                                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        conf = String.Format("{0}", reader["confirmed"]);
                                        rId = String.Format("{0}", reader["resId"]);
                                        memId = String.Format("{0}", reader["memId"]);
                                        stat = String.Format("{0}", reader["status"]);
                                    }
                                }
                                if (conf == "خیر")
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("ابتدا باید تحقیق قبلی را تایید نمایید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    confirmResForm newform;
                                    if (stat == "فردی")
                                        newform = new confirmResForm("تایید تحقیق فردی", rId, fol, memId);
                                    else
                                        newform = new confirmResForm("تایید تحقیق خانواری", rId, fol, memId);
                                    newform.ShowDialog(this);
                                    if (newform.Text == "confirmed")
                                    {
                                        conf = "بله";
                                    }
                                }
                                if (conf != "خیر")
                                {
                                    var newform = new setResearchForm(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text), "CB");
                                    newform.ShowDialog(this);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.Text == "حذف پوشش فرد")
                        {
                            var newform = new kickForm3(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            newform.ShowDialog(this);
                        }
                        else
                        {
                            SqlCommand cmdgetfol = new SqlCommand("select folder_id as fol from member where id = @id;", con);
                            cmdgetfol.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            string fol = "", rId = "", conf = "", memId = "", stat = "";
                            using (SqlDataReader reader = cmdgetfol.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    fol = String.Format("{0}", reader["fol"]);
                                }
                            }
                            cmdcheck = new SqlCommand("select distinct confirmed, research.id as resId, memberId as memId, status from research where id = (select max(research.id) from research, member where memberId = member.id and folder_id = @fol);", con);
                            cmdcheck.Parameters.AddWithValue("@fol", fol);

                            using (SqlDataReader reader = cmdcheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    conf = String.Format("{0}", reader["confirmed"]);
                                    rId = String.Format("{0}", reader["resId"]);
                                    memId = String.Format("{0}", reader["memId"]);
                                    stat = String.Format("{0}", reader["status"]);
                                }
                            }
                            if (conf == "خیر")
                            {
                                FMessegeBox.FarsiMessegeBox.Show("ابتدا باید تحقیق قبلی را تایید نمایید!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                confirmResForm newform;
                                if (stat == "فردی")
                                    newform = new confirmResForm("تایید تحقیق فردی", rId, fol, memId);
                                else
                                    newform = new confirmResForm("تایید تحقیق خانواری", rId, fol, memId);
                                newform.ShowDialog(this);
                                if (newform.Text == "confirmed")
                                {
                                    conf = "بله";
                                }
                            }
                            if (conf != "خیر")
                            {
                                var newform = new setResearchForm(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text), "period");
                                newform.ShowDialog(this);
                            }
                        }
                    }
                }
                
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdcheck, cmdget, cmdgettyp, cmddel, cmdgetexp, cmdupexp;
                int sup = 0;
                if (this.Text == "ویرایش حذف پوشش خانوار")
                {
                    cmdcheck = new SqlCommand("select count(*) as sup from outmember, abandoned where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج خانواری' and supporter_id = outmember.id and outmember.id = @sup;", con);
                    cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در لیست حذف پوشش خانوار موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        return;
                    }
                    else
                    {
                        var newform = new editKickForm3(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text));
                        newform.ShowDialog(this);
                    }
                }
                else if (this.Text == "ویرایش حذف پوشش فرد")
                {
                    cmdcheck = new SqlCommand("select count(*) as sup from outmember, abandoned where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج فردی' and outmember.id = @sup", con);
                    cmdcheck.Parameters.AddWithValue("@sup", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی عضو در لیست حذف پوشش موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        return;
                    }
                    else
                    {
                        var newform = new editKickForm3(this.Text, ExtensionFunction.PersianToEnglish(idTextbox.Text));
                        newform.ShowDialog(this);
                    }
                }
                else if (this.Text == "حذف تحقیق خانواری")
                {
                    string folder = "", memId = "", typ = "";
                    cmdgettyp = new SqlCommand("select distinct(rtype) from research where id = @id;", con);
                    cmdgettyp.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdgettyp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            typ = String.Format("{0}", reader["rtype"]);
                        }
                    }
                    if (typ == "ورود")
                    {
                        cmdcheck = new SqlCommand("select count(*) as sup from research, applicant where status = N'خانواری' and memberId=applicant.id and supporter_id=applicant.id and research.id = @id and confirmed = N'خیر';", con);
                    }
                    else if (typ == "رجعت")
                    {
                        cmdcheck = new SqlCommand("select count(*) as sup from research, abandoned where status = N'خانواری' and memberId=abandoned.id and supporter_id=abandoned.id and research.id = @id and confirmed = N'خیر';", con);
                    }
                    else
                    {
                        cmdcheck = new SqlCommand("select count(*) as sup from research, member where status = N'خانواری' and memberId=member.id and supporter_id=member.id and research.id = @id and confirmed = N'خیر';", con);
                    }
                    cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("تحقیق قابل حذفی با این شماره موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        return;
                    }
                    else
                    {
                        DialogResult resu = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به حذف این تحقیق مطمئن هستید؟", "توجه!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        if (resu != DialogResult.Yes)
                        {
                            con.Close();
                            return;
                        }


                        if (typ == "ورود")
                        {
                            cmdget = new SqlCommand("select memberId from applicant, research where research.id = @id and memberId = applicant.id and applicant.id = supporter_id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                        }
                        else if (typ == "رجعت")
                        {
                            cmdget = new SqlCommand("select memberId, folder_id from abandoned, research where research.id = @id and memberId = abandoned.id and abandoned.id = supporter_id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    folder = String.Format("{0}", reader["folder_id"]);
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                        }
                        else
                        {
                            cmdget = new SqlCommand("select memberId, folder_id from member, research where research.id = @id and memberId = member.id and member.id = supporter_id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    folder = String.Format("{0}", reader["folder_id"]);
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                        }

                        List<string> li = new List<string>();
                        string[] arr;
                        SqlCommand cmdchild;
                        if (typ == "ورود")
                        {
                            cmdchild = new SqlCommand("select id from applicant where supporter_id = @sup", con);
                        }
                        else if (typ == "رجعت")
                        {
                            cmdchild = new SqlCommand("select id from abandoned where supporter_id = @sup", con);
                        }
                        else
                        {
                            cmdchild = new SqlCommand("select id from member where supporter_id = @sup", con);
                        }

                        cmdchild.Parameters.AddWithValue("@sup", memId);
                        using (SqlDataReader reader = cmdchild.ExecuteReader())
                        {

                            while (reader.Read())
                                li.Add(reader.GetString(0));
                            arr = li.ToArray();
                        }
                        foreach (var i in arr)
                        {
                            string path = "";
                            if (typ == "ورود")
                            {
                                path = this.applicantPath + "\\" + i + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                                cmdgetexp = new SqlCommand("select explain from applicant where id = @i", con);
                                cmdupexp = new SqlCommand("update applicant Set explain = @exp", con);
                            }
                            else if (typ == "رجعت")
                            {
                                path = this.defaultPath + "\\" + folder + "\\" + i + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                                cmdgetexp = new SqlCommand("select explain from abandoned where id = @i", con);
                                cmdupexp = new SqlCommand("update abandoned Set explain = @exp", con);
                            }
                            else
                            {
                                path = this.defaultPath + "\\" + folder + "\\" + i + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                                cmdgetexp = new SqlCommand("select explain from member where id = @i", con);
                                cmdupexp = new SqlCommand("update member Set explain = @exp", con);
                            }

                            cmdgetexp.Parameters.AddWithValue("@i", i);
                            using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                            {
                                if (reader.Read())
                                    cmdupexp.Parameters.AddWithValue("@exp", String.Format("{0}", reader["explain"]) + "(حذف تحقیق خانواری " + typ + " به شماره " + ExtensionFunction.PersianToEnglish(idTextbox.Text) + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                            }
                            cmdupexp.ExecuteNonQuery();
                            cmddel = new SqlCommand("begin tran t1; delete from doc where researchId = @resId; delete from research where id = @resId; commit tran t1;", con);
                            cmddel.Parameters.AddWithValue("@resId", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            System.IO.Directory.Delete(path, true);
                            cmddel.ExecuteNonQuery();
                            FMessegeBox.FarsiMessegeBox.Show("تحقیق خانواری با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        }

                    }
                }
                else
                {
                    string folder = "", memId = "", typ = "";
                    cmdgettyp = new SqlCommand("select distinct(rtype) from research where id = @id;", con);
                    cmdgettyp.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdgettyp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            typ = String.Format("{0}", reader["rtype"]);
                        }
                    }
                    if (typ == "ورود")
                    {
                        cmdcheck = new SqlCommand("select count(*) as sup from research, applicant where status = N'فردی' and memberId=applicant.id and research.id = @id", con);
                    }
                    else if (typ == "رجعت")
                    {
                        cmdcheck = new SqlCommand("select count(*) as sup from research, abandoned where status = N'فردی' and memberId=abandoned.id and research.id = @id", con);
                    }
                    else
                    {
                        cmdcheck = new SqlCommand("select count(*) from research, member where status = N'فردی' and memberId=member.id and research.id = @id", con);
                    }

                    cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("تحقیق قابل حذفی با این شماره موجود نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        return;
                    }
                    else
                    {
                        DialogResult resu = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به حذف این تحقیق مطمئن هستید؟", "توجه!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        if (resu != DialogResult.Yes)
                        {
                            con.Close();
                            return;
                        }

                        string path = "";
                        if (typ == "ورود")
                        {
                            cmdget = new SqlCommand("select memberId from applicant, research where research.id = @id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                            path = this.applicantPath + "\\" + memId + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                            cmdgetexp = new SqlCommand("select explain from applicant where id = @i", con);
                            cmdupexp = new SqlCommand("update applicant Set explain = @exp", con);
                        }
                        else if (typ == "رجعت")
                        {
                            cmdget = new SqlCommand("select memberId, folder_id from abandoned, research where research.id = @id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    folder = String.Format("{0}", reader["folder_id"]);
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                            path = this.defaultPath + "\\" + folder + "\\" + memId + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                            cmdgetexp = new SqlCommand("select explain from abandoned where id = @i", con);
                            cmdupexp = new SqlCommand("update abandoned Set explain = @exp", con);
                        }
                        else
                        {
                            cmdget = new SqlCommand("select memberId, folder_id from member, research where research.id = @id", con);
                            cmdget.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    folder = String.Format("{0}", reader["folder_id"]);
                                    memId = String.Format("{0}", reader["memberId"]);
                                }
                            }
                            path = this.defaultPath + "\\" + folder + "\\" + memId + "\\" + ExtensionFunction.PersianToEnglish(idTextbox.Text);
                            cmdgetexp = new SqlCommand("select explain from member where id = @i", con);
                            cmdupexp = new SqlCommand("update member Set explain = @exp", con);
                        }

                        cmdgetexp.Parameters.AddWithValue("@i", memId);
                        using (SqlDataReader reader = cmdgetexp.ExecuteReader())
                        {
                            if (reader.Read())
                                cmdupexp.Parameters.AddWithValue("@exp", String.Format("{0}", reader["explain"]) + "(حذف تحقیق فردی " + typ + " به شماره " + ExtensionFunction.PersianToEnglish(idTextbox.Text) + " در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        }
                        cmdupexp.ExecuteNonQuery();
                        cmddel = new SqlCommand("begin tran t1; delete from doc where researchId = @resId; delete from research where id = @resId; commit tran t1;", con);
                        cmddel.Parameters.AddWithValue("@resId", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                        System.IO.Directory.Delete(path, true);
                        cmddel.ExecuteNonQuery();
                        FMessegeBox.FarsiMessegeBox.Show("تحقیق فردی با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                }
                con.Close();
            }
            
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void kickForm2_Load(object sender, EventArgs e)
        {
            setButton.Enabled = false;
            switch (this.Text)
            {
                case "ویرایش حذف پوشش فرد":
                case "ویرایش حذف پوشش خانوار":
                    this.BackColor = Color.Yellow;
                    break;
                case "ثبت تحقیق فردی":
                    this.BackColor = Color.LightSeaGreen;
                    setButton.BackColor = Color.Turquoise;
                    setButton.FlatAppearance.BorderColor = Color.DarkCyan;
                    searchAbandonedButton.Visible = true;
                    break;
                case "ثبت تحقیق خانواری":
                    this.BackColor = Color.LightSeaGreen;
                    setButton.BackColor = Color.Turquoise;
                    setButton.FlatAppearance.BorderColor = Color.DarkCyan;
                    searchApplicantButton.Visible = true;
                    searchAbandonedButton.Visible = true;
                    break;
                case "حذف تحقیق فردی":
                case "حذف تحقیق خانواری":
                    searchButton.Text = "جستجو";
                    break;
                default:
                    break;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm(this.Text);
            newform.ShowDialog(this);
            if(newform.Text.StartsWith("choose"))
            {
                id = idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }

        private void searchApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("متقاضی");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                id = idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void searchAbandonedButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("رجعت عضو");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                id = idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }
    }
}
