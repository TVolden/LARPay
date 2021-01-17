using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Accounting.Exceptions;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class TransferAmountCommand : ICommand
    {
        public Guid ProcessId => new Guid("50118802-69B6-4445-AC35-7BBACE2D4F3D");

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

        public void Handle(TransferAmountCommand command)
        {
            if (command.Amount < 1)
                throw new AmountRejectedException(command.Amount, "Illegal amount.");

            if (!_messages.Dispatch(new HasAccountQuery(command.Benefactor)))
                throw new AccountNotFoundException(command.Benefactor, "Benefactor account not found.");
            
            if (!_messages.Dispatch(new HasAccountQuery(command.Recipient)))
                throw new AccountNotFoundException(command.Recipient, "Recipient account not found.");

            var disposable = _messages.Dispatch(new GetDisposableAmountQuery(command.Benefactor));
            if (disposable < command.Amount)
                throw new AmountRejectedException(disposable, "Amount exceeds disposable amount.");

            _messages.Dispatch(new AmountTransferedEvent(_timeProvider.Now, command.ProcessId, command.Benefactor, command.Recipient, command.Amount, command.Description));
        }
    }
}
