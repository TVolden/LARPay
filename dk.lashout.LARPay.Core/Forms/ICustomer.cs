using System;

namespace dk.lashout.LARPay.Customers.Forms
{
    public interface ICustomer
    {
        string Name { get; }
        string Identity { get; }
        Guid Account { get; }
    }
}
