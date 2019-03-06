using System;

namespace dk.lashout.LARPay.Accounting.Forms
{
    public sealed class TransferDto
    {
        public Guid BenefactorCustomerId { get; }
        public Guid RecipientCustomerId { get; }
        public double Amount { get; }
        public string Description { get; }

        public TransferDto(Guid benefactorCustomerId, Guid recipientCustomerId, double amount, string description)
        {
            BenefactorCustomerId = benefactorCustomerId;
            RecipientCustomerId = recipientCustomerId;
            Amount = amount;
            Description = description;
        }
    }
}
