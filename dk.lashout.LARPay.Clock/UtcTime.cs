using System;

namespace dk.lashout.LARPay.Clock
{
    class UtcTime : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
