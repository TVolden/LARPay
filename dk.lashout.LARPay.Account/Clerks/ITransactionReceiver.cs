using System;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface ITransactionReceiver
    {
        void SaveTransaction(Guid account, decimal amount, string description);
    }
}