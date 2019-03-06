using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public interface IAccount
    {
        Guid Customer { get; }
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions();
    }
}