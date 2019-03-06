using dk.lashout.LARPay.Customers;

namespace dk.lashout.LARPay.Bank
{
    public class TransactionAdapterFactory
    {
        private readonly ICustomerGetter _customerGetter;

        public TransactionAdapterFactory(ICustomerGetter customerGetter)
        {
            _customerGetter = customerGetter ?? throw new System.ArgumentNullException(nameof(customerGetter));
        }

        public ITransaction CreateTransactionAdapter(Accounting.Forms.Transaction transaction)
        {
            return new TransactionAdapter(_customerGetter, transaction);
        }
    }
}
