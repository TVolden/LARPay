using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ICustomerRepository
    {
        void Insert(Customer customer);
        Customer GetByIdentity(string identity);
    }
}
