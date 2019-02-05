using System;
using dk.lashout.LARPay.Accounting.Forms;

namespace dk.lashout.LARPay.Archives.Records
{
    class Transaction : ITransaction
    {
        public Transaction(DateTime date, decimal amount, string description)
        {
            Date = date;
            Amount = amount;
            Description = description;
        }

        public string Description { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
    }
}
