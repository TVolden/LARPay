using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class GetDisposableAmountQuery : IQuery<decimal>
    {
        public Guid AccountId { get; }

        public GetDisposableAmountQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
