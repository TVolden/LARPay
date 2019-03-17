using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Accounting.Exceptions;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class OpenAccountCommand : ICommand
    {
        public Guid ProcessId => new Guid("77DB32F7-1272-4132-AB2C-CC311314CE11");

        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public OpenAccountCommand(Guid accountId, Guid customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
        }
    }

    public sealed class OpenAccountCommandHandler : ICommandHandler<OpenAccountCommand>
    {
        private readonly Messages _messages;
        private readonly ITimeProvider _timeProvider;

        public OpenAccountCommandHandler(Messages messages, ITimeProvider timeProvider)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(OpenAccountCommand command)
        {
            if (_messages.Dispatch(new HasAccountQuery(command.AccountId)))
                throw new Exception("AccountId already exists, try again with an other GUID");

            _messages.Dispatch(new AccountCreatedEvent(_timeProvider.Now, command.ProcessId, command.AccountId, command.CustomerId));
        }
    }

}
