using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Applications
{
    public class TransferDtoVisitor : ITransferVisitor<TransferDto>
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
            var customerId = _messages.Dispatch(new GetCustomerIdByAccountIdQuery(debit.Recipient));
            return new TransferDto(_accountCustomerId, customerId, debit.Amount, debit.Description, debit.Date);
        }

        public TransferDto Visit(Credit credit)
        {
            var customerId = _messages.Dispatch(new GetCustomerIdByAccountIdQuery(credit.Benefactor));
            return new TransferDto(customerId, _accountCustomerId, credit.Amount, credit.Description, credit.Date);
        }
    }
}
