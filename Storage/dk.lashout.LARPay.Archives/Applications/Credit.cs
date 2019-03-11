using System;

namespace dk.lashout.LARPay.Archives.Applications
{
    public class Credit : Transaction
    {
        public Guid Benefactor { get; }

        public Credit(Guid benefactor, decimal amount, string description, DateTime date) : base(amount, description, date)
        {
            Benefactor = benefactor;
        }
    }
}
