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
using StudentManagementSystem;

namespace StudentManagementSystem
{
    public partial class AttendanceForm : Form
    {
        List<Attendance> students;

        public AttendanceForm()
        {
            InitializeComponent();
            lbDate.Text = DateTime.Today.ToLongDateString();
        }
        private void Attendent_Load(object sender, EventArgs e)
        {
            Database.Open();
            int Numsession = Attendance.NumberSession();
            drawTextBox(Numsession);
            dataGridViewAtd.Columns[0].ReadOnly = true;
            dataGridViewAtd.Columns[1].ReadOnly = true;
            dataGridViewAtd.Columns[2].ReadOnly = true;
            dataGridViewAtd.Columns[3].ReadOnly = true;
            dataGridViewAtd.Columns[Numsession+4].ReadOnly = true;
            ChangeLanguage();
            LoadStudent();
        } 
   
        public void LoadStudent()
        {
            int k = 0;
            students = Attendance.GetAllAttendances();
            dataGridViewAtd.Rows.Clear();
            string gender="";
            foreach (Attendance s in students)
            {
                if (s.Gender==true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                dataGridViewAtd.Rows.Add(s.AtdId, s.StdId, s.StdName, gender);
                int session = Attendance.NumberSession() ;
                string[] a = s.Atd.Split('-');
                /*for (int i = 0; i < session; i++)
                {
                    if (Int16.Parse(a[i]) == 1)
                    {
                        dataGridViewAtd.Rows[k].Cells[i+4].Value = true;
                    }
                    else dataGridViewAtd.Rows[k].Cells[i+4].Value = false;
                }
                */
                for (int i = 0; i < session; i++)
                {
                    if (a[i] != "E")
                    {
                        dataGridViewAtd.Rows[k].Cells[i + 4].Value = a[i];
                    }
                    else dataGridViewAtd.Rows[k].Cells[i + 4].Value = "";
                }
                dataGridViewAtd.Rows[k].Cells[session + 4].Value = s.AtdScore;
                k++;
            }
        }
 
        private void btnSave_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            foreach (DataGridViewRow row in dataGridViewAtd.Rows)
            {
                a.AtdId = Int16.Parse(row.Cells[0].Value.ToString());
                a.StdId = Int16.Parse(row.Cells[1].Value.ToString());
                string tmp;
                if (row.Cells[4].Value==null)
                {
                    tmp = "E";
                }
                else
                {
                    tmp = row.Cells[4].Value.ToString();
                }

                for (int i = 1; i < Attendance.NumberSession(); i++)
                {
                    if (row.Cells[i + 4].Value == null)
                    {
                        tmp = tmp + "-E";
                    }
                    else
                    {
                        tmp = tmp + "-" + row.Cells[i + 4].Value.ToString();
                    }
                }
                a.Atd = tmp;
                Attendance.AssignAttendance(a);
            }
            dataGridViewAtd.Rows.Clear();

            MessageBox.Show("Done");
            LoadStudent();
        }
        public int ConvertTo10(string s){
            if (s== "True")
	        {
                return 1;
	        }
            else
            {
                return 0;
            }
        }
      
        public void dgvColumn(int session)
        {

            for (int i = 0; i < session ; i++)
            {
                DataGridViewCheckBoxColumn cb1 = new DataGridViewCheckBoxColumn();
                cb1.HeaderText = (i+1).ToString();
                cb1.Width = 50;
                dataGridViewAtd.Columns.Add(cb1);
            }   //end for loop i
        }

        public void DrawComboBoxColumn(int session)
        {
            for (int i = 0; i < session; i++)
            {
                DataGridViewComboBoxColumn cb1 = new DataGridViewComboBoxColumn();
                cb1.HeaderText = (i + 1).ToString();
                cb1.Width = 50;
                cb1.MaxDropDownItems = 3;
                cb1.Items.Add("A");
                cb1.Items.Add("L");
                cb1.Items.Add("P");
                cb1.ValueType= typeof(string);
                dataGridViewAtd.Columns.Add(cb1);
            }   //end for loop i
        }

        public void drawTextBox(int session)
        {

            for (int i = 0; i < session; i++)
            {
                DataGridViewTextBoxColumn tb1 = new DataGridViewTextBoxColumn();

                tb1.HeaderText = (i + 1).ToString();
                tb1.Width = 50;
                tb1.MaxInputLength = 1;
                tb1.DefaultCellStyle.BackColor = Color.White;
                dataGridViewAtd.Columns.Add(tb1);
            }

            DataGridViewTextBoxColumn ScoreAtd = new DataGridViewTextBoxColumn();

            ScoreAtd.HeaderText = "Score";
            ScoreAtd.Width = 80;
            ScoreAtd.MaxInputLength = 4;
            ScoreAtd.DefaultCellStyle.BackColor = Color.White;
            dataGridViewAtd.Columns.Add(ScoreAtd);
        }

        private void dataGridViewAtd_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var t = e.Control as TextBox;
            if (t != null)
            {
                t.KeyPress += OnKeyPress;
            }
        }

        public void AutoSave()
        {
            Attendance a = new Attendance();
            a.AtdId = Int16.Parse(dataGridViewAtd.CurrentRow.Cells[0].Value.ToString());
            a.StdId = Int16.Parse(dataGridViewAtd.CurrentRow.Cells[1].Value.ToString());
            string tmp;
            if (dataGridViewAtd.CurrentRow.Cells[4].Value == null)
            {
                tmp = "E";
            }
            else
            {
                tmp = dataGridViewAtd.CurrentRow.Cells[4].Value.ToString();
            }
            for (int i = 1; i < Attendance.NumberSession(); i++)
            {
                if (dataGridViewAtd.CurrentRow.Cells[i + 4].Value == null)
                {
                    tmp = tmp + "-E";
                }
                else
                {
                    tmp = tmp + "-" + dataGridViewAtd.CurrentRow.Cells[i + 4].Value.ToString();
                }
            }
            a.Atd = tmp;
            Attendance.AssignAttendance(a);
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'A' && e.KeyChar != 'a' && e.KeyChar != 'P' && e.KeyChar != 'p' && e.KeyChar != 'L' && e.KeyChar != 'l' && e.KeyChar != 'b' && e.KeyChar != 'B')
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == 'a' || e.KeyChar == 'A')
                {
                    e.KeyChar = 'A';
                }
                else if (e.KeyChar == 'p' || e.KeyChar == 'P')
                {
                    e.KeyChar = 'P';
                }
                else if (e.KeyChar == 'l' || e.KeyChar == 'L')
                {
                    e.KeyChar = 'L';
                }
                else if (e.KeyChar == 'b' || e.KeyChar == 'B')
                {
                    e.KeyChar = ' ';
                }
            }
        }

        public void reLoadScoreAte()
        {
            List<Attendance> at = new List<Attendance>();
            at = Attendance.GetAllAttendances();
            foreach (Attendance i in at)
            {
                int k=0;
                dataGridViewAtd.Rows[k++].Cells[Attendance.NumberSession()+4].Value= i.AtdScore;
            }
        }
        private void dataGridViewAtd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAtd.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridViewAtd.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
        }

        private void dataGridViewAtd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AutoSave();
            //reLoadScoreAte();
            //LoadStudent();
        }

        public void LoadSearch(string key)
        {
            int k = 0;
            List<Attendance> atd = Attendance.Search(key);
            dataGridViewAtd.Rows.Clear();
            string gender = "";
            foreach (Attendance s in atd)
            {
                if (s.Gender == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                dataGridViewAtd.Rows.Add(s.AtdId, s.StdId, s.StdName, gender);
                int session = Attendance.NumberSession();
                string[] a = s.Atd.Split('-');
                for (int i = 0; i < session; i++)
                {
                    if (a[i] != "E")
                    {
                        dataGridViewAtd.Rows[k].Cells[i + 4].Value = a[i];
                    }
                    else dataGridViewAtd.Rows[k].Cells[i + 4].Value = "";
                }
                dataGridViewAtd.Rows[k].Cells[session + 4].Value = s.AtdScore;
                k++;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewAtd.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewAtd.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            if (!(string.IsNullOrEmpty(txtSearch.Text)))
            {
                LoadSearch(txtSearch.Text);
            }
            else LoadStudent();
        }

  //end dgvColumn   
        private void ChangeLanguage()
        {
           
            if((this.Owner as ToolMenu).btnOption.Text == "    ជម្រើស")
            {
                dataGridViewAtd.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                dataGridViewAtd.Columns[1].HeaderText = "ល.រ";
                dataGridViewAtd.Columns[2].HeaderText = "ឈ្មោះ";
                dataGridViewAtd.Columns[3].HeaderText = "ភេទ";
                //dataGridViewAtd.Columns[19].HeaderText = "ពិន្ទុ";

                btnSave.Font = new Font("Khmer Os Bokor", 13, FontStyle.Regular);
                btnSave.Text = "រក្សាទុក";
            }
        }
    }   //end class AttedanceForm
}   //end StudentMangementSystem