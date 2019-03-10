using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetAvailableAccountIdQuery : IQuery<Guid> { }

    public sealed class GetAvailableAccountIdQueryHandler : IQueryHandler<GetAvailableAccountIdQuery, Guid>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAvailableAccountIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Guid Handle(GetAvailableAccountIdQuery query)
        {
            Guid returnValue;
            do
            {
                returnValue = Guid.NewGuid();
            }
            while (_accountRepository.HasAccount(returnValue));

            return returnValue;
        }
    }
}
