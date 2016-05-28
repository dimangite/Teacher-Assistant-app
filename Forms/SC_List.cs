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
using MySql.Data;

namespace StudentManagementSystem
{
    public partial class SC_List : Form
    {
        List<StudentScoreDB> score;
        StudentScoreDB P = new StudentScoreDB(); // Percetage

        public static int ScoreId = 0;
        public SC_List()
        {
            InitializeComponent();
            ttSearch.SetToolTip(btnSearch, "Search");
            
        }
        private void SC_List_Load(object sender, EventArgs e)
        {
            Database.Open(); 
            LoadScore();
            ChangeLanguage();
        }

        public void LoadScore()
        {
            score = StudentScoreDB.GetAllScores();
            P = StudentScoreDB.Setting();
            double Total = 0;
            string gender;
            StudentScoreList.Rows.Clear();
            foreach (StudentScoreDB s in score)
            {
                if (s.gender == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                Total = ((s.Quiz * P.QuizPct) + (s.Homework * P.HomeWorkPct) + (s.Attendance * P.AssignmentPct) + (s.Assignment * P.AssignmentPct) + (s.Midterm * P.MidtermPct) + (s.Final * P.FinalPct)) / 100;
                StudentScoreList.Rows.Add(s.scoreId, s.stdId, s.stdName, gender, s.Quiz, s.Homework, s.Attendance, s.Assignment, s.Midterm, s.Final, Total);
            }
   
        }
        private void StudentScoreList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            StudentScoreList.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            StudentScoreList.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            ScoreId = Int16.Parse(StudentScoreList.SelectedCells[0].Value.ToString());
            ///Send Value of ID to Form SC_Edit to Edit Score////////////////////////////////
            if (ScoreId > 0)
            {
                //StudentScoreDB.GetID = ScoreId;
                (this.Owner as StudentScore).btnEdit.Enabled = true;
               // (this.Owner as StudentScore).btnDelete.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            StudentScoreList.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            StudentScoreList.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            if (!(string.IsNullOrEmpty(txtSearch.Text)))
            {
                LoadSearch(txtSearch.Text);
            }
            else LoadScore();
        }

        public void LoadSearch(string keyword)
        {

            score = StudentScoreDB.Search(keyword);
            P = StudentScoreDB.Setting();
            int Total = 0;
            string gender;
            StudentScoreList.Rows.Clear();
            foreach (StudentScoreDB s in score)
            {
                if (s.gender == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                Total = ((s.Quiz * P.QuizPct) + (s.Homework * P.HomeWorkPct) + (s.Assignment * P.AssignmentPct) + (s.Midterm * P.MidtermPct) + (s.Final * P.FinalPct)) / 100;
                StudentScoreList.Rows.Add(s.scoreId, s.stdId, s.stdName, gender, s.Quiz, s.Homework, s.Assignment, s.Midterm, s.Final, Total);
            }
        }
        private void ChangeLanguage()
        {
             if ((this.Owner as StudentScore).btnList.Text == "បញ្ជីឈ្មោះសិស្ស")
             {
                StudentScoreList.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                StudentScoreList.Columns[1].HeaderText = "ល.រ";
                StudentScoreList.Columns[2].HeaderText = "ឈ្មោះ";
                StudentScoreList.Columns[3].HeaderText = "ភេទ";
                StudentScoreList.Columns[5].HeaderText = "កិច្ចការផ្ទះ";
                StudentScoreList.Columns[7].HeaderText = "កិច្ចការស្រាវជ្រាវ";
                StudentScoreList.Columns[6].HeaderText = "វត្តមាន";
                StudentScoreList.Columns[10].HeaderText = "ពិន្ទុសរុប";
                
            }
        }

        private void SC_List_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
    }
}
