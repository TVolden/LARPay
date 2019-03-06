using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.MaybeType;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class Repository : IAccountRepository
    {
        private readonly Dictionary<Guid, IAccount> _accounts;

        public Repository()
        {
            _accounts = new Dictionary<Guid, IAccount>();
        }

        public void AddAccount(Guid id, IAccount account)
        {
            if (!HasAccount(id))
                _accounts.Add(id, account);
        }

        public bool HasAccount(Guid id)
        {
            return _accounts.ContainsKey(id);
        }

        public Maybe<IAccount> GetAccount(Guid id)
        {
            if (HasAccount(id))
                return new Maybe<IAccount>(_accounts[id]);
            return new Maybe<IAccount>();
        }
    }
}
