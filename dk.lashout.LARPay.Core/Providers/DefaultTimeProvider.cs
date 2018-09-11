using System;

namespace dk.lashout.LARPay.Core.Providers
{
    internal class DefaultTimeProvider : TimeProvider
    {
        public override DateTime UtcNow => DateTime.UtcNow;
    }
}