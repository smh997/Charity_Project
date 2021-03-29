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
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class editBudgetForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string[] budgets = { "culture", "edu", "heal", "grocery", "bread", "marry", "others", "healFamily", "breadFamily"};
        Dictionary<string, decimal> pream;
        Dictionary<string, decimal> bconsume;
        public editBudgetForm()
        {
            InitializeComponent();
            enactmentTextbox.EnableContextMenu();
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;
            pream = new Dictionary<string, decimal>();
            bconsume = new Dictionary<string, decimal>();
        }

        private void editBudgetForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select typename, amount from budgetsCurrencies;", con);
            NumericUpDown nu;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(0).Contains("Budget"))
                    {
                        string budget = reader.GetString(0).Substring(0, reader.GetString(0).Length - 6);
                        //FMessegeBox.FarsiMessegeBox.Show(budget);
                        nu = (NumericUpDown)this.Controls.Find(budget + "NumericUpDown", true)[0];
                        //FMessegeBox.FarsiMessegeBox.Show(nu.ToString());
                        nu.Value = reader.GetDecimal(1);
                        pream[budget] = nu.Value;
                    }
                }
            }
            cmd = new SqlCommand("select typename, amount from budgetsCurrencies where typename like '%Consume';", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bconsume[reader.GetString(0).Substring(0, reader.GetString(0).Length - 7)] = reader.GetDecimal(1);
                }
            }
            calc_breadconsume();
            calc_healConsume();
            con.Close();
        }
        public void calc_healConsume()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            List<string> members = new List<string>();
            SqlCommand cmdgetmembers = new SqlCommand("select id from member;", con);
            using(SqlDataReader reader = cmdgetmembers.ExecuteReader())
            {
                while (reader.Read())
                {
                    members.Add(reader.GetString(0));
                }
            }
            bconsume["healFamily"] = 0;
            decimal consum = 0;
            foreach (string member in members)
            {
                SqlCommand cmd = new SqlCommand("select fee from HealHelps, HealHelpReq where HealHelps.reqId = HealHelpReq.id and mId in (select id from member where folder_id = (select folder_id from member where id = @mId)) and HealHelps.id in (select id from HealHelps where confirmdate >= (select Max(subdate) from budgetsets));", con);
                cmd.Parameters.AddWithValue("@mId", member);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consum += reader.GetDecimal(0);
                    }
                }
                bconsume["healFamily"] = Math.Max(consum, bconsume["healFamily"]);
            }
            con.Close();
        }
        public void calc_breadconsume()
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            List<string> members = new List<string>();
            SqlCommand cmdgetmembers = new SqlCommand("select distinct(folder_id) from member;", con);
            using (SqlDataReader reader = cmdgetmembers.ExecuteReader())
            {
                while (reader.Read())
                {
                    members.Add(reader.GetString(0));
                }
            }
            bconsume["breadFamily"] = 0;
            decimal consum = 0;
            foreach (string member in members)
            {
                SqlCommand cmd = new SqlCommand("select fee from receivedTableHelp, GlobalHelps where folder_id = @fId and enddate is not Null and DATEDIFF(day, enddate, GETDATE()) <= 30;", con);
                cmd.Parameters.AddWithValue("@fId", member); ;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consum += reader.GetDecimal(0);
                    }
                }
                bconsume["breadFamily"] = Math.Max(consum, bconsume["breadFamily"]);
            }
            con.Close();

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
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            NumericUpDown nu;
            foreach (var budget in budgets)
            {
                nu = (NumericUpDown)this.Controls.Find(budget + "NumericUpDown", true)[0];
                if(pream[budget] > nu.Value && nu.Value < bconsume[budget])
                {
                    switch (budget)
                    {
                        case "culture":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه فرهنگی اداری تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "edu":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه آموزشی تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "heal":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه درمان تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "grocery":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه خواربار تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "bread":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه نان تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "marry":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه ازدواج تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "others":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه متفرقه تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "healFamily":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه درمانی خانواری تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                        case "breadFamily":
                            FMessegeBox.FarsiMessegeBox.Show("مصرف بودجه نان خانواری تا کنون از بودجه نعیین شده بیشتر است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                            break;
                    }
                    return;
                }

            }
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ویرایش بودجه اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                return;
            }
            string d = DateTime.Now.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
            SqlCommand cmd = new SqlCommand("insert into budgetedits (id, subdate, enactmentId, description) Values(@id, @sdate, @eId, @des);", con);
            cmd.Parameters.AddWithValue("@id", "be" + d);
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
            cmd.Parameters.AddWithValue("@des", explainTextBox.Text);
            cmd.ExecuteNonQuery();
            foreach (var budget in budgets)
            {
                cmd = new SqlCommand("update budgetsCurrencies Set amount = @amount where typename = @tname;", con);
                nu = (NumericUpDown)this.Controls.Find(budget + "NumericUpDown", true)[0];
                cmd.Parameters.AddWithValue("@amount", nu.Value);
                cmd.Parameters.AddWithValue("@tname", budget + "Budget");
                cmd.ExecuteNonQuery();
            }
            FMessegeBox.FarsiMessegeBox.Show("بودجه با موفقیت ویرایش شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            con.Close();
            this.Close();
        }

        private void explainTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (explainTextBox.Text.Length != 0 && myreg.IsMatch(explainTextBox.Text.Substring(explainTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                explainTextBox.Text = explainTextBox.Text.Substring(0, explainTextBox.Text.Length - 1);
            }
        }
    }
}
