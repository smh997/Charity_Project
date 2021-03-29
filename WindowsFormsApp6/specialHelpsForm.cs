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
    public partial class specialHelpsForm : Form
    {
        string pp="";
        public specialHelpsForm(string p = "")
        {
            InitializeComponent();
            if(p != "")
            {
                this.pp = p;
            }
        }

        private void studyButton_Click(object sender, EventArgs e)
        {
            if(this.pp == "")
            {
                var newform = new specialHelpsForm2("تعریف کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if(this.pp == "ارائه کمک ویژه")
            {
                var newform = new helpPresentationForm2("ارائه کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if(this.pp == "تایید کمک ویژه")
            {
                var newform = new helpPresentationForm2("تایید کمک تحصیلی");
                newform.ShowDialog(this);
            }
        }

        private void specialHelpsForm_Load(object sender, EventArgs e)
        {

        }

        private void marryButton_Click(object sender, EventArgs e)
        {
            if (this.pp == "")
            {
                var newform = new marryHelpForm();
                newform.ShowDialog(this);
            }
            else if (this.pp == "ارائه کمک ویژه")
            {
                var newform = new helpPresentationForm2("ارائه کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.pp == "تایید کمک ویژه")
            {
                var newform = new helpPresentationForm2("تایید کمک ازدواج");
                newform.ShowDialog(this);
            }
        }

        private void healButton_Click(object sender, EventArgs e)
        {
            if (this.pp == "")
            {
                var newform = new healHelpForm();
                newform.ShowDialog(this);
            }
            else if (this.pp == "ارائه کمک ویژه")
            {
                var newform = new helpPresentationForm2("ارائه کمک درمان");
                newform.ShowDialog(this);
            }
            else if (this.pp == "تایید کمک ویژه")
            {
                var newform = new helpPresentationForm2("تایید کمک درمان");
                newform.ShowDialog(this);
            }
        }
    }
}
