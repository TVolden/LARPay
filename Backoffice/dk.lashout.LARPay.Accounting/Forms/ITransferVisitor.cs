using dk.lashout.LARPay.Accounting.Applications;

namespace dk.lashout.LARPay.Accounting.Forms
{
    interface ITransferVisitor<TReturn>
    {
        TReturn Visit(Debit debit);
        TReturn Visit(Credit debit);
    }
}