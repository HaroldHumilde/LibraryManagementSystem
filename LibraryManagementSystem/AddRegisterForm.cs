using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class AddRegisterForm
    {
        private long _StudentNumber;
        private long _ContactNo;
        private int _Age;
        private string _Gender, _Section, _Year, _Email , _Birthday, _Address, _Lastname, _Firstname, _Middlename;
        public AddRegisterForm(long StudentNumber,string Year, string Lastname, string Firstname, string Middlename, string Birthday, int Age, string Gender, string Address, string Section, string Email, long ContactNo)
        {
            this._StudentNumber = StudentNumber;
            this._Year = Year;
            this._Lastname = Lastname;
            this._Firstname = Firstname;
            this._Middlename = Middlename;
            this._ContactNo = ContactNo;
            this._Gender = Gender;
            this._Age = Age;
            this._Section = Section;
            this._Email = Email;
            this._Birthday = Birthday;
            this._Address = Address;
          
            
            
            

        }
       
        public string lastname
        {
            get
            {
                return this._Lastname;
            }
            set
            {
                this._Lastname = value;
            }
        }
        public string firstname
        {
            get
            {
                return this._Firstname;
            }
            set
            {
                this._Firstname = value;
            }
        }

        public string middlename
        {
            get
            {
                return this._Middlename;
            }
            set
            {
                this._Middlename = value;
            }
        }
        public string gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
            }
        }
        public string section
        {
            get
            {
                return this._Section;
            }
            set
            {
                this._Section = value;
            }
        }
        
        public string year
        {
            get
            {
                return this._Year;
            }
            set
            {
                this._Year = value;
            }
        }
        
        public string email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }
        
        public string birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this._Birthday = value;
            }
        }
        public string address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }
        public long studentNumber
        {
            get
            {
                return this._StudentNumber;
            }
            set
            {
                this._StudentNumber = value;
            }
        }
        public long contactNo
        {
            get
            {
                return this._ContactNo;
            }
            set
            {
                this._ContactNo = value;
            }
        }
        public int age
        {
            get
            {
                return this._Age;
            }
            set
            {
                this._Age = value;
            }
        }

    }
}
