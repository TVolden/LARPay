using System;

namespace dk.lashout.LARPay.Customers.Forms
{
    public interface ICustomer
    {
        string Name { get; }
        string Identifier { get; }
        Guid Account { get; }
    }
}
