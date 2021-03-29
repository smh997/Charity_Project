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
    public partial class kickForm : Form
    {
        public kickForm(string p)
        {
            InitializeComponent();
            this.Text = p;
        }

        private void deletefamilyButton_Click(object sender, EventArgs e)
        {
            kickForm2 newform;
            switch (this.Text)
            {
                case "حذف پوشش":
                    newform = new kickForm2("حذف پوشش خانوار");
                    newform.ShowDialog(this);
                    break;
                case "ویرایش حذف پوشش":
                    newform = new kickForm2("ویرایش حذف پوشش خانوار");
                    newform.ShowDialog(this);
                    break;
                case "ثبت تحقیق":
                    newform = new kickForm2("ثبت تحقیق خانواری");
                    newform.ShowDialog(this);
                    break;
                case "حذف تحقیق":
                    newform = new kickForm2("حذف تحقیق خانواری");
                    newform.ShowDialog(this);
                    break;
                default:
                    break;
            }
        }

        private void deletememberButton_Click(object sender, EventArgs e)
        {
            kickForm2 newform;
            switch (this.Text)
            {
                case "حذف پوشش":
                    newform = new kickForm2("حذف پوشش فرد");
                    newform.ShowDialog(this);
                    break;
                case "ویرایش حذف پوشش":
                    newform = new kickForm2("ویرایش حذف پوشش فرد");
                    newform.ShowDialog(this);
                    break;
                case "ثبت تحقیق":
                    newform = new kickForm2("ثبت تحقیق فردی");
                    newform.ShowDialog(this);
                    break;
                case "حذف تحقیق":
                    newform = new kickForm2("حذف تحقیق فردی");
                    newform.ShowDialog(this);
                    break;
                default:
                    break;
            }
        }

        private void kickForm_Load(object sender, EventArgs e)
        {
            switch (this.Text)
            {
                case "ویرایش حذف پوشش":
                    this.BackColor = Color.Yellow;
                    break;
                case "ثبت تحقیق":
                    this.BackColor = Color.DodgerBlue;
                    deletememberButton.BackColor = Color.Turquoise; deletememberButton.Text = "تحقیق فردی";
                    deletefamilyButton.BackColor = Color.Cyan; deletefamilyButton.Text = "تحقیق خانواری";
                    deletefamilyButton.FlatAppearance.BorderColor = deletememberButton.FlatAppearance.BorderColor = Color.SteelBlue;
                    break;
                default:
                    break;
            }
        }
    }
}
