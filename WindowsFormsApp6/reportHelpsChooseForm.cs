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
    public partial class reportHelpsChooseForm : Form
    {
        string typ;
        public reportHelpsChooseForm(string typ)
        {
            InitializeComponent();
            this.typ = typ;
            this.Text += typ;
            if(typ == "خانوار")
            {
                idLabel.Text += "پرونده:";
            }
            else
            {
                idLabel.Text += "ملی:";
            }
        }

        private void reportHelpsChooseForm_Load(object sender, EventArgs e)
        {
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(this.typ == "خانوار")
            {
                var newform = new searchForm("انتخاب خانوار");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else
            {
                var newform = new searchForm("ویرایش عضو");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            var newform = new reportHelpsForm(this.typ, ExtensionFunction.PersianToEnglish(idTextbox.Text));
            newform.ShowDialog(this);
        }
    }
}
