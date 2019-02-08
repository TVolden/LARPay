using System;

namespace dk.lashout.LARPay.Accounting
{
    public interface IAccountCreator
    {
        void Create(Guid guid);
    }
}
