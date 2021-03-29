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
    public partial class otherHelpForm : Form
    {
        public otherHelpForm()
        {
            InitializeComponent();
        }

        private void globalButton_Click(object sender, EventArgs e)
        {
            var newform = new globalHelpsForm("تعریف کمک متفرقه گروهی");
            newform.ShowDialog(this);
        }

        private void indivButton_Click(object sender, EventArgs e)
        {
            var newform = new otherHelpIndivForm();
            newform.ShowDialog(this);
        }
    }
}
