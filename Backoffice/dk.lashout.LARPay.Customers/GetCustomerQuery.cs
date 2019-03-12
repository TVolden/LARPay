using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers
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
