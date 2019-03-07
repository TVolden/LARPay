using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;
using System;

namespace dk.lashout.LARPay.Bank
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly Messages _messages;

        public CustomerFacade(Messages messages)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        public void CreateCustomer(string username, string name, string pincode)
        {
            if (!_messages.Dispatch(new IsUsernameAvailableQuery(username)))
                throw new IdentifierTakenException(username);

            var customerId = _messages.Dispatch(new GetAvailableCustomerIdQuery());
            if (!_messages.Dispatch(new RegisterCustomerCommand(customerId, username, pincode, name)).Success)
            {
                throw new Exception("Unable to register customer");
            }

            var accountId = Guid.NewGuid(); //= _messages.Dispatch(new GetAvailableAccountIdQuery());
            if (!_messages.Dispatch(new OpenAccountCommand(accountId, customerId)).Success)
            {
                throw new Exception("Unable to open account");
            }
        }

        public bool Login(string username, string pincode)
        {
            return _messages.Dispatch(new LoginQuery(username, pincode));
        }
    }
}
