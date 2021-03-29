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
    public partial class marryHelpForm2 : Form
    {
        public marryHelpForm2()
        {
            InitializeComponent();
        }

        private void sendIntroduceButton_Click(object sender, EventArgs e)
        {
            var newform = new searchHelpForm("ارسال معرفی‌نامه جهیزیه");
            newform.ShowDialog(this);
        }

        private void editSendIntroduceButton_Click(object sender, EventArgs e)
        {
            var newform = new searchHelpForm("ویرایش ارسال معرفی‌نامه جهیزیه");
            newform.ShowDialog(this);
        }

        private void setResultButton_Click(object sender, EventArgs e)
        {
            var newform = new searchHelpForm("دریافت نتیجه معرفی‌نامه جهیزیه");
            newform.ShowDialog(this);
        }

        private void editResultButton_Click(object sender, EventArgs e)
        {
            var newform = new searchHelpForm("ویرایش نتیجه معرفی‌نامه جهیزیه");
            newform.ShowDialog(this);
        }
    }
}
