using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public interface IAccount
    {
        Guid CustomerId { get; }
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions();
    }
}