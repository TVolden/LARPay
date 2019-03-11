using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetCustomerIdByAccountIdQueryHandler : IQueryHandler<GetCustomerIdByAccountIdQuery, Guid>
    {
        private readonly AccountArchive _archive;

        public GetCustomerIdByAccountIdQueryHandler(AccountArchive archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Guid Handle(GetCustomerIdByAccountIdQuery query)
        {
            return _archive.GetAccount(query.Account).ValueOrDefault(null).CustomerId;
        }
    }
}
