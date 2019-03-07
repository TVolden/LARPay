using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Clerks
{
    public interface ICustomerRepository
    {
        Maybe<Guid> GetCustomerId(string username);
        Maybe<ICustomer> GetCustomer(Guid accountId);
        bool HasCustomer(Guid accountId);
        void AddCustomer(Guid accountId, ICustomer customer);
        bool Authorize(string username, string pincode);
    }
}
