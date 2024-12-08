namespace LibraryManagementSystem
{
    partial class dshBorrower
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dshBorrower));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.PanelBookBorrowing = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlAddBook = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookSearch = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBookShelves = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowSearchButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.activeBorrowersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet30 = new LibraryManagementSystem.lmsdcsDataSet30();
            this.activeBorrowersTableAdapter = new LibraryManagementSystem.lmsdcsDataSet30TableAdapters.ActiveBorrowersTableAdapter();
            this.lmsdcsDataSet32 = new LibraryManagementSystem.lmsdcsDataSet32();
            this.bookBorrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookBorrowingTableAdapter = new LibraryManagementSystem.lmsdcsDataSet32TableAdapters.BookBorrowingTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lmsdcsDataSet1 = new LibraryManagementSystem.lmsdcsDataSet1();
            this.bookBorrowingBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bookBorrowingTableAdapter1 = new LibraryManagementSystem.lmsdcsDataSet1TableAdapters.BookBorrowingTableAdapter();
            this.BorrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverdueNotified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PictureBook = new System.Windows.Forms.PictureBox();
            this.pictureProfile = new System.Windows.Forms.PictureBox();
            this.dtgBooks = new System.Windows.Forms.DataGridView();
            this.lmsdcsDataSet2 = new LibraryManagementSystem.lmsdcsDataSet2();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTableAdapter = new LibraryManagementSystem.lmsdcsDataSet2TableAdapters.InventoryTableAdapter();
            this.BooksID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BooksTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookShelves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageFile = new System.Windows.Forms.DataGridViewImageColumn();
            this.Statuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelBookBorrowing.SuspendLayout();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlAddBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Borrowing";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(424, 22);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(734, 36);
            this.txtSearch.TabIndex = 53;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // PanelBookBorrowing
            // 
            this.PanelBookBorrowing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBookBorrowing.BackColor = System.Drawing.Color.White;
            this.PanelBookBorrowing.Controls.Add(this.pnlAddBook);
            this.PanelBookBorrowing.Controls.Add(this.pictureProfile);
            this.PanelBookBorrowing.Controls.Add(this.dataGridView1);
            this.PanelBookBorrowing.Controls.Add(this.panel20);
            this.PanelBookBorrowing.Controls.Add(this.panel12);
            this.PanelBookBorrowing.Controls.Add(this.panel1);
            this.PanelBookBorrowing.Controls.Add(this.btnShowSearchButton);
            this.PanelBookBorrowing.Controls.Add(this.panel7);
            this.PanelBookBorrowing.Controls.Add(this.panel6);
            this.PanelBookBorrowing.Controls.Add(this.label4);
            this.PanelBookBorrowing.Controls.Add(this.panel2);
            this.PanelBookBorrowing.Controls.Add(this.txtFirstName);
            this.PanelBookBorrowing.Controls.Add(this.panel11);
            this.PanelBookBorrowing.Controls.Add(this.lblGender);
            this.PanelBookBorrowing.Controls.Add(this.txtStudentNumber);
            this.PanelBookBorrowing.Controls.Add(this.txtYear);
            this.PanelBookBorrowing.Controls.Add(this.txtMiddleName);
            this.PanelBookBorrowing.Controls.Add(this.label13);
            this.PanelBookBorrowing.Controls.Add(this.txtSection);
            this.PanelBookBorrowing.Controls.Add(this.label9);
            this.PanelBookBorrowing.Controls.Add(this.label12);
            this.PanelBookBorrowing.Controls.Add(this.panel10);
            this.PanelBookBorrowing.Controls.Add(this.txtLastName);
            this.PanelBookBorrowing.Controls.Add(this.label8);
            this.PanelBookBorrowing.Controls.Add(this.label10);
            this.PanelBookBorrowing.Controls.Add(this.txtGender);
            this.PanelBookBorrowing.Controls.Add(this.txtID);
            this.PanelBookBorrowing.Controls.Add(this.panel8);
            this.PanelBookBorrowing.Controls.Add(this.label23);
            this.PanelBookBorrowing.Controls.Add(this.panel4);
            this.PanelBookBorrowing.Controls.Add(this.panel3);
            this.PanelBookBorrowing.Location = new System.Drawing.Point(0, 0);
            this.PanelBookBorrowing.Name = "PanelBookBorrowing";
            this.PanelBookBorrowing.Size = new System.Drawing.Size(1925, 1111);
            this.PanelBookBorrowing.TabIndex = 0;
            this.PanelBookBorrowing.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel20.Controls.Add(this.pictureBox2);
            this.panel20.Controls.Add(this.txtSearch);
            this.panel20.Controls.Add(this.label1);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1925, 68);
            this.panel20.TabIndex = 229;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(380, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 230;
            this.pictureBox2.TabStop = false;
            // 
            // pnlAddBook
            // 
            this.pnlAddBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAddBook.BackColor = System.Drawing.Color.White;
            this.pnlAddBook.Controls.Add(this.dtgBooks);
            this.pnlAddBook.Controls.Add(this.PictureBook);
            this.pnlAddBook.Controls.Add(this.pictureBox1);
            this.pnlAddBook.Controls.Add(this.btnBack);
            this.pnlAddBook.Controls.Add(this.label3);
            this.pnlAddBook.Controls.Add(this.txtBookSearch);
            this.pnlAddBook.Controls.Add(this.txtBookTitle);
            this.pnlAddBook.Controls.Add(this.btnBorrowBook);
            this.pnlAddBook.Controls.Add(this.txtISBN);
            this.pnlAddBook.Controls.Add(this.label11);
            this.pnlAddBook.Controls.Add(this.txtSerialNumber);
            this.pnlAddBook.Controls.Add(this.label6);
            this.pnlAddBook.Controls.Add(this.label2);
            this.pnlAddBook.Controls.Add(this.dtpDueDate);
            this.pnlAddBook.Controls.Add(this.label22);
            this.pnlAddBook.Controls.Add(this.label14);
            this.pnlAddBook.Controls.Add(this.txtCategory);
            this.pnlAddBook.Controls.Add(this.txtQuantity);
            this.pnlAddBook.Controls.Add(this.label5);
            this.pnlAddBook.Controls.Add(this.txtBookShelves);
            this.pnlAddBook.Controls.Add(this.txtAuthor);
            this.pnlAddBook.Controls.Add(this.label7);
            this.pnlAddBook.Controls.Add(this.panel15);
            this.pnlAddBook.Controls.Add(this.panel14);
            this.pnlAddBook.Controls.Add(this.panel13);
            this.pnlAddBook.Controls.Add(this.panel16);
            this.pnlAddBook.Controls.Add(this.panel17);
            this.pnlAddBook.Controls.Add(this.panel18);
            this.pnlAddBook.Controls.Add(this.panel19);
            this.pnlAddBook.Location = new System.Drawing.Point(12, 74);
            this.pnlAddBook.Name = "pnlAddBook";
            this.pnlAddBook.Size = new System.Drawing.Size(1910, 983);
            this.pnlAddBook.TabIndex = 228;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 231;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(-18, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 37);
            this.btnBack.TabIndex = 228;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 82;
            this.label3.Text = "Book Title:";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.Location = new System.Drawing.Point(3, 308);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(516, 20);
            this.txtBookTitle.TabIndex = 86;
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrowBook.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrowBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBorrowBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowBook.ForeColor = System.Drawing.Color.Green;
            this.btnBorrowBook.Location = new System.Drawing.Point(1192, 555);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(101, 43);
            this.btnBorrowBook.TabIndex = 103;
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = false;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // txtISBN
            // 
            this.txtISBN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtISBN.BackColor = System.Drawing.Color.White;
            this.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBN.Location = new System.Drawing.Point(779, 209);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(515, 20);
            this.txtISBN.TabIndex = 100;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(774, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 98;
            this.label11.Text = "ISBN:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNumber.Location = new System.Drawing.Point(5, 211);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(516, 20);
            this.txtSerialNumber.TabIndex = 221;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(774, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 25);
            this.label6.TabIndex = 85;
            this.label6.Text = "BookShelves:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 83;
            this.label2.Text = "Category:";
            // 
            // txtBookSearch
            // 
            this.txtBookSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookSearch.BackColor = System.Drawing.Color.White;
            this.txtBookSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookSearch.ForeColor = System.Drawing.Color.Black;
            this.txtBookSearch.Location = new System.Drawing.Point(316, 8);
            this.txtBookSearch.Multiline = true;
            this.txtBookSearch.Name = "txtBookSearch";
            this.txtBookSearch.Size = new System.Drawing.Size(729, 36);
            this.txtBookSearch.TabIndex = 107;
            this.txtBookSearch.TextChanged += new System.EventHandler(this.txtSearchBook_TextChanged);
            this.txtBookSearch.Enter += new System.EventHandler(this.txtBookSearch_Enter);
            this.txtBookSearch.Leave += new System.EventHandler(this.txtBookSearch_Leave);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDueDate.Location = new System.Drawing.Point(3, 482);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(516, 22);
            this.dtpDueDate.TabIndex = 103;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(0, 174);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 25);
            this.label22.TabIndex = 220;
            this.label22.Text = "Serial Number";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(-2, 446);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 25);
            this.label14.TabIndex = 104;
            this.label14.Text = "Due date:";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(3, 401);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(516, 20);
            this.txtCategory.TabIndex = 105;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(778, 473);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(515, 20);
            this.txtQuantity.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(773, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 99;
            this.label5.Text = "Author:";
            // 
            // txtBookShelves
            // 
            this.txtBookShelves.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookShelves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookShelves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookShelves.Location = new System.Drawing.Point(779, 300);
            this.txtBookShelves.Name = "txtBookShelves";
            this.txtBookShelves.Size = new System.Drawing.Size(515, 20);
            this.txtBookShelves.TabIndex = 106;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(778, 394);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(515, 20);
            this.txtAuthor.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(773, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 89;
            this.label7.Text = "Quantity:";
            // 
            // panel15
            // 
            this.panel15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel15.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel15.Location = new System.Drawing.Point(3, 423);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(516, 2);
            this.panel15.TabIndex = 215;
            // 
            // panel14
            // 
            this.panel14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel14.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel14.Location = new System.Drawing.Point(2, 329);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(516, 2);
            this.panel14.TabIndex = 215;
            // 
            // panel13
            // 
            this.panel13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel13.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel13.Location = new System.Drawing.Point(4, 231);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(516, 2);
            this.panel13.TabIndex = 226;
            // 
            // panel16
            // 
            this.panel16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel16.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel16.Location = new System.Drawing.Point(779, 231);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(515, 2);
            this.panel16.TabIndex = 227;
            // 
            // panel17
            // 
            this.panel17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel17.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel17.Location = new System.Drawing.Point(778, 322);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(515, 2);
            this.panel17.TabIndex = 215;
            // 
            // panel18
            // 
            this.panel18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel18.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel18.Location = new System.Drawing.Point(779, 416);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(515, 2);
            this.panel18.TabIndex = 215;
            // 
            // panel19
            // 
            this.panel19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel19.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel19.Location = new System.Drawing.Point(779, 495);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(515, 2);
            this.panel19.TabIndex = 215;
            // 
            // panel12
            // 
            this.panel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel12.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel12.Location = new System.Drawing.Point(25, 304);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(517, 2);
            this.panel12.TabIndex = 225;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(814, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 2);
            this.panel1.TabIndex = 215;
            // 
            // btnShowSearchButton
            // 
            this.btnShowSearchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowSearchButton.ForeColor = System.Drawing.Color.Green;
            this.btnShowSearchButton.Location = new System.Drawing.Point(1227, 519);
            this.btnShowSearchButton.Name = "btnShowSearchButton";
            this.btnShowSearchButton.Size = new System.Drawing.Size(101, 44);
            this.btnShowSearchButton.TabIndex = 223;
            this.btnShowSearchButton.Text = "Add Book";
            this.btnShowSearchButton.UseVisualStyleBackColor = true;
            this.btnShowSearchButton.Click += new System.EventHandler(this.btnShowSearchButton_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel7.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(25, 401);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(517, 2);
            this.panel7.TabIndex = 214;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(25, 485);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(517, 2);
            this.panel6.TabIndex = 214;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(809, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 105;
            this.label4.Text = "Firstname:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(813, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 2);
            this.panel2.TabIndex = 214;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(814, 186);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(515, 20);
            this.txtFirstName.TabIndex = 106;
            // 
            // panel11
            // 
            this.panel11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel11.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(812, 485);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(515, 2);
            this.panel11.TabIndex = 213;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(808, 428);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(83, 25);
            this.lblGender.TabIndex = 200;
            this.lblGender.Text = "Gender";
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStudentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentNumber.Location = new System.Drawing.Point(26, 281);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(517, 20);
            this.txtStudentNumber.TabIndex = 104;
            // 
            // txtYear
            // 
            this.txtYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(25, 463);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(517, 20);
            this.txtYear.TabIndex = 112;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(814, 282);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(515, 20);
            this.txtMiddleName.TabIndex = 103;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 25);
            this.label13.TabIndex = 111;
            this.label13.Text = "Year:";
            // 
            // txtSection
            // 
            this.txtSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(25, 379);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(517, 20);
            this.txtSection.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(809, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 25);
            this.label9.TabIndex = 93;
            this.label9.Text = "Middlename:";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 25);
            this.label12.TabIndex = 109;
            this.label12.Text = "Section:";
            // 
            // panel10
            // 
            this.panel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel10.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(26, 208);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(517, 2);
            this.panel10.TabIndex = 214;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(813, 379);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(515, 20);
            this.txtLastName.TabIndex = 108;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 91;
            this.label8.Text = "StudentNo:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(808, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 25);
            this.label10.TabIndex = 107;
            this.label10.Text = "Lastname:";
            // 
            // txtGender
            // 
            this.txtGender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(812, 463);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(515, 20);
            this.txtGender.TabIndex = 215;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(26, 186);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(517, 20);
            this.txtID.TabIndex = 220;
            // 
            // panel8
            // 
            this.panel8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel8.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(26, 304);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(517, 2);
            this.panel8.TabIndex = 214;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(21, 147);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 25);
            this.label23.TabIndex = 219;
            this.label23.Text = "ID";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(814, 304);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 2);
            this.panel4.TabIndex = 221;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(813, 208);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 2);
            this.panel3.TabIndex = 216;
            // 
            // activeBorrowersBindingSource
            // 
            this.activeBorrowersBindingSource.DataMember = "ActiveBorrowers";
            this.activeBorrowersBindingSource.DataSource = this.lmsdcsDataSet30;
            // 
            // lmsdcsDataSet30
            // 
            this.lmsdcsDataSet30.DataSetName = "lmsdcsDataSet30";
            this.lmsdcsDataSet30.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // activeBorrowersTableAdapter
            // 
            this.activeBorrowersTableAdapter.ClearBeforeFill = true;
            // 
            // lmsdcsDataSet32
            // 
            this.lmsdcsDataSet32.DataSetName = "lmsdcsDataSet32";
            this.lmsdcsDataSet32.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBorrowingBindingSource
            // 
            this.bookBorrowingBindingSource.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource.DataSource = this.lmsdcsDataSet32;
            // 
            // bookBorrowingTableAdapter
            // 
            this.bookBorrowingTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BorrowID,
            this.BorrowerID,
            this.BookID,
            this.BorrowedDate,
            this.DueDate,
            this.BookTitle,
            this.Status,
            this.OverdueNotified});
            this.dataGridView1.DataSource = this.bookBorrowingBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(145, 630);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1256, 324);
            this.dataGridView1.TabIndex = 230;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lmsdcsDataSet1
            // 
            this.lmsdcsDataSet1.DataSetName = "lmsdcsDataSet1";
            this.lmsdcsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBorrowingBindingSource1
            // 
            this.bookBorrowingBindingSource1.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource1.DataSource = this.lmsdcsDataSet1;
            // 
            // bookBorrowingTableAdapter1
            // 
            this.bookBorrowingTableAdapter1.ClearBeforeFill = true;
            // 
            // BorrowID
            // 
            this.BorrowID.DataPropertyName = "BorrowID";
            this.BorrowID.HeaderText = "BorrowID";
            this.BorrowID.MinimumWidth = 6;
            this.BorrowID.Name = "BorrowID";
            this.BorrowID.ReadOnly = true;
            this.BorrowID.Visible = false;
            this.BorrowID.Width = 125;
            // 
            // BorrowerID
            // 
            this.BorrowerID.DataPropertyName = "BorrowerID";
            this.BorrowerID.HeaderText = "BorrowerID";
            this.BorrowerID.MinimumWidth = 6;
            this.BorrowerID.Name = "BorrowerID";
            this.BorrowerID.ReadOnly = true;
            this.BorrowerID.Visible = false;
            this.BorrowerID.Width = 125;
            // 
            // BookID
            // 
            this.BookID.DataPropertyName = "BookID";
            this.BookID.HeaderText = "BookID";
            this.BookID.MinimumWidth = 6;
            this.BookID.Name = "BookID";
            this.BookID.ReadOnly = true;
            this.BookID.Visible = false;
            this.BookID.Width = 125;
            // 
            // BorrowedDate
            // 
            this.BorrowedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BorrowedDate.DataPropertyName = "BorrowedDate";
            this.BorrowedDate.HeaderText = "BorrowedDate";
            this.BorrowedDate.MinimumWidth = 6;
            this.BorrowedDate.Name = "BorrowedDate";
            this.BorrowedDate.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.HeaderText = "DueDate";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // BookTitle
            // 
            this.BookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "BookTitle";
            this.BookTitle.MinimumWidth = 6;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // OverdueNotified
            // 
            this.OverdueNotified.DataPropertyName = "OverdueNotified";
            this.OverdueNotified.HeaderText = "OverdueNotified";
            this.OverdueNotified.MinimumWidth = 6;
            this.OverdueNotified.Name = "OverdueNotified";
            this.OverdueNotified.ReadOnly = true;
            this.OverdueNotified.Visible = false;
            this.OverdueNotified.Width = 125;
            // 
            // PictureBook
            // 
            this.PictureBook.BackColor = System.Drawing.Color.White;
            this.PictureBook.Location = new System.Drawing.Point(1388, 215);
            this.PictureBook.Name = "PictureBook";
            this.PictureBook.Size = new System.Drawing.Size(192, 192);
            this.PictureBook.TabIndex = 232;
            this.PictureBook.TabStop = false;
            this.PictureBook.Click += new System.EventHandler(this.PictureBook_Click);
            // 
            // pictureProfile
            // 
            this.pictureProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureProfile.Location = new System.Drawing.Point(1371, 225);
            this.pictureProfile.Name = "pictureProfile";
            this.pictureProfile.Size = new System.Drawing.Size(170, 159);
            this.pictureProfile.TabIndex = 231;
            this.pictureProfile.TabStop = false;
            // 
            // dtgBooks
            // 
            this.dtgBooks.AllowUserToAddRows = false;
            this.dtgBooks.AllowUserToDeleteRows = false;
            this.dtgBooks.AutoGenerateColumns = false;
            this.dtgBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BooksID,
            this.ISBN,
            this.BooksTitle,
            this.Author,
            this.Category,
            this.PublishedDate,
            this.BookShelves,
            this.Quantity,
            this.Price,
            this.Location,
            this.Publisher,
            this.ImageFile,
            this.Statuses});
            this.dtgBooks.DataSource = this.inventoryBindingSource;
            this.dtgBooks.Location = new System.Drawing.Point(-13, 645);
            this.dtgBooks.Name = "dtgBooks";
            this.dtgBooks.ReadOnly = true;
            this.dtgBooks.RowHeadersWidth = 51;
            this.dtgBooks.RowTemplate.Height = 24;
            this.dtgBooks.Size = new System.Drawing.Size(1390, 157);
            this.dtgBooks.TabIndex = 233;
            this.dtgBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBooks_CellContentClick);
            // 
            // lmsdcsDataSet2
            // 
            this.lmsdcsDataSet2.DataSetName = "lmsdcsDataSet2";
            this.lmsdcsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.lmsdcsDataSet2;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // BooksID
            // 
            this.BooksID.DataPropertyName = "BookID";
            this.BooksID.HeaderText = "BookID";
            this.BooksID.MinimumWidth = 6;
            this.BooksID.Name = "BooksID";
            this.BooksID.ReadOnly = true;
            this.BooksID.Width = 125;
            // 
            // ISBN
            // 
            this.ISBN.DataPropertyName = "ISBN";
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 6;
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            this.ISBN.Width = 125;
            // 
            // BooksTitle
            // 
            this.BooksTitle.DataPropertyName = "BookTitle";
            this.BooksTitle.HeaderText = "BookTitle";
            this.BooksTitle.MinimumWidth = 6;
            this.BooksTitle.Name = "BooksTitle";
            this.BooksTitle.ReadOnly = true;
            this.BooksTitle.Width = 125;
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            this.Author.Width = 125;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // PublishedDate
            // 
            this.PublishedDate.DataPropertyName = "PublishedDate";
            this.PublishedDate.HeaderText = "PublishedDate";
            this.PublishedDate.MinimumWidth = 6;
            this.PublishedDate.Name = "PublishedDate";
            this.PublishedDate.ReadOnly = true;
            this.PublishedDate.Width = 125;
            // 
            // BookShelves
            // 
            this.BookShelves.DataPropertyName = "BookShelves";
            this.BookShelves.HeaderText = "BookShelves";
            this.BookShelves.MinimumWidth = 6;
            this.BookShelves.Name = "BookShelves";
            this.BookShelves.ReadOnly = true;
            this.BookShelves.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 125;
            // 
            // Publisher
            // 
            this.Publisher.DataPropertyName = "Publisher";
            this.Publisher.HeaderText = "Publisher";
            this.Publisher.MinimumWidth = 6;
            this.Publisher.Name = "Publisher";
            this.Publisher.ReadOnly = true;
            this.Publisher.Width = 125;
            // 
            // ImageFile
            // 
            this.ImageFile.DataPropertyName = "ImageFile";
            this.ImageFile.HeaderText = "ImageFile";
            this.ImageFile.MinimumWidth = 6;
            this.ImageFile.Name = "ImageFile";
            this.ImageFile.ReadOnly = true;
            this.ImageFile.Width = 125;
            // 
            // Statuses
            // 
            this.Statuses.DataPropertyName = "Status";
            this.Statuses.HeaderText = "Status";
            this.Statuses.MinimumWidth = 6;
            this.Statuses.Name = "Statuses";
            this.Statuses.ReadOnly = true;
            this.Statuses.Width = 125;
            // 
            // dshBorrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.PanelBookBorrowing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dshBorrower";
            this.Text = "dshBorrower";
            this.Load += new System.EventHandler(this.dshBorrower_Load);
            this.Shown += new System.EventHandler(this.dshBorrower_Shown);
            this.PanelBookBorrowing.ResumeLayout(false);
            this.PanelBookBorrowing.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlAddBook.ResumeLayout(false);
            this.pnlAddBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel PanelBookBorrowing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.TextBox txtBookShelves;
        private System.Windows.Forms.TextBox txtCategory;
        private lmsdcsDataSet30 lmsdcsDataSet30;
        private System.Windows.Forms.BindingSource activeBorrowersBindingSource;
        private lmsdcsDataSet30TableAdapters.ActiveBorrowersTableAdapter activeBorrowersTableAdapter;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtBookSearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtID;
        private lmsdcsDataSet32 lmsdcsDataSet32;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource;
        private lmsdcsDataSet32TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnShowSearchButton;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAddBook;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private lmsdcsDataSet1 lmsdcsDataSet1;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource1;
        private lmsdcsDataSet1TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OverdueNotified;
        private System.Windows.Forms.PictureBox pictureProfile;
        private System.Windows.Forms.PictureBox PictureBook;
        private System.Windows.Forms.DataGridView dtgBooks;
        private lmsdcsDataSet2 lmsdcsDataSet2;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private lmsdcsDataSet2TableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BooksID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BooksTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookShelves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewImageColumn ImageFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statuses;
    }
}