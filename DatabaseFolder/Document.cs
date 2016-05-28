using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace StudentManagementSystem
{
    public class Document
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
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int session;

        public int Session
        {
            get { return session; }
            set { session = value; }
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

        public static List<Document> getAllDocument()
        {
            List<Document> note = new List<Document>();
            string query = "SELECT * FROM document WHERE subUserId= @subUserId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Document n = new Document();
                n.Id = Int16.Parse(reader["docId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Path = reader["path"].ToString();
                note.Add(n);
            }
            reader.Close();
            return note;
        }

        public static void Insert(Document n)
        {
            string query = "INSERT INTO document(subUserId, title, session, date, path ) VALUES(@subUserId, @title, @session, @date, @path)";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@title", n.Title);
            cmd.Parameters.AddWithValue("@session", n.Session);
            cmd.Parameters.AddWithValue("@date", n.Date);
            cmd.Parameters.AddWithValue("@path", n.Path);
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            cmd.ExecuteNonQuery();

        }

        public static void Update(Document n)
        {
            string query = "UPDATE document SET title= @title, session=@session, date=@date, path=@path WHERE docId= @docId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@title", n.Title);
            cmd.Parameters.AddWithValue("@session", n.Session);
            cmd.Parameters.AddWithValue("@date", n.Date);
            cmd.Parameters.AddWithValue("@path", n.Path);
            cmd.Parameters.AddWithValue("@docId", n.Id);

            cmd.ExecuteNonQuery();
        }

        public static void Delect(int id)
        {
            string query = "DELETE FROM document WHERE docId= @docId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@docId", id);
            cmd.ExecuteNonQuery();
        }
        public static Document GetSelected(int id)
        {
            Document n = new Document();
            string query = "SELECT * FROM document WHERE subUserId= @subUserId AND docId= @id";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                n.Id = Int16.Parse(reader["docId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Path = reader["path"].ToString();
            }
            reader.Close();
            return n;
        }

        public static List<Document> Search (string Keyword)
        {
            List<Document> note = new List<Document>();
            string query = "SELECT * FROM document WHERE subUserId= @subUserId AND (title like '" + Keyword + "%' or docId like '" + Keyword + "%' )";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Document n = new Document();
                n.Id = Int16.Parse(reader["docId"].ToString());
                n.Title = reader["title"].ToString();
                n.Session = Int16.Parse(reader["session"].ToString());
                n.Date = Convert.ToDateTime(reader["date"].ToString());
                n.Path = reader["path"].ToString();
                note.Add(n);
            }
            reader.Close();
            return note;
        }
    }
}
