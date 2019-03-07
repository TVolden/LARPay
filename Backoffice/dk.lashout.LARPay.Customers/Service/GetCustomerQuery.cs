using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class GetCustomerQuery : IQuery<Maybe<CustomerDto>>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Maybe<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public Maybe<CustomerDto> Handle(GetCustomerQuery query)
        {
            var maybeCustomer = _customerRepository.GetCustomer(query.CustomerId);
            if (!maybeCustomer.HasValue())
                return new Maybe<CustomerDto>();

            var customer = maybeCustomer.ValueOrDefault(null);

            var dto = new CustomerDto(customer.Username, customer.Name);
            return new Maybe<CustomerDto>(dto);
        }
    }
}
