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
using AForge.Video;
using AForge.Video.DirectShow;


namespace LibraryManagementSystem
{
    public partial class dshRegister : Form
    {
        private FilterInfoCollection videoDevices;  // List of available video devices
        private VideoCaptureDevice videoSource;  // Video capture device
        private Bitmap capturedImage;  // Store captured image

        

        private byte[] profileImageBytes;  // Declare profileImageBytes at the class level
        public dshRegister()
        {
            InitializeComponent();


            InitializeCamera();





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



        private void btnRegister_Click(object sender, EventArgs e)
        {

            // User input values
            string studentNumber = txtStudentNo.Text;
            string contactNo = txtContactNo.Text;
            string ageText = txtAge.Text;  // Will convert to int
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
                if (pictureBoxProfile.Image == null)
                {
                    // Throw an exception if no image is captured
                    throw new InvalidOperationException("Please capture an image before registering.");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields before registering.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // Exit the method to prevent the registration process
            }

            // Validate if the age, student number, and contact number are valid numbers
            int age;
            if (!int.TryParse(ageText, out age))
            {
                MessageBox.Show("Please enter a valid age.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if age is not a valid integer
            }

            // Validate if the student number and contact number are valid numbers
            long studentNo;
            if (!long.TryParse(studentNumber, out studentNo))
            {
                MessageBox.Show("Please enter a valid Student Number.", "Invalid Student Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if student number is not valid
            }

            long contactNoLong;
            if (!long.TryParse(contactNo, out contactNoLong))
            {
                MessageBox.Show("Please enter a valid Contact Number.", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if contact number is not valid
            }

            // Validate that LastName, FirstName, and MiddleName contain only letters and spaces
            foreach (char c in lastName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Last Name must contain only letters and spaces.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit if last name contains invalid characters
                }
            }

            foreach (char c in firstName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("First Name must contain only letters and spaces.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit if first name contains invalid characters
                }
            }

            foreach (char c in middleName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Middle Name must contain only letters and spaces.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit if middle name contains invalid characters
                }
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
            else
            {
                // If the image is null, throw an exception to indicate that the picture was not captured
                throw new InvalidOperationException("Please capture an image before registering.");
            }

            try
            {
                // SQL connection string
                string connectionData = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connectionData))
                {
                    con.Open();

                    // Get the highest existing ID value from ActiveBorrowers and increment by 1
                    SqlCommand getMaxIdCmd = new SqlCommand("SELECT ISNULL(MAX(ID), 0) + 1 FROM ActiveBorrowers", con);
                    int newId = Convert.ToInt32(getMaxIdCmd.ExecuteScalar());

                    // SQL query to insert data with the manually generated ID, including the profile image
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"
    INSERT INTO ActiveBorrowers 
    (ID, StudentNumber, Year, Lastname, Firstname, Middlename, Birthday, Age, Gender, Address, Section, Email, ContactNumber, ProfileImage) 
    VALUES 
    (@ID, @StudentNumber, @Year, @Lastname, @Firstname, @Middlename, @Birthday, @Age, @Gender, @Address, @Section, @Email, @ContactNumber, @ProfileImage)";

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ID", newId);
                    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Lastname", lastName);
                    cmd.Parameters.AddWithValue("@Firstname", firstName);
                    cmd.Parameters.AddWithValue("@Middlename", middleName);
                    cmd.Parameters.AddWithValue("@Birthday", birthday);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ContactNumber", contactNo);

                    // Add the image byte array to the parameter
                    cmd.Parameters.AddWithValue("@ProfileImage", profileImageBytes);

                    // Execute the insert query
                    cmd.ExecuteNonQuery();
                }

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
                // Clear the image from the PictureBox
                pictureBoxProfile.Image = null;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Stop the camera if it's running
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();  // Stop the video feed
                videoSource.WaitForStop();   // Wait until the camera has fully stopped
            }

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

                        // Optionally resize the image to fit within the PictureBox
                        int newWidth = 192;  // Define the maximum width
                        int newHeight = (int)((float)image.Height / image.Width * newWidth);  // Maintain aspect ratio

                        // Set the PictureBox size dynamically
                        pictureBoxProfile.Width = newWidth;
                        pictureBoxProfile.Height = newHeight;

                        // Set the SizeMode to Zoom to preserve the aspect ratio
                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;

                        // Display the image in the PictureBox
                        pictureBoxProfile.Image = image;

                        // Convert the image to a byte array (for saving to the database or other use)
                        profileImageBytes = ImageToByteArray(image);  // Store the byte array here

                        // Optional: Store the byte array as Base64 for reference
                        lblProfileImage.Text = Convert.ToBase64String(profileImageBytes);  // Optional: Store Base64 in label for reference
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
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  // Save image as JPEG
                return ms.ToArray();  // Convert the image to a byte array
            }
        }

      

        private void btnCamera_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that the checkbox is checked to open the camera
                if (cbCamera.Checked)
                {
                    // Initialize videoDevices if not already done
                    if (videoDevices == null || videoDevices.Count == 0)
                    {
                        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        if (videoDevices.Count == 0)
                        {
                            MessageBox.Show("No video devices found. Please connect a camera.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // If the video source is not initialized, initialize it
                    if (videoSource == null || !videoSource.IsRunning)
                    {
                        InitializeCamera();
                        MessageBox.Show("Camera started.", "Camera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // If the camera is running, capture an image and stop the camera
                        if (pictureBoxProfile.Image != null)
                        {
                            Bitmap capturedImage = (Bitmap)pictureBoxProfile.Image.Clone();

                            videoSource.SignalToStop();
                            videoSource.WaitForStop();

                            pictureBoxProfile.Image = capturedImage;

                            MessageBox.Show("Image captured successfully", "Capture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No image to capture. Ensure the camera is running.", "Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Camera is not started if the checkbox is unchecked
                    MessageBox.Show("Camera not enabled. Please check the camera option first.", "Camera Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // Create a bitmap from the current frame
                Bitmap originalFrame = new Bitmap(eventArgs.Frame);

                // Flip the image horizontally to remove the mirror effect
                originalFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);  // Flip horizontally

                // Resize the corrected frame to fit the PictureBox size
                Bitmap resizedFrame = new Bitmap(originalFrame, pictureBoxProfile.Width, pictureBoxProfile.Height);

                // Set PictureBox SizeMode to Zoom to automatically scale the image
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;

                // Display the resized frame in the picture box
                pictureBoxProfile.Image = resizedFrame;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing the frame: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dshRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }



        private void InitializeCamera()
        {
            try
            {
                // Initialize video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count > 0)
                {
                    // Initialize video capture device
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

                    // Set resolution and other properties (optional)
                    videoSource.VideoResolution = videoSource.VideoCapabilities[0]; // Select the first resolution

                    // Attach event handler for NewFrame
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);

                    // Start the camera feed
                    videoSource.Start();
                }
                else
                {
                    MessageBox.Show("No camera found. Please connect a camera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while starting the camera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void StopCamera()
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping the camera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void cbCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCamera.Checked)
            {
                // Initialize and start the camera when the checkbox is checked
                InitializeCamera();
            }
            else
            {
                // Stop the camera when the checkbox is unchecked
                if (videoSource != null && videoSource.IsRunning)
                {
                    StopCamera();
                    pictureBoxProfile.Image = null;
                    MessageBox.Show("Camera stopped.", "Camera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
