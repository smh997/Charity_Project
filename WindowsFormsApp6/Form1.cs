using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Diagnostics;
using System.Globalization;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";

        //Point myOriginalLocation;
        //bool positionLocked = false;
        private void Form1_Move(object sender, EventArgs e)
        {
            /*if (positionLocked)
            {
                this.Location = myOriginalLocation;
            }*/
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void addMemberbutton_Click(object sender, EventArgs e)
        {
            var newform = new editApplicantForm("افزودن مددجو");
            newform.ShowDialog(this);
        }

        private void deleteMemeberButton_Click(object sender, EventArgs e)
        {
            var newform = new deleteMemberForm();
            newform.ShowDialog(this);
        }

        private void editMemberButton_Click(object sender, EventArgs e)
        {
            var newform = new EditMemberForm();
            newform.ShowDialog(this);
        }

        private void independencyCheckButton_Click(object sender, EventArgs e)
        {
            var newform = new independencyForm();
            newform.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            List<string> li = new List<string>();
            string[] arr;
            SqlCommand cmdgetids = new SqlCommand("select member.id from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) );", con);
            using (SqlDataReader reader = cmdgetids.ExecuteReader())
            {
                while (reader.Read())
                    li.Add(reader.GetString(0));
                arr = li.ToArray();
            }
            SqlCommand cmd, cmdget;
            foreach (var i in arr)
            {
                cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, legalYearAbandoned, abandoneddate, reason, enactmentId)" +
                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @legalYearAbandoned, @abandoneddate, @description, @eId); " +
                                "insert into outmember (id, setupdate, description, status, folder_id, legalYearAbandoned) Values(@id, @abandoneddate, @description, @stat, @folder_id, @legalYearAbandoned); " +
                                "insert into independencyChecked (name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, description, checkinddate)" +
                                " Values (@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @description, @setupdate) " +
                                "delete from onindependency where id = @id; delete from member where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, homephone, cellphone, address, explain, rate, marriage, insurance, orphan, student, folder_id, identifierName, identifierPhone, enactmentId from member where id = @tmp", con);
                cmdget.Parameters.AddWithValue("@tmp", i);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                        cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                        cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                        cmd.Parameters.AddWithValue("@id", String.Format("{0}", reader["id"]));
                        cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                        cmd.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                        cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                        cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                        cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                        cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                        cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                        cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                        cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                        cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                        cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                        cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                        cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                        cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                        cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + "(خروج از پوشش به علت رسیدن به سن قانونی در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                        cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        cmd.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@rate", float.Parse(String.Format("{0}", reader["rate"])));
                        cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                        cmd.Parameters.AddWithValue("@legalYearAbandoned", "بله");
                        cmd.Parameters.AddWithValue("@description", "(خروج از پوشش به علت رسیدن به سن قانونی در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                    }
                }
                cmd.ExecuteNonQuery();
            }

            /*
            SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) )", con);
            int sup = 0;
            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            if (sup == 0)
            {
                independencyCheckButton.BackColor = Color.Green;
                
            }
            */
            con.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            analogClock1.Time = DateTime.Now;
            /*if (!positionLocked)
            {
                myOriginalLocation = this.Location;
                positionLocked = true;
            }*/
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            List<string> li = new List<string>();
            string[] arr;
            SqlCommand cmdgetids = new SqlCommand("select member.id from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) );", con);
            using (SqlDataReader reader = cmdgetids.ExecuteReader())
            {
                while (reader.Read())
                    li.Add(reader.GetString(0));
                arr = li.ToArray();
            }
            SqlCommand cmd, cmdget;
            foreach (var i in arr)
            {
                cmd = new SqlCommand("BEGIN TRY begin tran t1; insert into abandoned(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, legalYearAbandoned, abandoneddate, reason, enactmentId)" +
                                " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @legalYearAbandoned, @abandoneddate, @description, @eId); " +
                                "insert into outmember (id, setupdate, description, status, folder_id, legalYearAbandoned) Values(@id, @abandoneddate, @description, @stat, @folder_id, @legalYearAbandoned); " +
                                "insert into independencyChecked (name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, marriage, insurance, orphan, student, homephone, cellphone, address, explain, folder_id, identifierName, identifierPhone, description, checkinddate)" +
                                " Values (@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @seyed, @car, @marriage, @ins, @orphan, @student, @homephone, @cellphone, @address, @explain, @folder_id, @iName, @iPhone, @description, @setupdate) " +
                                "delete from onindependency where id = @id; delete from member where id = @id; commit tran t1; END TRY BEGIN CATCH ROLLBACK END CATCH", con);
                cmdget = new SqlCommand("select name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, seyed, car, homephone, cellphone, address, explain, rate, marriage, insurance, orphan, student, folder_id, identifierName, identifierPhone, enactmentId from member where id = @tmp", con);
                cmdget.Parameters.AddWithValue("@tmp", i);
                using (SqlDataReader reader = cmdget.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmd.Parameters.AddWithValue("@name", String.Format("{0}", reader["name"]));
                        cmd.Parameters.AddWithValue("@family", String.Format("{0}", reader["family"]));
                        cmd.Parameters.AddWithValue("@fatherName", String.Format("{0}", reader["fatherName"]));
                        cmd.Parameters.AddWithValue("@id", String.Format("{0}", reader["id"]));
                        cmd.Parameters.AddWithValue("@supporter_id", String.Format("{0}", reader["supporter_id"]));
                        cmd.Parameters.AddWithValue("@eId", String.Format("{0}", reader["enactmentId"]));
                        cmd.Parameters.AddWithValue("@sex", String.Format("{0}", reader["sex"]));
                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                        cmd.Parameters.AddWithValue("@health", String.Format("{0}", reader["health"]));
                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                        cmd.Parameters.AddWithValue("@seyed", String.Format("{0}", reader["seyed"]));
                        cmd.Parameters.AddWithValue("@car", String.Format("{0}", reader["car"]));
                        cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                        cmd.Parameters.AddWithValue("@orphan", String.Format("{0}", reader["orphan"]));
                        cmd.Parameters.AddWithValue("@student", String.Format("{0}", reader["student"]));
                        cmd.Parameters.AddWithValue("@homephone", String.Format("{0}", reader["homephone"]));
                        cmd.Parameters.AddWithValue("@cellphone", String.Format("{0}", reader["cellphone"]));
                        cmd.Parameters.AddWithValue("@address", String.Format("{0}", reader["address"]));
                        cmd.Parameters.AddWithValue("@marriage", String.Format("{0}", reader["marriage"]));
                        cmd.Parameters.AddWithValue("@folder_id", String.Format("{0}", reader["folder_id"]));
                        cmd.Parameters.AddWithValue("@explain", String.Format("{0}", reader["explain"]) + "(خروج از پوشش به علت رسیدن به سن قانونی در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@folderdate", Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date);
                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                        cmd.Parameters.AddWithValue("@checkdate", Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date);
                        cmd.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@abandoneddate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@rate", float.Parse(String.Format("{0}", reader["rate"])));
                        cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date);
                        cmd.Parameters.AddWithValue("@legalYearAbandoned", "بله");
                        cmd.Parameters.AddWithValue("@description", "(خروج از پوشش به علت رسیدن به سن قانونی در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                    }
                }
                cmd.ExecuteNonQuery();
            }

            /*
            SqlCommand cmdcheck = new SqlCommand("select count(*) as sup from onindependency , member where onindependency.id=member.id and ( year(birthdate) + 18 <  year(CURRENT_TIMESTAMP) or (year(birthdate) + 18 =  year(CURRENT_TIMESTAMP) and (month(birthdate)<month(CURRENT_TIMESTAMP) or (month(birthdate)=month(CURRENT_TIMESTAMP) and day(birthdate)<=day(CURRENT_TIMESTAMP) ) ) ) )", con);
            int sup = 0;
            using (SqlDataReader reader = cmdcheck.ExecuteReader())
            {
                if (reader.Read())
                {
                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            if (sup == 0)
            {
                independencyCheckButton.BackColor = Color.Green;
                
            }
            */
            con.Close();
        }

        private void editIndependencyButton_Click(object sender, EventArgs e)
        {
            var newform = new editIndependencyForm();
            newform.ShowDialog(this);
        }

        private void marryButton_Click(object sender, EventArgs e)
        {
            var newform = new setMarriageForm();
            newform.ShowDialog(this);
        }

        private void editMarryButton_Click(object sender, EventArgs e)
        {
            var newform = new editMarriageForm();
            newform.ShowDialog(this);
        }

        private void deleteSupportButton_Click(object sender, EventArgs e)
        {
            var newform = new kickForm("حذف پوشش");
            newform.ShowDialog(this);
        }

        private void editDeleteSupportButton_Click(object sender, EventArgs e)
        {
            var newform = new kickForm("ویرایش حذف پوشش");
            newform.ShowDialog(this);
        }

        private void editComeBackButton_Click(object sender, EventArgs e)
        {
            /*
            openFileDialog1.InitialDirectory = @"C:\Users\hashemi\Desktop\";
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileNames[0]);
            }
            */
            var newform = new comebackForm("ویرایش رجعت عضو");
            newform.ShowDialog(this);
        }

        private void comeBackButton_Click(object sender, EventArgs e)
        {
            var newform = new comebackForm("رجعت عضو");
            newform.ShowDialog(this);
        }

        private void increaseُStockButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            //
            //System.Diagnostics.Process.Start("C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\a.pdf");

            /*
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(var fm in openFileDialog1.FileNames)
                {
                    string fileName = System.IO.Path.GetFileName(fm);
                    string targetPath = @"C:\Users\hashemi\Desktop\Kheirie warehouse\" + "123";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(fm, destFile, false);
                }
            }
            */
            //System.IO.Directory.Move(@"C:\Users\hashemi\Desktop\Kheirie warehouse\members", @"C:\Users\hashemi\Desktop\Kheirie warehouse\new");

            /*
            string fileName = "چاپ اطلاعات ثبت نام.pdf";
            string sourcePath = @"C:\Users\hashemi\Desktop";
            string targetPath = @"C:\Users\hashemi\Desktop\Kheirie warehouse\newfolder";

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            //System.IO.Directory.CreateDirectory(targetPath);

            System.IO.File.Copy(sourceFile, destFile, false);
            //System.Diagnostics.Process.Start(@"C:\Users\hashemi\Desktop\Kheirie warehouse\newfolder\چاپ اطلاعات ثبت نام.pdf");*/
        }



        private void reasearchButton_Click(object sender, EventArgs e)
        {
            var newform = new kickForm("ثبت تحقیق");
            newform.ShowDialog(this);
        }

        private void editResearchButton_Click(object sender, EventArgs e)
        {
            var newform = new kickForm("حذف تحقیق");
            newform.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            analogClock1.Time = DateTime.Now;
        }

        private void editParametersButton_Click(object sender, EventArgs e)
        {
            var newform = new parameterForm();
            newform.ShowDialog(this);
        }

        private void addApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new addApplicantForm();
            newform.ShowDialog(this);
        }

        private void editApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new editApplicantForm();
            newform.ShowDialog(this);
        }

        private void addotherApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new otherApplicantForm();
            newform.ShowDialog(this);
        }

        private void editotherApplicantButton_Click(object sender, EventArgs e)
        {
            var newform = new editApplicantForm("ویرایش متقاضی");
            newform.ShowDialog(this);
        }

        private void reqButton_Click(object sender, EventArgs e)
        {
            var newform = new reqForm();
            newform.ShowDialog(this);
        }

        private void bankScoreButton_Click(object sender, EventArgs e)
        {
            var newform = new bankScoreForm();
            newform.ShowDialog(this);
        }

        private void checkReqButton_Click(object sender, EventArgs e)
        {
            var newform = new reqForm("بررسی تقاضا");
            newform.ShowDialog(this);
        }

        private void introduceButton_Click(object sender, EventArgs e)
        {
            var newform = new reqForm("ارائه معرفی‌نامه");
            newform.ShowDialog(this);
        }

        private void setEnactmentButton_Click(object sender, EventArgs e)
        {
            var newform = new setEnactmentForm();
            newform.ShowDialog(this);
        }

        private void editEnactmentButton_Click(object sender, EventArgs e)
        {
            var newform = new editReqForm("ویرایش مصوبه");
            newform.ShowDialog(this);
        }

        private void budgetButton_Click(object sender, EventArgs e)
        {
            var newform = new budgetForm();
            newform.ShowDialog(this);
        }

        private void enactmentedHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new globalHelpsForm("تعریف کمک جمعی با مصوبه");
            newform.ShowDialog(this);
        }

        private void suddenHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new globalHelpsForm("تعریف کمک جمعی اتفاقی");
            newform.ShowDialog(this);
        }

        private void giveHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new helpPresentationForm("", "ارائه");
            newform.ShowDialog(this);
        }

        private void ackButton_Click(object sender, EventArgs e)
        {
            var newform = new helpPresentationForm("تایید کمک");
            newform.ShowDialog(this);
        }

        private void indivHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new specialHelpsForm();
            newform.ShowDialog(this);
        }

        private void otherHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new otherHelpForm();
            newform.ShowDialog(this);
        }

        private void setHelpRecieveButton_Click(object sender, EventArgs e)
        {
            var newform = new recHelpsForm();
            newform.ShowDialog(this);
        }

        private void bankAccountCreateButton_Click(object sender, EventArgs e)
        {
            var newform = new bankAccountCreateForm();
            newform.ShowDialog(this);
        }

        private void bankAccountEditButton_Click(object sender, EventArgs e)
        {
            var newform = new bankAccountEditForm();
            newform.ShowDialog(this);
        }

        private void bankAccounttransferButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            int cnt = 0;
            SqlCommand cmdexist = new SqlCommand("select count(*) from bankAccount;", con);
            using(SqlDataReader reader = cmdexist.ExecuteReader())
            {
                if (reader.Read())
                {
                    cnt = reader.GetInt32(0);
                }
            }
            con.Close();
            if(cnt < 2)
            {
                FMessegeBox.FarsiMessegeBox.Show("تنها یک حساب تعریف شده موجود است و انتقال معنایی ندارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }
            var newform = new bankAccountTransferForm();
            newform.ShowDialog(this);
        }

        private void bankAccountDeleteButton_Click(object sender, EventArgs e)
        {
            var newform = new bankAccountDelForm();
            newform.ShowDialog(this);
        }

        private void editTransferButton_Click(object sender, EventArgs e)
        {
            var newform = new bankAccountTransferEditForm();
            newform.ShowDialog(this);
        }

        private void addHelperButton_Click(object sender, EventArgs e)
        {
            var newform = new addhelperForm();
            newform.ShowDialog(this);
        }

        private void editHelperButton_Click(object sender, EventArgs e)
        {
            var newform = new editHelperForm();
            newform.ShowDialog(this);
        }

        private void editHelpRecieveButton_Click(object sender, EventArgs e)
        {
            var newform = new recHelpsEditForm();
            newform.ShowDialog(this);
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            var newform = new buyHelpsForm();
            newform.ShowDialog(this);
        }

        private void editBuyHelpsButton_Click(object sender, EventArgs e)
        {
            var newform = new editBuyHelpsForm();
            newform.ShowDialog(this);
        }

        private void sendLetterButton_Click(object sender, EventArgs e)
        {
            var newform = new sendingLetterForm();
            newform.ShowDialog(this);
        }

        private void receiveLetterButton_Click(object sender, EventArgs e)
        {
            var newform = new receivedLetterForm();
            newform.ShowDialog(this);
            
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            /*for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();*/
        }

        private void observeButton_Click(object sender, EventArgs e)
        {
            var newform = new observeForm();
            newform.ShowDialog(this);
        }

        private void reportButton_Click_1(object sender, EventArgs e)
        {
            var newform = new reportForm();
            newform.ShowDialog(this);
        }
    }
}
