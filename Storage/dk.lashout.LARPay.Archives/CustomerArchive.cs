using System.Collections.Generic;
using System.Linq;
using dk.lashout.LARPay.Archives.Records;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Archives
{
    public class CustomerArchive : ICustomerRepository
    {
        private readonly Dictionary<Customer, int> repository;

        public CustomerArchive()
        {
            repository = new Dictionary<Customer, int>();
        }

        public Maybe<ICustomer> GetCustomer(string identifier)
        {
            var customer = getCustomer(identifier);
            if (customer != null)
                return new Maybe<ICustomer>(customer);
            return new Maybe<ICustomer>();
        }

        private Customer getCustomer(string identifier)
        {
            return repository.Keys.FirstOrDefault(c => c.Identifier.Equals(identifier));
        }

        public void SaveCustomer(string identifier, string name, Guid account, int pincode)
        {
            var customer = new Customer(identifier, name, account);
            repository.Add(customer, pincode);
        }

        public Maybe<Guid> GetAccount(string identifier)
        {
            var customer = getCustomer(identifier);
            if (customer == null)
                return new Maybe<Guid>();
            return new Maybe<Guid>(customer.Account);
        }

        public bool Authorize(string identifier, int pincode)
        {
            var customer = getCustomer(identifier);
            if (customer != null)
                return repository[customer].Equals(pincode);
            return false;
        }

        public Maybe<ICustomer> GetCustomer(Guid account)
        {
            var customer = repository.Keys.SingleOrDefault(c => c.Account == account);
            if (customer != null)
                return new Maybe<ICustomer>(customer);
            return new Maybe<ICustomer>();
        }
    }
}
