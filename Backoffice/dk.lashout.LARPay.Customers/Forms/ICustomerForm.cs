using System;

namespace dk.lashout.LARPay.Customers.Forms
{
    public interface ICustomerForm
    {
        Guid Customer { get; }
        DateTime Date { get; }
    }
}
