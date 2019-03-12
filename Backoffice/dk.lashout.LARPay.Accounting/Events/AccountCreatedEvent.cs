using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class AccountCreatedEvent : IEvent
    {
        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public AccountCreatedEvent(Guid AccountId, Guid CustomerId)
        {
            this.AccountId = AccountId;
            this.CustomerId = CustomerId;
        }
    }
}
