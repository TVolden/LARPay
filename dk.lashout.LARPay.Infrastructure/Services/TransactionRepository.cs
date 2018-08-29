using System.Collections.Generic;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Dictionary<Customer, List<Transaction>> _accounts;

        public TransactionRepository()
        {
            _accounts = new Dictionary<Customer, List<Transaction>>();
        }

        public void Add(Customer customer, Transaction transaction)
        {
            GetAccount(customer).Add(transaction);
        }

        public Transaction[] GetTransactions(Customer customer)
        {
            return GetAccount(customer).ToArray();
        }

        private List<Transaction> GetAccount(Customer customer)
        {
            if (!_accounts.ContainsKey(customer))
                _accounts.Add(customer, new List<Transaction>());

            return _accounts[customer];
        }
    }
}
