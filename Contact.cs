using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactList
{
    class Contact
    {
        public string contactName{ get; set; }
        public string contactNumber { get; set; }
        public string contactMail { get; set; }
        public override string ToString()
        {
            return contactName + " " + contactNumber + " " + contactMail;
        }
    }
}
