using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Facades
{
    public interface IAccounts
    {
        void Transfer(string from, string to, double amount, string description);
        ITransaction[] Statement(string identity);
        double Balance(string identity);
    }
}
