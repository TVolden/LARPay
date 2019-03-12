using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetAccountIdByCustomerIdQueryHandler : IQueryHandler<GetAccountIdByCustomerIdQuery, Maybe<Guid>>
    {
        private readonly AccountStates _archive;

        public GetAccountIdByCustomerIdQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Maybe<Guid> Handle(GetAccountIdByCustomerIdQuery query)
        {
            return _archive.GetAccountId(query.CustomerId);
        }
    }

}
