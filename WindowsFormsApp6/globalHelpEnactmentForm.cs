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
    public partial class globalHelpEnactmentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, type, status = "";
        decimal metric = 0, fee = 0;
        int packets = 0;
        DateTime subdate;
        public globalHelpEnactmentForm(string p = "", string id = "")
        {
            InitializeComponent();
            if(p != "")
            {
                this.Text = p;
                this.id = id;
            }
        }

        private void startDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (this.Text == "ویرایش کمک جمعی با مصوبه")
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

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            decimal budget = 0, consume = 0, stock = 0;
            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
            cmdget.Parameters.AddWithValue("@id", "othersBudegt");
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
            SqlCommand cmd = new SqlCommand("begin tran t1; delete from tmpDefinedTableHelp where gId = @id; delete from delDefinedTableHelp where gId = @id; delete from finalizedTableHelp where gId = @id; delete from GlobalHelps where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            switch (this.type)
            {
                case "گوشت":
                    cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                    cmd.Parameters.AddWithValue("@tname3", "meat");
                    break;
                case "خواربار":
                    cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                    cmd.Parameters.AddWithValue("@tname3", "grocery");
                    break;
                case "مرغ":
                    cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                    cmd.Parameters.AddWithValue("@tname3", "chicken");
                    break;
                case "نان":
                    cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                    cmd.Parameters.AddWithValue("@tname3", "bread");
                    break;
            }
            cmd.Parameters.AddWithValue("@amount2", consume - this.fee);
            cmd.Parameters.AddWithValue("@amount3", stock + this.fee);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.Text.Length == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("نوع کمک تعیین نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
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
                if(this.Text == "ویرایش کمک جمعی با مصوبه")
                {
                    if (this.status != "تعریف شده")
                    {
                        if(this.type != typeComboBox.Text)
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            switch (typeComboBox.Text)
                            {
                                case "گوشت":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "meat");
                                    break;
                                case "خواربار":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "grocery");
                                    break;
                                case "مرغ":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "chicken");
                                    break;
                                case "نان":
                                    cmdget.Parameters.AddWithValue("@id", "breadBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "bread");
                                    break;
                            }
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
                            if ((typeComboBox.Text == "نان" || this.type == "نان") && consume + feeNumericUpDown.Value > budget)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                decimal preconsume = 0, prestock = 0;
                                cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                switch (this.type)
                                {
                                    case "گوشت":
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "meat");
                                        break;
                                    case "خواربار":
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "grocery");
                                        break;
                                    case "مرغ":
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "chicken");
                                        break;
                                    case "نان":
                                        cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "bread");
                                        break;
                                }
                                using (SqlDataReader reader = cmdget2.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        preconsume = reader.GetDecimal(0);
                                    }
                                }
                                using (SqlDataReader reader = cmdget3.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        prestock = reader.GetDecimal(0);
                                    }
                                }
                                SqlCommand cmd = new SqlCommand("begin tran t1; update GlobalHelps Set type = @type, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount where typename = @tname; update budgetsCurrencies Set amount = @amount1 where typename = @tname1; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
                                cmd.Parameters.AddWithValue("@id", this.id);
                                cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                if (typeComboBox.Text == "نان" || this.type == "نان")
                                {
                                    cmd.Parameters.AddWithValue("@amount", preconsume - feeNumericUpDown.Value);
                                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                    
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@amount", preconsume);
                                    cmd.Parameters.AddWithValue("@amount2", consume);
                                }
                                cmd.Parameters.AddWithValue("@amount1", prestock + feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                switch (typeComboBox.Text)
                                {
                                    case "گوشت":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "meat");
                                        break;
                                    case "خواربار":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "grocery");
                                        break;
                                    case "مرغ":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "chicken");
                                        break;
                                    case "نان":
                                        cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "bread");
                                        break;
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SqlCommand cmdupdate = new SqlCommand("update GlobalHelps Set enactmentId = @eId, description = @des where id = @id;", con);
                            cmdupdate.Parameters.AddWithValue("@id", this.id);
                            cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                            cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmdupdate.ExecuteNonQuery();
                        }
                        FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        if (this.type != typeComboBox.Text)
                        {
                            decimal budget = 0, consume = 0, stock = 0;
                            SqlCommand cmdget = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            SqlCommand cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                            switch (typeComboBox.Text)
                            {
                                case "گوشت":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "meat");
                                    break;
                                case "خواربار":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "grocery");
                                    break;
                                case "مرغ":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "chicken");
                                    break;
                                case "نان":
                                    cmdget.Parameters.AddWithValue("@id", "breadBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "bread");
                                    break;
                            }
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
                            if (((typeComboBox.Text == "نان" || this.type == "نان") && consume + feeNumericUpDown.Value > budget) || ((typeComboBox.Text != "نان" && this.type != "نان") && consume + feeNumericUpDown.Value - this.fee > budget))
                            {
                                FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else if (feeNumericUpDown.Value > stock)
                            {
                                FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                return;
                            }
                            else
                            {
                                decimal preconsume = 0, prestock = 0;string tname="", tname1="";
                                cmdget2 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                cmdget3 = new SqlCommand("select amount from budgetsCurrencies where typename = @id", con);
                                switch (this.type)
                                {
                                    case "گوشت":
                                        tname = "groceryConsume";
                                        tname1 = "meat";
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "meat");
                                        break;
                                    case "خواربار":
                                        tname = "groceryConsume";
                                        tname1 = "grocery";
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "grocery");
                                        break;
                                    case "مرغ":
                                        tname = "groceryConsume";
                                        tname1 = "chicken";
                                        cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "chicken");
                                        break;
                                    case "نان":
                                        tname = "breadConsume";
                                        tname1 = "bread";
                                        cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                        cmdget3.Parameters.AddWithValue("@id", "bread");
                                        break;
                                }
                                using (SqlDataReader reader = cmdget2.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        preconsume = reader.GetDecimal(0);
                                    }
                                }
                                using (SqlDataReader reader = cmdget3.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        prestock = reader.GetDecimal(0);
                                    }
                                }
                                SqlCommand cmd = new SqlCommand("begin tran t1; update GlobalHelps Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des, type = @type where id = @id; update budgetsCurrencies Set amount = @amount where typename = @tname; update budgetsCurrencies Set amount = @amount1 where typename = @tname1; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
                                cmd.Parameters.AddWithValue("@id", this.id);
                                cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                                cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                if (typeComboBox.Text == "نان" || this.type == "نان")
                                {
                                    cmd.Parameters.AddWithValue("@amount", preconsume - this.fee);
                                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@amount", preconsume + feeNumericUpDown.Value - this.fee);
                                    cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                }
                                cmd.Parameters.AddWithValue("@amount1", prestock + this.fee);
                                cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                                cmd.Parameters.AddWithValue("@tname", tname);
                                cmd.Parameters.AddWithValue("@tname1", tname1);
                                switch (typeComboBox.Text)
                                {
                                    case "گوشت":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "meat");
                                        break;
                                    case "خواربار":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "grocery");
                                        break;
                                    case "مرغ":
                                        cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "chicken");
                                        break;
                                    case "نان":
                                        cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                                        cmd.Parameters.AddWithValue("@tname3", "bread");
                                        break;
                                }
                                cmd.ExecuteNonQuery();
                                var newform = new globalHelpListForm(this.id, "ویرایش کمک جمعی");
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
                            switch (typeComboBox.Text)
                            {
                                case "گوشت":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "meat");
                                    break;
                                case "خواربار":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "grocery");
                                    break;
                                case "مرغ":
                                    cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "chicken");
                                    break;
                                case "نان":
                                    cmdget.Parameters.AddWithValue("@id", "breadBudget");
                                    cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                                    cmdget3.Parameters.AddWithValue("@id", "bread");
                                    break;
                            }
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
                                
                                SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update GlobalHelps Set fee = @fee, packets = @packs, startdate = @sdate, enactmentId = @eId, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                                cmdupdate.Parameters.AddWithValue("@id", this.id);
                                cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                                cmdupdate.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                                cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
                                cmdupdate.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                                cmdupdate.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                                cmdupdate.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                                switch (typeComboBox.Text)
                                {
                                    case "گوشت":
                                        cmdupdate.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmdupdate.Parameters.AddWithValue("@tname3", "meat");
                                        break;
                                    case "خواربار":
                                        cmdupdate.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmdupdate.Parameters.AddWithValue("@tname3", "grocery");
                                        break;
                                    case "مرغ":
                                        cmdupdate.Parameters.AddWithValue("@tname2", "groceryConsume");
                                        cmdupdate.Parameters.AddWithValue("@tname3", "chicken");
                                        break;
                                    case "نان":
                                        cmdupdate.Parameters.AddWithValue("@tname2", "breadConsume");
                                        cmdupdate.Parameters.AddWithValue("@tname3", "bread");
                                        break;
                                }
                                cmdupdate.ExecuteNonQuery();
                                var newform = new globalHelpListForm(this.id, "ویرایش کمک جمعی");
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
                    switch (typeComboBox.Text)
                    {
                        case "گوشت":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "meat");
                            break;
                        case "خواربار":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "grocery");
                            break;
                        case "مرغ":
                            cmdget.Parameters.AddWithValue("@id", "groceryBudget");
                            cmdget2.Parameters.AddWithValue("@id", "groceryConsume");
                            cmdget3.Parameters.AddWithValue("@id", "chicken");
                            break;
                        case "نان":
                            cmdget.Parameters.AddWithValue("@id", "breadBudget");
                            cmdget2.Parameters.AddWithValue("@id", "breadConsume");
                            cmdget3.Parameters.AddWithValue("@id", "bread");
                            break;
                    }
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
                        string d = DateTime.Now.Date.ToPersian(); d = "G" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                        cmdget = new SqlCommand("select id from GlobalHelps where id like '" + d + "%';", con);
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
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into GlobalHelps (id, type, fee, packets, startdate, subdate, enactmentId, status, metric, description, defType) Values (@id, @type, @fee, @packs, @sdate, @subdate, @eId, @stat, @metric, @des, @def); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", d);
                        cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@sdate", startDateTimePickerX.SelectedDateInDateTime.Date);
                        cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                        cmd.Parameters.AddWithValue("@def", "با مصوبه");
                        cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                        cmd.Parameters.AddWithValue("@stat", "تعریف شده");
                        cmd.Parameters.AddWithValue("@metric", metric);
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                        switch (typeComboBox.Text)
                        {
                            case "گوشت":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "meat");
                                break;
                            case "خواربار":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "grocery");
                                break;
                            case "مرغ":
                                cmd.Parameters.AddWithValue("@tname2", "groceryConsume");
                                cmd.Parameters.AddWithValue("@tname3", "chicken");
                                break;
                            case "نان":
                                cmd.Parameters.AddWithValue("@tname2", "breadConsume");
                                cmd.Parameters.AddWithValue("@tname3", "bread");
                                break;
                        }
                        cmd.ExecuteNonQuery();
                        var newform = new globalHelpListForm(d);
                        newform.ShowDialog(this);
                        if (newform.Text == "fail")
                        {
                            SqlCommand cmdcancel = new SqlCommand("BEGIN TRY begin tran t1; delete from tmpDefinedTableHelp where gId = @id; delete from delDefinedTableHelp where gId = @id; delete from GlobalHelps where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmdcancel.Parameters.AddWithValue("@id", d);
                            cmdcancel.Parameters.AddWithValue("@amount2", consume);
                            cmdcancel.Parameters.AddWithValue("@amount3", stock);
                            switch (typeComboBox.Text)
                            {
                                case "گوشت":
                                    cmdcancel.Parameters.AddWithValue("@tname2", "groceryConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "meat");
                                    break;
                                case "خواربار":
                                    cmdcancel.Parameters.AddWithValue("@tname2", "groceryConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "grocery");
                                    break;
                                case "مرغ":
                                    cmdcancel.Parameters.AddWithValue("@tname2", "groceryConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "chicken");
                                    break;
                                case "نان":
                                    cmdcancel.Parameters.AddWithValue("@tname2", "breadConsume");
                                    cmdcancel.Parameters.AddWithValue("@tname3", "bread");
                                    break;
                            }
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

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void globalHelpEnactmentForm_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            if(this.Text == "ویرایش کمک جمعی با مصوبه")
            {
                this.BackColor = Color.Yellow;delButton.Visible = true;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                
                SqlCommand cmdget = new SqlCommand("select type, fee, packets, startdate, enactmentId, status, metric, description, subdate from GlobalHelps where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using(SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.type = typeComboBox.Text = reader.GetString(0);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(1);
                        startDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["startdate"])).Date;
                        enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(reader.GetString(4));
                        this.packets = reader.GetInt32(2);
                        packetNumericUpDown.Value = Convert.ToDecimal(this.packets);
                        this.status = reader.GetString(5);
                        this.metric = reader.GetDecimal(6);
                        explainTextBox.Text = String.Format("{0}", reader["description"]);
                        this.subdate = Convert.ToDateTime(String.Format("{0}", reader["subdate"])).Date;
                    }
                }
                if(this.status != "تعریف شده")
                {
                    delButton.Enabled = startDateTimePickerX.Enabled = packetNumericUpDown.Enabled = feeNumericUpDown.Enabled = false;
                }
                con.Close();
            }
        }
    }
}
