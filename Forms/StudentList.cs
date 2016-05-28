using StudentManagementSystem.Forms;
using System;
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
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
            //SL_Add Add = new SL_Add();
            //Add.Owner = this;
        }


        private void StudentList_Load(object sender, EventArgs e)
        {
            ChangeLanguages();
            SL_List List = new SL_List();
            List.Owner = this;
            List.TopLevel = false;
            List.AutoScroll = true;
            pnSList.Controls.Add(List);
            List.Show();
        }
        void DetectColorButton(int button)
        {
            if (button == 1)
            {
                btnList.BackColor = Color.WhiteSmoke;
                //
                btnAddStudent.BackColor = Color.Gray;
                btnEdit.BackColor = Color.Gray;
                //btnSettings.BackColor = Color.Gray;
            }
            else if (button == 2)
            {
                btnAddStudent.BackColor = Color.WhiteSmoke;
                //
                btnList.BackColor = Color.Gray;
                btnEdit.BackColor = Color.Gray;
                //btnSettings.BackColor = Color.Gray;
            }
            else if (button == 3)
            {
                btnEdit.BackColor = Color.WhiteSmoke;
                //
                btnList.BackColor = Color.Gray;
                btnAddStudent.BackColor = Color.Gray;
                //btnSettings.BackColor = Color.Gray;
            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
          
            DetectColorButton(2);
            pnSList.Controls.Clear();
            SL_Add Add = new SL_Add();
            Add.Owner = this;
            Add.TopLevel = false;
            Add.AutoScroll = true;
            pnSList.Controls.Add(Add);
            btnEdit.Enabled= false;
            btnDelete.Enabled = false;
            Add.Show();
           
        }

        public void btnList_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            ///////////////Open Form StudentList/////////////////////////////
            DetectColorButton(1);
            pnSList.Controls.Clear();
            SL_List List = new SL_List();
            List.Owner = this;
            List.TopLevel = false;
            List.AutoScroll = true;
            pnSList.Controls.Add(List);
            List.Show();
            //pnUnder.BackColor = Color.FromArgb(192, 64, 0);
        }
        StudentListDB student = new StudentListDB();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SL_List s = new SL_List();
            s.Owner = this;
            student = s.GetSelected();
            if (student != null)
            {
                DetectColorButton(3);
                pnSList.Controls.Clear();
                SL_Edit Edit = new SL_Edit(student);
                Edit.Owner = this;
                Edit.TopLevel = false;
                Edit.AutoScroll = true;
                pnSList.Controls.Add(Edit);
                btnDelete.Enabled = false;
                Edit.Show();
            }

            else MessageBox.Show("Please Select Student First!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Del = "Do you want to delete : ";
            string Title = "Delete Confirm!";
            string Op = (this.Owner as ToolMenu).btnOption.Text;
            if (Op == "    ជម្រើស")
            {
                
                Del = "តើអ្នកចង់លុបសិស្សឈ្មោះ  ";
                Title = "លុប";
            }
            Database.Open();
            SL_List s = new SL_List();
            student = s.GetSelected();
            if (student != null)
            {
                var result = MessageBox.Show(Del + student.Name , Title,MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result== DialogResult.Yes)
                {
                StudentListDB.Delete(student.Id);
                Database.Close(); 
                this.btnList_Click(sender ,e );
                }
            }
            else MessageBox.Show("Please Select Student First!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void StudentList_Leave(object sender, EventArgs e)
        {
            student = null;
        }
        private void ChangeLanguages()
        {
            string Op = (this.Owner as ToolMenu).btnOption.Text;
            if (Op == "    ជម្រើស")
            {
                btnAddStudent.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);
                btnList.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);
                btnEdit.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);
                btnDelete.Font = new Font("Khmer OS Bokor", 13, FontStyle.Regular);

                btnList.Text = "បញ្ជីឈ្មោះសិស្ស";
                btnEdit.Text = "កែ";
                btnDelete.Text = "លុបសិស្ស";
                btnAddStudent.Text = "បន្ថែមសិស្ស";
            }
        }
    }
}
