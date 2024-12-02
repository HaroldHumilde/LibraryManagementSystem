using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public  class ViewProf
    {

        private string _Penalty;
        public ViewProf(string Penalty)
        {
            this._Penalty = Penalty;
           


        }
        public string Penalty
        {
            get
            {
                return this._Penalty;
            }
            set
            {
                this._Penalty = value;
            }
        }
    }
}
