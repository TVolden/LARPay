using System;
using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICredentialsRepository _repository;

        public CustomerService(ICredentialsRepository repository)
        {
            _repository = repository;
        }

        public void Create(Customer customer, int pincode)
        {
            if (_repository.GetByIdentity(customer.Identity) != null)
                throw new Exception("Identity taken");

            var credentials = new Credentials()
            {
                Identity = customer.Identity,
                Name = customer.Name,
                Pincode = pincode
            };
            _repository.Insert(credentials);
        }

        public bool Login(string identity, int pincode)
        {
            var customer = _repository.GetByIdentity(identity);
            return customer != null && pincode == customer.Pincode;
        }

        public Customer GetCustomer(string identity)
        {
            return _repository.GetByIdentity(identity);
        }
    }
}