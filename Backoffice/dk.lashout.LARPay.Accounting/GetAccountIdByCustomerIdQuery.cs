using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class GetAccountIdByCustomerIdQuery : IQuery<Maybe<Guid>>
    {
        public Guid CustomerId { get; }

        public GetAccountIdByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
