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
using Tulpep.NotificationWindow;


namespace LibraryManagementSystem
{
    public partial class DashBoardForm : Form
    {

        
        public DashBoardForm()
        {
            InitializeComponent();
            
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegisterDash_Click(object sender, EventArgs e)
        {

            /*if (panelContainer.Controls.OfType<dshRegister>().Any()) return;
            panelContainer.Controls.Clear();

            dshRegister dshregister = new dshRegister()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Width = panelContainer.ClientSize.Width,
                Height = panelContainer.ClientSize.Height
            };

            // Optionally center the form within the container
            dshregister.Location = new Point(
                (panelContainer.ClientSize.Width - dshregister.Width) / 2,
                (panelContainer.ClientSize.Height - dshregister.Height) / 2
            );

            panelContainer.Controls.Add(dshregister);
            dshregister.Show();*/

            if (panel2.Controls.OfType<dshRegister>().Any()) return;
            panel2.Controls.Clear();

            dshRegister dashregister = new dshRegister()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashregister);
            dashregister.Show();




            //btnRegisterDash.Text = pnlRegister.Visible ? " Hide Panel" : "Show Panel";



        }

        private void btnViewProfileDash_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshProfile>().Any()) return;
            panel2.Controls.Clear();

            dshProfile dashProfile = new dshProfile()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashProfile);
            dashProfile.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

            // Show the Admin form where user will input the password
            Admin adminForm = new Admin();

            // Show the Admin form as a dialog
            if (adminForm.ShowDialog() == DialogResult.OK)
            {
                // If password is correct, open the Inventory form
                if (panel2.Controls.OfType<dshInventory>().Any()) return;

                panel2.Controls.Clear();

                dshInventory dashinventory = new dshInventory()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                panel2.Controls.Add(dashinventory);
                dashinventory.Show();
                MenuTransition.Start();
            }
        }

       

        private void btnBookIssue_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshBorrower>().Any()) return;
            panel2.Controls.Clear();

            dshBorrower dashBorrower = new dshBorrower()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashBorrower);
            dashBorrower.Show();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
         

            PopupNotifier popUp = new PopupNotifier();
            popUp.BodyColor = Color.LightBlue;
            popUp.TitleText = "Due Date";
            popUp.ContentText = "Due Date of Book";
            popUp.Popup();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Toggle visibility of the panel
            panelShowButtons.Visible = !panelShowButtons.Visible;

            // Start animation or transition effect
            MenuTransition.Start();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        
        bool menuExpand = false;
       
        private void MenuTransition_Tick(object sender, EventArgs e)
        {
           
        }
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                panelShowButtons.Width -= 10;
                if (panelShowButtons.Width <= 43)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                panelShowButtons.Width += 10;
                if (panelShowButtons.Width >= 264)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }

                panel2.Visible = sidebarExpand;
                panel2.Visible = sidebarExpand;
                



            }
        }

        private void panelShowButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 logout = new Form1();
                logout.Show();
                this.Hide();

            }
        }

        private void btnLogBookIssue_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshLogDamageBook>().Any()) return;
            panel2.Controls.Clear();

            dshLogDamageBook dashLogDamageBook = new dshLogDamageBook()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashLogDamageBook);
            dashLogDamageBook.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelShowButtons_Paint_1(object sender, PaintEventArgs e)
        {
           
        }

        private void panelShowButtons_Paint_2(object sender, PaintEventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBorrowerList_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshBorrowerList>().Any()) return;
            panel2.Controls.Clear();

            dshBorrowerList dashBorrowerList = new dshBorrowerList()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashBorrowerList);
            dashBorrowerList.Show();
        }

       

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshBorrowerList>().Any()) return;
            panel2.Controls.Clear();

            dshBookReturn dashBookReturn = new dshBookReturn()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashBookReturn);
            dashBookReturn.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<dshBorrowerList>().Any()) return;
            panel2.Controls.Clear();

            dshInvoice dashInvoice = new dshInvoice()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(dashInvoice);
            dashInvoice.Show();
        }
    }
}
