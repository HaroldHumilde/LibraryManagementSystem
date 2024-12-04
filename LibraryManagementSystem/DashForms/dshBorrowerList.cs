using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class dshBorrowerList : Form
    {

        private string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        // Define a placeholder message
        private const string PlaceholderText = "Search ID";
        private bool isPlaceholderActive = true;

        public dshBorrowerList()
        {
            InitializeComponent();
        }

        private void dshBorrowerList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet45.ActiveBorrowers' table. You can move, or remove it, as needed.
            this.activeBorrowersTableAdapter.Fill(this.lmsdcsDataSet45.ActiveBorrowers);
            // TODO: This line of code loads data into the 'lmsdcsDataSet36.BookBorrowing' table. You can move, or remove it, as needed.
            this.bookBorrowingTableAdapter.Fill(this.lmsdcsDataSet36.BookBorrowing);
            

          

            // Set initial placeholder text and state
            txtSearchBorrow.Text = PlaceholderText;
            txtSearchBorrow.ForeColor = Color.Gray; // Placeholder text in gray color
            isPlaceholderActive = true;

            // Attach the events
            txtSearchBorrow.Enter += txtSearchBorrow_Enter;
            txtSearchBorrow.Leave += txtSearchBorrow_Leave;

        }

        private void txtSearchBorrow_TextChanged(object sender, EventArgs e)
        {
            // Skip the search if the placeholder text is active
            if (isPlaceholderActive)
                return;

            string searchText = txtSearchBorrow.Text.Trim();

            if (!string.IsNullOrEmpty(searchText) && searchText != PlaceholderText)
            {
                bool isNumeric = int.TryParse(searchText, out int borrowerID);

                if (isNumeric)
                {
                    // Perform the search for ActiveBorrowers and BookBorrowing based on the input
                    SearchActiveBorrowers(searchText);
                    SearchBookBorrowing(searchText);
                }
                else
                {
                    // Optionally, handle invalid non-numeric input if needed
                    MessageBox.Show("Please enter a valid numeric Student ID.");
                }
            }
            else
            {
                // If the textbox is empty or contains placeholder text, clear the data grids
                ClearDataGrids();
            }
        }
        private void ClearDataGrids()
        {
            // Unbind the DataGridViews before clearing
            dgvBorrower.DataSource = null;
            dgvBorrowedInfo.DataSource = null;

            // Clear the DataGridViews
            dgvBorrower.Rows.Clear();
            dgvBorrowedInfo.Rows.Clear();
        }
        private void SearchActiveBorrowers(string searchText)
        {
            try
            {
                string query = "SELECT * FROM ActiveBorrowers WHERE ID = @searchText";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvBorrower.DataSource = dt;
                    }
                    else
                    {
                        dgvBorrower.DataSource = null; // If no data is found, just clear the DataGrid
                    }
                }
            }
            catch
            {
                // Skip the error handling to avoid showing any error message
            }
        }

        private void SearchBookBorrowing(string searchText)
        {
            // Check if placeholder text is active or search text is empty
            if (isPlaceholderActive || string.IsNullOrEmpty(searchText) || searchText == PlaceholderText)
            {
                return; // Skip search if placeholder is active or input is empty
            }

            bool isNumeric = int.TryParse(searchText, out int borrowerID);

            string query = @"
    SELECT 
        bb.BorrowID,
        bb.BorrowerID,
        bb.SerialNumber,
        i.BookTitle AS BookTitle,
        bb.BorrowedDate,
        bb.DueDate,
        bb.Status
    FROM 
        [BookBorrowing] bb
    INNER JOIN 
        [Inventory] i 
    ON 
        bb.SerialNumber = i.SerialNumber
    WHERE ";

            query += isNumeric ? "bb.BorrowerID = @searchText" : "bb.SerialNumber = @searchText";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Check if DataTable has no rows, and if so, skip processing
                    if (dt.Rows.Count == 0)
                    {
                        dgvBorrowedInfo.DataSource = null; // Clear DataGrid if no results
                        return; // Skip further processing
                    }

                    // Sort the DataTable rows by Status, with 'Borrowed' first
                    var sortedRows = dt.AsEnumerable()
                                       .OrderBy(row => row["Status"].ToString() == "Borrowed" ? 0 : 1)
                                       .CopyToDataTable();

                    dgvBorrowedInfo.DataSource = sortedRows;

                    // Ensure the "BookTitle" header text is correctly updated
                    if (dgvBorrowedInfo.Columns["BookTitle"] != null)
                    {
                        dgvBorrowedInfo.Columns["BookTitle"].HeaderText = "Book Title";
                    }
                }
            }
            catch (Exception ex)
            {
                // Only catch unexpected errors here, not empty results
                if (ex is SqlException || ex is InvalidOperationException || ex is NullReferenceException)
                {
                    // You can log this exception if you need, but don't show it to the user
                    // LogException(ex); // Uncomment if you want to log the exception
                }
                else
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }



        private void txtSearchBorrow_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBorrow.Text)) // Check if TextBox is empty
            {
                txtSearchBorrow.Text = PlaceholderText; // Reapply placeholder text
                txtSearchBorrow.ForeColor = Color.Gray; // Set placeholder color
                isPlaceholderActive = true; // Mark placeholder as active
            }
        }

        private void txtSearchBorrow_Enter(object sender, EventArgs e)
        {
            if (isPlaceholderActive)
            {
                txtSearchBorrow.Text = string.Empty; // Remove placeholder text
                txtSearchBorrow.ForeColor = Color.Black; // Set color for user input
                isPlaceholderActive = false; // Mark placeholder as inactive
            }
        }
    }
}
