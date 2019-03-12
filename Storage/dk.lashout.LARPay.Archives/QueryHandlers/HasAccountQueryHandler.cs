using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class HasAccountQueryHandler : IQueryHandler<HasAccountQuery, bool>
    {
        private readonly AccountArchive _archive;

        public HasAccountQueryHandler(AccountArchive archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public bool Handle(HasAccountQuery query)
        {
            return _archive.HasAccount(query.AccountId);
        }
    }
}
