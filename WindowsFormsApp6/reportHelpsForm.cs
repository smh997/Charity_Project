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
    public partial class reportHelpsForm : Form
    {
        string connection = "Data Source=DESKTOP-S1F0LH1;Initial Catalog=kheirie;Integrated Security=True";
        string typ, id;
        public reportHelpsForm(string typ, string id)
        {
            InitializeComponent();
            this.typ = typ;
            this.Text += typ;
            this.id = id;
        }
        private void reportHelpsForm_Load(object sender, EventArgs e)
        {
            stuHelpExportButton2.Enabled = GhelpExportButton2.Enabled = healHelpExportButton2.Enabled = marryHelpExportButton2.Enabled = OGhelpExportButton2.Enabled = OIhelpExportButton2.Enabled = false;
            SqlConnection con = new SqlConnection(this.connection);
            con.Open();
            if (this.typ == "خانوار")
            {
                SqlCommand cmd2, cmdgetmembers; SqlDataAdapter da; DataTable dt;
                // Ghelp
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', GlobalHelps.id as 'شماره کمک', GlobalHelps.defType as 'نوع تعریف', GlobalHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(GlobalHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(GlobalHelps.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(GlobalHelps.enddate) as 'تاریخ پایان', cast(GlobalHelps.fee as decimal(15,0)) as 'ارزش ریالی', GlobalHelps.packets as 'تعداد بسته', GlobalHelps.metric as 'مبلغ معیار امتیاز', GlobalHelps.status as 'وضعیت', GlobalHelps.enactmentId as 'شماره مصوبه تعریف', GlobalHelps.fenactmentId as 'شماره مصوبه تایید', GlobalHelps.description as 'توضیحات' from GlobalHelps, receivedTableHelp where GlobalHelps.id = receivedTableHelp.gId and folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                GhelpDataGridView.DataSource = dt;
                GhelpDataGridView.Columns[GhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // marry
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', MarryHelps.id as 'شماره کمک', MarryHelps.reqId as 'شماره درخواست', MarryHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(MarryHelps.confirmdate) as 'تاریخ تایید', cast(MarryHelps.fee as decimal(15,0)) as 'ارزش ریالی', MarryHelps.status as 'وضعیت', MarryHelps.bankAccountName as 'نام حساب', MarryHelps.bankAccountId as 'شماره حساب', MarryHelps.enactmentId as 'شماره مصوبه تعریف', MarryHelps.fenactmentId as 'شماره مصوبه تایید', MarryHelps.description as 'توضیحات کمک', MarryHelps.introdescription as 'توضیحات ارسال معرفی‌نامه', resdescription as 'توضیحات دریافت نتیجه', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from MarryHelps, MarryHelpReq, member where MarryHelps.reqId = MarryHelpReq.id and MarryHelpReq.mId = member.id and member.folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                marryHelpDataGridView.DataSource = dt;
                marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 4].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // stu
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', StudyHelps.id as 'شماره کمک', StudyHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(StudyHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(StudyHelps.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(StudyHelps.enddate) as 'تاریخ پایان', StudyHelps.school as 'نام مدرسه', cast(StudyHelps.fee as decimal(15,0)) as 'ارزش ریالی', StudyHelps.number as 'تعداد', StudyHelps.status as 'وضعیت', StudyHelps.enactmentId as 'شماره مصوبه تعریف', StudyHelps.fenactmentId as 'شماره مصوبه تایید', StudyHelps.description as 'توضیحات کمک' from StudyHelps, StudyRecList where StudyHelps.id = StudyRecList.hId and folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                stuHelpDataGridView.DataSource = dt;
                stuHelpDataGridView.Columns[stuHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // heal
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', HealHelps.id as 'شماره کمک', HealHelps.reqId as 'شماره درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(HealHelps.confirmdate) as 'تاریخ تایید', cast(HealHelps.fee as decimal(15,0)) as 'ارزش ریالی', HealHelps.status as 'وضعیت', HealHelps.bankAccountName as 'نام حساب', HealHelps.bankAccountId as 'شماره حساب', HealHelps.enactmentId as 'شماره مصوبه تعریف', HealHelps.fenactmentId as 'شماره مصوبه تایید', HealHelps.description as 'توضیحات کمک', HealHelps.presdescription as 'توضیحات ارائه', HealHelps.confirmdescription as 'توضیحات تایید' from HealHelps, HealHelpReq, member where HealHelps.reqId = HealHelpReq.id and HealHelpReq.mId = member.id and member.folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                healHelpDataGridView.DataSource = dt;
                healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // OGhelp
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', OtherHelpsGlobal.id as 'شماره کمک', OtherHelpsGlobal.ctype as 'دریافت‌کنندگان', OtherHelpsGlobal.cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(OtherHelpsGlobal.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(OtherHelpsGlobal.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(OtherHelpsGlobal.enddate) as 'تاریخ پایان', cast(OtherHelpsGlobal.fee as decimal(15,0)) as 'ارزش ریالی', OtherHelpsGlobal.packets as 'تعداد بسته', OtherHelpsGlobal.metric as 'مبلغ معیار امتیاز', OtherHelpsGlobal.status as 'وضعیت', OtherHelpsGlobal.bankAccountName as 'نام حساب', OtherHelpsGlobal.bankAccountId as 'شماره حساب', OtherHelpsGlobal.enactmentId as 'شماره مصوبه تعریف', OtherHelpsGlobal.fenactmentId as 'شماره مصوبه تایید', OtherHelpsGlobal.description as 'توضیحات' from OtherHelpsGlobal, OtherHelpsGlobalRecList where OtherHelpsGlobal.id = OtherHelpsGlobalRecList.hId and folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                OGhelpDataGridView.DataSource = dt;
                OGhelpDataGridView.Columns[OGhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // OIhelp
                cmd2 = new SqlCommand("select @id as 'شماره پرونده', OtherHelpsIndiv.id as 'شماره کمک', OtherHelpsIndiv.reqId as 'شماره درخواست', OtherHelpsIndiv.cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(OtherHelpsIndiv.confirmdate) as 'تاریخ تایید', cast(OtherHelpsIndiv.fee as decimal(15,0)) as 'ارزش ریالی', OtherHelpsIndiv.status as 'وضعیت', OtherHelpsIndiv.bankAccountName as 'نام حساب', OtherHelpsIndiv.bankAccountId as 'شماره حساب', OtherHelpsIndiv.enactmentId as 'شماره مصوبه تعریف', OtherHelpsIndiv.fenactmentId as 'شماره مصوبه تایید', OtherHelpsIndiv.description as 'توضیحات کمک', OtherHelpsIndiv.presdescription as 'توضیحات ارائه', OtherHelpsIndiv.confirmdescription as 'توضیحات تایید' from OtherHelpsIndiv, OtherHelpIndivReq, member where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpIndivReq.mId = member.id and member.folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                OIhelpDataGridView.DataSource = dt;
                OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            else
            {
                SqlCommand cmd2, cmdgetmembers; SqlDataAdapter da; DataTable dt;
                // Ghelp
                cmd2 = new SqlCommand("select @id as 'شماره ملی', GlobalHelps.id as 'شماره کمک', GlobalHelps.defType as 'نوع تعریف', GlobalHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(GlobalHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(GlobalHelps.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(GlobalHelps.enddate) as 'تاریخ پایان', cast(GlobalHelps.fee as decimal(15,0)) as 'ارزش ریالی', GlobalHelps.packets as 'تعداد بسته', GlobalHelps.metric as 'مبلغ معیار امتیاز', GlobalHelps.status as 'وضعیت', GlobalHelps.enactmentId as 'شماره مصوبه تعریف', GlobalHelps.fenactmentId as 'شماره مصوبه تایید', GlobalHelps.description as 'توضیحات' from GlobalHelps, receivedTableHelp where GlobalHelps.id = receivedTableHelp.gId and folder_id = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                GhelpDataGridView.DataSource = dt;
                GhelpDataGridView.Columns[GhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // marry
                cmd2 = new SqlCommand("select @id as 'شماره ملی', MarryHelps.id as 'شماره کمک', MarryHelps.reqId as 'شماره درخواست', MarryHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(MarryHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(MarryHelps.senddate) as 'تاریخ ارسال معرفی‌نامه', dbo.MiladiTOShamsi(MarryHelps.recdate) as 'تاریخ دریافت نتیجه', dbo.MiladiTOShamsi(MarryHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(MarryHelps.confirmdate) as 'تاریخ تایید', cast(MarryHelps.fee as decimal(15,0)) as 'ارزش ریالی', MarryHelps.status as 'وضعیت', MarryHelps.bankAccountName as 'نام حساب', MarryHelps.bankAccountId as 'شماره حساب', MarryHelps.enactmentId as 'شماره مصوبه تعریف', MarryHelps.fenactmentId as 'شماره مصوبه تایید', MarryHelps.description as 'توضیحات کمک', MarryHelps.introdescription as 'توضیحات ارسال معرفی‌نامه', resdescription as 'توضیحات دریافت نتیجه', presdescription as 'توضیحات ارائه', confirmdescription as 'توضیحات تایید' from MarryHelps, MarryHelpReq where MarryHelps.reqId = MarryHelpReq.id and MarryHelpReq.mId = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                marryHelpDataGridView.DataSource = dt;
                marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 4].DefaultCellStyle.WrapMode = marryHelpDataGridView.Columns[marryHelpDataGridView.ColumnCount - 5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // stu
                cmd2 = new SqlCommand("select @id as 'شماره ملی', StudyHelps.id as 'شماره کمک', StudyHelps.type as 'نوع کمک', dbo.MiladiTOShamsi(StudyHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(StudyHelps.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(StudyHelps.enddate) as 'تاریخ پایان', StudyHelps.school as 'نام مدرسه', cast(StudyHelps.fee as decimal(15,0)) as 'ارزش ریالی', StudyHelps.number as 'تعداد', StudyHelps.status as 'وضعیت', StudyHelps.enactmentId as 'شماره مصوبه تعریف', StudyHelps.fenactmentId as 'شماره مصوبه تایید', StudyHelps.description as 'توضیحات کمک' from StudyHelps, StudyRecList where StudyHelps.id = StudyRecList.hId and stuId = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                stuHelpDataGridView.DataSource = dt;
                stuHelpDataGridView.Columns[stuHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // heal
                cmd2 = new SqlCommand("select @id as 'شماره ملی', HealHelps.id as 'شماره کمک', HealHelps.reqId as 'شماره درخواست', dbo.MiladiTOShamsi(HealHelps.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(HealHelps.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(HealHelps.confirmdate) as 'تاریخ تایید', cast(HealHelps.fee as decimal(15,0)) as 'ارزش ریالی', HealHelps.status as 'وضعیت', HealHelps.bankAccountName as 'نام حساب', HealHelps.bankAccountId as 'شماره حساب', HealHelps.enactmentId as 'شماره مصوبه تعریف', HealHelps.fenactmentId as 'شماره مصوبه تایید', HealHelps.description as 'توضیحات کمک', HealHelps.presdescription as 'توضیحات ارائه', HealHelps.confirmdescription as 'توضیحات تایید' from HealHelps, HealHelpReq, member where HealHelps.reqId = HealHelpReq.id and HealHelpReq.mId = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                healHelpDataGridView.DataSource = dt;
                healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = healHelpDataGridView.Columns[healHelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // OGhelp
                cmd2 = new SqlCommand("select @id as 'شماره ملی', OtherHelpsGlobal.id as 'شماره کمک', OtherHelpsGlobal.ctype as 'دریافت‌کنندگان', OtherHelpsGlobal.cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(OtherHelpsGlobal.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(OtherHelpsGlobal.startdate) as 'تاریخ شروع', dbo.MiladiTOShamsi(OtherHelpsGlobal.enddate) as 'تاریخ پایان', cast(OtherHelpsGlobal.fee as decimal(15,0)) as 'ارزش ریالی', OtherHelpsGlobal.packets as 'تعداد بسته', OtherHelpsGlobal.metric as 'مبلغ معیار امتیاز', OtherHelpsGlobal.status as 'وضعیت', OtherHelpsGlobal.bankAccountName as 'نام حساب', OtherHelpsGlobal.bankAccountId as 'شماره حساب', OtherHelpsGlobal.enactmentId as 'شماره مصوبه تعریف', OtherHelpsGlobal.fenactmentId as 'شماره مصوبه تایید', OtherHelpsGlobal.description as 'توضیحات' from OtherHelpsGlobal, OtherHelpsGlobalRecList where OtherHelpsGlobal.id = OtherHelpsGlobalRecList.hId and ((ctype = N'همه خانوارها' and folder_id = @id) or (ctype != N'همه خانوارها' and mId = @id));", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                OGhelpDataGridView.DataSource = dt;
                OGhelpDataGridView.Columns[OGhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // OIhelp
                cmd2 = new SqlCommand("select @id as 'شماره ملی', OtherHelpsIndiv.id as 'شماره کمک', OtherHelpsIndiv.reqId as 'شماره درخواست', OtherHelpsIndiv.cashtype as 'نوع پرداخت', dbo.MiladiTOShamsi(OtherHelpsIndiv.subdate) as 'تاریخ ثبت', dbo.MiladiTOShamsi(OtherHelpsIndiv.enddate) as 'تاریخ ارائه', dbo.MiladiTOShamsi(OtherHelpsIndiv.confirmdate) as 'تاریخ تایید', cast(OtherHelpsIndiv.fee as decimal(15,0)) as 'ارزش ریالی', OtherHelpsIndiv.status as 'وضعیت', OtherHelpsIndiv.bankAccountName as 'نام حساب', OtherHelpsIndiv.bankAccountId as 'شماره حساب', OtherHelpsIndiv.enactmentId as 'شماره مصوبه تعریف', OtherHelpsIndiv.fenactmentId as 'شماره مصوبه تایید', OtherHelpsIndiv.description as 'توضیحات کمک', OtherHelpsIndiv.presdescription as 'توضیحات ارائه', OtherHelpsIndiv.confirmdescription as 'توضیحات تایید' from OtherHelpsIndiv, OtherHelpIndivReq, member where OtherHelpsIndiv.reqId = OtherHelpIndivReq.id and OtherHelpIndivReq.mId = @id;", con);
                cmd2.Parameters.AddWithValue("@id", this.id);
                da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
                OIhelpDataGridView.DataSource = dt;
                OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 1].DefaultCellStyle.WrapMode = OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 2].DefaultCellStyle.WrapMode = OIhelpDataGridView.Columns[OIhelpDataGridView.ColumnCount - 3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            con.Close();
        }
        private void GhelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < GhelpDataGridView.Columns.Count+1; i++)
            {
                worksheet.Cells[1, i] = GhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < GhelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < GhelpDataGridView.Columns.Count; j++)
                {
                    if (GhelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(GhelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = GhelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void GhelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < GhelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = GhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < GhelpDataGridView.Columns.Count; j++)
            {
                if (GhelpDataGridView.Rows[GhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(GhelpDataGridView.Rows[GhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = GhelpDataGridView.Rows[GhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void GhelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeGlobalHelpsForm2(ExtensionFunction.PersianToEnglish(GhelpDataGridView.Rows[GhelpDataGridView.SelectedCells[0].RowIndex].Cells[GhelpDataGridView.SelectedCells[0].ColumnIndex+1].Value.ToString()));
            newform.ShowDialog(this);
        }

        private void marryHelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < marryHelpDataGridView.Columns.Count+1; i++)
            {
                worksheet.Cells[1, i] = marryHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < marryHelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < marryHelpDataGridView.Columns.Count; j++)
                {
                    if (marryHelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(marryHelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = marryHelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void marryHelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < marryHelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = marryHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < marryHelpDataGridView.Columns.Count; j++)
            {
                if (marryHelpDataGridView.Rows[marryHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(marryHelpDataGridView.Rows[marryHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = marryHelpDataGridView.Rows[marryHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void marryHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeMarryHelpsForm2(ExtensionFunction.PersianToEnglish(marryHelpDataGridView.Rows[marryHelpDataGridView.SelectedCells[0].RowIndex].Cells[marryHelpDataGridView.SelectedCells[0].ColumnIndex + 1].Value.ToString()));
            newform.ShowDialog(this);
        }

        private void stuHelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < stuHelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = stuHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < stuHelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < stuHelpDataGridView.Columns.Count; j++)
                {
                    if (stuHelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(stuHelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = stuHelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void stuHelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < stuHelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = stuHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < stuHelpDataGridView.Columns.Count; j++)
            {
                if (stuHelpDataGridView.Rows[stuHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(stuHelpDataGridView.Rows[stuHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = stuHelpDataGridView.Rows[stuHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void stuHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeStudyHelpsForm2(ExtensionFunction.PersianToEnglish(stuHelpDataGridView.Rows[stuHelpDataGridView.SelectedCells[0].RowIndex].Cells[stuHelpDataGridView.SelectedCells[0].ColumnIndex + 1].Value.ToString()));
            newform.ShowDialog(this);
        }

        private void healHelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < healHelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = healHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < healHelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < healHelpDataGridView.Columns.Count; j++)
                {
                    if (healHelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(healHelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = healHelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void healHelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < healHelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = healHelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < healHelpDataGridView.Columns.Count; j++)
            {
                if (healHelpDataGridView.Rows[healHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(healHelpDataGridView.Rows[healHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = healHelpDataGridView.Rows[healHelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void healHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeHealHelpsForm2(ExtensionFunction.PersianToEnglish(healHelpDataGridView.Rows[healHelpDataGridView.SelectedCells[0].RowIndex].Cells[healHelpDataGridView.SelectedCells[0].ColumnIndex + 1].Value.ToString()));
            newform.ShowDialog(this);
        }

        private void OGhelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < OGhelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = OGhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < OGhelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < OGhelpDataGridView.Columns.Count; j++)
                {
                    if (OGhelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(OGhelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = OGhelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void OGhelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < OGhelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = OGhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < OGhelpDataGridView.Columns.Count; j++)
            {
                if (OGhelpDataGridView.Rows[OGhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(OGhelpDataGridView.Rows[OGhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = OGhelpDataGridView.Rows[OGhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void OGhelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherHelpsGlobalForm2(ExtensionFunction.PersianToEnglish(OGhelpDataGridView.Rows[OGhelpDataGridView.SelectedCells[0].RowIndex].Cells[OGhelpDataGridView.SelectedCells[0].ColumnIndex + 1].Value.ToString()));
            newform.ShowDialog(this);
        }

        private void OIhelpExportButton_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < OIhelpDataGridView.Columns.Count+1; i++)
            {
                worksheet.Cells[1, i] = OIhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < OIhelpDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < OIhelpDataGridView.Columns.Count; j++)
                {
                    if (OIhelpDataGridView.Rows[i].Cells[j].Value.GetType().ToString() == "System.DateTime")
                    {
                        worksheet.Cells[i + 2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(OIhelpDataGridView.Rows[i].Cells[j].Value.ToString()));
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = OIhelpDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void OIhelpExportButton2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet  
            //worksheet.Name = "Exported from gridview";
            worksheet.DisplayRightToLeft = true;
            DialogResult res = FMessegeBox.FarsiMessegeBox.Show("نسبت به گرفتن خروجی اکسل اطمینان دارید؟", "پرسش", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question, FMessegeBox.FMessegeBoxDefaultButton.button1);
            if (res != DialogResult.Yes)
            {
                app.Quit();
                return;
            }
            for (int i = 1; i < OIhelpDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = OIhelpDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int j = 0; j < OIhelpDataGridView.Columns.Count; j++)
            {
                if (OIhelpDataGridView.Rows[OIhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.GetType().ToString() == "System.DateTime")
                {
                    worksheet.Cells[2, j + 1] = ExtensionFunction.ToPersian(Convert.ToDateTime(OIhelpDataGridView.Rows[OIhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString()));
                }
                else
                {
                    worksheet.Cells[2, j + 1] = OIhelpDataGridView.Rows[OIhelpDataGridView.SelectedCells[0].RowIndex].Cells[j].Value.ToString();
                }
            }
            // see the excel sheet behind the program  
            app.Visible = true;
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

        private void OIHelpButton_Click(object sender, EventArgs e)
        {
            var newform = new observeOtherIndivHelpsForm2(ExtensionFunction.PersianToEnglish(OIhelpDataGridView.Rows[OIhelpDataGridView.SelectedCells[0].RowIndex].Cells[OIhelpDataGridView.SelectedCells[0].ColumnIndex + 1].Value.ToString()));
            newform.ShowDialog(this);
        }
        
    }
}
