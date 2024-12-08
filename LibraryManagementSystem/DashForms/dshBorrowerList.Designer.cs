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
            this.SuspendLayout();
            // 
            // dshBorrowerList
            // 
            this.ClientSize = new System.Drawing.Size(1628, 701);
            this.Name = "dshBorrowerList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBorrower;
        private System.Windows.Forms.TextBox txtSearchBorrow;
        private System.Windows.Forms.DataGridView dgvBorrowedInfo;
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
        private lmsdcsDataSet45 lmsdcsDataSet45;
        private System.Windows.Forms.BindingSource activeBorrowersBindingSource;
        private lmsdcsDataSet45TableAdapters.ActiveBorrowersTableAdapter activeBorrowersTableAdapter;
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
    }
}