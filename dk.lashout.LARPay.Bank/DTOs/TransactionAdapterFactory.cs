using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Bank
{
    public class TransactionAdapterFactory
    {
        private readonly Messages _messages;

        public TransactionAdapterFactory(Messages messages)
        {
            _messages = messages ?? throw new System.ArgumentNullException(nameof(messages));
        }

        public ITransaction CreateTransactionAdapter(TransferDto transferDto)
        {
            return new TransactionAdapter(_messages, transferDto);
        }
    }
}
