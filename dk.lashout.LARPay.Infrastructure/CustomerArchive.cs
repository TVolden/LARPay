using System.Collections.Generic;
using System.Linq;
using dk.lashout.LARPay.Archives.Records;
using dk.lashout.LARPay.CustomerService;
using dk.lashout.LARPay.CustomerService.Clerks;
using dk.lashout.LARPay.CustomerService.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.Archives
{
    public class CustomerArchive : ICustomerRetreiver, ILogin, ICustomerReceiver
    {
        private readonly Dictionary<Customer, int> repository;

        public CustomerArchive()
        {
            repository = new Dictionary<Customer, int>();
        }

        public Maybe<ICustomer> GetCustomer(string identifier)
        {
            var customer = getCustomer(identifier);
            if (customer == null)
                return new Maybe<ICustomer>(customer);
            return new Maybe<ICustomer>();
        }

        private Customer getCustomer(string identifier)
        {
            return repository.Keys.FirstOrDefault(c => c.Identity.Equals(identifier));
        }

        public bool Login(string identifier, int pincode)
        {
            var customer = getCustomer(identifier);
            if (customer != null)
                return repository[customer].Equals(pincode);
            return false;
        }

        public void SaveCustomer(string identifier, string name, int pincode)
        {
            var customer = new Customer(identifier, name);
            repository.Add(customer, pincode);
        }
    }
}
