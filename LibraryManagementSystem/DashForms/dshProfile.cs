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
                "ABM",
                "HUMSS",
                "TVL-ICT",
                "TVL-HE",
                "GAS",
                "STEM",

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

            // Regular expression for validating FirstName, LastName (letters and spaces only)
            string namePattern = @"^[A-Za-z\s]+$"; // Matches letters and spaces only

            // Regular expression for validating MiddleName (letters, spaces, and dots allowed)
            string middleNamePattern = @"^[A-Za-z\s\.]+$"; // Matches letters, spaces, and dots only

            // Regular expression for validating Contact Number (digits, spaces, dashes, and parentheses)
            string contactNumberPattern = @"^[0-9\s\-\(\)]*$"; // Matches digits, spaces, dashes, and parentheses only

            // Regular expression for validating Student Number (numeric only or alphanumeric, change based on your requirement)
            string studentNumberPattern = @"^[A-Za-z0-9]+$"; // Matches alphanumeric only (adjust if needed)

            // Validate FirstName (only letters and spaces)
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text, namePattern))
            {
                MessageBox.Show("First Name can only contain letters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate MiddleName (only letters, spaces, and dots)
            if (string.IsNullOrWhiteSpace(txtMiddleName.Text) || !Regex.IsMatch(txtMiddleName.Text, middleNamePattern))
            {
                MessageBox.Show("Middle Name can only contain letters, spaces, and dots.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate LastName (only letters and spaces)
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text, namePattern))
            {
                MessageBox.Show("Last Name can only contain letters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Age (must be a valid number)
            if (string.IsNullOrWhiteSpace(txtAge.Text) || !int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Age must be a valid number greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Contact Number (must only contain digits, spaces, dashes, or parentheses)
            if (string.IsNullOrWhiteSpace(txtContactNo.Text) || !Regex.IsMatch(txtContactNo.Text, contactNumberPattern))
            {
                MessageBox.Show("Contact Number can only contain digits, spaces, dashes, or parentheses.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Student Number (must only contain alphanumeric characters)
            if (string.IsNullOrWhiteSpace(txtStudentNo.Text) || !Regex.IsMatch(txtStudentNo.Text, studentNumberPattern))
            {
                MessageBox.Show("Student Number can only contain alphanumeric characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                    // Step 1: If a new StudentNumber is entered, check if it already exists
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

                    // Step 2: Check if any field has been modified (using dynamic comparison)
                    bool isModified = CheckIfFieldsModified(con, txtStudentNo.Text);

                    if (!isModified && string.IsNullOrEmpty(txtNewStudentNumber.Text))
                    {
                        MessageBox.Show("No changes were made to the user information.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Step 3: Perform the update
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
                        updateCmd.Parameters.AddWithValue("@Age", string.IsNullOrWhiteSpace(txtAge.Text) ? DBNull.Value : (object)txtAge.Text);
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
            // Set the PictureBox size to 2x2 inches (approx 192x192 pixels assuming 96 DPI)
            pictureBoxProfile.Width = 192;
            pictureBoxProfile.Height = 192;

            // Set the SizeMode to Zoom or StretchImage, depending on how you want the image to fit.
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom; // or StretchImage if you prefer stretching

            // Optionally, you could load an image or perform other operations here
            // Example: pictureBoxProfile.Image = Image.FromFile("path_to_image.jpg");
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            // Only perform search if the textbox is not empty
            if (!string.IsNullOrEmpty(txtSearchUser.Text))
            {
                SearchStudent(txtSearchUser.Text);
            }
            else
            {
                // If the search box is empty, clear the DataGridView or load all records
                LoadAllStudents();
            }
        }

        private void SearchStudent(string searchText)
        {
            // Connection string
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // SQL query to search for students by StudentNumber, FirstName, or LastName
            string searchQuery = @"
        SELECT * FROM ActiveBorrowers
        WHERE StudentNumber LIKE @SearchText
           OR FirstName LIKE @SearchText
           OR LastName LIKE @SearchText";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Create command to execute the query
                    using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                    {
                        // Use the parameter to avoid SQL injection
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        // Use SqlDataAdapter to fill data into DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind DataTable to the DataGridView
                        dataGridSearchInfo.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAllStudents()
        {
            // Connection string
            string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // SQL query to load all students
            string loadQuery = "SELECT * FROM ActiveBorrowers";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Create command to execute the query
                    using (SqlCommand cmd = new SqlCommand(loadQuery, con))
                    {
                        // Use SqlDataAdapter to fill data into DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind DataTable to the DataGridView
                        dataGridSearchInfo.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridSearchInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                // Get the data of the selected row
                DataGridViewRow row = dataGridSearchInfo.Rows[e.RowIndex];

                // Populate the textboxes with the data from the selected row
                txtStudentNo.Text = row.Cells["StudentNumber"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtMiddleName.Text = row.Cells["MiddleName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtContactNo.Text = row.Cells["ContactNumber"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                cmbBoxGender.SelectedItem = row.Cells["Gender"].Value.ToString();
                cmbBoxYear.SelectedItem = row.Cells["Year"].Value.ToString();
                cmbBoxSection.SelectedItem = row.Cells["Section"].Value.ToString();
                BirthdayDateTimePicker.Value = Convert.ToDateTime(row.Cells["Birthday"].Value);

                // Optionally, you can also display the profile image in a PictureBox (if you have that column in your DataGridView)
                byte[] profileImageBytes = row.Cells["ProfileImage"].Value as byte[];
                if (profileImageBytes != null && profileImageBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(profileImageBytes))
                    {
                        Image image = Image.FromStream(ms);

                        // Set the PictureBox SizeMode to StretchImage so the image fits the PictureBox without zooming
                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxProfile.Image = image;
                    }
                }
                else
                {
                    // Optionally, clear the picture if no image is available
                    pictureBoxProfile.Image = null;
                }
            }
        }
    }
}
