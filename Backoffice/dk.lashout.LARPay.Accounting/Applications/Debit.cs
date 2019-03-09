using dk.lashout.LARPay.Accounting.Forms;
using System;

namespace dk.lashout.LARPay.Accounting.Applications
{
    public class Debit : Transaction
    {
        public Guid Recipient { get; }

        public Debit(Guid recipient, decimal amount, string description, DateTime date) : base(-amount, description, date)
        {
            Recipient = recipient;
        }
    }
}
