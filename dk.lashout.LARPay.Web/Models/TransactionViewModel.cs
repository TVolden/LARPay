using System;

namespace dk.lashout.LARPay.Web.Models
{
    public class TransferViewModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
    }
}
