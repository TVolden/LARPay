using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class HasAccountQueryHandler : IQueryHandler<HasAccountQuery, bool>
    {
        private readonly AccountStates _archive;

        public HasAccountQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public bool Handle(HasAccountQuery query)
        {
            return _archive.HasAccount(query.AccountId);
        }
    }
}
