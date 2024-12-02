using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content.Objects;
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

            // Define fonts
            XFont fontTitle = new XFont("Arial", 16); // Title font
            XFont fontNormal = new XFont("Arial", 12); // Regular text
            XFont fontSmall = new XFont("Arial", 10); // Footer text
            XFont fontBold = new XFont("Arial", 12); // Bold font for librarian name

            // Define positions
            double margin = 40;
            double yPosition = margin;

            // Header (Move Date to the Right, Align with Name)
            gfx.DrawString($"Name: {name}", fontNormal, XBrushes.Black, margin, yPosition);

            // Move the date to the right side of the page, aligned with Name
            double pageWidth = page.Width;
            gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy}", fontNormal, XBrushes.Black, pageWidth - 150, yPosition); // Adjust for right alignment

            yPosition += 20; // Move down for the next line

            gfx.DrawString($"Student Number: {studentNumber}", fontNormal, XBrushes.Black, margin, yPosition);
            yPosition += 20;
            gfx.DrawString($"Invoice No: #{invoiceNumber}", fontNormal, XBrushes.Black, margin, yPosition);
            yPosition += 20;

            yPosition += 40; // Add more space before the table (was previously 60)

            // Table dimensions
            double columnNoWidth = 40;
            double columnBookWidth = 200;
            double columnQtyWidth = 50;
            double columnPriceWidth = 80;
            double columnSubtotalWidth = 80;
            double tableWidth = columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + columnSubtotalWidth;

            // Table Header Background
            gfx.DrawRectangle(XBrushes.LightGray, margin, yPosition, tableWidth, 20);

            // Table Header
            gfx.DrawString("NO", fontNormal, XBrushes.Black, margin + 5, yPosition + 13);
            gfx.DrawString("BOOK LOST", fontNormal, XBrushes.Black, margin + columnNoWidth + 5, yPosition + 13);
            gfx.DrawString("QTY", fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + 5, yPosition + 13);
            gfx.DrawString("PRICE", fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + 5, yPosition + 13);
            gfx.DrawString("SUBTOTAL", fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 5, yPosition + 13);

            yPosition += 20;

            // Draw top border of the table
            gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition);

            // **No Vertical Lines** - Comment or delete the lines that draw vertical lines between columns

            // Table Rows
            int rowHeight = 20;
            int qty = 1;  // Quantity (constant for this example)

            // Row 1
            gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition); // Draw top border of the row
            gfx.DrawString("1", fontNormal, XBrushes.Black, margin + 15, yPosition + 13);
            gfx.DrawString(book1, fontNormal, XBrushes.Black, margin + columnNoWidth + 10, yPosition + 13);
            gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + 15, yPosition + 13);
            gfx.DrawString(price1, fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
            gfx.DrawString(price1, fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);
            yPosition += rowHeight;

            // Draw horizontal line after the first row (without vertical lines)
            gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition);

            // Row 2 (if applicable)
            if (!string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(price2))
            {
                gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition); // Draw top border of the row
                gfx.DrawString("2", fontNormal, XBrushes.Black, margin + 15, yPosition + 13);
                gfx.DrawString(book2, fontNormal, XBrushes.Black, margin + columnNoWidth + 10, yPosition + 13);
                gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + 15, yPosition + 13);
                gfx.DrawString(price2, fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
                gfx.DrawString(price2, fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);
                yPosition += rowHeight;

                // Draw horizontal line after the second row (without vertical lines)
                gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition);
            }

            // Draw bottom border of the table (without vertical lines)
            gfx.DrawLine(XPens.Black, margin, yPosition, margin + tableWidth, yPosition);

            // Total Row (no vertical lines)
            gfx.DrawString("TOTAL", fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
            double total = double.Parse(price1) + (string.IsNullOrEmpty(price2) ? 0 : double.Parse(price2));
            gfx.DrawString(total.ToString("F2"), fontNormal, XBrushes.Black, margin + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);
            yPosition += rowHeight;

            // Footer (Librarian Name below the underlined name)
            double footerLineY = yPosition + 250;
            gfx.DrawString(librarianName, fontBold, XBrushes.Black, margin, footerLineY); // Librarian's name
            double underlineLength = 90; // Length of the underline
            gfx.DrawLine(XPens.Black, margin, footerLineY + 3, margin + underlineLength, footerLineY + 3); // Underline for the name

            gfx.DrawString("Librarian", fontSmall, XBrushes.Black, margin, footerLineY + 20); // 'Librarian' label

            // Save the document to a file
            string filename = "Invoice_" + invoiceNumber + ".pdf";
            doc.Save(filename);

            return filename;  // Return file name (or path) of the generated invoice
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





        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
