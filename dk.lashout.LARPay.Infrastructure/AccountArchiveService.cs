using System.Collections.Generic;
using dk.lashout.LARPay.Archives.Records;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Clock;
using System;
using dk.lashout.LARPay.Accounting;

namespace dk.lashout.LARPay.Archives
{
    public class AccountArchiveService : ITransactionRetreiver, ITransactionReceiver, IAccountChecker, IAccountCreator
    {
        private readonly Dictionary<Guid, List<Transaction>> _accounts;
        private readonly ITimeProvider timeProvider;
        private readonly IAccountArchive accountArchive;

        public AccountArchiveService(ITimeProvider timeProvider, IAccountArchive accountArchive)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.accountArchive = accountArchive ?? throw new ArgumentNullException(nameof(accountArchive));
        }

        public bool AccountExists(Guid account)
        {
            return accountArchive.Contains(account);
        }

        public void Create(Guid guid)
        {
            _accounts.Add(guid, new List<Transaction>());
        }

        public IEnumerable<ITransaction> GetTransactions(Guid account)
        {
            return accountArchive[account];
        }

        public void SaveTransaction(Guid account, decimal amount, string description)
        {
            if (!accountArchive.Contains(account))
                _accounts.Add(account, new List<Transaction>());

            accountArchive.Add(new Transaction(timeProvider.Now, amount, description));
        }
    }
}
