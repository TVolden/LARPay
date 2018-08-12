using System;
using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Create(Customer customer)
        {
            if (_repository.GetByIdentity(customer.Identity) != null)
                throw new Exception("Identity taken");

            _repository.Insert(customer);
        }

        public bool Login(string identity, int pincode)
        {
            var customer = _repository.GetByIdentity(identity);
            return customer != null && pincode == customer.Pincode;
        }
    }
}