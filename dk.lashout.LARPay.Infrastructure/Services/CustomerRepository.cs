using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICredentialsRepository _repository;

        public CustomerRepository(ICredentialsRepository repository)
        {
            _repository = repository;
        }

        public Customer GetByIdentity(string identity)
        {
            return _repository.GetByIdentity(identity);
        }
    }
}
