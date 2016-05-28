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
    public partial class SL_Edit : Form
    {
        StudentListDB student = new StudentListDB();
        public SL_Edit(StudentListDB s)
        {
            InitializeComponent();
            student = s;
        }
        public static Image img;
        private void SL_Edit_Load(object sender, EventArgs e)
        {
            Database.Open();
            ChangeLanguages();
            txtFullName.Text = student.Name;
            txtPhone.Text = student.Phone.ToString();
            if (student.Gender==true)
            {
                rdbMale.Checked = true;
            }
            else
            {
                rdbFemale.Checked = true;
            }
            //Picture.Image = student.Photo;
            Picture.ImageLocation = student.PhotoPath;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            student.Name = txtFullName.Text;
            if (rdbFemale.Checked==true)
	        {
                student.Gender = false;
	        }
            else
            {
                student.Gender = true;
            }
            student.Phone = (txtPhone.Text);
            student.PhotoPath = Picture.ImageLocation;
            student.Photo = Picture.Image;
            StudentListDB.Update(student);
            (this.Owner as StudentList).btnList_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            (this.Owner as StudentList).btnList_Click(sender, e);
        }

        private void SL_Edit_Leave(object sender, EventArgs e)
        {
            Database.Close();
            student = null;
        }

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
        private void ChangeLanguages()
        {
               if ((this.Owner as StudentList).btnList.Text == "បញ្ជីឈ្មោះសិស្ស")
               {
                    lbName.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    btnAddPhoto.Font = new Font("Khmer OS Bokor", 9, FontStyle.Regular);
                    lbGender.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    lbPN.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    rdbFemale.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    rdbMale.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    btnUpdate.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                    btnCancel.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);

                    lbName.Text = "ឈ្មោះ";
                    btnAddPhoto.Text = "បញ្ចូលរូបភាគ";
                    lbGender.Text = "ភេទ";
                    lbPN.Text = "លេខទូរស័ព្ទ";
                    rdbMale.Text = "ប្រុស";
                    rdbFemale.Text​ = "ស្រី";
                    btnUpdate.Text = "រក្សាទុក";
                    btnCancel.Text = "បោះបង់";
            }
        }
    }
}
