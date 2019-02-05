namespace dk.lashout.LARPay.Accountance
{
    public interface ITransfer
    {
        void Transfer(long fromAccount, long toAccount, decimal amount, string description);
    }
}
