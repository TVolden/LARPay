using System;

namespace dk.lashout.LARPay.Clock
{
    public  interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
