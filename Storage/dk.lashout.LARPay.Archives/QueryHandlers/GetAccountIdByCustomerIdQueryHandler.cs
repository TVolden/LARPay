using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetAccountIdByCustomerIdQueryHandler : IQueryHandler<GetAccountIdByCustomerIdQuery, Maybe<Guid>>
    {
        private readonly AccountArchive _archive;

        public GetAccountIdByCustomerIdQueryHandler(AccountArchive archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Maybe<Guid> Handle(GetAccountIdByCustomerIdQuery query)
        {
            return _archive.GetAccountId(query.CustomerId);
        }
    }

}
