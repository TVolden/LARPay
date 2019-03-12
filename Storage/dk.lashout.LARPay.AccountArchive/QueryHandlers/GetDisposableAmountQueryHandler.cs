using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public class GetDisposableAmountQueryHandler : IQueryHandler<GetDisposableAmountQuery, decimal>
    {
        private readonly AccountStates _archive;

        public GetDisposableAmountQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public decimal Handle(GetDisposableAmountQuery query)
        {
            var maybeAccount = _archive.GetAccount(query.AccountId);
            if (maybeAccount.HasValue())
            {
                var account = maybeAccount.ValueOrDefault(null);
                return _archive.GetBalance(query.AccountId).ValueOrDefault(0) + account.creditLimit;
            }
            return 0;
        }
    }
}
