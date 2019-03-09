using System;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public sealed class TransferDto
    {
        public Guid BenefactorCustomerId { get; }
        public Guid RecipientCustomerId { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Date { get; }

        public TransferDto(Guid benefactorCustomerId, Guid recipientCustomerId, decimal amount, string description, DateTime date)
        {
            BenefactorCustomerId = benefactorCustomerId;
            RecipientCustomerId = recipientCustomerId;
            Amount = amount;
            Description = description;
            Date = date;
        }
    }
}
