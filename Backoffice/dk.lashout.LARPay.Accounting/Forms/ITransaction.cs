using System;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public interface ITransaction
    {
        Guid OtherAccount { get; }
        string Description { get; }
        decimal Amount { get; }
        DateTime Date { get; }
    }
}
