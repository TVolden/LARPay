using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.Accounting.Service
{
    public class AccountService : IBalance, IStatement, ITransfer
    {
        private readonly ITransactionRetreiver retreiver;
        private readonly ITransactionStorer storer;

        public AccountService(ITransactionRetreiver retreiver, ITransactionStorer storer)
        {
            this.retreiver = retreiver ?? throw new System.ArgumentNullException(nameof(retreiver));
            this.storer = storer ?? throw new System.ArgumentNullException(nameof(storer));
        }

        public decimal Balance(long account)
        {
            return retreiver.GetTransactions(account).Sum(t => t.Amount);
        }

        public IEnumerable<ITransaction> Statement(long account)
        {
            return retreiver.GetTransactions(account);
        }

        public void Transfer(long fromAccount, long toAccount, decimal amount, string description)
        {
            storer.SaveTransaction(fromAccount, -amount, description);
            storer.SaveTransaction(toAccount, amount, description);
        }
    }
}
