using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class CreditLimitChangedEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventDate { get; }
        public Guid ProcessId { get; }

        public Guid AccountId { get; }
        public decimal CreditLimit { get; }

        public CreditLimitChangedEvent(DateTime eventTime, Guid processId, Guid accountId, decimal creditLimit)
        {
            EventDate = eventTime;
            ProcessId = processId;
            AccountId = accountId;
            CreditLimit = creditLimit;
        }
    }
}
