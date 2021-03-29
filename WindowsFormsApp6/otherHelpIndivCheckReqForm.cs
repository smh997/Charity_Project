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
    public partial class otherHelpIndivCheckReqForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id = "", rId, explain, mId;
        decimal fee;
        bool rad = false;
        public otherHelpIndivCheckReqForm(string rId, string id = "", string st = "")
        {
            InitializeComponent();
            this.rId = rId;
            if (id != "")
            {
                this.id = id;
                this.Text = "ویرایش بررسی درخواست کمک متفرقه فردی";
            }
            if (st != "")
            {
                this.rad = true;
                this.Text = "ویرایش بررسی درخواست کمک متفرقه فردی";
            }
        }

        private void otherHelpIndivCheckReqForm_Load(object sender, EventArgs e)
        {
            cashtypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rIdTextBox.SelectionAlignment = HorizontalAlignment.Center;
            mIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            rIdTextBox.Text = ExtensionFunction.EnglishToPersian(this.rId);
            if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                denyButton.Enabled = setButton.Enabled = false;
                SqlCommand cmdget = new SqlCommand("select mId, description from OtherHelpIndivReq where id = @id;", con);
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
                cashtypeComboBox.Enabled = false;
                if (rad)
                {
                    SqlCommand cmdget = new SqlCommand("select mId, description, enactmentId from OtherHelpIndivReq where id = @id;", con);
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
                    SqlCommand cmdget = new SqlCommand("select reqId, mId, OtherHelpsIndiv.description, OtherHelpsIndiv.enactmentId, fee, OtherHelpIndivReq.description, cashtype from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.id = @id;", con);
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
                            if (reader.GetString(6) == "نقدی")
                            {
                                cashtypeComboBox.Text = "نقدی";
                            }
                            else
                            {
                                cashtypeComboBox.Text = "غیرنقدی";
                            }
                        }
                    }
                }
                label17.Text = "توضیحات کمک:"; label17.Location = new Point(searchButton.Location.X + 5, searchButton.Location.Y + 50);
                delButton.Visible = true;
            }
            con.Close();
        }
        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            denyButton.Enabled = setButton.Enabled = (!string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text) && !string.IsNullOrEmpty(explainTextBox.Text) && !string.IsNullOrWhiteSpace(explainTextBox.Text));
        }

        private void visitFormButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.rId + "\\req")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void visitDocsButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("مشاهده مدارک دیگر کمک متفرقه فردی", this.rId, "OIRhelp:otherDoc");
            newform.ShowDialog(this);
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

        private void explainTextBox2_TextChanged(object sender, EventArgs e)
        {
            denyButton.Enabled = setButton.Enabled = (!string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text) && !string.IsNullOrEmpty(explainTextBox.Text) && !string.IsNullOrWhiteSpace(explainTextBox.Text));
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update OtherHelpIndivReq Set status = @rstat, enactmentId = @eId where id = @rId;", con);
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
                SqlCommand cmd = new SqlCommand("update OtherHelpIndivReq Set status = @rstat, enactmentId = Null where id = @rId;", con);
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
                if (cashtypeComboBox.Text == "نقدی")
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
                    
                    System.IO.Directory.Delete(this.helpPath + "\\" + this.id, true);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsIndiv where id = @id; update OtherHelpIndivReq Set status = @rstat, enactmentId = Null where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);//update budgetsCurrencies Set amount = @amount3 where typename = @tname3;
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@rId", this.rId);
                    cmd.Parameters.AddWithValue("@rstat", "ثبت شده");
                    cmd.Parameters.AddWithValue("@amount2", consume - this.fee);
                    //cmd.Parameters.AddWithValue("@amount3", stock + this.fee);
                    cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                    //cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با شماره " + ExtensionFunction.EnglishToPersian(this.id) + " با موفقیت حذف شد و درخواست با شماره " + this.rId + " مجددا آماده بررسی است!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
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
                    System.IO.Directory.Delete(this.helpPath + "\\" + this.id, true);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from OtherHelpsIndiv where id = @id; update OtherHelpIndivReq Set status = @rstat, enactmentId = Null where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@rId", this.rId);
                    cmd.Parameters.AddWithValue("@rstat", "ثبت شده");
                    cmd.Parameters.AddWithValue("@amount2", consume - this.fee);
                    cmd.Parameters.AddWithValue("@amount3", stock + this.fee);
                    cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                    cmd.Parameters.AddWithValue("@tname3", "stock");
                    cmd.ExecuteNonQuery();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با شماره " + ExtensionFunction.EnglishToPersian(this.id) + " با موفقیت حذف شد و درخواست با شماره " + this.rId + " مجددا آماده بررسی است!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    con.Close();
                    this.Close();
                }   
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
                if (this.Text == "بررسی درخواست کمک متفرقه فردی")
                {
                    decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                    if (cashtypeComboBox.Text == "نقدی")
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
                            string d = DateTime.Now.Date.ToPersian(); d = "OI" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                            SqlCommand cmdgetid = new SqlCommand("select id from OtherHelpsIndiv where id like '" + d + "%';", con);
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
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsIndiv (id, reqId, subdate, description, enactmentId, status, fee, cashtype) Values (@id, @rId, @sdate, @des, @eId, @stat, @fee, @cashtype); update OtherHelpIndivReq Set status = @rstat, enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@rId", this.rId);
                            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@des", "(توضیحات کمک: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd.Parameters.AddWithValue("@stat", "ارائه");
                            if(cashtypeComboBox.Text == "نقدی")
                            {
                                cmd.Parameters.AddWithValue("@cashtype", "نقدی");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@cashtype", "غیرنقدی");
                            }
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@rstat", "تایید");
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                            //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                            //cmd.Parameters.AddWithValue("@tname3", "stock");
                            cmd.ExecuteNonQuery();
                            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                            string d = DateTime.Now.Date.ToPersian(); d = "OI" + d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                            SqlCommand cmdgetid = new SqlCommand("select id from OtherHelpsIndiv where id like '" + d + "%';", con);
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
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into OtherHelpsIndiv (id, reqId, subdate, description, enactmentId, status, fee) Values (@id, @rId, @sdate, @des, @eId, @stat, @fee); update OtherHelpIndivReq Set status = @rstat, enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@rId", this.rId);
                            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@des", "(توضیحات کمک: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd.Parameters.AddWithValue("@stat", "ارائه");
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@rstat", "تایید");
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                            cmd.Parameters.AddWithValue("@tname3", "stock");
                            cmd.ExecuteNonQuery();
                            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            con.Close();
                            this.Close();
                        }
                    }
                }
                else
                {
                    decimal budget = 0, consume = 0, stock = 0, familyBudget = 0;
                    if (cashtypeComboBox.Text == "نقدی")
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
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set description = @des, fee = @fee, enactmentId = @eId where id = @id; update OtherHelpIndivReq Set enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@rId", this.rId);
                            cmd.Parameters.AddWithValue("@des", this.explain + " " + "(توضیحات ویرایش کمک: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                            //cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                            cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                            //cmd.Parameters.AddWithValue("@tname3", "stock");
                            cmd.ExecuteNonQuery();
                            FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set description = @des, fee = @fee, enactmentId = @eId where id = @id; update OtherHelpIndivReq Set enactmentId = @eId where id = @rId; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update budgetsCurrencies Set amount = @amount3 where typename = @tname3; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@rId", this.rId);
                            cmd.Parameters.AddWithValue("@des", this.explain + " " + "(توضیحات ویرایش کمک: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                            cmd.Parameters.AddWithValue("@amount3", stock - feeNumericUpDown.Value + this.fee);
                            cmd.Parameters.AddWithValue("@tname2", "othersConsume");
                            cmd.Parameters.AddWithValue("@tname3", "stock");
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
}
