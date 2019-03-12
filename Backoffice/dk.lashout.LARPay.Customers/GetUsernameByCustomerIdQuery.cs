using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers
{
    public class GetUsernameByCustomerIdQuery : IQuery<Maybe<string>>
    {
        public Guid CustomerId { get; }

        public GetUsernameByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
