using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class AccountCreatedEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }

        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public AccountCreatedEvent(DateTime eventTime, Guid processId, Guid accountId, Guid customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
            EventTime = eventTime;
            ProcessId = processId;
        }
    }
}
