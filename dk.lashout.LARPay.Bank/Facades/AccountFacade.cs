using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Customers;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Bank
{
    public class AccountFacade : IAccountFacade
    {
        private readonly IAccountGetter _accountGetter;
        private readonly ITransfer _transfer;
        private readonly IBalance _balance;
        private readonly IStatement _statement;
        private readonly TransactionAdapterFactory _transactionAdapterFactory;

        public AccountFacade(IAccountGetter accountGetter, ITransfer transfer, IBalance balance, IStatement statement, TransactionAdapterFactory transactionAdapterFactory)
        {
            _accountGetter = accountGetter ?? throw new ArgumentNullException(nameof(accountGetter));
            _transfer = transfer ?? throw new ArgumentNullException(nameof(transfer));
            _balance = balance ?? throw new ArgumentNullException(nameof(balance));
            _statement = statement ?? throw new ArgumentNullException(nameof(statement));
            _transactionAdapterFactory = transactionAdapterFactory ?? throw new ArgumentNullException(nameof(transactionAdapterFactory));
        }

        public Guid getAccount(string customer)
        {
            var account = _accountGetter.GetAccount(customer);
            if (!account.HasValue())
                throw new AccountNotFoundException(customer);
            return account.ValueOrDefault(Guid.Empty);
        }

        public decimal Balance(string customer)
        {
            return _balance.Balance(getAccount(customer));
        }

        public IEnumerable<ITransaction> Statement(string customer)
        {
            foreach(var transaction in _statement.Statement(getAccount(customer)))
            {
                yield return _transactionAdapterFactory.CreateTransactionAdapter(transaction);
            }
        }

        public void Transfer(string from, string receipant, decimal amount, string description)
        {
            var fromAccount = getAccount(from);
            var toAccount = getAccount(receipant);

            _transfer.Transfer(fromAccount, toAccount, amount, description);
        }
    }
}
