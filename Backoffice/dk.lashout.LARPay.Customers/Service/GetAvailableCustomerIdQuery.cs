using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class GetAvailableCustomerIdQuery : IQuery<Guid> { }

    public sealed class GetAvailableCustomerIdQueryHandler : IQueryHandler<GetAvailableCustomerIdQuery, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAvailableCustomerIdQueryHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public Guid Handle(GetAvailableCustomerIdQuery query)
        {
            Guid returnValue;
            do
            {
                returnValue = Guid.NewGuid();
            }
            while (_customerRepository.HasCustomer(returnValue));

            return returnValue;
        }
    }
}
