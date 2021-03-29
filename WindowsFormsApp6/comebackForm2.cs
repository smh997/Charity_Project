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
    public partial class comebackForm2 : Form
    {
        private string id;
        private string sup_id;
        private string fol;
        private string birth, profile;
        string eId;
        string reason = "";
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\member";
        string[] dirList = { "auth", "health", "house", "marry", "study", "orphan", "other", "research", "deletion", "CB", "helped" };
        List<string> doc;
        public comebackForm2(string id)
        {
            InitializeComponent();
            this.id = id;
            doc = new List<string>();
            this.profile = "";
        }

        private void comebackForm2_Load(object sender, EventArgs e)
        {
            FMessegeBox.FarsiMessegeBox.Show("در صورتی که میخواهید فردی را رجعت دهید که سرپرست خود نیست، ابتدا از تحت پوشش بودن سرپرست او اطمینان حاصل نمایید و در صورت تمایل به رجعت یک خانوار ابتدا سرپرست را رجعت دهید.", "نوجه", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);

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

            comebackmangroupBox.Hide();
            comebackwomangroupBox.Hide();
            
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from abandoned where id = @id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    idTextbox.Text = String.Format("{0}", reader["id"]); idTextbox.Enabled = false;
                    nameTextbox.Text = String.Format("{0}", reader["name"]);
                    familyTextbox.Text = String.Format("{0}", reader["family"]);
                    fathernameTextbox.Text = String.Format("{0}", reader["fatherName"]);
                    supporterTextbox.Text = String.Format("{0}", reader["supporter_id"]); sup_id = supporterTextbox.Text;
                    homephoneTextBox.Text = String.Format("{0}", reader["homephone"]);
                    cellphoneTextBox.Text = String.Format("{0}", reader["cellphone"]);
                    addressTextBox.Text = String.Format("{0}", reader["address"]);
                    explainTextBox.Text = String.Format("{0}", reader["explain"]);
                    identifierNameTextBox.Text = String.Format("{0}", reader["identifierName"]);
                    identifierPhoneTextBox.Text = String.Format("{0}", reader["identifierPhone"]);
                    eId = String.Format("{0}", reader["enactmentId"]);
                    birthdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date; this.birth = String.Format("{0}", reader["birthdate"]);
                    folderdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["folderdate"])).Date;
                    checkdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["checkdate"])).Date;
                    this.fol = String.Format("{0}", reader["folder_id"]);
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
                    if (annual == "سطح یک")
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
                    else
                    {
                        orphanCheckBox.Checked = false;
                    }
                    //student
                    String student = String.Format("{0}", reader["student"]);
                    if (student == "بله")
                    {
                        studentAddFileButton.Visible = studentLabel.Visible = studentCheckBox.Checked = true;
                        studentLabel.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        studentCheckBox.Checked = false;
                    }
                }
                if (sexComboBox.Text == "مرد")
                {
                    comebackmangroupBox.Show();
                }
                else
                {
                    comebackwomangroupBox.Show();
                }
            }
            if (this.sup_id == this.id)
            {
                identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = annualCheckBox1.Enabled = otherSupCheckBox.Enabled = otherSupTextBox.Enabled = houseComboBox.Enabled = workComboBox.Enabled = insComboBox.Enabled = true;
            }
            SqlCommand cmdgetprofile = new SqlCommand("select docpath from doc where id = @id and doctype = 'profile';", con);
            cmdgetprofile.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmdgetprofile.ExecuteReader())
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
        }

        private void comebackButton_Click(object sender, EventArgs e)
        {
            bool isempty = true;
            if (sexComboBox.Text == "مرد")
            {
                foreach (CheckBox cb in comebackmangroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        reason += cb.Text + " و ";
                        isempty = false;
                    }
                }
            }
            else
            {
                foreach (CheckBox cb in comebackwomangroupBox.Controls)
                {
                    if (cb.Checked)
                    {
                        reason += cb.Text + " و ";
                        isempty = false;
                    }
                }
            }

            if (isempty)
            {
                FMessegeBox.FarsiMessegeBox.Show("هیچ علتی برای رجعت انتخاب نشده است!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                return;
            }

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
            else if (authLabel.BackColor == Color.Red || marryLabel.BackColor == Color.Red || (orphanLabel.Visible && orphanLabel.BackColor == Color.Red) || (studentLabel.Visible && studentLabel.BackColor == Color.Red) || (healthLabel.Visible && healthLabel.BackColor == Color.Red) || (houseLabel.Visible && houseLabel.BackColor == Color.Red) || (comebackLabel.BackColor == Color.Red))
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
                        SqlCommand cmd1 = new SqlCommand("begin tran t1; insert into member(id, name, family, fatherName, supporter_id, sex, job, house, birthdate, folderdate, checkdate, health, otherSup, annual, car, seyed, marriage, insurance, homephone, cellphone, address, explain, folder_id, orphan, student, identifierName, identifierPhone, enactmentId)" +
                            "Values(@id, @name, @family, @fatherName, @supporter_id, @sex, @job, @house, @birthdate, @folderdate, @checkdate, @health, @otherSup, @annual, @car, @seyed, @marriage, @ins, @homephone, @cellphone, @address, @explain, @folder_id, @orphan, @student, @iName, @iPhone, @eId);" +
                            "insert into Inmember(id, description, setupdate, folder_id, sick, familyFinancial, nonjob, single, cut, returnRegion) Values(@id, @description, @setupdate, @folder_id, @sick, @familyFinancial, @nonjob, @single, @cut, @returnRegion);" +
                            "delete from abandoned where id = @id; update outmember Set comebackdate= @setupdate where id = @id and comebackdate is Null;commit tran t1;", con1);
                        cmd1.Parameters.AddWithValue("@name", nameTextbox.Text);
                        cmd1.Parameters.AddWithValue("@family", familyTextbox.Text);
                        cmd1.Parameters.AddWithValue("@fatherName", fathernameTextbox.Text);
                        cmd1.Parameters.AddWithValue("@id", idTextbox.Text);
                        cmd1.Parameters.AddWithValue("@supporter_id", supporterTextbox.Text);
                        cmd1.Parameters.AddWithValue("@homephone", homephoneTextBox.Text);
                        cmd1.Parameters.AddWithValue("@cellphone", cellphoneTextBox.Text);
                        cmd1.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd1.Parameters.AddWithValue("@explain", explainTextBox.Text + newExplain.Text + "(رجعت عضو به دلیل " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd1.Parameters.AddWithValue("@birthdate", birthdateTimePickerX.SelectedDateInDateTime.Date);
                        cmd1.Parameters.AddWithValue("@folderdate", folderdateTimePickerX.SelectedDateInDateTime.Date);
                        string d = folderdateTimePickerX.SelectedDateInDateTime.Date.ToPersian(); d = d.Substring(0, 4) + d.Substring(5, 2) + d.Substring(8, 2);
                        cmd1.Parameters.AddWithValue("@checkdate", checkdateTimePickerX.SelectedDateInDateTime.Date);
                        cmd1.Parameters.AddWithValue("@description", newExplain.Text + "(رجعت عضو به دلیل " + reason + "در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd1.Parameters.AddWithValue("@setupdate", DateTime.Now.Date);
                        cmd1.Parameters.AddWithValue("@eId", eId);
                        cmd1.Parameters.AddWithValue("@sex", sexComboBox.Text);
                        cmd1.Parameters.AddWithValue("@health", healthComboBox.Text);
                        cmd1.Parameters.AddWithValue("@marriage", marryComboBox.Text);
                        if (workComboBox.Enabled)
                        {
                            cmd1.Parameters.AddWithValue("@job", workComboBox.Text);
                            cmd1.Parameters.AddWithValue("@house", houseComboBox.Text);
                            cmd1.Parameters.AddWithValue("@ins", insComboBox.Text);
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

                        if (manhealthcheckBox.Checked || womanhealthcheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@sick", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@sick", "خیر");
                        }
                        if (financialcheckBox.Checked || womanfinancialcheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@familyFinancial", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@familyFinancial", "خیر");
                        }
                        if (nonjobcheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@nonjob", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@nonjob", "خیر");
                        }
                        if (cutcheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@cut", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@cut", "خیر");
                        }
                        if (singlecheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@single", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@single", "خیر");
                        }
                        if(returncheckBox.Checked || returnMancheckBox.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@returnRegion", "بله");
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@returnRegion", "خیر");
                        }

                        string fold = this.fol;
                        if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                        {
                                
                            DialogResult res = MessageBox.Show("آیا مایلید عضو با تشکیل خانوار جدید رجعت نماید؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            if (res == DialogResult.Yes)
                            {
                                newExplain.Text += ("(رجعت عضو: تشکیل خانوار جدید به سرپرستی این عضو در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
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
                            DialogResult res = MessageBox.Show("آیا مایلید عضو با پیوستن به خانواری متفاوت از خانوار قبلی رجعت نماید؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            if (res == DialogResult.Yes)
                            {
                                newExplain.Text += ("(رجعت عضو:پیوستن به خانواری متفاوت از قبل در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
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
                        SqlCommand cmdget = new SqlCommand("select i, docname, doctype from doc where id = @prev_id", con1);
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

                        foreach (var dd in arr)
                        {
                            cmd1 = new SqlCommand("update doc Set docpath = @dpath where i = @i", con1);
                            cmd1.Parameters.AddWithValue("@i", dd.Item1);
                            cmd1.Parameters.AddWithValue("@dpath", defaultPath + "\\" + fold + "\\" + idTextbox.Text + "\\" + dd.Item3 + "\\" + dd.Item2);
                            cmd1.ExecuteNonQuery();
                        }
                        if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                        {
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + fold);
                            System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                        }
                        else if (this.sup_id != supporterTextbox.Text)
                        {
                            System.IO.Directory.Move(defaultPath + "\\" + fol + "\\" + this.id, defaultPath + "\\" + fold + "\\" + idTextbox.Text);
                        }
                        foreach (var fm in doc)
                        {
                            string fileName = System.IO.Path.GetFileName(fm);
                            string targetPath = defaultPath + "\\" + fold + "\\" + idTextbox.Text + "\\CB";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            if (System.IO.File.Exists(destFile))
                            {
                                destFile = System.IO.Path.Combine(targetPath, fileName.Substring(0, fileName.Length - 4) + " " + DateTime.Now.Date.ToPersian() + ".pdf");
                            }
                            System.IO.File.Copy(fm, destFile, false);
                            cmd1 = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                            cmd1.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd1.Parameters.AddWithValue("@dname", fileName);
                            cmd1.Parameters.AddWithValue("@dpath", destFile);
                            cmd1.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd1.Parameters.AddWithValue("@dtype", "CB");
                            cmd1.ExecuteNonQuery();
                        }
                        cmd1 = new SqlCommand("update research Set confirmed = @conf where id = (select max(research.id) from research, abandoned where memberId = abandoned.id and abandoned.id = @sup and confirmed = N'خیر');", con1);
                        cmd1.Parameters.AddWithValue("@sup", idTextbox.Text);
                        cmd1.Parameters.AddWithValue("@conf", "بله");
                        cmd1.ExecuteNonQuery();

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

                    FMessegeBox.FarsiMessegeBox.Show("عضو با موفقیت رجعت داده شد.", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);

                    this.Close();

                    
                }
            }
            con1.Close();
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

        private void marryAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش مدارک " + marryComboBox.Text, this.id, "marry", nameTextbox.Text, familyTextbox.Text, this.fol);
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                marryLabel.BackColor = Color.Red;
            else
                marryLabel.BackColor = Color.YellowGreen;
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

        private void comebackAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب مدارک رجعت";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var d in addOpenFileDialog.FileNames)
                {
                    doc.Add(@d);
                }
                comebackLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                doc.Clear();
                addOpenFileDialog.FileName = "*.pdf";
                comebackLabel.BackColor = Color.Red;
            }
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

        private void lifehoodComboBox_Click(object sender, EventArgs e)
        {
            houseComboBox.BackColor = SystemColors.Window;
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

        private void supporterTextbox_TextChanged(object sender, EventArgs e)
        {
            checkSupporterButton.Enabled = !string.IsNullOrEmpty(supporterTextbox.Text);
            identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualCheckBox1.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1; annualCheckBox1.Checked = otherSupCheckBox.Checked = false;
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

        private void otherSupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            otherSupTextBox.Visible = otherSupCheckBox.Checked;
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualCheckBox1.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1; annualCheckBox1.Checked = otherSupCheckBox.Checked = false;
        }

        private void annualCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox2.Checked = (annualCheckBox2.Checked && !annualCheckBox1.Checked);
        }
        private void annualCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox1.Checked = (annualCheckBox1.Checked && !annualCheckBox2.Checked);
        }
    }
}
