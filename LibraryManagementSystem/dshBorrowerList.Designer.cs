﻿namespace LibraryManagementSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dshBorrowerList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBorrowedInfo = new System.Windows.Forms.DataGridView();
            this.BorrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookBorrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet36 = new LibraryManagementSystem.lmsdcsDataSet36();
            this.dgvBorrower = new System.Windows.Forms.DataGridView();
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
            this.activeBorrowersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet33 = new LibraryManagementSystem.lmsdcsDataSet33();
            this.txtSearchBorrow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.activeBorrowersTableAdapter = new LibraryManagementSystem.lmsdcsDataSet33TableAdapters.ActiveBorrowersTableAdapter();
            this.bookBorrowingTableAdapter = new LibraryManagementSystem.lmsdcsDataSet36TableAdapters.BookBorrowingTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet33)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvBorrowedInfo);
            this.panel1.Controls.Add(this.dgvBorrower);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 1055);
            this.panel1.TabIndex = 0;
            // 
            // dgvBorrowedInfo
            // 
            this.dgvBorrowedInfo.AllowUserToAddRows = false;
            this.dgvBorrowedInfo.AllowUserToDeleteRows = false;
            this.dgvBorrowedInfo.AllowUserToResizeColumns = false;
            this.dgvBorrowedInfo.AllowUserToResizeRows = false;
            this.dgvBorrowedInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.serialNumberDataGridViewTextBoxColumn,
            this.BookTitle,
            this.BorrowedDate,
            this.DueDate,
            this.Status});
            this.dgvBorrowedInfo.DataSource = this.bookBorrowingBindingSource;
            this.dgvBorrowedInfo.EnableHeadersVisualStyles = false;
            this.dgvBorrowedInfo.Location = new System.Drawing.Point(953, 189);
            this.dgvBorrowedInfo.Name = "dgvBorrowedInfo";
            this.dgvBorrowedInfo.ReadOnly = true;
            this.dgvBorrowedInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrowedInfo.RowHeadersVisible = false;
            this.dgvBorrowedInfo.RowHeadersWidth = 51;
            this.dgvBorrowedInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBorrowedInfo.RowTemplate.Height = 24;
            this.dgvBorrowedInfo.Size = new System.Drawing.Size(867, 583);
            this.dgvBorrowedInfo.TabIndex = 4;
            // 
            // BorrowID
            // 
            this.BorrowID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BorrowID.DataPropertyName = "BorrowID";
            this.BorrowID.HeaderText = "BorrowID";
            this.BorrowID.MinimumWidth = 6;
            this.BorrowID.Name = "BorrowID";
            this.BorrowID.ReadOnly = true;
            this.BorrowID.Visible = false;
            // 
            // BorrowerID
            // 
            this.BorrowerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BorrowerID.DataPropertyName = "BorrowerID";
            this.BorrowerID.HeaderText = "BorrowerID";
            this.BorrowerID.MinimumWidth = 6;
            this.BorrowerID.Name = "BorrowerID";
            this.BorrowerID.ReadOnly = true;
            this.BorrowerID.Visible = false;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // BookTitle
            // 
            this.BookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "BookTitle";
            this.BookTitle.MinimumWidth = 6;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            this.BookTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BorrowedDate
            // 
            this.BorrowedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BorrowedDate.DataPropertyName = "BorrowedDate";
            this.BorrowedDate.HeaderText = "BorrowedDate";
            this.BorrowedDate.MinimumWidth = 6;
            this.BorrowedDate.Name = "BorrowedDate";
            this.BorrowedDate.ReadOnly = true;
            this.BorrowedDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.HeaderText = "DueDate";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // bookBorrowingBindingSource
            // 
            this.bookBorrowingBindingSource.DataMember = "BookBorrowing";
            this.bookBorrowingBindingSource.DataSource = this.lmsdcsDataSet36;
            // 
            // lmsdcsDataSet36
            // 
            this.lmsdcsDataSet36.DataSetName = "lmsdcsDataSet36";
            this.lmsdcsDataSet36.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvBorrower
            // 
            this.dgvBorrower.AllowUserToAddRows = false;
            this.dgvBorrower.AllowUserToDeleteRows = false;
            this.dgvBorrower.AllowUserToResizeColumns = false;
            this.dgvBorrower.AllowUserToResizeRows = false;
            this.dgvBorrower.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.Section});
            this.dgvBorrower.DataSource = this.activeBorrowersBindingSource;
            this.dgvBorrower.EnableHeadersVisualStyles = false;
            this.dgvBorrower.Location = new System.Drawing.Point(112, 189);
            this.dgvBorrower.Name = "dgvBorrower";
            this.dgvBorrower.ReadOnly = true;
            this.dgvBorrower.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrower.RowHeadersVisible = false;
            this.dgvBorrower.RowHeadersWidth = 51;
            this.dgvBorrower.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBorrower.RowTemplate.Height = 24;
            this.dgvBorrower.Size = new System.Drawing.Size(842, 583);
            this.dgvBorrower.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
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
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Visible = false;
            // 
            // Section
            // 
            this.Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.MinimumWidth = 6;
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Visible = false;
            // 
            // activeBorrowersBindingSource
            // 
            this.activeBorrowersBindingSource.DataMember = "ActiveBorrowers";
            this.activeBorrowersBindingSource.DataSource = this.lmsdcsDataSet33;
            // 
            // lmsdcsDataSet33
            // 
            this.lmsdcsDataSet33.DataSetName = "lmsdcsDataSet33";
            this.lmsdcsDataSet33.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSearchBorrow
            // 
            this.txtSearchBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearchBorrow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBorrow.Location = new System.Drawing.Point(514, 18);
            this.txtSearchBorrow.Name = "txtSearchBorrow";
            this.txtSearchBorrow.Size = new System.Drawing.Size(714, 27);
            this.txtSearchBorrow.TabIndex = 2;
            this.txtSearchBorrow.TextChanged += new System.EventHandler(this.txtSearchBorrow_TextChanged);
            this.txtSearchBorrow.Enter += new System.EventHandler(this.txtSearchBorrow_Enter);
            this.txtSearchBorrow.Leave += new System.EventHandler(this.txtSearchBorrow_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Borrower List";
            // 
            // activeBorrowersTableAdapter
            // 
            this.activeBorrowersTableAdapter.ClearBeforeFill = true;
            // 
            // bookBorrowingTableAdapter
            // 
            this.bookBorrowingTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtSearchBorrow);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 68);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(465, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 205;
            this.pictureBox1.TabStop = false;
            // 
            // dshBorrowerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dshBorrowerList";
            this.Text = "dshBorrowerList";
            this.Load += new System.EventHandler(this.dshBorrowerList_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBorrowingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBorrowersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet33)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBorrower;
        private System.Windows.Forms.TextBox txtSearchBorrow;
        private lmsdcsDataSet33 lmsdcsDataSet33;
        private System.Windows.Forms.BindingSource activeBorrowersBindingSource;
        private lmsdcsDataSet33TableAdapters.ActiveBorrowersTableAdapter activeBorrowersTableAdapter;
        private System.Windows.Forms.DataGridView dgvBorrowedInfo;
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
        private lmsdcsDataSet36 lmsdcsDataSet36;
        private System.Windows.Forms.BindingSource bookBorrowingBindingSource;
        private lmsdcsDataSet36TableAdapters.BookBorrowingTableAdapter bookBorrowingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}