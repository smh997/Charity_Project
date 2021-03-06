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
    public partial class editSendingLetterForm2 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string sendingLettersPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\sendingLetters";
        string doc, id;
        bool preattach;
        public editSendingLetterForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void editSendingLetterForm2_Load(object sender, EventArgs e)
        {
            idTextBox.SelectionAlignment = HorizontalAlignment.Center;
            titleTextBox.SelectionAlignment = HorizontalAlignment.Center;
            receiverTextBox.SelectionAlignment = HorizontalAlignment.Center;
            signerTextBox.SelectionAlignment = HorizontalAlignment.Center;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select title, signer, receiver, senddate, attachment from sendingLetters where id = @id;", con);
            cmdget.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                if (reader.Read())
                {
                    idTextBox.Text = this.id;
                    titleTextBox.Text = reader.GetString(0);
                    signerTextBox.Text = reader.GetString(1);
                    receiverTextBox.Text = reader.GetString(2);
                    sendDateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["senddate"]));
                    if(reader.GetString(4) == "بله")
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
            using(SqlDataReader reader = cmdgetfile.ExecuteReader())
            {
                if (reader.Read())
                {
                    doc = reader.GetString(0);
                }
            }
            
            con.Close();
        }

        private void receiverTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (receiverTextBox.Text.Length != 0 && myreg.IsMatch(receiverTextBox.Text.Substring(receiverTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                receiverTextBox.Text = receiverTextBox.Text.Substring(0, receiverTextBox.Text.Length - 1);
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

        private void sendDateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (sendDateTimePickerX.SelectedDateInDateTime.Date < DateTime.Now.Date)
            {
                sendDateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
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
        private void receiverTextBox_Enter(object sender, EventArgs e)
        {
            receiverTextBox.BackColor = SystemColors.Window;
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
            if (String.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                titleTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("عنوان وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            if (String.IsNullOrWhiteSpace(receiverTextBox.Text))
            {
                receiverTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("گیرنده وارد نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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

            if(docLabel.BackColor == Color.YellowGreen)
            {
                string fileName = System.IO.Path.GetFileName(doc);
                string iddir = this.sendingLettersPath + "\\" + this.id;
                System.IO.Directory.CreateDirectory(iddir);
                string targetPath = iddir + "\\" + "doc";
                System.IO.Directory.Delete(targetPath, true);
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(doc, destFile, false);
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update sendingLetters set title = @title, receiver = @rec, signer = @signer, attachment = @attach, senddate = @senddate, subdate = @subdate where id = @id; insert into sendingLettersHistory (id, title, receiver, signer, attachment, senddate, subdate, enactmentId) Values(@id, @title, @rec, @signer, @attach, @senddate, @subdate, @eId); delete from doc where id = @id and doctype = 'Letter'; insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                cmd.Parameters.AddWithValue("@rec", receiverTextBox.Text);
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
                    if (System.IO.Directory.Exists(this.sendingLettersPath + "\\" + this.id + "\\attachments"))
                    {
                        System.IO.Directory.Delete(this.sendingLettersPath + "\\" + this.id + "\\attachments", true);
                    }
                }
                cmd.Parameters.AddWithValue("@senddate", sendDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@dname", fileName);
                cmd.Parameters.AddWithValue("@dpath", destFile);
                cmd.Parameters.AddWithValue("@dtype", "Letter");
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; update sendingLetters set title = @title, receiver = @rec, signer = @signer, attachment = @attach, senddate = @senddate, subdate = @subdate where id = @id; insert into sendingLettersHistory (id, title, receiver, signer, attachment, senddate, subdate, enactmentId) Values(@id, @title, @rec, @signer, @attach, @senddate, @subdate, @eId); commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                cmd.Parameters.AddWithValue("@rec", receiverTextBox.Text);
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
                    if (System.IO.Directory.Exists(this.sendingLettersPath + "\\" + this.id + "\\attachments"))
                    {
                        System.IO.Directory.Delete(this.sendingLettersPath + "\\" + this.id + "\\attachments", true);
                    }
                }
                cmd.Parameters.AddWithValue("@senddate", sendDateTimePickerX.SelectedDateInDateTime.Date);
                cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            FMessegeBox.FarsiMessegeBox.Show("نامه ارسالی با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            this.Close();
        }
    }
}
