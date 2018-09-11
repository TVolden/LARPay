using System;

namespace dk.lashout.LARPay.Core.Entities
{
    class Transaction : ITransaction
    {
        public ICustomer Linked { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
