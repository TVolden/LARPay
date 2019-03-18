using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class AmountTransferedEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventDate { get; }
        public Guid ProcessId { get; }

        public Guid BenefactorAccountId { get; }
        public Guid ReceipientAccountId { get; }
        public decimal Amount { get; }
        public string Description { get; }

        public AmountTransferedEvent(DateTime eventTime, Guid processId, Guid benefactor, Guid receipient, decimal amount, string description)
        {
            BenefactorAccountId = benefactor;
            ReceipientAccountId = receipient;
            Amount = amount;
            Description = description;
            EventDate = eventTime;
            ProcessId = processId;
        }
    }
}
