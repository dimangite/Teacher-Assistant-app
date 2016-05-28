using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace StudentManagementSystem
{
    public class ReportDB
    {


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int stdId;

        public int StdId
        {
            get { return stdId; }
            set { stdId = value; }
        }
        private string stdName;

        public string StdName
        {
            get { return stdName; }
            set { stdName = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private int quiz;

        public int Quiz
        {
            get { return quiz; }
            set { quiz = value; }
        }
        private int homework;

        public int Homework
        {
            get { return homework; }
            set { homework = value; }
        }
        private int assignment;

        public int Assignment
        {
            get { return assignment; }
            set { assignment = value; }
        }
        private double attendance;

        public double Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }
        private int midterm;

        public int Midterm
        {
            get { return midterm; }
            set { midterm = value; }
        }
        private int final;

        public int Final
        {
            get { return final; }
            set { final = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        private int subUserId;

        public int SubUserId
        {
            get { return subUserId; }
            set { subUserId = value; }
        }
        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public static int GetSubId(string name)
        {
            int subId = 0;

            string query = "SELECT subId FROM subject WHERE subName=@subName";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Parameters.AddWithValue("@subName", name);
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subId = Int16.Parse(reader["subId"].ToString());
            }
            reader.Close();
            return subId;
        }

        public static int GetSubUserId()
        {
            // get subUserId from subUser
            int subUserId = 0;
            string querySubUserId = "SELECT subUserId FROM subjectuser WHERE userId=@userId AND subId= @subId";
            MySqlCommand cmdSubUserId = new MySqlCommand(querySubUserId, Database.connection);
            cmdSubUserId.Parameters.AddWithValue("@userId", User.UserId);
            cmdSubUserId.Parameters.AddWithValue("@subId", GetSubId(Home.ClassName));
            cmdSubUserId.Prepare();
            MySqlDataReader readerSubUserId = cmdSubUserId.ExecuteReader();
            while (readerSubUserId.Read())
            {
                subUserId = Int16.Parse(readerSubUserId["subUserId"].ToString());
            }
            readerSubUserId.Close();
            return subUserId;
        }
        public static string controlNULL(string n)
        {
            if (string.IsNullOrEmpty(n))
            {
                return "0";
            }
            else return n;
        }

        public static List<ReportDB> GetAllStudentScore()
        {
            List<ReportDB> score = new List<ReportDB>();
            int subUserId = GetSubUserId();
            try
            {
                string query = "SELECT s.stdId,s.name,s.gender,sc.scoreId, sc.quiz, sc.homework,sc.atdScore, sc.assignment, sc.midterm,sc.final FROM score sc INNER JOIN student s ON s.stdId= sc.stdId WHERE s.subUserId= @subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", subUserId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReportDB p = new ReportDB();
                    //p.scoreId = Int16.Parse(controlNULL(reader["scoreId"].ToString()));
                    p.StdId = Int16.Parse(reader["stdId"].ToString());
                    p.StdName = reader["name"].ToString();
                    p.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    p.Quiz = Int16.Parse(controlNULL(reader["quiz"].ToString()));
                    p.Homework = Int16.Parse(controlNULL(reader["homework"].ToString()));
                    p.Assignment = Int16.Parse(controlNULL(reader["assignment"].ToString()));
                    p.Attendance = Double.Parse(controlNULL(reader["atdScore"].ToString()));
                    p.Midterm = Int16.Parse(controlNULL(reader["midterm"].ToString()));
                    p.Final = Int16.Parse(controlNULL(reader["final"].ToString()));
                    //p.Total = p.Quiz + p.Homework + p.Midterm + p.Assignment + p.Final;
                    score.Add(p);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return score;
        }
    }
}
