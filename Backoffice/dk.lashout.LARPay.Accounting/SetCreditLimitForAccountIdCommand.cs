using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Accounting.Exceptions;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class SetCreditLimitForAccountIdCommand : ICommand
    {
        public Guid ProcessId => new Guid("EFA1EDD1-2ED9-4A65-885A-70463C5570B2");

        public Guid AccountId { get; }
        public decimal CreditLimit { get; }

        public SetCreditLimitForAccountIdCommand(Guid accountId, decimal creditLimit)
        {
            AccountId = accountId;
            CreditLimit = creditLimit;
        }
    }

    public sealed class SetCreditLimitForAccountIdCommandHandler : ICommandHandler<SetCreditLimitForAccountIdCommand>
    {
        private readonly Messages _messages;
        private readonly ITimeProvider _timeProvider;

        public SetCreditLimitForAccountIdCommandHandler(Messages messages, ITimeProvider timeProvider)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(SetCreditLimitForAccountIdCommand command)
        {
            if (!_messages.Dispatch(new HasAccountQuery(command.AccountId)))
                throw new AccountNotFoundException(command.AccountId);

            _messages.Dispatch(new CreditLimitChangedEvent(_timeProvider.Now, command.ProcessId, command.AccountId, command.CreditLimit));
        }
    }
}
