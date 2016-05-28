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
    public partial class NoteForm : Form
    {

        List<Note> n = new List<Note>();
        public NoteForm()
        {
            InitializeComponent();
            lbDate.Text = DateTime.Today.ToLongDateString();
        }
        public void InitNote()
        {
            lbId.Text = "0";
            txtDetail.Text = "";
            txtTitle.Text = "";
        }
        private void NoteForm_Load(object sender, EventArgs e)
        {
            Database.Open();
            DataGridViewNote.Columns[2].ReadOnly = false;
            ChangeLanguage();
            LoadNote();
        }

        private void NoteForm_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            InitNote();
        }
        int rowId;
        private void StudentScoreList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewNote.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            DataGridViewNote.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            rowId = Int16.Parse(DataGridViewNote.SelectedCells[0].Value.ToString());
            LoadEdit(rowId);
        }
        public void LoadNote()
        {

            DataGridViewNote.Rows.Clear();
            n = Note.getAllNote();
            foreach (Note b in n)
            {
                DataGridViewNote.Rows.Add(b.Id, b.Title, b.Session, b.Date.ToShortDateString(), b.Detail);
            }
        }

        public void LoadEdit(int id)
        {
            Note note = new Note();
            note = Note.GetSelected(id);
            lbId.Text = note.Id.ToString();
            txtDetail.Text = note.Detail;
            txtTitle.Text = note.Title;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Note m = new Note();
            m.Id = Int16.Parse(lbId.Text);
            m.Title = txtTitle.Text;
            m.Session = 1;
            m.Date = DateTime.Today;
            m.Detail = txtDetail.Text;
            if (Int16.Parse(lbId.Text) == 0)
            {
                Note.Insert(m);
            }
            else Note.Update(m);
            
            LoadNote();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Note.Delect(Int16.Parse(lbId.Text));
            LoadNote();
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text=="Title")
            {
                txtTitle.ForeColor = Color.Black;
                txtTitle.Text = "";

            }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                txtTitle.Text = "Title";
                txtTitle.ForeColor = Color.LightGray;
            }
        }

        private void txtDetail_Leave(object sender, EventArgs e)
        {
            if (txtDetail.Text=="")
            {
                txtDetail.Text = "Detail";
                txtDetail.ForeColor = Color.RosyBrown;
            }
        }

        private void txtDetail_Enter(object sender, EventArgs e)
        {
            if (txtDetail.Text == "Detail")
            {
                txtDetail.Text = "";
                txtDetail.ForeColor = Color.IndianRed;
            }
        }
        public void LoadSearch(string key)
        {
            DataGridViewNote.Rows.Clear();
            List<Note> ns = new List<Note>();
            ns = Note.Search(key);
            foreach (Note b in ns)
            {
                DataGridViewNote.Rows.Add(b.Id, b.Title, b.Session, b.Date.ToShortDateString(), b.Detail);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataGridViewNote.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            DataGridViewNote.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            if (!(string.IsNullOrEmpty(txtSearch.Text)))
            {
                LoadSearch(txtSearch.Text);
            }
            else LoadNote();
        }
        private void ChangeLanguage()
        {
            if((this.Owner as ToolMenu).btnOption.Text == "    ជម្រើស")
            {
                btnAddNote.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                btnDelete.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                btnUpdate.Font = new Font("Khmer OS Bokor", 12, FontStyle.Regular);
                txtTitle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                txtDetail.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                DataGridViewNote.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                DataGridViewNote.Columns[0].HeaderText = "ល.រ";
                DataGridViewNote.Columns[1].HeaderText = "ចំណងជើរ";
                DataGridViewNote.Columns[2].HeaderText = "មេរៀនទី";
                DataGridViewNote.Columns[3].HeaderText = "កាវិភាគ";
                DataGridViewNote.Columns[4].HeaderText = "លម្អិត";

                txtTitle.Text = "ចំណងជើរ";
                txtDetail.Text = "លម្អិត";
                btnUpdate.Text = "រក្សាទុក";
                btnDelete.Text = "លុប";
                btnAddNote.Text = "បន្ថែមកំណត់ត្រាថ្មី";
            }
        }
    }
}
