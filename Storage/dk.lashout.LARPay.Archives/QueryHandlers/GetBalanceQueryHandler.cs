using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetBalanceQueryHandler : IQueryHandler<GetBalanceQuery, decimal>
    {
        private readonly AccountArchive _archive;

        public GetBalanceQueryHandler(AccountArchive archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public decimal Handle(GetBalanceQuery query)
        {
            return _archive.GetBalance(query.Account).ValueOrDefault(0);
        }
    }
}
