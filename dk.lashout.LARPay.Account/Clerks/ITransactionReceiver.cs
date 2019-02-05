namespace dk.lashout.LARPay.Accountance.Clerks
{
    public interface ITransactionStorer
    {
        void SaveTransaction(long account, decimal amount, string description);
    }
}