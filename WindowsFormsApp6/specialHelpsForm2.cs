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
    public partial class specialHelpsForm2 : Form
    {
        public specialHelpsForm2(string p)
        {
            InitializeComponent();
            this.Text = p;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "درخواست کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ثبت درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("بررسی درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "درخواست کمک درمان")
            {
                var newform = new searchHelpForm("ثبت درخواست کمک درمان");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                var newform = new searchHelpForm("بررسی درخواست کمک درمان");
                newform.ShowDialog(this);
            }
            else if(this.Text == "درخواست کمک ازدواج")
            {
                var newform = new searchHelpForm("ثبت درخواست کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک ازدواج")
            {
                var newform = new searchHelpForm("بررسی درخواست کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if(this.Text == "تعریف کمک تحصیلی")
            {
                var newform = new studyHelpForm();
                newform.ShowDialog(this);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "تعریف کمک تحصیلی")
            {
                var newform = new searchHelpForm("ویرایش کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if(this.Text == "درخواست کمک ازدواج")
            {
                var newform = new searchHelpForm("ویرایش درخواست کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if(this.Text == "بررسی درخواست کمک ازدواج")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک ازدواج تاییدشده");
                newform.ShowDialog(this);
            }
            else if (this.Text == "درخواست کمک درمان")
            {
                var newform = new searchHelpForm("ویرایش درخواست کمک درمان");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک درمان تاییدشده");
                newform.ShowDialog(this);
            }
            else if (this.Text == "درخواست کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ویرایش درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک متفرقه فردی تاییدشده");
                newform.ShowDialog(this);
            }
        }

        private void specialHelpsForm2_Load(object sender, EventArgs e)
        {
            if(this.Text == "بررسی درخواست کمک ازدواج")
            {
                this.BackColor = Color.MediumPurple;
                setButton.Location = new Point(setButton.Location.X, setButton.Location.Y - 24);
                editButton.Location = new Point(editButton.Location.X, editButton.Location.Y - 25);
                editButton.Text = "ویرایش تایید";
                editButton2.Visible = true;
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                this.BackColor = Color.Gold;
                setButton.Location = new Point(setButton.Location.X, setButton.Location.Y - 24);
                editButton.Location = new Point(editButton.Location.X, editButton.Location.Y - 25);
                editButton.Text = "ویرایش تایید";
                editButton2.Visible = true;
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                this.BackColor = Color.LightCoral;
                setButton.Location = new Point(setButton.Location.X, setButton.Location.Y - 24);
                editButton.Location = new Point(editButton.Location.X, editButton.Location.Y - 25);
                editButton.Text = "ویرایش تایید";
                editButton2.Visible = true;
            }
        }

        private void editButton2_Click(object sender, EventArgs e)
        {
            if (this.Text == "بررسی درخواست کمک ازدواج")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک ازدواج ردشده");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک درمان ردشده");
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                var newform = new searchHelpForm("ویرایش بررسی درخواست کمک متفرقه فردی ردشده");
                newform.ShowDialog(this);
            }
        }
    }
}
