using dk.lashout.LARPay.Accountance.Records;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accountance
{
    public interface IStatement
    {
        IEnumerable<ITransaction> Statement(long account);
    }
}
