using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.AccountArchive.Applications
{
    public class Account
    {
        public Guid CustomerId { get; }
        public decimal creditLimit { get; set; }

        private List<Transaction> passbook;

        public Account(Guid customerId)
        {
            passbook = new List<Transaction>();
            creditLimit = 0;
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
