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
    public partial class reqForm : Form
    {
        public reqForm(string p="")
        {
            InitializeComponent();
            if (p != "")
            {
                this.Text = p;
            }
        }

        private void newReqButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "بررسی تقاضا")
            {
                var newform = new editReqForm("بررسی تقاضا");
                newform.ShowDialog(this);
            }
            else if(this.Text == "ارائه معرفی‌نامه")
            {
                var newform = new editReqForm("ثبت ارائه معرفی‌نامه");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new newReqForm();
                newform.ShowDialog(this);
            }
        }

        private void editReqButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "بررسی تقاضا")
            {
                var newform = new editReqForm("ویرایش بررسی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه معرفی‌نامه")
            {
                var newform = new editReqForm("ویرایش ارائه معرفی‌نامه");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new editReqForm();
                newform.ShowDialog(this);
            }
        }

        private void reqForm_Load(object sender, EventArgs e)
        {
            if(this.Text == "بررسی تقاضا")
            {
                newReqButton.Text = "بررسی جدید";
                editReqButton.Text = "ویرایش بررسی";
            }
            else if(this.Text == "ارائه معرفی‌نامه")
            {
                newReqButton.Text = "ثبت";
                editReqButton.Text = "ویرایش";
            }
        }
    }
}
