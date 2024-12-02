using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LibraryManagementSystem
{
    public partial class dshRegister : Form
    {


        // Declare the class-level variable to store the image bytes
        private byte[] profileImageBytes;

        public dshRegister()
        {
            InitializeComponent();

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

            };
                for (int i = 0; i < 5; i++)
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
        }

        private long _StudentNumber;
        private long _ContactNo;
        private int _Age;
        private string _Gender;
        private string _Section;
        private string _Year;
        private string _Email;
        private string _Birthday;
        private string _Address;
        private string _Lastname;
        private string _FirstName;
        private string _MiddleName;

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // User input values
            string studentNumber = txtStudentNo.Text.ToString();
            string contactNo = txtContactNo.Text.ToString();
            string ageText = txtAge.Text.ToString();  // Will convert to int
            string gender = cmbBoxGender.Text;
            string section = cmbBoxSection.Text;
            string year = cmbBoxYear.Text;
            string email = txtEmail.Text;
            string birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
            string address = txtAddress.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;

            // Check if any required field is empty
            if (string.IsNullOrEmpty(studentNumber) ||
                string.IsNullOrEmpty(contactNo) ||
                string.IsNullOrEmpty(ageText) || // Age needs to be checked for valid number
                string.IsNullOrEmpty(gender) ||
                string.IsNullOrEmpty(section) ||
                string.IsNullOrEmpty(year) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(middleName) ||
                pictureBoxProfile.Image == null) // Ensure profile image is set
            {
                MessageBox.Show("Please fill in all fields before registering.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent the registration process
            }

            // Validate if the age is a valid number
            int age;
            if (!int.TryParse(ageText, out age))
            {
                MessageBox.Show("Please enter a valid age.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if age is not a valid integer
            }

            // Get the ProfileImage from PictureBox (or your chosen control)
            byte[] profileImageBytes = null;
            if (pictureBoxProfile.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxProfile.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    profileImageBytes = ms.ToArray();  // Convert image to byte array
                }
            }

            try
            {
                // SQL connection
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                con.Open();

                // Get the highest existing ID value from ActiveBorrowers and increment by 1
                SqlCommand getMaxIdCmd = new SqlCommand("SELECT MAX(ID) FROM ActiveBorrowers", con);
                object result = getMaxIdCmd.ExecuteScalar();
                int newId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1; // If no records exist, start from 1

                // SQL query to insert data with the manually generated ID, including the profile image
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"
    INSERT INTO ActiveBorrowers 
    (ID, StudentNumber, Year, Lastname, Firstname, Middlename, Birthday, Age, Gender, Address, Section, Email, ContactNumber, ProfileImage) 
    VALUES 
    (@ID, @StudentNumber, @Year, @Lastname, @Firstname, @Middlename, @Birthday, @Age, @Gender, @Address, @Section, @Email, @ContactNumber, 
    CONVERT(varbinary(max), @ProfileImage))";  // Use CONVERT for the profile image

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@ID", newId); // Add the newly generated ID
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Lastname", lastName);
                cmd.Parameters.AddWithValue("@Firstname", firstName);
                cmd.Parameters.AddWithValue("@Middlename", middleName);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Age", age); // Use the valid age
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Section", section);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNo);

                // If the image is not null, add the byte array to the parameter
                if (profileImageBytes != null)
                {
                    cmd.Parameters.AddWithValue("@ProfileImage", profileImageBytes);
                }
                else
                {
                    // If no image was provided, pass NULL to the database
                    cmd.Parameters.AddWithValue("@ProfileImage", DBNull.Value);
                }

                // Execute the insert query
                cmd.ExecuteNonQuery();

                con.Close();

                // Show success message
                MessageBox.Show("Registered Successfully!");

                // Clear the input fields after registration
                txtStudentNo.Clear();
                txtLastName.Clear();
                txtMiddleName.Clear();
                txtFirstName.Clear();
                txtAge.Clear();
                txtContactNo.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                cmbBoxGender.SelectedIndex = -1;  // Clears the gender ComboBox
                cmbBoxSection.SelectedIndex = -1; // Clears the section ComboBox
                cmbBoxYear.SelectedIndex = -1;    // Clears the year ComboBox
                BirthdayDateTimePicker.Checked = false;
                BirthdayDateTimePicker.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /* // User input values
             _StudentNumber = StudentNumber(txtStudentNo.Text.ToString());
             _ContactNo = ContactNo(txtContactNo.Text.ToString());
             _Age = Age(txtAge.Text.ToString());
             _Gender = cmbBoxGender.Text;
             _Section = cmbBoxSection.Text;
             _Year = cmbBoxYear.Text;
             _Email = txtEmail.Text;
             _Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
             _Address = txtAddress.Text;
             _Lastname = txtLastName.Text;
             _FirstName = txtFirstName.Text;
             _MiddleName = txtMiddleName.Text;

             try
             {
                 // SQL connection
                 SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                 con.Open();

                 // Get the highest existing ID value from ActiveBorrowers and increment by 1
                 SqlCommand getMaxIdCmd = new SqlCommand("SELECT MAX(ID) FROM ActiveBorrowers", con);
                 object result = getMaxIdCmd.ExecuteScalar();
                 int newId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1; // If no records exist, start from 1

                 // SQL query to insert data with the manually generated ID
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.CommandText = @"
             INSERT INTO ActiveBorrowers 
             (ID, StudentNumber, Year, Lastname, Firstname, Middlename, Birthday, Age, Gender, Address, Section, Email, ContactNumber) 
             VALUES 
             (@ID, @StudentNumber, @Year, @Lastname, @Firstname, @Middlename, @Birthday, @Age, @Gender, @Address, @Section, @Email, @ContactNumber)";

                 // Add parameters to prevent SQL injection
                 cmd.Parameters.AddWithValue("@ID", newId); // Add the newly generated ID
                 cmd.Parameters.AddWithValue("@StudentNumber", _StudentNumber);
                 cmd.Parameters.AddWithValue("@Year", _Year);
                 cmd.Parameters.AddWithValue("@Lastname", _Lastname);
                 cmd.Parameters.AddWithValue("@Firstname", _FirstName);
                 cmd.Parameters.AddWithValue("@Middlename", _MiddleName);
                 cmd.Parameters.AddWithValue("@Birthday", _Birthday);
                 cmd.Parameters.AddWithValue("@Age", _Age);
                 cmd.Parameters.AddWithValue("@Gender", _Gender);
                 cmd.Parameters.AddWithValue("@Address", _Address);
                 cmd.Parameters.AddWithValue("@Section", _Section);
                 cmd.Parameters.AddWithValue("@Email", _Email);
                 cmd.Parameters.AddWithValue("@ContactNumber", _ContactNo);

                 // Execute the insert query
                 cmd.ExecuteNonQuery();

                 con.Close();

                 // Show success message
                 MessageBox.Show("Registered Successfully!");

                 // Clear the input fields after registration
                 txtStudentNo.Clear();
                 txtLastName.Clear();
                 txtMiddleName.Clear();
                 txtFirstName.Clear();
                 txtAge.Clear();
                 txtContactNo.Clear();
                 txtEmail.Clear();
                 txtAddress.Clear();
                 cmbBoxGender.SelectedIndex = -1;  // Clears the gender ComboBox
                 cmbBoxSection.SelectedIndex = -1; // Clears the section ComboBox
                 cmbBoxYear.SelectedIndex = -1;    // Clears the year ComboBox
                 BirthdayDateTimePicker.Checked = false;
                 BirthdayDateTimePicker.Value = DateTime.Today;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/



        }

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNumber = long.Parse(studNum);
            }
            catch (NumberFormatException io)
            {
                MessageBox.Show(io.Message, studNum);
            }
            return _StudentNumber;
        }

        public int Age(string age)
        {
            try
            {
                _Age = int.Parse(age);
            }
            catch (NumberFormatException io)
            {
                MessageBox.Show(io.Message);
            }
            return _Age;
        }
        public long ContactNo(string contactNumber)
        {
            _ContactNo = long.Parse(contactNumber);
            return _ContactNo;
        }

        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void dshRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dshRegister_Load(object sender, EventArgs e)
        {
            
        }

        

        private void pictureBoxCamera_Click(object sender, EventArgs e)
        {
          
        }

       

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to allow the user to select an image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter for image file types
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

                // Show the dialog and check if the user selects a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the image path from the file selected by the user
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        // Load the image from the file path
                        Image image = Image.FromFile(imagePath);

                        // Display the image in the PictureBox
                        pictureBoxProfile.Image = image;  // Assign the image to the PictureBox

                        // Convert the image to a byte array (for saving to the database)
                        byte[] imageBytes = ImageToByteArray(image);

                        // Store the byte array in a label or variable (Optional: Use it later for database insert)
                        lblProfileImage.Text = Convert.ToBase64String(imageBytes);  // Optional: Store as Base64 in label for reference

                        // Store the byte array in a class-level variable for use later (in database operation)
                        profileImageBytes = imageBytes;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  // Or use the desired format
                return ms.ToArray();  // Convert image to byte array
            }
        }
    }
}
