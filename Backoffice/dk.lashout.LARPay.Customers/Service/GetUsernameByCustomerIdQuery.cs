using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class GetUsernameByCustomerIdQuery : IQuery<Maybe<string>>
    {
        public Guid CustomerId { get; }

        public GetUsernameByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    public sealed class GetUsernameByCustomerIdQueryHandler : IQueryHandler<GetUsernameByCustomerIdQuery, Maybe<string>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetUsernameByCustomerIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public Maybe<string> Handle(GetUsernameByCustomerIdQuery query)
        {
            var customer = _customerRepository.GetCustomer(query.CustomerId);
            if (customer.HasValue())
                return new Maybe<string>(customer.ValueOrDefault(null).Username);
            return new Maybe<string>();
        }
    }
}
