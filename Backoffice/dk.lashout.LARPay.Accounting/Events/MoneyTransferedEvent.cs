using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Events
{
    public class MoneyTransferedEvent : IEvent
    {
        public Guid BenefactorAccountId { get; }
        public Guid ReceipientAccountId { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Date { get; }

        public MoneyTransferedEvent(Guid benefactor, Guid receipient, decimal amount, string description, DateTime date)
        {
            BenefactorAccountId = benefactor;
            ReceipientAccountId = receipient;
            Amount = amount;
            Description = description;
            Date = date;
        }
    }
}
