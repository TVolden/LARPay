using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class TransferAmountCommand : ICommand
    {
        public Guid Benefactor { get; }
        public Guid Recipient { get; }
        public decimal Amount { get; }
        public string Description { get; }

        public TransferAmountCommand(Guid benefactor, Guid recipient, decimal amount, string description)
        {
            Benefactor = benefactor;
            Recipient = recipient;
            Amount = amount;
            Description = description;
        }

    }

    public sealed class TransferMoneyCommandHandler : ICommandHandler<TransferAmountCommand>
    {
        private readonly Messages _messages;
        private readonly ITimeProvider _timeProvider;

        public TransferMoneyCommandHandler(Messages messages, ITimeProvider timeProvider)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public Result Handle(TransferAmountCommand command)
        {
            if (!_messages.Dispatch(new HasAccountQuery(command.Benefactor)))
                return new Result("Benefactor account not found.");

            if (!_messages.Dispatch(new HasAccountQuery(command.Recipient)))
                return new Result("Recipient account not found.");

            var disposable = _messages.Dispatch(new GetDisposableAmountQuery(command.Benefactor));
            if (disposable < command.Amount)
                return new Result("Amount exceeds account balance.");

            var transferDate = _timeProvider.Now;

            _messages.Dispatch(new AmountTransferedEvent(command.Benefactor, command.Recipient, command.Amount, command.Description, transferDate));

            return new Result();
        }
    }
}
