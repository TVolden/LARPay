using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Customers.Service;
using System;

namespace dk.lashout.LARPay.CustomerArchive.QueryHandlers
{
    public sealed class GetAvailableCustomerIdQueryHandler : IQueryHandler<GetAvailableCustomerIdQuery, Guid>
    {
        private readonly CustomerStates _archive;

        public GetAvailableCustomerIdQueryHandler(CustomerStates archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public Guid Handle(GetAvailableCustomerIdQuery query)
        {
            Guid returnValue;
            do
            {
                returnValue = Guid.NewGuid();
            }
            while (_archive.HasCustomer(returnValue));

            return returnValue;
        }
    }
}
