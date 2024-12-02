using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        public string Password { get;  set; }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            // Get the entered password from the text box
            string enteredPassword = txtPassword.Text;

            // Validate the password against the database
            if (ValidatePassword(enteredPassword))
            {
                // If password is correct, close the Admin form and show the Inventory form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password. Access denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate the password by querying the database
        private bool ValidatePassword(string enteredPassword)
        {
            bool isValid = false;

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;TrustServerCertificate=True"))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(*) FROM loginform WHERE password = @password";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@password", enteredPassword);

                    int count = (int)cmd.ExecuteScalar();

                    isValid = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error validating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
