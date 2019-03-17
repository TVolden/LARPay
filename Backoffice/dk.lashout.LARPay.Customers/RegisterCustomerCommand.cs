using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using dk.lashout.LARPay.Customers.Events;
using System;

namespace dk.lashout.LARPay.Customers
{
    public class RegisterCustomerCommand : ICommand
    {
        public Guid ProcessId => new Guid("AC71ED51-7F1E-41F2-996E-0F071317D7C9");

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

        public void Handle(RegisterCustomerCommand command)
        {
            if (_messages.Dispatch(new HasCustomerIdQuery(command.CustomerId)))
                throw new Exception("CustomerId already exists, try again with an other GUID");

            _messages.Dispatch(new CustomerRegisteredEvent(_timeProvider.Now, command.ProcessId, command.CustomerId, command.Username, command.Pincode, command.Name));
        }
    }
}
