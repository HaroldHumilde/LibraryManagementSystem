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
    public partial class dshBookReturn : Form
    {
        private string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        // Define a placeholder message
        private const string PlaceholderText = "Search ID";
        private bool isPlaceholderActive = true;

        private int selectedBorrowID = -1; // To store the selected BorrowID
        private string selectedSerialNumber = string.Empty; // To store the selected SerialNumber

        public dshBookReturn()
        {
            InitializeComponent();

            
        }

        private void BookReturn_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet3.BookBorrowing' table. You can move, or remove it, as needed.
            this.bookBorrowingTableAdapter.Fill(this.lmsdcsDataSet3.BookBorrowing);


            // TODO: This line of code loads data into the 'lmsdcsDataSet46.ActiveBorrowers' table. You can move, or remove it, as needed.
            this.activeBorrowersTableAdapter.Fill(this.lmsdcsDataSet46.ActiveBorrowers);
           


            // Set initial placeholder text and state
            txtSearchBorrow.Text = PlaceholderText;
            txtSearchBorrow.ForeColor = Color.Gray; // Placeholder text in gray color
            isPlaceholderActive = true;

            // Attach the events
            txtSearchBorrow.Enter += txtSearchBorrow_Enter;
            txtSearchBorrow.Leave += txtSearchBorrow_Leave;


            // Initialize the timer
            overDueCheck = new Timer();
            overDueCheck.Interval = 10000; // Check every minute (60000 ms)
            overDueCheck.Tick += overDueCheck_Tick;
            overDueCheck.Start();  // Start the timer
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
                // Query to search in ActiveBorrowers by ID (BorrowerID)
                string query = "SELECT * FROM ActiveBorrowers WHERE ID = @searchText";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchText", searchText);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the results to the DataGridView
                    dgvBorrower.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching ActiveBorrowers: " + ex.Message);
            }
        }


        private void SearchBorrowedBooksByID(string borrowerID)
        {
            if (string.IsNullOrEmpty(borrowerID))
            {
                MessageBox.Show("Please enter a Borrower ID.");
                return;
            }

            // SQL query to get the borrowed books along with BookTitle from Inventory
            // and sort the results by Status ('Borrowed' first, 'Unreturned' second, 'Returned' last)
            string query = @"
    SELECT 
        bb.BorrowID,
        bb.BorrowerID,
        bb.BookID,
        i.BookTitle,  -- Get BookTitle from Inventory
        bb.BorrowedDate,
        bb.DueDate,
        bb.Status
    FROM 
        BookBorrowing bb
    INNER JOIN 
        Inventory i 
    ON 
        bb.BookID = i.BookID
    WHERE 
        bb.BorrowerID = @BorrowerID
    ORDER BY 
        CASE 
            WHEN bb.Status = 'Borrowed' THEN 0  -- Borrowed books first
            WHEN bb.Status = 'Unreturned' THEN 1  -- Unreturned books second
            WHEN bb.Status = 'Returned' THEN 2  -- Returned books last
            ELSE 3  -- Any other statuses go last
        END";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Initialize the command with the SQL query
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add the parameter to the command
                    cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the result to the DataGridView
                    dgvBorrowedInfo.DataSource = null;  // Clear previous data
                    if (dt.Rows.Count > 0)
                    {
                        dgvBorrowedInfo.DataSource = dt;

                        // Ensure the column name is displayed correctly
                        if (dgvBorrowedInfo.Columns["BookTitle"] != null)
                        {
                            dgvBorrowedInfo.Columns["BookTitle"].HeaderText = "Book Title";
                        }
                    }
                    else
                    {
                        // Silently clear the DataGridView if no books are found
                        dgvBorrowedInfo.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving borrowed books: " + ex.Message);
            }
        }

        private void btnRetunBook_Click(object sender, EventArgs e)
        {
            if (selectedBorrowID == -1 || string.IsNullOrEmpty(selectedSerialNumber))
            {
                MessageBox.Show("Please select a book to return.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the book is already marked as "Returned"
                    string checkStatusQuery = "SELECT Status FROM BookBorrowing WHERE BorrowID = @BorrowID";
                    using (SqlCommand checkCmd = new SqlCommand(checkStatusQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@BorrowID", selectedBorrowID);
                        string currentStatus = (string)checkCmd.ExecuteScalar();

                        if (currentStatus == "Returned")
                        {
                            MessageBox.Show("This book has already been returned. No changes will be made.", "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Update the BookBorrowing status to "Returned" for the selected book
                    string updateStatusQuery = "UPDATE BookBorrowing SET Status = 'Returned' WHERE BorrowID = @BorrowID";
                    using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@BorrowID", selectedBorrowID);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Increase the book quantity in Inventory
                    IncreaseBookQuantity(selectedSerialNumber);

                    MessageBox.Show("Book returned successfully!");

                    // Refresh the borrowed books list
                    SearchBorrowedBooksByID(txtSearchBorrow.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }


        }

        private void IncreaseBookQuantity(string BookID)
        {
            // SQL query to update the book quantity in Inventory
            string query = "UPDATE Inventory SET Quantity = Quantity + 1 WHERE BookID = @BookID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookID", BookID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory: " + ex.Message);
            }
        }

        private void txtSearchBorrow_TextChanged(object sender, EventArgs e)
        {
            // Get the search input from the textbox
            string searchText = txtSearchBorrow.Text.Trim();

            // Check if the input is not empty
            if (!string.IsNullOrEmpty(searchText))
            {
                // Check if the input is numeric (for ID validation)
                bool isNumeric = int.TryParse(searchText, out int borrowerID);

                if (!isNumeric)
                {
                    // Clear results or simply do nothing if the input is not numeric
                    ClearDataGrids();
                    return; // Exit early if the input is invalid
                }

                // Perform the search for ActiveBorrowers and BookBorrowing based on the input
                SearchActiveBorrowers(searchText);
                SearchBorrowedBooksByID(searchText);
            }
            else
            {
                // Clear the DataGridViews if there's no search text
                ClearDataGrids();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure the search box has a valid ID
            string studentIDText = txtSearchBorrow.Text.Trim();

            // Check if the search textbox is empty
            if (string.IsNullOrEmpty(studentIDText))
            {
                MessageBox.Show("Please enter a Student ID to search for borrowed books.");
                return;
            }

            // Check if the ID entered is valid (numeric)
            bool isNumeric = int.TryParse(studentIDText, out int studentID);
            if (!isNumeric)
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if all books for the student are marked as "Returned"
                    string checkReturnedQuery = @"
                SELECT COUNT(*) 
                FROM BookBorrowing 
                WHERE BorrowerID = @StudentID AND Status != 'Returned'";

                    using (SqlCommand checkCmd = new SqlCommand(checkReturnedQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@StudentID", studentID);
                        int notReturnedCount = (int)checkCmd.ExecuteScalar();

                        if (notReturnedCount > 0)
                        {
                            MessageBox.Show("Not all borrowed books have been returned. You cannot delete the records until all books are returned.",
                                "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // If all books are returned, proceed to delete
                    string deleteQuery = "DELETE FROM BookBorrowing WHERE BorrowerID = @StudentID";

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@StudentID", studentID);
                        int rowsDeleted = deleteCmd.ExecuteNonQuery();

                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("All borrowed book records for this student have been deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            SearchBorrowedBooksByID(studentID.ToString());
                        }
                        else
                        {
                            MessageBox.Show("No borrowed book records were found for this student.",
                                "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting borrowed book records: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void txtSearchBorrow_Enter(object sender, EventArgs e)
        {
            if (isPlaceholderActive)
            {
                txtSearchBorrow.Text = string.Empty; // Remove placeholder text
                txtSearchBorrow.ForeColor = Color.Black; // Set the text color for user input
                isPlaceholderActive = false; // Mark placeholder as inactive
            }
        }

        private void txtSearchBorrow_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBorrow.Text)) // Check if TextBox is empty
            {
                txtSearchBorrow.Text = PlaceholderText; // Reapply placeholder text
                txtSearchBorrow.ForeColor = Color.Gray; // Set placeholder text color
                isPlaceholderActive = true; // Mark placeholder as active
            }
        }

        private void overDueCheck_Tick(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;

            // Query to find overdue books that are still borrowed
            string query = "SELECT bb.BorrowerID, bb.BookID, bb.BookTitle, bb.DueDate " +
                           "FROM BookBorrowing bb " +
                           "WHERE bb.DueDate < @currentDate AND bb.Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@currentDate", currentDate);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int borrowerID = reader.GetInt32(0); // Borrower ID
                        string serialNumber = reader[1].ToString(); // Serial number of the book
                        string bookTitle = reader.GetString(2); // Book title
                        DateTime dueDate = reader.GetDateTime(3); // Due date of the borrowed book

                        // Mark the specific borrowed book as "Unreturned"
                        MarkAsUnreturned(serialNumber);

                        // Notify the user
                        ShowOverdueNotification(borrowerID, bookTitle, dueDate);

                        // Mark the book as notified after showing the notification
                        MarkAsNotified(serialNumber);
                    }
                }
            }
        }

        // Mark book as "Unreturned" if it's still borrowed
        private void MarkAsUnreturned(string BookID)
        {
            string updateQuery = "UPDATE BookBorrowing " +
                                 "SET Status = 'Unreturned', OverdueNotified = 1 " +
                                 "WHERE BookID = @BookID AND Status = 'Borrowed'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", BookID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to mark the book as notified
        private void MarkAsNotified(string BookID)
        {
            string updateQuery = "UPDATE BookBorrowing SET OverdueNotified = 1 WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", BookID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private Queue<(int BorrowerID, string BookTitle, DateTime DueDate)> notificationQueue = new Queue<(int, string, DateTime)>();
        private bool isNotificationVisible = false;

        private void ShowOverdueNotification(int borrowerID, string bookTitle, DateTime dueDate)
        {
            // Add the notification details to the queue
            notificationQueue.Enqueue((borrowerID, bookTitle, dueDate));

            // If no notification is currently visible, start showing notifications
            if (!isNotificationVisible)
            {
                ShowNextNotification();
            }
        }

        private void ShowNextNotification()
        {
            // If there are no notifications in the queue, do nothing
            if (notificationQueue.Count == 0)
            {
                isNotificationVisible = false;
                return;
            }

            // If a notification is already visible, we wait until it's done before showing the next one
            if (isNotificationVisible)
            {
                return;
            }

            // Set flag to indicate that a notification is being displayed
            isNotificationVisible = true;

            // Dequeue the next notification details
            var (borrowerID, bookTitle, dueDate) = notificationQueue.Dequeue();

            // Retrieve the student's name based on the borrowerID
            string studentName = GetStudentNameByID(borrowerID);

            // Check if student name was found
            if (string.IsNullOrEmpty(studentName))
            {
                studentName = "Unknown Student"; // Fallback if the student name isn't found
            }

            // Load the icon image
            Icon notificationIcon = new Icon(@"C:\Users\Admin\Downloads\notificatio.ico.ico");

            // Create a new PopupNotifier
            PopupNotifier overdueNotification = new PopupNotifier
            {
                TitleText = "Book Overdue",
                ContentText = $"(ID: {borrowerID}) \nName: {studentName}  \nUnreturned Book: '{bookTitle}' \nDue date ({dueDate.ToShortDateString()}).",
                BodyColor = Color.White,
                TitleColor = Color.Red,
                ContentColor = Color.Black,
                IsRightToLeft = false,
                ShowCloseButton = true,
                ShowGrip = true,
                Image = notificationIcon.ToBitmap(),
                Delay = 10000 // Set notification duration to 10 seconds (in milliseconds)
            };

            // Timer to close the notification after 10 seconds
            Timer timer = new Timer { Interval = 10000 };

            // Event handler to close the notification and show the next one
            timer.Tick += (s, e) =>
            {
                overdueNotification.Hide(); // Hide the notification
                timer.Stop(); // Stop the timer
                timer.Dispose(); // Dispose the timer

                // Once the current notification has been closed, we show the next one
                isNotificationVisible = false;

                // Show the next notification in the queue
                ShowNextNotification();
            };

            // Display the notification
            overdueNotification.Popup();

            // Start the timer
            timer.Start();
        }

        // Method to retrieve the student's name by ID
        private string GetStudentNameByID(int borrowerID)
        {
            string studentName = string.Empty;

            // SQL query to retrieve student's name by ID
            string query = "SELECT Firstname + ' ' + Lastname FROM ActiveBorrowers WHERE ID = @BorrowerID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);  // Use BorrowerID for the parameter

                    // Open the connection to the database
                    conn.Open();

                    // Execute the query and get the student's name
                    studentName = cmd.ExecuteScalar()?.ToString();

                    // If the result is null, set a fallback name
                    if (string.IsNullOrEmpty(studentName))
                    {
                        studentName = "Unknown Student";
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return studentName;
        }

        private void dgvBorrowedInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvBorrowedInfo.Rows[e.RowIndex];

                selectedBorrowID = Convert.ToInt32(row.Cells["BorrowID"].Value); // BorrowID column
                selectedSerialNumber = row.Cells["BookID"].Value.ToString(); // SerialNumber column
            }
        }
    }
}
