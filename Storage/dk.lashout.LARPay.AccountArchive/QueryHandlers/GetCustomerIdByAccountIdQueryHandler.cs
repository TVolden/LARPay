using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetCustomerIdByAccountIdQueryHandler : IQueryHandler<GetCustomerIdByAccountIdQuery, Guid>
    {
        private readonly AccountStates _archive;

        public GetCustomerIdByAccountIdQueryHandler(AccountStates archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Guid Handle(GetCustomerIdByAccountIdQuery query)
        {
            return _archive.GetAccount(query.Account).ValueOrDefault(null).CustomerId;
        }
    }
}
