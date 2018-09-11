using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;
using System;

namespace dk.lashout.LARPay.Core.Facades
{
    public class Customers : ICustomers
    {
        private readonly ICustomerService _service;

        public Customers(ICustomerService service)
        {
            _service = service;
        }

        public void Create(string identity, string name, int pincode)
        {
            if (_service.HasCustomer(identity))
                throw new Exception("Identity taken");

            var customer = new Customer()
            {
                Identity = identity,
                Name = name
            };

            _service.Create(customer, pincode);
        }

        public bool Login(string identity, int pincode)
        {
            return _service.Login(identity, pincode);
        }
    }
}
