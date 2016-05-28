using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class SC_Edit : Form
    {
        StudentScoreDB myScore = new StudentScoreDB();
        public SC_Edit()
        {
            InitializeComponent();
            
        }
        private void SC_List_Load(object sender, EventArgs e)
        {
            Database.Open();
            myScore = StudentScoreDB.getSelected(SC_List.ScoreId);
            //StudentScoreDB.EditLoad();
            lbName.Text = myScore.stdName;
            txtHomework.Text = myScore.Homework.ToString();
            txtQuiz.Text = myScore.Quiz.ToString();
            txtAssignment.Text = myScore.Assignment.ToString();
            txtMidterm.Text = myScore.Midterm.ToString();
            //txtAttendent.Text = "0";
            txtFinal.Text = myScore.Final.ToString();
            ChangeLanguage();
        }
        public void btnCencel_Click(object sender, EventArgs e)
        {
            (this.Owner as StudentScore).btnList_Click(sender, e);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentScoreDB sc = new StudentScoreDB();
            try {
                sc.scoreId = myScore.scoreId;
                sc.Homework = Int16.Parse(txtHomework.Text);
                sc.Quiz = Int16.Parse(txtQuiz.Text);
                sc.Assignment = Int16.Parse(txtAssignment.Text);
                sc.Midterm = Int16.Parse(txtMidterm.Text);
                sc.Final = Int16.Parse(txtFinal.Text);
                StudentScoreDB.Update(sc);
                (this.Owner as StudentScore).btnList_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all score", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void SC_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///
            txtHomework.MaxLength = 3;
            txtQuiz.MaxLength = 3;
            txtAssignment.MaxLength = 3;
            txtMidterm.MaxLength = 3;
            //txtAttendent.MaxLength = 3;
            txtFinal.MaxLength = 3;
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void SC_Edit_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
        private void ChangeLanguage()
        {
            if((this.Owner as StudentScore).btnList.Text == "បញ្ជីឈ្មោះសិស្ស")
            {
                lbStudentName.Font = new Font("Khmer Os Bokor",16, FontStyle.Regular);
                lbHw.Font = new Font("khmer os Bokor", 13, FontStyle.Regular);
                lbAss.Font = new Font("khmer os Bokor", 13, FontStyle.Regular);
                lbStudentName.Text = "ឈ្មោះ  : ";
                lbHw.Text = "កិច្ចការផ្ទះ";
                lbAss.Text = "កិច្ចការស្រាវជ្រាវ";
                btnUpdate.Font = new Font("khmer os Bokor", 14, FontStyle.Regular);
                btnUpdate.Text = "កែប្រែ";
                btnCencel.Font = new Font("khmer os Bokor", 14, FontStyle.Regular);
                btnCencel.Text = "បោះបង់";
            }
        }
    }
}
