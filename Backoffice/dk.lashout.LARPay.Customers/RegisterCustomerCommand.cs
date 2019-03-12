using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using dk.lashout.LARPay.Customers.Events;
using System;

namespace dk.lashout.LARPay.Customers
{
    public class RegisterCustomerCommand : ICommand
    {
        public Guid CustomerId { get; }
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }

        public RegisterCustomerCommand(Guid customerId, string username, string pincode, string name)
        {
            CustomerId = customerId;
            Username = username;
            Pincode = pincode;
            Name = name;
        }
    }

    public sealed class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
    {
        private readonly Messages _messages;
        private readonly ITimeProvider _timeProvider;

        public RegisterCustomerCommandHandler(Messages messages, ITimeProvider timeProvider)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public Result Handle(RegisterCustomerCommand command)
        {
            if (_messages.Dispatch(new HasCustomerIdQuery(command.CustomerId)))
                return new Result("CustomerId already exists, try again with an other GUID");

            _messages.Dispatch(new CustomerRegisteredEvent(command.CustomerId, command.Username, command.Pincode, command.Name, _timeProvider.Now));
            return new Result();
        }
    }
}
