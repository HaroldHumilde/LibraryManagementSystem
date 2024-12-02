using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class RecordForm : Form
    {

        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; } // New property
        public string Email { get; set; }
        public string ContactNumber { get; set; }





        public RecordForm(string studentNum, string firstName, string lastName, string middleName, string gender, string year, string section, string age, string email, string contactno, DateTime birthday, string address)
        {
            InitializeComponent();


            StudentNumber = studentNum;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Gender = gender;
            Year = year;
            Section = section;
            Age = int.TryParse(age, out int parsedAge) ? parsedAge : 0;
            Birthday = birthday;
            Address = address; // Assign Address
            Email = email;
            ContactNumber = contactno;
        }

       

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecordForm_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentNumber;
            lblFirstName.Text = FirstName;
            lblLastName.Text = LastName;
            lblMiddleName.Text = MiddleName;
            lblAge.Text = Age.ToString();
            lblGender.Text = Gender;
            lblYear.Text = Year;
            lblSection.Text = Section;
            lblAddress.Text = Address;
            lblEmail.Text = Email; // Ensure lblEmail exists
            lblContactNumber.Text = ContactNumber; // Ensure lblContactNumber exists

            // Console.WriteLine($"Debug: Gender={Gender}, Year={Year}, Section={Section}, Age={Age}");

        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void lblSection_Click(object sender, EventArgs e)
        {

        }
    }
}
