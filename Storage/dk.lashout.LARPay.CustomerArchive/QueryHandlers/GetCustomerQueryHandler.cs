using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Maybe<CustomerDto>>
    {
        private readonly CustomerStates _archive;

        public GetCustomerQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public Maybe<CustomerDto> Handle(GetCustomerQuery query)
        {
            var maybeCustomer = _archive.GetCustomer(query.CustomerId);
            if (!maybeCustomer.HasValue())
                return new Maybe<CustomerDto>();

            var customer = maybeCustomer.ValueOrDefault(null);

            var dto = new CustomerDto(customer.Username, customer.Name);
            return new Maybe<CustomerDto>(dto);
        }
    }
}
