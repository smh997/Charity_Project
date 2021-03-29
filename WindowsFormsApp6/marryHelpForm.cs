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
    public partial class marryHelpForm : Form
    {
        public marryHelpForm()
        {
            InitializeComponent();
        }

        private void reqButton_Click(object sender, EventArgs e)
        {
            var newform = new specialHelpsForm2("درخواست کمک ازدواج");
            newform.ShowDialog(this);
        }

        private void checkReqButton_Click(object sender, EventArgs e)
        {
            var newform = new specialHelpsForm2("بررسی درخواست کمک ازدواج");
            newform.ShowDialog(this);
        }

        private void drowryButton_Click(object sender, EventArgs e)
        {
            var newform = new marryHelpForm2();
            newform.ShowDialog(this);
        }

        private void marryHelpForm_Load(object sender, EventArgs e)
        {

        }

        private void marryHelpForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }
    }
}
