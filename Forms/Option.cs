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
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();
        }
        private void Option_Load(object sender, EventArgs e)
        {
        }
        private void pbKhmerLanguage_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////ToolMenu Form//////////////////////////////////////////////////
            (this.Owner as ToolMenu).btnClass.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnClass.Text = "    ថ្នាក់";
            (this.Owner as ToolMenu).btnStudentList.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentList.Text = "   បញ្ជីឈ្មោះសិស្ស";
            (this.Owner as ToolMenu).btnStudentScore.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentScore.Text = "   បញ្ជីពិន្ទុសិស្ស";
            (this.Owner as ToolMenu).btnStudentAttendent.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentAttendent.Text = "   បញ្ជីអវត្តមានសិស្ស";
            (this.Owner as ToolMenu).btnNote1.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnNote1.Text = "   កំណត់ត្រា";
            (this.Owner as ToolMenu).btnReport.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnReport.Text = "   របាយការណ៍";
            (this.Owner as ToolMenu).btnOption.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnOption.Text = "    ជម្រើស";
            (this.Owner as ToolMenu).btnDocument.Font = new Font("Khmer OS Content", 13, FontStyle.Regular);
            (this.Owner as ToolMenu).btnDocument.Text = "    ឯកសារ";
            (this.Owner as ToolMenu).btnLogOut.Font = new Font("Khmer OS Content", 12, FontStyle.Regular);
            (this.Owner as ToolMenu).btnLogOut.Text = "ចាក់ចេញ";
            (this.Owner as ToolMenu).btnAboutUs.Font = new Font("Khmer OS Content", 12, FontStyle.Regular);
            (this.Owner as ToolMenu).btnAboutUs.Text = "អំពីយើង";
            //////////////////////////////////////Main Title///////////////////////////////////////////////////////////////////
            (this.Owner as ToolMenu).lbMainName.Font = new Font("Khmer OS Bokor", 21, FontStyle.Regular);
            (this.Owner as ToolMenu).lbMainName.Text = "   ជម្រើស";

        }

        private void pbEnglishLanguage_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////Form Menu//////////////////////////////////////////////////
            (this.Owner as ToolMenu).btnClass.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnClass.Text = "      Classes";
            (this.Owner as ToolMenu).btnStudentList.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentList.Text = "     Students List";
            (this.Owner as ToolMenu).btnStudentScore.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentScore.Text = "     Students Score";
            (this.Owner as ToolMenu).btnStudentAttendent.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnStudentAttendent.Text = "     Students Attendence";
            (this.Owner as ToolMenu).btnNote1.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnNote1.Text = "     Note+";
            (this.Owner as ToolMenu).btnReport.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnReport.Text = "     Students Report";
            (this.Owner as ToolMenu).btnOption.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnOption.Text = "      Option";
            (this.Owner as ToolMenu).btnDocument.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnDocument.Text = "      Document";
            (this.Owner as ToolMenu).btnLogOut.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnLogOut.Text = "LOG OUT";
            (this.Owner as ToolMenu).btnAboutUs.Font = new Font("Chaparral Pro", 15, FontStyle.Regular);
            (this.Owner as ToolMenu).btnAboutUs.Text = "About Us";
            (this.Owner as ToolMenu).lbMainName.Font = new Font("Chaparral Pro", 28, FontStyle.Regular);
            (this.Owner as ToolMenu).lbMainName.Text = "      Option";
        }

        private void lbKhmer_Click(object sender, EventArgs e)
        {
            pbKhmerLanguage_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pbEnglishLanguage_Click(sender, e);
        }
    }
}
