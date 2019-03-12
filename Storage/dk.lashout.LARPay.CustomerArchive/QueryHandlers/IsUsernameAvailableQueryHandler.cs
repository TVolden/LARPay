using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class IsUsernameAvailableQueryHandler : IQueryHandler<IsUsernameAvailableQuery, bool>
    {
        private readonly CustomerStates _archive;

        public IsUsernameAvailableQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public bool Handle(IsUsernameAvailableQuery query)
        {
            return !_archive.GetCustomerId(query.Username).HasValue();
        }
    }
}
