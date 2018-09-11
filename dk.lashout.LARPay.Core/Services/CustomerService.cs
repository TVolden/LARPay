using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Shared;

namespace dk.lashout.LARPay.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public bool HasCustomer(string identity)
        {
            return _repository.GetByIdentity(identity) != null;
        }

        public void Create(ICustomer customer, int pincode)
        {
            _repository.Insert(customer, pincode);
        }

        public bool Login(string identity, int pincode)
        {
            var customer = _repository.GetByIdentity(identity);
            return _repository.Authenticate(customer, pincode);
        }

        public ICustomer GetCustomer(string identity)
        {
            return _repository.GetByIdentity(identity);
        }
    }
}