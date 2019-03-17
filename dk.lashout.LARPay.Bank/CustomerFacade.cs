using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers;
using System;

namespace dk.lashout.LARPay.Bank
{
    public class CustomerFacade
    {
        private readonly Messages _messages;

        public CustomerFacade(Messages messages)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        public void CreateCustomer(string username, string name, string pincode)
        {
            if (!_messages.Dispatch(new IsUsernameAvailableQuery(username)))
                throw new Exception("Username not available");

            var customerId = _messages.Dispatch(new GetAvailableCustomerIdQuery());
            _messages.Dispatch(new RegisterCustomerCommand(customerId, username, pincode, name));

            var accountId = _messages.Dispatch(new GetAvailableAccountIdQuery());
            _messages.Dispatch(new OpenAccountCommand(accountId, customerId));
        }

        public bool Login(string username, string pincode)
        {
            return _messages.Dispatch(new LoginQuery(username, pincode));
        }
    }
}
