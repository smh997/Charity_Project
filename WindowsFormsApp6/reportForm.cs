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
    public partial class reportForm : Form
    {
        public reportForm()
        {
            InitializeComponent();
        }

        private void reqButton_Click(object sender, EventArgs e)
        {
            var newform = new reportReqsForm();
            newform.ShowDialog(this);
        }

        private void helpFamilyButton_Click(object sender, EventArgs e)
        {
            var newform = new reportHelpsChooseForm("خانوار");
            newform.ShowDialog(this);
        }

        private void helpMemberButton_Click(object sender, EventArgs e)
        {
            var newform = new reportHelpsChooseForm("مددجو");
            newform.ShowDialog(this);
        }
    }
}
