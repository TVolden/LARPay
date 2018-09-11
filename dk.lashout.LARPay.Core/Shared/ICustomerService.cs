using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ICustomerService
    {
        void Create(ICustomer customer, int pincode);
        ICustomer GetCustomer(string identity);
        bool HasCustomer(string identity);
        bool Login(string identity, int pincode);
    }
}