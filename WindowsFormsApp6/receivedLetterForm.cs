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
    public partial class receivedLetterForm : Form
    {
        public receivedLetterForm()
        {
            InitializeComponent();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            var newform = new addReceivedLetterForm();
            newform.ShowDialog(this);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var newform = new editReceivedLetterForm();
            newform.ShowDialog(this);
        }
    }
}
