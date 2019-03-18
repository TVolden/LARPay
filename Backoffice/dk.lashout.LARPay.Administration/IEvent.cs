using System;

namespace dk.lashout.LARPay.Administration
{
    public interface IEvent
    {
        DateTime EventDate { get; }
        int Version { get; }
        Guid ProcessId { get; }
    }
}
