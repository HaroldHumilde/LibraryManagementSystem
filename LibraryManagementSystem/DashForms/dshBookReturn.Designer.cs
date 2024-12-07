namespace LibraryManagementSystem
{
    partial class dshBookReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dshBookReturn));
            this.pnlReturnBook = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchBorrow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRetunBook = new System.Windows.Forms.Button();
            this.dgvBorrowedInfo = new System.Windows.Forms.DataGridView();
            this.dgvBorrower = new System.Windows.Forms.DataGridView();
            this.activeBorrowersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet46 = new LibraryManagementSystem.lmsdcsDataSet46();
            this.overdueNotification = new Tulpep.NotificationWindow.PopupNotifier();
            this.overDueCheck = new System.Windows.Forms.Timer(this.components);
            this.activeBorrowersTableAdapter = new LibraryManagementSystem.lmsdcsDataSet46TableAdapters.ActiveBorrowersTableAdapter();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Middlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfileImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.lmsdcsDataSet3 = new LibraryManagementSystem.lmsdcsDataSet3();
            this.bookBorrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookBorrowingTableAdapter = new LibraryManagementSystem.lmsdcsDataSet3TableAdapters.BookBorrowingTableAdapter();
            this.BorrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverdueNotified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlReturnBook.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlReturnBook
            // 
            this.pnlReturnBook.BackColor = System.Drawing.Color.White;
            this.pnlReturnBook.Controls.Add(this.panel2);
            this.pnlReturnBook.Controls.Add(this.btnDelete);
            this.pnlReturnBook.Controls.Add(this.btnRetunBook);
            this.pnlReturnBook.Controls.Add(this.dgvBorrowedInfo);
            this.pnlReturnBook.Controls.Add(this.dgvBorrower);
            this.pnlReturnBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReturnBook.Location = new System.Drawing.Point(0, 0);
            this.pnlReturnBook.Name = "pnlReturnBook";
            this.pnlReturnBook.Size = new System.Drawing.Size(1942, 1102);
            this.pnlReturnBook.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtSearchBorrow);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1942, 68);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(628, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 205;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearchBorrow
            // 
            this.txtSearchBorrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearchBorrow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBorrow.Location = new System.Drawing.Point(686, 22);
            this.txtSearchBorrow.Name = "txtSearchBorrow";
            this.txtSearchBorrow.Size = new System.Drawing.Size(558, 23);
            this.txtSearchBorrow.TabIndex = 0;
            this.txtSearchBorrow.TextChanged += new System.EventHandler(this.txtSearchBorrow_TextChanged);
            this.txtSearchBorrow.Enter += new System.EventHandler(this.txtSearchBorrow_Enter);
            this.txtSearchBorrow.Leave += new System.EventHandler(this.txtSearchBorrow_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Return Book";
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(1607, 611);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRetunBook
            // 
            this.btnRetunBook.ForeColor = System.Drawing.Color.Green;
            this.btnRetunBook.Location = new System.Drawing.Point(1470, 611);
            this.btnRetunBook.Name = "btnRetunBook";
            this.btnRetunBook.Size = new System.Drawing.Size(113, 44);
            this.btnRetunBook.TabIndex = 5;
            this.btnRetunBook.Text = "Return Book";
            this.btnRetunBook.UseVisualStyleBackColor = true;
            this.btnRetunBook.Click += new System.EventHandler(this.btnRetunBook_Click);
            // 
            // dgvBorrowedInfo
            // 
            this.dgvBorrowedInfo.AllowUserToAddRows = false;
            this.dgvBorrowedInfo.AllowUserToDeleteRows = false;
            this.dgvBorrowedInfo.AllowUserToResizeColumns = false;
            this.dgvBorrowedInfo.AllowUserToResizeRows = false;
            this.dgvBorrowedInfo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dgvBorrowedInfo.AutoGenerateColumns = false;
            this.dgvBorrowedInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrowedInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowedInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBorrowedInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrowedInfo.ColumnHeadersHeight = 29;
            this.dgvBorrowedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrowedInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BorrowID,
            this.BorrowerID,
            this.BookID,
            this.BorrowedDate,
            this.DueDate,
            this.BookTitle,
            this.Status,
            this.OverdueNotified});
            this.dgvBorrowedInfo.DataSource = this.bookBorrowingBindingSource;
            this.dgvBorrowedInfo.EnableHeadersVisualStyles = false;
            this.dgvBorrowedInfo.Location = new System.Drawing.Point(1084, 221);
            this.dgvBorrowedInfo.Name = "dgvBorrowedInfo";
            this.dgvBorrowedInfo.ReadOnly = true;
            this.dgvBorrowedInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrowedInfo.RowHeadersVisible = false;
            this.dgvBorrowedInfo.RowHeadersWidth = 51;
            this.dgvBorrowedInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBorrowedInfo.RowTemplate.Height = 24;
            this.dgvBorrowedInfo.Size = new System.Drawing.Size(772, 386);
            this.dgvBorrowedInfo.TabIndex = 4;
            this.dgvBorrowedInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrowedInfo_CellClick);
            // 
            // dgvBorrower
            // 
            this.dgvBorrower.AllowUserToAddRows = false;
            this.dgvBorrower.AllowUserToDeleteRows = false;
            this.dgvBorrower.AllowUserToResizeColumns = false;
            this.dgvBorrower.AllowUserToResizeRows = false;
            this.dgvBorrower.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dgvBorrower.AutoGenerateColumns = false;
            this.dgvBorrower.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrower.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBorrower.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrower.ColumnHeadersHeight = 29;
            this.dgvBorrower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrower.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.StudentNumber,
            this.Firstname,
            this.Middlename,
            this.Lastname,
            this.Age,
            this.Birthday,
            this.Gender,
            this.Address,
            this.ContactNumber,
            this.Email,
            this.Year,
            this.Section,
            this.ProfileImage});
            this.dgvBorrower.DataSource = this.activeBorrowersBindingSource;
            this.dgvBorrower.EnableHeadersVisualStyles = false;
            this.dgvBorrower.GridColor = System.Drawing.Color.White;
            this.dgvBorrower.Location = new System.Drawing.Point(204, 221);
            this.dgvBorrower.Name = "dgvBorrower";
            this.dgvBorrower.ReadOnly = true;
            this.dgvBorrower.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrower.RowHeadersVisible = false;
            this.dgvBorrower.RowHeadersWidth = 51;
            this.dgvBorrower.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBorrower.RowTemplate.Height = 24;
            this.dgvBorrower.Size = new System.Drawing.Size(880, 386);
            this.dgvBorrower.TabIndex = 3;
            // 
            // activeBorrowersBindingSource
            // 
            this.activeBorrowersBindingSource.DataMember = "ActiveBorrowers";
            this.activeBorrowersBindingSource.DataSource = this.lmsdcsDataSet46;
            // 
            // lmsdcsDataSet46
            // 
            this.lmsdcsDataSet46.DataSetName = "lmsdcsDataSet46";
            this.lmsdcsDataSet46.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // overdueNotification
            // 
            this.overdueNotification.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.overdueNotification.ContentText = null;
            this.overdueNotification.Image = null;
            this.overdueNotification.IsRightToLeft = false;
            this.overdueNotification.OptionsMenu = null;
            this.overdueNotification.Size = new System.Drawing.Size(400, 100);
            this.overdueNotification.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.overdueNotification.TitleText = null;
            // 
            // overDueCheck
            // 
            this.overDueCheck.Tick += new System.EventHandler(this.overDueCheck_Tick);
            // 
            // activeBorrowersTableAdapter
            // 
            this.activeBorrowersTableAdapter.ClearBeforeFill = true;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // StudentNumber
            // 
            this.StudentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentNumber.DataPropertyName = "StudentNumber";
            this.StudentNumber.HeaderText = "Student Number";
            this.StudentNumber.MinimumWidth = 6;
            this.StudentNumber.Name = "StudentNumber";
            this.StudentNumber.ReadOnly = true;
            // 
            // Firstname
            // 
            this.Firstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Firstname.DataPropertyName = "Firstname";
            this.Firstname.HeaderText = "Firstname";
            this.Firstname.MinimumWidth = 6;
            this.Firstname.Name = "Firstname";
            this.Firstname.ReadOnly = true;
            // 
            // Middlename
            // 
            this.Middlename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Middlename.DataPropertyName = "Middlename";
            this.Middlename.HeaderText = "Middlename";
            this.Middlename.MinimumWidth = 6;
            this.Middlename.Name = "Middlename";
            this.Middlename.ReadOnly = true;
            // 
            // Lastname
            // 
            this.Lastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lastname.DataPropertyName = "Lastname";
            this.Lastname.HeaderText = "Lastname";
            this.Lastname.MinimumWidth = 6;
            this.Lastname.Name = "Lastname";
            this.Lastname.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.MinimumWidth = 6;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Visible = false;
            this.Age.Width = 125;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "Birthday";
            this.Birthday.MinimumWidth = 6;
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            this.Birthday.Visible = false;
            this.Birthday.Width = 125;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Visible = false;
            this.Gender.Width = 125;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Visible = false;
            this.Address.Width = 125;
            // 
            // ContactNumber
            // 
            this.ContactNumber.DataPropertyName = "ContactNumber";
            this.ContactNumber.HeaderText = "ContactNumber";
            this.ContactNumber.MinimumWidth = 6;
            this.ContactNumber.Name = "ContactNumber";
            this.ContactNumber.ReadOnly = true;
            this.ContactNumber.Visible = false;
            this.ContactNumber.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            this.Email.Width = 125;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Visible = false;
            this.Year.Width = 125;
            // 
            // Section
            // 
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.MinimumWidth = 6;
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Visible = false;
            this.Section.Width = 125;
            // 
            // ProfileImage
            // 
            this.ProfileImage.DataPropertyName = "ProfileImage";
            this.ProfileImage.HeaderText = "ProfileImage";
            this.ProfileImage.MinimumWidth = 6;
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.ReadOnly = true;
            this.ProfileImage.Visible = false;
            this.ProfileImage.Width = 125;
            // 
            // lmsdcsDataSet3
            // 
            this.lmsdcsDataSet3.DataSetName = "lmsdcsDataSet3";
            this.lmsdcsDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBorrowingBindingSource
            // 
            this.bookBorrowingBindingSource.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource.DataSource = this.lmsdcsDataSet3;
            // 
            // bookBorrowingTableAdapter
            // 
            this.bookBorrowingTableAdapter.ClearBeforeFill = true;
            // 
            // BorrowID
            // 
            this.BorrowID.DataPropertyName = "BorrowID";
            this.BorrowID.HeaderText = "BorrowID";
            this.BorrowID.MinimumWidth = 6;
            this.BorrowID.Name = "BorrowID";
            this.BorrowID.ReadOnly = true;
            this.BorrowID.Width = 125;
            // 
            // BorrowerID
            // 
            this.BorrowerID.DataPropertyName = "BorrowerID";
            this.BorrowerID.HeaderText = "BorrowerID";
            this.BorrowerID.MinimumWidth = 6;
            this.BorrowerID.Name = "BorrowerID";
            this.BorrowerID.ReadOnly = true;
            this.BorrowerID.Width = 125;
            // 
            // BookID
            // 
            this.BookID.DataPropertyName = "BookID";
            this.BookID.HeaderText = "BookID";
            this.BookID.MinimumWidth = 6;
            this.BookID.Name = "BookID";
            this.BookID.ReadOnly = true;
            this.BookID.Width = 125;
            // 
            // BorrowedDate
            // 
            this.BorrowedDate.DataPropertyName = "BorrowedDate";
            this.BorrowedDate.HeaderText = "BorrowedDate";
            this.BorrowedDate.MinimumWidth = 6;
            this.BorrowedDate.Name = "BorrowedDate";
            this.BorrowedDate.ReadOnly = true;
            this.BorrowedDate.Width = 125;
            // 
            // DueDate
            // 
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.HeaderText = "DueDate";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 125;
            // 
            // BookTitle
            // 
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "BookTitle";
            this.BookTitle.MinimumWidth = 6;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            this.BookTitle.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // OverdueNotified
            // 
            this.OverdueNotified.DataPropertyName = "OverdueNotified";
            this.OverdueNotified.HeaderText = "OverdueNotified";
            this.OverdueNotified.MinimumWidth = 6;
            this.OverdueNotified.Name = "OverdueNotified";
            this.OverdueNotified.ReadOnly = true;
            this.OverdueNotified.Width = 125;
            // 
            // dshBookReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.pnlReturnBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dshBookReturn";
            this.Text = "BookReturn";
            this.Load += new System.EventHandler(this.BookReturn_Load);
            this.pnlReturnBook.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReturnBook;
        private System.Windows.Forms.TextBox txtSearchBorrow;
        private System.Windows.Forms.DataGridView dgvBorrower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBorrowedInfo;
        private System.Windows.Forms.Button btnRetunBook;
        private System.Windows.Forms.Button btnDelete;
        private Tulpep.NotificationWindow.PopupNotifier overdueNotification;
        private System.Windows.Forms.Timer overDueCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private lmsdcsDataSet46 lmsdcsDataSet46;
        private System.Windows.Forms.BindingSource activeBorrowersBindingSource;
        private lmsdcsDataSet46TableAdapters.ActiveBorrowersTableAdapter activeBorrowersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Middlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewImageColumn ProfileImage;
        private lmsdcsDataSet3 lmsdcsDataSet3;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource;
        private lmsdcsDataSet3TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OverdueNotified;
    }
}