using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Archives
{
    public interface IAccountArchive
    {
        bool Contains(Guid account);
        void Add(Guid account);
        IEnumerable<ITransaction> this[Guid account] { get; }
    }
}
