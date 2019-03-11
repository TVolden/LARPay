using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public class GetDisposableAmountQueryHandler : IQueryHandler<GetDisposableAmountQuery, decimal>
    {
        private readonly AccountArchive _archive;

        public GetDisposableAmountQueryHandler(AccountArchive archive)
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
