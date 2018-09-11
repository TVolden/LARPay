using System.Collections.Generic;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Shared;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Dictionary<ICustomer, List<ITransaction>> _accounts;

        public TransactionRepository()
        {
            _accounts = new Dictionary<ICustomer, List<ITransaction>>();
        }

        public void Add(ICustomer customer, ITransaction transaction)
        {
            GetAccount(customer).Add(transaction);
        }

        public ITransaction[] GetTransactions(ICustomer customer)
        {
            return GetAccount(customer).ToArray();
        }

        private List<ITransaction> GetAccount(ICustomer customer)
        {
            if (!_accounts.ContainsKey(customer))
                _accounts.Add(customer, new List<ITransaction>());

            return _accounts[customer];
        }
    }
}
