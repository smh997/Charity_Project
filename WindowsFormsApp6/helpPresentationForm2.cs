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
    public partial class helpPresentationForm2 : Form
    {
        public helpPresentationForm2(string p)
        {
            InitializeComponent();
            this.Text = p;
        }

        private void helpPresentationForm2_Load(object sender, EventArgs e)
        {
            /*if(this.Text == "ارائه کمک جمعی" || this.Text == "تایید کمک جمعی" || this.Text == "ارائه کمک متفرقه گروهی" || this.Text == "تایید کمک متفرقه گروهی")
            {
                this.BackColor = Color.YellowGreen;
            }*/
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            var newform = new searchHelpForm(this.Text);
            newform.ShowDialog(this);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(this.Text == "ارائه کمک جمعی")
            {
                var newform = new searchHelpForm("ویرایش فایل‌های ارائه کمک جمعی");
                newform.ShowDialog(this);
            }
            else if(this.Text == "تایید کمک جمعی")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک جمعی");
                newform.ShowDialog(this);
            }
            else if(this.Text == "ارائه کمک تحصیلی")
            {
                var newform = new searchHelpForm("ویرایش فایل‌های ارائه کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک تحصیلی")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک ازدواج")
            {
                var newform = new searchHelpForm("ویرایش‌ ارائه کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک ازدواج")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک درمان")
            {
                var newform = new searchHelpForm("ویرایش‌ ارائه کمک درمان");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک درمان")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک درمان");
                newform.ShowDialog(this);
            }
            if (this.Text == "ارائه کمک متفرقه گروهی")
            {
                var newform = new searchHelpForm("ویرایش فایل‌های ارائه کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک متفرقه گروهی")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ویرایش‌ ارائه کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ویرایش تایید کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
        }
    }
}
