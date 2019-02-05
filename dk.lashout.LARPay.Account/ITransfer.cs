namespace dk.lashout.LARPay.Accounting
{
    public interface ITransfer
    {
        void Transfer(long fromAccount, long toAccount, decimal amount, string description);
    }
}
