using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.IO;


namespace LibraryManagementSystem
{
    public partial class dshBorrower : Form
    {


        private string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private const string SearchPlaceholderText = "Search Student Number, Name";
        private bool isSearchPlaceholderActive = true;

        public dshBorrower()
        {
            InitializeComponent();
        }



        private void dshBorrower_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet2.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet2.Inventory);
            // TODO: This line of code loads data into the 'lmsdcsDataSet1.BookBorrowing' table. You can move, or remove it, as needed.
            this.bookBorrowingTableAdapter1.Fill(this.lmsdcsDataSet1.BookBorrowing);

            pnlAddBook.Visible = false;

            // Set the placeholder text
            txtBookSearch.Text = "Search Book";
            txtBookSearch.ForeColor = Color.Gray; // Set color to gray for placeholder



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

            // If the search box is empty, clear both student and book details, and clear the PictureBox
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ClearStudentFields();  // Clear student fields
                dataGridView1.DataSource = null;  // Clear book borrowing history (data grid)
                pictureProfile.Image = null;  // Clear the PictureBox (no image)
                return;
            }

            // Get the search query from txtSearch
            string searchQuery = txtSearch.Text;

            // Search for the student based on the query (e.g., student name or ID)
            DataTable studentResults = GetStudentSearchResults(searchQuery);

            // If student results are found, populate student fields and show borrowed books
            if (studentResults.Rows.Count > 0)
            {
                // Populate student fields with the first result
                PopulateStudentFields(studentResults.Rows[0]);

                // Get borrowed books for the found student
                string borrowerID = studentResults.Rows[0]["ID"].ToString(); // Assuming the column name for student ID is "ID"
                DataTable borrowedBooks = GetBorrowedBooks(borrowerID);

                // Show the borrowed books in the DataGridView
                dataGridView1.DataSource = borrowedBooks;
            }
            else
            {
                // If no student is found, clear student fields and perform book search
                ClearStudentFields();

                // Set the DataGridView to show nothing when no student is found
                dataGridView1.DataSource = null;
            }
        }

        // Method to get the student search results from the database
        private DataTable GetStudentSearchResults(string searchQuery)
        {
            DataTable dt = new DataTable();

            // Your connection string
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Search query to search students by Firstname, Lastname, or StudentNumber
                    string query = @"
            SELECT ID, StudentNumber, Firstname, Middlename, Lastname, Gender, Year, Section, ProfileImage
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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }



        // Helper method to populate student fields and the profile image
        private void PopulateStudentFields(DataRow studentRow)
        {
            txtStudentNumber.Text = studentRow["StudentNumber"].ToString();
            txtFirstName.Text = studentRow["Firstname"].ToString();
            txtMiddleName.Text = studentRow["Middlename"].ToString();
            txtLastName.Text = studentRow["Lastname"].ToString();
            txtGender.Text = studentRow["Gender"].ToString();
            txtYear.Text = studentRow["Year"].ToString();
            txtSection.Text = studentRow["Section"].ToString();
            txtID.Text = studentRow["ID"].ToString();

            // Load the student's profile image into the PictureBox (if available)
            if (studentRow["ProfileImage"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])studentRow["ProfileImage"];  // Convert the byte array to an image
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image img = Image.FromStream(ms);  // Load the image from the byte array

                    // Set the image to fit the PictureBox while maintaining aspect ratio
                    pictureProfile.Image = img;
                    pictureProfile.SizeMode = PictureBoxSizeMode.Zoom;  // Adjust the size mode if necessary
                    pictureProfile.Size = new Size(192, 192);  // Set PictureBox size to 192x192 (or desired size)
                }
            }
            else
            {
                // If no image is available, clear the PictureBox
                pictureProfile.Image = null;
            }
        }


        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            // If the search box is empty (or has placeholder text), clear the book-related textboxes
            if (string.IsNullOrWhiteSpace(txtBookSearch.Text) || txtBookSearch.Text == "Search for a book...")
            {
                ClearBookFields();  // Clear book-related fields
                return;
            }

            // Get the search query from txtSearchBook
            string searchQuery = txtBookSearch.Text;

            // Fetch book details from the database based on the search query
            DataTable bookResults = GetBookSearchResults(searchQuery);

            // Bind the search results to the DataGridView (dtgBooks)
            dtgBooks.DataSource = bookResults;

            // If book results are found, populate textboxes and image
            if (bookResults.Rows.Count > 0)
            {
                PopulateBookFields(bookResults.Rows[0]);  // Populate fields with the first result
            }
            else
            {
                // Clear book fields if no book is found
                ClearBookFields();
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

                    // Modified query to exclude borrowed books with a quantity of 0
                    string query = @"
                SELECT i.BookID, i.BookTitle, i.ISBN, i.Author, i.Category, i.BookShelves, i.Quantity, i.ImageFile
                FROM Inventory i
                WHERE (i.BookID LIKE @Search OR i.BookTitle LIKE @Search OR i.Author LIKE @Search OR i.ISBN LIKE @Search)
                  AND i.Quantity > 0
                  AND i.BookID NOT IN (SELECT bb.BookID FROM BookBorrowing bb WHERE bb.Status = 'Unreturned')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        private void PopulateBookFields(DataRow bookData)
        {
            txtBookTitle.Text = bookData["BookTitle"].ToString();
            txtISBN.Text = bookData["ISBN"].ToString();
            txtAuthor.Text = bookData["Author"].ToString();
            txtCategory.Text = bookData["Category"].ToString();
            txtBookShelves.Text = bookData["BookShelves"].ToString();
            txtQuantity.Text = bookData["Quantity"].ToString();
            txtSerialNumber.Text = bookData["BookID"].ToString();

            // Ensure the PictureBox has the correct size and SizeMode set
            PictureBook.Size = new Size(192, 192);
            PictureBook.SizeMode = PictureBoxSizeMode.Zoom;

            // Check if the ImageFile column is not DBNull
            if (bookData["ImageFile"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])bookData["ImageFile"];  // Convert the byte array to an image
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image img = Image.FromStream(ms);  // Load the image from the byte array

                    // Set the image to fit the PictureBox while maintaining aspect ratio
                    PictureBook.Image = img;
                }
            }
            else
            {
                // If no image is available, clear the PictureBox
                PictureBook.Image = null;
            }
        }
        // Method to load the book image into the PictureBox
        private void LoadBookImage(string imageFilePath)
        {
            try
            {
                // Check if the image path is valid
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    // If the file exists, load the image
                    if (File.Exists(imageFilePath))
                    {
                        PictureBook.Image = Image.FromFile(imageFilePath);  // Load image from file path
                    }
                    else
                    {
                        MessageBox.Show($"Image not found at the path: {imageFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PictureBook.Image = null;  // Clear the image if path is invalid
                    }
                }
                else
                {
                    MessageBox.Show("The image file path is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PictureBook.Image = null;  // Clear the image if the path is empty
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., file access issues)
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PictureBook.Image = null;  // Clear the picture box on error
            }
        }



        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            string BookID = txtSerialNumber.Text.Trim();

            // Try to parse borrowerID safely
            if (!int.TryParse(txtID.Text.Trim(), out int borrowerID))
            {
                MessageBox.Show("Invalid student ID. Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if parsing fails
            }

            // Check if the Serial Number textbox is empty
            if (string.IsNullOrEmpty(BookID))
            {
                MessageBox.Show("Input a book to borrow.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent further execution
            }

            // Check if the borrower has any unreturned books
            if (HasUnreturnedBooks(borrowerID))
            {
                MessageBox.Show("You cannot borrow a new book until you return your overdue books.", "Borrowing Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Check if the student has already borrowed the same book
            if (HasAlreadyBorrowedBook(borrowerID, BookID))
            {
                MessageBox.Show("You have already borrowed this book.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Check if the student has reached the borrowing limit (2 books)
            if (HasReachedBorrowLimit(borrowerID))
            {
                MessageBox.Show("You have reached the limit of borrowing two books. Please return a book before borrowing more.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Fetch the book title from the Inventory table (ensure that this doesn't return null or empty)
            string bookTitle = GetBookTitle(BookID);
            if (string.IsNullOrEmpty(bookTitle))
            {
                MessageBox.Show("Book not found or invalid serial number.", "Invalid Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check the current book quantity before allowing borrowing
            int currentQuantity = GetBookQuantity(BookID);
            if (currentQuantity <= 0)
            {
                MessageBox.Show("No books available for borrowing.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Prevent borrowing if quantity is 0 or less
            }

            // Set status based on borrowing date
            string status = DateTime.Now.Date == DateTime.Now.Date ? "Unreturned" : "Borrowed"; // If borrowed today, status is Unreturned

            // Calculate the due date and adjust it to skip weekends
            DateTime borrowedDate = DateTime.Now;  // Current date when the book is borrowed
            DateTime adjustedDueDate = borrowedDate.AddDays(7); // Example: due date is 7 days after borrowing
            DateTime finalDueDate = GetDueDateSkippingWeekends(adjustedDueDate); // Skip weekends

            // SQL query to insert a borrowing record
            string query = "INSERT INTO BookBorrowing (BorrowerID, BookID, BookTitle, Status, BorrowedDate, DueDate) " +
                           "VALUES (@BorrowerID, @BookID, @BookTitle, @Status, @BorrowedDate, @DueDate)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                    cmd.Parameters.AddWithValue("@BookID", BookID);
                    cmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@BorrowedDate", borrowedDate);
                    cmd.Parameters.AddWithValue("@DueDate", finalDueDate); // Use the adjusted due date

                    // Open the connection to the database
                    conn.Open();

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Decrease the quantity in the Inventory after successful borrowing
                        DecreaseBookQuantity(BookID);

                        MessageBox.Show("Book borrowed successfully!");
                        ClearBookFields();  // Clear book fields after borrowing
                        ClearStudentFields(); // Clear student fields if needed
                    }
                    else
                    {
                        MessageBox.Show("Failed to borrow book.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Method to check if the borrower has any unreturned books
        private bool HasUnreturnedBooks(int borrowerID)
        {
            string query = "SELECT COUNT(*) FROM BookBorrowing WHERE BorrowerID = @BorrowerID AND Status = 'Unreturned'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // If count > 0, the borrower has unreturned books
            }
        }

        // Method to check if the student has already borrowed the same book
        private bool HasAlreadyBorrowedBook(int borrowerID, string BookID)
        {
            string query = "SELECT COUNT(*) FROM BookBorrowing WHERE BorrowerID = @BorrowerID AND BookID = @BookID AND Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                cmd.Parameters.AddWithValue("@BookID", BookID);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // If count > 0, the student has already borrowed the book
            }
        }


        // Method to check if the student has reached the borrowing limit (2 books)
        private bool HasReachedBorrowLimit(int borrowerID)
        {
            string query = "SELECT COUNT(*) FROM BookBorrowing WHERE BorrowerID = @BorrowerID AND Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count >= 2; // If count >= 2, the student has already borrowed 2 books
            }
        }

        // Method to check if the student can borrow after returning books
        private bool CanBorrowAfterReturn(int borrowerID)
        {
            string query = "SELECT COUNT(*) FROM BookBorrowing WHERE BorrowerID = @BorrowerID AND Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count == 0; // If count == 0, the student has returned all borrowed books
            }
        }

        // Modify DecreaseBookQuantity to accept serialNumber as a parameter
        private void DecreaseBookQuantity(string serialNumber)
        {
            try
            {
                // Use the correct parameter name 'serialNumber' in the method body
                int currentQuantity = GetBookQuantity(serialNumber);
                if (currentQuantity > 0)
                {
                    int newQuantity = currentQuantity - 1;
                    UpdateBookQuantity(serialNumber, newQuantity);
                }
                else
                {
                    MessageBox.Show("No books available for borrowing.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book quantity: " + ex.Message);
            }
        }

        // Method to get the current quantity of the book from the Inventory
        private int GetBookQuantity(string serialNumber)
        {
            int quantity = 0;

            string query = "SELECT Quantity FROM Inventory WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", serialNumber);
                conn.Open();

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    quantity = Convert.ToInt32(result);
                }
            }

            return quantity;
        }

        // Method to update the book quantity in the Inventory
        private void UpdateBookQuantity(string serialNumber, int newQuantity)
        {
            string query = "UPDATE Inventory SET Quantity = @Quantity WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                cmd.Parameters.AddWithValue("@BookID", serialNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }








        // Method to clear all book-related fields and picture box
        private void ClearBookFields()
        {
            txtBookTitle.Clear();
            txtISBN.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtBookShelves.Clear();
            txtQuantity.Clear();
            txtSerialNumber.Clear();
            PictureBook.Image = null;  // Clear the picture box
        }


        // Method to clear student fields when no result is found
        private void ClearStudentFields()
        {
            txtStudentNumber.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtGender.Clear();
            txtYear.Clear();
            txtSection.Clear();
            txtID.Clear();
        }

        private void btnShowSearchButton_Click(object sender, EventArgs e)
        {
            // Check if the student information (e.g., txtID) is filled in
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                MessageBox.Show("Fill the textbox with information to add a book.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without toggling the panel if the textbox is empty
            }

            // Toggle visibility of pnlAddBook 
            pnlAddBook.Visible = !pnlAddBook.Visible;  // Toggles visibility

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide the pnlAddBook panel when the back button is clicked
            pnlAddBook.Visible = false;
        }

        // Method to fetch the Book Title from Inventory
        private string GetBookTitle(string BookID)
        {
            string bookTitle = string.Empty;
            string query = "SELECT BookTitle FROM Inventory WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", BookID);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    bookTitle = result.ToString();
                }
            }
            return bookTitle;
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

        private void txtBookSearch_Leave(object sender, EventArgs e)
        {
            // If the user hasn't entered any text, restore the placeholder
            if (string.IsNullOrWhiteSpace(txtBookSearch.Text))
            {
                txtBookSearch.Text = "Search Book";
                txtBookSearch.ForeColor = Color.Gray; // Set color to gray for placeholder text
            }
        }

        private void txtBookSearch_Enter(object sender, EventArgs e)
        {
            // If the placeholder text is there, clear it when focusing
            if (txtBookSearch.Text == "Search Book" && txtBookSearch.ForeColor == Color.Gray)
            {
                txtBookSearch.Text = "";
                txtBookSearch.ForeColor = Color.Black;  // Change the text color to black for user input
            }
        }


        private DataTable GetBorrowedBooks(string borrowerID)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Include Status in the SELECT query
                    string query = @"
            SELECT bb.BookID, bb.BookTitle, bb.BorrowedDate, bb.DueDate, bb.Status
            FROM BookBorrowing bb
            WHERE bb.BorrowerID = @BorrowerID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);  // Fill the DataTable with the results
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching borrowed books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        // Method to get the due date while skipping weekends (Saturday and Sunday)
        private DateTime GetDueDateSkippingWeekends(DateTime initialDate)
        {
            // Check if the initial due date falls on a weekend (Saturday or Sunday)
            if (initialDate.DayOfWeek == DayOfWeek.Saturday)
            {
                // If it's Saturday, set the due date to the next Monday
                return initialDate.AddDays(2); // Skip to Monday
            }
            else if (initialDate.DayOfWeek == DayOfWeek.Sunday)
            {
                // If it's Sunday, set the due date to the next Monday
                return initialDate.AddDays(1); // Skip to Monday
            }
            else
            {
                // If it's a weekday, return the same date
                return initialDate;
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is selected
            if (e.RowIndex >= 0)
            {
                // Get the selected book's information from the DataGridView
                DataGridViewRow selectedRow = dtgBooks.Rows[e.RowIndex];

                // Extract book details from the selected row
                string bookID = selectedRow.Cells["BooksID"].Value.ToString();
                string bookTitle = selectedRow.Cells["BooksTitle"].Value.ToString();
                string isbn = selectedRow.Cells["ISBN"].Value.ToString();
                string author = selectedRow.Cells["Author"].Value.ToString();
                string category = selectedRow.Cells["Category"].Value.ToString();
                string bookShelves = selectedRow.Cells["BookShelves"].Value.ToString();
                string quantity = selectedRow.Cells["Quantity"].Value.ToString();
                byte[] imageBytes = (byte[])selectedRow.Cells["ImageFile"].Value;  // Get the image data as a byte array

                // Update the book details fields
                txtBookTitle.Text = bookTitle;
                txtISBN.Text = isbn;
                txtAuthor.Text = author;
                txtCategory.Text = category;
                txtBookShelves.Text = bookShelves;
                txtQuantity.Text = quantity;

                // Load and display the book's image in the PictureBox (if the image exists)
                try
                {
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        // Convert byte[] to Image and display in the PictureBox
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            PictureBook.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Clear image if no image is found
                        PictureBook.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors (e.g., file access issues)
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PictureBook.Image = null;  // Clear image on error
                }
            }
        
        }

        private void PictureBook_Click(object sender, EventArgs e)
        {
        }
    }
}
