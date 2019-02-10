using System;

namespace dk.lashout.LARPay.Clock
{
    public class UtcTime : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
