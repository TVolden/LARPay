using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class Account : IAccount
    {
        public Guid CustomerId { get; }
        private List<Transaction> passbook;

        public Account(Guid customerId)
        {
            passbook = new List<Transaction>();
            CustomerId = customerId;
        }

        public void AddTransaction(Transaction transaction)
        {
            passbook.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return passbook;
        }
    }
}
