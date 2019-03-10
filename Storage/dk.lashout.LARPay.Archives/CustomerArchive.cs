using System.Collections.Generic;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Archives
{
    public class CustomerArchive : ICustomerRepository
    {
        private readonly Dictionary<Guid, ICustomer> _repository;

        public CustomerArchive()
        {
            _repository = new Dictionary<Guid, ICustomer>();
        }

        public void AddCustomer(Guid customerId, ICustomer customer)
        {
            if (!_repository.ContainsKey(customerId))
                _repository.Add(customerId, customer);
        }

        public bool Authorize(string username, string pincode)
        {
            var customerId = GetCustomerId(username);
            if (!customerId.HasValue())
                return false;

            var customer = _repository[customerId.ValueOrDefault(Guid.Empty)];
            return customer.Pincode == pincode;
        }

        public Maybe<Guid> GetCustomerId(string username)
        {
            foreach(var pair in _repository)
            {
                if (pair.Value.Username == username)
                    return new Maybe<Guid>(pair.Key);
            }
            return new Maybe<Guid>();
        }

        public Maybe<ICustomer> GetCustomer(Guid customerId)
        {
            if (HasCustomer(customerId))
                return new Maybe<ICustomer>(_repository[customerId]);
            return new Maybe<ICustomer>();
        }

        public bool HasCustomer(Guid customerId)
        {
            return _repository.ContainsKey(customerId);
        }
    }
}
