using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class dshInventory : Form
    {
        // Define the placeholder text
        private string placeholderText = "Search Book ISBN";
       

        private string connectionData = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        private DataTable usersDataTable = new DataTable();
        private Timer searchTimer = new Timer(); // Initialize timer for debounce

        
        public dshInventory()
        {
            InitializeComponent();


            // Make sure events are wired up
            txtSearchBook.Enter += txtSearchBook_Enter;
            txtSearchBook.Leave += txtSearchBook_Leave;

            InitializePlaceholder();  // Initialize the placeholder

            LoadAllUsersData();
           
        }

        private void dshInventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lmsdcsDataSet3.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet3.Inventory);
         


            // Manually add items to Category ComboBox
            cmbCategory.Items.Clear(); // Ensure no old data is lingering
            cmbCategory.Items.Add("Literary Fiction");
            cmbCategory.Items.Add("Biography & Memoir");
            cmbCategory.Items.Add("History");
            cmbCategory.Items.Add("Science & Technology");
            cmbCategory.Items.Add("Self-Help & Personal Development");
            cmbCategory.Items.Add("Travel");
            cmbCategory.Items.Add("Politics & Government");
            cmbCategory.Items.Add("Religion & Spirituality");
            cmbCategory.Items.Add("Art & Photography");
            cmbCategory.Items.Add("Health & Fitness");
            cmbCategory.Items.Add("Business & Economics");
            cmbCategory.Items.Add("True Crime");
            cmbCategory.Items.Add("Dictionaries & Encyclopedias");
            cmbCategory.Items.Add("Atlases");
            cmbCategory.Items.Add("Legal References");
            cmbCategory.Items.Add("Academic Texts");
            cmbCategory.Items.Add("Textbooks");
            cmbCategory.Items.Add("Study Guides");
            cmbCategory.Items.Add("Language Learning");
            cmbCategory.Items.Add("Magazines");
            cmbCategory.Items.Add("Journals");
            cmbCategory.Items.Add("Newspapers");

            // Populate BookShelves ComboBox
            cmbBookShelves.Items.Clear(); // Ensure no old data is lingering
            cmbBookShelves.Items.Add("BookShelves A");
            cmbBookShelves.Items.Add("BookShelves B");
            cmbBookShelves.Items.Add("BookShelves C");
            cmbBookShelves.Items.Add("BookShelves D");
            cmbBookShelves.Items.Add("BookShelves E");


            cmbStatus.Items.Add("Good");
            cmbStatus.Items.Add("Damaged");
            cmbStatus.Items.Add("Repaired");

            // Optionally, set a default selected item if required
            cmbCategory.SelectedIndex = 0; // Default to first category (optional)
            cmbBookShelves.SelectedIndex = 0; // Default to first book shelf (optional)
            cmbStatus.SelectedIndex = 0; // Defailt to first Status (optional)
        }
        // Method to load all user data from the database
        private void LoadAllUsersData()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionData))
                {
                    sqlCon.Open();
                    // SQL query to fetch data, including the Publisher and image column (ImageFile as byte[])
                    SqlDataAdapter sqlData = new SqlDataAdapter(
                        "SELECT BookID, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status FROM Inventory",
                        sqlCon);

                    usersDataTable.Clear();
                    sqlData.Fill(usersDataTable);  // Fill the DataTable with data from the database

                    // Bind the data to the DataGridView
                    dataGridInventory.DataSource = usersDataTable;

                    // Ensure there is an Image column in the DataGridView (if you haven't added it already)
                    if (!dataGridInventory.Columns.Contains("ImageFile"))
                    {
                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn.Name = "ImageFile";
                        imageColumn.HeaderText = "Image";
                        dataGridInventory.Columns.Add(imageColumn);
                    }

                    // Optionally, adjust the width of the columns or make them auto-size as needed
                    dataGridInventory.AutoResizeColumns();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method to filter the data based on the search text
        private void FilterData(string searchText)
        {
            // Set the DataGridView's DataSource to null to clear previous filters
            DataView dataView = new DataView(usersDataTable);

            // Apply the filter based on the search text (case-insensitive)
            dataView.RowFilter = string.Format("BookTitle LIKE '%{0}%' OR ISBN LIKE '%{0}%' OR Author LIKE '%{0}%' OR Category LIKE '%{0}%' OR PublishDate LIKE '%{0}%' OR BookShelves LIKE '%{0}%'",
                searchText);

            // Set the filtered DataView as the DataSource of the DataGridView
            cmbBookShelves.DataSource = dataView;
        }


        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse ISBN
                long isbn = ISBN(txtISBN.Text);
                if (isbn == -1) // Invalid ISBN
                {
                    MessageBox.Show("Invalid ISBN format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Quantity (allowing only positive numbers)
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Price (allowing only decimal values greater than zero)
                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate other fields
                if (string.IsNullOrEmpty(txtBookTitle.Text) || string.IsNullOrEmpty(txtAuthor.Text) ||
                    cmbCategory.SelectedItem == null || cmbBookShelves.SelectedItem == null || string.IsNullOrEmpty(txtLocation.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Handle image processing
                byte[] imageBytes = null;  // Declare imageBytes properly
                if (pictureBoxImage.Image != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (Bitmap bmp = new Bitmap(pictureBoxImage.Image))
                            {
                                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            imageBytes = ms.ToArray();  // Convert image to byte array
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error processing the image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Open connection and insert new book record
                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();
                    string status = cmbStatus.SelectedItem.ToString();

                    // Generate a new BookID based on the highest BookID in the database
                    SqlCommand cmdGetMaxBookID = new SqlCommand(
                        "SELECT MAX(BookID) FROM Inventory", con);
                    object maxBookIDObj = cmdGetMaxBookID.ExecuteScalar();
                    int newBookID = (maxBookIDObj != DBNull.Value) ? Convert.ToInt32(maxBookIDObj) + 1 : 1;

                    // Insert new book record with generated BookID
                    SqlCommand cmdInsert = new SqlCommand(
                        "INSERT INTO Inventory (BookID, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status) " +
                        "VALUES (@BookID, @BookTitle, @ISBN, @Author, @Category, @PublishedDate, @BookShelves, @Quantity, @Price, @Location, @Publisher, @ImageFile, @Status)", con);

                    cmdInsert.Parameters.AddWithValue("@BookID", newBookID);  // Insert the generated BookID
                    cmdInsert.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                    cmdInsert.Parameters.AddWithValue("@ISBN", isbn);
                    cmdInsert.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    cmdInsert.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                    cmdInsert.Parameters.AddWithValue("@PublishedDate", dtpPublishedDate.Value);
                    cmdInsert.Parameters.AddWithValue("@BookShelves", cmbBookShelves.SelectedItem.ToString());
                    cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                    cmdInsert.Parameters.AddWithValue("@Price", price);
                    cmdInsert.Parameters.AddWithValue("@Location", txtLocation.Text);
                    cmdInsert.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                    cmdInsert.Parameters.AddWithValue("@ImageFile", (object)imageBytes ?? DBNull.Value);
                    cmdInsert.Parameters.AddWithValue("@Status", status);

                    cmdInsert.ExecuteNonQuery();  // Execute the insert command
                    MessageBox.Show("Book added successfully.");
                }

                // Refresh the DataGridView after adding the book
                RefreshDataGrid();

                // Clear the form after adding the book
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            // Clear all text boxes
            txtISBN.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtLocation.Clear();
            txtPublisher.Clear();

            // Reset ComboBoxes
            cmbCategory.SelectedIndex = -1;
            cmbBookShelves.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            // Reset DateTimePicker to the current date
            dtpPublishedDate.Value = DateTime.Now;

            // Clear the picture box
            pictureBoxImage.Image = null;

            // Optional: Reset other controls if necessary
            lblSerialNumber.Text = string.Empty; // Example of a label reset
        }
        public long ISBN(string isbn)
        {
            try
            {
                return long.Parse(isbn);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid ISBN format: {ex.Message}");
                return -1;  // Return a value indicating invalid ISBN
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a book is selected (i.e., BookID is not empty)
                if (string.IsNullOrEmpty(lblSerialNumber.Text))
                {
                    MessageBox.Show("Please select a book to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ask the user for confirmation before deleting
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete one quantity of this book?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // If the user clicks 'No', cancel the operation
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();

                    // Step 1: Check the current quantity of the book
                    SqlCommand cmdCheckQuantity = new SqlCommand(
                        "SELECT Quantity FROM Inventory WHERE BookID = @BookID", con);
                    cmdCheckQuantity.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

                    object quantityObj = cmdCheckQuantity.ExecuteScalar();

                    // If no result (book not found), show an error
                    if (quantityObj == null)
                    {
                        MessageBox.Show("No book found with the provided BookID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int quantity = Convert.ToInt32(quantityObj);

                    if (quantity > 1)
                    {
                        // Step 2: Update the quantity (decrease by 1)
                        SqlCommand cmdUpdateQuantity = new SqlCommand(
                            "UPDATE Inventory SET Quantity = Quantity - 1 WHERE BookID = @BookID", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

                        cmdUpdateQuantity.ExecuteNonQuery();
                        MessageBox.Show("One quantity of the book has been deleted successfully!");
                    }
                    else if (quantity == 1)
                    {
                        // Step 3: If quantity is 1, delete the entire book record
                        SqlCommand cmdDeleteBook = new SqlCommand(
                            "DELETE FROM Inventory WHERE BookID = @BookID", con);
                        cmdDeleteBook.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

                        cmdDeleteBook.ExecuteNonQuery();
                        MessageBox.Show("The book has been completely deleted.");
                    }
                }

                // Clear fields after deletion
                ClearFields();

                // Refresh the DataGridView to show the updated data
                RefreshDataGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGrid()
        {
            LoadAllUsersData(); // This reloads data from the database into the DataGridView
        }

        private void EnableEditableFields(bool isEnabled)
        {
            txtBookTitle.Enabled = isEnabled;
            cmbCategory.Enabled = isEnabled;
            cmbBookShelves.Enabled = isEnabled;
            btnUploadImage.Enabled = isEnabled; // Enable image upload button
        }

        private void EnableNonEditableFields(bool isEditable)
        {
            // For TextBox fields
            txtISBN.ReadOnly = !isEditable;
            txtISBN.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtISBN.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            txtAuthor.ReadOnly = !isEditable;
            txtAuthor.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtAuthor.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            txtQuantity.ReadOnly = !isEditable;
            txtQuantity.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtQuantity.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            txtLocation.ReadOnly = !isEditable;
            txtLocation.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtLocation.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            txtPublisher.ReadOnly = !isEditable;
            txtPublisher.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtPublisher.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            txtPrice.ReadOnly = !isEditable;
            txtPrice.BackColor = isEditable ? SystemColors.Window : Color.White;
            txtPrice.ForeColor = isEditable ? SystemColors.WindowText : Color.Gray;

            // For other controls
            dtpPublishedDate.Enabled = isEditable;
            dtpPublishedDate.CalendarForeColor = isEditable ? SystemColors.WindowText : Color.Gray; // Adjust text color for DateTimePicker
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) || string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Please fill in the required fields: Book Title and ISBN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query for updating the record (exclude fields that are read-only)
            string query = @"
    UPDATE Inventory
    SET 
        BookTitle = @BookTitle,
        Category = @Category,
        BookShelves = @BookShelves,
        Status = @Status
    WHERE 
        BookID = @BookID";

            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Set parameters
                    cmd.Parameters.AddWithValue("@BookID", lblSerialNumber.Text); // SerialNumber must not be null
                    cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString());
                    cmd.Parameters.AddWithValue("@BookShelves", cmbBookShelves.SelectedItem?.ToString());
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString());

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Call method to refresh the DataGridView after update
                        RefreshDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. No record found for the given Serial Number.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllBooksData()
        {
            // Add your logic to reload data into the DataGridView, such as querying the database
            string query = "SELECT * FROM Inventory";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Assuming you have a DataGridView named dataGridView
                dataGridInventory.DataSource = dataTable;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // Open a file dialog for the user to select an image file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select a Book Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image into the PictureBox
                        string imagePath = ofd.FileName;

                        // Ensure the previous image is disposed to prevent memory issues
                        if (pictureBoxImage.Image != null)
                        {
                            pictureBoxImage.Image.Dispose();
                        }

                        // Load the image into the PictureBox
                        pictureBoxImage.Image = Image.FromFile(imagePath);

                        // Optional: Save the image path for further use if necessary
                        lblImagePath.Text = imagePath; // Assuming you have a textbox to display the path
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void dataGridInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is the image column (ImageFile)
            if (dataGridInventory.Columns[e.ColumnIndex].Name == "ImageFile" && e.Value != null)
            {
                byte[] imageBytes = e.Value as byte[];

                if (imageBytes != null && imageBytes.Length > 0)
                {
                    // Convert byte[] to Image
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        e.Value = Image.FromStream(ms);  // Set the value to the Image
                    }
                }
            }
        }

        // Set the placeholder if the TextBox is empty
        private void InitializePlaceholder()
        {
            if (string.IsNullOrEmpty(txtSearchBook.Text))
            {
                txtSearchBook.Text = placeholderText;
                txtSearchBook.ForeColor = Color.Gray;  // Set the placeholder color
            }
        }

        private void txtSearchBook_Enter(object sender, EventArgs e)
        {
            if (txtSearchBook.Text == placeholderText)
            {
                txtSearchBook.Text = "";
                txtSearchBook.ForeColor = Color.Black; // Set text color to black when typing
            }
        }

        private void txtSearchBook_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBook.Text))
            {
                txtSearchBook.Text = placeholderText;
                txtSearchBook.ForeColor = Color.Gray; // Restore placeholder color
            }
        }

        private void dataGridInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a row is double-clicked (ignore header clicks)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridInventory.Rows[e.RowIndex];

                // Populate the textboxes with the data from the selected row
                lblSerialNumber.Text = row.Cells["BookID"].Value.ToString();
                txtISBN.Text = row.Cells["BookNumber"].Value.ToString();
                txtBookTitle.Text = row.Cells["BookTitle"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                cmbCategory.SelectedItem = row.Cells["Category"].Value.ToString();
                cmbBookShelves.SelectedItem = row.Cells["BookShelves"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtLocation.Text = row.Cells["Location"].Value.ToString();
                txtPublisher.Text = row.Cells["Publisher"].Value.ToString();
                dtpPublishedDate.Value = Convert.ToDateTime(row.Cells["PublishedDate"].Value);
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();

                // Check if the image byte array exists and set it in the PictureBox
                if (row.Cells["ImageFile"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells["ImageFile"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBoxImage.Image = Image.FromStream(ms);  // Convert byte array to image and display in PictureBox
                    }
                }
                else
                {
                    // Clear the PictureBox if there is no image
                    pictureBoxImage.Image = null;
                }
            }
        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBook.Text.Trim();

            // Fetch and display the filtered books based on the search term
            SearchBooks(searchTerm);
        }

        private void SearchBooks(string searchTerm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();

                    // SQL query to search for books by ISBN, title, or author
                    string query = "SELECT BookID, ISBN, BookTitle, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status " +
                                   "FROM Inventory " +
                                   "WHERE BookTitle LIKE @SearchTerm OR Author LIKE @SearchTerm OR ISBN LIKE @SearchTerm";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the result to the DataGridView
                    dataGridInventory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
