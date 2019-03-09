using dk.lashout.LARPay.Archives;
using dk.lashout.LARPay.Bank;
using NUnit.Framework;

namespace dk.lashout.LARPay.Specifications.Drivers
{
    class CustomerFacadeDriver
    {
        private readonly ICustomerFacade _customerFacade;

        public CustomerFacadeDriver()
        {
            var customerArchive = new CustomerArchive();
            var accountArchive = new AccountArchive();
            //_customerFacade = new CustomerFacade(null);
        }

        public void CreateUser(string username, string name, string pincode)
        {
            //_customerFacade.CreateCustomer(username, name, pincode);
        }

        public void CanLogin(string username, string pincode)
        {
            //Assert.True(_customerFacade.Login(username, pincode));
        }
    }
}
