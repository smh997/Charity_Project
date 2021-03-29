using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer;

namespace WindowsFormsApp6
{
    public partial class bankScoreForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public bankScoreForm()
        {
            InitializeComponent();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update budgetsCurrencies Set amount = @bs where typename = 'bankScore';", con);
            cmd.Parameters.AddWithValue("@bs", bankScoreNumericUpDown.Value);
            cmd.ExecuteNonQuery();
            FMessegeBox.FarsiMessegeBox.Show("امتیاز بانکی با موفقیت به روز شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }
    }
}
