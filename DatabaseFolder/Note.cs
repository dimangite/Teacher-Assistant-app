using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace StudentManagementSystem
{
    public class Note
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private int session;

        public int Session
        {
            get { return session; }
            set { session = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string detail;

        public string Detail
        {
            get { return detail; }
            set { detail = value; }
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

        public static List<Note> getAllNote()
        {
            List<Note> note = new List<Note>();
            string query = "SELECT * FROM note WHERE subUserId= @subUserId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Note n = new Note();
                n.Id = Int16.Parse(reader["noteId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Detail = reader["detail"].ToString();
                note.Add(n);
            }
            reader.Close();
            return note;
        }

        public static void Insert(Note n)
        {
            string query = "INSERT INTO note(subUserId, title, session, date, detail ) VALUES(@subUserId, @title, @session, @date, @detail)";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@title", n.Title);
            cmd.Parameters.AddWithValue("@session", n.Session);
            cmd.Parameters.AddWithValue("@date", n.Date);
            cmd.Parameters.AddWithValue("@detail", n.Detail);
            cmd.Parameters.AddWithValue("@subUserId",GetSubUserId());
            cmd.ExecuteNonQuery();

        }

        public static void Update(Note n)
        {
            string query = "UPDATE note SET title= @title, session=@session, date=@date, detail=@detail WHERE noteId= @noteId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@title", n.Title);
            cmd.Parameters.AddWithValue("@session", n.Session);
            cmd.Parameters.AddWithValue("@date", n.Date);
            cmd.Parameters.AddWithValue("@detail", n.Detail);
            cmd.Parameters.AddWithValue("@noteId", n.Id);

            cmd.ExecuteNonQuery();
        }

        public static void Delect(int id)
        {
            string query = "DELETE FROM note WHERE noteId= @noteId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@noteId", id);
            cmd.ExecuteNonQuery();
        }

        public static Note GetSelected(int id)
        {
            Note n = new Note();
            string query = "SELECT * FROM note WHERE subUserId= @subUserId and NoteId=@id";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
             
                n.Id = Int16.Parse(reader["noteId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Detail = reader["detail"].ToString();
            }
            reader.Close();
            return n;
        }

        public static List<Note> Search(string Keyword)
        {
            List<Note> note = new List<Note>();
            string query = "SELECT * FROM note WHERE subUserId= @subUserId AND (title like '" + Keyword + "%' or noteId like '" + Keyword + "%' )";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Note n = new Note();
                n.Id = Int16.Parse(reader["noteId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Detail = reader["detail"].ToString();
                note.Add(n);
            }
            reader.Close();
            return note;
        }
    }
}
