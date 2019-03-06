using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class Account : IAccount
    {
        public Guid Customer { get; }
        private List<Transaction> passbook;

        public Account(Guid customer)
        {
            passbook = new List<Transaction>();
            Customer = customer;
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
