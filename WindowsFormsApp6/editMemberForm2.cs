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
using System.Globalization;

namespace WindowsFormsApp6
{
    public partial class editMemberForm2 : Form
    {
        private string id;
        private string sup_id;
        private string fol;
        private string birth, profile;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string[] dirList = { "auth", "health", "house", "marry", "study", "orphan", "other", "research", "deletion", "CB", "helped" };
        Dictionary<string, int> parameters = new Dictionary<string, int>(){
            { "outOfService", 0 }, { "sick", 0 }, { "interdicted", 0 }, { "addicted", 0 }, { "jobless", 0 },
            { "daily", 0}, { "specialSick", 0 }, { "student", 0 }, { "orphan", 0 }, { "familyMember", 0 },
            { "tenant1", 0 }, { "tenant2", 0 }, { "annual1", 0 }, { "annual2", 0 }, { "otherSup", 0 }, { "help", 0 }, { "day", 0 } };
        public editMemberForm2(string id)
        {
            InitializeComponent();
            this.id = id;
            this.profile = "";
        }

        private void editMemberForm2_Load(object sender, EventArgs e)
        {
            editButton.Enabled = false;
            enactmentTextbox.SelectionAlignment = HorizontalAlignment.Center;

            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            workComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            healthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            houseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            marryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            insComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            healthAddFileButton.Visible = healthLabel.Visible = false;
            houseAddFileButton.Visible = houseLabel.Visible = false;
            orphanAddFileButton.Visible = orphanLabel.Visible = false;
            studentAddFileButton.Visible = studentLabel.Visible = false;
            otherInsTextbox.Visible = otherSupTextBox.Visible = false;
            
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from member where id = @id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(String.Format("{0}", reader["enactmentId"]));
                    idTextbox.Text = String.Format("{0}", reader["id"]);
                    nameTextbox.Text = String.Format("{0}", reader["name"]);
                    familyTextbox.Text = String.Format("{0}", reader["family"]);
                    fathernameTextbox.Text = String.Format("{0}", reader["fatherName"]);
                    supporterTextbox.Text = String.Format("{0}", reader["supporter_id"]);sup_id = supporterTextbox.Text;
                    homephoneTextBox.Text = String.Format("{0}", reader["homephone"]);
                    cellphoneTextBox.Text = String.Format("{0}", reader["cellphone"]);
                    addressTextBox.Text = String.Format("{0}", reader["address"]);
                    explainTextBox.Text = String.Format("{0}", reader["explain"]);
                    identifierNameTextBox.Text = String.Format("{0}", reader["identifierName"]);
                    identifierPhoneTextBox.Text = String.Format("{0}", reader["identifierPhone"]);
                    birthdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date;this.birth = String.Format("{0}", reader["birthdate"]);
                    folderdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date;
                    checkdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date;
                    this. fol = String.Format("{0}", reader["folder_id"]);
                    //sex:
                    String sex = String.Format("{0}", reader["sex"]);
                    sexComboBox.Text = sex;
                    //job
                    String job = String.Format("{0}", reader["job"]);
                    workComboBox.Text = job;
                    //house
                    String house = String.Format("{0}", reader["house"]);
                    houseComboBox.Text = house;
                    if (house == "مستأجر سطح یک" || house == "مستأجر سطح دو")
                    {
                        houseAddFileButton.Visible = houseLabel.Visible = true;
                        houseLabel.BackColor = Color.YellowGreen;
                    }
                    //health
                    String health = String.Format("{0}", reader["health"]);
                    healthComboBox.Text = health;
                    if (health == "بیمار خاص")
                    {
                        healthAddFileButton.Visible = healthLabel.Visible = true;
                        healthLabel.BackColor = Color.YellowGreen;
                    }
                    //annual
                    String annual = String.Format("{0}", reader["annual"]);
                    if(annual == "سطح یک")
                    {
                        annualCheckBox1.Checked = true;
                    }
                    if (annual == "سطح دو")
                    {
                        annualCheckBox2.Checked = true;
                    }
                    //otherSup
                    String otherSup = String.Format("{0}", reader["otherSup"]);
                    if (otherSup != "خیر")
                    {
                        otherSupTextBox.Visible = otherSupCheckBox.Checked = true;
                        otherSupTextBox.Text = otherSup;
                    }
                    //seyed
                    String seyed = String.Format("{0}", reader["seyed"]);
                    if (seyed == "بله")
                    {
                        seyedCheckBox.Checked = true;
                    }
                    //car
                    String car = String.Format("{0}", reader["car"]);
                    if (car == "دارد")
                    {
                        carCheckBox.Checked = true;
                    }
                    //marriage
                    String marriage = String.Format("{0}", reader["marriage"]);
                    marryComboBox.Text = marriage;
                    //insurance
                    String ins = String.Format("{0}", reader["insurance"]);
                    insComboBox.Text = ins;
                    if (ins != "خدمات درمانی" && ins != "تأمین اجتماعی" && ins != "فاقد بیمه" && ins != "سلامت")
                    {
                        otherInsTextbox.Visible = true;
                        otherInsTextbox.Text = ins;
                        insComboBox.Text = "سایر";
                    }
                    //orphan
                    String orphan = String.Format("{0}", reader["orphan"]);
                    if (orphan == "بله")
                    {
                        orphanAddFileButton.Visible = orphanLabel.Visible = orphanCheckBox.Checked = true;
                        orphanLabel.BackColor = Color.YellowGreen;
                    }
                    //student
                    String student = String.Format("{0}", reader["student"]);
                    if (student == "بله")
                    {
                        studentAddFileButton.Visible = studentLabel.Visible = studentCheckBox.Checked = true;
                        studentLabel.BackColor = Color.YellowGreen;
                    }
                }
            }
            if (this.sup_id == this.id)
            {
                identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = otherSupTextBox.Enabled = houseComboBox.Enabled = workComboBox.Enabled = insComboBox.Enabled = true;
            }
            SqlCommand cmdgetprofile = new SqlCommand("select docpath from doc where id = @id and doctype = 'profile';", con);
            cmdgetprofile.Parameters.AddWithValue("@id", this.id);
            using(SqlDataReader reader = cmdgetprofile.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.profile = String.Format("{0}", reader["docpath"]);
                }
            }
            if (this.profile == "")
                profilePictureBox.Image = WindowsFormsApp6.Properties.Resources.profile;
            else
                profilePictureBox.ImageLocation = this.profile;
            con.Close();
        }
        private void updateFamily()
        {
            List<string> supsList = new List<string>();
            string job = "", health = "", house = "", annual = "", otherSup = ""; int rate;
            SqlConnection con = new SqlConnection(this.connection);
            SqlCommand cmdgetparams, cmdgetsupinfo, cmdgetchildren, cmduprate;
            con.Open();

            cmdgetparams = new SqlCommand("select name, point from parameters", con);
            using (SqlDataReader reader = cmdgetparams.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.parameters[reader.GetString(0)] = reader.GetInt32(1);
                }
            }

            string sup = supporterTextbox.Text;
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
                rate += this.parameters["outOfService"];
            }
            else if (health == "بیمار")
            {
                rate += this.parameters["sick"];
            }
            else if (health == "محجور")
            {
                rate += this.parameters["interdicted"];
            }
            else if (health == "معتاد")
            {
                rate += this.parameters["addicted"];
            }
            else if (job == "بیکار")
            {
                rate += this.parameters["jobless"];
            }
            else if (job == "کارگر روزمزد")
            {
                rate += this.parameters["daily"];
            }
            // calculate family rate
            switch (house)
            {
                case "مستأجر سطح یک":
                    rate += this.parameters["tenant1"];
                    break;
                case "مستأجر سطح دو":
                    rate += this.parameters["tenant2"];
                    break;
                default:
                    break;
            }
            switch (annual)
            {
                case "سطح یک":
                    rate += this.parameters["annual1"];
                    break;
                case "سطح دو":
                    rate += this.parameters["annual2"];
                    break;
                default:
                    break;
            }
            if (otherSup != "خیر")
            {
                rate += this.parameters["otherSup"];
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
                rate += this.parameters["familyMember"];
                if (child.Item2 == "بیماری خاص")
                {
                    rate += this.parameters["specialSick"];
                }
                if (child.Item3 == "بله")
                {
                    rate += this.parameters["student"];
                }
                if (child.Item4 == "بله")
                {
                    rate += this.parameters["orphan"];
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

            con.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();

            if (nameTextbox.TextLength == 0 || familyTextbox.TextLength == 0 || fathernameTextbox.TextLength == 0 || idTextbox.TextLength == 0 || supporterTextbox.TextLength == 0 || homephoneTextBox.TextLength == 0 || cellphoneTextBox.TextLength == 0 || addressTextBox.TextLength == 0 ||
                    (sexComboBox.Text.Length == 0) || (workComboBox.Enabled && workComboBox.Text.Length == 0) || (healthComboBox.Text.Length == 0) || (houseComboBox.Enabled && houseComboBox.Text.Length == 0) || (otherSupCheckBox.Checked && otherSupTextBox.Text.Length == 0) || (marryComboBox.Text.Length == 0) || (insComboBox.Enabled && (insComboBox.Text.Length == 0 || (insComboBox.Text == "سایر" && otherInsTextbox.TextLength == 0))) || (identifierNameTextBox.Enabled && identifierNameTextBox.Text.Length == 0) || (identifierPhoneTextBox.Enabled && identifierPhoneTextBox.Text.Length == 0))
            {
                if (nameTextbox.TextLength == 0)
                    nameTextbox.BackColor = Color.Tomato;
                if (familyTextbox.TextLength == 0)
                    familyTextbox.BackColor = Color.Tomato;
                if (fathernameTextbox.TextLength == 0)
                    fathernameTextbox.BackColor = Color.Tomato;
                if (idTextbox.TextLength == 0)
                    idTextbox.BackColor = Color.Tomato;
                if (supporterTextbox.TextLength == 0)
                    supporterTextbox.BackColor = Color.Tomato;
                if (homephoneTextBox.TextLength == 0)
                    homephoneTextBox.BackColor = Color.Tomato;
                if (cellphoneTextBox.TextLength == 0)
                    cellphoneTextBox.BackColor = Color.Tomato;
                if (addressTextBox.TextLength == 0)
                    addressTextBox.BackColor = Color.Tomato;
                if (sexComboBox.Text.Length == 0)
                    sexComboBox.BackColor = Color.Tomato;
                if (workComboBox.Enabled && workComboBox.Text.Length == 0)
                    workComboBox.BackColor = Color.Tomato;
                if (healthComboBox.Text.Length == 0)
                    healthComboBox.BackColor = Color.Tomato;
                if (houseComboBox.Enabled && houseComboBox.Text.Length == 0)
                    houseComboBox.BackColor = Color.Tomato;
                if (otherSupCheckBox.Checked && otherSupTextBox.Text.Length == 0)
                    otherSupTextBox.BackColor = Color.Tomato;
                if (marryComboBox.Text.Length == 0)
                    marryComboBox.BackColor = Color.Tomato;
                if (insComboBox.Enabled && insComboBox.Text.Length == 0)
                    insComboBox.BackColor = Color.Tomato;
                if (insComboBox.Text == "سایر" && otherInsTextbox.TextLength == 0)
                    otherInsTextbox.BackColor = Color.Tomato;
                if (identifierNameTextBox.Enabled && identifierNameTextBox.TextLength == 0)
                    identifierNameTextBox.BackColor = Color.Tomato;
                if (identifierPhoneTextBox.Enabled && identifierPhoneTextBox.TextLength == 0)
                    identifierPhoneTextBox.BackColor = Color.Tomato;
                FMessegeBox.FarsiMessegeBox.Show("مشخصات وارد شده ناقص است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else if (authLabel.BackColor == Color.Red || marryLabel.BackColor == Color.Red || (orphanLabel.Visible && orphanLabel.BackColor == Color.Red) || (studentLabel.Visible && studentLabel.BackColor == Color.Red) || (healthLabel.Visible && healthLabel.BackColor == Color.Red) || (houseLabel.Visible && houseLabel.BackColor == Color.Red))
            {
                FMessegeBox.FarsiMessegeBox.Show("مدارک ناقص است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                int check = 0;
                SqlCommand cmdcheck = new SqlCommand("select count(*) as checked from member where id = @id", con1);
                cmdcheck.Parameters.AddWithValue("@id", idTextbox.Text);
                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        check = int.Parse(String.Format("{0}", reader["checked"]));
                    }
                }
                if (check == 1 && this.id != idTextbox.Text)
                {
                    idTextbox.BackColor = Color.Tomato;
                    FMessegeBox.FarsiMessegeBox.Show("عضوی با این شماره ملی وجود دارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else
                {
                    if (nameTextbox.Text.Any(char.IsDigit))
                    {
                        nameTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام باید شامل حروف و بدون هیچ عددی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (familyTextbox.Text.Any(char.IsDigit))
                    {
                        familyTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام خانوادگی باید شامل حروف و بدون هیچ عددی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (fathernameTextbox.Text.Any(char.IsDigit))
                    {
                        fathernameTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام پدر باید شامل حروف و بدون هیچ عددی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (insComboBox.Text == "سایر" && otherInsTextbox.Text.Any(char.IsDigit))
                    {
                        otherInsTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام بیمه باید شامل حروف و بدون هیچ عددی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!idTextbox.Text.All(char.IsDigit) || idTextbox.Text.Any(char.IsWhiteSpace))
                    {
                        idTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی باید شامل اعداد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!supporterTextbox.Text.All(char.IsDigit) || supporterTextbox.Text.Any(char.IsWhiteSpace))
                    {
                        supporterTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست باید شامل اعداد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!homephoneTextBox.Text.All(char.IsDigit) || homephoneTextBox.Text.Any(char.IsWhiteSpace) || homephoneTextBox.Text.Length != 11)
                    {
                        homephoneTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره تلفن ثابت باید شامل 11 رقم عدد(همراه با پیش شماره) و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!cellphoneTextBox.Text.All(char.IsDigit) || cellphoneTextBox.Text.Any(char.IsWhiteSpace) || cellphoneTextBox.Text.Length != 11)
                    {
                        cellphoneTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره تلفن همراه باید شامل 11 رقم عدد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (identifierNameTextBox.Text.Any(char.IsDigit))
                    {
                        identifierNameTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام معرف باید شامل حروف و بدون هیچ عددی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (!identifierPhoneTextBox.Text.All(char.IsDigit) || identifierPhoneTextBox.Text.Any(char.IsWhiteSpace) || identifierPhoneTextBox.Text.Length != 11)
                    {
                        identifierPhoneTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره تلفن معرف باید شامل 11 رقم عدد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    SqlCommand cmdchecksupport = new SqlCommand("select count(*) as sup from member where id = @sup and id = supporter_id", con1);
                    cmdchecksupport.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                    int sup = 0;
                    using (SqlDataReader reader = cmdchecksupport.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0 && idTextbox.Text != supporterTextbox.Text)
                    {
                        supporterTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در سیستم موجود نیست و یا این شماره مربوط به هیچ سرپرست خانواری نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    else
                    {   
                        if (this.id == idTextbox.Text)
                        {
                            SqlCommand cmd1 = new SqlCommand("update member Set name = @name, family = @family, fatherName = @fatherName, supporter_id = @supporter_id, sex = @sex, job = @job, house = @house, birthdate = @birthdate, folderdate = @folderdate, checkdate = @checkdate, health = @health, otherSup = @otherSup, annual = @annual, car = @car, seyed = @seyed, marriage = @marriage, homephone = @homephone, cellphone = @cellphone, address = @address, explain = @explain, folder_id = @folder_id, orphan = @orphan, student = @student, insurance = @ins, identifierName = @iName, identifierPhone = @iPhone, enactmentId = @eId where id = @id", con1);
                            cmd1.Parameters.AddWithValue("@name", nameTextbox.Text);
                            cmd1.Parameters.AddWithValue("@family", familyTextbox.Text);
                            cmd1.Parameters.AddWithValue("@fatherName", fathernameTextbox.Text);
                            cmd1.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd1.Parameters.AddWithValue("@supporter_id", supporterTextbox.Text);
                            cmd1.Parameters.AddWithValue("@homephone", homephoneTextBox.Text);
                            cmd1.Parameters.AddWithValue("@cellphone", cellphoneTextBox.Text);
                            cmd1.Parameters.AddWithValue("@address", addressTextBox.Text);
                            cmd1.Parameters.AddWithValue("@explain", explainTextBox.Text + newExplain.Text + "(ویرایش اطلاعات در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                            cmd1.Parameters.AddWithValue("@birthdate", birthdateTimePickerX.SelectedDateInDateTime.Date);
                            cmd1.Parameters.AddWithValue("@folderdate", folderdateTimePickerX.SelectedDateInDateTime.Date);
                            string d = folderdateTimePickerX.SelectedDateInDateTime.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                            cmd1.Parameters.AddWithValue("@checkdate", checkdateTimePickerX.SelectedDateInDateTime.Date);
                            cmd1.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd1.Parameters.AddWithValue("@sex", sexComboBox.Text);
                            cmd1.Parameters.AddWithValue("@health", healthComboBox.Text);
                            cmd1.Parameters.AddWithValue("@marriage", marryComboBox.Text);
                            if (workComboBox.Enabled)
                            {
                                cmd1.Parameters.AddWithValue("@job", workComboBox.Text);
                                cmd1.Parameters.AddWithValue("@house", houseComboBox.Text);
                                if(insComboBox.Text == "سایر")
                                {
                                    cmd1.Parameters.AddWithValue("@ins", otherInsTextbox.Text);
                                }
                                else
                                {
                                    cmd1.Parameters.AddWithValue("@ins", insComboBox.Text);
                                }
                                cmd1.Parameters.AddWithValue("@iName", identifierNameTextBox.Text);
                                cmd1.Parameters.AddWithValue("@iPhone", identifierPhoneTextBox.Text);
                                if (annualCheckBox1.Checked)
                                    cmd1.Parameters.AddWithValue("@annual", "سطح یک");
                                else if (annualCheckBox2.Checked)
                                    cmd1.Parameters.AddWithValue("@annual", "سطح دو");
                                else
                                    cmd1.Parameters.AddWithValue("@annual", "خیر");
                                if (otherSupCheckBox.Checked)
                                    cmd1.Parameters.AddWithValue("@otherSup", otherSupTextBox.Text);
                                else
                                    cmd1.Parameters.AddWithValue("@otherSup", "خیر");
                            }
                            else
                            {
                                SqlCommand cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup, identifierName, identifierPhone from member where id = @sup;", con1);
                                cmdgetsupinfo.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                                using (SqlDataReader reader = cmdgetsupinfo.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        cmd1.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                                        cmd1.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                                        cmd1.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                                        cmd1.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                                        cmd1.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                                        cmd1.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                                        cmd1.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                                    }
                                }
                            }
                            if (seyedCheckBox.Checked)
                                cmd1.Parameters.AddWithValue("@seyed", "بله");
                            else
                                cmd1.Parameters.AddWithValue("@seyed", "خیر");
                            if (carCheckBox.Checked)
                                cmd1.Parameters.AddWithValue("@car", "دارد");
                            else
                                cmd1.Parameters.AddWithValue("@car", "ندارد");
                            
                            if (orphanCheckBox.Checked)
                            {
                                cmd1.Parameters.AddWithValue("@orphan", "بله");
                            }
                            else
                            {
                                cmd1.Parameters.AddWithValue("@orphan", "خیر");
                            }
                            if (studentCheckBox.Checked)
                            {
                                cmd1.Parameters.AddWithValue("@student", "بله");
                            }
                            else
                            {
                                cmd1.Parameters.AddWithValue("@student", "خیر");
                            }
                            string fold = this.fol;
                            if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                            {
                                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست را ویرایش کرده اید، آیا علت این امر تصحیح خطا در ثبت سرپرست عضو می باشد؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question,FMessegeBox.FMessegeBoxDefaultButton.button1);
                                if (res == DialogResult.No)
                                {
                                    newExplain.Text += ("(تغییر سرپرست به خود و تشکیل پرونده و خانوار جدید در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else if (res == DialogResult.Yes)
                                {
                                    newExplain.Text += ("(اصلاح سرپرست و تغییر آن به خود و ایجاد پرونده و خانوار در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else
                                {
                                    con1.Close();
                                    return;
                                }
                                SqlCommand cmdgetfolder = new SqlCommand("select folder_id from member where folder_id like '" + d + "%';", con1);
                                string index = "1";
                                using (SqlDataReader reader = cmdgetfolder.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string s = String.Format("{0}", reader["folder_id"]);
                                        if (s == "") index = "1";
                                        else index = (s[s.Length - 1] - '0' + 1).ToString();
                                    }
                                }
                                fold = d + index;

                            }
                            else if (this.sup_id != supporterTextbox.Text)
                            {
                                DialogResult res = FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست را ویرایش کرده اید، آیا علت این امر تصحیح خطا در ثبت سرپرست عضو می باشد؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                                if (res == DialogResult.No)
                                {
                                    newExplain.Text += ("(تغییر سرپرست در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else if (res == DialogResult.Yes)
                                {
                                    newExplain.Text += ("(اصلاح سرپرست در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else
                                {
                                    con1.Close();
                                    return;
                                }
                                SqlCommand cmdgetfolder = new SqlCommand("select folder_id from member where id = @sup;", con1);
                                cmdgetfolder.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                                using (SqlDataReader reader = cmdgetfolder.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string s = String.Format("{0}", reader["folder_id"]);
                                        fold = s;
                                    }
                                    
                                }
                            }
                            cmd1.Parameters.AddWithValue("@folder_id", fold);
                            cmd1.ExecuteNonQuery();
                            
                            if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                            {
                                System.IO.Directory.CreateDirectory(defaultPath + "\\" + fold);
                                System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                            }
                            else if(this.sup_id != supporterTextbox.Text)
                            {
                                System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                            }

                            PersianCalendar _persian = new PersianCalendar();
                            DateTime birth = birthdateTimePickerX.SelectedDateInDateTime.Date;
                            DateTime now = DateTime.Now.Date;
                            int now_month = _persian.GetMonth(now), now_year = _persian.GetYear(now), now_day = _persian.GetDayOfMonth(now);
                            int birth_month = _persian.GetMonth(birth), birth_year = _persian.GetYear(birth), birth_day = _persian.GetDayOfMonth(birth);
                            if (/*sex == "مرد"*/ healthComboBox.Text == "بیمار خاص" && now_year - birth_year < 18 || (now_year - birth_year == 18 && now_month < birth_month) || (now_year - birth_year == 18 && now_month == birth_month && now_day < birth_day))
                            {
                                SqlCommand cmdcheckexistance = new SqlCommand("select count(*) as exist from onindependency where id = @id", con1);
                                cmdcheckexistance.Parameters.AddWithValue("@id", idTextbox.Text);
                                int exist = 0;
                                using (SqlDataReader reader = cmdcheckexistance.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        exist = int.Parse(String.Format("{0}", reader["exist"]));
                                    }
                                }
                                if (exist == 0)
                                {
                                    SqlCommand addit = new SqlCommand("insert into onindependency(id) Values (@id);", con1);
                                    addit.Parameters.AddWithValue("@id", idTextbox.Text);
                                    addit.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                SqlCommand deleteit = new SqlCommand("delete from onindependency where id = @id;", con1);
                                deleteit.Parameters.AddWithValue("@id", idTextbox.Text);
                                deleteit.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("begin tran t1; delete from member where id = @prev_id; insert into member(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, homephone, cellphone, address, explain, folder_id, orphan, student, identifierName, identifierPhone, enactmentId)" +
                            " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @car, @seyed, @marriage, @homephone, @cellphone, @address, @explain, @folder_id, @orphan, @student, @iName, @iPhone, @eId); update member Set supporter_id = @id where supporter_id = @prev_id; delete from onindependency where id = @prev_id; commit tran t1", con1);
                            cmd.Parameters.AddWithValue("@name", nameTextbox.Text);
                            cmd.Parameters.AddWithValue("@family", familyTextbox.Text);
                            cmd.Parameters.AddWithValue("@fatherName", fathernameTextbox.Text);
                            cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd.Parameters.AddWithValue("@supporter_id", supporterTextbox.Text);
                            cmd.Parameters.AddWithValue("@homephone", homephoneTextBox.Text);
                            cmd.Parameters.AddWithValue("@cellphone", cellphoneTextBox.Text);
                            cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                            cmd.Parameters.AddWithValue("@explain", explainTextBox.Text+newExplain.Text + "(ویرایش شماره ملی و اطلاعات در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                            cmd.Parameters.AddWithValue("@birthdate", birthdateTimePickerX.SelectedDateInDateTime.Date);
                            cmd.Parameters.AddWithValue("@folderdate", folderdateTimePickerX.SelectedDateInDateTime.Date);
                            string d = folderdateTimePickerX.SelectedDateInDateTime.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                            cmd.Parameters.AddWithValue("@checkdate", checkdateTimePickerX.SelectedDateInDateTime.Date);
                            cmd.Parameters.AddWithValue("@prev_id", this.id);
                            cmd.Parameters.AddWithValue("@eId", ExtensionFunction.PersianToEnglish(enactmentTextbox.Text));
                            cmd.Parameters.AddWithValue("@sex", sexComboBox.Text);
                            cmd.Parameters.AddWithValue("@health", healthComboBox.Text);
                            if (workComboBox.Enabled)
                            {
                                cmd.Parameters.AddWithValue("@job", workComboBox.Text);
                                cmd.Parameters.AddWithValue("@house", houseComboBox.Text);
                                cmd.Parameters.AddWithValue("@ins", insComboBox.Text);
                                cmd.Parameters.AddWithValue("@iName", identifierNameTextBox.Text);
                                cmd.Parameters.AddWithValue("@iPhone", identifierPhoneTextBox.Text);
                                if (annualCheckBox1.Checked)
                                    cmd.Parameters.AddWithValue("@annual", "سطح یک");
                                else if (annualCheckBox2.Checked)
                                    cmd.Parameters.AddWithValue("@annual", "سطح دو");
                                else
                                    cmd.Parameters.AddWithValue("@annual", "خیر");
                                if (otherSupCheckBox.Checked)
                                    cmd.Parameters.AddWithValue("@otherSup", otherSupTextBox.Text);
                                else
                                    cmd.Parameters.AddWithValue("@otherSup", "خیر");
                            }
                            else
                            {
                                SqlCommand cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup from member where id = @sup;", con1);
                                cmdgetsupinfo.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                                using (SqlDataReader reader = cmdgetsupinfo.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        cmd.Parameters.AddWithValue("@job", String.Format("{0}", reader["job"]));
                                        cmd.Parameters.AddWithValue("@house", String.Format("{0}", reader["house"]));
                                        cmd.Parameters.AddWithValue("@ins", String.Format("{0}", reader["insurance"]));
                                        cmd.Parameters.AddWithValue("@annual", String.Format("{0}", reader["annual"]));
                                        cmd.Parameters.AddWithValue("@otherSup", String.Format("{0}", reader["otherSup"]));
                                        cmd.Parameters.AddWithValue("@iName", String.Format("{0}", reader["identifierName"]));
                                        cmd.Parameters.AddWithValue("@iPhone", String.Format("{0}", reader["identifierPhone"]));
                                    }
                                }
                            }
                            if (seyedCheckBox.Checked)
                                cmd.Parameters.AddWithValue("@seyed", "بله");
                            else
                                cmd.Parameters.AddWithValue("@seyed", "خیر");
                            if (carCheckBox.Checked)
                                cmd.Parameters.AddWithValue("@car", "دارد");
                            else
                                cmd.Parameters.AddWithValue("@car", "ندارد");
                            cmd.Parameters.AddWithValue("@marriage", marryComboBox.Text);
                            if (orphanCheckBox.Checked)
                            {
                                cmd.Parameters.AddWithValue("@orphan", "بله");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@orphan", "خیر");
                            }
                            if (studentCheckBox.Checked)
                            {
                                cmd.Parameters.AddWithValue("@student", "بله");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@student", "خیر");
                            }
                            string fold = this.fol;
                            if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                            {
                                SqlCommand cmdgetfolder = new SqlCommand("select folder_id from member where folder_id like '" + d + "%';", con1);
                                string index = "1";
                                using (SqlDataReader reader = cmdgetfolder.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string s = String.Format("{0}", reader["folder_id"]);
                                        if (s == "") index = "1";
                                        else index = (s[s.Length - 1] - '0' + 1).ToString();
                                    }
                                }
                                fold = d + index;
                            }
                            else if (this.sup_id != supporterTextbox.Text)
                            {
                                SqlCommand cmdgetfolder = new SqlCommand("select folder_id from member where id = @sup;", con1);
                                cmdgetfolder.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                                using (SqlDataReader reader = cmdgetfolder.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string s = String.Format("{0}", reader["folder_id"]);
                                        fold = s;
                                    }
                                }
                            }
                            cmd.Parameters.AddWithValue("@folder_id", fold);
                            cmd.ExecuteNonQuery();
                            SqlCommand cmdget = new SqlCommand("select i, docname, doctype from doc where id = @prev_id");
                            cmdget.Parameters.AddWithValue("@prev_id", this.id);
                            List<Tuple<string, string, string>> li = new List<Tuple<string, string, string>>();
                            Tuple<string, string, string>[] arr;
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    li.Add(new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                                }
                                arr = li.ToArray();
                            }
                            
                            foreach(var dd in arr)
                            {
                                cmd = new SqlCommand("update doc Set id = @id, docpath = @dpath where i = @i", con1);
                                cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                                cmd.Parameters.AddWithValue("@i", dd.Item1);
                                cmd.Parameters.AddWithValue("@dpath", defaultPath + "\\" + fold + "\\" + idTextbox.Text + "\\" + dd.Item3 + "\\" + dd.Item2);
                                cmd.ExecuteNonQuery();
                            }
                            if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                            {
                                System.IO.Directory.CreateDirectory(defaultPath + "\\" + fold);
                                System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                            }
                            else
                            {
                                System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                            }
                            PersianCalendar _persian = new PersianCalendar();
                            DateTime birth = birthdateTimePickerX.SelectedDateInDateTime.Date;
                            DateTime now = DateTime.Now.Date;
                            int now_month = _persian.GetMonth(now), now_year = _persian.GetYear(now), now_day = _persian.GetDayOfMonth(now);
                            int birth_month = _persian.GetMonth(birth), birth_year = _persian.GetYear(birth), birth_day = _persian.GetDayOfMonth(birth);
                            if (/*sex == "مرد"*/ healthComboBox.Text == "بیمار خاص" && now_year - birth_year < 18 || (now_year - birth_year == 18 && now_month < birth_month) || (now_year - birth_year == 18 && now_month == birth_month && now_day < birth_day))
                            {
                                SqlCommand cmdcheckexistance = new SqlCommand("select count(*) as exist from onindependency where id = @id", con1);
                                cmdcheckexistance.Parameters.AddWithValue("@id", idTextbox.Text);
                                int exist = 0;
                                using (SqlDataReader reader = cmdcheckexistance.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        exist = int.Parse(String.Format("{0}", reader["exist"]));
                                    }
                                }
                                if (exist == 0)
                                {
                                    SqlCommand addit = new SqlCommand("insert into onindependency(id) Values (@id);", con1);
                                    addit.Parameters.AddWithValue("@id", idTextbox.Text);
                                    addit.ExecuteNonQuery();
                                }
                            }
                        }
                        con1.Close();
                        updateFamily();
                        FMessegeBox.FarsiMessegeBox.Show("عضو با موفقیت ویرایش شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        

                        this.Close();

                    }
                }
            }
            con1.Close();
        }

        private void checkSupporterButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdchecksupport = new SqlCommand("select count(*) as sup from member where id = @sup and id = supporter_id", con);
            cmdchecksupport.Parameters.AddWithValue("@sup", supporterTextbox.Text);
            int sup = 0;
            using (SqlDataReader reader = cmdchecksupport.ExecuteReader())
            {

                if (reader.Read())
                {
                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            if (sup == 0 && idTextbox.Text != supporterTextbox.Text)
            {
                FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در سیستم موجود نیست و یا این شماره مربوط به هیچ سرپرست خانواری نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else if (idTextbox.Text == supporterTextbox.Text)
            {
                FMessegeBox.FarsiMessegeBox.Show("عضو سرپرست خود است!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select name, family from member where id = @sup", con);
                cmd.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        string msg = "نام: ";
                        msg += String.Format("{0}", reader["name"]);
                        msg += " نام خانوادگی: ";
                        msg += String.Format("{0}", reader["family"]);

                        FMessegeBox.FarsiMessegeBox.Show(msg, "اطلاعات سرپرست", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                }
            }
            
            con.Close();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("ویرایش عضو");
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                supporterTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void orphanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            orphanAddFileButton.Visible = orphanLabel.Visible = orphanCheckBox.Checked;
        }

        private void studentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            studentAddFileButton.Visible = studentLabel.Visible = studentCheckBox.Checked;
        }

        private void houseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            houseAddFileButton.Visible = houseLabel.Visible = (houseComboBox.Text == "مستأجر سطح یک" || houseComboBox.Text == "مستأجر سطح دو");
        }

        private void healthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            healthAddFileButton.Visible = healthLabel.Visible = (healthComboBox.Text == "بیمار خاص");
        }

        private void insComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            otherInsTextbox.Visible = (insComboBox.Text == "سایر");
        }

        private void idTextbox_Click(object sender, EventArgs e)
        {
            idTextbox.BackColor = SystemColors.Window;
        }

        private void nameTextbox_Click(object sender, EventArgs e)
        {
            nameTextbox.BackColor = SystemColors.Window;
        }

        private void familyTextbox_Click(object sender, EventArgs e)
        {
            familyTextbox.BackColor = SystemColors.Window;
        }

        private void fathernameTextbox_Click(object sender, EventArgs e)
        {
            fathernameTextbox.BackColor = SystemColors.Window;
        }

        private void supporterTextbox_Click(object sender, EventArgs e)
        {
            supporterTextbox.BackColor = SystemColors.Window;
        }

        private void homephoneTextBox_Click(object sender, EventArgs e)
        {
            homephoneTextBox.BackColor = SystemColors.Window;
        }

        private void cellphoneTextBox_Click(object sender, EventArgs e)
        {
            cellphoneTextBox.BackColor = SystemColors.Window;
        }

        private void sexComboBox_Click(object sender, EventArgs e)
        {
            sexComboBox.BackColor = SystemColors.Window;
        }

        private void houseComboBox_Click(object sender, EventArgs e)
        {
            houseComboBox.BackColor = SystemColors.Window;
        }

        private void healthComboBox_Click(object sender, EventArgs e)
        {
            healthComboBox.BackColor = SystemColors.Window;
        }

        private void marryComboBox_Click(object sender, EventArgs e)
        {
            marryComboBox.BackColor = SystemColors.Window;
        }

        private void workComboBox_Click(object sender, EventArgs e)
        {
            houseComboBox.BackColor = SystemColors.Window;
        }

        private void insComboBox_Click(object sender, EventArgs e)
        {
            houseComboBox.BackColor = SystemColors.Window;
        }
        
        private void otherInsTextbox_Click(object sender, EventArgs e)
        {
            otherInsTextbox.BackColor = SystemColors.Window;
        }

        private void authAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک شناسایی", this.id, "auth", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                authLabel.BackColor = Color.Red;
            else
                authLabel.BackColor = Color.YellowGreen;
        }

        private void otherAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک متفرقه", this.id, "other", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                otherLabel.BackColor = Color.Red;
            else
                otherLabel.BackColor = Color.YellowGreen;
        }

        private void studentAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک دانش‌آموزی", this.id, "student", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                studentLabel.BackColor = Color.Red;
            else
                studentLabel.BackColor = Color.YellowGreen;
        }

        private void orphanAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک یتیمی", this.id, "orphan", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                orphanLabel.BackColor = Color.Red;
            else
                orphanLabel.BackColor = Color.YellowGreen;
        }

        private void healthAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک بیماری", this.id, "health", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                healthLabel.BackColor = Color.Red;
            else
                healthLabel.BackColor = Color.YellowGreen;
        }

        private void marryAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک " + marryComboBox.Text, this.id, "marry", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                marryLabel.BackColor = Color.Red;
            else
                marryLabel.BackColor = Color.YellowGreen;
        }

        private void houseAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک استیجار", this.id, "house", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                houseLabel.BackColor = Color.Red;
            else
                houseLabel.BackColor = Color.YellowGreen;
        }

        private void otherSupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            otherSupTextBox.Visible = otherSupCheckBox.Checked;
        }

        private void profileAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب تصویر عضو";
            addOpenFileDialog.FileName = "*.png";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.profile = addOpenFileDialog.FileName;
                profilePictureBox.ImageLocation = this.profile;
                SqlConnection con = new SqlConnection(this.connection);
                con.Open();
                SqlCommand proupcmd = new SqlCommand("update doc Set docname=@dname, docpath=@dpath, subdate=@subdate where id=@id and doctype='profile';", con);
                string fileName = System.IO.Path.GetFileName(this.profile);
                string targetPath = defaultPath + "\\" + fol + "\\" + this.id + "\\profile";
                System.IO.Directory.Delete(targetPath, true);
                System.IO.Directory.CreateDirectory(targetPath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(this.profile, destFile, false);
                
                proupcmd.Parameters.AddWithValue("@id", this.id);
                proupcmd.Parameters.AddWithValue("@dname", fileName);
                proupcmd.Parameters.AddWithValue("@dpath", destFile);
                proupcmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                proupcmd.Parameters.AddWithValue("@dtype", "profile");
                proupcmd.ExecuteNonQuery();
                con.Close();
                FMessegeBox.FarsiMessegeBox.Show("تصویر با موفقیت به روز شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                addOpenFileDialog.FileName = "*.png";
                if (this.profile == "")
                    profilePictureBox.Image = WindowsFormsApp6.Properties.Resources.profile;
                else
                    profilePictureBox.ImageLocation = this.profile;
            }
        }

        private void otherSupTextBox_Click(object sender, EventArgs e)
        {
            otherSupTextBox.BackColor = SystemColors.Window;
        }

        private void supporterTextbox_TextChanged(object sender, EventArgs e)
        {
            identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualCheckBox1.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            if (!(supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text)))
            {
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualCheckBox1.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            if (!(supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text)))
            {
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
            }
        }

        private void annualCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox2.Checked = (annualCheckBox2.Checked && !annualCheckBox1.Checked);
        }
        private void annualCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox1.Checked = (annualCheckBox1.Checked && !annualCheckBox2.Checked);
        }

        private void identifierNameTextBox_Click(object sender, EventArgs e)
        {
            identifierNameTextBox.BackColor = SystemColors.Window;
        }

        private void addressTextBox_Click(object sender, EventArgs e)
        {
            addressTextBox.BackColor = SystemColors.Window;
        }

        private void editMemberForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (authLabel.BackColor == Color.Red || marryLabel.BackColor == Color.Red || (orphanLabel.Visible && orphanLabel.BackColor == Color.Red) || (studentLabel.Visible && studentLabel.BackColor == Color.Red) || (healthLabel.Visible && healthLabel.BackColor == Color.Red) || (houseLabel.Visible && houseLabel.BackColor == Color.Red))
            {
                FMessegeBox.FarsiMessegeBox.Show("مدارک ناقص است و بدون تکمیل مدارک نمی‌توانید ویرایش متقاضی را رها نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
        }

        private void enactmentTextbox_TextChanged(object sender, EventArgs e)
        {
            editButton.Enabled = !string.IsNullOrEmpty(enactmentTextbox.Text) && !string.IsNullOrWhiteSpace(enactmentTextbox.Text);
        }

        private void sexComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sexComboBox.Text == "مرد")
            {
                if (marryComboBox.Text == "بیوه" || marryComboBox.Text == "مطلقه")
                {
                    marryComboBox.SelectedIndex = -1;
                }
                if (marryComboBox.Items.Contains("بیوه"))
                {
                    marryComboBox.Items.Remove("بیوه");
                    marryComboBox.Items.Remove("مطلقه");
                }
            }
            else
            {
                if (!marryComboBox.Items.Contains("بیوه"))
                {
                    marryComboBox.Items.Add("مطلقه");
                    marryComboBox.Items.Add("بیوه");
                }
            }
        }

        private void searchEnactmentButton_Click(object sender, EventArgs e)
        {
            var newform = new searchEnactmentForm();
            newform.ShowDialog(this);
            if (newform.Text.StartsWith("choose"))
            {
                enactmentTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
            }
        }

        private void identifierPhoneTextBox_Click(object sender, EventArgs e)
        {
            identifierPhoneTextBox.BackColor = SystemColors.Window;
        }
    }
}