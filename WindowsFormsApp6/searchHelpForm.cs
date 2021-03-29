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
    public partial class searchHelpForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        bool rad = false;
        public searchHelpForm(string p)
        {
            InitializeComponent();
            idTextbox.EnableContextMenu();
            idTextbox.SelectionAlignment = HorizontalAlignment.Center;
            this.Text = p;
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            setButton.Enabled = !string.IsNullOrEmpty(idTextbox.Text) && !string.IsNullOrWhiteSpace(idTextbox.Text);
        }

        private void idTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && setButton.Enabled)
            {
                setButton.PerformClick();
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            
            if (this.Text == "ویرایش کمک جمعی با مصوبه")
            {
                var newform = new globalHelpEnactmentForm("ویرایش کمک جمعی با مصوبه", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش کمک جمعی اتفاقی")
            {
                var newform = new globalHelpsSuddenForm("ویرایش کمک جمعی اتفاقی", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک جمعی")
            {
                var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if(this.Text == "ویرایش فایل‌های ارائه کمک جمعی")
            {
                var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش ارائه کمک جمعی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک جمعی")
            {
                var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "تایید کمک جمعی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک جمعی")
            {
                var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک جمعی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش کمک تحصیلی")
            {
                var newform = new studyHelpForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش کمک تحصیلی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک تحصیلی")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from StudyHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                if(type == "معرفی‌نامه")
                {
                    var newform = new helpPresentationEduIntroductionForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                    newform.ShowDialog(this);
                }
                else
                {
                    var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ارائه کمک تحصیلی");
                    newform.ShowDialog(this);
                }
            }
            else if (this.Text == "ویرایش فایل‌های ارائه کمک تحصیلی")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from StudyHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                if (type == "معرفی‌نامه")
                {
                    var newform = new helpPresentationEduIntroductionForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش فایل‌های معرفی‌نامه تحصیلی");
                    newform.ShowDialog(this);
                }
                else
                {
                    var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش ارائه کمک تحصیلی");
                    newform.ShowDialog(this);
                }
            }
            else if (this.Text == "تایید کمک تحصیلی")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from StudyHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                if (type == "معرفی‌نامه")
                {
                    var newform = new helpPresentationEduIntroductionForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "تایید معرفی‌نامه تحصیلی");
                    newform.ShowDialog(this);
                }
                else
                {
                    var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "تایید کمک تحصیلی");
                    newform.ShowDialog(this);
                }
                    
            }
            else if (this.Text == "ویرایش تایید کمک تحصیلی")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from StudyHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                if (type == "معرفی‌نامه")
                {
                    var newform = new helpPresentationEduIntroductionForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید معرفی‌نامه تحصیلی");
                    newform.ShowDialog(this);
                }
                else
                {
                    var newform = new helpPresentationForm3(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک تحصیلی");
                    newform.ShowDialog(this);
                }
            }
            else if (this.Text == "ثبت درخواست کمک ازدواج")
            {
                var newform = new marryHelpReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if(this.Text == "ویرایش درخواست کمک ازدواج")
            {
                var newform = new marryHelpReqForm("", "ویرایش درخواست کمک ازدواج", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک ازدواج")
            {
                var newform = new marryHelpCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک ازدواج تاییدشده")
            {
                var newform = new marryHelpCheckReqForm("", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک ازدواج ردشده")
            {
                var newform = new marryHelpCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "", "رد");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارسال معرفی‌نامه جهیزیه")
            {
                var newform = new marrySendIntroForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش ارسال معرفی‌نامه جهیزیه")
            {
                var newform = new marrySendIntroForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), this.Text);
                newform.ShowDialog(this);
            }
            else if (this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                var newform = new marryResForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش نتیجه معرفی‌نامه جهیزیه")
            {
                if (rad)
                {
                    var newform = new marryResForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), this.Text, "رد");
                    newform.ShowDialog(this);
                }
                else
                {
                    var newform = new marryResForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), this.Text);
                    newform.ShowDialog(this);
                }
            }
            else if (this.Text == "ارائه کمک ازدواج")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from MarryHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                var newform = new marryHelpPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), type);
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش‌ ارائه کمک ازدواج")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from MarryHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                var newform = new marryHelpPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), type, "ویرایش ارائه کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک ازدواج")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from MarryHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                var newform = new marryHelpConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), type);
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک ازدواج")
            {
                string type = "";
                SqlCommand cmd = new SqlCommand("select type from MarryHelps where id = @id;", con);
                cmd.Parameters.AddWithValue("@id", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
                var newform = new marryHelpConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), type, "ویرایش تایید کمک ازدواج");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ثبت درخواست کمک درمان")
            {
                var newform = new healHelpReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش درخواست کمک درمان")
            {
                var newform = new healHelpReqForm("", "ویرایش درخواست کمک درمان", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                var newform = new healHelpCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک درمان تاییدشده")
            {
                var newform = new healHelpCheckReqForm("", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک درمان ردشده")
            {
                var newform = new healHelpCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "", "رد");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک درمان")
            {
                var newform = new healHelpPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش‌ ارائه کمک درمان")
            {
                var newform = new healHelpPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش ارائه کمک درمان");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک درمان")
            {
                var newform = new healHelpConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک درمان")
            {
                var newform = new healHelpConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک درمان");
                newform.ShowDialog(this);
            }
            if (this.Text == "ویرایش کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalForm("ویرایش کمک متفرقه گروهی", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش فایل‌های ارائه کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش ارائه کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه گروهی")
            {
                var newform = new otherHelpGlobalPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ثبت درخواست کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش درخواست کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivReqForm("", "ویرایش درخواست کمک متفرقه فردی", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک متفرقه فردی تاییدشده")
            {
                var newform = new otherHelpIndivCheckReqForm("", ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک متفرقه فردی ردشده")
            {
                var newform = new otherHelpIndivCheckReqForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "", "رد");
                newform.ShowDialog(this);
            }
            else if (this.Text == "ارائه کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش‌ ارائه کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivPresentForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش ارائه کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            else if (this.Text == "تایید کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text));
                newform.ShowDialog(this);
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه فردی")
            {
                var newform = new otherHelpIndivConfirmForm(ExtensionFunction.PersianToEnglish(idTextbox.Text), "ویرایش تایید کمک متفرقه فردی");
                newform.ShowDialog(this);
            }
            con.Close();
            idTextbox.Text = "";
            setButton.Enabled = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(this.Text == "ویرایش کمک جمعی با مصوبه")
            {
                var newform = new searchForm("ویرایش کمک جمعی با مصوبه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            } 
            else if(this.Text == "ویرایش کمک جمعی اتفاقی")
            {
                var newform = new searchForm("ویرایش کمک جمعی اتفاقی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ارائه کمک جمعی")
            {
                var newform = new searchForm("ارائه کمک جمعی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if(this.Text == "ویرایش فایل‌های ارائه کمک جمعی")
            {
                var newform = new searchForm("ویرایش فایل‌های ارائه کمک جمعی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک جمعی")
            {
                var newform = new searchForm("تایید کمک جمعی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک جمعی")
            {
                var newform = new searchForm("ویرایش تایید کمک جمعی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش کمک تحصیلی")
            {
                var newform = new searchForm("ویرایش کمک تحصیلی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if(this.Text == "ارائه کمک تحصیلی")
            {
                var newform = new searchForm("ارائه کمک تحصیلی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش فایل‌های ارائه کمک تحصیلی")
            {
                var newform = new searchForm("ویرایش فایل‌های ارائه کمک تحصیلی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک تحصیلی")
            {
                var newform = new searchForm("تایید کمک تحصیلی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک تحصیلی")
            {
                var newform = new searchForm("ویرایش تایید کمک تحصیلی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if(this.Text == "ثبت درخواست کمک ازدواج")
            {
                var newform = new searchForm("ثبت درخواست کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if(this.Text == "ویرایش درخواست کمک ازدواج")
            {
                var newform = new searchForm("ویرایش درخواست کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "بررسی درخواست کمک ازدواج")
            {
                var newform = new searchForm("بررسی درخواست کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک ازدواج تاییدشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک ازدواج ردشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک ازدواج ردشده");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ارسال معرفی‌نامه جهیزیه")
            {
                var newform = new searchForm("ارسال معرفی‌نامه جهیزیه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش ارسال معرفی‌نامه جهیزیه")
            {
                var newform = new searchForm("ویرایش ارسال معرفی‌نامه جهیزیه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                var newform = new searchForm("دریافت نتیجه معرفی‌نامه جهیزیه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش نتیجه معرفی‌نامه جهیزیه")
            {
                var newform = new searchForm("ویرایش نتیجه معرفی‌نامه جهیزیه");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
                else if (newform.Text.StartsWith("chooser"))
                {
                    rad = true;
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(8));
                }
            }
            else if (this.Text == "ارائه کمک ازدواج")
            {
                var newform = new searchForm("ارائه کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش‌ ارائه کمک ازدواج")
            {
                var newform = new searchForm("ویرایش‌ ارائه کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک ازدواج")
            {
                var newform = new searchForm("تایید کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک ازدواج")
            {
                var newform = new searchForm("ویرایش تایید کمک ازدواج");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ثبت درخواست کمک درمان")
            {
                var newform = new searchForm("ثبت درخواست کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش درخواست کمک درمان")
            {
                var newform = new searchForm("ویرایش درخواست کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "بررسی درخواست کمک درمان")
            {
                var newform = new searchForm("بررسی درخواست کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک درمان تاییدشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک درمان ردشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک درمان ردشده");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ارائه کمک درمان")
            {
                var newform = new searchForm("ارائه کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش‌ ارائه کمک درمان")
            {
                var newform = new searchForm("ویرایش‌ ارائه کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک درمان")
            {
                var newform = new searchForm("تایید کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک درمان")
            {
                var newform = new searchForm("ویرایش تایید کمک درمان");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش کمک متفرقه گروهی")
            {
                var newform = new searchForm("ویرایش کمک متفرقه گروهی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ارائه کمک متفرقه گروهی")
            {
                var newform = new searchForm("ارائه کمک متفرقه گروهی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش فایل‌های ارائه کمک متفرقه گروهی")
            {
                var newform = new searchForm("ویرایش فایل‌های ارائه کمک متفرقه گروهی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک متفرقه گروهی")
            {
                var newform = new searchForm("تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه گروهی")
            {
                var newform = new searchForm("ویرایش تایید کمک متفرقه گروهی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ثبت درخواست کمک متفرقه فردی")
            {
                var newform = new searchForm("ثبت درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش درخواست کمک متفرقه فردی")
            {
                var newform = new searchForm("ویرایش درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی")
            {
                var newform = new searchForm("بررسی درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک متفرقه فردی تاییدشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش بررسی درخواست کمک متفرقه فردی ردشده")
            {
                var newform = new searchForm("ویرایش بررسی درخواست کمک متفرقه فردی ردشده");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ارائه کمک متفرقه فردی")
            {
                var newform = new searchForm("ارائه کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش‌ ارائه کمک متفرقه فردی")
            {
                var newform = new searchForm("ویرایش‌ ارائه کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "تایید کمک متفرقه فردی")
            {
                var newform = new searchForm("تایید کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
            else if (this.Text == "ویرایش تایید کمک متفرقه فردی")
            {
                var newform = new searchForm("ویرایش تایید کمک متفرقه فردی");
                newform.ShowDialog(this);
                if (newform.Text.StartsWith("choose"))
                {
                    idTextbox.Text = ExtensionFunction.EnglishToPersian(newform.Text.Substring(6));
                }
            }
        }
        
        private void searchHelpForm_Load(object sender, EventArgs e)
        {
            if (this.Text == "ثبت درخواست کمک درمان" || this.Text == "بررسی درخواست کمک درمان" || this.Text == "ارائه کمک درمان" || this.Text == "تایید کمک درمان")
            {
                this.BackColor = Color.Gold;
            }
            else if (this.Text == "ثبت درخواست کمک متفرقه فردی")
            {
                this.BackColor = Color.LightCoral;
                editMemberLabel.Text = "شماره ملی عضو:";
            }
            else if (this.Text == "بررسی درخواست کمک متفرقه فردی" || this.Text == "ارائه کمک متفرقه گروهی" || this.Text == "تایید کمک متفرقه گروهی" || this.Text == "ارائه کمک متفرقه فردی" || this.Text == "تایید کمک متفرقه فردی")
            {
                this.BackColor = Color.LightCoral;
            }
            else if (this.Text == "ثبت درخواست کمک ازدواج" || this.Text == "بررسی درخواست کمک ازدواج" || this.Text == "ارائه کمک ازدواج" || this.Text == "تایید کمک ازدواج" || this.Text == "ارسال معرفی‌نامه جهیزیه" || this.Text == "دریافت نتیجه معرفی‌نامه جهیزیه")
            {
                this.BackColor = Color.MediumPurple;
            }
            else if (this.Text == "ارائه کمک تحصیلی" || this.Text == "تایید کمک تحصیلی")
            {
                this.BackColor = Color.Turquoise;
            }
            else if (this.Text == "ارائه کمک جمعی" || this.Text == "تایید کمک جمعی")
            {
                this.BackColor = Color.SkyBlue;
            }
        }
    }
}
