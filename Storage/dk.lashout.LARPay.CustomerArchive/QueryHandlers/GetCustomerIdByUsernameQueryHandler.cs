using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers;
using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class GetCustomerIdByUsernameQueryHandler : IQueryHandler<GetCustomerIdByUsernameQuery, Maybe<Guid>>
    {
        private readonly CustomerStates _archive;

        public GetCustomerIdByUsernameQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public Maybe<Guid> Handle(GetCustomerIdByUsernameQuery query)
        {
            return _archive.GetCustomerId(query.Username);
        }
    }
}
