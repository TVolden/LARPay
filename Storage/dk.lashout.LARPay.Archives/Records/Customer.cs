using System;
using dk.lashout.LARPay.Customers.Forms;

namespace dk.lashout.LARPay.Archives.Records
{
    class Customer : ICustomer
    {
        public string Name { get; }
        public string Identifier { get; }
        public Guid Account { get; set; }

        public Customer(string identity, string name, Guid account)
        {
            Identifier = identity;
            Name = name;
            Account = account;
        }
    }
}
