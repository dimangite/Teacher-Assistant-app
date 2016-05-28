using StudentManagementSystem;
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
    public partial class NewClass : Form
    {
        public static bool state= false;
        public static string ClassName;
        public int PosX;
        public int PosY;
        public NewClass(int x, int y)
        {
            InitializeComponent();
            PosX = x;
            PosY = y;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1) m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Database.Close();
            this.Close();
            state = false;
        }

        private void btnNewClass_Click(object sender, EventArgs e)
        {
            //1.verify all input (textbox, combobox, and datetimepicker)
            if (String.IsNullOrEmpty(txtClassName.Text) || string.IsNullOrEmpty(comboBoxSemseter.Text) || string.IsNullOrEmpty(comboBoxYear.Text) || string.IsNullOrEmpty(tbSession.Text))
            {
                MessageBox.Show("Please input class info", "Erorr Adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClassName.Focus();
                return;
            }

            //2.insert to table student in the database
            Class s = new Class();
            s.ClassName = txtClassName.Text.Trim();
            s.Year = Int16.Parse(comboBoxYear.Text.Trim());
            s.Semester = Int16.Parse(comboBoxSemseter.Text.Trim());
            s.StartDate = dateTimePickerStartDate.Value;
            s.SessionNumber = Int16.Parse(tbSession.Text.Trim());
           
            Class.Insert(s);
            state = true;
            this.Close();
            ClassName = s.ClassName;
        }

        private void NewClass_Load(object sender, EventArgs e)
        {
            Database.Open();
            ChangeLanguages();
            txtClassName.Focus();
        }
        private void ChangeLanguages()
        {
            if((this.Owner as Home).btnNewClass.Text == "បន្ថែមថ្នាក់")
            {
                btnCancel.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);
                btnNewClass.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                lbAcademic.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbName.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbNSession.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbSD.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbYear.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbSemester.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbCreateClass.Font = new Font("Khmer OS Bokor", 18, FontStyle.Regular);

                btnCancel.Text = "បោះបង់";
                btnNewClass.Text = "រក្សាទុក";

                lbCreateClass.Text = "ការបង្កើត ថ្នាក់";
                lbName.Text = "ថ្នាក់ឈ្នោះ";
                lbSD.Text = "កាវិភាគចូលរៀន";
                lbAcademic.Text = "កម្រិត";
                lbYear.Text = "ឆ្នាំ";
                lbSemester.Text = "ឆមាស";
                lbNSession.Text = "ចំនួនមេរៀន";

            }
        }

        private void lbCreateClass_TextChanged(object sender, EventArgs e)
        {
            if (lbCreateClass.Text == "ការបង្កើត ថ្នាក់")
                lbCreateClass.Top = panel1.Size.Height / 2 - 25;
        }

        private void tbSession_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
