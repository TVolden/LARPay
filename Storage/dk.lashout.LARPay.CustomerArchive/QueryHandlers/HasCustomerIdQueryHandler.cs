using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class HasCustomerIdQueryHandler : IQueryHandler<HasCustomerIdQuery, bool>
    {
        private readonly CustomerStates _archive;

        public HasCustomerIdQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public bool Handle(HasCustomerIdQuery query)
        {
            return _archive.HasCustomer(query.CustomerId);
        }
    }
}
