using System;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountChecker
    {
        bool AccountExists(Guid account);
    }
}
