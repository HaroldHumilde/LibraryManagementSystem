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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class UserProfileEdit : Form
    {
        private long _StudentNumber;
        private long _ContactNo;
        private int _Age;
        private string _Gender;
        private string _Section;
        private string _Year;
        private string _Email;
        private string _Birthday;
        private string _Address;
        private string _LastName;
        private string _FirstName;
        private string _MiddleName;

        // Properties to hold user data
        public long StudentNumber { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Age { get; private set; }
        public string Gender { get; private set; }
        public string Year { get; private set; }
        public string Section { get; private set; }
        public string ContactNo { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Birthday { get; private set; }

        public UserProfileEdit(long studentNo, string firstName, string lastName, string middleName, string age, string gender, string year, string section, string contactNo, string email, string address, DateTime birthday)
        {
            InitializeComponent();


            // Set form properties
            StudentNumber = studentNo;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Age = age;
            Gender = gender;
            Year = year;
            Section = section;
            ContactNo = contactNo;
            Email = email;
            Address = address;
            Birthday = birthday;

            // Populate the UI elements
            txtStudentNo.Text = studentNo.ToString();
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtMiddleName.Text = middleName;
            txtAge.Text = age;
            cmbBoxGender.Text = gender;
            cmbBoxYear.Text = year;
            cmbBoxSection.Text = section;
            txtContactNo.Text = contactNo;
            txtEmail.Text = email;
            txtAddress.Text = address;
            BirthdayDateTimePicker.Value = birthday;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Make sure the instance variables are correctly set
                _StudentNumber = long.Parse(txtStudentNo.Text);
                _FirstName = txtFirstName.Text;
                _LastName = txtLastName.Text;
                _MiddleName = txtMiddleName.Text;
                _Age = int.Parse(txtAge.Text);  // Make sure to parse the age as an integer
                _Gender = cmbBoxGender.Text;
                _Year = cmbBoxYear.Text;
                _Section = cmbBoxSection.Text;
                _ContactNo = long.Parse(txtContactNo.Text);
                _Email = txtEmail.Text;
                _Address = txtAddress.Text;
                _Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");

                // Now update the database with the new values
                UpdateUserProfile(_StudentNumber, _FirstName, _LastName, _MiddleName, _Age.ToString(), _Gender, _Year, _Section, _ContactNo.ToString(), _Email, DateTime.Parse(_Birthday), _Address);

                MessageBox.Show("User profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Close the edit form
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateUserProfile(long studentNo, string firstName, string lastName, string middleName, string age, string gender, string year, string section, string contactNo, string email, DateTime birthday, string address)
        {
            string connectionString = "Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string query = "UPDATE RegisterInformations SET FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, " +
                           "Age = @Age, Gender = @Gender, Year = @Year, Section = @Section, ContactNo = @ContactNo, Email = @Email, " +
                           "Birthday = @Birthday, Address = @Address WHERE StudentNumber = @StudentNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StudentNumber", studentNo);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@MiddleName", middleName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Section", section);
                cmd.Parameters.AddWithValue("@ContactNo", contactNo);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Address", address);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record found for the specified student number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserProfileEdit_Load(object sender, EventArgs e)
        {
            

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
        public long studentnumber(string studNum)
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

        public int ages(string age)
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
        public long contactNo(string contactNumber)
        {
            _ContactNo = long.Parse(contactNumber);
            return _ContactNo;
        }

        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
