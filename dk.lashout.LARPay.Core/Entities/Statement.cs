namespace dk.lashout.LARPay.Core.Entities
{
    class Statement
    {
        public Customer Customer { get; set; }
        public Transaction[] Transactions { get; set; }
    }
}
