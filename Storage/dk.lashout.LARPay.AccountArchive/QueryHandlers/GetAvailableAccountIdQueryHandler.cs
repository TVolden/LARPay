using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetAvailableAccountIdQueryHandler : IQueryHandler<GetAvailableAccountIdQuery, Guid>
    {
        private readonly AccountStates _archive;

        public GetAvailableAccountIdQueryHandler(AccountStates archive)
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
