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
    public partial class healHelpConfirmForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, rId, eId, mId, ePath, eId2, ePath2, explain;
        int climit;
        decimal fee, consume;
        public healHelpConfirmForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            if (p != "")
            {
                this.Text = p;
            }
        }
        public void calc_Consume()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select fee from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and mId in (select id from member where folder_id = (select folder_id from member where id = @mId)) and HealHelps.id in (select id from HealHelps where confirmdate >= (select Max(subdate) from budgetsets) and id != @id);", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@mId", this.mId);
            this.consume = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.consume += reader.GetDecimal(0);
                }
            }
            con.Close();
        }
        private void healHelpConfirmForm_Load(object sender, EventArgs e)
        {
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            visitButton.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text == "تایید کمک درمان")
            {
                SqlCommand cmdgetgrid = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', HealHelps.enactmentId as 'شماره مصوبه', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.id = @id;", con);
                cmdgetgrid.Parameters.AddWithValue("@id", this.id);
                SqlDataAdapter da = new SqlDataAdapter(cmdgetgrid);
                DataTable dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                climit = 5;
                SqlCommand cmdget = new SqlCommand("select reqId, HealHelps.description, HealHelpReq.description, presdescription, fee, HealHelps.enactmentId, mId from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.rId = reader.GetString(0);
                        explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(4);
                        this.eId = reader.GetString(5);
                        this.mId = reader.GetString(6);
                    }
                }
                SqlCommand cmdget2 = new SqlCommand("select docpath from enactment where id = @eId;", con);
                cmdget2.Parameters.AddWithValue("@eId", this.eId);
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.ePath = reader.GetString(0);
                    }
                }
            }
            else
            {
                this.BackColor = Color.Yellow;
                membersView.BackgroundColor = Color.Gold;
                SqlCommand cmdgetgrid = new SqlCommand("select HealHelps.id as 'شماره کمک', mId as 'شماره ملی مددجو', reqId as 'شماره درخواست', HealHelps.status as 'وضعیت کمک', HealHelpReq.status as 'وضعیت درخواست', HealHelps.enactmentId as 'شماره مصوبه', HealHelps.fenactmentId as 'شماره مصوبه پایانی', dbo.MiladiTOShamsi(HealHelpReq.reqdate) as 'تاریخ ثبت درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ بررسی و ثبت کمک', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(HealHelps.confirmdate) as 'تاریخ تایید' from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.id = @id;", con);
                cmdgetgrid.Parameters.AddWithValue("@id", this.id);
                SqlDataAdapter da = new SqlDataAdapter(cmdgetgrid);
                DataTable dt = new DataTable();
                da.Fill(dt);
                membersView.DataSource = dt;
                climit = 6;
                SqlCommand cmdget = new SqlCommand("select reqId, HealHelps.description, HealHelpReq.description, presdescription, fee, HealHelps.enactmentId, confirmdescription, fenactmentId, mId from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.rId = reader.GetString(0);
                        explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(6); this.explain = reader.GetString(6);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(4);
                        this.eId = reader.GetString(5);
                        this.eId2 = reader.GetString(7); enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(this.eId2);
                        this.mId = reader.GetString(8);
                    }
                }
                SqlCommand cmdget2 = new SqlCommand("select docpath from enactment where id = @eId;", con);
                cmdget2.Parameters.AddWithValue("@eId", this.eId);
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.ePath = reader.GetString(0);
                    }
                }
                cmdget2 = new SqlCommand("select docpath from enactment where id = @eId;", con);
                cmdget2.Parameters.AddWithValue("@eId", this.eId2);
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.ePath2 = reader.GetString(0);
                    }
                }
            }
            calc_Consume();
            con.Close();
        }
        private void visitButton_Click(object sender, EventArgs e)
        {
            string dpath;
            if (this.Text == "تایید کمک درمان")
            {
                switch (membersView.SelectedCells[0].ColumnIndex)
                {
                    case 6:
                        dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.rId + "\\req")[0];
                        System.Diagnostics.Process.Start(dpath);
                        break;
                    case 7:
                        System.Diagnostics.Process.Start(this.ePath);
                        break;
                    case 8:
                        dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                        System.Diagnostics.Process.Start(dpath);
                        break;
                }
            }
            else
            {
                switch (membersView.SelectedCells[0].ColumnIndex)
                {
                    case 7:
                        dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.rId + "\\req")[0];
                        System.Diagnostics.Process.Start(dpath);
                        break;
                    case 8:
                        System.Diagnostics.Process.Start(this.ePath);
                        break;
                    case 9:
                        dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                        System.Diagnostics.Process.Start(dpath);
                        break;
                    case 10:
                        System.Diagnostics.Process.Start(this.ePath2);
                        break;
                }
            }
        }

        private void membersView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView.ClearSelection();
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex <= this.climit)
            {
                membersView.ClearSelection();
            }
        }

        private void  healHelpConfirmForm_Activated(object sender, EventArgs e)
        {
            if (membersView.SelectedCells.Count > 0)
                membersView.SelectedCells[0].Selected = false;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک درمان")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget4 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "healBudget");
                cmdget2.Parameters.AddWithValue("@id", "healConsume");
                cmdget3.Parameters.AddWithValue("@id", "stock");
                cmdget4.Parameters.AddWithValue("@id", "healFamilyBudget");
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consume = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget4.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        familyBudget = reader.GetDecimal(0);
                    }
                }
                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else if (this.consume + feeNumericUpDown.Value > familyBudget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه درمانی خانوار تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else
                {
                    DialogResult dr = FMessegeBox.FarsiMessegeBox.Show("با تایید کمک، ویرایش اعمال پیش از تایید غیر ممکن خواهد شد. آیا نسبت به تایید اطمینان دارید؟", "هشدار!", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (dr != DialogResult.Yes)
                    {
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update HealHelps Set confirmdescription = @des, confirmdate = @cdate, status = @stat, fee = @fee, fenactmentId = @feId where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", "(توضیحات تایید: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@stat", "نهایی");
                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                    cmd.Parameters.AddWithValue("@tname2", "healConsume");
                    cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                    cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت تایید و نهایی شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget4 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "healBudget");
                cmdget2.Parameters.AddWithValue("@id", "healConsume");
                cmdget3.Parameters.AddWithValue("@id", "stock");
                cmdget4.Parameters.AddWithValue("@id", "healFamilyBudget");
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consume = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                using (SqlDataReader reader = cmdget4.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        familyBudget = reader.GetDecimal(0);
                    }
                }
                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else if (this.consume + feeNumericUpDown.Value > familyBudget)
                {
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه درمانی خانوار تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update HealHelps Set confirmdescription = @des, fee = @fee, fenactmentId = @feId where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش تایید: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@feId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                    cmd.Parameters.AddWithValue("@tname2", "healConsume");
                    cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                    cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("ویرایش تایید کمک با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
            }
        }

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            visitButton.Enabled = membersView.SelectedCells.Count != 0;
        }

        private void visitDocsButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("مشاهده مدارک درمان", this.rId, "HRhelp:healDoc");
            newform.ShowDialog(this);
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }
    }
}
