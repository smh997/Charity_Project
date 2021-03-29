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
    public partial class globalHelpsSuddenForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string id, type, status = "";
        decimal metric = 0, fee = 0, packFee, packpoint;
        int packets = 0;
        List<KeyValuePair<decimal, string>> li;
        Dictionary<string, Tuple<string, int, decimal>> di, di1, di2;

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from tmpDefinedTableHelp where gId = @id; delete from delDefinedTableHelp where gId = @id; delete from finalizedTableHelp where gId = @id; delete from GlobalHelps where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
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
            cmd.Parameters.AddWithValue("@amount2", this.fee);
            cmd.Parameters.AddWithValue("@amount3", this.fee);
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        KeyValuePair<decimal, string>[] arr;
        private void globalHelpsSuddenForm_Load(object sender, EventArgs e)
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            if (this.Text == "ویرایش کمک جمعی اتفاقی")
            {
                this.BackColor = Color.Yellow; delButton.Visible = true;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand cmdget = new SqlCommand("select type, fee, packets, status, metric, description from GlobalHelps where id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.type = typeComboBox.Text = reader.GetString(0);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(1);
                        this.packets = reader.GetInt32(2);
                        packetNumericUpDown.Value = Convert.ToDecimal(this.packets);
                        this.status = reader.GetString(6);
                        this.metric = reader.GetDecimal(7);
                        explainTextBox.Text = String.Format("{0}", reader["description"]);
                    }
                }
                if (this.status != "تعریف شده")
                {
                    delButton.Enabled = packetNumericUpDown.Enabled = feeNumericUpDown.Enabled = false;
                }
                con.Close();
            }
        }    

        public globalHelpsSuddenForm(string p = "", string id = "")
        {
            InitializeComponent();
            li = new List<KeyValuePair<decimal, string>>();
            di = new Dictionary<string, Tuple<string, int, decimal>>();
            di1 = new Dictionary<string, Tuple<string, int, decimal>>();
            di2 = new Dictionary<string, Tuple<string, int, decimal>>();
            if (p != "")
            {
                this.Text = p;
                this.id = id;
            }
        }
        private void updaterate()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select distinct gId, folder_id, GlobalHelps.packets, receivedTableHelp.packets, fee from GlobalHelps, receivedTableHelp where (GlobalHelps.status = N'تایید شده' or GlobalHelps.status = N'نهایی') and id = gId and DATEADD(day,@days, enddate) >= @now;", con);
            SqlCommand cmdgetparam = new SqlCommand("select point from parameters where name = 'day';", con);
            using (SqlDataReader reader = cmdgetparam.ExecuteReader())
            {
                if (reader.Read())
                {
                    cmdget.Parameters.AddWithValue("@days", reader.GetInt32(0));
                }
            }
            cmdget.Parameters.AddWithValue("@now", DateTime.Now.Date);
            int p = 0; decimal f = 0;
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (di.ContainsKey(reader.GetString(1)))
                        di[reader.GetString(1)] = new Tuple<string, int, decimal>(di[reader.GetString(1)].Item1, di[reader.GetString(1)].Item2, di[reader.GetString(1)].Item3 - (reader.GetDecimal(4) * reader.GetInt32(3) / reader.GetInt32(2)) / this.metric);
                }
            }
            con.Close();
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
            if (this.Text == "ویرایش کمک جمعی اتفاقی")
            {
                if (this.status != "تعریف شده")
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
                        if ((typeComboBox.Text == "نان" || this.type == "نان") && consume + feeNumericUpDown.Value > budget)
                        {
                            FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است باید در اولین فرصت بودجه اصلاح شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        }
                        if (feeNumericUpDown.Value > stock)
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
                            SqlCommand cmd = new SqlCommand("begin tran t1; update GlobalHelps Set type = @type, description = @des where id = @id; update budgetsCurrencies Set amount = @amount where typename = @tname; update budgetsCurrencies Set amount = @amount1 where typename = @tname1; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
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
                        SqlCommand cmdupdate = new SqlCommand("update GlobalHelps Set description = @des where id = @id;", con);
                        cmdupdate.Parameters.AddWithValue("@id", this.id);
                        cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
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
                            FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است باید در اولین فرصت بودجه اصلاح شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        }
                        if (feeNumericUpDown.Value > stock)
                        {
                            FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            return;
                        }
                        else
                        {
                            decimal preconsume = 0, prestock = 0; string tname = "", tname1 = "";
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
                            SqlCommand cmd = new SqlCommand("begin tran t1; update GlobalHelps Set fee = @fee, packets = @packs, description = @des, type = @type where id = @id; update budgetsCurrencies Set amount = @amount where typename = @tname; update budgetsCurrencies Set amount = @amount1 where typename = @tname1; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
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
                            this.packets = Convert.ToInt32(packetNumericUpDown.Value);
                            this.fee = feeNumericUpDown.Value;
                            this.type = typeComboBox.Text;
                            this.packFee = this.fee / this.packets;
                            this.packpoint = this.packFee / this.metric;
                            cmdget = new SqlCommand("select supporter_id, folder_id, packets, rate from tmpDefinedTableHelp where gId = @id;", con);
                            cmdget.Parameters.AddWithValue("@id", this.id);
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                                    di1[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                                }
                            }
                            decimal sum = 0; int consumep = 0;
                            li.Clear();
                            foreach (var dd in di1)
                            {
                                sum += dd.Value.Item3;
                            }
                            foreach (var dd in di)
                            {
                                if (di1.ContainsKey(dd.Key))
                                {
                                    int p = Convert.ToInt32(dd.Value.Item3 * this.packets / sum); consumep += p;
                                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                                    li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                                }
                            }
                            arr = li.ToArray();
                            arr.OrderBy((x => x.Key)).ToArray();
                            Array.Reverse(arr);
                            int i = 0;
                            while (consumep != this.packets)
                            {
                                di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                                i++;
                                consumep++;
                            }
                            foreach (var dd in di1)
                            {
                                SqlCommand cmdupdate = new SqlCommand("update tmpDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                                cmdupdate.Parameters.AddWithValue("@gId", this.id);
                                cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                                cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                                cmdupdate.ExecuteNonQuery();
                            }
                            cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from finalizedTableHelp where gId = @gId; insert into finalizedTableHelp (gId, supporter_id, folder_id, name, family, fatherName, packets, rate) select gId, supporter_id, folder_id, name, family, fatherName, packets, rate from tmpDefinedTableHelp where gId = @gId and packets != 0; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@gId", this.id);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                            FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است باید در اولین فرصت بودجه اصلاح شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        }
                        if (feeNumericUpDown.Value > this.fee && feeNumericUpDown.Value - this.fee > stock)
                        {
                            FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            return;
                        }
                        else
                        {

                            SqlCommand cmdupdate = new SqlCommand("BEGIN TRY begin tran t1; update GlobalHelps Set fee = @fee, packets = @packs, description = @des where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmdupdate.Parameters.AddWithValue("@id", this.id);
                            cmdupdate.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmdupdate.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                            cmdupdate.Parameters.AddWithValue("@des", explainTextBox.Text);
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
                            this.packets = Convert.ToInt32(packetNumericUpDown.Value);
                            this.fee = feeNumericUpDown.Value;
                            this.type = typeComboBox.Text;
                            this.packFee = this.fee / this.packets;
                            this.packpoint = this.packFee / this.metric;
                            cmdget = new SqlCommand("select supporter_id, folder_id, packets, rate from tmpDefinedTableHelp where gId = @id;", con);
                            cmdget.Parameters.AddWithValue("@id", this.id);
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                                    di1[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                                }
                            }
                            decimal sum = 0; int consumep = 0;
                            li.Clear();
                            foreach (var dd in di1)
                            {
                                sum += dd.Value.Item3;
                            }
                            foreach (var dd in di)
                            {
                                if (di1.ContainsKey(dd.Key))
                                {
                                    int p = Convert.ToInt32(dd.Value.Item3 * this.packets / sum); consumep += p;
                                    di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                                    li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                                }
                            }
                            arr = li.ToArray();
                            arr.OrderBy((x => x.Key)).ToArray();
                            Array.Reverse(arr);
                            int i = 0;
                            while (consumep != this.packets)
                            {
                                di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                                i++;
                                consumep++;
                            }
                            foreach (var dd in di1)
                            {
                                cmdupdate = new SqlCommand("update tmpDefinedTableHelp Set packets = @packs where folder_id = @fId and gId = @gId;", con);
                                cmdupdate.Parameters.AddWithValue("@gId", this.id);
                                cmdupdate.Parameters.AddWithValue("@fId", dd.Key);
                                cmdupdate.Parameters.AddWithValue("@packs", dd.Value.Item2);
                                cmdupdate.ExecuteNonQuery();
                            }
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from finalizedTableHelp where gId = @gId; insert into finalizedTableHelp (gId, supporter_id, folder_id, name, family, fatherName, packets, rate) select gId, supporter_id, folder_id, name, family, fatherName, packets, rate from tmpDefinedTableHelp where gId = @gId and packets != 0; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@gId", this.id);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                    FMessegeBox.FarsiMessegeBox.Show("این درخواست خارج از محدوده بودجه تعریف شده است باید در اولین فرصت بودجه اصلاح شود!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                if (feeNumericUpDown.Value > stock)
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
                    this.id = d = d + index.ToString();
                    SqlCommand cmd = new SqlCommand("begin tran t1; insert into GlobalHelps (id, type, fee, packets, subdate, startdate, status, metric, description, defType) Values (@id, @type, @fee, @packs, @subdate, @subdate, @stat, @metric, @des, @def); update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1;", con);
                    cmd.Parameters.AddWithValue("@id", d);
                    cmd.Parameters.AddWithValue("@type", typeComboBox.Text);
                    cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@packs", packetNumericUpDown.Value);
                    cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
                    cmd.Parameters.AddWithValue("@def", "اتفاقی");
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
                    this.packets = Convert.ToInt32(packetNumericUpDown.Value);
                    this.fee = feeNumericUpDown.Value;
                    this.type = typeComboBox.Text;
                    this.packFee = this.fee / this.packets;
                    this.packpoint = this.packFee / this.metric;
                    SqlCommand cmdgetfamilies = new SqlCommand("select id, folder_id, rate from member where id = supporter_id;", con);
                    using (SqlDataReader reader = cmdgetfamilies.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            di[reader.GetString(1)] = new Tuple<string, int, decimal>(reader.GetString(0), 0, Convert.ToDecimal(reader.GetInt32(2)));
                        }
                    }
                    if (di.Count == 0)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("خانواری وجود ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    updaterate();
                    decimal sum = 0; int consumep = 0;
                    foreach (var dd in di)
                    {
                        sum += dd.Value.Item3;
                    }
                    foreach (var dd in di)
                    {
                        int p = Convert.ToInt32(dd.Value.Item3 * this.packets / sum); consumep += p;
                        di1[dd.Key] = new Tuple<string, int, decimal>(dd.Value.Item1, p, dd.Value.Item3);
                        li.Add(new KeyValuePair<decimal, string>(((dd.Value.Item3 - p * this.packpoint < 0) ? 0 : dd.Value.Item3 - p * this.packpoint), dd.Key));
                    }
                    arr = li.ToArray();
                    arr.OrderBy((x => x.Key)).ToArray();
                    Array.Reverse(arr);
                    int i = 0;
                    while (consumep != this.packets)
                    {
                        di1[arr[i].Value] = new Tuple<string, int, decimal>(di1[arr[i].Value].Item1, di1[arr[i].Value].Item2 + 1, di1[arr[i].Value].Item3);
                        i++;
                        consumep++;
                    }
                    SqlCommand cmdgettmp;
                    foreach (var dd in di1)
                    {
                        cmdgettmp = new SqlCommand("insert into tmpDefinedTableHelp(gId, supporter_id, folder_id, name, family, fatherName, packets, rate) Values(@gId, @sId, @fId, @name, @family, @father, @packs, @rate);", con);
                        cmdgettmp.Parameters.AddWithValue("@gId", this.id);
                        cmdgettmp.Parameters.AddWithValue("@sId", dd.Value.Item1);
                        SqlCommand cmdgetdata = new SqlCommand("select name, family, fatherName from member where id = @id;", con);
                        cmdgetdata.Parameters.AddWithValue("@id", dd.Value.Item1);
                        using(SqlDataReader reader = cmdgetdata.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmdgettmp.Parameters.AddWithValue("@name", reader.GetString(0));
                                cmdgettmp.Parameters.AddWithValue("@family", reader.GetString(1));
                                cmdgettmp.Parameters.AddWithValue("@father", reader.GetString(2));
                            }
                        }
                        cmdgettmp.Parameters.AddWithValue("@fId", dd.Key);
                        cmdgettmp.Parameters.AddWithValue("@packs", dd.Value.Item2);
                        cmdgettmp.Parameters.AddWithValue("@rate", dd.Value.Item3);
                        cmdgettmp.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("insert into finalizedTableHelp (gId, supporter_id, folder_id, name, family, fatherName, packets, rate) select gId, supporter_id, folder_id, name, family, fatherName, packets, rate from tmpDefinedTableHelp where gId = @gId and packets != 0;", con);
                    cmd.Parameters.AddWithValue("@gId", this.id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
            }
        }
    }
}
