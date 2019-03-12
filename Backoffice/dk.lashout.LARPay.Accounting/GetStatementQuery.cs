using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting
{
    public class GetStatementQuery : IQuery<IEnumerable<TransferDto>>
    {
        public Guid account;

        public GetStatementQuery(Guid account)
        {
            this.account = account;
        }
    }

}
