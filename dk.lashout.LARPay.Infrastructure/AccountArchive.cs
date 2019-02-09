using System.Collections.Generic;
using dk.lashout.LARPay.Archives.Records;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Archives
{
    public class AccountArchive : IAccountRepository
    {
        private readonly Dictionary<Guid, List<Transaction>> _accounts;
        private readonly ITimeProvider timeProvider;

        public AccountArchive(ITimeProvider timeProvider)
        {
            _accounts = new Dictionary<Guid, List<Transaction>>();
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public bool AccountExists(Guid account)
        {
            return _accounts.ContainsKey(account);
        }

        public void Create(Guid guid)
        {
            _accounts.Add(guid, new List<Transaction>());
        }

        public void CreateAccount(Guid account)
        {
            _accounts.Add(account, new List<Transaction>());
        }

        public IEnumerable<ITransaction> GetTransactions(Guid account)
        {
            return _accounts[account];
        }

        public void SaveTransaction(Guid account, Guid otherAccount, decimal amount, string description)
        {
            _accounts[account].Add(new Transaction(timeProvider.Now, otherAccount, amount, description));
        }
    }
}
