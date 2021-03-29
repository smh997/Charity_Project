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
    public partial class otherHelpGlobalForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, ctype, status = "";
        decimal metric = 0, fee = 0;
        int packets = 0, maxstu = 0, maxsick = 0, maxorph = 0, maxmembers = 0, maxfamily = 0;

        DateTime subdate;

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case -1:
                    return;
                case 0:
                    packetNumericUpDown.Maximum = maxorph;
                    break;
                case 1:
                    packetNumericUpDown.Maximum = maxstu;
                    break;
                case 2:
                    packetNumericUpDown.Maximum = maxsick;
                    break;
                case 3:
                    packetNumericUpDown.Maximum = maxmembers;
                    break;
                case 4:
                    packetNumericUpDown.Maximum = maxfamily;
                    break;
            }
            if(packetNumericUpDown.Maximum < 1)
            {
                FMessegeBox.FarsiMessegeBox.Show("بیماری وجود ندارد!", "توجه", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                typeComboBox.SelectedIndex = -1;
            }
            packetNumericUpDown.Value = packetNumericUpDown.Minimum;
        }

        public otherHelpGlobalForm(string p = "", string id = "")
        {
            InitializeComponent();
            if (p != "")
            {
                this.Text = p;
                this.id = id;
            }
        }

        private void otherHelpGlobalForm_Load(object sender, EventArgs e)
        {
            cashtypeComboBox.DropDownStyle = typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from member where student = N'بله';", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    packetNumericUpDown.Maximum = reader.GetInt32(0);
                }
            }
            cmd = new SqlCommand("select count(*) from member where student = N'بله';", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    maxstu = reader.GetInt32(0);
                }
            }
            cmd = new SqlCommand("select count(*) from member where orphan = N'بله';", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    maxorph = reader.GetInt32(0);
                }
            }
            cmd = new SqlCommand("select count(*) from member where health = N'بیمار خاص';", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    maxsick = reader.GetInt32(0);
                }
            }
            cmd = new SqlCommand("select count(*) from member;", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    maxmembers = reader.GetInt32(0);
                }
            }
            cmd = new SqlCommand("select count(distinct folder_id) from member;", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    maxfamily = reader.GetInt32(0);
                }
            }
            if (this.Text == "ویرایش کمک متفرقه گروهی")
            {
                this.BackColor = Color.Yellow; delButton.Visible = true;
                cashtypeComboBox.Enabled = typeComboBox.Enabled = false;
                SqlCommand cmdget = new SqlCommand("select ctype, fee, packets, startdate, enactmentId, status, metric, description, subdate, cashtype from OtherHelpsGlobal where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.ctype = typeComboBox.Text = reader.GetString(0);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(1);
                        startDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["startdate"])).Date;
                        enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(4));
                        this.packets = reader.GetInt32(2);
                        packetNumericUpDown.Value = Convert.ToDecimal(this.packets);
                        this.status = reader.GetString(5);
                        this.metric = reader.GetDecimal(6);
                        explainTextBox.Text = String.Format("{0}", reader["description"]);
                        this.subdate = Convert.ToDateTime(String.Format("{0}", reader["subdate"])).Date;
                        if (reader.GetString(9) == "نقدی")
                        {
                            cashtypeComboBox.Text = "نقدی";
                        }
                        else
                        {
                            cashtypeComboBox.Text = "غیرنقدی";
                        }
                    }
                }
                if (this.status != "تعریف شده")
                {
                    delButton.Enabled = startDateTimePickerX.Enabled = packetNumericUpDown.Enabled = feeNumericUpDown.Enabled = cashtypeComboBox.Enabled = false;
                }
            }
            else
            {
                typeComboBox.SelectedIndex = 0;
            }
            con.Close();
        }

        private void startDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (this.Text == "ویرایش کمک متفرقه گروهی")
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

        private void explainTextBox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = (!string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text) && !string.IsNullOrEmpty(explainTextBox.Text) && !string.IsNullOrWhiteSpace(explainTextBox.Text));
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            decimal budget = 0, consume = 0, stock = 0;
            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            cmdget.Parameters.AddWithValue("@id", "othersBudget");
            cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobalFinList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@tname2", "othersConsume");
            cmd.Parameters.AddWithValue("@tname3", "stock");
            cmd.Parameters.AddWithValue("@amount2", consume - this.fee);
            cmd.Parameters.AddWithValue("@amount3", stock + this.fee);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
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
                if (this.Text == "ویرایش کمک متفرقه گروهی")
                {
                    if (this.status != "تعریف شده")
                    {
                        SqlCommand cmdupdate = new SqlCommand("update GlobalHelps Set enactmentId = @eId, description = @des where id = @id;", con);
                        cmdupdate.Parameters.AddWithValue("@id", this.id);
                        cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                        cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                        cmdupdate.ExecuteNonQuery();
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        decimal budget = 0, consume = 0, stock = 0;
                        if (cashtypeComboBox.Text == "نقدی")
                        {
                            // todo
                            if (typeComboBox.Text == "ایتام")
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget.Parameters.AddWithValue("@id", "othersBudget");
                                cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }
                                /*else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }*/
                                else
                                {
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3;
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    //cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "othersConsume");
                                    //cmdupdate.Parameters.AddWithValue("@tname3", "orphan");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                            else if (typeComboBox.Text == "ازدواج")
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                
                                cmdget.Parameters.AddWithValue("@id", "marryBudget");
                                cmdget2.Parameters.AddWithValue("@id", "marryConsume");
                                
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
                                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }
                                /*else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }*/
                                else
                                {
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3;
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    //cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "marryConsume");
                                    //cmdupdate.Parameters.AddWithValue("@tname3", "marry");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                            else
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                
                                cmdget.Parameters.AddWithValue("@id", "othersBudget");
                                cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                                
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
                                if (feeNumericUpDown.Value > this.fee && consume + feeNumericUpDown.Value - this.fee > budget)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }
                                /*else if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                                {
                                    FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                    return;
                                }*/
                                else
                                {
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con); // update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    //cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "othersConsume");
                                    //cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            if (typeComboBox.Text == "ایتام")
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget.Parameters.AddWithValue("@id", "othersBudget");
                                cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                                cmdget3.Parameters.AddWithValue("@id", "orphan");
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
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "othersConsume");
                                    cmdupdate.Parameters.AddWithValue("@tname3", "orphan");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                            else if (typeComboBox.Text == "ازدواج")
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget.Parameters.AddWithValue("@id", "marryBudget");
                                cmdget2.Parameters.AddWithValue("@id", "marryConsume");
                                cmdget3.Parameters.AddWithValue("@id", "marry");
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
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "marryConsume");
                                    cmdupdate.Parameters.AddWithValue("@tname3", "marry");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                            else
                            {
                                SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget.Parameters.AddWithValue("@id", "othersBudget");
                                cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                                    SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsGlobal Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdupdate.Parameters.AddWithValue("@id", this.id);
                                    cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                    cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                    cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                    cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                    cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                    cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                    cmdupdate.Parameters.AddWithValue("@tname2", "othersConsume");
                                    cmdupdate.Parameters.AddWithValue("@tname3", "stock");
                                    cmdupdate.ExecuteNonQuery();
                                    var newform = new otherHelpGlobalListForm(this.id, "ویرایش کمک متفرقه گروهی");
                                    newform.ShowDialog(this);
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if(cashtypeComboBox.SelectedIndex == -1)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("نوع(نقدی/غیرنقدی) کمک مشخص نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    decimal budget = 0, consume = 0, stock = 0;
                    if(cashtypeComboBox.Text == "نقدی")
                    {
                        // todo
                        if (typeComboBox.Text == "ایتام")
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "othersBudget");
                            cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                            if (consume + feeNumericUpDown.Value > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }
                            /*else if (feeNumericUpDown.Value > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }*/
                            else
                            {
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);// update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if (cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                                //cmd.Parameters.AddWithValue("@tname3", "orphan");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);//update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    //cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "othersConsume");
                                    //cmdcancel.Parameters.AddWithValue("@tname3", "orphan");
                                    cmdcancel.ExecuteNonQuery();
                                }
                                else
                                {
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                        else if (typeComboBox.Text == "ازدواج")
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            
                            cmdget.Parameters.AddWithValue("@id", "marryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "marryConsume");
                            
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
                            
                            if (consume + feeNumericUpDown.Value > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }
                            /*else if (feeNumericUpDown.Value > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }*/
                            else
                            {
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);//update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if (cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "marryConsume");
                                //cmd.Parameters.AddWithValue("@tname3", "marry");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);//update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    //cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "marryConsume");
                                    //cmdcancel.Parameters.AddWithValue("@tname3", "marry");
                                    cmdcancel.ExecuteNonQuery();
                                }
                                else
                                {
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            
                            cmdget.Parameters.AddWithValue("@id", "othersBudget");
                            cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                            
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
                            
                            if (consume + feeNumericUpDown.Value > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }
                            /*else if (feeNumericUpDown.Value > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            }*/
                            else
                            {
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);//update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if (cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                                //cmd.Parameters.AddWithValue("@tname3", "stock");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);// update budgetsCurrencies Set amount = @amount3 where typename = @tname3; 
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    //cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "othersConsume");
                                    //cmdcancel.Parameters.AddWithValue("@tname3", "stock");
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
                    else
                    {
                        if (typeComboBox.Text == "ایتام")
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "othersBudget");
                            cmdget2.Parameters.AddWithValue("@id", "othersConsume");
                            cmdget3.Parameters.AddWithValue("@id", "orphan");
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
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if(cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                                cmd.Parameters.AddWithValue("@tname3", "orphan");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "othersConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "orphan");
                                    cmdcancel.ExecuteNonQuery();
                                }
                                else
                                {
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                        else if (typeComboBox.Text == "ازدواج")
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "marryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "marryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "marry");
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
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if (cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "marryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "marry");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "marryConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "marry");
                                    cmdcancel.ExecuteNonQuery();
                                }
                                else
                                {
                                    con.Close();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            cmdget.Parameters.AddWithValue("@id", "othersBudget");
                            cmdget2.Parameters.AddWithValue("@id", "othersConsume");
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
                                cmdget = new SqlCommand("select point from parameters where name = 'help'", con);
                                using (SqlDataReader reader = cmdget.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        metric = reader.GetInt32(0);
                                    }
                                }
                                string d = DateTime.Now.Date.ToPersian(); d = "O" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                                cmdget = new SqlCommand("select id from OtherHelpsGlobal where id like '" + d + "%';", con);
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
                                this.id = d;
                                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsGlobal (id, ctype, fee, packets, startdate, subdate, enactmentId, status, metric, description, cashtype) Values (@id, @ctype, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @cashtype); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmd.Parameters.AddWithValue("@id", d);
                                cmd.Parameters.AddWithValue("@ctype", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                                if (cashtypeComboBox.Text == "نقدی")
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                                }
                                cmd.Parameters.AddWithValue("@metric", metric);
                                cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                                cmd.Parameters.AddWithValue("@tname3", "stock");
                                cmd.ExecuteNonQuery();

                                var newform = new otherHelpGlobalListForm(d);
                                newform.ShowDialog(this);
                                if (newform.Text == "fail")
                                {
                                    SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsGlobalTmpList where hId = @id; delete from OtherHelpsGlobalDelList where hId = @id; delete from OtherHelpsGlobal where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                    cmdcancel.Parameters.AddWithValue("@id", d);
                                    cmdcancel.Parameters.AddWithValue("@amount2", consume);
                                    cmdcancel.Parameters.AddWithValue("@amount3", stock);
                                    cmdcancel.Parameters.AddWithValue("@tname2", "othersConsume");
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

                }

            }
            con.Close();
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = (!string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text) && !string.IsNullOrEmpty(explainTextBox.Text) && !string.IsNullOrWhiteSpace(explainTextBox.Text));
        }
    }
}
