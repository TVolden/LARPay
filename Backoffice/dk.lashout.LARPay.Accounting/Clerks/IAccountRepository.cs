using System;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountRepository
    {
        Maybe<IAccount> GetAccount(Guid accountID);
        bool HasAccount(Guid accountID);
        void AddAccount(Guid accountID, IAccount account);
    }
}