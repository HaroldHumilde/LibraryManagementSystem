namespace LibraryManagementSystem
{
    partial class ViewProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProfileForm));
            this.dataViewBorrowerInfo = new System.Windows.Forms.DataGridView();
            this.registerInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lmsdcsDataSet = new LibraryManagementSystem.lmsdcsDataSet();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnBorrowBooks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblPenalty = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.lblStudentNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearchProf = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchProf = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPenalty = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbPenalty = new System.Windows.Forms.ComboBox();
            this.registerInformationTableAdapter = new LibraryManagementSystem.lmsdcsDataSetTableAdapters.RegisterInformationTableAdapter();
            this.txtSearchBorrower = new System.Windows.Forms.TextBox();
            this.lmsdcsDataSet2 = new LibraryManagementSystem.lmsdcsDataSet2();
            this.registerInformationBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.registerInformationTableAdapter1 = new LibraryManagementSystem.lmsdcsDataSet2TableAdapters.RegisterInformationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewBorrowerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInformationBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewBorrowerInfo
            // 
            this.dataViewBorrowerInfo.AllowUserToOrderColumns = true;
            this.dataViewBorrowerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewBorrowerInfo.BackgroundColor = System.Drawing.Color.Navy;
            this.dataViewBorrowerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewBorrowerInfo.Location = new System.Drawing.Point(75, 659);
            this.dataViewBorrowerInfo.Name = "dataViewBorrowerInfo";
            this.dataViewBorrowerInfo.RowHeadersWidth = 51;
            this.dataViewBorrowerInfo.RowTemplate.Height = 24;
            this.dataViewBorrowerInfo.Size = new System.Drawing.Size(1712, 79);
            this.dataViewBorrowerInfo.TabIndex = 2;
            this.dataViewBorrowerInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewBorrowerInfo_CellContentClick);
            // 
            // registerInformationBindingSource
            // 
            this.registerInformationBindingSource.DataMember = "RegisterInformation";
            this.registerInformationBindingSource.DataSource = this.lmsdcsDataSet;
            // 
            // lmsdcsDataSet
            // 
            this.lmsdcsDataSet.DataSetName = "lmsdcsDataSet";
            this.lmsdcsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Lime;
            this.btnRemove.Location = new System.Drawing.Point(70, 494);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 36);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnBorrowBooks
            // 
            this.btnBorrowBooks.ForeColor = System.Drawing.Color.Lime;
            this.btnBorrowBooks.Location = new System.Drawing.Point(70, 430);
            this.btnBorrowBooks.Name = "btnBorrowBooks";
            this.btnBorrowBooks.Size = new System.Drawing.Size(110, 36);
            this.btnBorrowBooks.TabIndex = 4;
            this.btnBorrowBooks.Text = "Borrow Books";
            this.btnBorrowBooks.UseVisualStyleBackColor = true;
            this.btnBorrowBooks.Click += new System.EventHandler(this.btnViewInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.lblPenalty);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(59, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 336);
            this.panel1.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(57, 263);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 20);
            this.label22.TabIndex = 19;
            this.label22.Text = "Penalty:";
            // 
            // lblPenalty
            // 
            this.lblPenalty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPenalty.AutoSize = true;
            this.lblPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPenalty.ForeColor = System.Drawing.Color.White;
            this.lblPenalty.Location = new System.Drawing.Point(143, 263);
            this.lblPenalty.Name = "lblPenalty";
            this.lblPenalty.Size = new System.Drawing.Size(64, 20);
            this.lblPenalty.TabIndex = 18;
            this.lblPenalty.Text = "Penalty";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(57, 214);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 20);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "FullName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(61, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(459, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(69, 20);
            this.label.TabIndex = 18;
            this.label.Text = "Gender:";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(819, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(107, 20);
            this.label32.TabIndex = 19;
            this.label32.Text = "Date of birth:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.lblDateOfBirth.Location = new System.Drawing.Point(930, 32);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(105, 20);
            this.lblDateOfBirth.TabIndex = 20;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(534, 32);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(64, 20);
            this.lblGender.TabIndex = 21;
            this.lblGender.Text = "Gender";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(819, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Contact number:";
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNumber.ForeColor = System.Drawing.Color.White;
            this.lblContactNumber.Location = new System.Drawing.Point(971, 42);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(131, 20);
            this.lblContactNumber.TabIndex = 23;
            this.lblContactNumber.Text = "Contact Number";
            // 
            // lblStudentNumber
            // 
            this.lblStudentNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStudentNumber.AutoSize = true;
            this.lblStudentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentNumber.ForeColor = System.Drawing.Color.White;
            this.lblStudentNumber.Location = new System.Drawing.Point(255, 37);
            this.lblStudentNumber.Name = "lblStudentNumber";
            this.lblStudentNumber.Size = new System.Drawing.Size(127, 20);
            this.lblStudentNumber.TabIndex = 24;
            this.lblStudentNumber.Text = "Student number";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(480, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Year:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lblGender);
            this.panel2.Controls.Add(this.lblDateOfBirth);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblAge);
            this.panel2.Location = new System.Drawing.Point(470, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 83);
            this.panel2.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(184, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Age:";
            // 
            // lblAge
            // 
            this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.Color.White;
            this.lblAge.Location = new System.Drawing.Point(246, 32);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 20);
            this.lblAge.TabIndex = 35;
            this.lblAge.Text = "Age";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(854, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Section:";
            // 
            // lblYear
            // 
            this.lblYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.White;
            this.lblYear.Location = new System.Drawing.Point(534, 37);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(43, 20);
            this.lblYear.TabIndex = 28;
            this.lblYear.Text = "Year";
            // 
            // lblSection
            // 
            this.lblSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.White;
            this.lblSection.Location = new System.Drawing.Point(930, 37);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(65, 20);
            this.lblSection.TabIndex = 29;
            this.lblSection.Text = "Section";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(108, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Address:";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(199, 42);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(71, 20);
            this.lblAddress.TabIndex = 31;
            this.lblAddress.Text = "Address";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(500, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Email:";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(562, 42);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 20);
            this.lblEmail.TabIndex = 33;
            this.lblEmail.Text = "Email";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblStudentNumber);
            this.panel3.Controls.Add(this.lblYear);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblSection);
            this.panel3.Location = new System.Drawing.Point(470, 183);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1299, 87);
            this.panel3.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(108, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Student number:";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblEmail);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblAddress);
            this.panel4.Controls.Add(this.lblContactNumber);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(470, 266);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1299, 104);
            this.panel4.TabIndex = 35;
            // 
            // btnSearchProf
            // 
            this.btnSearchProf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearchProf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchProf.BackgroundImage = global::LibraryManagementSystem.Properties.Resources.th_removebg_preview__5_;
            this.btnSearchProf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchProf.Location = new System.Drawing.Point(857, 25);
            this.btnSearchProf.Name = "btnSearchProf";
            this.btnSearchProf.Size = new System.Drawing.Size(38, 36);
            this.btnSearchProf.TabIndex = 40;
            this.btnSearchProf.UseVisualStyleBackColor = false;
            this.btnSearchProf.Click += new System.EventHandler(this.btnSearchProf_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(1043, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(621, 36);
            this.textBox1.TabIndex = 36;
            // 
            // searchProf
            // 
            this.searchProf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchProf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchProf.BackgroundImage = global::LibraryManagementSystem.Properties.Resources.th_removebg_preview__5_;
            this.searchProf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchProf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchProf.Location = new System.Drawing.Point(1626, 25);
            this.searchProf.Name = "searchProf";
            this.searchProf.Size = new System.Drawing.Size(38, 36);
            this.searchProf.TabIndex = 37;
            this.searchProf.UseVisualStyleBackColor = false;
            this.searchProf.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(782, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Profile";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(1560, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Books";
            // 
            // btnPenalty
            // 
            this.btnPenalty.ForeColor = System.Drawing.Color.Lime;
            this.btnPenalty.Location = new System.Drawing.Point(220, 494);
            this.btnPenalty.Name = "btnPenalty";
            this.btnPenalty.Size = new System.Drawing.Size(92, 36);
            this.btnPenalty.TabIndex = 39;
            this.btnPenalty.Text = "Penalty";
            this.btnPenalty.UseVisualStyleBackColor = true;
            this.btnPenalty.Click += new System.EventHandler(this.btnPenalty_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel5.BackColor = System.Drawing.Color.Navy;
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(470, 362);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1299, 75);
            this.panel5.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(951, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 20);
            this.label15.TabIndex = 23;
            this.label15.Text = "Author:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(868, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "Author:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(585, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "ISBN:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(502, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "ISBN:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(221, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Book Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(109, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Book Title:";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel6.BackColor = System.Drawing.Color.Navy;
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Location = new System.Drawing.Point(470, 432);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1299, 78);
            this.panel6.TabIndex = 42;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1057, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 20);
            this.label17.TabIndex = 28;
            this.label17.Text = "BookShelves:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(903, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 20);
            this.label16.TabIndex = 27;
            this.label16.Text = "BookShelves:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(556, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 25;
            this.label19.Text = "Publish Date:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(225, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 20);
            this.label21.TabIndex = 27;
            this.label21.Text = "Category:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(705, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 24;
            this.label18.Text = "Publish Date:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(108, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 20);
            this.label20.TabIndex = 26;
            this.label20.Text = "Category:";
            // 
            // cmbPenalty
            // 
            this.cmbPenalty.AllowDrop = true;
            this.cmbPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPenalty.FormattingEnabled = true;
            this.cmbPenalty.Location = new System.Drawing.Point(220, 434);
            this.cmbPenalty.Name = "cmbPenalty";
            this.cmbPenalty.Size = new System.Drawing.Size(212, 28);
            this.cmbPenalty.TabIndex = 47;
            // 
            // registerInformationTableAdapter
            // 
            this.registerInformationTableAdapter.ClearBeforeFill = true;
            // 
            // txtSearchBorrower
            // 
            this.txtSearchBorrower.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearchBorrower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchBorrower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBorrower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBorrower.ForeColor = System.Drawing.Color.White;
            this.txtSearchBorrower.Location = new System.Drawing.Point(274, 25);
            this.txtSearchBorrower.Multiline = true;
            this.txtSearchBorrower.Name = "txtSearchBorrower";
            this.txtSearchBorrower.Size = new System.Drawing.Size(621, 36);
            this.txtSearchBorrower.TabIndex = 48;
            this.txtSearchBorrower.TextChanged += new System.EventHandler(this.txtSearchBorrower_TextChanged);
            // 
            // lmsdcsDataSet2
            // 
            this.lmsdcsDataSet2.DataSetName = "lmsdcsDataSet2";
            this.lmsdcsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registerInformationBindingSource1
            // 
            this.registerInformationBindingSource1.DataMember = "RegisterInformation";
            this.registerInformationBindingSource1.DataSource = this.lmsdcsDataSet2;
            // 
            // registerInformationTableAdapter1
            // 
            this.registerInformationTableAdapter1.ClearBeforeFill = true;
            // 
            // ViewProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1816, 740);
            this.Controls.Add(this.cmbPenalty);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnPenalty);
            this.Controls.Add(this.btnBorrowBooks);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnSearchProf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.searchProf);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataViewBorrowerInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtSearchBorrower);
            this.Name = "ViewProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewProfileForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewProfileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewBorrowerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lmsdcsDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInformationBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataViewBorrowerInfo;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnBorrowBooks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.Label lblStudentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button searchProf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPenalty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchProf;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbPenalty;
        private lmsdcsDataSet lmsdcsDataSet;
        private System.Windows.Forms.BindingSource registerInformationBindingSource;
        private lmsdcsDataSetTableAdapters.RegisterInformationTableAdapter registerInformationTableAdapter;
        private System.Windows.Forms.TextBox txtSearchBorrower;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblPenalty;
        private lmsdcsDataSet2 lmsdcsDataSet2;
        private System.Windows.Forms.BindingSource registerInformationBindingSource1;
        private lmsdcsDataSet2TableAdapters.RegisterInformationTableAdapter registerInformationTableAdapter1;
    }
}