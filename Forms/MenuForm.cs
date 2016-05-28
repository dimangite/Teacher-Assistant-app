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
    public partial class MenuForm : Form
    {
        Option Op = new Option();
        public MenuForm()
        {
            Op.Owner = this;
            InitializeComponent();
            
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnOption_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LanguageLoad();
        }
        private void MenuForm_Leave(object sender, EventArgs e)
        {
            //(this.Owner as ToolMenu).btnClass.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnStudentList_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnStudentAttendent_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnStudentScore_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnReport_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnNote_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnDocument_Click(sender, e);
            (this.Owner as ToolMenu).ActiveButton();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            (this.Owner as ToolMenu).btnAboutUs_Click(sender, e);
            //(this.Owner as ToolMenu).ActiveButton();
        }

        private void LanguageLoad()
        {
            string Op = (this.Owner as ToolMenu).btnOption.Text;
            if (Op=="    ជម្រើស")
            {
                (this.Owner as ToolMenu).lbMainName.Font = new Font("Chaparral Pro", 28, FontStyle.Regular);
                (this.Owner as ToolMenu).lbMainName.Text = "បញ្ជី";
                btnList.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnAtt.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnScore.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnNote.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnOption.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnReport.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnDoc.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                btnAbout.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular); 
                btnList.Text = "បញ្ជីឈ្មោះសិស្ស";
                btnAtt.Text = "បញ្ជីអវត្តមានសិស្ស";
                btnScore.Text = "បញ្ជីពិន្ទុសិស្ស";
                btnNote.Text = "កំណត់ត្រា";
                btnOption.Text = "ជម្រើស";
                btnReport.Text = "របាយការណ៍";
                btnDoc.Text = "ឯកសារ";
                btnAbout.Text = "អំពីយើង";
            }
        }
    }
}
