using dk.lashout.LARPay.Customers.Forms;

namespace dk.lashout.LARPay.Customers
{
    public interface ICustomerCreator
    {
        void Create(ICustomer customer, int pincode);
        bool CustomerExists(string identifier);
    }
}
