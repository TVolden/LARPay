using System.Collections.Generic;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public void Insert(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetByIdentity(string identity)
        {
            foreach (var customer in _customers)
            {
                if (customer.Identity == identity)
                    return customer;
            }

            return null;
        }
    }
}
