namespace LibraryManagementSystem
{
    partial class dshBorrowerList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtgBorrowed = new System.Windows.Forms.DataGridView();
            this.BorrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverdueNotified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bookBorrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet11 = new LibraryManagementSystem.lmsdcsDataSet11();
            this.dtgBorrower = new System.Windows.Forms.DataGridView();
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
            this.activeBorrowersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet10 = new LibraryManagementSystem.lmsdcsDataSet10();
            this.activeBorrowersTableAdapter = new LibraryManagementSystem.lmsdcsDataSet10TableAdapters.ActiveBorrowersTableAdapter();
            this.bookBorrowingTableAdapter = new LibraryManagementSystem.lmsdcsDataSet11TableAdapters.BookBorrowingTableAdapter();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnDueDate = new Tulpep.NotificationWindow.PopupNotifier();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBorrowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBorrower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet10)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dtgBorrowed);
            this.panel1.Controls.Add(this.dtgBorrower);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1945, 1100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1945, 68);
            this.panel2.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(646, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(467, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dtgBorrowed
            // 
            this.dtgBorrowed.AllowUserToAddRows = false;
            this.dtgBorrowed.AllowUserToDeleteRows = false;
            this.dtgBorrowed.AllowUserToResizeColumns = false;
            this.dtgBorrowed.AllowUserToResizeRows = false;
            this.dtgBorrowed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtgBorrowed.AutoGenerateColumns = false;
            this.dtgBorrowed.BackgroundColor = System.Drawing.Color.White;
            this.dtgBorrowed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgBorrowed.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgBorrowed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgBorrowed.ColumnHeadersHeight = 30;
            this.dtgBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgBorrowed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BorrowID,
            this.BorrowerID,
            this.BookID,
            this.BookTitle,
            this.BorrowedDate,
            this.DueDate,
            this.Status,
            this.OverdueNotified});
            this.dtgBorrowed.DataSource = this.bookBorrowingBindingSource;
            this.dtgBorrowed.EnableHeadersVisualStyles = false;
            this.dtgBorrowed.Location = new System.Drawing.Point(1132, 155);
            this.dtgBorrowed.Name = "dtgBorrowed";
            this.dtgBorrowed.ReadOnly = true;
            this.dtgBorrowed.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgBorrowed.RowHeadersVisible = false;
            this.dtgBorrowed.RowHeadersWidth = 51;
            this.dtgBorrowed.Size = new System.Drawing.Size(750, 423);
            this.dtgBorrowed.TabIndex = 1;
            this.dtgBorrowed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBorrowed_CellContentClick);
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
            this.OverdueNotified.DataPropertyName = "OverdueNotified";
            this.OverdueNotified.HeaderText = "OverdueNotified";
            this.OverdueNotified.MinimumWidth = 6;
            this.OverdueNotified.Name = "OverdueNotified";
            this.OverdueNotified.ReadOnly = true;
            this.OverdueNotified.Visible = false;
            this.OverdueNotified.Width = 125;
            // 
            // bookBorrowingBindingSource
            // 
            this.bookBorrowingBindingSource.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource.DataSource = this.lmsdcsDataSet11;
            // 
            // lmsdcsDataSet11
            // 
            this.lmsdcsDataSet11.DataSetName = "lmsdcsDataSet11";
            this.lmsdcsDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtgBorrower
            // 
            this.dtgBorrower.AllowUserToAddRows = false;
            this.dtgBorrower.AllowUserToDeleteRows = false;
            this.dtgBorrower.AllowUserToResizeColumns = false;
            this.dtgBorrower.AllowUserToResizeRows = false;
            this.dtgBorrower.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtgBorrower.AutoGenerateColumns = false;
            this.dtgBorrower.BackgroundColor = System.Drawing.Color.White;
            this.dtgBorrower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgBorrower.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgBorrower.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgBorrower.ColumnHeadersHeight = 30;
            this.dtgBorrower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgBorrower.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dtgBorrower.DataSource = this.activeBorrowersBindingSource;
            this.dtgBorrower.EnableHeadersVisualStyles = false;
            this.dtgBorrower.GridColor = System.Drawing.Color.White;
            this.dtgBorrower.Location = new System.Drawing.Point(15, 155);
            this.dtgBorrower.Name = "dtgBorrower";
            this.dtgBorrower.ReadOnly = true;
            this.dtgBorrower.RowHeadersVisible = false;
            this.dtgBorrower.RowHeadersWidth = 51;
            this.dtgBorrower.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBorrower.RowTemplate.Height = 24;
            this.dtgBorrower.Size = new System.Drawing.Size(1121, 693);
            this.dtgBorrower.TabIndex = 0;
            this.dtgBorrower.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBorrower_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // StudentNumber
            // 
            this.StudentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentNumber.DataPropertyName = "StudentNumber";
            this.StudentNumber.HeaderText = "StudentNumber";
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
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.MinimumWidth = 6;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Visible = false;
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
            this.Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
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
            this.ContactNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContactNumber.DataPropertyName = "ContactNumber";
            this.ContactNumber.HeaderText = "ContactNumber";
            this.ContactNumber.MinimumWidth = 6;
            this.ContactNumber.Name = "ContactNumber";
            this.ContactNumber.ReadOnly = true;
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
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // Section
            // 
            this.Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.MinimumWidth = 6;
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
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
            // activeBorrowersBindingSource
            // 
            this.activeBorrowersBindingSource.DataMember = "ActiveBorrowers";
            this.activeBorrowersBindingSource.DataSource = this.lmsdcsDataSet10;
            // 
            // lmsdcsDataSet10
            // 
            this.lmsdcsDataSet10.DataSetName = "lmsdcsDataSet10";
            this.lmsdcsDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // activeBorrowersTableAdapter
            // 
            this.activeBorrowersTableAdapter.ClearBeforeFill = true;
            // 
            // bookBorrowingTableAdapter
            // 
            this.bookBorrowingTableAdapter.ClearBeforeFill = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(1396, 641);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(87, 43);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pnDueDate
            // 
            this.pnDueDate.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.pnDueDate.ContentText = null;
            this.pnDueDate.Image = null;
            this.pnDueDate.IsRightToLeft = false;
            this.pnDueDate.OptionsMenu = null;
            this.pnDueDate.Size = new System.Drawing.Size(400, 100);
            this.pnDueDate.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.pnDueDate.TitleText = null;
            // 
            // dshBorrowerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dshBorrowerList";
            this.Text = "BorrowerList";
            this.Load += new System.EventHandler(this.BorrowerList_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBorrowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBorrower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgBorrowed;
        private System.Windows.Forms.DataGridView dtgBorrower;
        private System.Windows.Forms.TextBox txtSearch;
        private lmsdcsDataSet10 lmsdcsDataSet10;
        private System.Windows.Forms.BindingSource activeBorrowersBindingSource;
        private lmsdcsDataSet10TableAdapters.ActiveBorrowersTableAdapter activeBorrowersTableAdapter;
        private lmsdcsDataSet11 lmsdcsDataSet11;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource;
        private lmsdcsDataSet11TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OverdueNotified;
        private System.Windows.Forms.Button btnReturn;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
    }
}