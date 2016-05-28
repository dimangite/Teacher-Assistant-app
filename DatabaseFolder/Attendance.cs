using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public class Attendance
    {
        private int atdId;

        public int AtdId
        {
            get { return atdId; }
            set { atdId = value; }
        }
        private int stdId;

        public int StdId
        {
            get { return stdId; }
            set { stdId = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private bool isAtd;

        public bool IsAtd
        {
            get { return isAtd; }
            set { isAtd = value; }
        }
        private int session;

        public int Session
        {
            get { return session; }
            set { session = value; }
        }

        private string stdName;

        public string StdName
        {
            get { return stdName; }
            set { stdName = value; }
        }

        private string atd;

        public string Atd
        {
            get { return atd; }
            set { atd = value;}
        }
        private double atdScore;

        public double AtdScore
        {
            get { return atdScore; }
            set { atdScore = value; }
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

        public static List<Attendance> GetAllAttendances()
        {
            List<Attendance> attendance = new List<Attendance>();

            try
            {
                string query = "SELECT s.name, s.gender, s.stdId ,a.session, a.attendance, a.id, sc.atdScore FROM attendance a INNER JOIN student s ON s.stdId= a.stdId INNER JOIN score sc ON s.stdId= sc.stdId WHERE a.subUserId=@subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Attendance s = new Attendance();
                    s.AtdId = Int16.Parse(reader["id"].ToString());
                    s.Session = Int16.Parse(reader["session"].ToString());
                    s.StdId = Int16.Parse(reader["stdId"].ToString());
                    s.AtdScore = Double.Parse(reader["atdScore"].ToString());
                    s.StdName = reader["name"].ToString();
                    s.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    s.Atd = reader["attendance"].ToString();
                    attendance.Add(s);
                }
                reader.Close();
            }
            catch(Exception ex){ MessageBox.Show(ex.ToString()); }
            return attendance;

        }        
        //----------------------------------------------------------------------------------------------------------------

        public static int NumberSession()
        {
            int s=0;
            string query = "SELECT sessionNumber FROM subjectUser WHERE subUserId= @id";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = Int16.Parse(reader["sessionNumber"].ToString());
            }
            reader.Close();
            return s;
        }

        public static void AssignAttendance(Attendance s)
        {
            string query= "UPDATE attendance SET attendance= @attendace WHERE id= @atdId; UPDATE score SET atdScore= @scoreAtd WHERE stdId= @stdId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@attendace", s.Atd);
            cmd.Parameters.AddWithValue("@atdId", s.AtdId);
            cmd.Parameters.AddWithValue("@scoreAtd", ToAtdScore(s.Atd));
            cmd.Parameters.AddWithValue("@stdId", s.StdId);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        public static double ToAtdScore(string a)
        {
            int number = Attendance.NumberSession();
            double result=0;
            string[] b = a.Split('-');
            //MessageBox.Show(b.Length.ToString());
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == "E" || string.IsNullOrEmpty(b[i].ToString()))
                {
                    result += 1;
                }
                else if (b[i] == "A")
                {
                    result += 0;
                }
                else if (b[i]=="P")
                {
                    result += 0.5;
                }
                else result += 0.75;
            }
            return result*(100/number);
        }

        public static List<Attendance> Search(string KeyWord)
        {
            List<Attendance> attendance = new List<Attendance>();

            try
            {
                string query = "SELECT s.name, s.gender, s.stdId ,a.session, a.attendance, a.id, sc.atdScore FROM attendance a INNER JOIN student s ON s.stdId= a.stdId INNER JOIN score sc ON s.stdId= sc.stdId WHERE a.subUserId=@subUserId AND (s.name like '" + KeyWord + "%' or s.stdId like '" + KeyWord + "%' )";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Attendance s = new Attendance();
                    s.AtdId = Int16.Parse(reader["id"].ToString());
                    s.Session = Int16.Parse(reader["session"].ToString());
                    s.StdId = Int16.Parse(reader["stdId"].ToString());
                    s.AtdScore = Double.Parse(reader["atdScore"].ToString());
                    s.StdName = reader["name"].ToString();
                    s.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    s.Atd = reader["attendance"].ToString();
                    attendance.Add(s);
                }
                reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return attendance;
        }

    }//end class Attendance
}//end StudentMangementSystem
