using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers
{
    public interface IAccountGetter
    {
        Maybe<Guid> GetAccount(string identifier);
    }
}
