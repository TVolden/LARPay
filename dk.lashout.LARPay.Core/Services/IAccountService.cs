using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface IAccountService
    {
        void Transfer(Customer Sender, Customer Recipient, double amount, string description);
        double Balance(Customer customer);
    }
}
