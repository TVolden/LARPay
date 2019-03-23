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

        public AmountTransferedEvent(DateTime eventDate, Guid processId, Guid benefactorAccountId, Guid receipientAccountId, decimal amount, string description)
        {
            BenefactorAccountId = benefactorAccountId;
            ReceipientAccountId = receipientAccountId;
            Amount = amount;
            Description = description;
            EventDate = eventDate;
            ProcessId = processId;
        }
    }
}
