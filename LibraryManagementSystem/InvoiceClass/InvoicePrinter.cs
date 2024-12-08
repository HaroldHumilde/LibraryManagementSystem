using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class InvoicePrinter
    {

        // Singleton pattern for the InvoicePrinter class
        private static InvoicePrinter _instance;
        public static InvoicePrinter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InvoicePrinter();
                return _instance;
            }
        }







        /*  public string GenerateInvoice(string name, string studentNumber, string book1, string book2, string price1, string price2, string librarianName)
          {
              int invoiceNumber = GetNextInvoiceNumber(); // Get the next invoice number (you may need to implement this logic)

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
                  logoStream = new MemoryStream();
                  image.Save(logoStream, ImageFormat.Png); // Save as PNG to memory stream
              }
              logoStream.Position = 0; // Reset stream position for reading

              // Convert MemoryStream to XImage
              XImage logo = XImage.FromStream(logoStream);

              // Set logo dimensions
              double logoWidth = 80; // Adjusted logo width
              double logoHeight = 80; // Adjusted logo height
              double pageWidth = page.Width.Point;
              double logoX = (pageWidth - logoWidth) / 2; // Center logo horizontally
              double logoY = 40; // Top margin
              gfx.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);

              // Adjust yPosition to start content below the logo
              double yPosition = logoY + logoHeight + 20;

              // Define fonts
              XFont fontNormal = new XFont("Arial", 12); // Regular text
              XFont fontTitle = new XFont("Arial", 20); // Larger size for the title
              XFont fontSchoolName = new XFont("Arial", 14); // Larger size for the school name

              // Title
              gfx.DrawString("Don Marcelo Jimenez Memorial Polytechnic Institute", fontSchoolName, XBrushes.Black,
                  new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
              yPosition += 20;

              // Address
              XFont fontAddress = new XFont("Arial", 11);
              gfx.DrawString("Poblacion, Dasol, Pangasinan", fontAddress, XBrushes.Black,
                  new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
              yPosition += 30;

              // Invoice title (BOOK MATE)
              gfx.DrawString("BOOK MATE", fontTitle, XBrushes.Black,
                  new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
              yPosition += 50;

              // Header: Name, Date, Student Number, Invoice No.
              gfx.DrawString($"Name: {name}", fontNormal, XBrushes.Black, 80, yPosition);
              gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
              yPosition += 20;

              gfx.DrawString($"Student Number: {studentNumber}", fontNormal, XBrushes.Black, 80, yPosition);
              gfx.DrawString($"Invoice No: #{invoiceNumber}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
              yPosition += 40;

              // Table for items (books and prices)
              double tableWidth = 450;
              double tableX = (pageWidth - tableWidth) / 2;
              double columnNoWidth = 40;
              double columnBookWidth = 200;
              double columnQtyWidth = 50;
              double columnPriceWidth = 80;

              // Draw the header background rectangle
              gfx.DrawRectangle(XBrushes.LightGray, tableX, yPosition, tableWidth, 20);

              // Table headers
              gfx.DrawString("NO", fontNormal, XBrushes.Black, tableX + 5, yPosition + 15);
              gfx.DrawString("BOOK LOST", fontNormal, XBrushes.Black, tableX + columnNoWidth + 5, yPosition + 15);
              gfx.DrawString("QTY", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 5, yPosition + 15);
              gfx.DrawString("PRICE", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 5, yPosition + 15);
              gfx.DrawString("SUBTOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 5, yPosition + 15);

              // Draw horizontal line below the headers
              gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

              yPosition += 20;

              // Rows for each book
              int qty = 1; // Quantity constant for simplicity

              // First Book (book1)
              gfx.DrawString("1", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
              gfx.DrawString(book1, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
              gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
              gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
              gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);

              // Draw horizontal line below the row
              gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

              yPosition += 20; // Move yPosition for next row

              // Second Book (book2) - Conditional check for empty book2 or price2
              if (!string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(price2))
              {
                  gfx.DrawString("2", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
                  gfx.DrawString(book2, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
                  gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
                  gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
                  gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);

                  // Draw horizontal line below the row
                  gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

                  yPosition += 20; // Move yPosition for next row
              }

              // Total
              double total = double.Parse(price1) + (string.IsNullOrEmpty(price2) ? 0 : double.Parse(price2));
              gfx.DrawString("TOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 20);
              gfx.DrawString(total.ToString("F2"), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 20);



              // Footer (Librarian Name)
              gfx.DrawString(librarianName, fontNormal, XBrushes.Black, tableX + 5, yPosition + 250);
              gfx.DrawString("Librarian", fontNormal, XBrushes.Black, tableX + 5, yPosition + 265);

              // Save the document to a file
              string filename = $"Invoice_{invoiceNumber}.pdf";
              doc.Save(filename);

              return filename; // Return the file path to the generated invoice
          }*/



      

            public string GenerateInvoice(string name, string studentNumber, string book1, string book2, string price1, string price2, string librarianName)
            {
                int invoiceNumber = GetNextInvoiceNumber(); // Get the next invoice number (now incremented)

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
                    logoStream = new MemoryStream();
                    image.Save(logoStream, ImageFormat.Png); // Save as PNG to memory stream
                }
                logoStream.Position = 0; // Reset stream position for reading

                // Convert MemoryStream to XImage
                XImage logo = XImage.FromStream(logoStream);

                // Set logo dimensions
                double logoWidth = 80; // Adjusted logo width
                double logoHeight = 80; // Adjusted logo height
                double pageWidth = page.Width.Point;
                double logoX = (pageWidth - logoWidth) / 2; // Center logo horizontally
                double logoY = 40; // Top margin
                gfx.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);

                // Adjust yPosition to start content below the logo
                double yPosition = logoY + logoHeight + 20;

                // Define fonts
                XFont fontNormal = new XFont("Arial", 12); // Regular text
                XFont fontTitle = new XFont("Arial", 20); // Larger size for the title
                XFont fontSchoolName = new XFont("Arial", 14); // Larger size for the school name

                // Title
                gfx.DrawString("Don Marcelo Jimenez Memorial Polytechnic Institute", fontSchoolName, XBrushes.Black,
                    new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
                yPosition += 20;

                // Address
                XFont fontAddress = new XFont("Arial", 11);
                gfx.DrawString("Poblacion, Dasol, Pangasinan", fontAddress, XBrushes.Black,
                    new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
                yPosition += 30;

                // Invoice title (BOOK MATE)
                gfx.DrawString("BOOK MATE", fontTitle, XBrushes.Black,
                    new XRect(0, yPosition, page.Width, page.Height), XStringFormat.TopCenter);
                yPosition += 50;

                // Header: Name, Date, Student Number, Invoice No.
                gfx.DrawString($"Name: {name}", fontNormal, XBrushes.Black, 80, yPosition);
                gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
                yPosition += 20;

                gfx.DrawString($"Student Number: {studentNumber}", fontNormal, XBrushes.Black, 80, yPosition);
                gfx.DrawString($"Invoice No: #{invoiceNumber}", fontNormal, XBrushes.Black, pageWidth - 180, yPosition);
                yPosition += 40;

                // Table for items (books and prices)
                double tableWidth = 450;
                double tableX = (pageWidth - tableWidth) / 2;
                double columnNoWidth = 40;
                double columnBookWidth = 200;
                double columnQtyWidth = 50;
                double columnPriceWidth = 80;

                // Draw the header background rectangle
                gfx.DrawRectangle(XBrushes.LightGray, tableX, yPosition, tableWidth, 20);

                // Table headers
                gfx.DrawString("NO", fontNormal, XBrushes.Black, tableX + 5, yPosition + 15);
                gfx.DrawString("BOOK LOST", fontNormal, XBrushes.Black, tableX + columnNoWidth + 5, yPosition + 15);
                gfx.DrawString("QTY", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 5, yPosition + 15);
                gfx.DrawString("PRICE", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 5, yPosition + 15);
                gfx.DrawString("SUBTOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 5, yPosition + 15);

                // Draw horizontal line below the headers
                gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

                yPosition += 20;

                // Rows for each book
                int qty = 1; // Quantity constant for simplicity

                // First Book (book1)
                gfx.DrawString("1", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
                gfx.DrawString(book1, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
                gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
                gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
                gfx.DrawString(price1, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);

                // Draw horizontal line below the row
                gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

                yPosition += 20; // Move yPosition for next row

                // Second Book (book2) - Conditional check for empty book2 or price2
                if (!string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(price2))
                {
                    gfx.DrawString("2", fontNormal, XBrushes.Black, tableX + 5, yPosition + 13);
                    gfx.DrawString(book2, fontNormal, XBrushes.Black, tableX + columnNoWidth + 10, yPosition + 13);
                    gfx.DrawString(qty.ToString(), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 13);
                    gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + 15, yPosition + 13);
                    gfx.DrawString(price2, fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 13);

                    // Draw horizontal line below the row
                    gfx.DrawLine(XPens.Black, tableX, yPosition + 20, tableX + tableWidth, yPosition + 20);

                    yPosition += 20; // Move yPosition for next row
                }

                // Total
                double total = double.Parse(price1) + (string.IsNullOrEmpty(price2) ? 0 : double.Parse(price2));
                gfx.DrawString("TOTAL", fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + 15, yPosition + 20);
                gfx.DrawString(total.ToString("F2"), fontNormal, XBrushes.Black, tableX + columnNoWidth + columnBookWidth + columnQtyWidth + columnPriceWidth + 15, yPosition + 20);

                // Footer (Librarian Name)
                gfx.DrawString(librarianName, fontNormal, XBrushes.Black, tableX + 5, yPosition + 250);
                gfx.DrawString("Librarian", fontNormal, XBrushes.Black, tableX + 5, yPosition + 265);

                // Save the document to a file
                string filename = $"Invoice_{invoiceNumber}.pdf";
                doc.Save(filename);

                return filename; // Return the file path to the generated invoice
            }

       
        
            // Static variable to store the last invoice number (it will be shared across all instances)
            private static int lastInvoiceNumber = 0;

            // Method to get the next invoice number (auto-increment)
            private int GetNextInvoiceNumber()
            {
                // Increment the last invoice number for the next one
                lastInvoiceNumber++;

                // Return the incremented invoice number
                return lastInvoiceNumber;
            }


            // Method to print the generated invoice
            public void PrintInvoice(string filename)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(filename)
                    {
                        Verb = "print",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error printing the invoice: " + ex.Message);
                }


            }
        

    

    }

    

}
