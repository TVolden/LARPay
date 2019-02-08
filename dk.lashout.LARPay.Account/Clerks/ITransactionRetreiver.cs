using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface ITransactionRetreiver
    {
        IEnumerable<ITransaction> GetTransactions(Guid account);
    }
}