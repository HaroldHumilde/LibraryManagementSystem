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
    public partial class dshDashBoard : Form
    {

        private string connectionString = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";


        // Timer to refresh counts periodically
        private Timer refreshTimer;

        public dshDashBoard()
        {
            InitializeComponent();

            

            UpdateDashboardCounts(); // Update all counts on form load
        }



        // Method to update all counts on the dashboard
        private void UpdateDashboardCounts()
        {
            UpdateActiveBorrowersLabel();
            UpdateBooksCountLabel();
            UpdateUnreturnedBooksCountLabel();

        }

        // Method to update the count of Active Borrowers
        private void UpdateActiveBorrowersLabel()
        {
            string query = "SELECT COUNT(*) AS ActiveBorrower FROM ActiveBorrowers";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    int activeBorrowerCount = (int)(cmd.ExecuteScalar() ?? 0); // Safely handle null
                    lblActiveBorrowers.Text = activeBorrowerCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the active borrowers count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update the count of Books in Inventory
        private void UpdateBooksCountLabel()
        {
            string query = "SELECT COUNT(*) AS BookCount FROM Inventory";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    int bookCount = (int)(cmd.ExecuteScalar() ?? 0); // Safely handle null
                    lblBooksCount.Text = bookCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the books count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Method to update the count of Unreturned Books
        private void UpdateUnreturnedBooksCountLabel()
        {
            string query = "SELECT COUNT(*) AS UnreturnedBooksCount FROM BookBorrowing WHERE Status = 'unreturned'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    int unreturnedBooksCount = (int)(cmd.ExecuteScalar() ?? 0); // Safely handle null
                    lblUnreturnedBooksCount.Text = unreturnedBooksCount.ToString(); // Assuming you have a label for this count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the unreturned books count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateDashboardCounts(); // Call method to update counts every time the Timer ticks
        }
    }
}
