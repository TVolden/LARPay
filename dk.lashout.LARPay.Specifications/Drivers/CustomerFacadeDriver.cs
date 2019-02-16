using dk.lashout.LARPay.Accounting.Service;
using dk.lashout.LARPay.Archives;
using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Clock;
using dk.lashout.LARPay.Customers.Service;
using NUnit.Framework;

namespace dk.lashout.LARPay.Specifications.Drivers
{
    class CustomerFacadeDriver
    {
        private readonly ICustomerFacade _customerFacade;

        public CustomerFacadeDriver()
        {
            var customerArchive = new CustomerArchive();
            var accountArchive = new AccountArchive(new UtcTime());
            var customerService = new CustomerService(customerArchive);
            var accountService = new AccountService(accountArchive);
            _customerFacade = new CustomerFacade(customerService, accountService, customerService);
        }

        public void CreateUser(string username, string name, int pincode)
        {
            _customerFacade.CreateCustomer(username, name, pincode);
        }

        public void CanLogin(string username, int pincode)
        {
            Assert.True(_customerFacade.Login(username, pincode));
        }
    }
}
