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

        public Result CreateCustomer(string username, string name, string pincode)
        {
            if (!_messages.Dispatch(new IsUsernameAvailableQuery(username)))
                return new Result("Username not available, try an other");

            var customerId = _messages.Dispatch(new GetAvailableCustomerIdQuery());
            var result = _messages.Dispatch(new RegisterCustomerCommand(customerId, username, pincode, name));
            if (!result.Success)
                return result;

            var accountId = _messages.Dispatch(new GetAvailableAccountIdQuery());
            result = _messages.Dispatch(new OpenAccountCommand(accountId, customerId));
            if (!result.Success)
                return result;

            return new Result();
        }

        public bool Login(string username, string pincode)
        {
            return _messages.Dispatch(new LoginQuery(username, pincode));
        }
    }
}
