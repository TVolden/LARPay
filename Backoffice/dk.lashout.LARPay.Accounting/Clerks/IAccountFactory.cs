using dk.lashout.LARPay.Accounting.Applications;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountFactory
    {
        IAccount CreateAccount();
    }
}
