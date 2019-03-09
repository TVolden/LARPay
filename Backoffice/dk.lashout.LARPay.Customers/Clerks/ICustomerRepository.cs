using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Clerks
{
    public interface ICustomerRepository
    {
        Maybe<Guid> GetCustomerId(string username);
        Maybe<ICustomer> GetCustomer(Guid customerId);
        bool HasCustomer(Guid customerId);
        void AddCustomer(Guid customerId, ICustomer customer);
        bool Authorize(string username, string pincode);
    }
}
