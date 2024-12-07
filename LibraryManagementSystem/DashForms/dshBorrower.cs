using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;


namespace LibraryManagementSystem
{
    public partial class dshBorrower : Form
    {

        private int activeBorrowerID = 0; // Default value, meaning no borrower is selected
        private string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private const string SearchPlaceholderText = "Search Student Number, Name";
        private bool isSearchPlaceholderActive = true;

        public dshBorrower()
        {
            InitializeComponent();
            InitializePlaceholders();
        }



        private void dshBorrower_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet6.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet6.Inventory);
            // TODO: This line of code loads data into the 'lmsdcsDataSet5.ActiveBorrowers' table. You can move, or remove it, as needed.
            this.activeBorrowersTableAdapter1.Fill(this.lmsdcsDataSet5.ActiveBorrowers);

            // Initialize placeholder text
            if (string.IsNullOrWhiteSpace(txtSearchBook.Text))
            {
                txtSearchBook.Text = "Search for a book...";
                txtSearchBook.ForeColor = Color.Gray;
            }

            pnlBooks.Visible = false;





        }


        // Initialize placeholder text for txtSearch
        private void InitializePlaceholder()
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = SearchPlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            // Skip search if placeholder is active
            if (isSearchPlaceholderActive)
                return;

            // If the search box is empty, clear the student fields
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ClearStudentFields(); // Clear student fields
                return;
            }

            // Get the search query from txtSearch
            string searchQuery = txtSearch.Text.Trim();
            Console.WriteLine($"Search Query: {searchQuery}");

            // Fetch student details from the database based on the search query
            DataTable studentResults = GetStudentSearchResults(searchQuery);
            Console.WriteLine($"Found {studentResults.Rows.Count} results.");

            // If student results are found, populate the student fields
            if (studentResults.Rows.Count > 0)
            {
                PopulateStudentFields(studentResults.Rows[0]); // Populate student textboxes and other fields
            }
            else
            {
                // Clear the student fields if no student is found
                ClearStudentFields();
            }
        }
        private DataTable GetStudentSearchResults(string searchQuery)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                    SELECT ID, StudentNumber, Firstname, Middlename, Lastname, Age, Birthday, Gender, Address, 
                           ContactNumber, Email, Year, Section, ProfileImage
                    FROM ActiveBorrowers
                    WHERE Firstname LIKE @Search OR Lastname LIKE @Search OR StudentNumber LIKE @Search";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Log detailed error message
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        private void PopulateStudentFields(DataRow studentData)
        {
            Console.WriteLine($"Populating fields for student: {studentData["Firstname"]} {studentData["Lastname"]}");

            // Populate student-related text fields with the data from the DataRow
            txtStudentNumber.Text = studentData["StudentNumber"].ToString();
            txtFirstName.Text = studentData["Firstname"].ToString();
            txtMiddleName.Text = studentData["Middlename"].ToString();
            txtLastName.Text = studentData["Lastname"].ToString();
            txtAge.Text = studentData["Age"].ToString();
            txtBirthday.Text = Convert.ToDateTime(studentData["Birthday"]).ToString("MM/dd/yyyy"); // Format the birthday if needed
            txtGender.Text = studentData["Gender"].ToString();
            txtAddress.Text = studentData["Address"].ToString();
            txtContactNumber.Text = studentData["ContactNumber"].ToString();
            txtEmail.Text = studentData["Email"].ToString();
            txtYear.Text = studentData["Year"].ToString();
            txtSection.Text = studentData["Section"].ToString();

            // Populate the student ID (active borrower's ID)
            txtID.Text = studentData["ID"].ToString(); // This should populate txtID

            // Handle the profile image
            if (studentData["ProfileImage"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])studentData["ProfileImage"]; // Get the byte array from the database

                if (imageBytes.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbProfileImage.Image = Image.FromStream(ms); // Convert the byte array into an image and display it
                            pbProfileImage.SizeMode = PictureBoxSizeMode.Zoom; // Adjust image display
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pbProfileImage.Image = null; // Clear the PictureBox on error
                    }
                }
                else
                {
                    pbProfileImage.Image = null; // Clear the PictureBox if no image data is found
                }
            }
            else
            {
                pbProfileImage.Image = null; // Clear the PictureBox if no image is provided
            }
        }

        private void ClearBookFields()
        {
            txtBookTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtBookShelves.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtPublishedDate.Text = string.Empty;

            // Clear BookID and disable the textbox if no book is selected
            txtBookID.Text = string.Empty;
            txtBookID.Enabled = false; // Disable BookID textbox if no book is selected
        }


        private void ClearStudentFields()
        {
            txtID.Clear(); // Clear the ID field
            txtStudentNumber.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtGender.Clear();
            txtYear.Clear();
            txtSection.Clear();
            txtSearch.Clear();
        }



        private void btnShowSearchButton_Click(object sender, EventArgs e)
        {
            // Fetch the active borrower ID dynamically from a method
            int borrowerID = GetActiveBorrowerID();

            // If no active borrower ID is found (i.e., borrowerID is 0), prompt the user to select a borrower
            if (borrowerID == 0)
            {
                MessageBox.Show("Please select a borrower first.", "No Borrower Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if no active borrower is found
            }

            // If a borrower is selected, proceed with your logic
            pnlBooks.Visible = !pnlBooks.Visible; // Toggle the visibility of the pnlBooks panel
        }

        private int GetActiveBorrowerID()
        {
            // Placeholder for the actual method that returns the active borrower ID
            return 1; // For testing purposes, let's assume the borrower ID is 1.
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide the pnlAddBook panel when the back button is clicked
            pnlBooks.Visible = false;
        }



        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchPlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
                isSearchPlaceholderActive = false;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                InitializePlaceholder();
                isSearchPlaceholderActive = true;
            }
        }

        private void dshBorrower_Shown(object sender, EventArgs e)
        {
            // Initialize the placeholder behavior after the form is fully shown
            InitializePlaceholder();
        }





        private void InitializePlaceholders()
        {
            // Set placeholder during initialization if textbox is empty
            if (string.IsNullOrWhiteSpace(txtSearchBook.Text))
            {
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            txtSearchBook.Text = "Search Book";
            txtSearchBook.ForeColor = Color.Gray;
        }





        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user has double-clicked a row (not the header row)
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewStudents.Rows[e.RowIndex];

                // Populate the textboxes with the selected row's data
                txtStudentNumber.Text = selectedRow.Cells["StudentNumber"].Value.ToString();
                txtFirstName.Text = selectedRow.Cells["Firstname"].Value.ToString();
                txtMiddleName.Text = selectedRow.Cells["Middlename"].Value.ToString();
                txtLastName.Text = selectedRow.Cells["Lastname"].Value.ToString();
                txtAge.Text = selectedRow.Cells["Age"].Value.ToString();
                txtBirthday.Text = Convert.ToDateTime(selectedRow.Cells["Birthday"].Value).ToString("MM/dd/yyyy");
                txtGender.Text = selectedRow.Cells["Gender"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                txtContactNumber.Text = selectedRow.Cells["ContactNumber"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtYear.Text = selectedRow.Cells["Year"].Value.ToString();
                txtSection.Text = selectedRow.Cells["Section"].Value.ToString();

                // Handle profile image (if exists in the row)
                if (selectedRow.Cells["ProfileImage"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])selectedRow.Cells["ProfileImage"].Value;

                    if (imageBytes.Length > 0)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pbProfileImage.Image = Image.FromStream(ms);
                                pbProfileImage.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            pbProfileImage.Image = null;
                        }
                    }
                    else
                    {
                        pbProfileImage.Image = null;
                    }
                }
                else
                {
                    pbProfileImage.Image = null;
                }
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDueDate.Value;

            // Prevent selecting past dates or today
            if (selectedDate.Date < DateTime.Today)
            {
                MessageBox.Show("You cannot select a past date or today as the due date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDueDate.Value = DateTime.Today.AddDays(1);  // Set to tomorrow by default
            }
            else
            {
                // Prevent selecting Saturday or Sunday
                if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("You cannot set the due date on weekends (Saturday or Sunday). Please choose a weekday.", "Weekend Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Set the date to the next Monday
                    dtpDueDate.Value = GetNextWeekday(selectedDate);
                }
            }
        }

        // Helper function to get the next weekday (Monday)
        private DateTime GetNextWeekday(DateTime date)
        {
            // If the date is a Saturday, return the following Monday
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(2); // Next Monday
            }
            // If the date is a Sunday, return the following Monday
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(1); // Next Monday
            }
            return date; // If not a weekend, return the same date
        }

        private void btnBorrowBooks_Click(object sender, EventArgs e)
        {
            // Get the Book ID from the TextBox (txtBookID)
            string bookID = txtBookID.Text.Trim();

            // Ensure Book ID is provided
            if (string.IsNullOrEmpty(bookID))
            {
                MessageBox.Show("Please select a valid Book.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the Borrower ID (assumes there's a TextBox for Borrower ID, like txtBorrowerID)
            string borrowerID = txtID.Text.Trim();

            // Ensure Borrower ID is provided
            if (string.IsNullOrEmpty(borrowerID))
            {
                MessageBox.Show("Please enter a valid Borrower ID.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the Due Date from the DateTimePicker
            DateTime dueDate = dtpDueDate.Value;

            // Check if the selected date is valid (not in the past)
            if (dueDate.Date < DateTime.Today)
            {
                MessageBox.Show("The due date cannot be in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
            private void InsertBookBorrowing(string borrowerID, int bookID, DateTime dueDate)
            {
                string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // SQL query to insert a new record into the BookBorrowing table
                        string query = @"
INSERT INTO BookBorrowing (BorrowerID, BookID, BorrowDate, DueDate)
VALUES (@BorrowerID, @BookID, @BorrowDate, @DueDate)";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        cmd.Parameters.AddWithValue("@BorrowDate", DateTime.Now);  // Current date is the BorrowDate
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The book has been borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error borrowing the book. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while borrowing the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        


            private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {

            string searchQuery = txtSearchBook.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                DataTable searchResults = GetBookSearchResults(searchQuery);
                dataGridBook.DataSource = searchResults;

                // Clear book details to prevent showing outdated data
                ClearBookFields();

                // Enable BookID textbox when search results are found
                if (searchResults.Rows.Count > 0)
                {
                    txtBookID.Enabled = true; // Enable BookID textbox
                }
                else
                {
                    txtBookID.Enabled = false; // Disable the BookID textbox if no search results
                }
            }
            else
            {
                dataGridBook.DataSource = null;
                ClearBookFields();
                txtBookID.Enabled = false; // Disable the BookID textbox when search is empty
            }
        }

        private void dataGridBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the clicked row is valid
            if (e.RowIndex >= 0)
            {
                // Get the DataRow corresponding to the clicked row
                DataGridViewRow row = dataGridBook.Rows[e.RowIndex];

                // Populate the textboxes with the data from the selected row
                PopulateBookFields((row.DataBoundItem as DataRowView).Row);

                // Populate the BookID textbox
                txtBookID.Text = row.Cells["BookID"].Value.ToString();  // Populate the BookID field

                // Enable the BookID textbox when a book is selected
                txtBookID.Enabled = true;
            }
        }
        private void PopulateBookFields(DataRow book)
        {
            txtBookTitle.Text = book["BookTitle"].ToString();
            txtAuthor.Text = book["Author"].ToString();
            txtISBN.Text = book["ISBN"].ToString();
            txtCategory.Text = book["Category"].ToString();
            txtBookShelves.Text = book["BookShelves"].ToString();
            txtQuantity.Text = book["Quantity"].ToString();
            txtPrice.Text = book["Price"].ToString();
            txtLocation.Text = book["Location"].ToString();
            txtPublisher.Text = book["Publisher"].ToString();

            // Add handling for Status and PublishedDate
            txtStatus.Text = book["Status"] == DBNull.Value ? "N/A" : book["Status"].ToString();
            txtPublishedDate.Text = book["PublishedDate"] == DBNull.Value ? "Unknown" : Convert.ToDateTime(book["PublishedDate"]).ToString("yyyy-MM-dd");

            // Handle the ImageFile
            if (book["ImageFile"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])book["ImageFile"];
                if (imageBytes.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbBookImage.Image = Image.FromStream(ms);
                            pbBookImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pbBookImage.Image = null;
                    }
                }
                else
                {
                    pbBookImage.Image = null;
                }
            }
            else
            {
                pbBookImage.Image = null;
            }
        }


        private DataTable GetBookSearchResults(string searchQuery)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
SELECT BookID, ISBN, BookTitle, Author, Category, PublishedDate, Status, BookShelves, Quantity, Price, Location, Publisher, ImageFile
FROM Inventory
WHERE BookTitle LIKE @Search OR ISBN LIKE @Search OR Author LIKE @Search";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);  // Fill DataTable with the search results
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

    }
}

