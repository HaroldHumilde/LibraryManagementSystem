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
            // TODO: This line of code loads data into the 'lmsdcsDataSet44.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet44.Inventory);


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
                        "SELECT SerialNumber, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status FROM Inventory",
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

                // Validate Quantity
                if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Price
                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Publisher
                if (string.IsNullOrEmpty(txtPublisher.Text))
                {
                    MessageBox.Show("Please enter a publisher name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                byte[] imageBytes = null;
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
                            imageBytes = ms.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error processing the image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();

                    string status = cmbStatus.SelectedItem.ToString();
                    bool bookExists = false;

                    // Check for existing book by ISBN and Status
                    SqlCommand cmdCheckExistence = new SqlCommand(
                        "SELECT Quantity FROM Inventory WHERE ISBN = @ISBN AND Status = @Status", con);
                    cmdCheckExistence.Parameters.AddWithValue("@ISBN", isbn);
                    cmdCheckExistence.Parameters.AddWithValue("@Status", status);

                    object existingQuantityObj = cmdCheckExistence.ExecuteScalar();

                    if (existingQuantityObj != null)
                    {
                        // Book with the same ISBN and Status exists, update the quantity
                        int existingQuantity = Convert.ToInt32(existingQuantityObj);
                        int updatedQuantity = existingQuantity + quantity;

                        SqlCommand cmdUpdateQuantity = new SqlCommand(
                            "UPDATE Inventory SET Quantity = @UpdatedQuantity, Publisher = @Publisher WHERE ISBN = @ISBN AND Status = @Status", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@UpdatedQuantity", updatedQuantity);
                        cmdUpdateQuantity.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                        cmdUpdateQuantity.Parameters.AddWithValue("@ISBN", isbn);
                        cmdUpdateQuantity.Parameters.AddWithValue("@Status", status);

                        cmdUpdateQuantity.ExecuteNonQuery();
                        bookExists = true;
                        MessageBox.Show("Book quantity updated successfully!");
                    }

                    if (!bookExists)
                    {
                        // Book does not exist, insert a new record
                        SqlCommand cmdInsert = new SqlCommand(
                            "INSERT INTO Inventory (SerialNumber, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status) " +
                            "VALUES (@SerialNumber, @BookTitle, @ISBN, @Author, @Category, @PublishedDate, @BookShelves, @Quantity, @Price, @Location, @Publisher, @ImageFile, @Status)", con);

                        // Generate SerialNumber
                        SqlCommand cmdGetMax = new SqlCommand("SELECT ISNULL(MAX(SerialNumber), 0) FROM Inventory", con);
                        int serialNumber = (int)cmdGetMax.ExecuteScalar() + 1;

                        cmdInsert.Parameters.AddWithValue("@SerialNumber", serialNumber);
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

                        cmdInsert.ExecuteNonQuery();
                        MessageBox.Show("Book added successfully!");
                    }

                    // Refresh the DataGridView
                    RefreshDataGrid();
                }

                // Clear fields after adding or updating
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "SELECT Quantity FROM Inventory WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND SerialNumber = @SerialNumber", con);
                    cmdCheckQuantity.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                    cmdCheckQuantity.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim());
                    cmdCheckQuantity.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                    cmdCheckQuantity.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text.Trim());

                    object quantityObj = cmdCheckQuantity.ExecuteScalar();

                    // If no result (book not found), show an error
                    if (quantityObj == null)
                    {
                        MessageBox.Show("No book found with the provided details.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int quantity = Convert.ToInt32(quantityObj);

                    if (quantity > 1)
                    {
                        // Step 2: Update the quantity (decrease by 1)
                        SqlCommand cmdUpdateQuantity = new SqlCommand(
                            "UPDATE Inventory SET Quantity = Quantity - 1 WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND SerialNumber = @SerialNumber", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                        cmdUpdateQuantity.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim());
                        cmdUpdateQuantity.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmdUpdateQuantity.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text.Trim());

                        cmdUpdateQuantity.ExecuteNonQuery();
                        MessageBox.Show("One quantity of the book has been deleted successfully!");
                    }
                    else if (quantity == 1)
                    {
                        // Step 3: If quantity is 1, delete the entire book record
                        SqlCommand cmdDeleteBook = new SqlCommand(
                            "DELETE FROM Inventory WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND SerialNumber = @SerialNumber", con);
                        cmdDeleteBook.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                        cmdDeleteBook.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim());
                        cmdDeleteBook.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmdDeleteBook.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text.Trim());

                        cmdDeleteBook.ExecuteNonQuery();
                        MessageBox.Show("The book has been completely deleted.");
                    }
                }

                // Clear fields after deletion
                txtAuthor.Clear();
                txtBookTitle.Clear();
                txtISBN.Clear();
                cmbBookShelves.SelectedIndex = -1;
                cmbStatus.SelectedIndex = -1;
                cmbCategory.SelectedIndex = -1;
                dtpPublishedDate.Checked = false;
                dtpPublishedDate.Value = DateTime.Today;

                // Clear quantity, price, publisher, location fields
                txtQuantity.Clear();
                txtPrice.Clear();
                txtPublisher.Clear();
                txtLocation.Clear();

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBook.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a valid search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"
    SELECT SerialNumber, ISBN, BookTitle, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status
    FROM Inventory 
    WHERE ISBN = @ISBN OR BookTitle LIKE @TitleSearchTerm OR Author LIKE @AuthorSearchTerm";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ISBN", searchTerm);
                    cmd.Parameters.AddWithValue("@TitleSearchTerm", "%" + searchTerm + "%");
                    cmd.Parameters.AddWithValue("@AuthorSearchTerm", "%" + searchTerm + "%");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate fields with data (without Description)
                            txtBookTitle.Text = reader["BookTitle"].ToString();
                            txtISBN.Text = reader["ISBN"].ToString();
                            txtAuthor.Text = reader["Author"].ToString();
                            txtPublisher.Text = reader["Publisher"].ToString();
                            // Removed the Description field assignment
                            txtQuantity.Text = reader["Quantity"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtLocation.Text = reader["Location"].ToString();
                            lblSerialNumber.Text = reader["SerialNumber"].ToString();

                            // Set ComboBoxes
                            cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf(reader["Category"].ToString());
                            cmbBookShelves.SelectedIndex = cmbBookShelves.Items.IndexOf(reader["BookShelves"].ToString());
                            cmbStatus.SelectedIndex = cmbStatus.Items.IndexOf(reader["Status"].ToString());

                            // Handle image
                            var imageFile = reader["ImageFile"];
                            if (imageFile != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])imageFile;
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBoxImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureBoxImage.Image = null;
                            }

                            // Handle PublishedDate
                            if (DateTime.TryParse(reader["PublishedDate"]?.ToString(), out DateTime publishedDate))
                            {
                                dtpPublishedDate.Value = publishedDate;
                            }

                            // Enable/disable fields based on edit mode
                            EnableEditableFields(true);
                            EnableNonEditableFields(false);
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
        SerialNumber = @SerialNumber";

            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Set parameters
                    cmd.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text); // SerialNumber must not be null
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
    }
}
