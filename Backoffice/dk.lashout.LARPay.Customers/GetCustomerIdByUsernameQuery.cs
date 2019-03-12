using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.Customers
{
    public class GetCustomerIdByUsernameQuery : IQuery<Maybe<Guid>>
    {
        public string Username { get; }

        public GetCustomerIdByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
