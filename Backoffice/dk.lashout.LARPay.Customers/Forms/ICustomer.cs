using System;

namespace dk.lashout.LARPay.Customers.Forms
{
    public interface ICustomer
    {
        string Username { get; }
        string Pincode { get; }
        string Name { get; }
    }
}
