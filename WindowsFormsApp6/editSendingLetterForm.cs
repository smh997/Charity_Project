using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class editSendingLetterForm : Form
    {
        public editSendingLetterForm()
        {
            InitializeComponent();
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void editSendingLetterForm_Load(object sender, EventArgs e)
        {
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("ویرایش نامه ارسالی");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            var newform = new editSendingLetterForm2(ExtensionFunction.PersianToEnglish(idTextbox.Text));
            newform.ShowDialog(this);
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }
    }
}
