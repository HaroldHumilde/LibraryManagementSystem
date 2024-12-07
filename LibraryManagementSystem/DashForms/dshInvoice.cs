using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.UniversalAccessibility.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    public partial class dshInvoice : Form
    {
        public dshInvoice()
        {
            InitializeComponent();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            // Get user input from the textboxes
            string name = txtName.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string book1 = txtBookOne.Text.Trim();
            string book2 = txtBookTwo.Text.Trim();
            string price1 = txtPriceOne.Text.Trim();
            string price2 = txtPriceTwo.Text.Trim();
            string librarianName = txtLibrarianName.Text.Trim(); // Get librarian's name from the textbox

            // Validate input fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentNumber) ||
                string.IsNullOrEmpty(book1) || string.IsNullOrEmpty(price1))
            {
                MessageBox.Show("Please fill all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Generate the invoice, passing the librarian's name
                string filePath = GenerateInvoice(name, studentNumber, book1, book2, price1, price2, librarianName);

                // Notify the user
                MessageBox.Show($"Invoice successfully generated at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the generated PDF
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        private string GenerateInvoice(string name, string studentNumber, string book1, string book2, string price1, string price2, string librarianName)
        {
            // Retrieve the next invoice number
            int invoiceNumber = GetNextInvoiceNumber();

            // Create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Invoice";

            // Add a page to the document
            PdfPage page = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Load and process the logo using System.Drawing
            string logoPath = "C:\\Users\\Admin\\OneDrive - STI College Alaminos\\Pictures\\Don ma.jpg"; // Replace with actual path
            MemoryStream logoStream;

            using (var image = new Bitmap(logoPath))
            {
                // Optionally resize or manipulate the image here if needed
                logoStream = new MemoryStream();
                image.Save(logoStream, System.Drawing.Imaging.ImageFormat.Png); // Save as PNG to memory stream
            }
            logoStream.Position = 0; // Reset stream position for reading

            // Convert MemoryStream to XImage
            XImage logo = XImage.FromStream(logoStream);

            // Set smaller dimensions for the logo
            double logoWidth = 80; // Adjusted logo width
            double logoHeight = 80; // Adjusted logo height
            double pageWidth = page.Width.Point;

            // Position the logo in the center of the page (top part)
            double logoX = (pageWidth - logoWidth) / 2; // Center the logo horizontally
            double logoY = 40; // Top margin

            // Draw the logo with specified dimensions
            gfx.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);

            // Adjust yPosition to start content below the logo
            double yPosition = logoY + logoHeight + 20; // Increased padding below the logo for more space

            // Define fonts
            XFont fontNormal = new XFont("Arial", 12); // Regular text
            XFont fontSmall = new XFont("Arial", 10); // Footer text
            XFont fontLibrarianName = new XFont("Arial", 12); // Librarian's name style


            // Title
            XFont fontSchoolName = new XFont("Arial", 14); // Larger size for the title
            gfx.DrawString("Don Marcelo Jimenez Memorial Polytechnic Institute", fontSchoolName, XBrushes.Black,
                new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
            yPosition += 20; // Add more space after the title

            

            XFont fontAddress = new XFont("Arial", 11); // Larger size for the title
            gfx.DrawString("Poblacion, Dasol, Pangasinan", fontAddress, XBrushes.Black,
                new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
            yPosition += 30; // Add more space after the title

            XFont fontTitle = new XFont("Arial", 20); // Larger size for the title
            gfx.DrawString("BOOK MATE", fontTitle, XBrushes.Black,
                new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
            yPosition += 50; // Add more space after the title

            // Header (Name and Date)
            gfx.DrawString($"Name: {name}", fontNormal, XBrushes.Black, 80, yPosition);

            gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
            yPosition += 20;

            gfx.DrawString($"Student Number: {studentNumber}", fontNormal, XBrushes.Black, 80, yPosition);
            gfx.DrawString($"Invoice No: #{invoiceNumber}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
            yPosition += 40; // Added more space before the table

            // Table dimensions
            double tableWidth = 450; // Table width remains the same
            double tableX = (pageWidth - tableWidth) / 2; // Center the table horizontally
            double columnNoWidth = 40;
            double columnBookWidth = 200;
            double columnQtyWidth = 50;
            double columnPriceWidth = 80;
            

            // Table Header Background
            gfx.DrawRectangle(XBrushes.LightGray, tableX, yPosition, tableWidth, 20);

            // Table Header
            gfx.DrawString("NO", fontNormal, XBrushes.Black, tableX + 5, yPosition + 15);
            gfx.DrawString("BOOK LOST", fontNormal, XBrushes.Black, tableX + columnNoWidth + 5, yPosition + 15);
            gfx.DrawString("QTY", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 5, yPosition + 15);
            gfx.DrawString("PRICE", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 5, yPosition + 15);
            gfx.DrawString("SUBTOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 5, yPosition + 15);

            // Draw vertical lines below the header
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth, yPosition, tableX + columnNoWidth, yPosition + 20);  // Line after NO
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth, yPosition, tableX + columnNoWidth + columnBookWidth, yPosition + 20);  // Line after BOOK LOST
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition + 20);  // Line after QTY
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition + 20);  // Line after PRICE

            yPosition += 20;

            // Table Rows
            int rowHeight = 20;
            int qty = 1;  // Quantity (constant for this example)

            // Row 1
            gfx.DrawString("1", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
            gfx.DrawString(book1, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
            gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
            gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
            gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);
            yPosition += rowHeight;

            // Draw horizontal line after the first row
            gfx.DrawLine(XPens.Black, tableX, yPosition, tableX + tableWidth, yPosition);

            // Draw vertical lines between columns in the first row
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth, yPosition - rowHeight, tableX + columnNoWidth, yPosition);  // Line after NO
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth, yPosition);  // Line after BOOK LOST
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition);  // Line after QTY
            gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition);  // Line after PRICE

            // Row 2 (if applicable)
            if (!string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(price2))
            {
                gfx.DrawString("2", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
                gfx.DrawString(book2, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
                gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
                gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
                gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);
                yPosition += rowHeight;

                // Draw horizontal line after the second row
                gfx.DrawLine(XPens.Black, tableX, yPosition, tableX + tableWidth, yPosition);

                // Draw vertical lines between columns in the second row
                gfx.DrawLine(XPens.Black, tableX + columnNoWidth, yPosition - rowHeight, tableX + columnNoWidth, yPosition);  // Line after NO
                gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth, yPosition);  // Line after BOOK LOST
                gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth + columnQtyWidth, yPosition);  // Line after QTY
                gfx.DrawLine(XPens.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition - rowHeight, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth, yPosition);  // Line after PRICE
            }

            // Total
            double total = double.Parse(price1) + (string.IsNullOrEmpty(price2) ? 0 : double.Parse(price2));
            gfx.DrawString("TOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 20);
            gfx.DrawString(total.ToString("F2"), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 20);

            // Footer (Librarian Name and Label)
            double footerLineY = yPosition + 300; // Lowered footer position further down

            // Adjust the position of the librarian's name and "Librarian" label
            double librarianNameX = tableX + 5;  // Align librarian's name with the left side of the table
            double librarianLabelX = tableX + 5;  // Align "Librarian" label with a little indentation to the right

            // Librarian's name at the top of the footer (no underline)
            gfx.DrawString(librarianName, fontLibrarianName, XBrushes.Black, librarianNameX, footerLineY);

            // "Librarian" label directly below the librarian's name
            gfx.DrawString("Librarian", fontSmall, XBrushes.Black, librarianLabelX, footerLineY + 10);

            // Save the document to a file
            string filename = $"Invoice_{invoiceNumber}.pdf";
            doc.Save(filename);

            return filename;

        }

        // Method to retrieve and increment the invoice number
        private int GetNextInvoiceNumber()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InvoiceNumber.txt");

            // Initialize the invoice number
            int invoiceNumber = 1;

            // Read the current invoice number from the file, if it exists
            if (File.Exists(filePath))
            {
                string lastNumber = File.ReadAllText(filePath);
                if (int.TryParse(lastNumber, out int parsedNumber))
                {
                    invoiceNumber = parsedNumber + 1;
                }
            }

            // Save the next invoice number back to the file
            File.WriteAllText(filePath, invoiceNumber.ToString());

            return invoiceNumber;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLibrarianName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtPriceTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
