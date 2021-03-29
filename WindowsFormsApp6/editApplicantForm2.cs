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
    public partial class editApplicantForm2 : Form
    {
        private string id;
        private string sup_id;
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\applicant";
        public editApplicantForm2(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void editApplicantForm2_Load(object sender, EventArgs e)
        {
            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            workComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            healthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            houseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            marryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            insComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            otherInsTextbox.Visible = otherSupTextBox.Visible = false;

            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from applicant where id = @id", con);
            cmd.Parameters.AddWithValue("@id", this.id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    idTextbox.Text = String.Format("{0}", reader["id"]);
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
                    birthdateTimePickerX.SelectedDateInDateTime = Convert.ToDateTime(String.Format("{0}", reader["birthdate"])).Date;
                    //sex:
                    String sex = String.Format("{0}", reader["sex"]);
                    sexComboBox.Text = sex;
                    //job
                    String job = String.Format("{0}", reader["job"]);
                    workComboBox.Text = job;
                    //house
                    String house = String.Format("{0}", reader["house"]);
                    houseComboBox.Text = house;
                    //health
                    String health = String.Format("{0}", reader["health"]);
                    healthComboBox.Text = health;
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
                        orphanCheckBox.Checked = true;
                    }
                    //student
                    String student = String.Format("{0}", reader["student"]);
                    if (student == "بله")
                    {
                        studentCheckBox.Checked = true;
                    }
                }
            }
            if (this.sup_id == this.id)
            {
                reqAddFileButton.Enabled = identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = otherSupTextBox.Enabled = houseComboBox.Enabled = workComboBox.Enabled = insComboBox.Enabled = true;
            }
            con.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
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
            else if (reqLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("فرم تقاضا انتخاب نشده است", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                int check = 0;
                SqlCommand cmdcheck = new SqlCommand("select count(*) as checked from applicant where id = @id", con1);
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
                    FMessegeBox.FarsiMessegeBox.Show("متقاضی با این شماره ملی وجود دارد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                    SqlCommand cmdchecksupport = new SqlCommand("select count(*) as sup from applicant where id = @sup and id = supporter_id", con1);
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
                            SqlCommand cmd1 = new SqlCommand("update applicant Set name = @name, family = @family, fatherName = @fatherName, supporter_id = @supporter_id, sex = @sex, job = @job, house = @house, birthdate = @birthdate, health = @health, otherSup = @otherSup, annual = @annual, car = @car, seyed = @seyed, marriage = @marriage, homephone = @homephone, cellphone = @cellphone, address = @address, explain = @explain, orphan = @orphan, student = @student, insurance = @ins, identifierName = @iName, identifierPhone = @iPhone where id = @id", con1);
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
                                SqlCommand cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup from applicant where id = @sup;", con1);
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
                            
                            if (this.sup_id != supporterTextbox.Text && this.id == supporterTextbox.Text)
                            {
                                DialogResult res = MessageBox.Show("شماره ملی سرپرست را ویرایش کرده اید، آیا علت این امر تصحیح خطا در ثبت سرپرست متقاضی می باشد؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                if (res == DialogResult.No)
                                {
                                    newExplain.Text += ("(تغییر سرپرست به خود متقاضی در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else if (res == DialogResult.Yes)
                                {
                                    newExplain.Text += ("(اصلاح سرپرست و تغییر آن به خود متقاضی در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                                }
                                else
                                {
                                    con1.Close();
                                    return;
                                }
                            }
                            else if (this.sup_id != supporterTextbox.Text)
                            {
                                DialogResult res = MessageBox.Show("شماره ملی سرپرست را ویرایش کرده اید، آیا علت این امر تصحیح خطا در ثبت سرپرست متقاضی می باشد؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
                            }
                            cmd1.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("BEGIN TRY begin tran t1; delete from applicant where id = @prev_id; insert into applicant(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, subdate, health, otherSup, annual, car, seyed, marriage, homephone, cellphone, address, explain, orphan, student, identifierName, identifierPhone)" +
                            " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @subdate, @health, @otherSup, @annual, @car, @seyed, @marriage, @homephone, @cellphone, @address, @explain, @orphan, @student, @iName, @iPhone); update applicant Set supporter_id = @id where supporter_id = @prev_id commit tran t1 END TRY BEGIN CATCH ROLLBACK END CATCH;", con1);
                            cmd.Parameters.AddWithValue("@name", nameTextbox.Text);
                            cmd.Parameters.AddWithValue("@family", familyTextbox.Text);
                            cmd.Parameters.AddWithValue("@fatherName", fathernameTextbox.Text);
                            cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd.Parameters.AddWithValue("@supporter_id", supporterTextbox.Text);
                            cmd.Parameters.AddWithValue("@homephone", homephoneTextBox.Text);
                            cmd.Parameters.AddWithValue("@cellphone", cellphoneTextBox.Text);
                            cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                            cmd.Parameters.AddWithValue("@explain", explainTextBox.Text + newExplain.Text + "(ویرایش شماره ملی و اطلاعات در تاریخ" + DateTime.Now.Date.ToPersian() + ")");
                            cmd.Parameters.AddWithValue("@birthdate", birthdateTimePickerX.SelectedDateInDateTime.Date);
                            cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@prev_id", this.id);
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
                                SqlCommand cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup from applicant where id = @sup;", con1);
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
                            cmd.ExecuteNonQuery();
                            SqlCommand cmdget = new SqlCommand("select i, docname, doctype from doc where id = @prev_id", con1);
                            cmdget.Parameters.AddWithValue("@prev_id", this.id);
                            Tuple<string, string, string> req = new Tuple<string, string, string>("","","");
                            using (SqlDataReader reader = cmdget.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    req = new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                                }
                            }
                            
                            cmd = new SqlCommand("update doc Set id = @id, docpath = @dpath where i = @i", con1);
                            cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd.Parameters.AddWithValue("@i", req.Item1);
                            cmd.Parameters.AddWithValue("@dpath", defaultPath + "\\" + idTextbox.Text + "\\" + req.Item3 + "\\" + req.Item2);
                            cmd.ExecuteNonQuery();
                            System.IO.Directory.Move(defaultPath + "\\" + this.id, defaultPath + "\\" + idTextbox.Text);
                            
                        }
                        con1.Close();

                        FMessegeBox.FarsiMessegeBox.Show("متقاضی با موفقیت ویرایش شد", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);

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
            SqlCommand cmdchecksupport = new SqlCommand("select count(*) as sup from applicant where id = @sup and id = supporter_id", con);
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
                FMessegeBox.FarsiMessegeBox.Show("متقاضی سرپرست خود است!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select name, family from applicant where id = @sup", con);
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
            var newform = new searchForm("متقاضی");
            newform.ShowDialog(this);
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

        private void identifierNameTextBox_Click(object sender, EventArgs e)
        {
            identifierNameTextBox.BackColor = SystemColors.Window;
        }

        private void identifierPhoneTextBox_Click(object sender, EventArgs e)
        {
            identifierPhoneTextBox.BackColor = SystemColors.Window;
        }

        private void reqAddFileButton_Click(object sender, EventArgs e)
        {
            var newform = new doceditForm("ویرایش فرم تقاضا", this.id, "req", nameTextbox.Text, familyTextbox.Text, "");
            newform.ShowDialog(this);
            if (int.Parse(newform.Text) == 0)
                reqLabel.BackColor = Color.Red;
            else
                reqLabel.BackColor = Color.YellowGreen;
        }

        private void otherSupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            otherSupTextBox.Visible = otherSupCheckBox.Checked;
        }

        private void supporterTextbox_TextChanged(object sender, EventArgs e)
        {
            checkSupporterButton.Enabled = !string.IsNullOrEmpty(supporterTextbox.Text);
            reqAddFileButton.Enabled = identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            
            if (!(supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text)))
            {
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
                reqLabel.BackColor = Color.YellowGreen;
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            reqAddFileButton.Enabled = identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            if (!(supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text)))
            {
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
                reqLabel.BackColor = Color.YellowGreen;
            }
            
        }
        private void otherSupTextBox_Click(object sender, EventArgs e)
        {
            otherSupTextBox.BackColor = SystemColors.Window;
        }

        private void annualCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox2.Checked = (annualCheckBox2.Checked && !annualCheckBox1.Checked);
        }
        private void annualCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            annualCheckBox1.Checked = (annualCheckBox1.Checked && !annualCheckBox2.Checked);
        }

        private void editApplicantForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(reqLabel.BackColor == Color.Red)
            {
                FMessegeBox.FarsiMessegeBox.Show("بدون افزودن فرم تقاضا نمی‌توانید ویرایش متقاضی را رها نمایید!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                e.Cancel = true;
            }
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
    }
}
