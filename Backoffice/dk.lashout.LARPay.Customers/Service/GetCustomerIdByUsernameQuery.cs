using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class GetCustomerIdByUsernameQuery : IQuery<Maybe<Guid>>
    {
        public string Username { get; }

        public GetCustomerIdByUsernameQuery(string username)
        {
            Username = username;
        }
    }

    public sealed class GetCustomerIdByUsernameQueryHandler : IQueryHandler<GetCustomerIdByUsernameQuery, Maybe<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerIdByUsernameQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public Maybe<Guid> Handle(GetCustomerIdByUsernameQuery query)
        {
            return _customerRepository.GetCustomerId(query.Username);
        }
    }
}
