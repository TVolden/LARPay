using dk.lashout.LARPay.Accounting.Forms;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting
{
    public interface IStatement
    {
        IEnumerable<ITransaction> Statement(long account);
    }
}
