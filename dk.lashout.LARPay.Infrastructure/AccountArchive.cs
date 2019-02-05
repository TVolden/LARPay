using System.Collections.Generic;
using dk.lashout.LARPay.Archives.Records;
using dk.lashout.LARPay.Accountance.Clerks;
using dk.lashout.LARPay.Accountance.Records;
using dk.lashout.LARPay.Clock;

namespace dk.lashout.LARPay.Archives
{
    public class TransactionRepository : ITransactionRetreiver, ITransactionStorer
    {
        private readonly Dictionary<long, List<Transaction>> _accounts;
        private readonly ITimeProvider timeProvider;

        public TransactionRepository(ITimeProvider timeProvider)
        {
            _accounts = new Dictionary<long, List<Transaction>>();
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public IEnumerable<ITransaction> GetTransactions(long account)
        {
            return _accounts.GetValueOrDefault(account);
        }

        public void SaveTransaction(long account, decimal amount, string description)
        {
            if (!_accounts.ContainsKey(account))
                _accounts.Add(account, new List<Transaction>());

            _accounts[account].Add(new Transaction(timeProvider.Now, amount, description));
        }
    }
}
