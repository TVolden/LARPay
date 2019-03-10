using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public interface IAccount
    {
        decimal creditLimit { get; set; }
        Guid CustomerId { get; }
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions();
    }
}