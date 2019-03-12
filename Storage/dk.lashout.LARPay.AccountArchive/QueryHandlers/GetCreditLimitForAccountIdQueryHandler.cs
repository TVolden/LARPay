using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetCreditLimitForAccountIdQueryHandler : IQueryHandler<GetCreditLimitForAccountIdQuery, decimal>
    {
        private readonly AccountStates _archive;

        public GetCreditLimitForAccountIdQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public decimal Handle(GetCreditLimitForAccountIdQuery query)
        {
            var account = _archive.GetAccount(query.Account);
            if (!account.HasValue())
                return 0;
            return account.ValueOrDefault(null).creditLimit;
        }
    }
}
