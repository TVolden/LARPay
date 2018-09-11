using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface IAccountService
    {
        double Balance(ICustomer customer);
        ITransaction[] Statement(ICustomer customer);
        void Transfer(ICustomer sender, ICustomer recipient, double amount, string description);
        
    }
}