using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class GetUsernameByCustomerIdQueryHandler : IQueryHandler<GetUsernameByCustomerIdQuery, Maybe<string>>
    {
        private readonly CustomerStates _archive;

        public GetUsernameByCustomerIdQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public Maybe<string> Handle(GetUsernameByCustomerIdQuery query)
        {
            var customer = _archive.GetCustomer(query.CustomerId);
            if (customer.HasValue())
                return new Maybe<string>(customer.ValueOrDefault(null).Username);
            return new Maybe<string>();
        }
    }
}
