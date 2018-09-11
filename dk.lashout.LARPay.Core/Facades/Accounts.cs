using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;

namespace dk.lashout.LARPay.Core.Facades
{
    public class Accounts : IAccounts
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public Accounts(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        public double Balance(string identity)
        {
            return _accountService.Balance(getCustomer(identity));
        }

        public ITransaction[] Statement(string identity)
        {
            return _accountService.Statement(getCustomer(identity));
        }

        private ICustomer getCustomer(string identity)
        {
            return _customerService.GetCustomer(identity);
        }

        public void Transfer(string from, string to, double amount, string description)
        {
            _accountService.Transfer(getCustomer(from), getCustomer(to), amount, description);
        }
    }
}
