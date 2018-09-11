using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Shared
{
    public interface ITransactionRepository
    {
        void Add(ICustomer customer, ITransaction transaction);
        ITransaction[] GetTransactions(ICustomer customer);
    }
}