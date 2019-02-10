using System;

namespace dk.lashout.LARPay.Accounting
{
    public interface ITransfer
    {
        void Transfer(Guid fromAccount, Guid toAccount, decimal amount, string description);
    }
}
