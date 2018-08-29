namespace dk.lashout.LARPay.Core.Entities
{
    public class Transaction
    {
        public Customer Linked { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
