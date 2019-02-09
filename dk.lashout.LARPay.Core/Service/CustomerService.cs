using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class CustomerService : ICustomerCreator, IAccountGetter, ILogin, ICustomerGetter
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Create(ICustomer customer, int pincode)
        {
            if (!_repository.GetCustomer(customer.Identity).HasValue())
                _repository.SaveCustomer(customer.Identity, customer.Name, customer.Account, pincode);
        }

        public Maybe<Guid> GetAccount(string identifier)
        {
            var customer = _repository.GetCustomer(identifier);
            if (!customer.HasValue())
                return new Maybe<Guid>();

            var account = customer.ValueOrDefault(null).Account;
            return new Maybe<Guid>(account);
        }

        public Maybe<string> GetCustomer(Guid account)
        {
            var customer = _repository.GetCustomer(account);
            if (customer.HasValue())
                return new Maybe<string>(customer.ValueOrDefault(null).Identity);
            return new Maybe<string>();
        }

        public bool Login(string identifier, int pincode)
        {
            return _repository.Authorize(identifier, pincode);
        }
    }
}