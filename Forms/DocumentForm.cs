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
    public partial class DocumentForm : Form
    {
        public DocumentForm()
        {
            InitializeComponent();
        }
        List<Document> doc = new List<Document>();
        public string filePath;
        public string fileName;
        Document d = new Document();

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               filePath = openFileDialog1.FileName;
               fileName = openFileDialog1.SafeFileName;
               string extension = System.IO.Path.GetExtension(fileName);
               string newFileName = AppDomain.CurrentDomain.BaseDirectory + " \\newFile." + extension;
                //MessageBox.Show(filePath);
                d.Path= filePath ;
                d.Title= fileName;
                d.Date= DateTime.Today;
                Document.Insert(d);
                LoadDoc();
            }
        }

        public void LoadDoc()
        {
            DataGridViewDoc.Rows.Clear();
            doc = Document.getAllDocument();
            foreach (Document d in doc)
            {
                DataGridViewDoc.Rows.Add(d.Id, d.Title, d.Session, d.Date, d.Path);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 1)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    fileName = openFileDialog1.SafeFileName;
                    string extension = System.IO.Path.GetExtension(fileName);
                    string newFileName = AppDomain.CurrentDomain.BaseDirectory + " \\newFile." + extension;
                    //MessageBox.Show(filePath);
                    d.Id = rowIndex;
                    d.Path = filePath;
                    d.Title = fileName;
                    d.Date = DateTime.Today;
                    Document.Update(d);
                    LoadDoc();
                }
            }
            else MessageBox.Show("Please select the file");
        }
        int rowIndex;
        private void StudentScoreList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewDoc.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            DataGridViewDoc.RowsDefaultCellStyle.SelectionForeColor = Color.Pink;
            rowIndex = Int16.Parse(DataGridViewDoc.SelectedCells[0].Value.ToString());
            Document d = new Document();
            d = Document.GetSelected(rowIndex);
            System.Diagnostics.Process.Start(d.Path);
        }

        private void StudentScoreList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewDoc.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            DataGridViewDoc.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            rowIndex = Int16.Parse(DataGridViewDoc.SelectedCells[0].Value.ToString());
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            Database.Open();
            DataGridViewDoc.Columns[2].ReadOnly = false;
            ChangeLanguage();
            LoadDoc();
        }

        private void DocumentForm_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 1)
            {
                Document.Delect(rowIndex);
                LoadDoc();
            }
            else MessageBox.Show("Please select the file");
        }
        public void LoadSearch(string key)
        {
            DataGridViewDoc.Rows.Clear();
            List<Document> docs = new List<Document>();
            docs = Document.Search(key);
            foreach (Document d in docs)
            {
                DataGridViewDoc.Rows.Add(d.Id, d.Title, d.Session, d.Date, d.Path);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataGridViewDoc.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            DataGridViewDoc.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            if (!(string.IsNullOrEmpty(txtSearch.Text)))
            {
                LoadSearch(txtSearch.Text);
            }
            else LoadDoc();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ChangeLanguage()
        {
            if((this.Owner as ToolMenu).btnOption.Text == "    ជម្រើស")
            {
                btnAddDoc.Font = new Font("Khmer Os Bokor", 12, FontStyle.Regular);
                btnDelete.Font = new Font("Khmer Os Bokor", 12, FontStyle.Regular);
                btnEdit.Font = new Font("Khmer Os Bokor", 12, FontStyle.Regular);
                DataGridViewDoc.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer Os Bokor", 11, FontStyle.Regular);
                DataGridViewDoc.Columns[0].HeaderText = "ល.រ";
                DataGridViewDoc.Columns[1].HeaderText = "ឈ្មោះឯកសារ";
                DataGridViewDoc.Columns[2].HeaderText = "មេរៀន";
                DataGridViewDoc.Columns[3].HeaderText = "កាវិភាគ";
                DataGridViewDoc.Columns[4].HeaderText = "លម្អិត";

                btnAddDoc.Text = "បញ្ចូលឯកសារ";
                btnEdit.Text = "កែ";
                btnDelete.Text = "លុប";
            }
        }
    }
}
