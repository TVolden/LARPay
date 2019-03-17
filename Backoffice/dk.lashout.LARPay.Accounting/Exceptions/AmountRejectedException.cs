using System;

namespace dk.lashout.LARPay.Accounting.Exceptions
{
    public class AmountRejectedException : Exception
    {
        public decimal Disposable { get; }

        public AmountRejectedException(decimal disposable, string message) : base(message)
        {
            Disposable = disposable;
        }
    }
}
