using System;

namespace dk.lashout.LARPay.Administration
{
    public interface IEvent
    {
        DateTime EventTime { get; }
        int Version { get; }
        Guid ProcessId { get; }
    }
}
