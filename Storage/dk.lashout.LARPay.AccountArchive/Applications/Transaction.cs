using System;

namespace dk.lashout.LARPay.AccountArchive.Applications
{
    public abstract class Transaction
    {
        public string Description { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }

        internal TReturn Accept<TReturn>(ITransferVisitor<TReturn> visitor)
        {
            return visitor.Visit((dynamic)this);
        }

        public Transaction(decimal amount, string description, DateTime date)
        {
            Amount = amount;
            Description = description;
            Date = date;
        }
    }
}
