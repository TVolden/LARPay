using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.Customers.Clerks
{
    public interface ICustomerRetreiver
    {
        Maybe<ICustomer> GetCustomer(string identifier);
    }
}
