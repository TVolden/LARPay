using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers
{
    public interface ICustomerGetter
    {
        Maybe<string> GetCustomer(Guid account);
    }
}
