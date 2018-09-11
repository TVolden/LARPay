using System;

namespace dk.lashout.LARPay.Core.Entities
{
    public interface ITransaction
    {
        ICustomer Linked { get; }
        string Description { get; }
        double Amount { get; }
        DateTime Date { get; }
    }
}
