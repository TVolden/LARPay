using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ITransactionRepository
    {
        void Add(Customer customer, Transaction transaction);
        Transaction[] GetTransactions(Customer customer);
    }
}