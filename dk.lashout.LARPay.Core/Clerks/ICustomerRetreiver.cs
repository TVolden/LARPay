using dk.lashout.LARPay.CustomerService.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerService.Clerks
{
    public interface ICustomerRetreiver
    {
        Maybe<ICustomer> GetCustomer(string identifier);
    }
}
