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
    public partial class healHelpCheckReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id = "", rId, explain, mId;
        decimal fee, consum;
        bool rad = false;
        public healHelpCheckReqForm(string rId, string id = "", string st = "")
        {
            InitializeComponent();
            this.rId = rId;
            if (id != "")
            {
                this.id = id;
                this.Text = "ویرایش بررسی درخواست کمک درمان";
            }
            if (st != "")
            {
                this.rad = true;
                this.Text = "ویرایش بررسی درخواست کمک درمان";
            }
        }
        public void calc_Consume()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select fee from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and mId in (select id from member where folder_id = (select folder_id from member where id = @mId)) and HealHelps.id in (select id from HealHelps where confirmdate >= (select Max(subdate) from budgetsets) and id != @id);", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@mId", this.mId);
            this.consum = 0;
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.consum += reader.GetDecimal(0);
                }
            }
            con.Close();
        }

        private void healHelpCheckReqForm_Load(object sender, EventArgs e)
        {
            rIdTextBox.SelectionAlignment = HorizontalAlignment.Center;
            mIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.Text == "بررسی درخواست کمک درمان")
            {
                rIdTextBox.Text = ExtensionFunction.EnglishToPersian(this.rId);
                denyButton.Enabled = setButton.Enabled = false;
                SqlCommand cmdget = new SqlCommand("select mId, description from HealHelpReq where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.rId);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                        explainTextBox.Text = reader.GetString(1);
                    }
                }
            }
            else
            {
                this.BackColor = Color.Yellow;
                denyButton.Visible = false;
                if (rad)
                {
                    SqlCommand cmdget = new SqlCommand("select mId, description, enactmentId from HealHelpReq where id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.rId);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                            explainTextBox.Text = reader.GetString(1);
                            enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(2));
                        }
                    }
                    searchButton.Enabled = false;
                    feeNumericUpDown.Enabled = false;
                    explainTextBox2.Enabled = false;
                    setButton.Text = "لغو ویرایش";
                    setButton.Enabled = true;
                }
                else
                {
                    SqlCommand cmdget = new SqlCommand("select reqId, mId, HealHelps.description, HealHelps.enactmentId, fee, HealHelpReq.description from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and HealHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.rId = reader.GetString(0); rIdTextBox.Text = ExtensionFunction.EnglishToPersian(this.rId);
                            this.mId = reader.GetString(1); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                            explainTextBox.Text = reader.GetString(5) + " " + reader.GetString(2); this.explain = reader.GetString(2);
                            enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(3));
                            this.fee = feeNumericUpDown.Value = reader.GetDecimal(4);
                        }
                    }
                }
                label17.Text = "توضیحات کمک:"; label17.Location = new Point(searchButton.Location.X + 5, searchButton.Location.Y + 50);
                delButton.Visible = true;
            }
            calc_Consume();
            con.Close();
        }
        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            denyButton.Enabled = setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void visitFormButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.rId + "\\req")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void visitDocsButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("مشاهده مدارک درمان", this.rId, "HRhelp:healDoc");
            newform.ShowDialog(this);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text == "choose")
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(Clipboard.GetText());
            }
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update HealHelpReq Set status = @rstat, enactmentId = @eId where id = @rId;", con);
            cmd.Parameters.AddWithValue("@rId", this.rId);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.Parameters.AddWithValue("@rstat", "رد شده");
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("درخواست با موفقیت رد شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (rad)
            {
                SqlCommand cmd = new SqlCommand("update HealHelpReq Set status = @rstat, enactmentId = Null where id = @rId;", con);
                cmd.Parameters.AddWithValue("@rId", this.rId);
                cmd.Parameters.AddWithValue("@rstat", "ثبت شده");
                cmd.ExecuteNonQuery();
                FMessegeBox.FarsiMessegeBox.Show("درخواست با شماره " + this.rId + " مجددا آماده بررسی است!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
            else
            {
                decimal budget = 0, consume = 0, stock = 0;
                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                //SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                cmdget.Parameters.AddWithValue("@id", "healBudget");
                cmdget2.Parameters.AddWithValue("@id", "healConsume");
                //cmdget3.Parameters.AddWithValue("@id", "stock");
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
                /*using (SqlDataReader reader = cmdget3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }*/
                System.IO.Directory.Delete(this.helpPath + "\\" + this.id, true);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from HealHelps where id = @id; update HealHelpReq Set status = @rstat, enactmentId = Null where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@rId", this.rId);
                cmd.Parameters.AddWithValue("@rstat", "ثبت شده");
                cmd.Parameters.AddWithValue("@amount2", consume - this.fee);
                //cmd.Parameters.AddWithValue("@amount3", stock + this.fee);
                cmd.Parameters.AddWithValue("@tname2", "healConsume");
                //cmd.Parameters.AddWithValue("@tname3", "stock");
                cmd.ExecuteNonQuery();
                FMessegeBox.FarsiMessegeBox.Show("کمک با شماره " + ExtensionFunction.EnglishToPersian(this.id) + " با موفقیت حذف شد و درخواست با شماره " + this.rId + " مجددا آماده بررسی است!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                con.Close();
                this.Close();
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (rad)
            {
                this.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                if (this.Text == "بررسی درخواست کمک درمان")
                {
                    decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    //SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget4 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "healBudget");
                    cmdget2.Parameters.AddWithValue("@id", "healConsume");
                    //cmdget3.Parameters.AddWithValue("@id", "stock");
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
                    /*using (SqlDataReader reader = cmdget3.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = reader.GetDecimal(0);
                        }
                    }*/
                    using (SqlDataReader reader = cmdget4.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            familyBudget = reader.GetDecimal(0);
                        }
                    }
                    if (consume + feeNumericUpDown.Value > budget)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    else if (this.consum + feeNumericUpDown.Value > familyBudget)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه درمانی خانوار تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    /*else if (feeNumericUpDown.Value > stock)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }*/
                    else
                    {
                        string d = DateTime.Now.Date.ToPersian(); d = "H" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                        SqlCommand cmdgetid = new SqlCommand("select id from HealHelps where id like '" + d + "%';", con);
                        int index = 1;
                        using (SqlDataReader reader = cmdgetid.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string s = String.Format("{0}", reader["id"]);
                                if (s == "") index = 1;
                                else index = Convert.ToInt32(s.Substring(9)) + 1;
                            }
                        }
                        d = d + index.ToString();
                        this.id = d;
                        System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id);
                        System.IO.Directory.CreateDirectory(this.helpPath + "\\" + this.id + "\\receipt");
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into HealHelps (id, reqId, subdate, description, enactmentId, status, fee) Values (@id, @rId, @sdate, @des, @eId, @stat, @fee); update HealHelpReq Set status = @rstat, enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@rId", this.rId);
                        cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@des", "(توضیحات کمک: " + explainTextBox2.Text + ")");
                        cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                        cmd.Parameters.AddWithValue("@stat", "ارائه");
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@rstat", "تایید");
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                        //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@tname2", "healConsume");
                        //cmd.Parameters.AddWithValue("@tname3", "stock");
                        cmd.ExecuteNonQuery();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        this.Close();
                    }
                }
                else
                {
                    decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    //SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget4 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "healBudget");
                    cmdget2.Parameters.AddWithValue("@id", "healConsume");
                    //cmdget3.Parameters.AddWithValue("@id", "stock");
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
                    /*using (SqlDataReader reader = cmdget3.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = reader.GetDecimal(0);
                        }
                    }*/
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
                    else if (this.consum + feeNumericUpDown.Value > familyBudget)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه درمانی خانوار تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    /*else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }*/
                    else
                    {
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update HealHelps Set description = @des, fee = @fee, enactmentId = @eId where id = @id; update HealHelpReq Set enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@rId", this.rId);
                        cmd.Parameters.AddWithValue("@des", this.explain + " " + "(توضیحات ویرایش کمک: " + explainTextBox2.Text + ")");
                        cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                        cmd.Parameters.AddWithValue("@tname2", "healConsume");
                        //cmd.Parameters.AddWithValue("@tname3", "stock");
                        cmd.ExecuteNonQuery();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        this.Close();
                    }
                }
            }
        }
    }
}
