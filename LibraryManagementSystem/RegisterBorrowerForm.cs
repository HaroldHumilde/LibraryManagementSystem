using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Net;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace LibraryManagementSystem
{
    public partial class RegisterBorrowerForm : Form
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
        private string _Lastname;
        private string _FirstName;
        private string _MiddleName;
       

        private BindingSource showRegisteredInfo;
        public RegisterBorrowerForm()
        {
            InitializeComponent();

            showRegisteredInfo = new BindingSource();
        }


        private void RegisterBorrowerForm_Load(object sender, EventArgs e)
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
             _StudentNumber = StudentNumber(txtStudentNo.Text.ToString());
            _ContactNo = ContactNo(txtContactNo.Text.ToString());
            _Age = Age(txtAge.Text.ToString());
            _Gender = cmbBoxGender.Text;
            _Section = cmbBoxSection.Text;
            _Year = cmbBoxYear.Text;
            _Email = txtEmail.Text;
            _Birthday = BirthdayDateTimePicker.Value.ToString("yyyy-MM-dd");
            _Address = txtAddress.Text;
            _Lastname = txtLastname.Text;
            _FirstName = txtFirstname.Text;
            _MiddleName = txtMiddlename.Text;

            showRegisteredInfo.Add(new AddRegisterForm(_StudentNumber, _Year, _Lastname, _FirstName, _MiddleName, _Birthday, _Age, _Gender, _Address, _Section, _Email, _ContactNo));
            dataGridViewRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRegister.DataSource = showRegisteredInfo;

           try 
            { 

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into RegisterInformations (StudentNumber,Year,Lastname,Firstname,Middlename,Birthday,Age,Gender,Address,Section,Email,ContactNumber) values ('" + _StudentNumber + "','" + _Year +  "','" +  _Lastname+ "','"+ _FirstName + "','"+ _MiddleName + "','" + _Birthday + "','" + _Age + "','" + _Gender + "','" + _Address + "','" + _Section + "','" + _Email + "','" + _ContactNo + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                con.Close();
                MessageBox.Show("Registered Successfully! ");
            }
           catch (Exception ex)
           {

               Console.WriteLine("An error occurred: " + ex.Message);
           }
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


            

        private void dataGridViewRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public long ContactNo(string contactNumber)
        {
            _ContactNo = long.Parse(contactNumber);
            return _ContactNo;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Establish the SQL connection
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            // SQL query to search by StudentNumber
            string sql = "SELECT * FROM RegisterInformations WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(sql, con);

            // Add parameter for StudentNumber
            cmd.Parameters.AddWithValue("@StudentNumber", txtStudentNo.Text);

            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                try
                {
                    if (reader.Read())
                    {
                        // Gather data from the SQL reader
                        string fullName = reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString() + " " + reader["LastName"].ToString();
                        string age = reader["Age"].ToString();
                        string gender = reader["Gender"].ToString();
                        string birthday = Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd");
                        string studentNumber = reader["StudentNumber"].ToString();
                        string year = reader["Year"].ToString();
                        string section = reader["Section"].ToString();
                        string address = reader["Address"].ToString();
                        string email = reader["Email"].ToString();
                        string contactNumber = reader["ContactNumber"].ToString();

                        // Create the ProfileInformationForm instance and pass the data
                        ProfileInformationForm profileInformationForm = new ProfileInformationForm();
                        profileInformationForm.SetProfileData(fullName, age, gender, birthday, studentNumber, year, section, address, email, contactNumber);

                        // Show the profile form
                        profileInformationForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No record found for the given Student Number.");
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            con.Close();

           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentNo.Clear();
            txtLastname.Clear();
            txtMiddlename.Clear();
            txtFirstname.Clear();
            txtAge.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbBoxGender.Text = string.Empty;
            cmbBoxSection.Text = string.Empty;
            cmbBoxYear.Text = string.Empty;
            BirthdayDateTimePicker.Checked = false;
            BirthdayDateTimePicker.Value = DateTime.Today;


        }
    }
}
