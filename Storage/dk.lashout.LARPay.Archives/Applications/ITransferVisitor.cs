namespace dk.lashout.LARPay.Archives.Applications
{
    public interface ITransferVisitor<TReturn>
    {
        TReturn Visit(Debit debit);
        TReturn Visit(Credit debit);
    }
}