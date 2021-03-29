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
    public partial class searchForm : Form
    {
        private string form;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public searchForm(string form)
        {
            InitializeComponent();
            this.form = form;
            if (this.form == "ثبت تحقیق فردی")
                this.form = "حذف پوشش فرد";
            else if (this.form == "ثبت تحقیق خانواری")
                this.form = "حذف پوشش خانوار";
        }

        private void searchForm_Load(object sender, EventArgs e)
        {
            chooseButton.Enabled = searchButton.Enabled = searchByFolderbutton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            if (this.form == "setMarriageForm")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', marriage as 'وضعیت تاهل', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where sex = N'زن' and marriage != N'متأهل' ", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "editMarriageForm")
            {
                cmd2 = new SqlCommand("select married.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', dbo.MiladiTOShamsi(marrieddate) as 'تاریخ ازدواج', married.description as 'توضیحات ازدواج', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from married, abandoned where married.id = abandoned.id", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "حذف پوشش خانوار")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[16].DefaultCellStyle.WrapMode = membersView.Columns[17].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[18].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "حذف پوشش فرد")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member ;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش خانوار")
            {
                cmd2 = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج خانواری' and supporter_id = outmember.id and abandoned.id = supporter_id;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش فرد")
            {
                cmd2 = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج فردی';", con1);
                da = new SqlDataAdapter(cmd2);
                //cmd2.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش عضو")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate)as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format =  "#,##;#,##-";
            }
            else if (this.form == "رجعت عضو")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(abandoneddate) as 'تاریخ تعلیق', reason as 'دلیل تعلیق', legalYearAbandoned as 'خروج در 18سالگی', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش رجعت عضو")
            {
                cmd2 = new SqlCommand("select Inmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', Inmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ رجعت', Inmember.description as 'توضیحات رجعت', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member, Inmember where member.id = Inmember.id and Inmember.kickdate is Null;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                //cmd2.ExecuteNonQuery();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق خانواری")
            {
                cmd2 = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'خانواری' and memberId=member.id and supporter_id=member.id;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق فردی")
            {
                cmd2 = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'فردی' and memberId=member.id;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "متقاضی")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(subdate)as 'تاریخ ثبت تقاضا', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from applicant", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount-1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "متقاضی سایر")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate)as 'تاریخ عضویت', phone as 'شماره تلفن', address as آدرس, explain as توضیحات from otherApplicant;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "تقاضا جدید مددجو")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تقاضا جدید متقاضی")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate)as 'تاریخ عضویت', phone as 'شماره تلفن', address as آدرس, explain as توضیحات from otherApplicant", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش تقاضا")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', description as توضیحات from request where applicantId = sup and result is NULL;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش بررسی")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and result is not Null and deliveryDate is Null;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ثبت ارائه معرفی‌نامه")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and result = N'تایید' and deliveryDate is Null;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش ارائه معرفی‌نامه")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', dbo.MiladiTOShamsi(deliveryDate) as 'تاریخ ارائه', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and deliveryDate is not Null;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if(this.form == "ویرایش مصوبه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible =  false;
                label3.Text = "شماره مصوبه";
                cmd2 = new SqlCommand("select id as 'شماره مصوبه', docname as 'نام قایل مصوبه' from enactment;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (this.form == "ویرایش کمک جمعی با مصوبه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where defType = N'با مصوبه' and (status = N'تعریف شده' or status = N'در حال ارائه');", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک جمعی اتفاقی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where defType = N'اتفاقی' and (status = N'تعریف شده' or status = N'در حال ارائه');", con1); 
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک جمعی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where (status = N'تعریف شده' or status = N'در حال ارائه') and startdate <= @now;", con1);
                cmd2.Parameters.AddWithValue("@now", DateTime.Now.Date);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک جمعی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک جمعی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک جمعی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک تحصیلی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'تعریف شده' or status = N'در حال ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک تحصیلی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'تعریف شده' or status = N'در حال ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک تحصیلی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک تحصیلی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک تحصیلی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک ازدواج")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where marriage != N'متأهل';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'ثبت شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'ثبت شده' or status = N'ثبت شده نقدی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and (MarryHelps.status = N'ارسال معرفی‌نامه' or MarryHelps.status = N'ارائه');", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک ازدواج ردشده")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'رد شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارسال معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'ارسال معرفی‌نامه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش ارسال معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'دریافت نتیجه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'دریافت نتیجه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش نتیجه معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and ((MarryHelps.status = N'پایان‌یافته: رد معرفی‌نامه' and MarryHelpReq.status = N'ثبت شده نقدی') or (MarryHelps.status = N'ارائه'));", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and ((MarryHelps.status = N'پایان‌یافته: رد معرفی‌نامه' and MarryHelpReq.status = N'ثبت شده نقدی') or (MarryHelps.status = N'ارائه'));", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(MarryHelps.confirmdate) as 'تاریخ تایید', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelps.fenactmentId as 'شماره مصوبه پایانی', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک درمان")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'ثبت شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'ثبت شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک درمان ردشده")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'رد شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک درمان")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(HealHelps.confirmdate) as 'تاریخ تایید', HealHelps.enactmentId as 'شماره مصوبه', HealHelps.fenactmentId as 'شماره مصوبه پایانی', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک متفرقه گروهی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'تعریف شده' or status = N'در حال ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک متفرقه گروهی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where (status = N'تعریف شده' or status = N'در حال ارائه') and startdate <= @now;", con1);
                cmd2.Parameters.AddWithValue("@now", DateTime.Now.Date);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک متفرقه گروهی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک متفرقه گروهی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'پایان‌یافته';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک متفرقه گروهی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک متفرقه فردی")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'ثبت شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'ثبت شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک متفرقه فردی ردشده")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره درخواست";
                cmd2 = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'رد شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'ارائه';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'پایان‌یافته: ارائه شده';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک متفرقه فردی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(OtherHelpsIndiv.confirmdate) as 'تاریخ تایید', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpsIndiv.fenactmentId as 'شماره مصوبه پایانی', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'نهایی';", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش انتقال وجه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره تراکنش";
                cmd2 = new SqlCommand("select id as 'شماره تراکنش', srcid as 'شماره حساب مبدا', dstid as 'شمار حساب مقصد', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(transferdate) as 'تاریخ انتقال', cast(fee as decimal(15,0)) as 'ارزش ریالی', cast(fee as decimal(15,0)) as 'کارمزد', transporterName as 'انتقال‌دهنده', description as 'توضیحات' from moneyTransfer;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش اطلاعات مددکار")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', phone as 'شماره تلفن', address as 'آدرس' from helper;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش کمک دریافتی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک دریافتی', fee as 'ارزش ریالی', packet as 'تعداد بسته', dbo.MiladiTOShamsi(recdate) as 'تاریخ دریافت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', helperId as 'شماره ملی مددکار', helperName as 'نام مددکار', bankAccountName as 'نام حساب', bankAccountId as 'شماره حساب',description as 'توضیحات' from recHelps;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[9].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش کمک خریده‌شده")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd2 = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', fee as 'ارزش ریالی', packet as 'تعداد بسته', dbo.MiladiTOShamsi(buydate) as 'تاریخ خرید', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', buyerName as 'نام خریدار', bankAccountName as 'نام حساب', bankAccountId as 'شماره حساب', description as 'توضیحات' from buyHelps;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[9].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش نامه ارسالی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره نامه";
                searchByFolderbutton.Enabled = foldertextBox.Enabled = false;
                cmd2 = new SqlCommand("select id as 'شماره نامه', title as 'عنوان', receiver as 'گیرنده', signer as 'امضاکننده', attachment as 'پیوست', dbo.MiladiTOShamsi(senddate) as 'تاریخ ارسال', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت' from sendingLetters;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[1].DefaultCellStyle.WrapMode = membersView.Columns[2].DefaultCellStyle.WrapMode = membersView.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش نامه دریافتی")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره نامه";
                searchByFolderbutton.Enabled = foldertextBox.Enabled = false;
                cmd2 = new SqlCommand("select id as 'شماره یکتا', id_i as 'شماره نامه', title as 'عنوان', sender as 'فرستنده', signer as 'امضاکننده', attachment as 'پیوست', dbo.MiladiTOShamsi(recdate) as 'تاریخ دریافت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت' from receivedLetters;", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[2].DefaultCellStyle.WrapMode = membersView.Columns[3].DefaultCellStyle.WrapMode = membersView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "انتخاب خانوار")
            {
                cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1", con1);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            con1.Close();
        }
        

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !string.IsNullOrEmpty(nameTextbox.Text) && !string.IsNullOrWhiteSpace(nameTextbox.Text);
            if(!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.searchForm_Load(sender, e);
            }
        }

        private void familyTextbox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !string.IsNullOrEmpty(familyTextbox.Text) && !string.IsNullOrWhiteSpace(familyTextbox.Text);
            if (!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.searchForm_Load(sender, e);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            if (this.form == "setMarriageForm")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where sex = N'زن' and marriage != N'متأهل' and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if(this.form == "editMarriageForm")
            {
                cmd = new SqlCommand("select married.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', dbo.MiladiTOShamsi(marrieddate) as 'تاریخ ازدواج', married.description as 'توضیحات ازدواج', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from married, abandoned where married.id = abandoned.id and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "حذف پوشش خانوار")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "حذف پوشش فرد")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where  name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش خانوار")
            {
                cmd = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج خانواری' and supporter_id = outmember.id and abandoned.id = supporter_id and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش فرد")
            {
                cmd = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن' annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج فردی' and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if(this.form == "ویرایش عضو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "رجعت عضو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(abandoneddate) as 'تاریخ تعلیق', reason as 'دلیل تعلیق', legalYearAbandoned as 'خروج در 18سالگی', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', folderdate as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from abandoned where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش رجعت عضو")
            {
                cmd = new SqlCommand("select Inmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', Inmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ رجعت', Inmember.description as 'توضیحات رجعت', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member, Inmember where member.id = Inmember.id and Inmember.kickdate is Null and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق خانواری")
            {
                cmd = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی' rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'خانواری' and memberId=member.id and supporter_id=member.id and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1); 
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق فردی")
            {
                cmd = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'فردی' and memberId=member.id and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "متقاضی")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(subdate)as 'تاریخ ثبت تقاضا', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from applicantand where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "متقاضی سایر")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate)as 'تاریخ عضویت', phone as 'شماره تلفن', address as آدرس, explain as توضیحات from otherApplicant where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "تقاضا جدید مددجو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1 and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تقاضا جدید متقاضی")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate)as 'تاریخ عضویت', phone as 'شماره تلفن', address as آدرس, explain as توضیحات from otherApplicant and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش تقاضا")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', description as توضیحات from request where applicantId = sup and result is Null and fullname like N'%" + nameTextbox.Text + "%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش بررسی")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and result is not Null and deliveryDate is Null and fullname like N'%" + nameTextbox.Text + "%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ثبت ارائه معرفی‌نامه")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and result = N'تایید' and deliveryDate is Null and fullname like N'%" + nameTextbox.Text + "%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ویرایش ارائه معرفی‌نامه")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره تقاضا', applicantId as 'شماره ملی متقاضی', fullname as 'نام و نام خانوادگی', reqType as 'نوع تقاضا', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تقاضا', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی', result as 'نتیجه بررسی', description as توضیحات from request where applicantId = sup and deliveryDate is not Null and fullname like N'%" + nameTextbox.Text + "%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[membersView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "ثبت درخواست کمک ازدواج")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where marriage != N'متأهل' and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ثبت درخواست کمک درمان")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ثبت درخواست کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش اطلاعات مددکار")
            {
                foldertextBox.Visible = searchByFolderbutton.Visible = label3.Visible = false;
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', phone as 'شماره تلفن', address as 'آدرس' from helper where name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (this.form == "انتخاب خانوار")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1 and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            con1.Close();
            //'%or%'
        }

        private void searchByFolderbutton_Click(object sender, EventArgs e)
        {
            if (!foldertextBox.Text.All(char.IsDigit))
            {
                FMessegeBox.FarsiMessegeBox.Show("شماره پرونده باید یک عدد باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            if (this.form == "setMarriageForm")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز',folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where sex = N'زن' and marriage != N'متأهل' and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "editMarriageForm")
            {
                cmd = new SqlCommand("select married.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', dbo.MiladiTOShamsi(marrieddate) as 'تاریخ ازدواج', married.description as 'توضیحات ازدواج', supporter_id as 'شماره ملی سرپرست', birthdate as 'تاریخ تولد', health as 'وضعیت سلامتی', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from married, abandoned where married.id = abandoned.id and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "حذف پوشش خانوار")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "حذف پوشش فرد")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش خانوار")
            {
                cmd = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج خانواری' and supporter_id = outmember.id and abandoned.id = supporter_id and  outmember.folder_id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش حذف پوشش فرد")
            {
                cmd = new SqlCommand("select outmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', outmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ حذف پوشش', outmember.description as 'توضیحات حذف پوشش', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned, outmember where abandoned.id = outmember.id and abandoneddate = setupdate and status = N'خروج فردی' and outmember.folder_id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش عضو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "رجعت عضو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(abandoneddate) as 'تاریخ تعلیق', reason as 'دلیل تعلیق', legalYearAbandoned as 'خروج در 18سالگی', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from abandoned where folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش رجعت عضو")
            {
                cmd = new SqlCommand("select Inmember.id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', Inmember.folder_id as 'شماره پرونده', dbo.MiladiTOShamsi(setupdate) as 'تاریخ رجعت', Inmember.description as 'توضیحات رجعت', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member, Inmember where member.id = Inmember.id and Inmember.kickdate is Null and Inmember.folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق خانواری")
            {
                cmd = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'خانواری' and memberId=member.id and supporter_id=member.id and folder_id like '%" + foldertextBox.Text + "%'", con1); 
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تحقیق فردی")
            {
                cmd = new SqlCommand("select research.id as 'شماره تحقیق', memberId as 'شماره ملی', name as 'نام', family as 'نام خانوادگی', rdate as 'تاریخ انجام تحقیق', subdate as 'تاریخ ثبت تحقیق', rtype as 'نوع تحقیق', description as 'توضیحات' from research, member where status = N'فردی' and memberId=member.id and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تقاضا جدید مددجو")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1 and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش مصوبه")
            {
                cmd = new SqlCommand("select id as 'شماره مصوبه', docname as 'نام قایل مصوبه' from enactment where id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک جمعی با مصوبه")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where defType = N'با مصوبه' and (status = N'تعریف شده' or status = N'در حال ارائه') and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک جمعی اتفاقی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where defType = N'اتفاقی' and (status = N'تعریف شده' or status = N'در حال ارائه') and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک جمعی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where (status = N'تعریف شده' or status = N'در حال ارائه') and startdate <= @now and id like '%" + foldertextBox.Text + "%'", con1);
                cmd.Parameters.AddWithValue("@now", DateTime.Now.Date);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک جمعی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک جمعی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک جمعی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', defType as 'نوع تعریف', type as 'نوع کمک', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from GlobalHelps where status = N'نهایی' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک تحصیلی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'تعریف شده' or status = N'در حال ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک تحصیلی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'تعریف شده' or status = N'در حال ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک تحصیلی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک تحصیلی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک تحصیلی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', number as 'تعداد', school as 'نام مدرسه', description as 'توضیحات' from StudyHelps where status = N'نهایی' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک ازدواج")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where marriage != N'متأهل' and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک ازدواج")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'ثبت شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک ازدواج")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'ثبت شده' or status = N'ثبت شده نقدی' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if(this.form == "ویرایش بررسی درخواست کمک ازدواج")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelps.description as 'توضیحات' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and (MarryHelps.status = N'ارسال معرفی‌نامه' or MarryHelps.status = N'ارائه') and MarryHelps.id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک ازدواج ردشده")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from MarryHelpReq where status = N'رد شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارسال معرفی‌نامه جهیزیه")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelps.description as 'توضیحات' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'ارسال معرفی‌نامه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش ارسال معرفی‌نامه جهیزیه")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'دریافت نتیجه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'دریافت نتیجه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش نتیجه معرفی‌نامه جهیزیه")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and ((MarryHelps.status = N'پایان‌یافته: رد معرفی‌نامه' and MarryHelpReq.status = N'ثبت شده نقدی') or (MarryHelps.status = N'ارائه')) and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک ازدواج")
            {
                nameTextbox.Visible = familyTextbox.Visible = label1.Visible = label2.Visible = searchButton.Visible = false;
                label3.Text = "شماره کمک";
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and ((MarryHelps.status = N'پایان‌یافته: رد معرفی‌نامه' and MarryHelpReq.status = N'ثبت شده نقدی') or (MarryHelps.status = N'ارائه')) and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک ازدواج")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک ازدواج")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک ازدواج")
            {
                cmd = new SqlCommand("select MarryHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', type as 'نوع کمک', reqId as 'شماره درخواست', MarryHelps.status as 'وضعیت کمک', MarryHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(MarryHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(MarryHelps.confirmdate) as 'تاریخ تایید', MarryHelps.enactmentId as 'شماره مصوبه', MarryHelps.fenactmentId as 'شماره مصوبه پایانی', MarryHelpReq.description as 'توضیحات درخواست', MarryHelps.description as 'توضیحات کمک', introdescription as 'توضیحات معرفی‌نامه', resdescription as 'توضیحات نتیجه', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.status = N'نهایی' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک درمان")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member where folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک درمان")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'ثبت شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک درمان")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'ثبت شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک درمان")
            {
                cmd = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک درمان ردشده")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from HealHelpReq where status = N'رد شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک درمان")
            {
                cmd = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک درمان")
            {
                cmd = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک درمان")
            {
                cmd = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', HealHelps.enactmentId as 'شماره مصوبه', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک درمان")
            {
                cmd = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(HealHelps.confirmdate) as 'تاریخ تایید', HealHelps.enactmentId as 'شماره مصوبه', HealHelps.fenactmentId as 'شماره مصوبه پایانی', HealHelpReq.description as 'توضیحات درخواست', HealHelps.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.status = N'نهایی' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where (status = N'تعریف شده' or status = N'در حال ارائه') and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where (status = N'تعریف شده' or status = N'در حال ارائه') and startdate <= @now and id like '%" + foldertextBox.Text + "%'", con1);
                cmd.Parameters.AddWithValue("@now", DateTime.Now.Date);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش فایل‌های ارائه کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'پایان‌یافته' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک متفرقه گروهی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', ctype as 'دریافت‌کنندگان', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(startdate) as 'تاریخ شروع', cast(fee as decimal(15,0)) as 'ارزش ریالی', packets as 'تعداد بسته', description as 'توضیحات' from OtherHelpsGlobal where status = N'نهایی' and id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ثبت درخواست کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', dbo.MiladiTOShamsi(folderdate) as 'تاریخ تشکیل پرونده', dbo.MiladiTOShamsi(checkdate) as 'تاریخ بررسی پوشش', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', orphan as 'یتیم', student as 'دانش‌آموز', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from memberwhere folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                membersView.Columns[20].DefaultCellStyle.WrapMode = membersView.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                membersView.Columns[22].DefaultCellStyle.Format = "#,##;#,##-";
            }
            else if (this.form == "ویرایش درخواست کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'ثبت شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "بررسی درخواست کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'ثبت شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش بررسی درخواست کمک متفرقه فردی ردشده")
            {
                cmd = new SqlCommand("select id as 'شماره درخواست', mId as 'شماره ملی مددجو', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(reqdate) as 'تاریخ درخواست', description as 'توضیحات' from OtherHelpIndivReq where status = N'رد شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ارائه کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'ارائه' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش‌ ارائه کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "تایید کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'پایان‌یافته: ارائه شده' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش تایید کمک متفرقه فردی")
            {
                cmd = new SqlCommand("select OtherHelpsIndiv.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', OtherHelpsIndiv.status as 'وضعیت کمک', OtherHelpIndivReq.status as 'وضعیت درخواست', dbo.MiladiTOShamsi(OtherHelpIndivReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(OtherHelpsIndiv.confirmdate) as 'تاریخ تایید', OtherHelpsIndiv.enactmentId as 'شماره مصوبه', OtherHelpsIndiv.fenactmentId as 'شماره مصوبه پایانی', OtherHelpIndivReq.description as 'توضیحات درخواست', OtherHelpsIndiv.description as 'توضیحات کمک', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.status = N'نهایی' and id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش انتقال وجه")
            {
                cmd = new SqlCommand("select id as 'شماره تراکنش', srcid as 'شماره حساب مبدا', dstid as 'شمار حساب مقصد', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(transferdate) as 'تاریخ انتقال', cast(fee as decimal(15,0)) as 'ارزش ریالی', cast(fee as decimal(15,0)) as 'کارمزد', transporterName as 'انتقال‌دهنده', description as 'توضیحات' from moneyTransfer where id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک دریافتی")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک دریافتی', fee as 'ارزش ریالی', packet as 'تعداد بسته', dbo.MiladiTOShamsi(recdate) as 'تاریخ دریافت', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', helperId as 'شماره ملی مددکار', helperName as 'شماره ملی مددجو', description as 'توضیحات' from recHelps where id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "ویرایش کمک خریده‌شده")
            {
                cmd = new SqlCommand("select id as 'شماره کمک', type as 'نوع کمک', fee as 'ارزش ریالی', packet as 'تعداد بسته', dbo.MiladiTOShamsi(buydate) as 'تاریخ خرید', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت', buyerName as 'نام خریدار', bankAccountName as 'نام حساب', bankAccountId as 'شماره حساب', description as 'توضیحات' from buyHelps where id like '%" + foldertextBox.Text + "%';", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else if (this.form == "انتخاب خانوار")
            {
                cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member) as t1  where id = t1.d1 and folder_id like '%" + foldertextBox.Text + "%'", con1);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            con1.Close();
        }

        private void foldertextBox_TextChanged(object sender, EventArgs e)
        {
            searchByFolderbutton.Enabled = !string.IsNullOrEmpty(foldertextBox.Text) && !string.IsNullOrWhiteSpace(foldertextBox.Text);
            if (!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.searchForm_Load(sender, e);
            }
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
        }

        private void membersView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView.ClearSelection();
        }

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            chooseButton.Enabled = (membersView.SelectedCells.Count != 0);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText();
            if (this.form == "انتخاب خانوار")
            {
                this.Text = "choose" + membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex+13].Value.ToString();
            }
            else
            {
                this.Text = "choose" + membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString();
            }
            if (this.form == "ویرایش نتیجه معرفی‌نامه جهیزیه" && membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex + 5].Value.ToString() == "ثبت شده نقدی")
            {
                this.Text = "chooser" + membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString();
            }
            this.Close();
        }
    }
}
