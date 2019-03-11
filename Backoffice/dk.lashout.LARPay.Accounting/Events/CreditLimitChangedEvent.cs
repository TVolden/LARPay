using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class CreditLimitChangedEvent : IEvent
    {
        public Guid AccountId { get; }
        public decimal CreditLimit { get; }

        public CreditLimitChangedEvent(Guid accountId, decimal creditLimit)
        {
            AccountId = accountId;
            CreditLimit = creditLimit;
        }
    }
}
