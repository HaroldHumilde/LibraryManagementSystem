using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagementSystem
{


    public partial class dshInvoice : Form
    {

        private string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        private bool isSearchPlaceholderActive = false;


        public dshInvoice()
        {
            InitializeComponent();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {



            /*  // Get user input from the textboxes
              string name = txtStudentName.Text.Trim();
              string studentNumber = txtStudentNumber.Text.Trim();
              string book1 = txtBookTitleOne.Text.Trim();
              string book2 = txtBookTitleTwo.Text.Trim();
              string price1 = txtPriceOne.Text.Trim();
              string price2 = txtPriceTwo.Text.Trim();
              string librarianName = txtLibrarianName.Text.Trim(); // Get librarian's name from the textbox

              // Validate input fields
              if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentNumber) ||
                  string.IsNullOrEmpty(book1) || string.IsNullOrEmpty(price1))
              {
                  MessageBox.Show("Please fill all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }

              try
              {
                  // Use the Singleton Instance to generate the invoice
                  string filePath = InvoicePrinter.Instance.GenerateInvoice(name, studentNumber, book1, book2, price1, price2, librarianName);

                  // Notify the user
                  MessageBox.Show($"Invoice successfully generated at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  // Optionally, open the generated PDF
                  System.Diagnostics.Process.Start(filePath);

                  // Print the generated PDF
                  InvoicePrinter.Instance.PrintInvoice(filePath);
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error generating or printing the invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
          }*/

            // Get user input from the textboxes
            string name = txtFullName.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string book1 = txtBookTitleOne.Text.Trim();
            string book2 = txtBookTitleTwo.Text.Trim();
            string price1 = txtPriceOne.Text.Trim();
            string price2 = txtPriceTwo.Text.Trim();
            string librarianName = txtLibrarianName.Text.Trim(); // Get librarian's name from the textbox

            // Validate if all required fields are filled
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentNumber) ||
                string.IsNullOrEmpty(book1) || string.IsNullOrEmpty(price1) ||
                string.IsNullOrEmpty(librarianName))
            {
                MessageBox.Show("Please fill all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the Student Name (only letters and spaces)
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Please enter letters only in the Student Name field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if validation fails
                }
            }

            // Validate the Student Number (only digits)
            foreach (char c in studentNumber)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Please enter numbers only in the Student Number field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if validation fails
                }
            }

            // Validate Book Title One (only letters and spaces)
            foreach (char c in book1)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Please enter letters only in the Book Title field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if validation fails
                }
            }

            // Validate Book Title Two (only letters and spaces)
            if (!string.IsNullOrEmpty(book2))
            {
                foreach (char c in book2)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        MessageBox.Show("Please enter letters only in the Book Title field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop further execution if validation fails
                    }
                }
            }

            // Validate Price One (only digits and a decimal point)
            foreach (char c in price1)
            {
                if (!(char.IsDigit(c) || c == '.' || c == ','))
                {
                    MessageBox.Show("Please enter valid numbers only in the Price fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if validation fails
                }
            }

            // Validate Price Two (only digits and a decimal point)
            if (!string.IsNullOrEmpty(price2))
            {
                foreach (char c in price2)
                {
                    if (!(char.IsDigit(c) || c == '.' || c == ','))
                    {
                        MessageBox.Show("Please enter valid numbers only in the Price fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop further execution if validation fails
                    }
                }
            }

            // Validate Librarian Name (only letters and spaces)
            foreach (char c in librarianName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Please enter letters only in the Librarian Name field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if validation fails
                }
            }

            try
            {
                // Use the Singleton Instance to generate the invoice
                string filePath = InvoicePrinter.Instance.GenerateInvoice(name, studentNumber, book1, book2, price1, price2, librarianName);

                // Notify the user
                MessageBox.Show($"Invoice successfully generated at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, open the generated PDF
                System.Diagnostics.Process.Start(filePath);

                // Print the generated PDF
                InvoicePrinter.Instance.PrintInvoice(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating or printing the invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dshInvoice_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'lmsdcsDataSet5.BookBorrowing' table. You can move, or remove it, as needed.
            this.bookBorrowingTableAdapter.Fill(this.lmsdcsDataSet5.BookBorrowing);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Skip search if placeholder is active
            if (isSearchPlaceholderActive)
                return;

            // If the search box is empty, clear all fields
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ClearFields();
                dtgInvoice.DataSource = null; // Clear book borrowing history (data grid)
                return;
            }

            // Get the search query from txtSearch
            string searchQuery = txtSearch.Text;

            // Search for the student
            DataTable studentResults = GetStudentSearchResults(searchQuery);

            if (studentResults.Rows.Count > 0)
            {
                // Populate student fields with the first result
                PopulateStudentFields(studentResults.Rows[0]);

                // Get borrowed books for the student
                string borrowerID = studentResults.Rows[0]["ID"].ToString();
                DataTable borrowedBooks = GetBorrowedBooks(borrowerID);

                // Display borrowed books in the DataGridView
                dtgInvoice.DataSource = borrowedBooks;

                // Add the Price column dynamically (if it does not already exist)
                if (!dtgInvoice.Columns.Contains("Price"))
                {
                    DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
                    priceColumn.Name = "Price";
                    priceColumn.HeaderText = "Price";
                    priceColumn.DataPropertyName = "Price";  // Binds the Price from the DataTable
                    dtgInvoice.Columns.Add(priceColumn);
                }

                // Check for "Unreturned" books and populate BookTitleOne, BookTitleTwo, PriceOne, and PriceTwo
                int unreturnedCount = 0;  // Counter for unreturned books
                foreach (DataRow row in borrowedBooks.Rows)
                {
                    string status = row["Status"].ToString();
                    if (status == "Unreturned")
                    {
                        string bookTitle = row["BookTitle"].ToString();
                        decimal bookPrice = Convert.ToDecimal(row["Price"]);

                        // Populate BookTitleOne and PriceOne if it's the first unreturned book
                        if (unreturnedCount == 0)
                        {
                            txtBookTitleOne.Text = bookTitle;
                            txtPriceOne.Text = bookPrice.ToString("N2");  // Format as numeric, no dollar sign
                        }
                        // Populate BookTitleTwo and PriceTwo if it's the second unreturned book
                        else if (unreturnedCount == 1)
                        {
                            txtBookTitleTwo.Text = bookTitle;
                            txtPriceTwo.Text = bookPrice.ToString("N2");  // Format as numeric, no dollar sign
                        }

                        unreturnedCount++;

                        // Break if two unreturned books are found
                        if (unreturnedCount == 2)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                // Clear fields if no student is found
                ClearFields();
                dtgInvoice.DataSource = null;
            }


            /*  // Skip search if placeholder is active
              if (isSearchPlaceholderActive)
                  return;

              // If the search box is empty, clear all fields
              if (string.IsNullOrWhiteSpace(txtSearch.Text))
              {
                  ClearFields();
                  dtgInvoice.DataSource = null; // Clear book borrowing history (data grid)
                  dtgBooksInfo.DataSource = null; // Clear book information (inventory data grid)
                  return;
              }

              // Get the search query from txtSearch
              string searchQuery = txtSearch.Text;

              // Search for the student
              DataTable studentResults = GetStudentSearchResults(searchQuery);

              if (studentResults.Rows.Count > 0)
              {
                  // Populate student fields with the first result
                  PopulateStudentFields(studentResults.Rows[0]);

                  // Get borrowed books for the student
                  string borrowerID = studentResults.Rows[0]["ID"].ToString();
                  DataTable borrowedBooks = GetBorrowedBooks(borrowerID);

                  // Display borrowed books in the DataGridView
                  dtgInvoice.DataSource = borrowedBooks;

                  // Get book information from Inventory and display in dtgBooksInfo
                  DataTable inventoryBooks = GetInventoryBooks();
                  dtgBooksInfo.DataSource = inventoryBooks;
              }
              else
              {
                  // Clear fields if no student is found
                  ClearFields();
                  dtgInvoice.DataSource = null;
                  dtgBooksInfo.DataSource = null;
              }*/
        }

        /*  private DataTable FilterBooksByBorrowed(DataTable borrowedBooks, DataTable inventoryBooks)
          {
              DataTable filteredBooks = inventoryBooks.Clone(); // Clone the structure of inventoryBooks

              foreach (DataRow borrowedRow in borrowedBooks.Rows)
              {
                  string borrowedBookID = borrowedRow["BookID"].ToString();
                  string borrowedBookTitle = borrowedRow["BookTitles"].ToString();  // Changed to BookTitles

                  foreach (DataRow inventoryRow in inventoryBooks.Rows)
                  {
                      string inventoryBookID = inventoryRow["BookID"].ToString();
                      string inventoryBookTitle = inventoryRow["BookTitles"].ToString();  // Changed to BookTitles

                      // Match both BookID and BookTitles
                      if (borrowedBookID == inventoryBookID && borrowedBookTitle.Equals(inventoryBookTitle, StringComparison.OrdinalIgnoreCase))
                      {
                          filteredBooks.ImportRow(inventoryRow); // Add matching book to the filtered list
                      }
                  }
              }

              return filteredBooks;
          }*/





        /*   // Retrieves student search results from the database
           private DataTable GetStudentSearchResults(string searchQuery)
           {
               DataTable dt = new DataTable();

               try
               {
                   using (SqlConnection con = new SqlConnection(connectionString))
                   {
                       con.Open();
                       string query = @"
                           SELECT ID, StudentNumber, CONCAT(Firstname, ' ', Middlename, ' ', Lastname) AS Fullname,
                                  Age, Gender, Year, Section
                           FROM ActiveBorrowers
                           WHERE Firstname LIKE @Search OR Lastname LIKE @Search OR StudentNumber LIKE @Search";

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
           }*/



        private DataTable GetStudentSearchResults(string searchQuery)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
            SELECT ID, StudentNumber, CONCAT(Firstname, ' ', Middlename, ' ', Lastname) AS Fullname,
                   Age, Gender, Year, Section
            FROM ActiveBorrowers
            WHERE Firstname LIKE @Search OR Lastname LIKE @Search OR StudentNumber LIKE @Search";

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

        private void ClearFields()
        {
            txtID.Clear(); // Clear Student ID
            txtBookID.Clear(); // Clear Book ID(s)

            txtStudentNumber.Clear();
            txtFullName.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtYear.Clear();
            txtSection.Clear();

            txtBookTitleOne.Clear();
            txtPriceOne.Clear();

            txtBookTitleTwo.Clear();
            txtPriceTwo.Clear();
        }

        /*  private void PopulateStudentFields(DataRow studentRow)
          {
              txtID.Text = studentRow["ID"].ToString(); // Populate the Student ID
              txtStudentNumber.Text = studentRow["StudentNumber"].ToString();
              txtFullName.Text = studentRow["Fullname"].ToString();
              txtAge.Text = studentRow["Age"].ToString();
              txtGender.Text = studentRow["Gender"].ToString();
              txtYear.Text = studentRow["Year"].ToString();
              txtSection.Text = studentRow["Section"].ToString();
          }*/


        private void PopulateStudentFields(DataRow studentRow)
        {
            txtID.Text = studentRow["ID"].ToString(); // Populate the Student ID
            txtStudentNumber.Text = studentRow["StudentNumber"].ToString();
            txtFullName.Text = studentRow["Fullname"].ToString();
            txtAge.Text = studentRow["Age"].ToString();
            txtGender.Text = studentRow["Gender"].ToString();
            txtYear.Text = studentRow["Year"].ToString();
            txtSection.Text = studentRow["Section"].ToString();
        }

        private void dtgInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This will prevent the population of textboxes when clicking on a row
            // Commenting out the entire logic that populates the textboxes
            if (e.RowIndex >= 0)
            {
                // Remove or comment out this part to prevent populating textboxes
                // DataGridViewRow selectedRow = dtgInvoice.Rows[e.RowIndex];

                // Do nothing or just show a message if you want feedback when a row is clicked
                // MessageBox.Show("Row clicked, but fields won't be populated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // If you want to do nothing when a row is clicked, just return here
                return;
            }
        }


        /*  private DataTable GetBorrowedBooks(string borrowerID)
          {
              DataTable dt = new DataTable();

              try
              {
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      con.Open();
                      string query = @"
      SELECT 
      bb.BookID, 
      i.BookTitle, 
      i.Author, 
      i.Category, 
      i.BookShelves, 
      i.Quantity, 
      i.Price, 
      bb.BorrowedDate, 
      bb.DueDate, 
      bb.Status
  FROM BookBorrowing bb
  INNER JOIN Inventory i ON bb.BookID = i.BookID
  WHERE bb.BorrowerID = @BorrowerID";

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
          }*/



        // This method now only fetches borrowed books for a specific student
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
                bb.BookID, 
                i.BookTitle, 
                i.Category, 
                i.BookShelves, 
                i.Quantity, 
                i.Price, 
                bb.BorrowedDate, 
                bb.DueDate, 
                bb.Status
            FROM BookBorrowing bb
            INNER JOIN Inventory i ON bb.BookID = i.BookID
            WHERE bb.BorrowerID = @BorrowerID";

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





        /* private DataTable GetInventoryBooks()
         {
             DataTable dt = new DataTable();

             try
             {
                 using (SqlConnection con = new SqlConnection(connectionString))
                 {
                     con.Open();
                     string query = @"
                 SELECT 
                     BookID, 
                     ISBN, 
                     BookTitles, 
                     Author, 
                     Category, 
                     PublishedDate, 
                     BookShelves, 
                     Quantity, 
                     Price, 
                     Location, 
                     Publisher, 
                     ImageFile, 
                     Status
                 FROM Inventory";

                     using (SqlCommand cmd = new SqlCommand(query, con))
                     {
                         SqlDataAdapter da = new SqlDataAdapter(cmd);
                         da.Fill(dt);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error retrieving inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

             return dt;
         }*/

    }

                
                        
    
}
