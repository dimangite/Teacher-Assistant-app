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
    public partial class ClassSettting : Form
    {
        public ClassSettting()
        {
            InitializeComponent();
        }
        List<Class> c = new List<Class>();

        private void ClassSettting_Load(object sender, EventArgs e)
        {
            Database.Open();
            //ChangeLanguages();
            LoadClass();
        }

        public void LoadClass()
        {
            c = Class.GetAllClasses();
            dataGridViewClass.Rows.Clear();
            foreach (Class s in c)
            {
                dataGridViewClass.Rows.Add(s.subUserId, s.ClassName, s.StartDate ,s.Year, s.Semester,s.SessionNumber);
            }

        }

        public void LoadEdit(int id)
        {
            Class c = new Class();
            c = Class.GetSelected(id);
            label3.Text = c.subUserId.ToString();
            txtClassName.Text = c.ClassName;
            txtSession.Text = c.SessionNumber.ToString();
            dateTimePickerStartDate.Text = c.StartDate.ToShortDateString();
            comboBoxYear.Text = c.Year.ToString();
            comboBoxSemseter.Text = c.Semester.ToString();
        }

        private void ClassSettting_Leave(object sender, EventArgs e)
        {
            Database.Close();
            
        }
        public int rowIndex;
        private void dataGridViewClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewClass.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewClass.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            rowIndex = Int16.Parse(dataGridViewClass.SelectedCells[0].Value.ToString());
            LoadEdit(rowIndex);
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Class c = new Class();
            c.subUserId = Int16.Parse(label3.Text);
            c.ClassName = txtClassName.Text;
            c.Semester = Int16.Parse(comboBoxSemseter.Text);
            c.SessionNumber = Int16.Parse(txtSession.Text);
            c.StartDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            c.Year = Int16.Parse(comboBoxYear.Text);
            Class.Update(c);
            LoadClass();
            btnUpdate.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete: Class" +txtClassName.Text , "Delete Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            Class.Delete(Int16.Parse(label3.Text));
            InitInfo();
            LoadClass();
            }

        }
        public void InitInfo()
        {
            label3.Text = "0";
            txtClassName.Text = "";
            txtSession.Text = "";
            dateTimePickerStartDate.Text = "";
            comboBoxYear.Text = "";
            comboBoxSemseter.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnClass_Click(sender, e);
            this.Close();
        }
        private void ChangeLanguages()
        {
            if(Home.btnOption == "កំណត់")
            {
                btnClose.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);
                btnDelete.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                btnUpdate.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                dataGridViewClass.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbAcademic.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbName.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbNSession.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbStartDate.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbYear.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular); 
                lbSemester.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbClass.Font = new Font("Khmer OS Bokor", 18, FontStyle.Regular);

                dataGridViewClass.Columns[0].HeaderText = "ល.រ";
                dataGridViewClass.Columns[1].HeaderText = "ថ្នាក់ឈ្មោះ";
                dataGridViewClass.Columns[2].HeaderText = "កាវិភាគ";
                dataGridViewClass.Columns[3].HeaderText = "ឆ្នាំ";
                dataGridViewClass.Columns[4].HeaderText = "ឆមាស";
                dataGridViewClass.Columns[5].HeaderText = "ចំនួនមេរៀន";

                btnClose.Text = "បោះបង់";
                btnDelete.Text = "លុប";
                btnUpdate.Text = "រក្សាទុក";

                lbClass.Text = "ការកំណត់ ថ្នាក់";
                lbName.Text = "ថ្នាក់ឈ្នោះ";
                lbStartDate.Text = "កាវិភាគចូលរៀន";
                lbAcademic.Text = "កម្រិត";
                lbYear.Text = "ឆ្នាំ";
                lbSemester.Text = "ឆមាស";
                lbNSession.Text = "ចំនួនមេរៀន";



            }

        }

        private void lbClass_TextChanged(object sender, EventArgs e)
        {
            if (lbClass.Text == "ការកំណត់ ថ្នាក់")
                lbClass.Top = PnCS.Size.Height / 2 - 25;
        }
    }
}
