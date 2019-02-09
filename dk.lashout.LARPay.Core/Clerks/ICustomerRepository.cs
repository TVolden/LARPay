using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Clerks
{
    public interface ICustomerRepository
    {
        void SaveCustomer(string identifier, string name, Guid account, int pincode);
        Maybe<ICustomer> GetCustomer(string identifier);
        bool Authorize(string identifier, int pincode);
        Maybe<ICustomer> GetCustomer(Guid account);
    }
}
