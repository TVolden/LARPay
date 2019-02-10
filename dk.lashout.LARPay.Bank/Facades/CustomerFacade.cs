using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Customers;
using System;

namespace dk.lashout.LARPay.Bank
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerCreator _customerCreator;
        private readonly IAccountCreator _accountCreator;

        public CustomerFacade(ICustomerCreator customerCreator, IAccountCreator accountCreator)
        {
            _customerCreator = customerCreator ?? throw new ArgumentNullException(nameof(customerCreator));
            _accountCreator = accountCreator ?? throw new ArgumentNullException(nameof(accountCreator));
        }

        public void CreateCustomer(string identifier, string name, int pincode)
        {
            if (_customerCreator.CustomerExists(identifier))
                throw new IdentifierTakenException(identifier);
            var account = _accountCreator.GenerateID();
            _customerCreator.Create(new ICustomerDTO(name, identifier, account), pincode);
            _accountCreator.Create(account);
        }
    }
}
