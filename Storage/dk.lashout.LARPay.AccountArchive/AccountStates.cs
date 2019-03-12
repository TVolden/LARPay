using dk.lashout.LARPay.AccountArchive.Applications;
using dk.lashout.MaybeType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.AccountArchive
{
    public class AccountStates
    {
        private readonly Dictionary<Guid, Account> _accounts;

        public AccountStates()
        {
            _accounts = new Dictionary<Guid, Account>();
        }

        public void AddAccount(Guid accountId, Account account)
        {
            if (!HasAccount(accountId))
                _accounts.Add(accountId, account);
        }

        public bool HasAccount(Guid id)
        {
            return _accounts.ContainsKey(id);
        }

        public Maybe<Account> GetAccount(Guid accountId)
        {
            if (HasAccount(accountId))
                return new Maybe<Account>(_accounts[accountId]);
            return new Maybe<Account>();
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

        public Maybe<decimal> GetBalance(Guid accountId)
        {
            var account = GetAccount(accountId);
            if (!account.HasValue())
                return new Maybe<decimal>();

            return new Maybe<decimal>(account.ValueOrDefault(null).GetTransactions().Sum(t => t.Amount));
        }
    }
}
