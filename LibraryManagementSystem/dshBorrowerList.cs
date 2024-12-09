using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;


namespace LibraryManagementSystem
{
    public partial class dshBorrowerList : Form
    {
        private string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        private PopupNotifier pnDueDate; // Declare once at the class level
        private Queue<(int BorrowerID, string BookTitle, DateTime DueDate)> notificationQueue = new Queue<(int, string, DateTime)>();
        private bool isNotificationVisible = false;


        // Declare this at the class level, outside of any method
        private HashSet<string> notifiedBooks = new HashSet<string>();


        private int selectedBorrowID = -1;
        private string selectedBookID = string.Empty;


        public dshBorrowerList()
        {
            InitializeComponent();


        }

        private void BorrowerList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet11.BookBorrowing' table. You can move, or remove it, as needed.
            this.bookBorrowingTableAdapter.Fill(this.lmsdcsDataSet11.BookBorrowing);
            // TODO: This line of code loads data into the 'lmsdcsDataSet10.ActiveBorrowers' table. You can move, or remove it, as needed.
            this.activeBorrowersTableAdapter.Fill(this.lmsdcsDataSet10.ActiveBorrowers);


            StartOverdueCheck();  // Start checking for unreturned books periodically
            LoadStudentsWithBorrowedOrUnreturnedBooks();

        }

        private void dtgBorrower_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgBorrowed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid row
            if (e.RowIndex >= 0)
            {
                // Get the BorrowID and BookID from the selected row
                selectedBorrowID = Convert.ToInt32(dtgBorrowed.Rows[e.RowIndex].Cells["BorrowID"].Value);
                selectedBookID = dtgBorrowed.Rows[e.RowIndex].Cells["BookID"].Value.ToString();

                // Optionally, display the selected book's details (for debugging or confirmation)
                MessageBox.Show($"Selected Book: {selectedBookID} with BorrowID: {selectedBorrowID}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dtgBorrower.DataSource = null;
                dtgBorrowed.DataSource = null;
                return;
            }

            string searchQuery = txtSearch.Text;
            DataTable studentResults = GetStudentSearchResults(searchQuery);

            if (studentResults.Rows.Count > 0)
            {
                dtgBorrower.AutoGenerateColumns = true;
                dtgBorrower.DataSource = studentResults;

                string borrowerID = studentResults.Rows[0]["ID"].ToString();
                DataTable borrowedBooks = GetBorrowedBooks(borrowerID);

                dtgBorrowed.AutoGenerateColumns = true;
                dtgBorrowed.DataSource = borrowedBooks;
            }
            else
            {
                dtgBorrower.DataSource = null;
                dtgBorrowed.DataSource = null;
                MessageBox.Show("No matching records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private DataTable GetStudentSearchResults(string searchQuery)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                SELECT DISTINCT
                    ab.ID, 
                    ab.StudentNumber, 
                    ab.Firstname,
                    ab.Middlename,
                    ab.Lastname,
                    ab.Age, 
                    ab.Gender, 
                    ab.Year, 
                    ab.Section
                FROM ActiveBorrowers ab
                INNER JOIN BookBorrowing bb ON ab.ID = bb.BorrowerID
                WHERE (ab.Firstname LIKE @Search OR ab.Lastname LIKE @Search)
                  AND (bb.Status = 'Borrowed' OR bb.Status = 'Unreturned')";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }



        private DataTable GetBorrowedBooks(string borrowerID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                SELECT 
                    bb.BorrowID,
                    bb.BookID, 
                    bb.BorrowedDate,
                    bb.BookTitle,
                    bb.DueDate, 
                    bb.Status
                FROM BookBorrowing bb
                WHERE bb.BorrowerID = @BorrowerID
                  AND (bb.Status = 'Borrowed' OR bb.Status = 'Unreturned')";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BorrowerID", borrowerID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving borrowed books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private void LoadStudentsWithBorrowedOrUnreturnedBooks()
        {
            DataTable studentResults = GetStudentsWithBorrowedOrUnreturnedBooks();
            if (studentResults.Rows.Count > 0)
            {
                dtgBorrower.AutoGenerateColumns = true;
                dtgBorrower.DataSource = studentResults;
            }
            else
            {
                dtgBorrower.DataSource = null;
                MessageBox.Show("No students with borrowed or unreturned books found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable GetStudentsWithBorrowedOrUnreturnedBooks()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                SELECT DISTINCT
                    ab.ID, 
                    ab.StudentNumber, 
                    ab.Firstname,
                    ab.Middlename,
                    ab.Lastname,
                    ab.Age, 
                    ab.Gender, 
                    ab.Year, 
                    ab.Section
                FROM ActiveBorrowers ab
                INNER JOIN BookBorrowing bb ON ab.ID = bb.BorrowerID
                WHERE bb.Status = 'Borrowed' OR bb.Status = 'Unreturned'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Check if a book has been selected
            if (selectedBorrowID == -1 || string.IsNullOrEmpty(selectedBookID))
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

                    // Update the status of the book to "Returned"
                    string updateStatusQuery = "UPDATE BookBorrowing SET Status = 'Returned' WHERE BorrowID = @BorrowID";
                    using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@BorrowID", selectedBorrowID);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Optionally, increase the book quantity in the inventory
                    IncreaseBookQuantity(selectedBookID);

                    MessageBox.Show("Book returned successfully!");

                    // Refresh the borrowed books list
                    RefreshBorrowedBooksList();

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }
        }

        private void IncreaseBookQuantity(string BookID)
        {
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
        private void RefreshBorrowedBooksList()
        {
            if (dtgBorrower.SelectedRows.Count > 0)
            {
                // Get the selected Borrower's ID
                string borrowerID = dtgBorrower.SelectedRows[0].Cells["ID"].Value.ToString();

                // Fetch the borrowed books of the selected borrower
                DataTable borrowedBooks = GetBorrowedBooks(borrowerID);
                dtgBorrowed.DataSource = borrowedBooks;
            }
            else
            {
                dtgBorrowed.DataSource = null;
            }
        }

        private void CheckUnreturnedBooks()
        {
            // Current date to check against due dates
            DateTime currentDate = DateTime.Now;

            // Query to find books with "Unreturned" status
            string query = "SELECT bb.BorrowerID, bb.BookID, bb.BookTitle, bb.DueDate " +
                           "FROM BookBorrowing bb " +
                           "WHERE bb.Status = 'Unreturned'"; // Adjust this query based on your actual database structure

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Retrieve data from the query result
                        int borrowerID = reader.GetInt32(0); // Borrower ID
                        string bookID = reader.GetString(1); // Book ID
                        string bookTitle = reader.GetString(2); // Book Title
                        DateTime dueDate = reader.GetDateTime(3); // Due Date
                        string firstName = reader.GetString(4); // First name of borrower (assuming it's available)
                        string lastName = reader.GetString(5); // Last name of borrower (assuming it's available)

                        // Display the notification for the unreturned book, passing the BookID to track it
                        ShowNotification(borrowerID.ToString(), firstName, lastName, bookTitle, dueDate, bookID);
                    }
                }
            }
        }




        private void ShowNotification(string studentNumber, string firstName, string lastName, string bookTitle, DateTime dueDate, string bookID)
        {
            // Check if the notification for this book has already been shown
            if (notifiedBooks.Contains(bookID))
            {
                return;  // Exit the method if the book has already been notified
            }

            // Add the book ID to the set to prevent future notifications
            notifiedBooks.Add(bookID);

            // Create a new PopupNotifier
            PopupNotifier popup = new PopupNotifier
            {
                TitleText = "Unreturned Book Notification",
                ContentText = $"Student Number: {studentNumber}\nName: {firstName} {lastName}\nBook: {bookTitle}\nDue Date: {dueDate.ToShortDateString()}",
                BodyColor = Color.White,
                TitleColor = Color.Red,
                ContentColor = Color.Black,
                IsRightToLeft = false,
                ShowCloseButton = true,
                ShowGrip = true,
                Delay = 5000, // Show the notification for 5 seconds
            };

            // Optional: You can add an icon to the notification (example below)
            try
            {
                string iconPath = @"C:\Users\Admin\Downloads\AlertIcon.ico"; // Path to your icon
                Icon notificationIcon = new Icon(iconPath);
                popup.Image = notificationIcon.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading icon: " + ex.Message, "Icon Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show the notification
            popup.Popup();
        }


        // Call this method to initiate the overdue check (you can use a timer to call it periodically)
        private void StartOverdueCheck()
        {
            // Example to call CheckUnreturnedBooks periodically (every 5 seconds here)
            Timer overdueCheckTimer = new Timer();
            overdueCheckTimer.Tick += (sender, e) => CheckUnreturnedBooks();
            overdueCheckTimer.Interval = 5000; // Interval of 5 seconds (adjust as needed)
            overdueCheckTimer.Start();
        }



    } 
}
