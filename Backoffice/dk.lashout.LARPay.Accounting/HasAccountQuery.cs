using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class HasAccountQuery : IQuery<bool>
    {
        public Guid AccountId { get; }

        public HasAccountQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
