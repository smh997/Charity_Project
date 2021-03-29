using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public static class ExtensionFunction
    {
        
        public static void EnableContextMenu(this RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                // Create a ContextMenuStrip without icons
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;

                // 1. Add the Undo option
                ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
                tsmiUndo.Click += (sender, e) => rtb.Undo();
                cms.Items.Add(tsmiUndo);

                // 2. Add the Redo option
                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
                tsmiRedo.Click += (sender, e) => rtb.Redo();
                cms.Items.Add(tsmiRedo);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 3. Add the Cut option (cuts the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);

                // 4. Add the Copy option (copies the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);

                // 5. Add the Paste option (adds the text from the clipboard into the richtextbox)
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(tsmiPaste);

                // 6. Add the Delete Option (remove the selected text in the richtextbox)
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
                cms.Items.Add(tsmiDelete);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 7. Add the Select All Option (selects all the text inside the richtextbox)
                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
                cms.Items.Add(tsmiSelectAll);
                
                // When opening the menu, check if the condition is fulfilled 
                // in order to enable the action
                cms.Opening += (sender, e) =>
                {
                    tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                    tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                    tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiCopy.Enabled = rtb.SelectionLength > 0;
                    tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                    tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                };

                rtb.ContextMenuStrip = cms;
            }
        }
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }
        public static bool IsValidEmail(this TextBoxBase txt)
        {
            return Regex.IsMatch(txt.Text.Trim(), @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                && Regex.IsMatch(txt.Text.Trim(), @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }

        public static int GetValue(this ComboBox Combo)
        {
            return Convert.ToInt32(Combo.SelectedValue);
        }

        public static int ConvertInt32(this TextBoxBase txt)
        {
           return txt.Text.Trim() == "" ? 0 : Convert.ToInt32(txt.Text.Trim());
        }
        public static long ConvertInt64(this TextBoxBase txt)
        {
            return txt.Text.Trim() == "" ? 0 : Convert.ToInt64(txt.Text.Trim());
        }
        public static short ConvertInt16(this TextBoxBase txt)
        {
            return txt.Text.Trim() == "" ? (short)0 : Convert.ToInt16(txt.Text.Trim());
        }

        public static string ToPersian(this DateTime dt)
        {
            PersianCalendar _persian = new PersianCalendar();
            string _year = _persian.GetYear(dt).ToString();
            string _month = _persian.GetMonth(dt).ToString();
            string _day = _persian.GetDayOfMonth(dt).ToString();
            if (_month.Length == 1)
                _month = "0" + _month;
            if (_day.Length == 1)
                _day = "0" + _day;
            return _year + "/" + _month + "/" + _day;
        }
        public static string GetPersianDetial(this DateTime dt)
        {
            PersianCalendar _persian = new PersianCalendar();
            int day = _persian.GetDayOfMonth(dt);
            int Month = _persian.GetMonth(dt);
            int year = _persian.GetYear(dt);

            string str = " امروز ";
            DayOfWeek d = _persian.GetDayOfWeek(dt);
            switch (d)
            {
                case DayOfWeek.Friday:
                    { str += " جمعه "; break; }
                case DayOfWeek.Monday:
                    { str += " دوشنبه "; break; }
                case DayOfWeek.Saturday:
                    { str += " شنبه "; break; }
                case DayOfWeek.Sunday:
                    { str += " یکشنبه "; break; }
                case DayOfWeek.Thursday:
                    { str += " پنج شنبه "; break; }
                case DayOfWeek.Tuesday:
                    { str += " سه شنبه "; break; }
                case DayOfWeek.Wednesday:
                    { str += " چهار شنبه "; break; }
            }
            str += day;
            switch (Month)
            {
                case 1: { str += " فروردین ماه "; ;break; }
                case 2: { str += " اردیبهشت ماه "; ;break; }
                case 3: { str += " خرداد ماه "; ;break; }
                case 4: { str += " تیر ماه "; ;break; }
                case 5: { str += " مرداد ماه "; ;break; }
                case 6: { str += " شهریور ماه "; ;break; }
                case 7: { str += " مهر ماه "; ;break; }
                case 8: { str += " آبان ماه "; ;break; }
                case 9: { str += " آذر ماه "; ;break; }
                case 10: { str += " دی ماه "; ;break; }
                case 11: { str += " بهمن ماه "; ;break; }
                case 12: { str += " اسفند ماه "; ;break; }
            }
            str += " سال " + year;
            return str;
        }
        public static string PersianToEnglish(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            };
            foreach (var item in persianStr)
            {
                if(LettersDictionary.ContainsKey(item))
                    persianStr = persianStr.Replace(item, LettersDictionary[item]);
            }
            return persianStr;
        }
        public static string EnglishToPersian(this string englishStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['0'] = '۰',
                ['1'] = '۱',
                ['2'] = '۲',
                ['3'] = '۳',
                ['4'] = '۴',
                ['5'] = '۵',
                ['6'] = '۶',
                ['7'] = '۷',
                ['8'] = '۸',
                ['9'] = '۹'
            };
            foreach (var item in englishStr)
            {
                if (LettersDictionary.ContainsKey(item))
                    englishStr = englishStr.Replace(item, LettersDictionary[item]);
            }
            return englishStr;
        }
    }
}
