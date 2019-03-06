using dk.lashout.LARPay.Customers;
using System;

namespace dk.lashout.LARPay.Bank
{
    class TransactionAdapter : ITransaction
    {
        private readonly ICustomerGetter customerGetter;
        private readonly Accounting.Forms.Transaction transaction;

        public TransactionAdapter(ICustomerGetter customerGetter, Accounting.Forms.Transaction transaction)
        {
            this.customerGetter = customerGetter ?? throw new ArgumentNullException(nameof(customerGetter));
            this.transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public decimal Amount => transaction.Amount;

        public string Description => transaction.Description;

        public string Recipient => customerGetter.GetCustomer(transaction.OtherAccount).ValueOrDefault(String.Empty);

        public DateTime Date => transaction.Date;
    }
}
