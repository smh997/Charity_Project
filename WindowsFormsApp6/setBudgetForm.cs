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
    public partial class setBudgetForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string[] budgets = {"culture", "edu", "heal", "grocery", "bread", "marry", "others", "healFamily", "breadFamily" };
        public setBudgetForm()
        {
            InitializeComponent();
            enactmentTextbox.EnableContextMenu();
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت بودجه اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if(res != DialogResult.Yes)
            {
                return;
            }
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdsavehistory = new SqlCommand("BEGIN TRY begin tran t1; insert into budgetsCurrenciesHistory select @y, * from budgetsCurrencies; update budgetsCurrencies set amount = 0 where typename like '%Consume'; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
            SqlCommand cmdgetbsid = new SqlCommand("select max(id) from budgetsets;", con);
            string bsid = "1398";
            using(SqlDataReader reader = cmdgetbsid.ExecuteReader())
            {
                if (reader.Read())
                {
                    bsid = reader.GetString(0);
                }
            }
            cmdsavehistory.Parameters.AddWithValue("@y", bsid);
            cmdsavehistory.ExecuteNonQuery();
            string d = DateTime.Now.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
            SqlCommand cmd = new SqlCommand("insert into budgetsets (id, subdate, enactmentId) Values(@id, @sdate, @eId);", con);
            cmd.Parameters.AddWithValue("@id", "bs" + d);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.ExecuteNonQuery();
            NumericUpDown nu;
            foreach (var budget in budgets)
            {
                cmd = new SqlCommand("update budgetsCurrencies Set amount = @amount where typename = @tname;", con);
                nu = (NumericUpDown)this.Controls.Find(budget + "NumericUpDown", true)[0];
                cmd.Parameters.AddWithValue("@amount", nu.Value);
                cmd.Parameters.AddWithValue("@tname", budget + "Budget");
                cmd.ExecuteNonQuery();
            }
            FMessegeBox.FarsiMessegeBox.Show("بودجه با موفقیت تعیین شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
            con.Close();
        }

    }
}
