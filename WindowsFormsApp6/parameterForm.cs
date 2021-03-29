using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Data.SqlClient;
namespace WindowsFormsApp6
{
    public partial class parameterForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string[] parameters = {"", "outOfService", "sick", "interdicted", "addicted", "jobless", "daily", "specialSick", "student", "orphan", "familyMember", "tenant1", "tenant2", "annual1", "annual2", "otherSup", "help", "day"};
        public parameterForm()
        {
            InitializeComponent();
        }

        private void updateFamilies()
        {
            List<string> supsList = new List<string>(); string[] sups;
            string job="", health = "", house = "", annual = "", otherSup = ""; int rate, totalrate;
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmdgetssups, cmdgetsupinfo, cmdgetchildren, cmduprate;
            con.Open();

            cmdgetssups = new SqlCommand("select id from member where id = supporter_id", con);
            using(SqlDataReader reader = cmdgetssups.ExecuteReader())
            {
                while (reader.Read())
                {
                    supsList.Add(reader.GetString(0));
                }
                sups = supsList.ToArray();
            }
            foreach (string sup in sups)
            {
                rate = 0;
                cmdgetsupinfo = new SqlCommand("select job, health, house, annual, otherSup from member where id = @id", con);
                cmdgetsupinfo.Parameters.AddWithValue("@id", sup);
                using (SqlDataReader reader = cmdgetsupinfo.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        job = String.Format("{0}", reader["job"]);
                        health = String.Format("{0}", reader["health"]);
                        annual = String.Format("{0}", reader["annual"]);
                        house = String.Format("{0}", reader["house"]);
                        otherSup = String.Format("{0}", reader["otherSup"]);
                    }
                }
                // calculate supporter rate
                if (job == "از کارافتاده")
                {
                    rate += (int)outOfServiceNumericUpDown.Value;
                }
                else if (health == "بیمار")
                {
                    rate += (int)sickNumericUpDown.Value;
                }
                else if (health == "محجور")
                {
                    rate += (int)interdictedNumericUpDown.Value;
                }
                else if (health == "معتاد")
                {
                    rate += (int)addictedNumericUpDown.Value;
                }
                else if (job == "بیکار")
                {
                    rate += (int)joblessNumericUpDown.Value;
                }
                else if (job == "کارگر روزمزد")
                {
                    rate += (int)dailyNumericUpDown.Value;
                }
                // calculate family rate
                switch (house)
                {
                    case "مستأجر سطح یک":
                        rate += (int)tenant1NumericUpDown.Value;
                        break;
                    case "مستأجر سطح دو":
                        rate += (int)tenant2NumericUpDown.Value;
                        break;
                    default:
                        break;
                }
                switch (annual)
                {
                    case "سطح یک":
                        rate += (int)annual1NumericUpDown.Value;
                        break;
                    case "سطح دو":
                        rate += (int)annual2NumericUpDown.Value;
                        break;
                    default:
                        break;
                }
                if (otherSup != "خیر")
                {
                    rate += (int)otherSupNumericUpDown.Value;
                }
                // get family members
                List<Tuple<string, string, string, string>> childList = new List<Tuple<string, string, string, string>>(); Tuple<string, string, string, string>[] children;
                cmdgetchildren = new SqlCommand("select id, health, student, orphan from member where supporter_id = @id", con);
                cmdgetchildren.Parameters.AddWithValue("@id", sup);
                using (SqlDataReader reader = cmdgetchildren.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        childList.Add(new Tuple<string, string, string, string>(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                    }
                    children = childList.ToArray();
                }
                // calculate each member
                foreach (Tuple<string, string, string, string> child in children)
                {
                    rate += (int)familyMemberNumericUpDown.Value;
                    if(child.Item2 == "بیماری خاص")
                    {
                        rate += (int)specialSickNumericUpDown.Value;
                    }
                    if(child.Item3 == "بله")
                    {
                        rate += (int)studentNumericUpDown.Value;
                    }
                    if(child.Item4 == "بله")
                    {
                        rate += (int)orphanNumericUpDown.Value;
                    }
                }
                
                // update rate of family
                foreach (Tuple<string, string, string, string> child in children)
                {
                    cmduprate = new SqlCommand("update member Set rate = @rate where id = @id", con);
                    cmduprate.Parameters.AddWithValue("@id", child.Item1);
                    cmduprate.Parameters.AddWithValue("@rate", rate);
                    cmduprate.ExecuteNonQuery();
                }
            }
            con.Close();
        }

        private void parameterForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdgetparams = new SqlCommand("select name, point from parameters;", con);
            using(SqlDataReader reader = cmdgetparams.ExecuteReader())
            {
                while (reader.Read())
                {
                    TextBox b = (TextBox)this.Controls.Find(reader.GetString(0) + "Textbox", true)[0];
                    NumericUpDown nu = (NumericUpDown)this.Controls.Find(reader.GetString(0) + "NumericUpDown", true)[0];
                    nu.Value = reader.GetInt32(1);
                    b.Text = nu.Value.ToString();
                }
            }
            con.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {

            // Display form modelessly
            var waitform = new waitForm();
            waitform.StartPosition = FormStartPosition.Manual;
            waitform.Show(this);
            
            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmdupparams; NumericUpDown nu;
            con.Open();
            for(int i=1; i<=17; i++)
            {
                cmdupparams = new SqlCommand("update parameters Set point = @p where name = @name;", con);
                cmdupparams.Parameters.AddWithValue("@name", parameters[i]);
                nu = (NumericUpDown)this.Controls.Find(parameters[i] + "NumericUpDown", true)[0];
                cmdupparams.Parameters.AddWithValue("@p", nu.Value);
                cmdupparams.ExecuteNonQuery();
            }
            con.Close();
            //update all family rates!
            updateFamilies();

            waitform.Close();
            FMessegeBox.FarsiMessegeBox.Show("فاکتورهای امتیازی و امتیازات خانوارها با موفقیت به روز گردید!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
        }

        private void visitButton_Click(object sender, EventArgs e)
        {
            var newform = new parameterVisitFamiliesForm();
            newform.ShowDialog(this);
        }
    }
}
