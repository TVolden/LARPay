﻿using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public class GetCustomerIdByAccountIdQuery : IQuery<Guid>
    {
        public Guid Account { get; }

        public GetCustomerIdByAccountIdQuery(Guid account)
        {
            Account = account;
        }
    }
}
