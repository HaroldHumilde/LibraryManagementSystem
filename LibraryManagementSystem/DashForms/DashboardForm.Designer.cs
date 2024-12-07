namespace LibraryManagementSystem
{
    partial class DashBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowButtons = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Label();
            this.DashBoard1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.MenuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.panelShowButtons = new System.Windows.Forms.Panel();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.btnReturnBooks = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnBorrowerList = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelShowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.Home);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1942, 91);
            this.panel3.TabIndex = 39;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Navy;
            this.btnLogout.Location = new System.Drawing.Point(1874, 24);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 50);
            this.btnLogout.TabIndex = 40;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnShowButtons);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 97);
            this.panel1.TabIndex = 39;
            // 
            // btnShowButtons
            // 
            this.btnShowButtons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnShowButtons.BackColor = System.Drawing.Color.Navy;
            this.btnShowButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowButtons.BackgroundImage")));
            this.btnShowButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowButtons.FlatAppearance.BorderSize = 0;
            this.btnShowButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowButtons.ForeColor = System.Drawing.Color.Green;
            this.btnShowButtons.Location = new System.Drawing.Point(12, 26);
            this.btnShowButtons.Name = "btnShowButtons";
            this.btnShowButtons.Size = new System.Drawing.Size(74, 44);
            this.btnShowButtons.TabIndex = 41;
            this.btnShowButtons.UseVisualStyleBackColor = false;
            this.btnShowButtons.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Home
            // 
            this.Home.AutoSize = true;
            this.Home.BackColor = System.Drawing.Color.Transparent;
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.White;
            this.Home.Location = new System.Drawing.Point(111, 32);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(153, 32);
            this.Home.TabIndex = 6;
            this.Home.Text = "Dashboard";
            // 
            // DashBoard1
            // 
            this.DashBoard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DashBoard1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DashBoard1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashBoard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoard1.ForeColor = System.Drawing.Color.White;
            this.DashBoard1.Location = new System.Drawing.Point(3, 67);
            this.DashBoard1.Name = "DashBoard1";
            this.DashBoard1.Size = new System.Drawing.Size(264, 66);
            this.DashBoard1.TabIndex = 13;
            this.DashBoard1.Text = "Dashboard";
            this.DashBoard1.UseVisualStyleBackColor = false;
            this.DashBoard1.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(264, 66);
            this.button2.TabIndex = 14;
            this.button2.Text = "Add Books";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(264, 66);
            this.button4.TabIndex = 15;
            this.button4.Text = "Issue Books";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // MenuTransition
            // 
            this.MenuTransition.Interval = 10;
            this.MenuTransition.Tick += new System.EventHandler(this.MenuTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // panelShowButtons
            // 
            this.panelShowButtons.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelShowButtons.Controls.Add(this.btnDashBoard);
            this.panelShowButtons.Controls.Add(this.btnReturnBooks);
            this.panelShowButtons.Controls.Add(this.btnInvoice);
            this.panelShowButtons.Controls.Add(this.btnBorrowerList);
            this.panelShowButtons.Controls.Add(this.button12);
            this.panelShowButtons.Controls.Add(this.button1);
            this.panelShowButtons.Controls.Add(this.button6);
            this.panelShowButtons.Controls.Add(this.button10);
            this.panelShowButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelShowButtons.Location = new System.Drawing.Point(0, 91);
            this.panelShowButtons.Name = "panelShowButtons";
            this.panelShowButtons.Size = new System.Drawing.Size(264, 1011);
            this.panelShowButtons.TabIndex = 41;
            this.panelShowButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShowButtons_Paint);
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDashBoard.FlatAppearance.BorderSize = 0;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.White;
            this.btnDashBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashBoard.Image")));
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(-1, 16);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(265, 50);
            this.btnDashBoard.TabIndex = 0;
            this.btnDashBoard.Text = "           DASHBOARD";
            this.btnDashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.UseVisualStyleBackColor = false;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // btnReturnBooks
            // 
            this.btnReturnBooks.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReturnBooks.FlatAppearance.BorderSize = 0;
            this.btnReturnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBooks.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnBooks.ForeColor = System.Drawing.Color.White;
            this.btnReturnBooks.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnBooks.Image")));
            this.btnReturnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnBooks.Location = new System.Drawing.Point(0, 381);
            this.btnReturnBooks.Name = "btnReturnBooks";
            this.btnReturnBooks.Size = new System.Drawing.Size(263, 50);
            this.btnReturnBooks.TabIndex = 0;
            this.btnReturnBooks.Text = "           RETURN BOOK";
            this.btnReturnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnBooks.UseVisualStyleBackColor = false;
            this.btnReturnBooks.Click += new System.EventHandler(this.btnReturnBooks_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInvoice.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnInvoice.FlatAppearance.BorderSize = 0;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnInvoice.Image")));
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(-1, 441);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(265, 50);
            this.btnInvoice.TabIndex = 16;
            this.btnInvoice.Text = "           INVOICE";
            this.btnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnBorrowerList
            // 
            this.btnBorrowerList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBorrowerList.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnBorrowerList.FlatAppearance.BorderSize = 0;
            this.btnBorrowerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowerList.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowerList.ForeColor = System.Drawing.Color.White;
            this.btnBorrowerList.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrowerList.Image")));
            this.btnBorrowerList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowerList.Location = new System.Drawing.Point(0, 320);
            this.btnBorrowerList.Name = "btnBorrowerList";
            this.btnBorrowerList.Size = new System.Drawing.Size(267, 50);
            this.btnBorrowerList.TabIndex = 14;
            this.btnBorrowerList.Text = "           BORROWER LIST";
            this.btnBorrowerList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowerList.UseVisualStyleBackColor = false;
            this.btnBorrowerList.Click += new System.EventHandler(this.btnBorrowerList_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.Highlight;
            this.button12.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.Location = new System.Drawing.Point(-1, 192);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(265, 47);
            this.button12.TabIndex = 5;
            this.button12.Text = "           INVENTORY";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-1, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 50);
            this.button1.TabIndex = 10;
            this.button1.Text = "           BORROWER";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnBorrower);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Highlight;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 69);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(267, 50);
            this.button6.TabIndex = 0;
            this.button6.Text = "           REGISTER";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnRegisterDash_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Highlight;
            this.button10.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(0, 128);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(264, 50);
            this.button10.TabIndex = 1;
            this.button10.Text = "           ACTIVE BORROWERS";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.btnViewProfileDash_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(264, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1678, 1011);
            this.panel2.TabIndex = 42;
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelShowButtons);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashBoardForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelShowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Home;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowButtons;
        private System.Windows.Forms.Button DashBoard1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer MenuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panelShowButtons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBorrowerList;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnReturnBooks;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDashBoard;
    }
}