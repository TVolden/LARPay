using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetCreditLimitForAccountIdQueryHandler : IQueryHandler<GetCreditLimitForAccountIdQuery, decimal>
    {
        private readonly AccountArchive _archive;

        public GetCreditLimitForAccountIdQueryHandler(AccountArchive archive)
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
