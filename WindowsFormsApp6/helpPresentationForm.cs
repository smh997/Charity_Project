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
    public partial class helpPresentationForm : Form
    {
        string pp;
        public helpPresentationForm(string p = "", string pp = "")
        {
            InitializeComponent();
            if (p != "")
            {
                this.Text = p;
            }
            if(pp != "")
            {
                this.pp = pp;
            }
        }

        private void indivButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک")
            {
                var newform = new specialHelpsForm("تایید کمک ویژه");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new specialHelpsForm("ارائه کمک ویژه");
                newform.ShowDialog(this);
            }
        }

        private void globalButton_Click(object sender, EventArgs e)
        {
            if(this.Text == "تایید کمک")
            {
                var newform = new helpPresentationForm2("تایید کمک جمعی");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new helpPresentationForm2("ارائه کمک جمعی");
                newform.ShowDialog(this);
            }
        }

        private void otherHelpButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک")
            {
                var newform = new helpPresentationForm2("تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new helpPresentationForm2("ارائه کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
        }

        private void helpPresentationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void otherHelpIndivButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تایید کمک")
            {
                var newform = new helpPresentationForm2("تایید کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else
            {
                var newform = new helpPresentationForm2("ارائه کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
        }
    }
}
