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
    public partial class marryResForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string helpPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\helps";
        string id, rId, assignment, explain;
        decimal fee;
        bool rad = false;
        public marryResForm(string id, string p = "", string st = "")
        {
            InitializeComponent();
            this.id = id;
            if (p != "")
            {
                this.Text = p;
            }
            if (st != "")
            {
                this.rad = true;
            }
        }

        private void marryResForm_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.Text = ExtensionFunction.EnglishToPersian(this.id);
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmdget;
            con.Open();
            if (this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                cmdget = new SqlCommand("select reqId, MarryHelps.description, MarryHelpReq.description, introdescription, fee from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                cmdget.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3);
                        this.fee = feeNumericUpDown.Value = reader.GetDecimal(4);
                        this.rId = reader.GetString(0);
                    }
                }
            }
            else
            {
                this.BackColor = Color.Yellow; delButton.Visible = true; denyButton.Visible = false;
                if (rad)
                {
                    setButton.Text = "لغو ویرایش";
                    feeNumericUpDown.Enabled = explainTextBox2.Enabled = assignmentAddFileButton.Enabled = false;
                    cmdget = new SqlCommand("select reqId, MarryHelps.description, MarryHelpReq.description, introdescription, resdescription, fee from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.rId = reader.GetString(0);
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4);
                            this.fee = feeNumericUpDown.Value = reader.GetDecimal(5);
                        }
                    }
                }
                else
                {
                    visitPreAssignmentButton.Visible = true;
                    assignmentLabel.BackColor = Color.YellowGreen;
                    label22.Location = new Point(label22.Location.X, label22.Location.Y - 12);
                    assignmentLabel.Location = new Point(assignmentLabel.Location.X, assignmentLabel.Location.Y - 12);
                    assignmentAddFileButton.Location = new Point(assignmentAddFileButton.Location.X, assignmentAddFileButton.Location.Y - 12);
                    cmdget = new SqlCommand("select reqId, MarryHelps.description, MarryHelpReq.description, introdescription, resdescription, fee from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelps.id = @id;", con);
                    cmdget.Parameters.AddWithValue("@id", this.id);
                    using (SqlDataReader reader = cmdget.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.rId = reader.GetString(0);
                            explainTextBox.Text = reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3) + " " + reader.GetString(4); this.explain = reader.GetString(4);
                            this.fee = feeNumericUpDown.Value = reader.GetDecimal(5);
                        }
                    }
                }
                
            }
            con.Close();
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set status = @stat, resdescription = @des, recdate = @rdate, enddate = @rdate where id = @id; update MarryHelpReq Set status = @rstat where id = @rId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@stat", "پایان‌یافته: رد معرفی‌نامه");
            cmd.Parameters.AddWithValue("@des", "(توضیح رد شدن معرفی‌نامه: " + explainTextBox2.Text + ")");
            cmd.Parameters.AddWithValue("@rdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@rId", this.rId);
            cmd.Parameters.AddWithValue("@rstat", "ثبت شده نقدی");
            cmd.ExecuteNonQuery();
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("نتیجه (رد شدن معرفی‌نامه) با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (rad)
            {
                this.Close();
            }
            else
            {
                if (assignmentLabel.BackColor == Color.Red)
                {
                    FMessegeBox.FarsiMessegeBox.Show("حواله بارگزاری نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    return;
                }
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                if (this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
                {
                    decimal budget = 0, consume = 0;
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
                    else
                    {
                        string fileName = System.IO.Path.GetFileName(assignment);
                        string targetPath = this.helpPath + "\\" + this.id + "\\assignment";
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                        SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set resdescription = @des, recdate = @rdate, status = @stat, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @rdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                        cmd.Parameters.AddWithValue("@id", this.id);
                        cmd.Parameters.AddWithValue("@des", "(توضیحات نتیجه معرفی‌نامه: " + explainTextBox2.Text + ")");
                        cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                        cmd.Parameters.AddWithValue("@rdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@stat", "ارائه");
                        cmd.Parameters.AddWithValue("@dname", fileName);
                        cmd.Parameters.AddWithValue("@dpath", destFile);
                        cmd.Parameters.AddWithValue("@dtype", "Mhelp:assignment");
                        cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                        cmd.Parameters.AddWithValue("@tname2", "marryConsume");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("حواله با موفقیت ثبت و آماده ارائه به مددجو می‌باشد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
                else
                {
                    decimal budget = 0, consume = 0;
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
                    else
                    {
                        if (assignmentLabel.BackColor == Color.GreenYellow)
                        {
                            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\assignment")[0];
                            System.IO.File.Delete(dpath);
                            string fileName = System.IO.Path.GetFileName(assignment);
                            string targetPath = this.helpPath + "\\" + this.id + "\\assignment";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(addOpenFileDialog.FileName, destFile, false);
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set resdescription = @des, recdate = @rdate, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; update doc Set docname = @dname, docpath = @dpath, subdate = @rdate where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش نتیجه معرفی‌نامه: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@rdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@dname", fileName);
                            cmd.Parameters.AddWithValue("@dpath", destFile);
                            cmd.Parameters.AddWithValue("@dtype", "Mhelp:assignment");
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                            cmd.Parameters.AddWithValue("@tname2", "marryConsume");
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set resdescription = @des, fee = @fee where id = @id; update budgetsCurrencies Set amount = @amount2 where typename = @tname2; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                            cmd.Parameters.AddWithValue("@id", this.id);
                            cmd.Parameters.AddWithValue("@des", this.explain + "(توضیحات ویرایش نتیجه معرفی‌نامه: " + explainTextBox2.Text + ")");
                            cmd.Parameters.AddWithValue("@fee", feeNumericUpDown.Value);
                            cmd.Parameters.AddWithValue("@amount2", consume + feeNumericUpDown.Value - this.fee);
                            cmd.Parameters.AddWithValue("@tname2", "marryConsume");
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        FMessegeBox.FarsiMessegeBox.Show("ویرایش نتیجه معرفی‌نامه با موفقیت انجام شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        this.Close();
                    }
                }
            }
        }

        private void assignmentAddFileButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                addOpenFileDialog.Title = "انتخاب فایل حواله";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    assignment = addOpenFileDialog.FileName;
                    assignmentLabel.BackColor = Color.YellowGreen;
                }
                else
                {
                    assignment = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    assignmentLabel.BackColor = Color.Red;
                }
            }
            else
            {
                addOpenFileDialog.Title = "انتخاب فایل حواله";
                addOpenFileDialog.FileName = "*.pdf";
                if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    assignment = addOpenFileDialog.FileName;
                    assignmentLabel.BackColor = Color.GreenYellow;
                }
                else
                {
                    assignment = "";
                    addOpenFileDialog.FileName = "*.pdf";
                    assignmentLabel.BackColor = Color.YellowGreen;
                }
            }
        }

        private void visitPreAssignmentButton_Click(object sender, EventArgs e)
        {
            string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\assignment")[0];
            System.Diagnostics.Process.Start(dpath);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (rad)
            {
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set status = @stat, resdescription = Null, recdate = Null, enddate = Null where id = @id; update MarryHelpReq Set status = @rstat where id = @rId; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@stat", "دریافت نتیجه");
                cmd.Parameters.AddWithValue("@rId", this.rId);
                cmd.Parameters.AddWithValue("@rstat", "تایید");
                cmd.ExecuteNonQuery();
                FMessegeBox.FarsiMessegeBox.Show("نتیجه ثبت شده با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
            else
            {
                string dpath = System.IO.Directory.GetFiles(this.helpPath + "\\" + this.id + "\\assignment")[0];
                System.IO.File.Delete(dpath);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update MarryHelps Set resdescription = Null, recdate = Null, status = @stat where id = @id; delete from doc where id = @id and doctype = @dtype; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@stat", "دریافت نتیجه");
                cmd.Parameters.AddWithValue("@dtype", "Mhelp:assignment");
                cmd.ExecuteNonQuery();
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("نتیجه ثبت شده با موفقیت حذف شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                this.Close();
            }
        }
    }
}
