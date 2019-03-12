using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetBalanceQueryHandler : IQueryHandler<GetBalanceQuery, decimal>
    {
        private readonly AccountStates _archive;

        public GetBalanceQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public decimal Handle(GetBalanceQuery query)
        {
            return _archive.GetBalance(query.Account).ValueOrDefault(0);
        }
    }
}
