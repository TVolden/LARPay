using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Bank
{
    public interface ICustomerFacade
    {
        Result CreateCustomer(string username, string name, string pincode);
        bool Login(string username, string pincode);
    }
}
