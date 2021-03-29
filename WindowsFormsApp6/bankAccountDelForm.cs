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
    public partial class bankAccountDelForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        List<KeyValuePair<string, string>> li;
        public bankAccountDelForm()
        {
            InitializeComponent();
            li = new List<KeyValuePair<string, string>>();
        }

        private void bankAccountDelForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdget = new SqlCommand("select id, name from bankAccount;", con);
            using (SqlDataReader reader = cmdget.ExecuteReader())
            {
                while (reader.Read())
                {
                    li.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                    bankAccountNameComboBox.Items.Add(reader.GetString(1));
                }
            }
            con.Close();
            bankAccountNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bankAccountNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            bankAccountNameComboBox.SelectedIndex = 0;
        }

        private void bankAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bankAccountNumberTextBox.Text = ExtensionFunction.PersianToEnglish(li[bankAccountNameComboBox.SelectedIndex].Key);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            decimal stock = 0;
            SqlCommand cmd = new SqlCommand("select stock from bankAccount where id = @id;", con);
            cmd.Parameters.AddWithValue("@id", li[bankAccountNameComboBox.SelectedIndex].Key);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    stock = reader.GetDecimal(0);
                }
            }
            if(stock != 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("حساب دارای موجودی است و قابل حذف نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            var newform = new bankAccountDelForm2(li[bankAccountNameComboBox.SelectedIndex].Key);
            newform.ShowDialog(this);
            this.Close();
        }
    }
}
