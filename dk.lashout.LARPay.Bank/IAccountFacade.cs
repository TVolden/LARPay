using dk.lashout.LARPay.Accounting.Forms;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Bank
{
    public interface IAccountFacade
    {
        void Transfer(string from, string receipant, decimal amount, string description);
        IEnumerable<ITransaction> Statement(string customer);
        decimal Balance(string customer);
    }
}
