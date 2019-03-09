using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;

namespace dk.lashout.LARPay.Customers.Service
{
    public class IsUsernameAvailableQuery : IQuery<bool>
    {
        public string Username { get; }

        public IsUsernameAvailableQuery(string username)
        {
            Username = username;
        }
    }

    public sealed class IsUsernameAvailableQueryHandler : IQueryHandler<IsUsernameAvailableQuery, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public IsUsernameAvailableQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new System.ArgumentNullException(nameof(customerRepository));
        }

        public bool Handle(IsUsernameAvailableQuery query)
        {
            return !_customerRepository.GetCustomerId(query.Username).HasValue();
        }
    }
}
