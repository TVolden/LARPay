using System;

namespace dk.lashout.LARPay.Archives.Applications
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
