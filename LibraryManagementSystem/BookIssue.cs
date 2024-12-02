using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookIssue
    {

        private long _ISBN;
        private string _BookTitle, _Author, _Category, _PublishDate, _BookShelves, _Description;
        public BookIssue(string BookTitle, long ISBN, string Author, string Category, string PublishDate, string BookShelves, string Discription)
        {
            this._ISBN = ISBN;
            this._BookTitle = BookTitle;
            this._Author = Author;
            this._Category = Category;
            this._PublishDate = PublishDate;
            this._BookShelves = BookShelves;
            this._Description = Discription;


        }
        public string BookTitle
        {
            get
            {
                return this._BookTitle;
            }
            set
            {
                this._BookTitle = value;
            }
        }
        public string Author
        {
            get
            {
                return this._Author;
            }
            set
            {
                this._Author = value;
            }
        }

        public string Category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
            }
        }
        public string PublishDate
        {
            get
            {
                return this._PublishDate;
            }
            set
            {
                this._PublishDate = value;
            }
        }
        public string BookShelves
        {
            get
            {
                return this._BookShelves;
            }
            set
            {
                this._BookShelves = value;
            }
        }
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        public long ISBN
        {
            get
            {
                return this._ISBN;
            }
            set
            {
                this._ISBN = value;
            }
        }
    }
}
