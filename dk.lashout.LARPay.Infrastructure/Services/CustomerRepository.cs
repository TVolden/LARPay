using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Shared;
using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<ICustomer, int> repository;

        public CustomerRepository()
        {
            repository = new Dictionary<ICustomer, int>();
        }

        public bool Authenticate(ICustomer customer, int pincode)
        {
            return repository[customer].Equals(pincode);
        }

        public ICustomer GetByIdentity(string identity)
        {
            return repository.Keys.FirstOrDefault(customer => customer.Identity.Equals(identity));
        }

        public void Insert(ICustomer customer, int pincode)
        {
            repository.Add(customer, pincode);
        }
    }
}
