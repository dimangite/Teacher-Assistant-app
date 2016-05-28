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
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
        }
        List<User> user = new List<User>();
        private void EditUser_Load(object sender, EventArgs e)
        {
            Database.Open();
            LoadUser();
        }

        private void EditUser_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }

        public void LoadUser()
        {
            user = User.GetAllUser();
            dataGridViewUsers.Rows.Clear();
            foreach (User s in user)
            {
                dataGridViewUsers.Rows.Add(s.Id, s.Username, s.Password, s.Name, s.Gender, s.Role);
            }
        }

        public void LoadEdit(int id)
        {
            User c = new User();
            c = User.GetSelected(id);
            label3.Text = c.Id.ToString();
            txtFullName.Text = c.Name;
            if (c.Gender == true)
            {
                rdbMale.Checked = true;
            }
            else rdbFemale.Checked = true;
            txtUsername.Text = c.Username.ToString();
            txtPassword.Text = c.Password;
            
            cbRole.Text = c.Role.ToString();
            Picture.ImageLocation = c.PhotoPath;
        }

        public int rowIndex;
        private void dataGridViewClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewUsers.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewUsers.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            rowIndex = Int16.Parse(dataGridViewUsers.SelectedCells[0].Value.ToString());
            LoadEdit(rowIndex);
            //btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User c = new User();
            c.Id = Int16.Parse(label3.Text);
            c.Name = txtFullName.Text;
            if (rdbFemale.Checked == false)
            {
                c.Gender = true;
            }
            else c.Gender = false;
            c.Username = txtUsername.Text;
            c.Password = txtPassword.Text;
            c.PhotoPath = Picture.ImageLocation;
            c.Photo = Picture.Image;
            if (cbRole.Text != "TRUE")
            {
                c.Role = false;
            }
            else c.Role = true;
            User.Update(c);
            LoadUser();
            btnUpdate.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete: " + txtFullName.Text, "Delete Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                User.Delete(Int16.Parse(label3.Text));
                InitInfo();
                LoadUser();
            }

        }
        public void InitInfo()
        {
            label3.Text = "0";
            txtFullName.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        public Image img;

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = openFileDialog1.SafeFileName;
                string extension = System.IO.Path.GetExtension(fileName);
                string newFileName = AppDomain.CurrentDomain.BaseDirectory + " \\newFile." + extension;
                //MessageBox.Show(filePath);
                Picture.ImageLocation = filePath;
                img = Image.FromFile(filePath);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
