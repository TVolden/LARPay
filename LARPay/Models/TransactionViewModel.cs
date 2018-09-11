using System;

namespace dk.lashout.LARPay.Web.Models
{
    public class TransactionViewModel
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
    }
}
