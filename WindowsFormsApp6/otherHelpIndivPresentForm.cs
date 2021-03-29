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
    public partial class otherHelpIndivPresentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, mId, explain, RF, cashtype, prebId;
        decimal fee;
        public otherHelpIndivPresentForm(string id, string p = "")
        {
            InitializeComponent();
            this.id = id;
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void otherHelpIndivPresentForm_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            mIdTextbox.SelectionAlignment = HorizontalAlignment.Center;
            feeTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.Text = ExtensionFunction.EnglishToPersian(this.id);
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget;
            if (this.Text == "ارائه کمک متفرقه فردی")
            {
                feeTextBox.Visible = label3.Visible = true;
                cmdget = new SqlCommand("select mId, OtherHelpsIndiv.description, OtherHelpIndivReq.description, fee, cashtype from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1);
                        this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                        feeTextBox.Text = ExtensionFunction.EnglishToPersian(Convert.ToUInt64(reader.GetDecimal(3)).ToString());
                        this.fee = reader.GetDecimal(3);
                        this.cashtype = reader.GetString(4);
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
                feeTextBox.Visible = label3.Visible = true;
                cmdget = new SqlCommand("select mId, OtherHelpsIndiv.description, OtherHelpIndivReq.description, presdescription, fee, cashtype, bankAccountName, bankAccountId from OtherHelpsIndiv, OtherHelpIndivReq where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpsIndiv.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3); this.explain = reader.GetString(3);
                        this.mId = reader.GetString(0); mIdTextbox.Text = ExtensionFunction.EnglishToPersian(this.mId);
                        feeTextBox.Text = ExtensionFunction.EnglishToPersian(Convert.ToUInt64(reader.GetDecimal(4)).ToString());
                        this.fee = reader.GetDecimal(4);
                        this.cashtype = reader.GetString(5);
                        this.prebId = reader.GetString(7);
                        bankAccountNumberTextBox.Text = ExtensionFunction.EnglishToPersian(this.prebId);
                        bankAccountNameComboBox.Text = reader.GetString(6);
                    }
                }
            }
            if(cashtype == "غیرنقدی")
            {
                bankAccountNameComboBox.Enabled = false;
            }
            con.Close();
        }
        private void visitPreReceiptButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسیت به حذف ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
            System.IO.File.Delete(dpath);
            if(cashtype == "نقدی")
            {
                decimal stock = 0;
                SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                cmdget.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                using(SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stock = reader.GetDecimal(0);
                    }
                }
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = Null, enddate = Null, status = @stat where id = @bId; update bankAccount set stock = @st where id = @id; delete from doc where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@stat", "ارائه");
                cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                cmd.Parameters.AddWithValue("@st", stock + fee);
                cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = Null, enddate = Null, status = @stat where id = @id; update bankAccount set stock = @st where id = @id; delete from doc where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@stat", "ارائه");
                cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                cmd.ExecuteNonQuery();
            }
            
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("ارائه کمک با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }
        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ارائه کمک متفرقه فردی")
            {
                if (receiptLabel.BackColor == Color.Red)
                {
                    FMessegeBox.FarsiMessegeBox.Show("فیش پرداخت بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();

                if(cashtype == "نقدی")
                {
                    decimal stock = 0;
                    SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                    cmdget.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = reader.GetDecimal(0);
                        }
                    }
                    if (stock < fee)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        return;
                    }
                    DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسیت به ثبت ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (res != DialogResult.Yes)
                    {
                        return;
                    }
                    string fileName = System.IO.Path.GetFileName(RF);
                    string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = @des, enddate = @edate, status = @stat where id = @id; update bankAccount set stock = @st where id = @bId; insert into doc(id, docname, docpath, subdate, doctype) Values (@id, @dname, @dpath, @edate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", "(توضیحات ارائه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@stat", "پایان‌یافته: ارائه شده");
                    cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                    cmd.Parameters.AddWithValue("@st", stock + fee);
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسیت به ثبت ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    if (res != DialogResult.Yes)
                    {
                        return;
                    }
                    string fileName = System.IO.Path.GetFileName(RF);
                    string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                    SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = @des, enddate = @edate, status = @stat where id = @id; insert into doc(id, docname, docpath, subdate, doctype) Values (@id, @dname, @dpath, @edate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@des", "(توضیحات ارائه: " + explainTextBox2.Text + ")");
                    cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@stat", "پایان‌یافته: ارائه شده");
                    cmd.Parameters.AddWithValue("@dname", fileName);
                    cmd.Parameters.AddWithValue("@dpath", destFile);
                    cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                    cmd.ExecuteNonQuery();
                }
                
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("کمک با موفقیت به مددجو ارائه شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                if(cashtype == "نقدی")
                {
                    if(this.prebId != bankAccountNumberTextBox.Text)
                    {
                        decimal stock = 0, prestock = 0;
                        SqlCommand cmdget = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                        cmdget.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stock = reader.GetDecimal(0);
                            }
                        }
                        cmdget = new SqlCommand("select stock from bankAccount where id = @bId;", con);
                        cmdget.Parameters.AddWithValue("@bId", this.prebId);
                        using (SqlDataReader reader = cmdget.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prestock = reader.GetDecimal(0);
                            }
                        }
                        if(stock < fee)
                        {
                            FMessegeBox.FarsiMessegeBox.Show("موجودی کافی نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            return;
                        }
                        DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسیت به ویرایش ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        if (res != DialogResult.Yes)
                        {
                            return;
                        }
                        SqlCommand cmdu = new SqlCommand("BEGIN TRY begin tran t1; update bankAccount set stock = @st where id = @prev; update bankAccount set stock = @newst where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmdu.Parameters.AddWithValue("@prev", this.prebId);
                        cmdu.Parameters.AddWithValue("@st", prestock + fee);
                        cmdu.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                        cmdu.Parameters.AddWithValue("@newst", stock - fee);
                        cmdu.ExecuteNonQuery();
                        if (receiptLabel.BackColor == Color.GreenYellow)
                        {
                            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                            System.IO.File.Delete(dpath);
                            string fileName = System.IO.Path.GetFileName(RF);
                            string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = @des, bankAccountName = @bName, bankAccountId = @bId where id = @id; update doc Set docname = @dname, docpath = @dpath, subdate = @edate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
                            cmd.Parameters.AddWithValue("@bId", ExtensionFunction.PersianToEnglish(bankAccountNumberTextBox.Text));
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("update OtherHelpsIndiv Set presdescription = @des, bankAccountName = @bName, bankAccountId = @bId where id = @id;", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@bName", bankAccountNameComboBox.Text);
                            cmd.Parameters.AddWithValue("@bId", ExtensionFunction.EnglishToPersian(bankAccountNumberTextBox.Text));
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسیت به ویرایش ارائه این کمک اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        if (res != DialogResult.Yes)
                        {
                            return;
                        }
                        if (receiptLabel.BackColor == Color.GreenYellow)
                        {
                            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                            System.IO.File.Delete(dpath);
                            string fileName = System.IO.Path.GetFileName(RF);
                            string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = @des where id = @id; update doc Set docname = @dname, docpath = @dpath, subdate = @edate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("update OtherHelpsIndiv Set presdescription = @des where id = @id;", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    if (receiptLabel.BackColor == Color.GreenYellow)
                    {
                        string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\receipt")[0];
                        System.IO.File.Delete(dpath);
                        string fileName = System.IO.Path.GetFileName(RF);
                        string targetPath = this.helpPath + "\\" + this.id + "\\receipt";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update OtherHelpsIndiv Set presdescription = @des where id = @id; update doc Set docname = @dname, docpath = @dpath, subdate = @edate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                        cmd.Parameters.AddWithValue("@edate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@dpath", destFile);
                        cmd.Parameters.AddWithValue("@dtype", "OIhelp:receipt");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update OtherHelpsIndiv Set presdescription = @des where id = @id;", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش ارائه: " + explainTextBox2.Text + ")");
                        cmd.ExecuteNonQuery();
                    }
                }
                
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("ارائه کمک با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }

        private void receiptAddFileButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "ارائه کمک متفرقه فردی")
            {
                addOpenFileDialog.Title = "انتخاب فایل فیش پرداخت";
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
                addOpenFileDialog.Title = "انتخاب فایل فیش پرداخت";
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
