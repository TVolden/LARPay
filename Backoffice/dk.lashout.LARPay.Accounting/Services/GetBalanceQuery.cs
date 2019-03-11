using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetBalanceQuery : IQuery<decimal>
    {
        public Guid Account { get; }

        public GetBalanceQuery(Guid account)
        {
            Account = account;
        }
    }

}
