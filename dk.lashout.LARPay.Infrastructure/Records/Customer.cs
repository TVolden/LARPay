using dk.lashout.LARPay.CustomerService.Forms;

namespace dk.lashout.LARPay.Archives.Records
{
    class Customer : ICustomer
    {
        public string Name { get; }
        public string Identity { get; }

        public Customer(string identity, string name)
        {
            Identity = identity;
            Name = name;
        }
    }
}
