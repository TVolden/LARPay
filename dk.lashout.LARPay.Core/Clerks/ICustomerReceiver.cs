using System;

namespace dk.lashout.LARPay.Customers.Clerks
{
    public interface ICustomerReceiver
    {
        void SaveCustomer(string identifier, string name, Guid account, int pincode);
    }
}
