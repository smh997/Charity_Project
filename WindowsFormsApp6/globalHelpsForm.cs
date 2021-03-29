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
    public partial class globalHelpsForm : Form
    {
        public globalHelpsForm(string p)
        {
            InitializeComponent();
            this.Text = p;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تعریف کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalForm();
                newform.ShowDialog(this);
            }
            else if(this.Text == "تعریف کمک جمعی اتفاقی")
            {
                var newform = new globalHelpsSuddenForm();
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new globalHelpEnactmentForm();
                newform.ShowDialog(this);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تعریف کمک متفرقه گروهی")
            {
                var newform = new searchHelpForm("ویرایش کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تعریف کمک جمعی اتفاقی")
            {
                var newform = new searchHelpForm("ویرایش کمک جمعی اتفاقی");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new searchHelpForm("ویرایش کمک جمعی با مصوبه");
                newform.ShowDialog(this);
            }
        }

        private void globalHelpsForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
