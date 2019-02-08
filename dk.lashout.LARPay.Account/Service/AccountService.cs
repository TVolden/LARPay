using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.Accounting.Service
{
    public class AccountService : IBalance, IStatement, ITransfer
    {
        private readonly IAccountChecker accountChecker;
        private readonly ITransactionRetreiver retreiver;
        private readonly ITransactionReceiver storer;

        public AccountService(IAccountChecker accountChecker, ITransactionRetreiver retreiver, ITransactionReceiver storer)
        {
            this.accountChecker = accountChecker ?? throw new System.ArgumentNullException(nameof(accountChecker));
            this.retreiver = retreiver ?? throw new System.ArgumentNullException(nameof(retreiver));
            this.storer = storer ?? throw new System.ArgumentNullException(nameof(storer));
        }

        public decimal Balance(Guid account)
        {
            return retreiver.GetTransactions(account).Sum(t => t.Amount);
        }

        public IEnumerable<ITransaction> Statement(Guid account)
        {
            return retreiver.GetTransactions(account);
        }

        public void Transfer(Guid fromAccount, Guid toAccount, decimal amount, string description)
        {
            if (accountChecker.AccountExists(fromAccount) && accountChecker.AccountExists(toAccount))
            {
                storer.SaveTransaction(toAccount, amount, description);
                storer.SaveTransaction(fromAccount, -amount, description);
            }
        }
    }
}
