using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    class Contact
    {
        public string name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Contact(string name, int phone, string email, string address)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.address = address;
        }
    }
}