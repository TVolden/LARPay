using dk.lashout.LARPay.Accounting.Forms;

namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountFactory
    {
        IAccount CreateAccount();
    }
}
