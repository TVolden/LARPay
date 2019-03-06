using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Applications
{
    class TransferDtoVisitor : ITransferVisitor<TransferDto>
    {
        private readonly Messages _messages;
        private readonly Guid _accountCustomerId;

        public TransferDtoVisitor(Messages messages, Guid accountCustomerId)
        {
            _messages = messages;
            _accountCustomerId = accountCustomerId;
        }

        public TransferDto Visit(Debit debit)
        {
            var customerId = _messages.Dispatch(new GetCustomerIdQuery(debit.Recipient));
            return new TransferDto(_accountCustomerId, customerId, debit.Amount, debit.Description);
        }

        public TransferDto Visit(Credit debit)
        {
            var customerId = _messages.Dispatch(new GetCustomerIdQuery(debit.Benefactor));
            return new TransferDto(customerId, _accountCustomerId, debit.Amount, debit.Description);
        }
    }
}
