using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountRepository
    {
        bool AccountExists(Guid account);
        IEnumerable<ITransaction> GetTransactions(Guid account);
        void SaveTransaction(Guid account, Guid otherAccount, decimal amount, string description);
        void CreateAccount(Guid account);
    }
}
