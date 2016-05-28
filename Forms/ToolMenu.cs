using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.Forms;

namespace StudentManagementSystem
{
    public partial class ToolMenu : Form
    {
        public static string btnsetting;
        
        public ToolMenu()
        {
            InitializeComponent();
            ////////Stating Program//////////////////
            ttClose.SetToolTip(btnExit, "Close");
            ttMinimun.SetToolTip(btnMinimun, "Minimun");
            btnClass.BackColor = Color.WhiteSmoke;
            if (Login.Role ==true)
            {
                btnUserSetting.Enabled = true;
                btnUserSetting.Visible = true;
            }
            ///////////////////
            AttendanceForm att = new AttendanceForm();
            att.Owner = this;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        public void btnClass_Click(object sender, EventArgs e)
        {
            lbMainName.Text = btnClass.Text;
            //ColorChecker
            DetectButton(1);
            
            /////////////////Open Form Home/////////////////////////////
            pnTool.Controls.Clear();
            Home Home = new Home();
            Home.Owner = this;
            Home.TopLevel = false;
            Home.AutoScroll = true;
            pnTool.Controls.Add(Home);
            Home.Show();
            DisactiveButton();
        }

        public void btnStudentList_Click(object sender, EventArgs e)
        {
            lbMainName.Text = btnStudentList.Text;
            //ColorChecker
            DetectButton(2);
            
            pnTool.Controls.Clear();
            StudentList list = new StudentList();
            list.Owner = this;
            list.TopLevel = false;
            list.AutoScroll = true;
            pnTool.Controls.Add(list);
            list.Show();
        }
        public void btnStudentScore_Click(object sender, EventArgs e)
        {
            lbMainName.Text = "";
            lbMainName.Text = btnStudentScore.Text;
            //ColorChecker
            DetectButton(3);

            ///////////////Open Form StudentScoreList/////////////////////////////
            pnTool.Controls.Clear();
            StudentScore List = new StudentScore();
            List.Owner = this;
            List.TopLevel = false;
            List.AutoScroll = true;
            pnTool.Controls.Add(List);
            List.Show();
            pnUnder.BackColor = Color.FromArgb(192, 64, 0);
        }

        public void btnStudentAttendent_Click(object sender, EventArgs e)
        {
            lbMainName.Text = btnStudentAttendent.Text;
            //ColorChecker
            pnTool.Controls.Clear();
            AttendanceForm form = new AttendanceForm();
            form.Owner = this;
            form.AutoScroll = true;
            form.TopLevel = false;
            pnTool.Controls.Add(form);
            form.Show();
            pnUnder.BackColor = Color.FromArgb(192, 64, 0);
            DetectButton(4);
        }



        public void btnReport_Click(object sender, EventArgs e)
        {
            lbMainName.Text = btnReport.Text;
            //ColorChecker
            pnTool.Controls.Clear();
            Report r = new Report();
            r.TopLevel = false;
            r.AutoScroll = true;
            pnTool.Controls.Add(r);
            r.Show();
            DetectButton(6);
        }

        public void btnOption_Click(object sender, EventArgs e)
        {
            lbMainName.Text = "";
            lbMainName.Text = btnOption.Text;
            //ColorChecker
            pnTool.Controls.Clear();
            Option Option = new Option();
            Option.Owner = this;
            Option.TopLevel = false;
            Option.AutoScroll = true;
            pnTool.Controls.Add(Option);
            Option.Show();
            btnsetting = btnOption.Text;
            DetectButton(8);
        }   
        void DetectButton(int button)
        {
            if(button == 1)
            {
                btnClass.BackColor = Color.WhiteSmoke;
                //
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 2)
            {
                btnStudentList.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 3)
            {
                btnStudentScore.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 4)
            {
                btnStudentAttendent.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 5)
            {
                btnNote1.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 6)
            {
                btnReport.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button == 7)
            {
                btnDocument.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnOption.BackColor = Color.FromArgb(30, 0, 18);
            }
            else if(button==8)
            {
                btnOption.BackColor = Color.WhiteSmoke;
                //
                btnClass.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentList.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentScore.BackColor = Color.FromArgb(30, 0, 18);
                btnStudentAttendent.BackColor = Color.FromArgb(30, 0, 18);
                btnNote1.BackColor = Color.FromArgb(30, 0, 18);
                btnReport.BackColor = Color.FromArgb(30, 0, 18);
                btnDocument.BackColor = Color.FromArgb(30, 0, 18);
            }

        }

        public void lbMainName_TextChanged(object sender, EventArgs e)
        {
            if(btnOption.Text == "   ជម្រើស")
                lbMainName.Top = pnMain.Size.Height / 2 - 30;
            else if(btnOption.Text == "     Option")
                lbMainName.Top = pnMain.Size.Height / 2 - 20;
        }

        private void ToolMenu_Load(object sender, EventArgs e)
        {
            if (btnClass.Text == "ថ្នាក់")
                lbMainName.Font = new Font("Khmer OS Bokor", 21, FontStyle.Regular);
            this.btnClass_Click(sender, e);     
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("DO YOU WANT TO LOG OUT?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                this.Close();
                Login g = new Login();
                g.Show();
            } 
        }

        public void btnAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs us = new AboutUs();
            us.ShowDialog();
        }

        public void DisactiveButton()
        {
            btnStudentList.Enabled = false;
            btnStudentScore.Enabled = false;
            btnStudentAttendent.Enabled = false;
            btnDocument.Enabled = false;
            btnReport.Enabled = false;
            btnOption.Enabled = false;
            btnNote1.Enabled = false;
        }

        public void ActiveButton()
        {
            btnStudentList.Enabled = true;
            btnStudentScore.Enabled = true;
            btnStudentAttendent.Enabled = true;
            btnDocument.Enabled = true;
            btnReport.Enabled = true;
            btnOption.Enabled = true;
            btnNote1.Enabled = true;
        }

        public void btnDocument_Click(object sender, EventArgs e)
        {
            DocumentForm d = new DocumentForm();
            lbMainName.Text = btnDocument.Text;
            //ColorChecker
            pnTool.Controls.Clear();
            d.Owner = this;
            d.TopLevel = false;
            d.AutoScroll = true;
            pnTool.Controls.Add(d);
            d.Show();
            DetectButton(7);
        }

        public void btnNote_Click(object sender, EventArgs e)
        {
            lbMainName.Text = btnNote1.Text;
            //ColorChecker
            pnTool.Controls.Clear();
            NoteForm r = new NoteForm();
            r.Owner = this;
            r.TopLevel = false;
            r.AutoScroll = true;
            pnTool.Controls.Add(r);
            r.Show();
            DetectButton(5);
        }

        private void btnUserSetting_Click(object sender, EventArgs e)
        {
            EditUser ed = new EditUser();
            ed.Show();
        }
    }

}


/*
//Make Form Move
        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)      m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }*/