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
using Tulpep.NotificationWindow;


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

            // If the search box is empty, clear the student fields
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ClearStudentFields();  // Clear student fields
                return;
            }

            // Get the search query from txtSearch
            string searchQuery = txtSearch.Text;

            // Fetch student details from the database based on the search query
            DataTable studentResults = GetStudentSearchResults(searchQuery);

            // If student results are found, populate textboxes
            if (studentResults.Rows.Count > 0)
            {
                PopulateStudentFields(studentResults.Rows[0]);  // Populate fields with the first result
            }
            else
            {
                // Clear student fields if no student is found
                ClearStudentFields();
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
                SELECT ID, StudentNumber, Firstname, Middlename, Lastname, Gender, Year, Section
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


        // Method to populate the student fields (textboxes)
        private void PopulateStudentFields(DataRow studentData)
        {
            txtID.Text = studentData["ID"].ToString();
            txtStudentNumber.Text = studentData["StudentNumber"].ToString();
            txtFirstName.Text = studentData["Firstname"].ToString();
            txtMiddleName.Text = studentData["Middlename"].ToString();
            txtLastName.Text = studentData["Lastname"].ToString();
            txtGender.Text = studentData["Gender"].ToString();
            txtYear.Text = studentData["Year"].ToString();
            txtSection.Text = studentData["Section"].ToString();
            
        }

        private void dataGridSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            // If book results are found, populate textboxes
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
            // Method to get book search results from the database
            private DataTable GetBookSearchResults(string searchQuery)
            {
                DataTable dt = new DataTable();

                // Your connection string
                string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Search query to search books by Title, Author, or ISBN
                        string query = @"
                SELECT SerialNumber, BookTitle, ISBN, Author, Category, BookShelves, Quantity
                FROM Inventory
                WHERE SerialNumber LIKE @Search OR BookTitle LIKE @Search OR Author LIKE @Search OR ISBN LIKE @Search";

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
        

        // Method to populate the book fields (textboxes)
        private void PopulateBookFields(DataRow bookData)
        {
            
            txtBookTitle.Text = bookData["BookTitle"].ToString();
            txtISBN.Text = bookData["ISBN"].ToString();
            txtAuthor.Text = bookData["Author"].ToString();
            txtCategory.Text = bookData["Category"].ToString();
            txtBookShelves.Text = bookData["BookShelves"].ToString();
            txtQuantity.Text = bookData["Quantity"].ToString();
            txtSerialNumber.Text = bookData["SerialNumber"].ToString();

        }

       

        private void btnOpenBookPanel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSerialNumber.Text.Trim();

            // Try to parse borrowerID safely
            if (!int.TryParse(txtID.Text.Trim(), out int borrowerID))
            {
                MessageBox.Show("Invalid student ID. Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if parsing fails
            }

            // Check if the Serial Number textbox is empty
            if (string.IsNullOrEmpty(serialNumber))
            {
                MessageBox.Show("Input a book to borrow.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent further execution
            }

            // Check if the student has already borrowed the same book
            if (HasAlreadyBorrowedBook(borrowerID, serialNumber))
            {
                MessageBox.Show("You have already borrowed this book.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Check if the student has reached the borrowing limit (2 books) and if all previous books are returned
            if (HasReachedBorrowLimit(borrowerID) && !CanBorrowAfterReturn(borrowerID))
            {
                MessageBox.Show("You have reached the limit of borrowing two books. Please return a book before borrowing more.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Fetch the book title from the Inventory table (ensure that this doesn't return null or empty)
            string bookTitle = GetBookTitle(serialNumber);
            if (string.IsNullOrEmpty(bookTitle))
            {
                MessageBox.Show("Book not found or invalid serial number.", "Invalid Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check the current book quantity before allowing borrowing
            int currentQuantity = GetBookQuantity(serialNumber);
            if (currentQuantity <= 0)
            {
                MessageBox.Show("No books available for borrowing.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Prevent borrowing if quantity is 0 or less
            }

            string status = "Borrowed"; // Status when the book is borrowed

            // SQL query to insert a borrowing record
            string query = "INSERT INTO BookBorrowing (BorrowerID, SerialNumber, BookTitle, Status, BorrowedDate, DueDate) " +
                           "VALUES (@BorrowerID, @SerialNumber, @BookTitle, @Status, @BorrowedDate, @DueDate)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@BorrowedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);

                    // Open the connection to the database
                    conn.Open();

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Decrease the quantity in the Inventory after successful borrowing
                        DecreaseBookQuantity(serialNumber);

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

        

        // Method to check if the student has already borrowed the same book
        private bool HasAlreadyBorrowedBook(int borrowerID, string serialNumber)
        {
            string query = "SELECT COUNT(*) FROM BookBorrowing WHERE BorrowerID = @BorrowerID AND SerialNumber = @SerialNumber AND Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
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

            string query = "SELECT Quantity FROM Inventory WHERE SerialNumber = @SerialNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
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
            string query = "UPDATE Inventory SET Quantity = @Quantity WHERE SerialNumber = @SerialNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        


        



        // Method to clear book fields when no result is found
        private void ClearBookFields()
        {
            txtBookTitle.Clear();
            txtISBN.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtBookShelves.Clear();
            txtQuantity.Clear();
            txtSerialNumber.Clear();

            
            dtpDueDate.Value = DateTime.Now;  // Reset to the current date


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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
        private string GetBookTitle(string serialNumber)
        {
            string bookTitle = string.Empty;
            string query = "SELECT BookTitle FROM Inventory WHERE SerialNumber = @SerialNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
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


       



        
       
    }
}
