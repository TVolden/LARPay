using System.Collections.Generic;
using System;
using dk.lashout.LARPay.CustomerArchive.Applications;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerArchive
{
    public class CustomerStates
    {
        private readonly Dictionary<Guid, Customer> _customers;

        public CustomerStates()
        {
            _customers = new Dictionary<Guid, Customer>();
        }

        public void AddCustomer(Guid customerId, Customer customer)
        {
            if (!_customers.ContainsKey(customerId))
                _customers.Add(customerId, customer);
        }

        public bool Authorize(string username, string pincode)
        {
            var customerId = GetCustomerId(username);
            if (!customerId.HasValue())
                return false;

            var customer = _customers[customerId.ValueOrDefault(Guid.Empty)];
            return customer.Pincode == pincode;
        }

        public Maybe<Guid> GetCustomerId(string username)
        {
            foreach(var pair in _customers)
            {
                if (pair.Value.Username == username)
                    return new Maybe<Guid>(pair.Key);
            }
            return new Maybe<Guid>();
        }

        public Maybe<Customer> GetCustomer(Guid customerId)
        {
            if (HasCustomer(customerId))
                return new Maybe<Customer>(_customers[customerId]);
            return new Maybe<Customer>();
        }

        public bool HasCustomer(Guid customerId)
        {
            return _customers.ContainsKey(customerId);
        }
    }
}
