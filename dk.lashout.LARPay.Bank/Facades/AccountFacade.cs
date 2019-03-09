using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Bank
{
    public class AccountFacade : IAccountFacade
    {
        private readonly Messages _messages;
        private readonly TransactionAdapterFactory _transactionAdapterFactory;

        public AccountFacade(Messages message, TransactionAdapterFactory transactionAdapterFactory)
        {
            _messages = message ?? throw new ArgumentNullException(nameof(message));
            _transactionAdapterFactory = transactionAdapterFactory ?? throw new ArgumentNullException(nameof(transactionAdapterFactory));
        }

        public Guid getAccount(string username)
        {
            var customerId = _messages.Dispatch(new GetCustomerIdByUsernameQuery(username));
            if (!customerId.HasValue())
                throw new CustomerNotFoundException(username);

            var accountId = _messages.Dispatch(new GetAccountIdByCustomerIdQuery(customerId.ValueOrDefault(Guid.Empty)));
            if (!accountId.HasValue())
                throw new CustomerNotFoundException(username);

            return accountId.ValueOrDefault(Guid.Empty);
        }

        public decimal Balance(string username)
        {
            var account = getAccount(username);
            return _messages.Dispatch(new GetBalanceQuery(account));
        }

        public IEnumerable<ITransaction> Statement(string username)
        {
            var account = getAccount(username);
            var transactions = _messages.Dispatch(new GetStatementQuery(account));
            foreach(var transaction in transactions)
            {
                yield return _transactionAdapterFactory.CreateTransactionAdapter(transaction);
            }
        }

        public void Transfer(string from, string receipant, decimal amount, string description)
        {
            var fromAccount = getAccount(from);
            var toAccount = getAccount(receipant);

            var result = _messages.Dispatch(new TransferMoneyCommand(fromAccount, toAccount, amount, description));

            if (!result.Success)
                throw new Exception(result.ErrorMessage);
        }
    }
}
