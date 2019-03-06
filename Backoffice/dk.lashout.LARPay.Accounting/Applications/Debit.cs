using dk.lashout.LARPay.Accounting.Forms;
using System;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class Debit : Transaction
    {
        public Guid Recipient { get; }
        public string Description { get; }
        public double Amount { get; }

        public Debit(Guid recipient, double amount, string description)
        {
            Recipient = recipient;
            Amount = -amount;
            Description = description;
        }
    }
}
