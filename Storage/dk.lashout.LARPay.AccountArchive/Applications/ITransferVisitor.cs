namespace dk.lashout.LARPay.AccountArchive.Applications
{
    public interface ITransferVisitor<TReturn>
    {
        TReturn Visit(Debit debit);
        TReturn Visit(Credit debit);
    }
}