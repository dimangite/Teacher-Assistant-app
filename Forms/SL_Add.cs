﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class SL_Add : Form
    {
        public SL_Add()
        {
            InitializeComponent();
        }

        public static Image img;

        private void SL_Add_Load(object sender, EventArgs e)
        {
            Database.Open();
            ChangeLanguages();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //1.verify all input (textbox, combobox, and datetimepicker)
            if (String.IsNullOrEmpty(txtFullName.Text) ||(string.IsNullOrEmpty(txtPhone.Text)))
            {
                MessageBox.Show("Please input student info", "Erorr Adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return;
            }

            //2.insert to table student in the database
            StudentListDB s = new StudentListDB();
            s.Name = txtFullName.Text.Trim();
            if (rdbMale.Checked == true)
            {
                s.Gender = true;
            }
            else
            {
                s.Gender = false;
            }
            
            s.Phone = txtPhone.Text.Trim();
            s.Photo = img;
            s.PhotoPath = Picture.ImageLocation;
            s.ClassID = 2;
            StudentListDB.Insert(s);

            Database.Close();
            (this.Owner as StudentList).btnList_Click(sender, e);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            (this.Owner as StudentList).btnList_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            lbAdd.Hide();
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

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
        private void ChangeLanguages()
        {
            if ((this.Owner as StudentList).btnList.Text == "បញ្ជីឈ្មោះសិស្ស")
            {
                lbName.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbAdd.Font = new Font("Khmer OS Bokor", 9, FontStyle.Regular);
                lbGender.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                lbPN.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                rdbFemale.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                rdbMale.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnAdd.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnCancel.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);

                lbName.Text = "ឈ្មោះ";
                lbAdd.Text = "បញ្ចូលរូបភាគ";
                lbGender.Text = "ភេទ";
                lbPN.Text = "លេខទូរស័ព្ទ";
                rdbMale.Text = "ប្រុស";
                rdbFemale.Text​ = "ស្រី";
                btnAdd.Text = "បញ្ចូល";
                btnCancel.Text = "បោះបង់";
            }
        }
    }
}
