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
    public partial class studyHelpForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, type, status;
        decimal fee;
        int packs;
        DateTime subdate;
        public studyHelpForm(string id = "", string p = "")
        {
            InitializeComponent();
            if (p != "")
            {
                this.id = id;
                this.Text = p;
            }
        }

        private void studyHelpForm_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            schoolTextBox.SelectionAlignment = HorizontalAlignment.Center;
            setButton.Enabled = searchButton.Enabled = startDateTimePickerX.Enabled = schoolTextBox.Enabled = feeNumericUpDown.Enabled = packetNumericUpDown.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from member where student = N'بله';", con);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    packetNumericUpDown.Maximum = reader.GetInt32(0);
                }
            }
            if(this.Text == "ویرایش کمک تحصیلی")
            {
                this.BackColor = Color.Yellow; delButton.Visible = true;
                SqlCommand cmdget = new SqlCommand("select type, fee, number, startdate, enactmentId, status, school, description, subdate from StudyHelps where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.type = typeComboBox.Text = reader.GetString(0);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(1);
                        startDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["startdate"])).Date;
                        enactmentTextbox.Text = reader.GetString(4);
                        this.packs = reader.GetInt32(2);
                        packetNumericUpDown.Value = Convert.ToDecimal(this.packs);
                        this.status = reader.GetString(5);
                        explainTextBox.Text = String.Format("{0}", reader["description"]);
                        schoolTextBox.Text = reader.GetString(6);
                        this.subdate = Convert.ToDateTime(String.Format("{0}", reader["subdate"])).Date;
                    }
                }
                typeComboBox.Enabled = false;
                if (this.status != "تعریف شده")
                {
                    delButton.Enabled = startDateTimePickerX.Enabled = packetNumericUpDown.Enabled = false;
                }
            }
            
            con.Close();
        }
        private void startDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if(this.Text == "ویرایش کمک تحصیلی")
            {
                if (startDateTimePickerX.SelectedDateInDateTime.Date < this.subdate)
                {
                    startDateTimePickerX.SelectedDateInDateTime = this.subdate;
                }
            }
            else
            {
                if (startDateTimePickerX.SelectedDateInDateTime.Date < DateTime.Now.Date)
                {
                    startDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
                }
            }
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
        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from StudyTmpList where hId = @id; delete from StudyDelList where hId = @id; delete from StudyFinList where hId = @id; delete from StudyHelps where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@tname2", "eduConsume");
            cmd.Parameters.AddWithValue("@tname3", "stock");
            cmd.Parameters.AddWithValue("@amount2", this.fee);
            cmd.Parameters.AddWithValue("@amount3", this.fee);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            feeNumericUpDown.Enabled = searchButton.Enabled = true;
            if(typeComboBox.Text == "معرفی‌نامه")
            {
                packetNumericUpDown.Enabled = startDateTimePickerX.Enabled = false;
                schoolTextBox.Enabled = true;
            }
            else
            {
                schoolTextBox.Enabled = false;
                startDateTimePickerX.Enabled = packetNumericUpDown.Enabled = true;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) as c from enactment where id = @id", con);
            cmdcheck.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            int c = 0;
            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    c = reader.GetInt32(0);
                }
            }
            if (c == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("مصوبه‌ای با این شماره وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                if(this.Text == "ویرایش کمک تحصیلی")
                {
                    if (this.status != "تعریف شده")
                    {
                        if (this.type == "معرفی‌نامه")
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "eduBudget");
                            cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                            cmdget3.Parameters.AddWithValue("@id", "stock");
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
                            if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set fee = @fee, enactmentId = @eId, description = @des, school = @sch where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmdupdate.Parameters.AddWithValue("@id", this.id);
                                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@eId", enactmentTextbox.Text);
                                cmdupdate.Parameters.AddWithValue("@sch", schoolTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                cmdupdate.Parameters.AddWithValue("@tname2", "eduConsume");
                                cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                cmdupdate.ExecuteNonQuery();
                                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                con.Close();
                                this.Close();
                            }
                        }
                        else
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "eduBudget");
                            cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                            cmdget3.Parameters.AddWithValue("@id", "stock");
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
                            if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set fee = @fee, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmdupdate.Parameters.AddWithValue("@id", this.id);
                                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@eId", enactmentTextbox.Text);
                                cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                cmdupdate.Parameters.AddWithValue("@tname2", "eduConsume");
                                cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                cmdupdate.ExecuteNonQuery();
                                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                con.Close();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (this.type == "معرفی‌نامه")
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "eduBudget");
                            cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                            cmdget3.Parameters.AddWithValue("@id", "stock");
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
                            if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set fee = @fee, enactmentId = @eId, description = @des, school = @sch where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmdupdate.Parameters.AddWithValue("@id", this.id);
                                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@eId", enactmentTextbox.Text);
                                cmdupdate.Parameters.AddWithValue("@sch", schoolTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                cmdupdate.Parameters.AddWithValue("@tname2", "eduConsume");
                                cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                cmdupdate.ExecuteNonQuery();
                                var newform = new studyHelpListForm(this.id, "معرفی‌نامه", "ویرایش");
                                newform.ShowDialog(this);
                                con.Close();
                                this.Close();
                            }
                        }
                        else
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "eduBudget");
                            cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                            cmdget3.Parameters.AddWithValue("@id", "stock");
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
                            if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update StudyHelps Set fee = @fee, number = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmdupdate.Parameters.AddWithValue("@id", this.id);
                                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@eId", enactmentTextbox.Text);
                                cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                cmdupdate.Parameters.AddWithValue("@tname2", "eduConsume");
                                cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                cmdupdate.ExecuteNonQuery();
                                var newform = new studyHelpListForm(this.id, "لوازم التحریر", "ویرایش");
                                newform.ShowDialog(this);
                                con.Close();
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    decimal budget = 0, consume = 0, stock = 0;
                    SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                    cmdget.Parameters.AddWithValue("@id", "eduBudget");
                    cmdget2.Parameters.AddWithValue("@id", "eduConsume");
                    cmdget3.Parameters.AddWithValue("@id", "stock");
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
                    if (consume + feeNumericUpDown.Value > budget)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    else if (feeNumericUpDown.Value > stock)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    else
                    {
                        string d = DateTime.Now.Date.ToPersian(); d = "S" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                        cmdget = new SqlCommand("select id from StudyHelps where id like '" + d + "%';", con);
                        int index = 1;
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string s = String.Format("{0}", reader["id"]);
                                if (s == "") index = 1;
                                else index = Convert.ToInt32(s.Substring(9)) + 1;
                            }
                        }
                        d = d + index.ToString();
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into StudyHelps (id, type, fee, number, startdate, subdate, enactmentId, status, description, school) Values (@id, @type, @fee, @num, @sdate, @subdate, @eId, @stat, @des, @school); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; insert into StudyDelList (hId, supporter_id, folder_id, name, family, stuId) select StudyHelps.id, supporter_id, folder_id, name, family, member.id from member, StudyHelps where student = N'بله' and StudyHelps.id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", d);
                        cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                        cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                        cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@tname2", "eduConsume");
                        cmd.Parameters.AddWithValue("@tname3", "stock");
                        if (typeComboBox.Text == "معرفی‌نامه")
                        {
                            cmd.Parameters.AddWithValue("@num", 0);
                            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@school", schoolTextBox.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@num", packetNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                            cmd.Parameters.AddWithValue("@school", "");
                        }
                        cmd.ExecuteNonQuery();
                        var newform = new studyHelpListForm(d, typeComboBox.Text);
                        newform.ShowDialog(this);
                        if (newform.Text == "fail")
                        {
                            SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from StudyTmpList where hId = @id; delete from StudyDelList where hId = @id; delete from StudyHelps where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmdcancel.Parameters.AddWithValue("@id", d);
                            cmdcancel.Parameters.AddWithValue("@amount2", consume);
                            cmdcancel.Parameters.AddWithValue("@amount3", stock);
                            cmdcancel.Parameters.AddWithValue("@tname2", "eduConsume");
                            cmdcancel.Parameters.AddWithValue("@tname3", "stock");
                            cmdcancel.ExecuteNonQuery();
                        }
                        else
                        {
                            con.Close();
                            this.Close();
                        }
                    }
                }
            }
            con.Close();
        }
    }
}
