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
    public partial class editReceivedLetterForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string receivedLettersPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\receivedLetters";
        string doc, id;
        bool preattach;
        public editReceivedLetterForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void editReceivedLetterForm2_Load(object sender, EventArgs e)
        {
            identicalTextBox.SelectionAlignment = HorizontalAlignment.Center;
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            titleTextBox.SelectionAlignment = HorizontalAlignment.Center;
            senderTextBox.SelectionAlignment = HorizontalAlignment.Center;
            signerTextBox.SelectionAlignment = HorizontalAlignment.Center;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select title, signer, sender, recdate, attachment, id_i from receivedLetters where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    identicalTextBox.Text = this.id;
                    idTextBox.Text = reader.GetString(5);
                    titleTextBox.Text = reader.GetString(0);
                    signerTextBox.Text = reader.GetString(1);
                    senderTextBox.Text = reader.GetString(2);
                    recDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["recdate"]));
                    if (reader.GetString(4) == "بله")
                    {
                        this.preattach = attachmentCheckBox.Checked = true;
                        attachmentLabel.Visible = attachmetAddFileButton.Visible = true;
                    }
                    else
                    {
                        attachmentLabel.BackColor = Color.Red;
                    }
                }
            }
            SqlCommand cmdgetfile = new SqlCommand("select docpath from doc where id = @id and doctype = 'Letter';", con);
            cmdgetfile.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetfile.ExecuteReader())
            {
                if (reader.Read())
                {
                    doc = reader.GetString(0);
                }
            }
            con.Close();
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

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (titleTextBox.Text.Length != 0 && myreg.IsMatch(titleTextBox.Text.Substring(titleTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                titleTextBox.Text = titleTextBox.Text.Substring(0, titleTextBox.Text.Length - 1);
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
            var newform = new doceditForm("ویرایش پیوست‌ها", this.id, "LetterAttachment");
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                attachmentLabel.BackColor = Color.Red;
            else
                attachmentLabel.BackColor = Color.LimeGreen;
        }

        private void attachmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            attachmetAddFileButton.Visible = attachmentLabel.Visible = attachmentCheckBox.Checked;
        }

        private void recDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (recDateTimePickerX.SelectedDateInDateTime.Date < DateTime.Now.Date)
            {
                recDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void seachEnactmentbutton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.doc);
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
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش نامه اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }

            SqlConnection con = new SqlConnection(this.connection);
            con.Open();

            if (docLabel.BackColor == Color.YellowGreen)
            {
                string fileName = System.IO.Path.GetFileName(doc);
                string iddir = this.receivedLettersPath + "\\" + this.id;
                System.IO.Directory.CreateDirectory(iddir);
                string targetPath = iddir + "\\" + "doc";
                System.IO.Directory.Delete(targetPath, true);
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update receivedLetters set id_i = @id_i, title = @title, sender = @sender, signer = @signer, attachment = @attach, recdate = @recdate, subdate = @subdate where id = @id; insert into receivedLettersHistory (id_i, id, title, sender, signer, attachment, recdate, subdate, enactmentId) Values(@id_i, @id, @title, @sender, @signer, @attach, @recdate, @subdate, @eId); delete from doc where id = @id and doctype = 'Letter'; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id_i", idTextBox.Text);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                cmd.Parameters.AddWithValue("@sender", senderTextBox.Text);
                cmd.Parameters.AddWithValue("@signer", signerTextBox.Text);
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                if (attachmentCheckBox.Checked)
                {
                    cmd.Parameters.AddWithValue("@attach", "بله");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@attach", "خیر");
                    SqlCommand cmddel = new SqlCommand("delete from doc where id = @id and doctype = 'LetterAttachment';", con);
                    cmddel.Parameters.AddWithValue("@id", this.id);
                    cmddel.ExecuteNonQuery();
                    if (System.IO.Directory.Exists(this.receivedLettersPath + "\\" + this.id + "\\attachments"))
                    {
                        System.IO.Directory.Delete(this.receivedLettersPath + "\\" + this.id + "\\attachments", true);
                    }
                }
                cmd.Parameters.AddWithValue("@recdate", recDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "Letter");
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update receivedLetters set id_i = @id_i, title = @title, sender = @sender, signer = @signer, attachment = @attach, recdate = @recdate, subdate = @subdate where id = @id; insert into receivedLettersHistory (id_i, id, title, sender, signer, attachment, recdate, subdate, enactmentId) Values(@id_i, @id, @title, @sender, @signer, @attach, @recdate, @subdate, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id_i", idTextBox.Text);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                cmd.Parameters.AddWithValue("@sender", senderTextBox.Text);
                cmd.Parameters.AddWithValue("@signer", signerTextBox.Text);
                cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                if (attachmentCheckBox.Checked)
                {
                    cmd.Parameters.AddWithValue("@attach", "بله");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@attach", "خیر");
                    SqlCommand cmddel = new SqlCommand("delete from doc where id = @id and doctype = 'LetterAttachment';", con);
                    cmddel.Parameters.AddWithValue("@id", this.id);
                    cmddel.ExecuteNonQuery();
                    if (System.IO.Directory.Exists(this.receivedLettersPath + "\\" + this.id + "\\attachments"))
                    {
                        System.IO.Directory.Delete(this.receivedLettersPath + "\\" + this.id + "\\attachments", true);
                    }
                }
                cmd.Parameters.AddWithValue("@recdate", recDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("نامه دریافتی با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }
    }
}
