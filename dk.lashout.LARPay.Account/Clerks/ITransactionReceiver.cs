namespace dk.lashout.LARPay.Accounting.Clerks
{
    public interface ITransactionStorer
    {
        void SaveTransaction(long account, decimal amount, string description);
    }
}