namespace dk.lashout.LARPay.Administration
{
    public interface IQueryDispatcher
    {
         IQueryHandler<TQuery, TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
