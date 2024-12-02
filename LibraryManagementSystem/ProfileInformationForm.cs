using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ProfileInformationForm : Form
    {

        public static RegisterBorrowerForm instance;
        public Label label;

        public ProfileInformationForm()
        {
            InitializeComponent();
          
        }
        // Method to receive and display profile data
        public void SetProfileData(string fullName, string age, string gender, string birthday, string studentNumber, string year, string section, string address, string email, string contactNumber)
        {
            lblName.Text = fullName;
            lblAge.Text = age;
            lblGender.Text = gender;
            lblBirthday.Text = birthday;
            lblStudentNo.Text = studentNumber;
            lblYear.Text = year;
            lblSection.Text = section;
            lblAddress.Text = address;
            lblEmail.Text = email;
            lblContacNo.Text = contactNumber;
        }

        private void ProfileInformationForm_Load(object sender, EventArgs e)
        {
          /* lblStudentNo.Text = BorrowerInformations.SetStudentNo.ToString();
            lblName.Text = BorrowerInformations.SetFullname.ToString();
            lblSection.Text = BorrowerInformations.SetSection.ToString();
            lblBirthday.Text = BorrowerInformations.SetBirthday.ToString();
            lblAge.Text = BorrowerInformations.SetAge.ToString();
            lblGender.Text = BorrowerInformations.SetGender.ToString();
            lblYear.Text = BorrowerInformations.SetYear.ToString();
            lblAddress.Text = BorrowerInformations.SetAddress.ToString();
            lblContacNo.Text = BorrowerInformations.SetContactNo.ToString();
            lblEmail.Text = BorrowerInformations.SetEmail.ToString();  */
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblStudentNo_Click(object sender, EventArgs e)
        {
           
        }
    }
}
