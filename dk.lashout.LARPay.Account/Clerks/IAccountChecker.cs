namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface IAccountChecker
    {
        bool AccountExists(long account);
    }
}
