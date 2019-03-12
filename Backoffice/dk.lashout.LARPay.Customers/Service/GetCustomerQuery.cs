using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers.Service
{
    public class GetCustomerQuery : IQuery<Maybe<CustomerDto>>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
