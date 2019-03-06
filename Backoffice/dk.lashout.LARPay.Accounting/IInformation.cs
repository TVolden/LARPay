using dk.lashout.LARPay.Accounting.Forms;
using System;

namespace dk.lashout.LARPay.Accounting
{
    public interface IInformation
    {
        IOpenAccountForm Get(Guid account);
        IOpenAccountForm GetByCustomer(string username);
    }
}
