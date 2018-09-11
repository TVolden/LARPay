using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Shared
{
    public interface ICustomerRepository
    {
        ICustomer GetByIdentity(string identity);
        void Insert(ICustomer customer, int pincode);
        bool Authenticate(ICustomer customer, int pincode);
    }
}
