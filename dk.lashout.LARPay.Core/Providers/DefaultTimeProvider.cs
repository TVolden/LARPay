using System;

namespace dk.lashout.LARPay.Core.Providers
{
    internal class UtcTimeProvider : ITimeProvider
    {
        public override DateTime UtcNow => DateTime.UtcNow;
    }
}