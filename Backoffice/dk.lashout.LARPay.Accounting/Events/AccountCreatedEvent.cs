﻿using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class AccountCreatedEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventDate { get; }
        public Guid ProcessId { get; }

        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public AccountCreatedEvent(DateTime eventDate, Guid processId, Guid accountId, Guid customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
            EventDate = eventDate;
            ProcessId = processId;
        }
    }
}
