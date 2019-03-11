using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetAvailableAccountIdQueryHandler : IQueryHandler<GetAvailableAccountIdQuery, Guid>
    {
        private readonly AccountArchive _archive;

        public GetAvailableAccountIdQueryHandler(AccountArchive archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Guid Handle(GetAvailableAccountIdQuery query)
        {
            Guid returnValue;
            do
            {
                returnValue = Guid.NewGuid();
            }
            while (_archive.HasAccount(returnValue));

            return returnValue;
        }
    }
}
