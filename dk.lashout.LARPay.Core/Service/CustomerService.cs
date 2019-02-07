using dk.lashout.LARPay.CustomerService.Clerks;
using dk.lashout.LARPay.CustomerService.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerService.Service
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
                receiver.SaveCustomer(customer.Identity, customer.Name, pincode);
        }

        public Maybe<long> GetAccount(string identifier)
        {
            var customer = retreiver.GetCustomer(identifier);
            if (customer.HasValue())
                return new Maybe<long>();

            var account = customer.ValueOrDefault(null).Account;
            if (account == null)
                return new Maybe<long>();

            return new Maybe<long>(account.Value);
        }
    }
}