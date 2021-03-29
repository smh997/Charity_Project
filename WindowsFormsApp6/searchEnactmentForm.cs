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
    public partial class searchEnactmentForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        public searchEnactmentForm()
        {
            InitializeComponent();
        }

        private void searchEnactmentForm_Load(object sender, EventArgs e)
        {
            searchButton.Enabled = visitButton.Enabled = chooseButton.Enabled = false;
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;

            cmd = new SqlCommand("select id as 'شماره مصوبه', docname as 'نام قایل مصوبه', docpath from enactment;", con1);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            membersView.Columns[2].Visible  = false;
            con1.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();
            SqlCommand cmd; SqlDataAdapter da; DataTable dt;
            cmd = new SqlCommand("select id as 'شماره مصوبه', docname as 'نام قایل مصوبه' from enactment where id like '%" + enactmentTxtBox.Text + "%'", con1);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            membersView.DataSource = dt;
            con1.Close();
        }

        private void enactmentTxtBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !string.IsNullOrEmpty(enactmentTxtBox.Text) && !string.IsNullOrWhiteSpace(enactmentTxtBox.Text);
        }

        private void membersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                membersView.ClearSelection();
            }
        }

        private void membersView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            membersView.ClearSelection();
        }

        private void membersView_SelectionChanged(object sender, EventArgs e)
        {
            visitButton.Enabled = chooseButton.Enabled = (membersView.SelectedCells.Count != 0);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString());
            this.Text = "choose" + membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex].Value.ToString();
            this.Close();
        }

        private void visitButton_Click(object sender, EventArgs e)
        {
            string dpath = membersView.Rows[membersView.SelectedCells[0].RowIndex].Cells[membersView.SelectedCells[0].ColumnIndex + 2].Value.ToString();
            System.Diagnostics.Process.Start(dpath);
        }
    }
}
