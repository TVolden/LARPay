using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public abstract class Transaction
    {
        public string Description { get; }
        public DateTime Date1 { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        internal TReturn Accept<TReturn>(ITransferVisitor<TReturn> visitor)
        {
            return visitor.Visit((dynamic)this);
        }

        public Transaction(decimal amount, string description, DateTime date)
        {
            Amount = amount;
            Description = description;
            Date1 = date;
        }
    }
}
