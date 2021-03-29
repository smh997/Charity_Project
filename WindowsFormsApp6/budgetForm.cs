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
    public partial class budgetForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public budgetForm()
        {
            InitializeComponent();
        }

        private void budgetForm_Load(object sender, EventArgs e)
        {
            string now = DateTime.Now.Date.ToPersian();
            if (now.Substring(5, 2) == "12")
            {
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                string lastd = "";
                SqlCommand cmdget = new SqlCommand("select max(subdate) as da from budgetsets;", con);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (String.Format("{0}", reader["da"]) == "")
                        {

                        }
                        else
                        {
                            lastd = Convert.ToDateTime(String.Format("{0}", reader["da"])).ToPersian();
                        }
                    }
                }
                if (lastd != "" && lastd.Substring(0, 4) == now.Substring(0, 4))
                {
                    setBudgetButton.Enabled = false;
                }
                con.Close();
            }
            else
            {
                setBudgetButton.Enabled = false;
            }
        }

        private void setBudgetButton_Click(object sender, EventArgs e)
        {
            var newform = new setBudgetForm();
            newform.ShowDialog(this);
        }

        private void editBudgetButton_Click(object sender, EventArgs e)
        {
            var newform = new editBudgetForm();
            newform.ShowDialog(this);
        }
    }
}
