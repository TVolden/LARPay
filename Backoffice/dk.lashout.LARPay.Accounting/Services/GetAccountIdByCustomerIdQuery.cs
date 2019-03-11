using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Accounting.Services
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
