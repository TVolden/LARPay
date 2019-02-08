using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class CustomerService : ICustomerCreator, IAccountGetter
    {
        private readonly ICustomerReceiver receiver;
        private readonly ICustomerRetreiver retreiver;

        public CustomerService(ICustomerReceiver receiver, ICustomerRetreiver retreiver)
        {
            this.receiver = receiver ?? throw new System.ArgumentNullException(nameof(receiver));
            this.retreiver = retreiver ?? throw new System.ArgumentNullException(nameof(retreiver));
        }

        public void Create(ICustomer customer, int pincode)
        {
            if (!retreiver.GetCustomer(customer.Identity).HasValue())
                receiver.SaveCustomer(customer.Identity, customer.Name, customer.Account, pincode);
        }

        public Maybe<Guid> GetAccount(string identifier)
        {
            var customer = retreiver.GetCustomer(identifier);
            if (customer.HasValue())
                return new Maybe<Guid>();

            var account = customer.ValueOrDefault(null).Account;
            return new Maybe<Guid>(account);
        }
    }
}