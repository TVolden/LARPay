using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.Accounting.Service
{
    public class AccountService : IBalance, IStatement, ITransfer, IAccountCreator
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public decimal Balance(Guid account)
        {
            if (_repository.AccountExists(account))
                return _repository.GetTransactions(account).Sum(t => t.Amount);
            return -1;
        }

        public void Create(Guid account)
        {
            if (_repository.AccountExists(account))
                _repository.CreateAccount(account);
        }

        public Guid GenerateID()
        {
            Guid returnValue;
            do
            {
                returnValue = Guid.NewGuid();
            }
            while (!_repository.AccountExists(returnValue));

            return returnValue;
        }

        public IEnumerable<ITransaction> Statement(Guid account)
        {
            if (_repository.AccountExists(account))
                return _repository.GetTransactions(account);
            return new ITransaction[] { };
        }

        public void Transfer(Guid fromAccount, Guid toAccount, decimal amount, string description)
        {
            if (_repository.AccountExists(fromAccount) && _repository.AccountExists(toAccount))
            {
                _repository.SaveTransaction(toAccount, fromAccount, amount, description);
                _repository.SaveTransaction(fromAccount, toAccount, -amount, description);
            }
        }
    }
}
