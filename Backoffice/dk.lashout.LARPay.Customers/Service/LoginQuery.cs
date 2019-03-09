using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Clerks;

namespace dk.lashout.LARPay.Customers.Service
{
    public class LoginQuery : IQuery<bool>
    {
        public string Username { get; }
        public string Pincode { get; }

        public LoginQuery(string username, string pincode)
        {
            Username = username;
            Pincode = pincode;
        }
    }

    public sealed class LoginQueryHandler : IQueryHandler<LoginQuery, bool>
    {
        private readonly ICustomerRepository customerRepository;

        public LoginQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository ?? throw new System.ArgumentNullException(nameof(customerRepository));
        }

        public bool Handle(LoginQuery query)
        {
            return customerRepository.Authorize(query.Username, query.Pincode);
        }
    }
}
