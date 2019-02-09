using System;

namespace dk.lashout.LARPay.Bank
{
    public interface ITransaction
    {
        decimal Amount { get; }
        string Description { get; }
        string Recipient { get; }
        DateTime Date { get; }
    }
}
