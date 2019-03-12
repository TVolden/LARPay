using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.CustomerArchive.Applications;
using dk.lashout.LARPay.Customers.Events;

namespace dk.lashout.LARPay.CustomerArchive.EventObservers
{
    public sealed class CustomerRegisteredEventObserver : IEventObserver<CustomerRegisteredEvent>
    {
        private readonly CustomerStates _archive;

        public CustomerRegisteredEventObserver(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(CustomerRegisteredEvent @event)
        {
            var customer = new Customer(@event.Username, @event.Pincode, @event.Name);
            _archive.AddCustomer(@event.CustomerId, customer);
        }
    }
}
