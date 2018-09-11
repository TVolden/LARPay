using System.Linq;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Providers;
using dk.lashout.LARPay.Core.Shared;

namespace dk.lashout.LARPay.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _repository;

        public AccountService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void Transfer(ICustomer sender, ICustomer recipient, double amount, string description)
        {
            var debit = new Transaction()
            {
                Amount = -amount,
                Description = description,
                Linked = recipient,
                Date = TimeProvider.Current.UtcNow
            };

            var credit = new Transaction()
            {
                Amount = amount,
                Description = description,
                Linked = sender,
                Date = TimeProvider.Current.UtcNow
            };

            _repository.Add(sender, debit);
            _repository.Add(recipient, credit);
        }

        public double Balance(ICustomer customer)
        {
           return _repository.GetTransactions(customer).Sum(t => t.Amount);
        }

        public ITransaction[] Statement(ICustomer customer)
        {
            return _repository.GetTransactions(customer);
        }
    }
}