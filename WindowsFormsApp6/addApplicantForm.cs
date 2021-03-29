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
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class addApplicantForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string defaultPath = "C:\\Users\\hashemi\\Desktop\\Kheirie warehouse\\applicant";
        string req;
        public addApplicantForm()
        {
            InitializeComponent();
        }

        private void addApplicantForm_Load(object sender, EventArgs e)
        {
            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            workComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            healthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            houseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            marryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            insComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            otherInsTextbox.Visible = otherSupTextBox.Visible = false;
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

        private void addressTextBox_Click(object sender, EventArgs e)
        {
            addressTextBox.BackColor = SystemColors.Window;
        }

        private void otherInsTextbox_Click(object sender, EventArgs e)
        {
            otherInsTextbox.BackColor = SystemColors.Window;
        }

        private void otherSupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            otherSupTextBox.Visible = otherSupCheckBox.Checked;
        }

        private void otherSupTextBox_Click(object sender, EventArgs e)
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

        private void supporterTextbox_TextChanged(object sender, EventArgs e)
        {
            checkSupporterButton.Enabled = !string.IsNullOrEmpty(supporterTextbox.Text);
            reqAddFileButton.Enabled = identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            
            if ((!string.IsNullOrEmpty(supporterTextbox.Text) && !string.IsNullOrEmpty(supporterTextbox.Text)) && (supporterTextbox.Text != idTextbox.Text))
            {
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                reqLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                reqLabel.BackColor = Color.Red;
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            reqAddFileButton.Enabled = identifierNameTextBox.Enabled = identifierPhoneTextBox.Enabled = workComboBox.Enabled = houseComboBox.Enabled = insComboBox.Enabled = annualGroupBox.Enabled = otherSupCheckBox.Enabled = (supporterTextbox.Text == idTextbox.Text && !string.IsNullOrEmpty(supporterTextbox.Text));
            if ((!string.IsNullOrEmpty(supporterTextbox.Text) && !string.IsNullOrEmpty(supporterTextbox.Text)) && (supporterTextbox.Text != idTextbox.Text))
            {
                annualCheckBox1.Checked = annualCheckBox2.Checked = otherSupCheckBox.Checked = false;
                workComboBox.SelectedIndex = houseComboBox.SelectedIndex = insComboBox.SelectedIndex = -1;
                reqLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                reqLabel.BackColor = Color.Red;
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

        private void addButton_Click(object sender, EventArgs e)
        {

            SqlConnection con1 = new SqlConnection(this.connection);
            con1.Open();

            if (nameTextbox.TextLength == 0 || familyTextbox.TextLength == 0 || fathernameTextbox.TextLength == 0 || idTextbox.TextLength == 0 || supporterTextbox.TextLength == 0 || homephoneTextBox.TextLength == 0 || cellphoneTextBox.TextLength == 0 || addressTextBox.TextLength == 0 ||
                    (sexComboBox.Text.Length == 0) || (workComboBox.Enabled && workComboBox.Text.Length == 0) || (healthComboBox.Text.Length == 0) || (houseComboBox.Enabled && houseComboBox.Text.Length == 0) || (otherSupCheckBox.Checked && otherSupTextBox.Text.Length == 0) || (marryComboBox.Text.Length == 0) || (insComboBox.Enabled && (insComboBox.Text.Length == 0 || (insComboBox.Text == "سایر" && otherInsTextbox.TextLength == 0))) || (identifierNameTextBox.Enabled && identifierNameTextBox.TextLength == 0) || (identifierPhoneTextBox.Enabled && identifierPhoneTextBox.TextLength == 0))
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
                FMessegeBox.FarsiMessegeBox.Show("مشخصات وارد شده ناقص است", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                if (check == 1)
                {
                    idTextbox.BackColor = Color.Tomato;
                    FMessegeBox.FarsiMessegeBox.Show("متقاضی با این شماره ملی وجود دارد", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                }
                else
                {
                    var myregex = new Regex(@"^[ آاأإؤيبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیة]+$");

                    if (nameTextbox.Text.Any(char.IsDigit) || !myregex.IsMatch(nameTextbox.Text))
                    {
                        nameTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (familyTextbox.Text.Any(char.IsDigit) || !myregex.IsMatch(familyTextbox.Text))
                    {
                        familyTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام خانوادگی باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (fathernameTextbox.Text.Any(char.IsDigit) || !myregex.IsMatch(fathernameTextbox.Text))
                    {
                        fathernameTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام پدر باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (insComboBox.Text == "سایر" && (otherInsTextbox.Text.Any(char.IsDigit) || !myregex.IsMatch(otherInsTextbox.Text)))
                    {
                        otherInsTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام بیمه باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
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
                    if (otherSupCheckBox.Checked && (otherSupTextBox.Text.Any(char.IsDigit) || !myregex.IsMatch(otherSupTextBox.Text)))
                    {
                        otherSupTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام موسسه تحت پوشش باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (identifierNameTextBox.Enabled && (identifierNameTextBox.Text.Any(char.IsDigit) || !myregex.IsMatch(identifierNameTextBox.Text)))
                    {
                        identifierNameTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("نام معرف باید شامل حروف و بدون هیچ عدد و کاراکتر خاصی باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    if (identifierPhoneTextBox.Enabled && (!identifierPhoneTextBox.Text.All(char.IsDigit) || identifierPhoneTextBox.Text.Any(char.IsWhiteSpace) || identifierPhoneTextBox.Text.Length != 11))
                    {
                        identifierPhoneTextBox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره تلفن معرف باید شامل 11 رقم عدد و بدون هیچ فاصله‌ای باشد!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        con1.Close();
                        return;
                    }
                    SqlCommand cmdchecksup2, cmdchecksupport = new SqlCommand("select count(*) as sup from applicant where id = @sup and id = supporter_id", con1);
                    cmdchecksup2 = new SqlCommand("select count(*) as sup from member where id = @sup and id = supporter_id", con1);
                    cmdchecksupport.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                    cmdchecksup2.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                    int sup = 0, sup2 = 0;
                    using (SqlDataReader reader = cmdchecksupport.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    using (SqlDataReader reader = cmdchecksup2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sup2 = int.Parse(String.Format("{0}", reader["sup"]));
                        }
                    }
                    if (sup == 0 && sup2 == 0 && idTextbox.Text != supporterTextbox.Text)
                    {
                        supporterTextbox.BackColor = Color.Tomato;
                        FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در سیستم موجود نیست و یا این شماره مربوط به هیچ سرپرست خانواری نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
                    }
                    else
                    {

                        DialogResult resu = FMessegeBox.FarsiMessegeBox.Show("آیا نسبت به ثبت این متقاضی مطمئن هستید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
                        if (resu != DialogResult.Yes)
                        {
                            con1.Close();
                            return;
                        }
                        SqlCommand cmd = new SqlCommand("insert into applicant(name, family, fatherName, id, supporter_id, sex, job, house, birthdate, subdate, health, annual, otherSup, seyed, car, marriage, homephone, cellphone, address, explain, orphan, student, insurance, identifierName, identifierPhone)" +
                        " Values(@name, @family, @fatherName, @id, @supporter_id, @sex, @job, @house, @birthdate, @subdate, @health, @annual, @otherSup, @seyed, @car, @marriage, @homephone, @cellphone, @address, @explain, @orphan, @student, @ins, @iName, @iPhone)", con1);
                        cmd.Parameters.AddWithValue("@name", nameTextbox.Text);
                        cmd.Parameters.AddWithValue("@family", familyTextbox.Text);
                        cmd.Parameters.AddWithValue("@fatherName", fathernameTextbox.Text);
                        cmd.Parameters.AddWithValue("@id", idTextbox.Text);
                        cmd.Parameters.AddWithValue("@supporter_id", supporterTextbox.Text);
                        cmd.Parameters.AddWithValue("@homephone", homephoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@cellphone", cellphoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@explain", explainTextBox.Text + "(اضافه شدن متقاضی مددجویی در تاریخ " + DateTime.Now.Date.ToPersian() + ")");
                        cmd.Parameters.AddWithValue("@birthdate", birthdateTimePickerX.SelectedDateInDateTime.Date);
                        cmd.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@sex", sexComboBox.Text);
                        cmd.Parameters.AddWithValue("@health", healthComboBox.Text);
                        cmd.Parameters.AddWithValue("@marriage", marryComboBox.Text);
                        if (workComboBox.Enabled)
                        {
                            cmd.Parameters.AddWithValue("@job", workComboBox.Text);
                            cmd.Parameters.AddWithValue("@house", houseComboBox.Text);
                            if(insComboBox.Text == "سایر")
                            {
                                cmd.Parameters.AddWithValue("@ins", otherInsTextbox.Text);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ins", insComboBox.Text);
                            }
                            
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
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text);
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "req");
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "req" + "\\enter");
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "research");
                            string fileName = System.IO.Path.GetFileName(req);
                            string targetPath = defaultPath + "\\" + idTextbox.Text + "\\req\\enter\\";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(req, destFile, false);
                            SqlCommand cmd2 = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                            cmd2.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd2.Parameters.AddWithValue("@dname", fileName);
                            cmd2.Parameters.AddWithValue("@dpath", destFile);
                            cmd2.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd2.Parameters.AddWithValue("@dtype", "req");
                            cmd2.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmdgetsupinfo;
                            if(sup!=0)
                                cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup, identifierName, identifierPhone from applicant where id = @sup;", con1);
                            else
                                cmdgetsupinfo = new SqlCommand("select job, house, insurance, annual, otherSup, identifierName, identifierPhone from member where id = @sup;", con1);
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
                            SqlCommand cmdgetreq = new SqlCommand("select docpath from doc where id = @sup and doctype = 'req';", con1);
                            cmdgetreq.Parameters.AddWithValue("@sup", supporterTextbox.Text);
                            using (SqlDataReader reader = cmdgetreq.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    req = reader.GetString(0);
                                }
                            }
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text);
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "req");
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "req" + "\\enter");
                            System.IO.Directory.CreateDirectory(defaultPath + "\\" + idTextbox.Text + "\\" + "research");
                            string fileName = System.IO.Path.GetFileName(req);
                            string targetPath = defaultPath + "\\" + idTextbox.Text + "\\req\\enter\\";
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(req, destFile, false);
                            SqlCommand cmd2 = new SqlCommand("insert into doc(id, docname, docpath, subdate, doctype) Values(@id, @dname, @dpath, @subdate, @dtype);", con1);
                            cmd2.Parameters.AddWithValue("@id", idTextbox.Text);
                            cmd2.Parameters.AddWithValue("@dname", fileName);
                            cmd2.Parameters.AddWithValue("@dpath", destFile);
                            cmd2.Parameters.AddWithValue("@subdate", DateTime.Now.Date);
                            cmd2.Parameters.AddWithValue("@dtype", "req");
                            cmd2.ExecuteNonQuery();
                        }
                        if (seyedCheckBox.Checked)
                            cmd.Parameters.AddWithValue("@seyed", "بله");
                        else
                            cmd.Parameters.AddWithValue("@seyed", "خیر");
                        if (carCheckBox.Checked)
                            cmd.Parameters.AddWithValue("@car", "دارد");
                        else
                            cmd.Parameters.AddWithValue("@car", "ندارد");
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
                        
                        FMessegeBox.FarsiMessegeBox.Show("متقاضی با موفقیت ثبت شد!", "تبریک!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Information, FMessegeBox.FMessegeBoxDefaultButton.button1);

                        idTextbox.Text = "";
                        nameTextbox.Text = "";
                        familyTextbox.Text = "";
                        fathernameTextbox.Text = "";
                        supporterTextbox.Text = "";
                        homephoneTextBox.Text = "";
                        cellphoneTextBox.Text = "";
                        addressTextBox.Text = "";
                        explainTextBox.Text = "";
                        otherInsTextbox.Text = "";
                        otherSupTextBox.Text = "";
                        identifierNameTextBox.Text = identifierPhoneTextBox.Text = "";
                        birthdateTimePickerX.SelectedDateInDateTime = DateTime.Now;
                        sexComboBox.SelectedIndex = -1;
                        workComboBox.SelectedIndex = -1;
                        healthComboBox.SelectedIndex = -1;
                        houseComboBox.SelectedIndex = -1; ;
                        marryComboBox.SelectedIndex = -1;
                        insComboBox.SelectedIndex = -1;
                        orphanCheckBox.Checked = studentCheckBox.Checked = otherSupCheckBox.Checked = annualCheckBox1.Checked = annualCheckBox2.Checked = carCheckBox.Checked = seyedCheckBox.Checked = false;
                        reqLabel.BackColor = Color.Red;
                        req = "";
                    }

                }
            }
            con1.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var newform = new searchForm("متقاضی");
            newform.ShowDialog(this);
        }

        private void checkSupporterButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            SqlCommand cmdchecksup2, cmdchecksupport = new SqlCommand("select count(*) as sup from applicant where id = @sup and id = supporter_id", con);
            cmdchecksup2 = new SqlCommand("select count(*) as sup from member where id = @sup and id = supporter_id", con);
            cmdchecksupport.Parameters.AddWithValue("@sup", supporterTextbox.Text);
            cmdchecksup2.Parameters.AddWithValue("@sup", supporterTextbox.Text);
            int sup = 0, sup2 = 0;
            using (SqlDataReader reader = cmdchecksupport.ExecuteReader())
            {
                if (reader.Read())
                {
                    sup = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            using (SqlDataReader reader = cmdchecksup2.ExecuteReader())
            {
                if (reader.Read())
                {
                    sup2 = int.Parse(String.Format("{0}", reader["sup"]));
                }
            }
            if (sup == 0 && sup2 == 0 && idTextbox.Text != supporterTextbox.Text)
            {
                FMessegeBox.FarsiMessegeBox.Show("شماره ملی سرپرست در سیستم موجود نیست و یا این شماره مربوط به هیچ سرپرست خانواری نیست!", "خطا!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else if (idTextbox.Text == supporterTextbox.Text)
            {
                FMessegeBox.FarsiMessegeBox.Show("متقاضی سرپرست خود است!", "توجه!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
            }
            else
            {
                SqlCommand cmd;
                if(sup != 0)
                    cmd = new SqlCommand("select name, family from applicant where id = @sup and id = supporter_id", con);
                else
                    cmd = new SqlCommand("select name, family from member where id = @sup and id = supporter_id", con);
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

        private void reqAddFileButton_Click(object sender, EventArgs e)
        {
            addOpenFileDialog.Title = "انتخاب فرم تقاضا";
            addOpenFileDialog.FileName = "*.pdf";
            if (addOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                req = addOpenFileDialog.FileName;
                reqLabel.BackColor = Color.YellowGreen;
            }
            else
            {
                addOpenFileDialog.FileName = "*.pdf";
            }
        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if(nameTextbox.Text.Length != 0 && myreg.IsMatch(nameTextbox.Text.Substring(nameTextbox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                nameTextbox.Text = nameTextbox.Text.Substring(0, nameTextbox.Text.Length - 1);
            }
            /*
             * var myregex = new Regex(@"^[ آاأإؤي بپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$");
            if (nameTextbox.Text.Length==0 || myregex.IsMatch(nameTextbox.Text))
            {
                
            }
            else
            {
                
            }
            */
        }

        private void familyTextbox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (familyTextbox.Text.Length != 0 && myreg.IsMatch(familyTextbox.Text.Substring(familyTextbox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                familyTextbox.Text = familyTextbox.Text.Substring(0, familyTextbox.Text.Length - 1);
            }
        }

        private void fathernameTextbox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (fathernameTextbox.Text.Length != 0 && myreg.IsMatch(fathernameTextbox.Text.Substring(fathernameTextbox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                fathernameTextbox.Text = fathernameTextbox.Text.Substring(0, fathernameTextbox.Text.Length - 1);
            }
        }

        private void identifierNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (identifierNameTextBox.Text.Length != 0 && myreg.IsMatch(identifierNameTextBox.Text.Substring(identifierNameTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                identifierNameTextBox.Text = identifierNameTextBox.Text.Substring(0, identifierNameTextBox.Text.Length - 1);
            }
        }

        private void otherInsTextbox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (otherInsTextbox.Text.Length != 0 && myreg.IsMatch(otherInsTextbox.Text.Substring(otherInsTextbox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                otherInsTextbox.Text = otherInsTextbox.Text.Substring(0, otherInsTextbox.Text.Length - 1);
            }
        }

        private void otherSupTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (otherSupTextBox.Text.Length != 0 && myreg.IsMatch(otherSupTextBox.Text.Substring(otherSupTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                otherSupTextBox.Text = otherSupTextBox.Text.Substring(0, otherSupTextBox.Text.Length - 1);
            }
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            var myreg = new Regex("^[a-zA-Z]*$");
            if (addressTextBox.Text.Length != 0 && myreg.IsMatch(addressTextBox.Text.Substring(addressTextBox.Text.Length - 1)))
            {
                FMessegeBox.FarsiMessegeBox.Show("صفحه کلید خود را فارسی نمایید!", "اخطار!", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Exclamtion, FMessegeBox.FMessegeBoxDefaultButton.button1);
                addressTextBox.Text = addressTextBox.Text.Substring(0, addressTextBox.Text.Length - 1);
            }
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

        private void birthdateTimePickerX_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            if (birthdateTimePickerX.SelectedDateInDateTime > DateTime.Now.Date)
            {
                birthdateTimePickerX.SelectedDateInDateTime = DateTime.Now.Date;
            }
            if (birthdateTimePickerX.SelectedDateInDateTime.Subtract(DateTime.Now).TotalDays > 25 * 365 + 6)
            {
                orphanCheckBox.Enabled = false;
                orphanCheckBox.Checked = false;
            }
            else
            {
                orphanCheckBox.Enabled = true;
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
