using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.MaybeType;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Archives
{
    public class AccountArchive : IAccountRepository
    {
        private readonly Dictionary<Guid, IAccount> _accounts;

        public AccountArchive()
        {
            _accounts = new Dictionary<Guid, IAccount>();
        }

        public void AddAccount(Guid accountId, IAccount account)
        {
            if (!HasAccount(accountId))
                _accounts.Add(accountId, account);
        }

        public bool HasAccount(Guid id)
        {
            return _accounts.ContainsKey(id);
        }

        public Maybe<IAccount> GetAccount(Guid accountId)
        {
            if (HasAccount(accountId))
                return new Maybe<IAccount>(_accounts[accountId]);
            return new Maybe<IAccount>();
        }

        public Maybe<Guid> GetAccountId(Guid customerId)
        {
            foreach (var pair in _accounts)
            {
                if (pair.Value.CustomerId == customerId)
                    return new Maybe<Guid>(pair.Key);
            }
            return new Maybe<Guid>();
        }
    }
}
