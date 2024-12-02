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
    public partial class ViewProfileForm : Form
    {
        private string connectionData = @"Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        private long _StudentNumber;
        private long _ContactNo;
        private int _Age;
        private string _Penalty;
        private string _Gender;
        private string _Section;
        private string _Year;
        private string _Email;
        private string _Birthday;
        private string _Address;
        private string _Lastname;
        private string _FirstName;
        private string _MiddleName;

        private BindingSource showPenalty;

        public ViewProfileForm()
        {
            InitializeComponent();
            showPenalty = new BindingSource();

            LoadData();

        }
        private void LoadData()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionData))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM RegisterInformations", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);

                dataViewBorrowerInfo.DataSource = dtbl;
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
            _Age = int.Parse(age);
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

        //Custom Exception
        class NumberFormatException : Exception
        {
            public NumberFormatException(string number) : base(number) { }

        }

        private void ViewProfileForm_Load(object sender, EventArgs e)
        {
           

            try
            {
                string[] ListofPenalty= new string[]{

                "Damage Book",
                "Lost Book",
                "Unpaid Lost Book",
                "Unpaid Damage Book",
                "Damage Inside Library",

            };
                for (int i = 0; i < 5; i++)
                {
                   cmbPenalty.Items.Add(ListofPenalty[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }

        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchProf_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            // Corrected SQL query: Assume you want to search by 'StudentNumber'
            string sql = "SELECT * FROM RegisterInformations WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(sql, con);

            // Use parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@StudentNumber", txtSearchBorrower.Text);

            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Combining first, middle, and last name into one label
                    lblName.Text = reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString() + " " + reader["LastName"].ToString();

                    lblAge.Text = reader["Age"].ToString();
                    lblGender.Text = reader["Gender"].ToString();
                    lblDateOfBirth.Text = Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd");  // Format date if needed
                    lblStudentNumber.Text = reader["StudentNumber"].ToString();
                    lblYear.Text = reader["Year"].ToString();
                    lblSection.Text = reader["Section"].ToString();
                    lblAddress.Text = reader["Address"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblContactNumber.Text = reader["ContactNumber"].ToString();
                    lblPenalty.Text = reader["Penalty"].ToString();
                }
            }
            con.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-IUO5MFF;Initial Catalog=lmsdcs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE RegisterInformations WHERE StudentNumber = @StudentNumber", con);
            cmd.Parameters.AddWithValue("@StudentNumber", txtSearchBorrower.Text);
            cmd.ExecuteNonQuery();
            
            con.Close();
            LoadData();
            MessageBox.Show("Successfully Deleted");
        }

        private void dataViewBorrowerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            _Penalty = cmbPenalty.Text;



            showPenalty.Add(new ViewProf(_Penalty));
            dataViewBorrowerInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataViewBorrowerInfo.DataSource = showPenalty;
        }

        private void txtSearchBorrower_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
