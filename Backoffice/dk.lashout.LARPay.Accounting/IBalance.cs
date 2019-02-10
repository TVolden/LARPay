using System;

namespace dk.lashout.LARPay.Accounting
{
    public interface IBalance
    {
        decimal Balance(Guid account);
    }
}
