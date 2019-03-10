using dk.lashout.LARPay.Administration;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Bank
{
    public interface IAccountFacade
    {
        Result Transfer(string from, string receipant, decimal amount, string description);
        Result SetCreditLimit(string customer, decimal creditLimit);
        IEnumerable<ITransaction> GetStatement(string customer);
        decimal GetBalance(string customer);
        decimal GetCreditLimit(string customer);
    }
}
