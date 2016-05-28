using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
namespace StudentManagementSystem
{
    public class User
    {
        public int Id;
        public string Name;
        public bool Gender;
        public string Phone;
        public string Username;
        public string Password;
        public bool Role;
        private string photoPath;

        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                if (value == null) photoPath = @"Resources\icon-user-default.png";
                else photoPath = value;
            }
        }
        private Image photo;

        public Image Photo
        {
            get { return photo; }
            set {
                if (value == null) photo = Image.FromFile(@"Resources\icon-user-default.png");
                else photo = value; }
        }
        private static int userId;

        public static int UserId
        {
            get { return User.userId; }
            set {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    User.userId= 0;
                }
                else User.userId = value; }
        }

        public static Image PhotoByteToImage(Byte[] b)
        {
            Image im;
            MemoryStream ms = new MemoryStream(b);
            im = Image.FromStream(ms);
            return im;
        }

        public static User LoginWithUsername (string username)
        {
            User u = null;
            try
            {
                string query = "SELECT * FROM user where username = @username";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare(); // prepare the cmd
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Int16.Parse(reader["userId"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.PhotoPath = reader["photoPath"].ToString();
                    user.Name = reader["name"].ToString();
                    user.Photo = PhotoByteToImage((byte[])reader["photo"]);
                    user.Role = Boolean.Parse(reader["role"].ToString());
                    userId = user.Id;
                    u = user;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return u;
        }

        public static User LoginWithPassword(string password)
        {
            User user = null;
            string query = "SELECT * FROM user where  password= @password";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);

            cmd.Prepare(); // prepare the cmd
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User();
                user.Id = Int16.Parse(reader["id"].ToString());
                user.Password = reader["password"].ToString();
                user.Username = reader["username"].ToString();
                //user.Role = reader["role"].ToString();
            }
            reader.Close();

            return user;
        }

        public static Byte[] ImageToByte(Image I)
        {
            Byte[] b;
            MemoryStream ms = new MemoryStream();
            I.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            b = ms.ToArray();
            return b;
        }

        public static void SignUp(User u)
        {
            try
            {
                string query = "INSERT INTO user(username, password, name, gender,photo, photoPath) VALUES(@username,@password,@name, @gender,@photo,@photoPath)";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@name", u.Name);
                cmd.Parameters.AddWithValue("@gender", u.Gender);
                //convert p.photo to byte[]
                cmd.Parameters.AddWithValue("@photo", ImageToByte(u.Photo));
                cmd.Parameters.AddWithValue("@PhotoPath", u.PhotoPath);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            // sign up success
            
        }

        public static List<User> GetAllUser()
        {
            List<User> result = new List<User>();
            try
            {
                string query = "SELECT * FROM User";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User u = new User();
                    u.Id = Int16.Parse(reader["userId"].ToString());
                    u.Password = reader["password"].ToString();
                    u.Username = reader["username"].ToString();
                    u.Gender = Boolean.Parse(reader["gender"].ToString());
                    u.Name = reader["name"].ToString();
                    u.Role = Boolean.Parse(reader["role"].ToString());
                    result.Add(u);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public static User GetSelected(int id)
        {
            User u = new User();
            try
            {
                string query = "SELECT * FROM User WHERE userId= @userId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@userId", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = Int16.Parse(reader["userId"].ToString());
                    u.Password = reader["password"].ToString();
                    u.Username = reader["username"].ToString();
                    u.Gender = Boolean.Parse(reader["gender"].ToString());
                    u.Name = reader["name"].ToString();
                    u.Role = Boolean.Parse(reader["role"].ToString());
                    u.PhotoPath = reader["photoPath"].ToString();
                    u.Photo = PhotoByteToImage((byte[])reader["photo"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return u;
        }

        public static void Update(User u)
        {
            try
            {
                string query = "UPDATE user SET username= @username, password= @password, name= @name, gender= @gender,role=@role, photo= @photo, photoPath=@photoPath WHERE userId=@userId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@name", u.Name);
                cmd.Parameters.AddWithValue("@gender", u.Gender);
                cmd.Parameters.AddWithValue("@role", u.Role);
                cmd.Parameters.AddWithValue("@photo", ImageToByte(u.Photo));
                cmd.Parameters.AddWithValue("@PhotoPath", u.PhotoPath);
                cmd.Parameters.AddWithValue("@userId", u.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public static void Delete(int id)
        {
            string query = "DELETE FROM user WHERE userId=@userId; ";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.ExecuteNonQuery();

            // delete from all the reveal with subUserId

            string query1 = "SELECT subUserId FROM subjectUser WHERE userId= @userId";
            MySqlCommand cmd1 = new MySqlCommand(query1, Database.connection);
            cmd1.Prepare();
            cmd1.Parameters.AddWithValue("@userId", id);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                int subUserId = Int16.Parse(reader1["subUserId"].ToString());
                Class.Delete(subUserId);
            }
            reader1.Close();
        }
    }
}
