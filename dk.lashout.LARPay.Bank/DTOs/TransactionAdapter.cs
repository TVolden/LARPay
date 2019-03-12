using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers;
using System;

namespace dk.lashout.LARPay.Bank
{
    class TransactionAdapter : ITransaction
    {
        private readonly Messages _messages;
        private readonly TransferDto _transfer;

        public TransactionAdapter(Messages messages, TransferDto transfer)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _transfer = transfer ?? throw new ArgumentNullException(nameof(transfer));
        }

        public decimal Amount => _transfer.Amount;

        public string Description => _transfer.Description;

        public string Recipient => new Lazy<string>(() => 
            _messages.Dispatch(new GetUsernameByCustomerIdQuery(_transfer.RecipientCustomerId)).ValueOrDefault("?")
            ).Value;

        public DateTime Date => _transfer.Date;
    }
}
