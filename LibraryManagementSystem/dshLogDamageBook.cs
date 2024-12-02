using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class dshLogDamageBook : Form
    {
        public dshLogDamageBook()
        {
            InitializeComponent();
        }

        private void dshLogDamageBook_Load(object sender, EventArgs e)
        {

            // Load data into the DataGridView when the form is loaded
            LoadLogDamagedBooks();



            try
            {
                string[] ListofCategory = new string[]{

                "Literary Fiction",
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

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Retrieve the input values
            string bookTitle = txtBookTitle.Text;
            string isbn = txtISBN.Text;
            string author = txtAuthor.Text;
            string category = cmbCategory.SelectedItem != null ? cmbCategory.SelectedItem.ToString() : "";
            DateTime publishedDate = dtpPublishedDate.Value;  // Fixed reference to DateTimePicker control
            string bookShelves = cmbBookShelves.SelectedItem != null ? cmbBookShelves.SelectedItem.ToString() : "";
            string description = txtDescription.Text;
            string publisher = txtPublisher.Text;
            string location = txtLocation.Text;
            decimal price = string.IsNullOrWhiteSpace(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text);

            // Validate the inputs
            if (string.IsNullOrWhiteSpace(bookTitle) || string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(bookShelves) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(publisher) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert image to byte array if it's not null
            byte[] imageBytes = null;
            if (pictureBoxImage.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Convert the image into a byte array
                        pictureBoxImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save as JPEG format
                        imageBytes = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Image Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop further processing
                }
            }

            // SQL queries for checking existence and updating/inserting records
            string checkQuery = @"SELECT Quantity FROM DamagedBooks 
WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND PublishedDate = @PublishedDate AND Category = @Category";
            string updateQuery = @"UPDATE DamagedBooks 
SET Quantity = Quantity + 1 
WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND PublishedDate = @PublishedDate AND Category = @Category";
            string insertQuery = @"INSERT INTO DamagedBooks (SerialNumber, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Description, Quantity, Publisher, Location, Price, ImageFile) 
VALUES (@SerialNumber, @BookTitle, @ISBN, @Author, @Category, @PublishedDate, @BookShelves, @Description, 1, @Publisher, @Location, @Price, @ImageFile)";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    // Get the next serial number
                    int serialNumber = 1;
                    using (SqlCommand serialCmd = new SqlCommand("SELECT MAX(SerialNumber) FROM DamagedBooks", conn))
                    {
                        object result = serialCmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            serialNumber = Convert.ToInt32(result) + 1;
                        }
                    }

                    // Check if the book already exists
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ISBN", isbn);
                        checkCmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                        checkCmd.Parameters.AddWithValue("@Author", author);
                        checkCmd.Parameters.AddWithValue("@Category", category);
                        checkCmd.Parameters.AddWithValue("@PublishedDate", publishedDate);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null) // Book exists
                        {
                            // Update the quantity
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@ISBN", isbn);
                                updateCmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                                updateCmd.Parameters.AddWithValue("@Author", author);
                                updateCmd.Parameters.AddWithValue("@Category", category);
                                updateCmd.Parameters.AddWithValue("@PublishedDate", publishedDate);

                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Book quantity updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else // Book does not exist
                        {
                            // Insert a new record
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                                insertCmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                                insertCmd.Parameters.AddWithValue("@ISBN", isbn);
                                insertCmd.Parameters.AddWithValue("@Author", author);
                                insertCmd.Parameters.AddWithValue("@Category", category);
                                insertCmd.Parameters.AddWithValue("@PublishedDate", publishedDate);
                                insertCmd.Parameters.AddWithValue("@BookShelves", bookShelves);
                                insertCmd.Parameters.AddWithValue("@Description", description);
                                insertCmd.Parameters.AddWithValue("@Publisher", publisher);
                                insertCmd.Parameters.AddWithValue("@Location", location);
                                insertCmd.Parameters.AddWithValue("@Price", price);

                                // If an image exists, use its byte array; otherwise, set it to NULL
                                insertCmd.Parameters.AddWithValue("@ImageFile", imageBytes ?? (object)DBNull.Value);

                                insertCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Clear the input fields
                    ClearFields();

                    // Refresh DataGridView
                    LoadLogDamagedBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding/updating book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
        private void ClearFields()
        {
            txtBookTitle.Clear();
            txtISBN.Clear();
            txtAuthor.Clear();
            txtDescription.Clear();
            txtSearchDamagedBooks.Clear(); // Clear the search box
            cmbCategory.SelectedIndex = -1; // Reset to no selection
            cmbBookShelves.SelectedIndex = -1; // Reset to no selection
            dtpPublishedDate.Value = DateTime.Now; // Set DateTimePicker to current date
            txtQuantity.Clear(); // Clear Quantity field if present
            txtPublisher.Clear();
            txtLocation.Clear(); // Clear Location field if present
            txtPrice.Clear(); // Clear Price field if present
            pictureBoxImage.Image = null; // Reset the image
        }

        private void LoadLogDamagedBooks()
        {
            // Define the connection string to your SQL Server database
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Define the query to retrieve data from the database
            string query = @"SELECT 
                 [SerialNumber], 
                 [ISBN], 
                 [BookTitle], 
                 [Author], 
                 [Category], 
                 [PublishedDate], 
                 [BookShelves], 
                 [Quantity], 
                 [Publisher], 
                 [Location], 
                 [Price], 
                 [ImageFile], 
                 [Description] 
              FROM [lmsdcs].[dbo].[DamagedBooks]";

            try
            {
                // Use a SqlConnection for database access
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a SqlDataAdapter to execute the query and fill the DataTable
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn))
                    {
                        // Create a DataTable to hold the data
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the database
                        dataAdapter.Fill(dataTable);

                        // Debugging: Log the number of rows retrieved
                        Console.WriteLine($"Rows Retrieved: {dataTable.Rows.Count}");

                        // Bind the data to the DataGridView
                        if (dataTable.Rows.Count > 0)
                        {
                            dataBookDamage.DataSource = dataTable; // Set DataTable as DataSource
                            dataBookDamage.Refresh(); // Refresh the DataGridView to display data
                        }
                        else
                        {
                            // Clear DataGridView if no data is found
                            dataBookDamage.DataSource = null;
                            MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnEdit_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchDamagedBooks.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a valid search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to search for the book by ISBN, BookTitle, or Author
            string query = @"
SELECT 
    BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Description, Quantity, Location, Publisher, Price, ImageFile
FROM 
    DamagedBooks 
WHERE 
    ISBN = @ISBN OR BookTitle LIKE @TitleSearchTerm OR Author LIKE @AuthorSearchTerm";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ISBN", searchTerm); // Exact match for ISBN
                    cmd.Parameters.AddWithValue("@TitleSearchTerm", "%" + searchTerm + "%"); // Partial match for Title
                    cmd.Parameters.AddWithValue("@AuthorSearchTerm", "%" + searchTerm + "%"); // Partial match for Author

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate all textboxes with book details
                            txtBookTitle.Text = reader["BookTitle"].ToString();
                            txtISBN.Text = reader["ISBN"].ToString();
                            txtAuthor.Text = reader["Author"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            txtLocation.Text = reader["Location"].ToString();
                            txtPublisher.Text = reader["Publisher"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtQuantity.Text = reader["Quantity"].ToString();

                            // Safely set combo box values
                            cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf(reader["Category"].ToString());
                            cmbBookShelves.SelectedIndex = cmbBookShelves.Items.IndexOf(reader["BookShelves"].ToString());

                            // Handle nullable PublishedDate
                            if (DateTime.TryParse(reader["PublishedDate"]?.ToString(), out DateTime publishedDate))
                            {
                                dtpPublishedDate.Value = publishedDate;
                            }

                            // Load image into PictureBox
                            if (reader["ImageFile"] != DBNull.Value)
                            {
                                string imagePath = reader["ImageFile"].ToString();
                                if (System.IO.File.Exists(imagePath))
                                {
                                    pictureBoxImage.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    pictureBoxImage.Image = null;
                                }
                            }
                            else
                            {
                                pictureBoxImage.Image = null;
                            }

                            // Enable/disable fields
                            EnableEditableFields(true); // Enable editable fields
                            EnableNonEditableFields(false); // Disable non-editable fields
                        }
                        else
                        {
                            MessageBox.Show("No book found with the given search term.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableEditableFields(bool isEnabled)
        {
            txtBookTitle.Enabled = isEnabled;
            cmbCategory.Enabled = isEnabled;
            cmbBookShelves.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            btnUploadImage.Enabled = isEnabled; // Enable image upload button
        }

        private void EnableNonEditableFields(bool isEnabled)
        {
            txtISBN.Enabled = isEnabled;
            txtAuthor.Enabled = isEnabled;
            txtQuantity.Enabled = isEnabled;
            txtLocation.Enabled = isEnabled;
            txtPublisher.Enabled = isEnabled;
            txtPrice.Enabled = isEnabled;
            dtpPublishedDate.Enabled = isEnabled;
        }


        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve input values for editable fields
            string bookTitle = txtBookTitle.Text.Trim();
            string category = cmbCategory.SelectedItem != null ? cmbCategory.SelectedItem.ToString() : "";
            string bookShelves = cmbBookShelves.SelectedItem != null ? cmbBookShelves.SelectedItem.ToString() : "";
            string description = txtDescription.Text.Trim();
            string isbn = txtISBN.Text.Trim(); // ISBN remains as the unique identifier

            // Validate the inputs for editable fields
            if (string.IsNullOrWhiteSpace(bookTitle) || string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(bookShelves) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all editable fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to update only the editable fields
            string query = @"
    UPDATE DamagedBooks 
    SET 
        BookTitle = @BookTitle, 
        Category = @Category, 
        BookShelves = @BookShelves, 
        Description = @Description,
        ImageFile = @ImageFile
    WHERE ISBN = @ISBN"; // Use ISBN as the identifier

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@BookShelves", bookShelves);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);

                    // Handle the image file and convert to byte array
                    if (pictureBoxImage.Image != null)
                    {
                        byte[] imageBytes = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Convert the image into a byte array
                            pictureBoxImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageBytes = ms.ToArray();
                        }

                        // Add the image byte array to the SQL command
                        cmd.Parameters.AddWithValue("@ImageFile", imageBytes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ImageFile", DBNull.Value); // No image provided
                    }

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView to reflect updated information
                        LoadLogDamagedBooks();

                        // Clear all input fields
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("No book found with the given ISBN to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Retrieve the ISBN from the textbox
            string isbn = txtISBN.Text.Trim();

            // Validate the ISBN
            if (string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Please enter a valid ISBN to delete a book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to delete this book?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Proceed only if the user confirms
            if (dialogResult == DialogResult.Yes)
            {
                // SQL query to delete the book using the ISBN
                string query = "DELETE FROM DamagedBooks WHERE ISBN = @ISBN";

                try
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ISBN", isbn);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Notify the user of successful deletion
                            MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the textboxes and reset the form
                            ClearFields();

                            // Refresh the DataGridView to reflect the deletion
                            LoadLogDamagedBooks();
                        }
                        else
                        {
                            // Notify if no matching book was found
                            MessageBox.Show("No book found with the given ISBN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors during the database operation
                    MessageBox.Show($"Error deleting book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // Open a file dialog for the user to select an image file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Filter for image files
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select a Book Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the selected image's file path
                        string imagePath = ofd.FileName;

                        // Dispose of the previous image to avoid memory issues
                        if (pictureBoxImage.Image != null)
                        {
                            pictureBoxImage.Image.Dispose();
                        }

                        // Load the new image into the PictureBox
                        pictureBoxImage.Image = Image.FromFile(imagePath);

                        // Store the image path for saving it to the database
                        lblImagePath.Text = imagePath; // Assuming lblImagePath is used to hold the image path
                    }
                    catch (Exception ex)
                    {
                        // Handle errors in loading the image
                        MessageBox.Show("Error loading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearchDamagedBooks_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
