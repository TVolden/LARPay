using dk.lashout.LARPay.CustomerService.Clerks;
using dk.lashout.LARPay.CustomerService.Forms;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerService.Service
{
    public class CustomerService : ICustomerCreator
    {
        private readonly ICustomerReceiver receiver;

        public CustomerService(ICustomerReceiver receiver)
        {
            this.receiver = receiver ?? throw new System.ArgumentNullException(nameof(receiver));
        }

        public void Create(ICustomer customer, int pincode)
        {
            receiver.SaveCustomer(customer.Identity, customer.Name, pincode);
        }
    }
}