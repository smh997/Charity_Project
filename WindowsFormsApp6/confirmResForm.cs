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
    public partial class confirmResForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string fold, resId, memId;


        public confirmResForm(string p, string resId, string fold, string memId)
        {
            InitializeComponent();
            this.Text = p;
            this.resId = resId;
            this.fold = fold;
            this.memId = memId;
        }

        private void confirmResForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetres, cmdget; SqlDataAdapter dar, da; DataTable dtr, dt;
            if (this.Text == "تایید تحقیق فردی")
            {
                cmdgetres = new SqlCommand("select id as 'شماره تحقیق', rtype as 'نوع تجقیق', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تحقیق', dbo.MiladiTOShamsi(rdate) as 'تاریخ انجام تحقیق', description as 'توضیحات تحقیق' from research where id = @id", con);
                cmdgetres.Parameters.AddWithValue("@id", this.resId);
                dar = new SqlDataAdapter(cmdgetres);
                dtr = new DataTable();
                dar.Fill(dtr);
                researchView.DataSource = dtr;
                cmdget = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member where id = @sup", con);
                cmdget.Parameters.AddWithValue("@sup", this.memId);
                da = new SqlDataAdapter(cmdget);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
            else
            {
                cmdgetres = new SqlCommand("select id as 'شماره تحقیق', rtype as 'نوع تجقیق', dbo.MiladiTOShamsi(subdate) as 'تاریخ ثبت تحقیق', dbo.MiladiTOShamsi(rdate) as 'تاریخ انجام تحقیق', description as 'توضیحات تحقیق' from research where id = @id and memberId = @memId", con);
                cmdgetres.Parameters.AddWithValue("@id", this.resId);
                cmdgetres.Parameters.AddWithValue("@memId", this.memId);
                dar = new SqlDataAdapter(cmdgetres);
                dtr = new DataTable();
                dar.Fill(dtr);
                researchView.DataSource = dtr;
                cmdget = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', folder_id as 'شماره پرونده', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', insurance as 'وضعیت بیمه', orphan as 'یتیم', student as 'دانش‌آموز', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات from member where folder_id = @fol", con);
                cmdget.Parameters.AddWithValue("@fol", this.fold);
                da = new SqlDataAdapter(cmdget);
                dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
            }
        }
        private void setButton_Click(object sender, EventArgs e)
        {
            DialogResult resu =  FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به تایید این تحقیق مطمئن هستید؟", "توجه!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (resu != DialogResult.Yes)
                return;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update research Set confirmed = @conf where id = @resId", con);
            cmd.Parameters.AddWithValue("@conf", "بله");
            cmd.Parameters.AddWithValue("@resId", this.resId);
            cmd.ExecuteNonQuery();
            this.Text = "confirmed";
            con.Close();
            this.Close();
        }
    }
}
