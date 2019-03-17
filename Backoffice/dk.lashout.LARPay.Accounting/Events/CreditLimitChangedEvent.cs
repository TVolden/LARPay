using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class CreditLimitChangedEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }

        public Guid AccountId { get; }
        public decimal CreditLimit { get; }

        public CreditLimitChangedEvent(DateTime eventTime, Guid processId, Guid accountId, decimal creditLimit)
        {
            EventTime = eventTime;
            ProcessId = processId;
            AccountId = accountId;
            CreditLimit = creditLimit;
        }
    }
}
