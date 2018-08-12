using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        bool Login(string identity, int pincode);
    }
}
