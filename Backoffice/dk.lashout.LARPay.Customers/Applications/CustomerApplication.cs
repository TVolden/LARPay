using System;
using dk.lashout.LARPay.Customers.Forms;

namespace dk.lashout.LARPay.Customers.Applications
{
    class CustomerApplication : ICustomer
    {
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }

        public CustomerApplication(string username, string pincode, string name)
        {
            Username = username;
            Pincode = pincode;
            Name = name;
        }
    }
}
