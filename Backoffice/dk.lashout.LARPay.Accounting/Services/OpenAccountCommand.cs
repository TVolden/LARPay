using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class OpenAccountCommand : ICommand
    {
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

        public OpenAccountCommandHandler(Messages messages)
        {
            _messages = messages;
        }

        public Result Handle(OpenAccountCommand command)
        {
            if (_messages.Dispatch(new HasAccountQuery(command.AccountId)))
                return new Result("AccountId already exists, try again with an other GUID");

            _messages.Dispatch(new NewAccountEvent(command.AccountId, command.CustomerId));
            return new Result();
        }
    }

}
