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
    public partial class healHelpForm : Form
    {
        public healHelpForm()
        {
            InitializeComponent();
        }

        private void reqButton_Click(object sender, EventArgs e)
        {
            var newform = new specialHelpsForm2("درخواست کمک درمان");
            newform.ShowDialog(this);
        }

        private void checkReqButton_Click(object sender, EventArgs e)
        {
            var newform = new specialHelpsForm2("بررسی درخواست کمک درمان");
            newform.ShowDialog(this);
        }
    }
}
