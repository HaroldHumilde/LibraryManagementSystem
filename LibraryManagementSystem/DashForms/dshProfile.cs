using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;




namespace LibraryManagementSystem
{

    public partial class dshProfile : Form
    {

        private string connectionData = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        
        private DataTable usersDataTable = new DataTable();
        private Timer searchTimer = new Timer(); // Timer for search debounce

        // Declare a placeholder text
        private string placeholderText = "Search Student Number";

        public dshProfile()
        {
            InitializeComponent();

            InitializeTimerSearch();

           
            // Set the timer interval (500ms debounce time)
            searchTimer.Interval = 500; // Delay in milliseconds
            searchTimer.Tick += SearchTimer_Tick;

        }


        private void dshProfile_Load(object sender, EventArgs e)
        {

            InitializePlaceholder();  // Set the placeholder when the form loads

            // TODO: This line of code loads data into the 'lmsdcsDataSet40.ActiveBorrowers' table. You can move, or remove it, as needed.
            this.activeBorrowersTableAdapter.Fill(this.lmsdcsDataSet40.ActiveBorrowers);


            try
            {
                string[] ListofYear = new string[]{

                "1st Year Highschool",
                "2nd Year Highschool",
                "3rd Year Highschool",
                "4th Year Highschool",
                "Grade 11 Senior Highschool",
                "Grade 12 Senior Highschool",
            };
                for (int i = 0; i < 6; i++)
                {
                    cmbBoxYear.Items.Add(ListofYear[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }

            try
            {
                string[] ListofSection = new string[]{

                "Section 1",
                "Section 2",
                "Section 3",
                "Section 4",
                "Section 5",
                "STEM",
                "ABM",
                "HUMSS",
                "TVL-ICT",
                "TVL-HE",
                "GAS"

            };
                for (int i = 0; i < 11; i++)
                {
                    cmbBoxSection.Items.Add(ListofSection[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }

            try
            {
                string[] ListofGender = new string[]{

                "Male",
                "Female"

            };
                for (int i = 0; i < 2; i++)
                {
                    cmbBoxGender.Items.Add(ListofGender[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }


            // Load data from ActiveBorrowers table and bind it to DataGridView
            LoadAllUserData(); // Fetching data into the DataGridView is already handled by this method

            // Fetch data from ActiveBorrowers table and bind to DataGridView (optional as LoadAllUsersData already does it)
            // If you still want to fetch it again explicitly (for a reason), this is the adjusted method:
            string query = "SELECT ID, StudentNumber, Firstname, Middlename, Lastname, Age, Birthday, Gender, Address, ContactNumber, Email, Year, Section, ProfileImage FROM ActiveBorrowers";

            using (SqlConnection sqlCon = new SqlConnection(connectionData)) // connectionData should contain your connection string
            {
                sqlCon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlCon);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dataGridSearchInfo.DataSource = dt;
            }
        }

        public void LoadAllUserData() // Changed to public for external access if needed
        {
            // Define the connection string
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Define the SQL query to fetch all user data, including ProfileImage
            string query = @"
    SELECT 
        ID,
        StudentNumber,
        Firstname,
        Middlename,
        Lastname,
        Age,
        Birthday,
        Gender,
        Address,
        ContactNumber,
        Email,
        Year,
        Section,
        ProfileImage
    FROM ActiveBorrowers"; // Removed square brackets and added ProfileImage

            // Use a SqlConnection to fetch data from the database
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open(); // Open the database connection

                    // Use a SqlDataAdapter to fill a DataTable with the query result
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridSearchInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    // Log or display an error message if something goes wrong
                    MessageBox.Show($"An error occurred while loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Filter data based on search value
        private void FilterData(string searchValue)
        {
            // SQL query with ProfileImage column and removed square brackets
            string query = @"
    SELECT 
        ID,
        StudentNumber,
        Firstname,
        Middlename,
        Lastname,
        Age,
        Birthday,
        Gender,
        Address,
        ContactNumber,
        Email,
        Year,
        Section,
        ProfileImage
    FROM ActiveBorrowers
    WHERE 
        StudentNumber LIKE @SearchValue OR
        Lastname LIKE @SearchValue OR
        Firstname LIKE @SearchValue OR
        Middlename LIKE @SearchValue";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;User ID=your_username;Password=your_password;Encrypt=True;TrustServerCertificate=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridSearchInfo.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Timer tick event to handle the search delay
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            TimerSearch.Stop();
            FilterData(txtSearchUser.Text); // Make sure you're passing the correct search term here
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // SQL query to search for a record by StudentNumber, FirstName, MiddleName, or LastName
            string query = @"
SELECT * 
FROM ActiveBorrowers 
WHERE LOWER(StudentNumber) = LOWER(@SearchTerm)
   OR LOWER(FirstName) = LOWER(@SearchTerm)
   OR LOWER(MiddleName) = LOWER(@SearchTerm)
   OR LOWER(LastName) = LOWER(@SearchTerm)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SearchTerm", txtSearchUser.Text.Trim());

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate textboxes with user information
                            txtFirstName.Text = reader["FirstName"]?.ToString() ?? string.Empty;
                            txtMiddleName.Text = reader["MiddleName"]?.ToString() ?? string.Empty;
                            txtLastName.Text = reader["LastName"]?.ToString() ?? string.Empty;
                            txtAge.Text = reader["Age"]?.ToString() ?? string.Empty;
                            cmbBoxGender.Text = reader["Gender"]?.ToString() ?? string.Empty;

                            if (reader["Birthday"] != DBNull.Value)
                            {
                                BirthdayDateTimePicker.Value = Convert.ToDateTime(reader["Birthday"]);
                            }
                            else
                            {
                                BirthdayDateTimePicker.Value = DateTime.Today; // Default value
                            }

                            txtStudentNo.Text = reader["StudentNumber"]?.ToString() ?? string.Empty;
                            cmbBoxYear.Text = reader["Year"]?.ToString() ?? string.Empty;
                            cmbBoxSection.Text = reader["Section"]?.ToString() ?? string.Empty;
                            txtAddress.Text = reader["Address"]?.ToString() ?? string.Empty;
                            txtEmail.Text = reader["Email"]?.ToString() ?? string.Empty;
                            txtContactNo.Text = reader["ContactNumber"]?.ToString() ?? string.Empty;

                            // Handle ProfileImage (if needed)
                            if (reader["ProfileImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["ProfileImage"];

                                // Check if the image data is valid
                                if (imageData.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        // Load the image into the PictureBox
                                        pictureBoxProfile.Image = Image.FromStream(ms);

                                        // Set SizeMode to Zoom to maintain the aspect ratio while fitting the image
                                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;

                                        // Optionally, you can set the PictureBox's size to fit the image more precisely
                                        // For example, to ensure it doesn't stretch:
                                        // pictureBoxProfile.Width = Math.Min(image.Width, pictureBoxProfile.Width);
                                        // pictureBoxProfile.Height = Math.Min(image.Height, pictureBoxProfile.Height);
                                    }
                                }
                                else
                                {
                                    pictureBoxProfile.Image = null; // If no image data, clear the PictureBox
                                    MessageBox.Show("No valid image found for this user.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                pictureBoxProfile.Image = null; // If no image is available, clear the PictureBox
                            }
                        }
                        else
                        {
                            MessageBox.Show("No record found for the given search term.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            TimerSearch.Stop();
            FilterData();
        }

        private void InitializeTimerSearch()
        {
            TimerSearch = new Timer();
            TimerSearch.Interval = 500;
            TimerSearch.Tick += TimerSearch_Tick;
        }

        private void FilterData()
        {
            string searchTerm = txtSearchUser.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAllUserData(); // Reload all data if search term is empty
                return;
            }

            try
            {
                // Ensure the DataSource is a valid DataTable
                var dataTable = dataGridSearchInfo.DataSource as DataTable;
                if (dataTable == null)
                {
                    MessageBox.Show("The data source is invalid or not a DataTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Clone the structure of the DataTable to hold the filtered results
                DataTable filteredDataTable = dataTable.Clone();

                // Iterate through each row in the original DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Check each column for a match with the search term
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (row[column.ColumnName]?.ToString().ToLower().Contains(searchTerm) ?? false)
                        {
                            // If any column contains the search term, add the row to filtered data
                            filteredDataTable.ImportRow(row);
                            break; // Exit loop early once a match is found for the row
                        }
                    }
                }

                // If filtered data is different from the original, update the DataGridView
                if (filteredDataTable.Rows.Count != dataTable.Rows.Count)
                {
                    dataGridSearchInfo.DataSource = filteredDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // SQL query to update user info (without ProfileImage)
            string updateQuery = @"
UPDATE ActiveBorrowers 
SET 
    StudentNumber = @NewStudentNumber,
    FirstName = @FirstName,
    MiddleName = @MiddleName,
    LastName = @LastName,
    Age = @Age,
    Gender = @Gender,
    Birthday = @Birthday,
    Year = @Year,
    Section = @Section,
    Address = @Address,
    Email = @Email,
    ContactNumber = @ContactNumber
WHERE StudentNumber = @CurrentStudentNumber";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Step 1: Validate NewStudentNumber - only allow numbers
                    if (!string.IsNullOrEmpty(txtNewStudentNumber.Text) && !txtNewStudentNumber.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("The new Student Number must contain only numeric digits.", "Invalid Student Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop further execution if validation fails
                    }

                    // Step 2: Validate that FirstName, MiddleName, and LastName contain only letters
                    if (!txtFirstName.Text.All(char.IsLetter))
                    {
                        MessageBox.Show("First Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!txtMiddleName.Text.All(char.IsLetter))
                    {
                        MessageBox.Show("Middle Name must contain only letters.", "Invalid Middle Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!txtLastName.Text.All(char.IsLetter))
                    {
                        MessageBox.Show("Last Name must contain only letters.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Step 3: Validate that Age contains only numbers
                    if (!int.TryParse(txtAge.Text, out int age))
                    {
                        MessageBox.Show("Age must be a valid numeric value.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop further execution if validation fails
                    }

                    // Step 4: Validate ContactNumber - only allow numbers
                    if (!Regex.IsMatch(txtContactNo.Text, @"^\d+$"))
                    {
                        MessageBox.Show("The contact number must contain only numeric digits. Please remove any letters or symbols.", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop further execution if validation fails
                    }

                    // Step 5: If a new StudentNumber is entered, check if it already exists
                    if (!string.IsNullOrEmpty(txtNewStudentNumber.Text) && txtNewStudentNumber.Text != txtStudentNo.Text)
                    {
                        string checkDuplicateQuery = "SELECT COUNT(*) FROM ActiveBorrowers WHERE StudentNumber = @NewStudentNumber";
                        using (SqlCommand checkCmd = new SqlCommand(checkDuplicateQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@NewStudentNumber", txtNewStudentNumber.Text);

                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("The Student Number already exists for another user.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Step 6: Check if any field has been modified (using dynamic comparison)
                    bool isModified = CheckIfFieldsModified(con, txtStudentNo.Text);

                    if (!isModified && string.IsNullOrEmpty(txtNewStudentNumber.Text))
                    {
                        MessageBox.Show("No changes were made to the user information.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Step 7: Perform the update
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        // Set the CurrentStudentNumber (before update)
                        updateCmd.Parameters.AddWithValue("@CurrentStudentNumber", txtStudentNo.Text);

                        // Set the new StudentNumber (only if changed)
                        updateCmd.Parameters.AddWithValue("@NewStudentNumber", string.IsNullOrEmpty(txtNewStudentNumber.Text) ? txtStudentNo.Text : txtNewStudentNumber.Text);

                        // Update the rest of the fields
                        updateCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        updateCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        updateCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        updateCmd.Parameters.AddWithValue("@Age", age); // Use the validated numeric age value
                        updateCmd.Parameters.AddWithValue("@Gender", cmbBoxGender.Text);
                        updateCmd.Parameters.AddWithValue("@Birthday", BirthdayDateTimePicker.Value);
                        updateCmd.Parameters.AddWithValue("@Year", cmbBoxYear.Text);
                        updateCmd.Parameters.AddWithValue("@Section", cmbBoxSection.Text);
                        updateCmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        updateCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        updateCmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text);

                        // Execute the update
                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllUserData(); // Refresh data grid or list

                            // Clear all textboxes and reset the form fields
                            ClearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the user information. Please check the Student Number.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private bool CheckIfFieldsModified(SqlConnection con, string currentStudentNumber)
        {
            string fetchCurrentRecordQuery = "SELECT * FROM ActiveBorrowers WHERE StudentNumber = @CurrentStudentNumber";
            using (SqlCommand fetchCmd = new SqlCommand(fetchCurrentRecordQuery, con))
            {
                fetchCmd.Parameters.AddWithValue("@CurrentStudentNumber", currentStudentNumber);

                using (SqlDataReader reader = fetchCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Check for changes by comparing current values in the database with form fields
                        return txtFirstName.Text != reader["FirstName"].ToString() ||
                               txtMiddleName.Text != reader["MiddleName"].ToString() ||
                               txtLastName.Text != reader["LastName"].ToString() ||
                               txtAge.Text != reader["Age"].ToString() ||
                               cmbBoxGender.Text != reader["Gender"].ToString() ||
                               BirthdayDateTimePicker.Value != Convert.ToDateTime(reader["Birthday"]) ||
                               cmbBoxYear.Text != reader["Year"].ToString() ||
                               cmbBoxSection.Text != reader["Section"].ToString() ||
                               txtAddress.Text != reader["Address"].ToString() ||
                               txtEmail.Text != reader["Email"].ToString() ||
                               txtContactNo.Text != reader["ContactNumber"].ToString() ||
                               !CompareProfileImages(reader["ProfileImage"]);
                    }
                }
            }
            return false;
        }

        // Helper method to compare profile images (if they exist)
        private bool CompareProfileImages(object profileImageDb)
        {
            if (profileImageDb == DBNull.Value) return false;

            byte[] dbImage = (byte[])profileImageDb;
            using (MemoryStream ms = new MemoryStream(dbImage))
            {
                Image dbImg = Image.FromStream(ms);
                return !pictureBoxProfile.Image.Equals(dbImg); // Compare the current image with the one in DB
            }
        }

        // Function to clear all the textboxes and reset form fields
        private void ClearFormFields()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            cmbBoxGender.SelectedIndex = -1; // Or set it to default value if needed
            BirthdayDateTimePicker.Value = DateTime.Now; // Or set to a specific default date
            txtStudentNo.Clear();
            cmbBoxYear.SelectedIndex = -1;
            cmbBoxSection.SelectedIndex = -1;
            txtAddress.Clear();
            txtEmail.Clear();
            txtContactNo.Clear();
            txtNewStudentNumber.Clear(); // If you have a text box for the new student number

            // Reset the Profile Image PictureBox
            pictureBoxProfile.Image = null; // This will clear the image
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Prompt user for confirmation before deleting
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to delete this user? Make sure to delete their borrowing history first.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // If the user clicks 'No', exit the function
            if (dialogResult == DialogResult.No)
            {
                return; // Exit the method and do nothing
            }

            // Get StudentNumber
            string studentNumber = txtStudentNo.Text;

            // Check if the user exists in the ActiveBorrowers table
            if (!CheckIfUserExists(studentNumber))
            {
                MessageBox.Show("User not found. Deletion cannot proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the user has borrowing history in the BookBorrowing table
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string checkHistoryQuery = @"
    SELECT COUNT(*) 
    FROM BookBorrowing 
    WHERE BorrowerID = (SELECT TOP 1 ID FROM ActiveBorrowers WHERE StudentNumber = @StudentNumber)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(checkHistoryQuery, con))
            {
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                con.Open();
                int count = (int)cmd.ExecuteScalar();

                // If borrowing history exists, show a message and return
                if (count > 0)
                {
                    MessageBox.Show("This user has borrowing history. Please delete the borrowing history first before deleting the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method if the user has borrowing history
                }
            }

            // Proceed with deletion if no borrowing history is found
            string deleteUserQuery = "DELETE FROM ActiveBorrowers WHERE StudentNumber = @StudentNumber";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    // Step 1: Delete from ActiveBorrowers table
                    using (SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, con, transaction))
                    {
                        deleteUserCmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        deleteUserCmd.ExecuteNonQuery();
                    }

                    // Commit the transaction if the delete operation was successful
                    transaction.Commit();

                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear all textboxes and reset the form fields
                    ClearFormFields();

                    
                    LoadAllUserData(); // Refresh data grid or list
                }
                catch (Exception ex)
                {
                    transaction?.Rollback(); // Rollback the transaction in case of an error
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckIfUserExists(string studentNumber)
        {
            // Define your connection string
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "SELECT COUNT(*) FROM ActiveBorrowers WHERE StudentNumber = @StudentNumber";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    // Open the connection
                    con.Open();

                    int userCount = (int)cmd.ExecuteScalar();  // ExecuteScalar returns the first column of the first row
                    return userCount > 0;  // Return true if the user exists
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  // Return false if there's an issue connecting to the database
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtSearchUser_Enter(object sender, EventArgs e)
        {
            // Remove the placeholder when the user clicks on the TextBox
            if (txtSearchUser.Text == placeholderText)
            {
                txtSearchUser.Text = ""; // Clear the placeholder text
                txtSearchUser.ForeColor = Color.Black; // Set the text color to black when typing
            }
        }

        private void txtSearchUser_Leave(object sender, EventArgs e)
        {
            // If the TextBox is empty, show the placeholder text again
            if (string.IsNullOrEmpty(txtSearchUser.Text))
            {
                txtSearchUser.Text = placeholderText; // Set the placeholder text
                txtSearchUser.ForeColor = Color.Gray; // Set the color of the placeholder
            }
        }

        // Set the placeholder text initially
        private void InitializePlaceholder()
        {
            if (string.IsNullOrEmpty(txtSearchUser.Text))
            {
                txtSearchUser.Text = placeholderText;
                txtSearchUser.ForeColor = Color.Gray;  // Set the placeholder color
            }
        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            


            // Set the SizeMode to Zoom or StretchImage, depending on how you want the image to fit.
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom; // or StretchImage if you prefer stretching

            // Optionally, you could load an image or perform other operations here
            // Example: pictureBoxProfile.Image = Image.FromFile("path_to_image.jpg");
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchUser.Text.Trim();

            // If the search box is empty, load all users
            if (string.IsNullOrEmpty(searchText))
            {
                LoadAllUserData();
            }
            else
            {
                // Perform a filtered search
                SearchUserData(searchText);
            }
        }

      
        private void SearchUserData(string searchText)
        {
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string searchQuery = @"
        SELECT ID, StudentNumber, Firstname, Middlename, Lastname, Gender, Year, Section, 
               Age, Birthday, Address, Email, ContactNumber, ProfileImage
        FROM ActiveBorrowers
        WHERE StudentNumber LIKE @SearchText 
           OR Firstname LIKE @SearchText 
           OR Lastname LIKE @SearchText 
           OR Middlename LIKE @SearchText 
           OR Gender LIKE @SearchText 
           OR Year LIKE @SearchText 
           OR Section LIKE @SearchText";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(searchQuery, con))
            {
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable filteredData = new DataTable();
                    adapter.Fill(filteredData);

                    // Bind the filtered data to the DataGridView
                    dataGridSearchInfo.DataSource = filteredData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        }

        private void dataGridSearchInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure that a valid row was clicked
                if (e.RowIndex >= 0 && e.RowIndex < dataGridSearchInfo.Rows.Count)
                {
                    DataGridViewRow row = dataGridSearchInfo.Rows[e.RowIndex];

                    // Check if row is not null before accessing
                    if (row != null)
                    {
                        // Populate textboxes with the data from the selected row
                        txtFirstName.Text = row.Cells["Firstname"].Value?.ToString() ?? string.Empty;
                        txtMiddleName.Text = row.Cells["Middlename"].Value?.ToString() ?? string.Empty;
                        txtLastName.Text = row.Cells["Lastname"].Value?.ToString() ?? string.Empty;

                        // Check and populate Age field
                        string ageValue = row.Cells["Age"].Value?.ToString();
                        txtAge.Text = !string.IsNullOrEmpty(ageValue) ? ageValue : "N/A"; // Default if no value found

                        cmbBoxGender.Text = row.Cells["Gender"].Value?.ToString() ?? string.Empty;

                        // Populate DateTimePicker for Birthday with a valid date
                        if (row.Cells["Birthday"].Value != DBNull.Value && row.Cells["Birthday"].Value != null)
                        {
                            DateTime birthday = Convert.ToDateTime(row.Cells["Birthday"].Value);
                            BirthdayDateTimePicker.Value = birthday > DateTime.MinValue && birthday < DateTime.MaxValue ? birthday : DateTime.Today;
                        }
                        else
                        {
                            BirthdayDateTimePicker.Value = DateTime.Today; // Default value if no birthday
                        }

                        // Handle Address field
                        txtAddress.Text = row.Cells["Address"].Value != DBNull.Value
                                          ? row.Cells["Address"].Value?.ToString()
                                          : "No Address Available";

                        // Handle Email field
                        txtEmail.Text = row.Cells["Email"].Value != DBNull.Value
                                        ? row.Cells["Email"].Value?.ToString()
                                        : "No Email Available";

                        // Handle ContactNumber field
                        txtContactNo.Text = row.Cells["ContactNumber"].Value != DBNull.Value
                                            ? row.Cells["ContactNumber"].Value?.ToString()
                                            : "No Contact Available";

                        // Populate the Section combo box with the correct value
                        cmbBoxSection.Text = row.Cells["Section"].Value?.ToString() ?? string.Empty;

                        // Populate Year and Student Number fields
                        string studentNumber = row.Cells["StudentNumber"].Value?.ToString();
                        txtStudentNo.Text = !string.IsNullOrEmpty(studentNumber) ? studentNumber : "No Student Number";

                        string yearValue = row.Cells["Year"].Value?.ToString();
                        cmbBoxYear.Text = !string.IsNullOrEmpty(yearValue) ? yearValue : "No Year";

                        // Handle ProfileImage if available
                        byte[] imageBytes = row.Cells["ProfileImage"].Value as byte[];
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBoxProfile.Image = Image.FromStream(ms);
                                pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        else
                        {
                            pictureBoxProfile.Image = null; // Set to default image if no profile image
                        }

                        // Enable editing and reset background color
                        txtFirstName.ReadOnly = false;
                        txtMiddleName.ReadOnly = false;
                        txtLastName.ReadOnly = false;
                        txtAge.ReadOnly = false;
                        txtStudentNo.ReadOnly = false;
                        txtEmail.ReadOnly = false;
                        txtContactNo.ReadOnly = false;
                        txtAddress.ReadOnly = false;
                        cmbBoxYear.Enabled = true;
                        cmbBoxSection.Enabled = true;

                        txtFirstName.BackColor = Color.White;
                        txtMiddleName.BackColor = Color.White;
                        txtLastName.BackColor = Color.White;
                        txtAge.BackColor = Color.White;
                        txtStudentNo.BackColor = Color.White;
                        txtEmail.BackColor = Color.White;
                        txtContactNo.BackColor = Color.White;
                        txtAddress.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
