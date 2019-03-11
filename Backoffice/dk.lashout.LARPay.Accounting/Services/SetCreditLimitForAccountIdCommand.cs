using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class SetCreditLimitForAccountIdCommand : ICommand
    {
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

        public SetCreditLimitForAccountIdCommandHandler(Messages messages)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        public Result Handle(SetCreditLimitForAccountIdCommand command)
        {
            if (!_messages.Dispatch(new HasAccountQuery(command.AccountId)))
                return new Result("Account not found");

            _messages.Dispatch(new CreditLimitChangedEvent(command.AccountId, command.CreditLimit));

            return new Result();
        }
    }
}
