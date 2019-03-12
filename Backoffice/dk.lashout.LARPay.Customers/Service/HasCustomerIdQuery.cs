using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class HasCustomerIdQuery : IQuery<bool>
    {
        public Guid CustomerId { get; }

        public HasCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
