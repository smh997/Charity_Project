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
    public partial class observeFamiliesForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public observeFamiliesForm()
        {
            InitializeComponent();
        }

        private void observeFamiliesForm_Load(object sender, EventArgs e)
        {
            chooseButton.Enabled = searchButton.Enabled = searchByFolderbutton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd2; SqlDataAdapter da; DataTable dt;
            cmd2 = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1", con1);
            da = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[16].DefaultCellStyle.WrapMode = membersView.Columns[17].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            membersView.Columns[18].DefaultCellStyle.Format = "#,##;#,##-";
            con1.Close();
        }
        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !string.IsNullOrEmpty(nameTextbox.Text) && !string.IsNullOrWhiteSpace(nameTextbox.Text);
            if (!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.observeFamiliesForm_Load(sender, e);
            }
        }

        private void familyTextbox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !string.IsNullOrEmpty(familyTextbox.Text) && !string.IsNullOrWhiteSpace(familyTextbox.Text);
            if (!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.observeFamiliesForm_Load(sender, e);
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1 and name like N'%" + nameTextbox.Text + "%' and family like N'%" + familyTextbox.Text + "%';", con1);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            con1.Close();
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
            cmd = new SqlCommand("select id as 'شماره ملی', name as نام, family as 'نام خانوادگی', fatherName as 'نام پدر', supporter_id as 'شماره ملی سرپرست', dbo.MiladiTOShamsi(birthdate) as 'تاریخ تولد', health as 'وضعیت سلامتی', sex as 'جنسیت', job as 'شغل', house as 'وضعیت مسکن', annual as 'مستمری‌بگیر', otherSup as 'تحت پوشش سایر موسسات', marriage as 'وضعیت تاهل', folder_id as 'شماره پرونده', homephone as 'شماره منزل', cellphone as 'شماره همراه', address as آدرس, explain as توضیحات, rate as امتیاز from member , (select distinct(supporter_id) as d1 from member where id != supporter_id) as t1  where id = t1.d1 and folder_id like '%" + foldertextBox.Text + "%'", con1);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
        }
        private void foldertextBox_TextChanged(object sender, EventArgs e)
        {
            searchByFolderbutton.Enabled = !string.IsNullOrEmpty(foldertextBox.Text) && !string.IsNullOrWhiteSpace(foldertextBox.Text);
            if (!searchButton.Enabled && !searchByFolderbutton.Enabled)
            {
                this.observeFamiliesForm_Load(sender, e);
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
            var newform = new observeFamiliesForm2(ExtensionFunction.PersianToEnglish(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString()));
            newform.ShowDialog(this);
        }
    }
}
