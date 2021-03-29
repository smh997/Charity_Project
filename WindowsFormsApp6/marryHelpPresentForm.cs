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
    public partial class marryHelpPresentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, type, mId, RF, explain, prebId;
        decimal fee;
        List<KeyValuePair<string, string>> li;

        public marryHelpPresentForm(string id, string typ, string p = "")
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
            this.id = id;
            this.type = typ;
            if(p != "")
            {
                this.Text = p;
            }
        }

        private void marryHelpPresentForm_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            mIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            feeTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.Text = ExtensionFunction.EnglishToPersian(this.id);
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    bankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            if (this.Text == "ارائه کمک ازدواج")
            {
                if (type == "نقدی")
                {
                    visitAssignmentButton.Visible = false;
                    feeTextBox.Visible = label3.Visible = true;
                    cmdget = new SqlCommand("select mId, MarryHelps.description, MarryHelpReq.description, fee from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1);
                            this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                            feeTextBox.Text = ExtensionFunction.EnglishToPersian(Convert.ToUInt64(reader.GetDecimal(3)).ToString());
                        }
                    }
                }
                else
                {
                    bankAccountNameComboBox.Enabled = false;
                    cmdget = new SqlCommand("select mId, MarryHelps.description, MarryHelpReq.description, introdescription, resdescription from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4);
                            this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                        }
                    }
                }
            }
            else
            {
                this.BackColor = Color.Yellow;
                visitPreReceiptButton.Visible = delButton.Visible = true;
                receiptLabel.BackColor = Color.YellowGreen;
                label22.Location = new Point(label22.Location.X, label22.Location.Y - 12);
                receiptLabel.Location = new Point(receiptLabel.Location.X, receiptLabel.Location.Y - 12);
                receiptAddFileButton.Location = new Point(receiptAddFileButton.Location.X, receiptAddFileButton.Location.Y - 12);
                
                if (type == "نقدی")
                {
                    visitAssignmentButton.Visible = false;
                    feeTextBox.Visible = label3.Visible = true;
                    cmdget = new SqlCommand("select mId, MarryHelps.description, MarryHelpReq.description, presdescription, fee, bankAccountName, bankAccountId from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3); this.explain = reader.GetString(3);
                            this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                            feeTextBox.Text = ExtensionFunction.EnglishToPersian(Convert.ToUInt64(reader.GetDecimal(4)).ToString());
                            this.fee = reader.GetDecimal(4);
                            this.prebId = reader.GetString(6);
                            bankAccountNameComboBox.Text = reader.GetString(5);
                            bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(this.prebId);
                        }
                    }
                    int c = 0;
                    SqlCommand cmdcheck = new SqlCommand("select count(*) from bankAccount where id = @id;", con);
                    cmdcheck.Parameters.AddWithValue("@id", this.prebId);
                    using (SqlDataReader reader = cmdcheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            c = reader.GetInt32(0);
                        }
                    }
                    if (c == 0)
                    {
                        bankAccountNameComboBox.Text += "(حذف شده)";
                        bankAccountNameComboBox.Enabled = false;
                        delButton.Enabled = false;
                    }
                }
                else
                {
                    bankAccountNameComboBox.Enabled = false;
                    cmdget = new SqlCommand("select mId, MarryHelps.description, MarryHelpReq.description, introdescription, resdescription, presdescription from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5); this.explain = reader.GetString(5);
                            this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                        }
                    }
                }
            }
            con.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به حذف ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (type == "نقدی")
            {
                decimal prestock = 0;
                SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @id;", con);
                cmdgetst.Parameters.AddWithValue("@id", this.prebId);
                using (SqlDataReader reader = cmdgetst.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        prestock = reader.GetDecimal(0);
                    }
                }
                SqlCommand cmdu = new SqlCommand("update bankAccount set stock = @st where id = @bId;", con);
                cmdu.Parameters.AddWithValue("@bId", this.prebId);
                cmdu.Parameters.AddWithValue("@st", prestock + fee);
                cmdu.ExecuteNonQuery();
            }
            
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
            System.IO.File.Delete(dpath);
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set presdescription = Null, enddate = Null, status = @stat where id = @id; delete from doc where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@stat", "ارائه");
            cmd.Parameters.AddWithValue("@dtype", "Mhelp:receipt");
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("ارائه کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void bankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[bankAccountNameComboBox.SelectedIndex].Key);
        }

        private void visitPreReceiptButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
            System.Diagnostics.Process.Start(dpath);
        }
        

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ارائه کمک ازدواج")
            {
                if (this.type == "نقدی")
                {
                    if(bankAccountNameComboBox.SelectedIndex == -1)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("حساب بانکی انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    if (receiptLabel.BackColor == Color.Red)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("فیش پرداخت بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    decimal stock = 0;
                    SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                    cmdgetst.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    using(SqlDataReader reader = cmdgetst.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = reader.GetDecimal(0);
                        }
                    }
                    if(stock < fee)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("موجودی حساب کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (res != DialogResult.Yes)
                    {
                        return;
                    }
                    string fileName = System.IO.Path.GetFileName(RF);
                    string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set presdescription = @des, enddate = @edate, status = @stat, bankAccountName = @bName, bankAccountId = @bId where id = @id; update bankAccount set stock = @st where id = @bId; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @edate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", "(توضیحات ارائه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@stat", "پایان‌یافته: ارائه شده");
                    cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd.Parameters.AddWithValue("@st", stock - fee);
                    cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
                    cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "Mhelp:receipt");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت به مددجو ارائه شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
                else
                {
                    if (receiptLabel.BackColor == Color.Red)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("رسید بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }

                    SqlConnection con = new SqlConnection(this.connection);
                    con.Open();
                    string fileName = System.IO.Path.GetFileName(RF);
                    string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set presdescription = @des, enddate = @edate, status = @stat where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @edate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", "(توضیحات ارائه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@stat", "پایان‌یافته: ارائه شده");
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "Mhelp:receipt");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت به مددجو ارائه شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    this.Close();
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                decimal prestock = 0, stock = 0;
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    SqlCommand cmdgetst = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                    cmdgetst.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    using (SqlDataReader reader = cmdgetst.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = reader.GetDecimal(0);
                        }
                    }
                    cmdgetst = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                    cmdgetst.Parameters.AddWithValue("@bId", this.prebId);
                    using (SqlDataReader reader = cmdgetst.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prestock = reader.GetDecimal(0);
                        }
                    }
                }
                if (stock < fee)
                {
                    FMessegeBox.FarsiMessegeBox.Show("موجودی حساب قبلی برای ویرایش کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                if (this.prebId != ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text))
                {
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@prev", this.prebId);
                    cmd.Parameters.AddWithValue("@st", prestock + fee);
                    cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd.Parameters.AddWithValue("@newst", stock - fee);
                    cmd.ExecuteNonQuery();
                }
                if (receiptLabel.BackColor == Color.GreenYellow)
                {
                    string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                    System.IO.File.Delete(dpath);
                    string fileName = System.IO.Path.GetFileName(RF);
                    string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set presdescription = @des where id = @id; update doc Set docname = @dname, docpath = @dpath, subdate = @edate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "Mhelp:receipt");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update MarryHelps Set presdescription = @des where id = @id;", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("ارائه کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }

        private void visitAssignmentButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\assignment")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void receiptAddFileButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ارائه کمک ازدواج")
            {
                addOpenFileDialog.Title = "انتخاب فایل رسید";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RF = addOpenFileDialog.FileName;
                    receiptLabel.BackColor = Color.YellowGreen;
                }
                else
                {
                    RF = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    receiptLabel.BackColor = Color.Red;
                }
            }
            else
            {
                addOpenFileDialog.Title = "انتخاب فایل رسید";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RF = addOpenFileDialog.FileName;
                    receiptLabel.BackColor = Color.GreenYellow;
                }
                else
                {
                    RF = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    receiptLabel.BackColor = Color.YellowGreen;
                }
            }
        }
    }
}
