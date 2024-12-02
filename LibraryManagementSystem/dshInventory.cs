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
        private long _ISBN;
        private string _BookTitle;
        private string _Author;
        private string _Category;
        private string _PublishDate;
        private string _BookShelves;
        private string _Location;
        private int _Quantity;
        private decimal _Price;

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
            // TODO: This line of code loads data into the 'lmsdcsDataSet42.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet42.Inventory);





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

                // Ensure Image is not null
                if (pictureBoxImage.Image == null)
                {
                    MessageBox.Show("Please upload an image for the book.", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convert the image to a byte array
                byte[] imageBytes = null;

                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Ensure the image is not disposed or locked
                        Bitmap bitmap = new Bitmap(pictureBoxImage.Image);
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing the image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if the image cannot be processed
                }

                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();

                    // Check if the book already exists in the inventory (based on ISBN)
                    SqlCommand cmdCheckExistence = new SqlCommand(
                        "SELECT Quantity FROM Inventory WHERE ISBN = @ISBN", con);
                    cmdCheckExistence.Parameters.AddWithValue("@ISBN", isbn);

                    object existingQuantityObj = cmdCheckExistence.ExecuteScalar();

                    if (existingQuantityObj != null)
                    {
                        // Book exists, update the quantity
                        int existingQuantity = Convert.ToInt32(existingQuantityObj);
                        int updatedQuantity = existingQuantity + quantity;

                        SqlCommand cmdUpdateQuantity = new SqlCommand(
                            "UPDATE Inventory SET Quantity = @UpdatedQuantity, Publisher = @Publisher WHERE ISBN = @ISBN", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@UpdatedQuantity", updatedQuantity);
                        cmdUpdateQuantity.Parameters.AddWithValue("@Publisher", txtPublisher.Text); // Update Publisher if needed
                        cmdUpdateQuantity.Parameters.AddWithValue("@ISBN", isbn);

                        cmdUpdateQuantity.ExecuteNonQuery();
                        MessageBox.Show("Book quantity updated successfully!");
                    }
                    else
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
                        cmdInsert.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());  // Category from ComboBox
                        cmdInsert.Parameters.AddWithValue("@PublishedDate", dtpPublishDate.Value);
                        cmdInsert.Parameters.AddWithValue("@BookShelves", cmbBookShelves.SelectedItem.ToString()); // Shelves from ComboBox
                        cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                        cmdInsert.Parameters.AddWithValue("@Price", price);
                        cmdInsert.Parameters.AddWithValue("@Location", txtLocation.Text);
                        cmdInsert.Parameters.AddWithValue("@Publisher", txtPublisher.Text); // Add Publisher
                        cmdInsert.Parameters.AddWithValue("@ImageFile", imageBytes);
                        cmdInsert.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

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
            dtpPublishDate.Value = DateTime.Now;

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

        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ask the user for confirmation before deleting
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this book?",
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

                    // Delete query with corrected WHERE clause
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Inventory WHERE ISBN = @ISBN AND BookTitle = @BookTitle AND Author = @Author AND SerialNumber = @SerialNumber", con);

                    // Pass the parameters from the form controls
                    cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                    cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text.Trim()); // Assuming SerialNumber is stored in a label

                    int rowsAffected = cmd.ExecuteNonQuery(); // Check if rows were deleted

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No book found with the provided details.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clear fields after successful deletion
            txtAuthor.Clear();
            txtBookTitle.Clear();
            txtISBN.Clear();
            cmbBookShelves.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            dtpPublishDate.Checked = false;
            dtpPublishDate.Value = DateTime.Today;

            // Clear quantity, price, publisher, and location fields
            txtQuantity.Clear();
            txtPrice.Clear();
            txtPublisher.Clear();
            txtLocation.Clear();

            // Refresh the DataGridView to show the updated data
            RefreshDataGrid();


        }
        private void RefreshDataGrid()
        {
            LoadAllUsersData(); // This reloads data from the database into the DataGridView
        }

        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the search term from the user input
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
                // Establish connection to the database
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
                            // Populate the fields with the retrieved data
                            txtBookTitle.Text = reader["BookTitle"].ToString();
                            txtISBN.Text = reader["ISBN"].ToString();
                            txtAuthor.Text = reader["Author"].ToString();
                            txtPublisher.Text = reader["Publisher"].ToString();

                            // Set ComboBox (Category and BookShelves)
                            cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                            cmbBookShelves.DropDownStyle = ComboBoxStyle.DropDown;
                            cmbStatus.DropDownStyle = ComboBoxStyle.DropDown;

                            cmbCategory.SelectedItem = reader["Category"].ToString();
                            cmbBookShelves.SelectedItem = reader["BookShelves"].ToString();
                            cmbStatus.SelectedItem = reader["Status"].ToString();

                            // Load image if available (only show the image, no image picker here)
                            var imageFile = reader["ImageFile"];
                            if (imageFile != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])imageFile;
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBoxImage.Image = Image.FromStream(ms); // Display the image from byte[] in the PictureBox
                                }
                            }
                            else
                            {
                                pictureBoxImage.Image = null; // If no image, set the PictureBox to null
                            }

                            // Populate other fields
                            txtQuantity.Text = reader["Quantity"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtLocation.Text = reader["Location"].ToString();
                            lblSerialNumber.Text = reader["SerialNumber"].ToString(); // Store SerialNumber for future updates

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
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if a book is selected (i.e., SerialNumber is not empty)
            if (string.IsNullOrWhiteSpace(lblSerialNumber.Text))
            {
                MessageBox.Show("Please select a book to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Price input (ensure it's a valid decimal)
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price (non-negative number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare the UPDATE query to exclude both the ImageFile and Quantity fields
            string updateQuery = @"UPDATE Inventory SET BookTitle = @BookTitle, Category = @Category, BookShelves = @BookShelves, Price = @Price, Location = @Location, Status = @Status WHERE SerialNumber = @SerialNumber";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    // Set parameters for the update query
                    cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text.Trim()); // Book Title
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? ""); // Category
                    cmd.Parameters.AddWithValue("@BookShelves", cmbBookShelves.SelectedItem?.ToString() ?? ""); // Book Shelves
                    cmd.Parameters.AddWithValue("@Price", price); // Price
                    cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim()); // Location
                    cmd.Parameters.AddWithValue("@SerialNumber", lblSerialNumber.Text); // Update using the SerialNumber
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? ""); // Status

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload data into DataGridView to reflect the changes
                        RefreshDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please ensure the book exists and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            
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

        private void dataGridInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {

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
