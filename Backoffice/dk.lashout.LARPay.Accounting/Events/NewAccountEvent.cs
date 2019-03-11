using dk.lashout.LARPay.Administration;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class NewAccountEvent : IEvent
    {
        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public NewAccountEvent(Guid AccountId, Guid CustomerId)
        {
            this.AccountId = AccountId;
            this.CustomerId = CustomerId;
        }
    }
}
