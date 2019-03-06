using dk.lashout.LARPay.Accounting.Forms;
using System;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class Credit : Transaction
    {
        public Guid Benefactor { get; }
        public string Description { get; }
        public double Amount { get; }

        public Credit(Guid benefactor, double amount, string description)
        {
            Benefactor = benefactor;
            Amount = amount;
            Description = description;
        }
    }
}
