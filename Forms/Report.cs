using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        StudentScoreDB P = new StudentScoreDB(); // Percetage

        private void Report_Load(object sender, EventArgs e)
        {
            Database.Open();
            this.reportViewer1.RefreshReport();
            List<ReportDB> r = new List<ReportDB>();
            r = ReportDB.GetAllStudentScore();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("StdId", typeof(int));
            table.Columns.Add("StdName", typeof(string));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Attendance", typeof(double));
            table.Columns.Add("Quiz", typeof(int));
            table.Columns.Add("Homework", typeof(int));
            table.Columns.Add("Assignment", typeof(int));
            table.Columns.Add("Midterm", typeof(int));
            table.Columns.Add("Final", typeof(int));
            table.Columns.Add("Total", typeof(int));
            int j = 1;

            P = StudentScoreDB.Setting();

            foreach (ReportDB i in r)
            {
                DataRow row = table.NewRow();
                row[0] = j++;
                row[1] = i.StdId;
                row[2] = i.StdName;
                row[3] = GenderConvert(i.Gender);
                row[4] = i.Attendance;
                row[5] = i.Quiz;
                row[6] = i.Homework;
                row[7] = i.Assignment;
                row[8] = i.Midterm;
                row[9] = i.Final;
                row[10] = ((i.Quiz * P.QuizPct) + (i.Homework * P.HomeWorkPct) + (i.Attendance * P.AssignmentPct) + (i.Assignment * P.AssignmentPct) + (i.Midterm * P.MidtermPct) + (i.Final * P.FinalPct)) / 100; 
       
                table.Rows.Add(row);
            }
            
            ReportDataSource dataSource = new ReportDataSource("DataReport", table);

            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            List<ReportParameter> para = new List<ReportParameter>();
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            para.Add(new ReportParameter("TodayDate", date));
            para.Add(new ReportParameter("subject", Home.ClassName));
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            this.reportViewer1.SetPageSettings(ps);
            this.reportViewer1.RefreshReport();
        }
        public string GenderConvert(bool s)
        {
            if (s)
            {
                return "ប";
            }
            else return "ស";
        }

        private void Report_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
    }
}
