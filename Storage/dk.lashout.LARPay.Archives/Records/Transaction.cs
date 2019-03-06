using System;
using dk.lashout.LARPay.Accounting.Forms;

namespace dk.lashout.LARPay.Archives.Records
{
    class Transaction : Accounting.Forms.Transaction
    {
        public Transaction(DateTime date, Guid otherAccount, decimal amount, string description)
        {
            Date = date;
            Amount = amount;
            Description = description;
            OtherAccount = otherAccount;
        }

        public string Description { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        public Guid OtherAccount { get; }
    }
}
