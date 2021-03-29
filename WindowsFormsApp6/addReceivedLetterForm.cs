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
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class addReceivedLetterForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string receivedLettersPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\receivedLetters";
        string doc, id;
        List<string> attli;
        string[] attachments;
        public addReceivedLetterForm()
        {
            InitializeComponent();
            attli = new List<string>();
        }

        private void addReceivedLetterForm_Load(object sender, EventArgs e)
        {
            identicalTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            titleTextBox.SelectionAlignment = HorizontalAlignment.Center;
            senderTextBox.SelectionAlignment = HorizontalAlignment.Center;
            signerTextBox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetnum = new SqlCommand("select id_i from receivedLetters;", con);
            int index = 1, mx = 1;
            using (SqlDataReader reader = cmdgetnum.ExecuteReader())
            {
                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    if (s == "") index = 1;
                    else index = Convert.ToInt32(s.Substring(2)) + 1;
                    mx = Math.Max(mx, index);
                }
            }
            identicalTextBox.Text = "RL " + mx.ToString();
            this.id = "RL" + mx.ToString();
            con.Close();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (titleTextBox.Text.Length != 0 && myreg.IsMatch(titleTextBox.Text.Substring(titleTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                titleTextBox.Text = titleTextBox.Text.Substring(0, titleTextBox.Text.Length - 1);
            }
        }

        private void senderTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (senderTextBox.Text.Length != 0 && myreg.IsMatch(senderTextBox.Text.Substring(senderTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                senderTextBox.Text = senderTextBox.Text.Substring(0, senderTextBox.Text.Length - 1);
            }
        }

        private void signerTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (signerTextBox.Text.Length != 0 && myreg.IsMatch(signerTextBox.Text.Substring(signerTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                signerTextBox.Text = signerTextBox.Text.Substring(0, signerTextBox.Text.Length - 1);
            }
        }

        private void recDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (recDateTimePickerX.SelectedDateInDateTime.Date < DateTime.Now.Date)
            {
                recDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void docAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب فایل نامه";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc = addOpenFileDialog.FileName;
                docLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                addOpenFileDialog.FileName = "*.pdf";
            }
        }

        private void attachmetAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب پیوست‌ها";
            addOpenFileDialog.Multiselect = true;
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                attli.Clear();
                foreach (var d in addOpenFileDialog.FileNames)
                {
                    attli.Add(@d);
                }
                attachmentLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                attli.Clear();
                addOpenFileDialog.FileName = "*.pdf";
                attachmentLabel.BackColor = Color.Red;
            }
            addOpenFileDialog.Multiselect = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idTextBox.Text))
            {
                idTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("شماره نامه وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                titleTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("عنوان وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(senderTextBox.Text))
            {
                senderTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("فرستنده وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(signerTextBox.Text))
            {
                signerTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("امضاکننده وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (docLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایل نامه انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (attachmentCheckBox.Checked && attachmentLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فایل‌های پیوست انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت نامه اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            this.id = "RL" + ExtensionFunction.PersianToEnglish(idTextBox.Text);
            string fileName = System.IO.Path.GetFileName(doc);
            string iddir = this.receivedLettersPath + "\\" + this.id;
            System.IO.Directory.CreateDirectory(iddir);
            string targetPath = iddir + "\\" + "doc";
            System.IO.Directory.CreateDirectory(targetPath);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(doc, destFile, false);
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into receivedLetters (id_i, id, title, sender, signer, attachment, recdate, subdate) Values(@id_i, @id, @title, @sender, @signer, @attach, @recdate, @subdate); insert into receivedLettersHistory (id_i, id, title, sender, signer, attachment, recdate, subdate) Values(@id_i, @id, @title, @sender, @signer, @attach, @recdate, @subdate); insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.Parameters.AddWithValue("@id_i", idTextBox.Text);
            cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
            cmd.Parameters.AddWithValue("@sender", senderTextBox.Text);
            cmd.Parameters.AddWithValue("@signer", signerTextBox.Text);
            if (attachmentCheckBox.Checked)
            {
                cmd.Parameters.AddWithValue("@attach", "بله");
            }
            else
            {
                cmd.Parameters.AddWithValue("@attach", "خیر");
            }
            cmd.Parameters.AddWithValue("@recdate", recDateTimePickerX.SelectedDateInDateTime.Date);
            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@dname", fileName);
            cmd.Parameters.AddWithValue("@dpath", destFile);
            cmd.Parameters.AddWithValue("@dtype", "Letter");
            cmd.ExecuteNonQuery();
            if (attachmentCheckBox.Checked)
            {
                this.attachments = attli.ToArray();
                foreach (string attachment in this.attachments)
                {
                    int i = 2;
                    fileName = System.IO.Path.GetFileName(attachment);
                    targetPath = iddir + "\\" + "attachments";
                    System.IO.Directory.CreateDirectory(targetPath);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    while (System.IO.File.Exists(destFile))
                    {
                        destFile = System.IO.Path.Combine(targetPath, fileName + "(" + i.ToString() + ")");
                        i++;
                    }
                    System.IO.File.Copy(doc, destFile, false);
                    SqlCommand cmdattach = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con);
                    cmdattach.Parameters.AddWithValue("@id", this.id);
                    cmdattach.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                    cmdattach.Parameters.AddWithValue("@dname", fileName);
                    cmdattach.Parameters.AddWithValue("@dpath", destFile);
                    cmdattach.Parameters.AddWithValue("@dtype", "LetterAttachment");
                    cmdattach.ExecuteNonQuery();
                }
            }
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("نامه دریافتی با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }

        private void senderTextBox_Enter(object sender, EventArgs e)
        {
            senderTextBox.BackColor = SystemColors.Window;
        }

        private void signerTextBox_Enter(object sender, EventArgs e)
        {
            signerTextBox.BackColor = SystemColors.Window;
        }

        private void titleTextBox_Enter(object sender, EventArgs e)
        {
            titleTextBox.BackColor = SystemColors.Window;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (idTextBox.Text.Length != 0 && myreg.IsMatch(idTextBox.Text.Substring(idTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                idTextBox.Text = idTextBox.Text.Substring(0, idTextBox.Text.Length - 1);
            }
        }

        private void idTextBox_Enter(object sender, EventArgs e)
        {
            idTextBox.BackColor = SystemColors.Window;
        }

        private void attachmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            attachmetAddFileButton.Visible = attachmentLabel.Visible = attachmentCheckBox.Checked;
        }
    }
}
