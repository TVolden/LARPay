using System;

namespace dk.lashout.LARPay.Administration
{
    public interface ICommand
    {
        Guid ProcessId { get; }
    }
}
