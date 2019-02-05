using dk.lashout.LARPay.Core.Shared;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Customer, int> repository;

        public CustomerRepository()
        {
            repository = new Dictionary<Customer, int>();
        }

        public bool Authenticate(Customer customer, int pincode)
        {
            return repository[customer].Equals(pincode);
        }

        public Customer GetByIdentity(string identity)
        {
            return repository.Keys.FirstOrDefault(customer => customer.Identity.Equals(identity));
        }

        public void Insert(Customer customer, int pincode)
        {
            repository.Add(customer, pincode);
        }
    }
}
