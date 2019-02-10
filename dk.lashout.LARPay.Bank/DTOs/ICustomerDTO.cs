using dk.lashout.LARPay.Customers.Forms;
using System;

namespace dk.lashout.LARPay.Bank
{
    class ICustomerDTO : ICustomer
    {
        public ICustomerDTO(string name, string identity, Guid account)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            Identifier = identity ?? throw new System.ArgumentNullException(nameof(identity));
            Account = account;
        }

        public string Name { get; }
        public string Identifier { get; }
        public Guid Account { get; }
    }
}
