using dk.lashout.LARPay.Accountance.Records;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accountance.Clerks
{
    public interface ITransactionRetreiver
    {
        IEnumerable<ITransaction> GetTransactions(long accountId);
    }
}