using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class LoginQueryHandler : IQueryHandler<LoginQuery, bool>
    {
        private readonly CustomerStates _archive;

        public LoginQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public bool Handle(LoginQuery query)
        {
            return _archive.Authorize(query.Username, query.Pincode);
        }
    }
}
