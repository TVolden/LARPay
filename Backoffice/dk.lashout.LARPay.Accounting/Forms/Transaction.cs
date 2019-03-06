namespace dk.lashout.LARPay.Accounting.Forms
{
    public abstract class Transaction
    {
        string Description { get; }
        double Amount { get; }

        internal TReturn Accept<TReturn>(ITransferVisitor<TReturn> visitor)
        {
            return visitor.Visit((dynamic)this);
        }
    }
}
