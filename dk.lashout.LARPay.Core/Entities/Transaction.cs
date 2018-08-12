namespace dk.lashout.LARPay.Core.Entities
{
    class Transaction
    {
        public Customer Recipient { get; set; }
        public Customer Sender { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
