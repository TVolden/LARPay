using System;

namespace dk.lashout.LARPay.Accounting
{
    public interface IAccountCreator
    {
        Guid GenerateID();
        void Create(Guid account);
    }
}
