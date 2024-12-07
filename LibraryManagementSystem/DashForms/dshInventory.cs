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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class dshInventory : Form
    {
        // Define the placeholder text
        private string placeholderText = "Search ISBN or Book Name";
       

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
            // TODO: This line of code loads data into the 'lmsdcsDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.lmsdcsDataSet.Inventory);



            // Manually add items to Category ComboBox
            cmbCategory.Items.Clear(); // Ensure no old data is lingering
            
            cmbCategory.Items.Add("Academic Texts");
            cmbCategory.Items.Add("Action Adventure");
            cmbCategory.Items.Add("Allegory");
            cmbCategory.Items.Add("Art & Photography");//A
            cmbCategory.Items.Add("Atlases");
            cmbCategory.Items.Add("Autobiography");
            

            cmbCategory.Items.Add("Biography & Memoir");
            cmbCategory.Items.Add("Business & Economics");//B

            cmbCategory.Items.Add("Classics");
            cmbCategory.Items.Add("Contemporary Romance");//C
            cmbCategory.Items.Add("Contemporary Women's Fiction");

            cmbCategory.Items.Add("Dictionaries & Encyclopedias");//D
            cmbCategory.Items.Add("Drama");

            cmbCategory.Items.Add("Fairytale");
            cmbCategory.Items.Add("Fantasy");
            cmbCategory.Items.Add("Fiction");//F

            cmbCategory.Items.Add("Health & Fitness");//H
            cmbCategory.Items.Add("History");
            cmbCategory.Items.Add("Horror");
            cmbCategory.Items.Add("Humanities & Social Science");

            

            cmbCategory.Items.Add("Journals");//J

            cmbCategory.Items.Add("Language Learning");//L
            cmbCategory.Items.Add("Legal References");
            cmbCategory.Items.Add("Literary Fiction");
            cmbCategory.Items.Add("Literature & Language Arts");


            cmbCategory.Items.Add("Magazines");//M
            cmbCategory.Items.Add("Mystery");

            cmbCategory.Items.Add("Newspapers");//N
            cmbCategory.Items.Add("Novel");

            cmbCategory.Items.Add("Philosophy");//P
            cmbCategory.Items.Add("Psychology");
            cmbCategory.Items.Add("Poetry");
            cmbCategory.Items.Add("Politics & Government");

            cmbCategory.Items.Add("Romance");//R
            cmbCategory.Items.Add("Religion & Spirituality");
            
            

            cmbCategory.Items.Add("Study Guides");//S
            cmbCategory.Items.Add("Science & Technology");
            cmbCategory.Items.Add("Self-Help & Personal Development");


            cmbCategory.Items.Add("Travel");
            cmbCategory.Items.Add("Textbooks");
            cmbCategory.Items.Add("True Crime");
            cmbCategory.Items.Add("Thriller/Suspense");//T


            cmbCategory.Items.Add("Women's Fiction");//W





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


        private void btnAddBook_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtBookTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtISBN.Text) ||
                    string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtLocation.Text) ||
                    string.IsNullOrWhiteSpace(txtPublisher.Text) ||
                    cmbCategory.SelectedIndex == -1 ||
                    cmbBookShelves.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all the required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string isbn = txtISBN.Text.Trim();
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (pictureBoxImage.Image == null)
                {
                    MessageBox.Show("Please upload an image for the book.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] imageBytes;
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (Bitmap imageToSave = new Bitmap(pictureBoxImage.Image))
                        {
                            imageToSave.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        imageBytes = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image processing error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();
                    string status = cmbStatus.SelectedItem?.ToString() ?? "Available";

                    for (int i = 0; i < quantity; i++)
                    {
                        SqlCommand cmdInsert = new SqlCommand(
                            "INSERT INTO Inventory (BookID, BookTitle, ISBN, Author, Category, PublishedDate, BookShelves, Quantity, Price, Location, Publisher, ImageFile, Status) " +
                            "VALUES (@BookID, @BookTitle, @ISBN, @Author, @Category, @PublishedDate, @BookShelves, @Quantity, @Price, @Location, @Publisher, @ImageFile, @Status)", con);

                        SqlCommand cmdGetMax = new SqlCommand("SELECT ISNULL(MAX(BookID), 0) FROM Inventory", con);
                        int serialNumber = (int)cmdGetMax.ExecuteScalar() + 1;

                        cmdInsert.Parameters.AddWithValue("@BookID", serialNumber);
                        cmdInsert.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                        cmdInsert.Parameters.AddWithValue("@ISBN", isbn);
                        cmdInsert.Parameters.AddWithValue("@Author", txtAuthor.Text);
                        cmdInsert.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                        cmdInsert.Parameters.AddWithValue("@PublishedDate", dtpPublishedDate.Value);
                        cmdInsert.Parameters.AddWithValue("@BookShelves", cmbBookShelves.SelectedItem.ToString());
                        cmdInsert.Parameters.AddWithValue("@Quantity", 1);
                        cmdInsert.Parameters.AddWithValue("@Price", price);
                        cmdInsert.Parameters.AddWithValue("@Location", txtLocation.Text);
                        cmdInsert.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                        cmdInsert.Parameters.AddWithValue("@ImageFile", imageBytes);
                        cmdInsert.Parameters.AddWithValue("@Status", status);

                        cmdInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Books added successfully!");
                    RefreshDataGrid();
                }

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Assuming ValidateISBN simply checks for non-empty input
        private string ValidateISBN(string isbn)
        {
            // ISBN should not be empty or whitespace
            if (string.IsNullOrWhiteSpace(isbn))
            {
                return null;  // Invalid if empty or whitespace
            }

            return isbn;  // Return the ISBN if it's not empty
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
                // Debugging: Check what values are being passed for deletion
                Console.WriteLine("BookID: " + lblSerialNumber.Text);
                Console.WriteLine("ISBN: " + txtISBN.Text.Trim());
                Console.WriteLine("Book Title: " + txtBookTitle.Text.Trim());

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
                        "SELECT Quantity FROM Inventory WHERE ISBN = @ISBN AND BookID = @BookID", con);
                    cmdCheckQuantity.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                    cmdCheckQuantity.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

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
                            "UPDATE Inventory SET Quantity = Quantity - 1 WHERE ISBN = @ISBN AND BookID = @BookID", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                        cmdUpdateQuantity.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

                        cmdUpdateQuantity.ExecuteNonQuery();
                        MessageBox.Show("One quantity of the book has been deleted successfully!");
                    }
                    else if (quantity == 1)
                    {
                        // Step 3: If quantity is 1, delete the entire book record
                        SqlCommand cmdDeleteBook = new SqlCommand(
                            "DELETE FROM Inventory WHERE ISBN = @ISBN AND BookID = @BookID", con);
                        cmdDeleteBook.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                        cmdDeleteBook.Parameters.AddWithValue("@BookID", lblSerialNumber.Text.Trim());

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

                // Clear the picture box
                pictureBoxImage.Image = null;

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

                        // Enable the fields after successful update
                        SetFieldsEditable(true);  // Enable the input fields after successful update
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

            // Clear fields after adding or updating (optional, if required)
             ClearFields();
        }

        private void SetFieldsEditable(bool isEditable)
        {
            // Set TextBoxes to editable or uneditable based on the flag
            txtBookTitle.ReadOnly = !isEditable;
            txtISBN.ReadOnly = !isEditable;
            txtQuantity.ReadOnly = !isEditable;
            txtAuthor.ReadOnly = !isEditable;
            txtLocation.ReadOnly = !isEditable;
            txtPrice.ReadOnly = !isEditable;
            txtPublisher.ReadOnly = !isEditable;

            // Set ComboBoxes to editable or uneditable based on the flag
            cmbCategory.Enabled = isEditable;
            cmbBookShelves.Enabled = isEditable;
            cmbStatus.Enabled = isEditable;

            // Enable or disable the DateTimePicker
            dtpPublishedDate.Enabled = isEditable;

            // Optionally enable or disable buttons, if required
            btnUpdate.Enabled = isEditable;
            btnUploadImage.Enabled = isEditable;
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

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchBook.Text.Trim().ToLower();

            string query = @"
            SELECT BookID, BookTitle, ISBN, Author, Category, Price, Quantity, Status, Location, 
                   BookShelves, PublishedDate, Publisher, ImageFile
            FROM Inventory
            WHERE BookTitle LIKE @SearchKeyword 
               OR ISBN LIKE @SearchKeyword
               OR BookShelves LIKE @SearchKeyword
               OR PublishedDate LIKE @SearchKeyword";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionData))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                    conn.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dataGridInventory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridInventory.Rows.Count)
                {
                    DataGridViewRow row = dataGridInventory.Rows[e.RowIndex];

                    if (row != null)
                    {
                        // Populate text fields
                        txtBookTitle.Text = row.Cells["BookTitle"].Value?.ToString() ?? string.Empty;
                        txtISBN.Text = row.Cells["BookNumber"].Value?.ToString() ?? string.Empty;
                        txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? string.Empty;
                        txtLocation.Text = row.Cells["Location"].Value?.ToString() ?? string.Empty;
                        txtPublisher.Text = row.Cells["Publisher"].Value?.ToString() ?? string.Empty;
                        txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;
                        txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? string.Empty;

                        cmbCategory.SelectedItem = row.Cells["Category"].Value?.ToString() ?? string.Empty;
                        cmbBookShelves.SelectedItem = row.Cells["BookShelves"].Value?.ToString() ?? string.Empty;
                        cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? string.Empty;

                        if (row.Cells["PublishedDate"].Value != DBNull.Value)
                        {
                            dtpPublishedDate.Value = Convert.ToDateTime(row.Cells["PublishedDate"].Value);
                        }
                        else
                        {
                            dtpPublishedDate.Value = DateTime.Now;
                        }

                        // Handle image
                        byte[] imageBytes = row.Cells["ImageFile"].Value as byte[];
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                if (pictureBoxImage.Image != null)
                                {
                                    pictureBoxImage.Image.Dispose(); // Dispose of existing image
                                }
                                pictureBoxImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            if (pictureBoxImage.Image != null)
                            {
                                pictureBoxImage.Image.Dispose();
                            }
                            pictureBoxImage.Image = null;
                        }

                        lblSerialNumber.Text = row.Cells["BookID"].Value?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
