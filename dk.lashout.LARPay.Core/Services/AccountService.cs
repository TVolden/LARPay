using System.Linq;
using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public class AccountService : IAccountService

    {
        private readonly ITransactionRepository _repository;

        public AccountService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void Transfer(Customer sender, Customer recipient, double amount, string description)
        {
            var debit = new Transaction()
            {
                Amount = -amount,
                Description = description,
                Linked = recipient
            };

            var credit = new Transaction()
            {
                Amount = amount,
                Description = description,
                Linked = sender
            };

            _repository.Add(sender, debit);
            _repository.Add(recipient, credit);
        }

        public double Balance(Customer customer)
        {
           return _repository.GetTransactions(customer).Sum(t => t.Amount);
        }
    }
}