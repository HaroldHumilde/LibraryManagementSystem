namespace LibraryManagementSystem
{
    partial class dshInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dtgInvoice = new System.Windows.Forms.DataGridView();
            this.BorrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverdueNotified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookBorrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet5 = new LibraryManagementSystem.lmsdcsDataSet5();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLibrarianName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPriceTwo = new System.Windows.Forms.TextBox();
            this.txtBookTitleTwo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookTitleOne = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPriceOne = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bookBorrowingTableAdapter = new LibraryManagementSystem.lmsdcsDataSet5TableAdapters.BookBorrowingTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet5)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtBookID);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.dtgInvoice);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtSection);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.txtGender);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.txtAge);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLibrarianName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPriceTwo);
            this.panel1.Controls.Add(this.txtBookTitleTwo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblInvoiceNo);
            this.panel1.Controls.Add(this.btnInvoice);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBookTitleOne);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPriceOne);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.txtStudentNumber);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1942, 1102);
            this.panel1.TabIndex = 0;
            // 
            // txtBookID
            // 
            this.txtBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookID.Location = new System.Drawing.Point(811, 158);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(347, 23);
            this.txtBookID.TabIndex = 55;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(245, 165);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(347, 23);
            this.txtID.TabIndex = 54;
            // 
            // dtgInvoice
            // 
            this.dtgInvoice.AllowUserToAddRows = false;
            this.dtgInvoice.AllowUserToDeleteRows = false;
            this.dtgInvoice.AllowUserToResizeColumns = false;
            this.dtgInvoice.AllowUserToResizeRows = false;
            this.dtgInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtgInvoice.AutoGenerateColumns = false;
            this.dtgInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dtgInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgInvoice.ColumnHeadersHeight = 29;
            this.dtgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BorrowID,
            this.BorrowerID,
            this.BookID,
            this.BookTitle,
            this.BorrowedDate,
            this.DueDate,
            this.Status,
            this.OverdueNotified,
            this.Price});
            this.dtgInvoice.DataSource = this.bookBorrowingBindingSource;
            this.dtgInvoice.EnableHeadersVisualStyles = false;
            this.dtgInvoice.GridColor = System.Drawing.Color.White;
            this.dtgInvoice.Location = new System.Drawing.Point(148, 666);
            this.dtgInvoice.Name = "dtgInvoice";
            this.dtgInvoice.ReadOnly = true;
            this.dtgInvoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgInvoice.RowHeadersVisible = false;
            this.dtgInvoice.RowHeadersWidth = 51;
            this.dtgInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgInvoice.RowTemplate.Height = 24;
            this.dtgInvoice.Size = new System.Drawing.Size(1399, 246);
            this.dtgInvoice.TabIndex = 51;
            this.dtgInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInvoice_CellContentClick);
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
            // BookTitle
            // 
            this.BookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "BookTitle";
            this.BookTitle.MinimumWidth = 6;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
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
            this.OverdueNotified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OverdueNotified.DataPropertyName = "OverdueNotified";
            this.OverdueNotified.HeaderText = "OverdueNotified";
            this.OverdueNotified.MinimumWidth = 6;
            this.OverdueNotified.Name = "OverdueNotified";
            this.OverdueNotified.ReadOnly = true;
            this.OverdueNotified.Visible = false;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // bookBorrowingBindingSource
            // 
            this.bookBorrowingBindingSource.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource.DataSource = this.lmsdcsDataSet5;
            // 
            // lmsdcsDataSet5
            // 
            this.lmsdcsDataSet5.DataSetName = "lmsdcsDataSet5";
            this.lmsdcsDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel13
            // 
            this.panel13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel13.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel13.Location = new System.Drawing.Point(1202, 274);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(349, 2);
            this.panel13.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1194, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 25);
            this.label12.TabIndex = 37;
            this.label12.Text = "Section";
            // 
            // txtSection
            // 
            this.txtSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(1205, 250);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(347, 23);
            this.txtSection.TabIndex = 36;
            // 
            // panel12
            // 
            this.panel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel12.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel12.Location = new System.Drawing.Point(792, 274);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(349, 2);
            this.panel12.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(784, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 25);
            this.label11.TabIndex = 34;
            this.label11.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(795, 250);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(347, 23);
            this.txtYear.TabIndex = 33;
            // 
            // panel11
            // 
            this.panel11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel11.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel11.Location = new System.Drawing.Point(248, 593);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(349, 2);
            this.panel11.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(240, 524);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 25);
            this.label10.TabIndex = 31;
            this.label10.Text = "Gender";
            // 
            // panel10
            // 
            this.panel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel10.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel10.Location = new System.Drawing.Point(248, 492);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(349, 2);
            this.panel10.TabIndex = 29;
            // 
            // txtGender
            // 
            this.txtGender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(251, 569);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(347, 23);
            this.txtGender.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(240, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "Age";
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel9.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel9.Location = new System.Drawing.Point(1202, 486);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(349, 2);
            this.panel9.TabIndex = 27;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(251, 468);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(347, 23);
            this.txtAge.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel8.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel8.Location = new System.Drawing.Point(1199, 379);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(349, 2);
            this.panel8.TabIndex = 27;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel7.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel7.Location = new System.Drawing.Point(794, 486);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(349, 2);
            this.panel7.TabIndex = 27;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Location = new System.Drawing.Point(789, 379);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(349, 2);
            this.panel6.TabIndex = 28;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel5.Location = new System.Drawing.Point(787, 593);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(349, 2);
            this.panel5.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel4.Location = new System.Drawing.Point(245, 273);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(349, 2);
            this.panel4.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(248, 380);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 2);
            this.panel3.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(787, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Librarian Name";
            // 
            // txtLibrarianName
            // 
            this.txtLibrarianName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLibrarianName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLibrarianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibrarianName.Location = new System.Drawing.Point(790, 569);
            this.txtLibrarianName.Name = "txtLibrarianName";
            this.txtLibrarianName.Size = new System.Drawing.Size(349, 23);
            this.txtLibrarianName.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1194, 417);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Price #2";
            // 
            // txtPriceTwo
            // 
            this.txtPriceTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPriceTwo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPriceTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceTwo.Location = new System.Drawing.Point(1205, 462);
            this.txtPriceTwo.Name = "txtPriceTwo";
            this.txtPriceTwo.Size = new System.Drawing.Size(347, 23);
            this.txtPriceTwo.TabIndex = 22;
            // 
            // txtBookTitleTwo
            // 
            this.txtBookTitleTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookTitleTwo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookTitleTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitleTwo.Location = new System.Drawing.Point(797, 463);
            this.txtBookTitleTwo.Name = "txtBookTitleTwo";
            this.txtBookTitleTwo.Size = new System.Drawing.Size(347, 23);
            this.txtBookTitleTwo.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(784, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Book Title #2";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(1490, 165);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(10, 16);
            this.lblInvoiceNo.TabIndex = 19;
            this.lblInvoiceNo.Text = "I";
            this.lblInvoiceNo.Visible = false;
            // 
            // btnInvoice
            // 
            this.btnInvoice.ForeColor = System.Drawing.Color.Green;
            this.btnInvoice.Location = new System.Drawing.Point(1446, 563);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(102, 32);
            this.btnInvoice.TabIndex = 17;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1194, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Price #1";
            // 
            // txtBookTitleOne
            // 
            this.txtBookTitleOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookTitleOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookTitleOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitleOne.Location = new System.Drawing.Point(792, 356);
            this.txtBookTitleOne.Name = "txtBookTitleOne";
            this.txtBookTitleOne.Size = new System.Drawing.Size(347, 23);
            this.txtBookTitleOne.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(784, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Book Title #1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(240, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Student Name";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Student Number";
            // 
            // txtPriceOne
            // 
            this.txtPriceOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPriceOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPriceOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOne.Location = new System.Drawing.Point(1200, 355);
            this.txtPriceOne.Name = "txtPriceOne";
            this.txtPriceOne.Size = new System.Drawing.Size(347, 23);
            this.txtPriceOne.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(251, 356);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(347, 23);
            this.txtFullName.TabIndex = 2;
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStudentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentNumber.Location = new System.Drawing.Point(245, 249);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(347, 23);
            this.txtStudentNumber.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1925, 68);
            this.panel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(609, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(458, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 36);
            this.label6.TabIndex = 1;
            this.label6.Text = "INVOICE";
            // 
            // bookBorrowingTableAdapter
            // 
            this.bookBorrowingTableAdapter.ClearBeforeFill = true;
            // 
            // dshInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dshInvoice";
            this.Text = "dshInvoice";
            this.Load += new System.EventHandler(this.dshInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriceOne;
        private System.Windows.Forms.TextBox txtBookTitleOne;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtBookTitleTwo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPriceTwo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLibrarianName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.DataGridView dtgInvoice;
        private lmsdcsDataSet5 lmsdcsDataSet5;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource;
        private lmsdcsDataSet5TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitles;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OverdueNotified;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}