using System;

namespace dk.lashout.LARPay.Accountance.Records
{
    public interface ITransaction
    {
        string Description { get; }
        decimal Amount { get; }
        DateTime Date { get; }
    }
}
