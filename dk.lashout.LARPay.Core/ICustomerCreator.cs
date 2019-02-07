using dk.lashout.LARPay.CustomerService.Forms;

namespace dk.lashout.LARPay.CustomerService
{
    public interface ICustomerCreator
    {
        void Create(ICustomer customer, int pincode);
    }
}
