using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BookIssueForm : Form
    {
        private long _ISBN;
        private string _BookTitle;
        private string _Author;
        private string _Category;
        private string _PublishDate;
        private string _BookShelves;
        private string _Description;

        private BindingSource showIssueInfo;
        public BookIssueForm()
        {
            InitializeComponent();
            showIssueInfo = new BindingSource();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            _BookTitle = (txtBookTitle.Text.ToString());
            _ISBN = ISBN(txtISBN.Text.ToString());
            _Author = (txtAuthor.Text.ToString());
            _Category = cmbCategory.Text;
            _PublishDate = biPublishDate.Text;
            _BookShelves = cmbBookShelves.Text;
            _Description = txtDescription.Text;


            showIssueInfo.Add(new BookIssue(_BookTitle, _ISBN, _Author, _Category, _PublishDate, _BookShelves, _Description));
            gridViewIssue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewIssue.DataSource = showIssueInfo;
        }
        public long ISBN(string isbn)
        {
            try
            {
                _ISBN = long.Parse(isbn);
            }
            catch (NumberFormatException io)
            {
                MessageBox.Show(io.Message, isbn);
            }
            return _ISBN;
        }

        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }

        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {

           
        }


        private void cmbPublishDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBookShelves_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BookIssueForm_Load(object sender, EventArgs e)
        {

            try
            {
                string[] ListofCategory = new string[]{

                "Biography & Memoir",
                "History",
                "Science & Technology",
                "Self-Help & Personal Development",
                "Travel",
                "Politics & Government",
                "Religion & Spirituality",
                "Art & Photography",
                "Health & Fitness",
                "Business & Economics",
                "True Crime",
                "Dictionaries & Encyclopedias",
                "Atlases",
                "Legal References",
                "Academic Texts",
                "Textbooks",
                "Study Guides",
                "Language Learning",
                "Magazines",
                "Journals",
                "Newspapers"
            };
                for (int i = 0; i < 21; i++)
                {
                    cmbCategory.Items.Add(ListofCategory[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show("Invalid Categoy", io.Message);
            }

            try
            {
                string[] ListOfShelves = new string[]{

                "BookShelves A",
                "BookShelves B",
                "BookShelves C",
                "BookShelves D",
                "BookShelves E",

            };
                for (int i = 0; i < 5; i++)
                {
                    cmbBookShelves.Items.Add(ListOfShelves[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthor.Clear();
            txtBookTitle.Clear();
            txtDescription.Clear();
            txtISBN.Clear();
            cmbBookShelves.Text = string.Empty;
            cmbCategory.Text = string.Empty;
            biPublishDate.Text = string.Empty;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void gridViewIssue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

