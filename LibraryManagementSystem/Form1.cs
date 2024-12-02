using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // Initialize placeholder text for username and password
            MaskedUserNameText();
            MaskedPasswordText();


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

      


        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM loginform WHERE username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("username", txtUserName.Text);
                cmd.Parameters.AddWithValue("password", txtPassword.Text);

                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("Login Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DashBoardForm dashboardForm = new DashBoardForm();
                    dashboardForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the checkbox
            if (chckBoxShowPassword.Checked)
            {
                // Show password as plain text by setting PasswordChar to \0 (empty char)
                txtPassword.PasswordChar = '\0';  // Plain text
            }
            else
            {
                // Mask password by setting PasswordChar to '*'
                txtPassword.PasswordChar = '*';  // Masked (asterisks)
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {



        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }


        // Placeholder for the Username field
        private void MaskedUserNameText()
        {
            txtUserName.Text = "Username";
            txtUserName.ForeColor = Color.Gray; // Placeholder color
            txtUserName.Enter += (sender, e) =>
            {
                if (txtUserName.Text == "Username")
                {
                    txtUserName.Text = ""; // Clear placeholder on focus
                    txtUserName.ForeColor = Color.Black; // Set text color to black
                }
            };

            txtUserName.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    txtUserName.Text = "Username"; // Restore placeholder text
                    txtUserName.ForeColor = Color.Gray; // Set placeholder color
                }
            };
        }

        private void MaskedPasswordText()
        {
            // Set the placeholder text initially
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray; // Placeholder color
            txtPassword.PasswordChar = '*'; // Initially masked with asterisk (PasswordChar)

            // Handle Enter event to clear the placeholder
            txtPassword.Enter += (sender, e) =>
            {
                if (txtPassword.Text == "Password")
                {
                    txtPassword.Text = ""; // Clear the placeholder when focused
                    txtPassword.ForeColor = Color.Black; // Set text color to black
                }
            };

            // Handle Leave event to restore the placeholder
            txtPassword.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.Text = "Password"; // Restore placeholder text
                    txtPassword.ForeColor = Color.Gray; // Set placeholder color back to gray
                }
            };
        }



        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphanumeric characters in the username
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only valid characters in the password field (optional)
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
