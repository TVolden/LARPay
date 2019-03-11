using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetCreditLimitForAccountIdQuery : IQuery<decimal>
    {
        public Guid Account { get; }

        public GetCreditLimitForAccountIdQuery(Guid account)
        {
            Account = account;
        }
    }
}
