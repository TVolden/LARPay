using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Applications;
using dk.lashout.LARPay.Customers.Clerks;
using System;

namespace dk.lashout.LARPay.Customers.Service
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
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public Result Handle(RegisterCustomerCommand command)
        {
            if (_customerRepository.HasCustomer(command.CustomerId))
                return new Result("AccountId already exists, try again with an other GUID");

            var customer = new CustomerApplication(command.Username, command.Pincode, command.Name);
            _customerRepository.AddCustomer(command.CustomerId, customer);
            return new Result();
        }
    }
}
